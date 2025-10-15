using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET api/Booking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingViewModel>>> GetTick()
        {
            List<BookingViewModel> result = await _bookingService.GetBookingViewModelAsync();

            return Ok(result);
        }

    }
}
