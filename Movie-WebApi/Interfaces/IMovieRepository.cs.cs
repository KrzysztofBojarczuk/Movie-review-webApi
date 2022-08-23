using Movie_WebApi.Models;

namespace Movie_WebApi.Interfaces
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieAsyncById(int id);
        Task<Movie> GetMovieAsync(string name);
        Task<bool> MovieExistsAsync(int movieId);
        Task<bool> CreateMovieAsync(Movie movie);
        Task<bool> UpdateMovieAsync(Movie movie);
        Task<bool> DeleteBookAsync(Movie movie);
        Task<bool> SaveAsync();
    }
}
