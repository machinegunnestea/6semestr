using AutoMapper;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ВLL.DTO;

namespace ВLL.Profiles
{
    public class CarProfile:Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDTO>().ForMember(x=>x.Title,w=>w.MapFrom(e=>e.Name)).ReverseMap();
        }
    }
}
