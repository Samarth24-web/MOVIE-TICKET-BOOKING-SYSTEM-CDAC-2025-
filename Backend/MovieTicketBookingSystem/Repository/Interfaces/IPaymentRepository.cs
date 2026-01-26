using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface IPaymentRepository
    {
        Payment Add(Payment payment);
        Payment GetByOrderId(string gatewayOrderId);
        void Update(Payment payment);
        List<Payment> GetPendingPayments();
    }
}
