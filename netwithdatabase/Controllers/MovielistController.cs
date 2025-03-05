using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using netwithdatabase.Models;
using netwithdatabase.Services;

namespace netwithdatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovielistController : ControllerBase
    {
        private readonly MongoDBService _mongoDBService;
        public MovielistController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Movielist>>> Get()
        {
            var movies = await _mongoDBService.GetMovieAsync();
            return Ok(movies);
            //return await _mongoDBService.GetMovieAsync();
        }
    }
}
