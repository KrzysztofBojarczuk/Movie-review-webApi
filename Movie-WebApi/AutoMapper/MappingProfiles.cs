using AutoMapper;
using Movie_WebApi.Dto;
using Movie_WebApi.Models;

namespace Movie_WebApi.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<MovieCreateDto, Movie>();
            CreateMap<Movie, MovieDto>();


            CreateMap<ReviewCreateDto, Review>();
            CreateMap<Review, ReviewDto>();

        }
    }
}
