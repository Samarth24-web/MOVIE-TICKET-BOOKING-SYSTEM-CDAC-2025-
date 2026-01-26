namespace MovieTicketBookingSystem.Utilities
{
    public static class TimeValidator
    {
        public static void ValidateCancellationTime(
            DateTime showDate,
            TimeSpan startTime,
            DateTime currentTime)
        {
            var showStart = showDate.Date.Add(startTime);

            if ((showStart - currentTime).TotalHours < 3)
            {
                throw new Exception("Cancellation is not allowed within 3 hours of show start time.");
            }
        }

        public static void ValidateShowRegistrationDate(
            DateTime showDate,
            DateTime currentDate)
        {
            if ((showDate.Date - currentDate.Date).TotalDays < 3)
            {
                throw new Exception("Show must be registered at least 3 days before show date.");
            }
        }

        public static bool IsLockExpired(DateTime lockExpiryTime)
        {
            return DateTime.UtcNow > lockExpiryTime;
        }
    }
}
