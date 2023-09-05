using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace ВLL.Profiles
{
    public class MovieProfile:Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDTO>().ForMember(x=>x.Title,w=>w.MapFrom(e=>e.Name)).ReverseMap();
        }
    }
}
