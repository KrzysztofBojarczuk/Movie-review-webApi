using Microsoft.EntityFrameworkCore;
using Movie_WebApi.Models;

namespace Movie_WebApi.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
