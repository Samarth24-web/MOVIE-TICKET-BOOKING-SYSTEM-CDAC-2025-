using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Services.Implementation;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.controllers
{
    [Route("api/languages")]
    [ApiController]
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService) {
            _languageService = languageService;
        }

        [HttpGet]
        public List<Language> getAllLanguages()
        {
            return _languageService.getAllLanguages();
        }
    }
}
