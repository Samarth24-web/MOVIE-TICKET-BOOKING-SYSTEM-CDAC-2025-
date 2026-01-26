namespace MovieTicketBookingSystem.DTOs.Movie
{
    public class MovieResponseDto
    {
        public long? MovieId { get; set; }
        public string Title { get; set; }
        public int? Duration { get; set; }
        public decimal? Rating { get; set; }
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? ImageUrl { get; set; }

        public List<string> Genres { get; set; }
        public List<string> Languages { get; set; }
    }
}
