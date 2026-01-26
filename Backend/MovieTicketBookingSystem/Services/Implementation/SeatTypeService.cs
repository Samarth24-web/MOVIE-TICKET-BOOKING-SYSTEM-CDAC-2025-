using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class SeatTypeService : ISeatTypeService
    {
        private readonly ISeatTypeRepository _seatTypeRepository;

        public SeatTypeService(ISeatTypeRepository seatTypeRepository)
        {
            _seatTypeRepository = seatTypeRepository;
        }

        public List<SeatType> GetAll()
        {
            return _seatTypeRepository.GetAll();
        }
    }
}
