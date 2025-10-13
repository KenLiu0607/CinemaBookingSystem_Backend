using Backend.Data;
using Backend.Models; // 依你的命名空間調整
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowTimeController : ControllerBase
    {
        private readonly CinemaDbContext _context;

        public ShowTimeController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET api/Seat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetTick()
        {
            var result = await _context.Showtimes
            .GroupJoin(
                _context.Halls,
                s => s.HallId,
                h => h.Id,
                (s, halls) => new { s, halls }
            )
            .ToListAsync();
            return Ok(result);
        }
    }
}
