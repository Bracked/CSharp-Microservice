using AutoMapper;
using MovieService.Dtos;
using MovieService.Models;

namespace MovieService.Profiles
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            // Source -> Target
            CreateMap<Movie, MovieReadDto>();
            CreateMap<MovieCreateDto, Movie>();
            CreateMap<MovieReadDto, MoviePublishedDto>();
            // CreateMap<Movie, GrpcMovieModel>()
            //     .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src =>src.Id))
            //     .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>src.Name))
            //     .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src =>src.Publisher));
        }
    }
}