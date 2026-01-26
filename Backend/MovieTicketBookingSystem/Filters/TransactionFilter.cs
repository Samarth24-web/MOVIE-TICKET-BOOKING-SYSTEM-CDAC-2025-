using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Storage;
using MovieTicketBookingSystem.Data;

namespace MovieTicketBookingSystem.Filters
{
    public class TransactionFilter : IActionFilter
    {
        private readonly MovieBookingDbContext _dbContext;
        private IDbContextTransaction _transaction;

        public TransactionFilter(MovieBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                _transaction.Commit();
            }
            else
            {
                _transaction.Rollback();
            }
        }
    }

}
