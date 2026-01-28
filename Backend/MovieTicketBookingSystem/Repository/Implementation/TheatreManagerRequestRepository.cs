using Microsoft.EntityFrameworkCore;
using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class TheatreManagerRequestRepository : ITheatreManagerRequestRepository
    {
        private readonly MovieBookingDbContext _context;

        public TheatreManagerRequestRepository(MovieBookingDbContext context)
        {
            _context = context;
        }

        public TheatreManagerRequest CreateRequest(TheatreManagerRequest request)
        {
            _context.TheatreManagerRequests.Add(request);
            _context.SaveChanges();
            return request;
        }

        public List<TheatreManagerRequest> GetAll()
        {
            return _context.TheatreManagerRequests
                .Include(x => x.City)
                .ToList();
        }

        public void Approve(long requestId, long adminId)
        {
            var req = _context.TheatreManagerRequests
                .Include(r => r.RequestedByUser)
                .FirstOrDefault(r => r.RequestId == requestId);

            if (req == null || req.Status != "Pending")
                throw new Exception("Invalid request");


            var theatre = new Theatre
            {
                TheatreName = req.TheatreName,
                TheaterAddressUrl = req.TheaterAddressUrl,
                Address = req.Address,
                CityId = req.CityId,
                ManagerId = req.UserId,
                ApprovedByAdminId = adminId,
            };

            _context.Theatres.Add(theatre);

            var user = _context.Users.Find(req.UserId);
            if (user == null)
                throw new Exception("User not found");

            user.RoleId = 2; 

            req.Status = "Approved";
            req.ReviewedByAdminId = adminId;
            req.ReviewedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }


        public void Reject(long requestId, string reason, long adminId)
        {
            var req = _context.TheatreManagerRequests.Find(requestId);
            if (req == null || req.Status != "Pending")
                throw new Exception("Invalid request");

            req.Status = "Rejected";
            req.RejectionReason = reason;
            req.ReviewedByAdminId = adminId;
            req.ReviewedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }

        public TheatreManagerRequest GetByUser(long userId)
        {
            return _context?.TheatreManagerRequests
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.RequestedAt)
                .FirstOrDefault();
        }


    }
}
