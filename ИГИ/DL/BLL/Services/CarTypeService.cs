using AutoMapper;
using DL.Entities;
using DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ВLL.DTO;
using ВLL.Interfaces.EntityServices;

namespace ВLL.Services
{
    public class CarTypeService : ICarTypeService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper mapper;
        public CarTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public void Create(CarTypeDTO item)
        {
            _unitOfWork.CarType.Create(mapper.Map<CarType>(item));
        }

        public void Delete(int id)
        {
            _unitOfWork.CarType.Delete(id);
        }

        public IEnumerable<CarTypeDTO> Find(string typeName)
        {
            return mapper.Map<IEnumerable<CarType>, IEnumerable<CarTypeDTO>>(_unitOfWork.CarType.Find(name => name.Title==typeName)); 
        }

        public IEnumerable<CarTypeDTO> Get()
        {
            return mapper.Map<IEnumerable<CarType>, IEnumerable<CarTypeDTO>>(_unitOfWork.CarType.Get());
        }
    }
}
