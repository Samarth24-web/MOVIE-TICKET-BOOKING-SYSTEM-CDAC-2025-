using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly MovieBookingDbContext _context;

        public LanguageRepository(MovieBookingDbContext context)
        {
            _context = context;
        }

        public List<Language> findAllLanguages()
        {
            List<Language> languages = (from l in _context.Languages
                                        orderby l.LanguageName
                                        select l).ToList();
            return languages;
        }

        public Language findById(long languageId)
        {
            return _context.Languages.FirstOrDefault(l => l.LanguageId == languageId);
        }

    }
}
