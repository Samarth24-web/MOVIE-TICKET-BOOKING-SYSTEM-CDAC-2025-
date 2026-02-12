using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieTicketBookingSystem.Constats;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.BackgroundJobs
{
    public class PendingBookingCleanupJob : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public PendingBookingCleanupJob(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();

                var bookingRepo = scope.ServiceProvider
                    .GetRequiredService<IBookingRepository>();

                var seatRepo = scope.ServiceProvider
                    .GetRequiredService<IShowSeatStatusRepository>();

                var expiredBookings =
                    bookingRepo.GetExpiredPendingBookings(
                        DateTime.UtcNow.AddMinutes(-5));

                foreach (var booking in expiredBookings)
                {
                    var seats = seatRepo.GetSeatsByBookingId(booking.BookingId);

                    foreach (var seat in seats)
                    {
                        seat.Status = SeatStatus.Available;
                        seat.LockedByUserId = null;
                        seat.LockStartTime = null;
                        seat.LockExpiryTime = null;
                        seat.BookingId = null;
                    }

                    seatRepo.UpdateRange(seats);
                    bookingRepo.MarkCancelled(booking.BookingId);
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
