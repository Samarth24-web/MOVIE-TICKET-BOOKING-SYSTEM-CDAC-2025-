using Microsoft.EntityFrameworkCore.Storage;
using MovieTicketBookingSystem.Data;

namespace MovieTicketBookingSystem.Infrastructure.Transactions
{
    public class TransactionManager
    {
        private readonly MovieBookingDbContext _context;

        public TransactionManager(MovieBookingDbContext context)
        {
            _context = context;
        }

        public IDbContextTransaction Begin()
        {
            return _context.Database.BeginTransaction();
        }

        public void Commit(IDbContextTransaction transaction)
        {
            transaction.Commit();
        }

        public void Rollback(IDbContextTransaction transaction)
        {
            transaction.Rollback();
        }
    }
}
