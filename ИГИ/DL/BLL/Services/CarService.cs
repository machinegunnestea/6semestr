using AutoMapper;
using BLL.Interfaces.EntityServices;
using DL.Entities;
using DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ВLL.DTO;

namespace ВLL.Services
{
    public class CarService:ICarService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper mapper;
        public CarService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Create(CarDTO item)
        {
            _unitOfWork.Car.Create(mapper.Map<Car>(item));
        }

        public void Delete(int id)
        {
            _unitOfWork.Car.Delete(id);
        }

        public IEnumerable<CarDTO> Find(int cost)
        {
            return mapper.Map<IEnumerable<Car>, IEnumerable<CarDTO>>(_unitOfWork.Car.Find(name => name.Cost ==cost));
        }

        public IEnumerable<CarDTO> Get()
        {
            return mapper.Map<IEnumerable<Car>, IEnumerable<CarDTO>>(_unitOfWork.Car.Get());
        }
    }
}
