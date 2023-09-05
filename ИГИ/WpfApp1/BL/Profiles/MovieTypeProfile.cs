using AutoMapper;
using DAL.Entities;
using ВLL.DTO;

namespace ВLL.Profiles
{
    public class MovieTypeProfile:Profile
    {
        public MovieTypeProfile()
        {
            CreateMap<MovieType, MovieTypeDTO>().ReverseMap();
        }
    }
}
