namespace MovieTicketBookingSystem.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public long UserId { get; set; }
        public string Role { get; set; }
    }
}
