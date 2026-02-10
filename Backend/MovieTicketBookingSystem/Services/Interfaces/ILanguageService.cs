using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface ILanguageService
    {
        List<Language> getAllLanguages();
        Language getLanguageById(long languageId);
    }
}
