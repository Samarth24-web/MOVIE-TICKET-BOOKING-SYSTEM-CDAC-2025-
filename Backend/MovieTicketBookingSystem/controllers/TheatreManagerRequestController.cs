using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.controllers
{
    [ApiController]
    [Route("api/theaterManagerRequest")]
    public class TheatreManagerRequestController : Controller
    {
        private readonly ITheatreManageRequestService _service;

        public TheatreManagerRequestController(ITheatreManageRequestService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("{UserId}")]
        [Authorize(Roles = "User")]
        public IActionResult Create(TheatreManagerRequest request, long UserId)
        {
            var result = _service.CreateRequest(request, UserId);
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllRequests());
        }

        [HttpPut("approve/{requerstId}/{adminId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Approve(long requerstId, long adminId)
        {
            _service.Approve(requerstId, adminId);
            return Ok("Request approved");
        }

        [HttpPut("reject/{requerstId}/{adminId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Reject(long requerstId, long adminId, [FromQuery] string reason)
        {
            _service.Reject(requerstId, reason, adminId);
            return Ok("Request rejected");
        }
    }
}
