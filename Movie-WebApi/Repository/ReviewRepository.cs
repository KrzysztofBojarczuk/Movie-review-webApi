using Microsoft.EntityFrameworkCore;
using Movie_WebApi.Data;
using Movie_WebApi.Interfaces;
using Movie_WebApi.Models;

namespace Movie_WebApi.Repository
{
    public class ReviewRepository : IReviewRepository
    {

        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Review> CreateReviewAsync(int movieId, Review review)
        {
           var movie = await _context.Movies.Include(h => h.Reviews).FirstOrDefaultAsync(h => h.MovieId == movieId);

            movie.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
                 
        }

        public async Task<Review> DeleteReviewAsync(int movieId, int reviewId)
        {
           var review = await _context.Reviews.SingleOrDefaultAsync(r => r.ReviewId == reviewId && r.MovieId == movieId);

            if (review == null)
            {
                return null;
            }
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review> GetReviewByIdIdAsync(int movieId, int reviewId)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(r => r.MovieId == movieId && r.ReviewId == reviewId);

            if (review == null)
            {
                return null;
            }
            return review;
        }

        public async Task<ICollection<Review>> GetReviewsOfAMovieAsync(int movieId)
        {
            return await _context.Reviews.Where(r => r.MovieId == movieId).ToListAsync();
                 
        }

        public async Task<Review> UpdateReviewAsync(int movieId, Review updateReview)
        {
            _context.Reviews.Update(updateReview);
            await _context.SaveChangesAsync();
            return updateReview;
        }
        //public async Task<ICollection<Review>> GetReviewsAsync()
        //{

        //        return await _context.Reviews.OrderBy(p => p.Id).ToListAsync();

        //}
        //public async Task<bool> SaveAsync()
        //{
        //    var saved = await _context.SaveChangesAsync();
        //    return saved > 0 ? true : false;
        //}

        //public async Task<Review> GetReviewIdAsync(int reviewId)
        //{
        //    return await _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefaultAsync();
        //}

        //public async Task<ICollection<Review>> GetReviewsOfAMovieAsync(int movieId)
        //{
        //    return await _context.Reviews.Where(r => r.Id == movieId).OrderBy(p => p.Id).ToListAsync();
        //}

        //public async Task<bool> ReviewExistsAsync(int reviewId)
        //{
        //    return await _context.Reviews.AnyAsync(r => r.Id == reviewId);
        //}

        //public async Task<Review> CreateReviewAsync(int movieId,Review createReview)
        //{
        //    var movie = await _context.Movies.Include(h => h.Id).FirstOrDefaultAsync(r => r.Id == movieId);


        //    movie.Ad (review);
        //    await _context.SaveChangesAsync();
        //    return review;
        //}

        //public async Task<bool> UpdateReviewAsync(Review review)
        //{
        //    _context.Update(review);
        //    return await SaveAsync();
        //}
        //public async Task<bool> DeleteReviewAsync(Review review)
        //{
        //    _context.Remove(review);
        //    return await SaveAsync();
        //}

        //public async Task<bool> DeleteReviewsAsync(List<Review> reviews)
        //{
        //    _context.RemoveRange(reviews);
        //    return await SaveAsync();
        //}
    }
}
