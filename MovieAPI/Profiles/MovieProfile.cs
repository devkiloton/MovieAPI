using AutoMapper;
using MovieAPI.Data.DTO_s;
using MovieAPI.Models;
namespace MovieAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<AddMovieDTO, Movie>();
            CreateMap<Movie, ReadMovieDTO>();
            CreateMap<UpdateMovieDTO, Movie>();
        }
    }
}
