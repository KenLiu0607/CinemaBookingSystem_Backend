using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class HomeService
    {
        private readonly CinemaDbContext _context;

        public HomeService(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetMoviesAsync()
        {
            List<Movie> movies = await _context.Movies.ToListAsync();
            return movies;
        }
    }
}
