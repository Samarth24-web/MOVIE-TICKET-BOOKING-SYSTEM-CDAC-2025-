namespace MovieTicketBookingSystem.Infrastructure.PaymentGateways
{
    public interface IPaymentGateway
    {
        string CreateOrder(decimal amount, string currency, string receiptId);

        bool VerifyPayment(
            string orderId,
            string paymentId,
            string signature);

        string FetchPaymentStatus(string paymentId);
    }
}
