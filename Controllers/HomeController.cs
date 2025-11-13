using Backend.Data;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using OpenAI;
namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly HomeService _homeService;

        public HomeController(HomeService homeService)
        {
            this._homeService = homeService;
        }

        //GET api/Movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            List<Movie> result = await _homeService.GetMoviesAsync();

            //ChatClient client = new(model: "gpt-5-nano", apiKey: Environment.GetEnvironmentVariable("Cinema_RAG"));

            //ChatCompletion completion = client.CompleteChat("這是一個測試");

            //string content = completion.Content[0].Text;

            //OpenAIClient client = new(Environment.GetEnvironmentVariable("Cinema_RAG"));



            return Ok(result);
        }
    }
}
