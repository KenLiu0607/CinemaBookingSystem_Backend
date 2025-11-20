using Backend.Data;
using Backend.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Backend.OpenAIFunction
{
    public enum QueryStatus
    {
        NowShowing,
        ComingSoon
    }
    public class OpenAIFunction
    {

        private readonly CinemaDbContext _context;
        private OpenAIFunction(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetMovies()
        {
            List<Movie> movies = await _context.Movies.ToListAsync();
            return JsonSerializer.Serialize(movies);
        }
        //public async Task<List<Movie>> QueryMovies(QueryStatus status, Movie movie)
        //{
        //    switch (status)
        //    {
        //        case QueryStatus.NowShowing:
        //            DateTime today = DateTime.Today;
        //            List<Movie> movies = await _context.Movies
        //                .Where(m => today >= m.StartDate.ToDateTime(TimeOnly.MinValue) && today <= m.EndDate.ToDateTime(TimeOnly.MaxValue))
        //                .ToListAsync();
        //            // 還沒加上
        //            return movies;
        //        case QueryStatus.ComingSoon:


        //            return await GetComingSoonMovies();
        //        default:



        //            return new List<Movie>();
        //    }
        //    return movies;
        //}

    }
}
