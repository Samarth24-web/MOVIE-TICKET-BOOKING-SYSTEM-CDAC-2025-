namespace MovieTicketBookingSystem.Utilities
{
    public class DateTimeProvider
    {
        public virtual DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }

        public virtual DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
