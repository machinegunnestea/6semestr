using AutoMapper;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using ВLL.DTO;
using ВLL.Interfaces.EntityServices;

namespace ВLL.Services
{
    public class MovieTypeService : IMovieTypeService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper mapper;
        public MovieTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public void Create(MovieTypeDTO item)
        {
            _unitOfWork.MovieType.Create(mapper.Map<MovieType>(item));
        }

        public void Delete(int id)
        {
            _unitOfWork.MovieType.Delete(id);
        }

        public IEnumerable<MovieTypeDTO> Find(string typeName)
        {
            return mapper.Map<IEnumerable<MovieType>, IEnumerable<MovieTypeDTO>>(_unitOfWork.MovieType.Find(name => name.Title==typeName)); 
        }

        public IEnumerable<MovieTypeDTO> Get()
        {
            return mapper.Map<IEnumerable<MovieType>, IEnumerable<MovieTypeDTO>>(_unitOfWork.MovieType.Get());
        }
    }
}
