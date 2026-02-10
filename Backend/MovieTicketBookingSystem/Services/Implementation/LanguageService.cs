using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class LanguageService: ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public List<Language> getAllLanguages()
        {
            return _languageRepository.findAllLanguages();
        }

        public Language getLanguageById(long languageId)
        {
             return _languageRepository.findById(languageId);
        }
    }
}
