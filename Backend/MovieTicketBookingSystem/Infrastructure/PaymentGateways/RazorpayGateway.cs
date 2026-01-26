using MovieTicketBookingSystem.Configuration;
using Razorpay;
using Razorpay.Api;
using System.Security.Cryptography;
using System.Text;

namespace MovieTicketBookingSystem.Infrastructure.PaymentGateways
{
    public class RazorpayGateway : IPaymentGateway
    {
        private readonly RazorpayClient _client;
        private readonly RazorpayConfig _config;

        public RazorpayGateway(RazorpayConfig config)
        {
            _config = config;
            _client = new RazorpayClient(
                config.KeyId,
                config.KeySecret);
        }

        public string CreateOrder(decimal amount, string currency, string receiptId)
        {
            var options = new Dictionary<string, object>
            {
                { "amount", (int)(amount * 100) },
                { "currency", currency },
                { "receipt", receiptId }
            };

            var order = _client.Order.Create(options);
            return order["id"].ToString();
        }

        public bool VerifyPayment(
            string orderId,
            string paymentId,
            string signature)
        {
            var payload = $"{orderId}|{paymentId}";
            var secret = _config.KeySecret;

            var generatedSignature = ComputeHmacSha256(payload, secret);

            return generatedSignature == signature;
        }

        private string ComputeHmacSha256(string data, string secret)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
            return Convert.ToBase64String(hash);
        }

        public string FetchPaymentStatus(string paymentId)
        {
            var payment = _client.Payment.Fetch(paymentId);
            return payment["status"].ToString();
        }
    }

}
