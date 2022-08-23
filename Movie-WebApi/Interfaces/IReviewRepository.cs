using Movie_WebApi.Models;

namespace Movie_WebApi.Interfaces
{
    public interface IReviewRepository
    {
        //Task<ICollection<Review>> GetReviewsAsync();
        //Task<bool> ReviewExistsAsync(int reviewId);
        Task<ICollection<Review>> GetReviewsOfAMovieAsync(int movieId);
        Task<Review> GetReviewByIdIdAsync(int movieId, int reviewId);
       
        Task<Review> CreateReviewAsync(int movieId,Review review);
       
        Task<Review> UpdateReviewAsync(int movieId,Review review);

       
        Task<Review> DeleteReviewAsync(int movieId, int reviewId);
      
        //Task<bool> DeleteReviewsAsync(List<Review> reviews);
        //Task<bool> SaveAsync();
    }
}
