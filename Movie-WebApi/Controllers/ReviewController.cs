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
    public class ReviewController : ControllerBase
    {

        private readonly IReviewRepository _reviewReposiotry;
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public ReviewController(IMapper mapper, IReviewRepository reviewReposiotry, IMovieRepository movieRepository)
        {

            _mapper = mapper;
            _reviewReposiotry = reviewReposiotry;
            _movieRepository = movieRepository;
        }



        [HttpGet("movie/{movieId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllReviews(int movieId)
        {
            var reviews = await _reviewReposiotry.GetReviewsOfAMovieAsync(movieId);
            var mappedReview = _mapper.Map<List<ReviewDto>>(reviews);

            return Ok(mappedReview);

        }
        [HttpGet("{movieId}/reviews/{reviewId}")]
        public async Task<IActionResult> GetReviewsForMovie(int movieId, int reviewId)
        {
            var review = await _reviewReposiotry.GetReviewByIdIdAsync(movieId, reviewId);
            var mappedComnet = _mapper.Map<ReviewDto>(review);
            return Ok(mappedComnet);
        }

        [HttpPost("{movieId}/reviews")]
        public async Task<IActionResult> AddReviewMovie(int movieId, [FromBody] ReviewCreateDto newReview)
        {
            var review = _mapper.Map<Review>(newReview);

            await _reviewReposiotry.CreateReviewAsync(movieId, review);

            var mappedReview = _mapper.Map<ReviewDto>(review);
            return CreatedAtAction(nameof(GetAllReviews), new { movieId = movieId, reviewId = mappedReview}, mappedReview );
        }


        [HttpPut("{movieId}/review/{reviewId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateReview(int movieId,int reviewId, [FromBody] ReviewCreateDto reviewCreate)
        {
            var toUpdate = _mapper.Map<Review>(reviewCreate);
            toUpdate.ReviewId = reviewId;
            toUpdate.MovieId = movieId;

            await _reviewReposiotry.UpdateReviewAsync(movieId, toUpdate);
            return NoContent();
        }

        [HttpDelete("{movieId}/review/{reviewId}")]
        public async Task<IActionResult> DeleteReview(int movieId, int reviewId)
        {
            var review = await _reviewReposiotry.DeleteReviewAsync(movieId, reviewId);

            if (review == null)
            {
                return NotFound("Review not found");
            }
            return NoContent();
        }

             
    }
}
