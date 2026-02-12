using MovieTicketBookingSystem.Constats;
using MovieTicketBookingSystem.DTOs.Booking;
using MovieTicketBookingSystem.DTOs.Payment;
using MovieTicketBookingSystem.Infrastructure.PaymentGateways;
using MovieTicketBookingSystem.Mappers;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepo;
        private readonly IBookingRepository _bookingRepo;
        private readonly IShowSeatStatusRepository _seatStatusRepo;
        private readonly ISeatStatusLogRepository _logRepo;
        private readonly IPaymentGateway _gateway;

        public PaymentService(
            IPaymentRepository paymentRepo,
            IBookingRepository bookingRepo,
            IShowSeatStatusRepository seatStatusRepo,
            ISeatStatusLogRepository logRepo,
            IPaymentGateway gateway)
        {
            _paymentRepo = paymentRepo;
            _bookingRepo = bookingRepo;
            _seatStatusRepo = seatStatusRepo;
            _logRepo = logRepo;
            _gateway = gateway;
        }

        // 1️⃣ INITIATE PAYMENT (called from PaymentController)
        public RazorpayOrderDto CreatePaymentOrder(BookingPaymentInitDto dto)
        {
            var booking = _bookingRepo.GetById(dto.BookingId);

            if (booking == null)
                throw new Exception("Invalid booking");

            if (booking.Status != BookingStatus.Pending)
                throw new Exception("Booking is not in payable state");

            var orderId = _gateway.CreateOrder(
                booking.TotalAmount,
                "INR",
                $"booking_{booking.BookingId}");

            var payment = new Payment
            {
                BookingId = booking.BookingId,
                GatewayName = "Razorpay",
                GatewayOrderId = orderId,
                Amount = booking.TotalAmount,
                Currency = "INR",
                Status = PaymentStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            _paymentRepo.Add(payment);

            return new RazorpayOrderDto
            {
                OrderId = orderId,
                Amount = booking.TotalAmount,
                Currency = "INR",
                BookingId = booking.BookingId
            };
        }

        // 2️⃣ VERIFY PAYMENT (called after Razorpay success)
        public PaymentResponseDto VerifyPayment(RazorpayPaymentVerifyDto dto)
        {
            var isValid = _gateway.VerifyPayment(
                dto.RazorpayOrderId,
                dto.RazorpayPaymentId,
                dto.RazorpaySignature);

            if (!isValid)
                throw new Exception("Payment verification failed");

            var payment = _paymentRepo.GetByOrderId(dto.RazorpayOrderId);
            payment.GatewayPaymentId = dto.RazorpayPaymentId;
            payment.GatewaySignature = dto.RazorpaySignature;
            payment.Status = PaymentStatus.Paid;
            payment.PaidAt = DateTime.UtcNow;

            _paymentRepo.Update(payment);

            var booking = _bookingRepo.GetById(payment.BookingId);
            booking.Status = BookingStatus.Confirmed;
            booking.BookedAt = DateTime.UtcNow;

            _bookingRepo.Update(booking);

            var seats = _seatStatusRepo.GetSeatsByBookingId(booking.BookingId);

            foreach (var seat in seats)
            {
                var oldStatus = seat.Status;

                seat.Status = SeatStatus.Booked;
                seat.PriceAtBooking = seat.Seat.Price;
                seat.LastUpdatedAt = DateTime.UtcNow;

                _seatStatusRepo.Update(seat);

                _logRepo.Add(new SeatStatusLog
                {
                    ShowId = seat.ShowId,
                    SeatId = seat.SeatId,
                    OldStatus = oldStatus,
                    NewStatus = SeatStatus.Booked,
                    BookingId = booking.BookingId,
                    ChangedByUserId = booking.UserId,
                    ChangedAt = DateTime.UtcNow
                });
            }

            return PaymentMapper.PaymentToPaymentResponseDto(
                payment,
                "Payment successful, seats booked");
        }
    }
}
