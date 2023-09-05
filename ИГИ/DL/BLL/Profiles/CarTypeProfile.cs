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
    public class CarTypeProfile:Profile
    {
        public CarTypeProfile()
        {
            CreateMap<CarType, CarTypeDTO>().ReverseMap();
        }
    }
}
