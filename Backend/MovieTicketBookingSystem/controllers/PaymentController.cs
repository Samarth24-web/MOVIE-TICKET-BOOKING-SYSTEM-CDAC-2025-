using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingSystem.DTOs.Booking;
using MovieTicketBookingSystem.DTOs.Payment;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("initiate")]
        public IActionResult InitiatePayment(BookingPaymentInitDto dto)
        {
            var order = _paymentService.CreatePaymentOrder(dto);
            return Ok(order);
        }

        [HttpPost("verify")]
        public IActionResult VerifyPayment(RazorpayPaymentVerifyDto dto)
        {
            var response = _paymentService.VerifyPayment(dto);
            return Ok(response);
        }
    }
}
