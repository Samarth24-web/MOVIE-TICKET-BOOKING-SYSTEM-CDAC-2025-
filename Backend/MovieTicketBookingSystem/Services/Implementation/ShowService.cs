using MovieTicketBookingSystem.DTOs;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Implementation;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Interfaces;
using MovieTicketBookingSystem.Utils;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class ShowService : IShowService
    {
        private readonly IShowRepository _showRepo;
        private readonly ISeatRepository _seatRepo;
        private readonly ISeatRowRepository _rowRepo;
        private readonly IShowSeatStatusRepository _statusRepo;

        public ShowService(
            IShowRepository showRepo,
            ISeatRepository seatRepo,
            ISeatRowRepository rowRepo,
            IShowSeatStatusRepository statusRepo)
        {
            _showRepo = showRepo;
            _seatRepo = seatRepo;
            _rowRepo = rowRepo;
            _statusRepo = statusRepo;
        }

        public ShowDto RegisterShow(CreateShowDto dto)
        {
            Show show = ShowMapper.CreateShowDtoToShow(dto);
            show = _showRepo.Add(show);

            List<Seat> seats = _seatRepo.GetSeatsByScreen(show.ScreenId);
            List<ShowSeatStatus> statuses = new List<ShowSeatStatus>();

            foreach (Seat seat in seats)
            {
                ShowSeatStatus status = new ShowSeatStatus();
                status.ShowId = show.ShowId;
                status.SeatId = seat.SeatId;
                status.Status = "AVAILABLE";
                status.PriceAtBooking = seat.Price;
                status.LastUpdatedAt = DateTime.Now;
                status.IsActive = true;
                statuses.Add(status);
            }

            _statusRepo.AddRange(statuses);
            return ShowMapper.ShowToShowDto(show);
        }

        public ShowSeatLayoutDto GetSeatLayout(long showId)
        {
            Show show = _showRepo.GetById(showId);
            List<SeatRow> rows = _rowRepo.GetSeatRowsByScreen(show.ScreenId);
            List<ShowSeatStatus> statuses = _statusRepo.GetByShow(showId);

            ShowSeatLayoutDto layout = new ShowSeatLayoutDto();
            layout.ShowId = show.ShowId;
            layout.MovieName = show.Movie.Title;
            layout.ShowDate = show.ShowDate;
            layout.StartTime = show.StartTime;
            layout.EndTime = show.EndTime;
            layout.SeatRows = new List<ShowSeatRowDto>();

            foreach (SeatRow row in rows.OrderBy(r => r.RowOrder))
            {
                ShowSeatRowDto rowDto = new ShowSeatRowDto();
                rowDto.SeatRowId = row.SeatRowId;
                rowDto.RowName = row.RowName;
                rowDto.RowOrder = row.RowOrder;
                rowDto.Seats = new List<SeatStatusDto>();

                foreach (ShowSeatStatus s in statuses.Where(x => x.Seat.SeatRowId == row.SeatRowId))
                {
                    SeatStatusDto seatDto = new SeatStatusDto();
                    seatDto.ShowSeatStatusId= s.ShowSeatStatusId;
                    seatDto.SeatId = s.SeatId;
                    seatDto.SeatNumber = s.Seat.SeatNumber;
                    seatDto.Price = s.PriceAtBooking ?? 0;
                    seatDto.Status = s.Status;
                    rowDto.Seats.Add(seatDto);
                }

                layout.SeatRows.Add(rowDto);
            }

            return layout;
        }

        public List<ShowDto> GetPastShows(long managerId)
        {
            List<ShowDto> list = new List<ShowDto>();
            foreach (Show s in _showRepo.GetPastShows(managerId))
            {
                list.Add(ShowMapper.ShowToShowDto(s));
            }
            return list;
        }

        public List<ShowDto> GetUpcomingShows(long managerId)
        {
            List<ShowDto> list = new List<ShowDto>();
            foreach (Show s in _showRepo.GetUpcomingShows(managerId))
            {
                list.Add(ShowMapper.ShowToShowDto(s));
            }
            return list;
        }

        public ShowDto GetById(long id)
        {
            Show s= _showRepo.GetById(id);

            return ShowMapper.ShowToShowDto(s);
        }

        public List<ScreenMovieShowsDto> GetShowsByCityMovieDate(
    string city,
    long movieId,
    DateTime date)
        {
            var shows = _showRepo
                .GetShowsByCityMovieDate(city, movieId, date);

            var result = shows
                .GroupBy(s => s.ScreenId)   
                .Select(screenGroup =>
                {
                    var firstShow = screenGroup.First();

                    return new ScreenMovieShowsDto
                    {
                        TheatreId = firstShow.Screen.Theatre.TheatreId,
                        TheatreName = firstShow.Screen.Theatre.TheatreName,

                        ScreenId = firstShow.ScreenId,
                        ScreenName = firstShow.Screen.ScreenName,

                        MovieId = firstShow.MovieId,
                        MovieName = firstShow.Movie.Title,

                        Shows = screenGroup
                            .OrderBy(s => s.StartTime)
                            .Select(s => new ShowTimeDto
                            {
                                ShowId = s.ShowId,
                                StartTime = s.StartTime,
                                EndTime = s.EndTime,
                                Date = s.ShowDate
                            })
                            .ToList()
                    };
                })
                .ToList();

            return result;
        }

    }

}
