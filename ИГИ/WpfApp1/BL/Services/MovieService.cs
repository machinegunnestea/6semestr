using AutoMapper;
using BLL.DTO;
using BLL.Interfaces.EntityServices;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;

namespace ВLL.Services
{
    public class MovieService:IMovieService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper mapper;
        public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Create(MovieDTO item)
        {
            _unitOfWork.Movie.Create(mapper.Map<Movie>(item));
        }

        public void Delete(int id)
        {
            _unitOfWork.Movie.Delete(id);
        }

        public IEnumerable<MovieDTO> Find(int cost)
        {
            return mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(_unitOfWork.Movie.Find(name => name.Cost ==cost));
        }

        public IEnumerable<MovieDTO> Get()
        {
            return mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(_unitOfWork.Movie.Get());
        }
    }
}
