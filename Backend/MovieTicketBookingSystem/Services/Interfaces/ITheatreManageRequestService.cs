using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface ITheatreManageRequestService
    {
        TheatreManagerRequest CreateRequest(TheatreManagerRequest request, long user);
        List<TheatreManagerRequest> GetAllRequests();
        void Approve(long requestId, long adminId);
        void Reject(long requestId, string reason, long adminId);
    }
}
