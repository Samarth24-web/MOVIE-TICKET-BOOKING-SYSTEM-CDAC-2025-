using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface ITheatreManagerRequestRepository
    {
        TheatreManagerRequest CreateRequest(TheatreManagerRequest request);
        void Approve(long requestId, long adminId);
        List<TheatreManagerRequest> GetAll();
        void Reject(long requestId, string reason, long adminId);
    }
}
