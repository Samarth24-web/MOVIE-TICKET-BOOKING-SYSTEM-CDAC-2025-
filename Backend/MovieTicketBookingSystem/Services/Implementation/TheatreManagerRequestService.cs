using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class TheatreManagerRequestService : ITheatreManageRequestService
    {
        private readonly ITheatreManagerRequestRepository _theaterManagerRequestRepository;
        public TheatreManagerRequestService(ITheatreManagerRequestRepository theaterManagerRequestRepository)
        {
            _theaterManagerRequestRepository = theaterManagerRequestRepository;
        }

        public TheatreManagerRequest CreateRequest(TheatreManagerRequest request, long userId)
        {
            request.UserId = userId;
            request.Status = "Pending";
            request.RequestedAt = DateTime.UtcNow;

           return _theaterManagerRequestRepository.CreateRequest(request);
        }

        public List<TheatreManagerRequest> GetAllRequests()
        {
            return _theaterManagerRequestRepository.GetAll();
        }

        public void Approve(long requestId, long adminId)
        {
            _theaterManagerRequestRepository.Approve(requestId, adminId);
        }

        public void Reject(long requestId, string reason, long adminId)
        {
            _theaterManagerRequestRepository.Reject(requestId, reason, adminId);
        }

        public object? GetByUser(long userId)
        {
            return _theaterManagerRequestRepository.GetByUser(userId);
        }
    }
}
