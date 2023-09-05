using AutoMapper;
using DAL.Entities;
using ВLL.DTO;

namespace ВLL.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
