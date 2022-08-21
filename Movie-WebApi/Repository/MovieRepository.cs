using Microsoft.EntityFrameworkCore;
using Movie_WebApi.Data;
using Movie_WebApi.Interfaces;
using Movie_WebApi.Models;

namespace Movie_WebApi.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await _context.Movies.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Movie> GetMovieAsync(string name)
        {
            return await _context.Movies.Where(p => p.Name == name).FirstOrDefaultAsync();
        }



        public async Task<bool> CreateMovieAsync(Movie movie)
        {
            await _context.AddAsync(movie);
            return await SaveAsync();
        }


        public async Task<bool> MovieExistsAsync(int movieId)
        {
            return await _context.Movies.AnyAsync(p => p.Id == movieId);
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            _context.Update(movie);
            return await SaveAsync();
        }

        public async Task<bool> DeleteBookAsync(Movie movie)
        {

            _context.Remove(movie);
            return await SaveAsync();
        }


    }
}

