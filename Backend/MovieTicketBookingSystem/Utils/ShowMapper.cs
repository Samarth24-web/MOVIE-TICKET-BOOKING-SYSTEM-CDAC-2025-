using MovieTicketBookingSystem.DTOs;
using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Utils
{
    public static class ShowMapper
    {
        public static Show CreateShowDtoToShow(CreateShowDto dto)
        {
            Show show = new Show();
            show.MovieId = dto.MovieId;
            show.ScreenId = dto.ScreenId;
            show.LanguageId = dto.LanguageId;
            show.ShowDate = dto.ShowDate.Date;
            show.StartTime = dto.StartTime;
            show.EndTime = dto.EndTime;
            show.CreatedByManagerId = dto.CreatedByManagerId;
            return show;
        }

        public static ShowDto ShowToShowDto(Show show)
        {
            ShowDto dto = new ShowDto();
            dto.ShowId = show.ShowId;
            dto.MovieId = show.MovieId;
            dto.ScreenId = show.ScreenId;
            dto.ShowDate = show.ShowDate;
            dto.StartTime = show.StartTime;
            dto.EndTime = show.EndTime;
            return dto;
        }
    }

}
