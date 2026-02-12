using Microsoft.Extensions.Hosting;
using MovieTicketBookingSystem.Constats;
using MovieTicketBookingSystem.Repository.Interfaces;

public class SeatLockExpiryJob : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public SeatLockExpiryJob(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();

            var seatRepo = scope.ServiceProvider
                .GetRequiredService<IShowSeatStatusRepository>();

            var expiredSeats = seatRepo.GetExpiredLockedSeats(DateTime.UtcNow);

            foreach (var seat in expiredSeats)
            {
                seat.Status = SeatStatus.Available;
                seat.LockedByUserId = null;
                seat.LockStartTime = null;
                seat.LockExpiryTime = null;
                seat.BookingId = null;
            }

            seatRepo.UpdateRange(expiredSeats);

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
