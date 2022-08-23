namespace Movie_WebApi.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public DateTime Releasedate { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
