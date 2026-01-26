using MovieTicketBookingSystem.DTOs.Payment;
using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Mappers
{
    public static class PaymentMapper
    {
        public static PaymentResponseDto PaymentToPaymentResponseDto(
            Payment payment,
            string message)
        {
            return new PaymentResponseDto
            {
                PaymentId = payment.PaymentId,
                Status = payment.Status,
                Message = message
            };
        }
    }
}
