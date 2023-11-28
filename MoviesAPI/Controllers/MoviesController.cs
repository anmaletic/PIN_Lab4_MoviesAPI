using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;
using MoviesAPI.ViewModels;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesService _moviesService;

        public MoviesController(MoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = _moviesService.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet("id")]
        public IActionResult GetMovieById([FromQuery] int id)
        {
            var movie =  _moviesService.GetMovieById(id);
            return Ok(movie);
        }

        [HttpPut("id")]
        public IActionResult UpdateMovie([FromQuery] int id, [FromBody]MovieVM movie)
        {
            var updatedMovie = _moviesService.UpdateMovie(id, movie);
            return Ok(updatedMovie);
        }

        [HttpDelete("id")]
        public IActionResult DeleteMovie(int id)
        {
            _moviesService?.DeleteMovie(id);
            return Ok();
        }


        [HttpPost]
        public IActionResult AddMovie(MovieVM movie)
        {
            _moviesService.AddMovie(movie);
            return Ok();
        }
        


    }
}
