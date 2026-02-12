namespace MovieTicketBookingSystem.Configuration
{
    public class JobConfig
    {
        public int SeatLockExpiryIntervalSeconds { get; set; }
        public int PendingBookingCleanupIntervalMinutes { get; set; }
    }
}
