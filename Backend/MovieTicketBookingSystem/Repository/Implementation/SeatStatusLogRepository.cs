using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class SeatStatusLogRepository : ISeatStatusLogRepository
    {
        private readonly MovieBookingDbContext _db;

        public SeatStatusLogRepository(MovieBookingDbContext db)
        {
            _db = db;
        }

        public void AddRange(List<SeatStatusLog> logs)
        {
            _db.SeatStatusLogs.AddRange(logs);
            _db.SaveChanges();
        }

        public List<SeatStatusLog> GetByUserId(long userId)
        {
            return _db.SeatStatusLogs
                .Where(x => x.ChangedByUserId == userId)
                .OrderByDescending(x => x.ChangedAt)
                .ToList();
        }

        public List<SeatStatusLog> GetByShowId(long showId)
        {
            return _db.SeatStatusLogs
                .Where(x => x.ShowId == showId)
                .OrderByDescending(x => x.ChangedAt)
                .ToList();
        }

        public void Add(SeatStatusLog log)
        {
            _db.SeatStatusLogs.Add(log);
            _db.SaveChanges();
        }

    }
}
