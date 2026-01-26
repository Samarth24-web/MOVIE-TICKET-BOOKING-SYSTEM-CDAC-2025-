using MovieTicketBookingSystem.DTOs.Booking;
using MovieTicketBookingSystem.DTOs.Payment;
using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface IPaymentService
    {
        RazorpayOrderDto CreatePaymentOrder(BookingPaymentInitDto dto);
        PaymentResponseDto VerifyPayment(RazorpayPaymentVerifyDto dto);
    }
}
