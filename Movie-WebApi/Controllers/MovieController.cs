using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_WebApi.Dto;
using Movie_WebApi.Interfaces;
using Movie_WebApi.Models;

namespace Movie_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieReposiotry;
        private readonly IMapper _mapper;

        public MovieController(IMovieRepository movieReposiotry, IMapper mapper)
        {
            _movieReposiotry = movieReposiotry;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var getAllMvoies = await _movieReposiotry.GetMoviesAsync();
            return Ok(getAllMvoies);
        }

        [HttpGet("{movieId}")]
        [ProducesResponseType(200, Type = typeof(Movie))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetMovieId(int movieId)
        {
            var getExistMovie = await _movieReposiotry.MovieExistsAsync(movieId);

            if (!getExistMovie)
            {
                return NotFound("No objwct");
            }
            var getMovie = await _movieReposiotry.GetMovieAsyncById(movieId);

            var getMapMovie = _mapper.Map<Movie>(getMovie);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(getMapMovie);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreatePokemon([FromBody] MovieCreateDto movieCreate)
        {
            if (movieCreate == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var movieMap = _mapper.Map<Movie>(movieCreate);

            var movieGet = await _movieReposiotry.CreateMovieAsync(movieMap);
            if (!movieGet)
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }


        [HttpPut("{movieId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateMovie([FromBody] MovieCreateDto updateMovie,int movieId)
        {
            if (updateMovie == null)
            {
                return BadRequest(ModelState);
            }

            var movieExists = await _movieReposiotry.MovieExistsAsync(movieId);

            if (movieExists == null)
            {
                return NotFound("No object");
            }

            var movieMap = _mapper.Map<Movie>(updateMovie);

            movieMap.MovieId = movieId;

            var movieGet = await _movieReposiotry.UpdateMovieAsync(movieMap);

            if (!movieGet)
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{movieId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteMovie(int movieId)
        {
            var getExistmovie = await _movieReposiotry.MovieExistsAsync(movieId);
            if (!getExistmovie)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var movieToDelete = await _movieReposiotry.GetMovieAsyncById(movieId);


            if (movieToDelete == null)
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            var getMovie = await _movieReposiotry.DeleteBookAsync(movieToDelete);
            if (!getMovie)
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }
            return NoContent();
        }
    }
}
