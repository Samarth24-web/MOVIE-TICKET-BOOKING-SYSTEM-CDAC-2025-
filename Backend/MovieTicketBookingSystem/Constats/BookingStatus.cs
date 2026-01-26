namespace MovieTicketBookingSystem.Constats
{
    public static class BookingStatus
    {
        public const string Pending = "PENDING";
        public const string Confirmed = "CONFIRMED";
        public const string Cancelled = "CANCELLED";
        public const string Failed = "FAILED";
        public const string Expired = "EXPIRED";

        public static object CancelledTimeout { get; internal set; }
    }
}
