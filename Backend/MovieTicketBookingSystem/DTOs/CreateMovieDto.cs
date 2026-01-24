namespace MovieTicketBookingSystem.DTOs
{
    public class CreateMovieDto
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public decimal? Rating { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public List<long> GenreIds { get; set; }
        public List<long> LanguageIds { get; set; }

        public IFormFile? Image { get; set; }
    }
}
