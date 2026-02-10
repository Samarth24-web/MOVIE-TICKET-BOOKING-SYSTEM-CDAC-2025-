using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface ILanguageRepository
    {
        List<Language> findAllLanguages();
        Language findById(long languageId);
    }
}
