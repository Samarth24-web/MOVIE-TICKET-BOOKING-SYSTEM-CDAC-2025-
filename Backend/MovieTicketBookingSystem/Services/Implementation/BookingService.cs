using Microsoft.AspNetCore.SignalR;
using MovieTicketBookingSystem.Constats;
using MovieTicketBookingSystem.DTOs.Booking;
using MovieTicketBookingSystem.Mappers;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Interfaces;
using MovieTicketBookingSystem.SignalR;
using MovieTicketBookingSystem.Utilities;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly IShowSeatStatusRepository _seatRepo;
        private readonly IBookingRepository _bookingRepo;
        private readonly IBookingSeatRepository _bookingSeatRepo;
        private readonly ISeatStatusLogRepository _logRepo;
        private readonly IPaymentService _paymentService;
        private readonly DateTimeProvider _time;
        private readonly IHubContext<SeatLockHub> _hub;

        public BookingService(
            IShowSeatStatusRepository seatRepo,
            IBookingRepository bookingRepo,
            IBookingSeatRepository bookingSeatRepo,
            ISeatStatusLogRepository logRepo,
            IPaymentService paymentService,
            DateTimeProvider time,
            IHubContext<SeatLockHub> hub)
        {
            _seatRepo = seatRepo;
            _bookingRepo = bookingRepo;
            _bookingSeatRepo = bookingSeatRepo;
            _logRepo = logRepo;
            _paymentService = paymentService;
            _time = time;
            _hub = hub;
        }

        public BookingResultDto CreateBooking(CreateBookingDto dto)
        {
            var seatIds = dto.Seats
                .Select(x => x.ShowSeatStatusId)
                .ToList();

            var seats = _seatRepo.GetByIds(seatIds);

            // ✅ MANDATORY GUARD
            if (seats == null || !seats.Any())
                throw new Exception("No seats found for the given selection");

            // ✅ Availability check
            if (seats.Any(s => s.Status != SeatStatus.Available))
                throw new Exception("One or more seats are not available");

            // ✅ Lock seats
            foreach (var seat in seats)
            {
                seat.Status = SeatStatus.Locked;
                seat.LockedByUserId = dto.UserId;
                seat.LockStartTime = _time.UtcNow();
                seat.LockExpiryTime = _time.UtcNow().AddMinutes(5);
            }

            _seatRepo.UpdateRange(seats);

            // ✅ Create booking
            var booking = new Booking
            {
                UserId = dto.UserId,
                ShowId = seats.First().ShowId,
                Status = BookingStatus.Pending,
                CreatedAt = _time.UtcNow(),
                TotalAmount = PriceCalculator.CalculateTotalPrice(seats)
            };

            booking = _bookingRepo.Add(booking);

            // ✅ Create booking seats
            var bookingSeats = seats.Select(s => new BookingSeat
            {
                BookingId = booking.BookingId,
                ShowSeatStatusId = s.ShowSeatStatusId,
                Price = s.Seat.Price
            }).ToList();

            _bookingSeatRepo.AddRange(bookingSeats);

            // ✅ Init payment
            var paymentInitDto = new BookingPaymentInitDto
            {
                BookingId = booking.BookingId
            };

            var payment = _paymentService.CreatePaymentOrder(paymentInitDto);

            // ✅ Return correct data
            return BookingMapper.BookingToBookingResultDto(
                booking,
                payment.BookingId.ToString()
            );
        }



        public void CancelBooking(CancelBookingDto dto)
        {
            var booking = _bookingRepo.GetById(dto.BookingId);

            TimeValidator.ValidateCancellationTime(
                booking.Show.ShowDate,
                booking.Show.StartTime,
                _time.UtcNow());

            booking.Status = BookingStatus.Cancelled;
            booking.CancelledAt = _time.UtcNow();

            _bookingRepo.Update(booking);
        }
    }
}
