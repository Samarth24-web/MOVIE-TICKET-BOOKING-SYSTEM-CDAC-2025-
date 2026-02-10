using MovieTicketBookingSystem.Configuration;
using Razorpay;
using Razorpay.Api;
using Razorpay.Api.Errors;
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
                { "receipt", receiptId },
                { "payment_capture", 1 }
            };

            var order = _client.Order.Create(options);
            return order["id"].ToString();
        }

        public bool VerifyPayment(
            string orderId,
            string paymentId,
            string signature)
        {


            Dictionary< string, string> attributes = new Dictionary<string, string>
                    {
                        { "razorpay_payment_id", paymentId },
                        { "razorpay_order_id", orderId },
                        { "razorpay_signature", signature }
                    };
    
            try
            {
                Razorpay.Api.Utils.verifyPaymentSignature(attributes);
                return true;
            }
            catch (SignatureVerificationError)
            {
                return false;
            }
        }
        public string FetchPaymentStatus(string paymentId)
        {
            var payment = _client.Payment.Fetch(paymentId);
            return payment["status"].ToString();
        }
    }

}
