using MovieTicketBookingSystem.DTOs.Show;

namespace MovieTicketBookingSystem.DTOs.Screen
{
    public class ScreenMovieShowsDto
    {
        public long TheatreId { get; set; }
        public string TheatreName { get; set; }

        public long ScreenId { get; set; }
        public string ScreenName { get; set; }

        public long MovieId { get; set; }
        public string MovieName { get; set; }

        public List<ShowTimeDto> Shows { get; set; }
    }
}
