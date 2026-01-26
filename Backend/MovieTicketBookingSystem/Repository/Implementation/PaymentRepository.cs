using Microsoft.EntityFrameworkCore;
using MovieTicketBookingSystem.Constats;
using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly MovieBookingDbContext _db;

        public PaymentRepository(MovieBookingDbContext db)
        {
            _db = db;
        }

        public List<Payment> GetPendingPayments()
        {
            if (_db?.Payments == null)
                return new List<Payment>();

            return _db.Payments
                .Where(p => p.Status == PaymentStatus.Pending)
                .ToList();
        }
        public Payment Add(Payment payment)
        {
            _db.Payments.Add(payment);
            _db.SaveChanges();
            return payment;
        }

        public Payment GetByOrderId(string gatewayOrderId)
        {
            return _db.Payments
                .First(x => x.GatewayOrderId == gatewayOrderId);
        }

        public void Update(Payment payment)
        {
            _db.Payments.Update(payment);
            _db.SaveChanges();
        }
    }
}
