using Backend.Data;
using Backend.Models; // 依你的命名空間調整
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly CinemaDbContext _context;

        public HomeController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET api/Movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            List<Movie> movies = await _context.Movies.ToListAsync();
            return Ok(movies);
        }
    }
}
