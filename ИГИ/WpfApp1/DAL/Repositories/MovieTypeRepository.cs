using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class MovieTypeRepository : IRepository<MovieType>
    {
        private readonly MovieRentContext movieRentContext;
        public MovieTypeRepository(MovieRentContext movieRentContext)
        {
            this.movieRentContext = movieRentContext;
        }
        public void Create(MovieType item)
        {
            movieRentContext.MovieType.Add(item);
            movieRentContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = movieRentContext.MovieType.Find(id);
            if (item != null)
            {
                movieRentContext.MovieType.Remove(item);
            }
            else
            {
                throw new Exception("Такой тип не найден");
            }
            movieRentContext.SaveChanges();
        }

        public IEnumerable<MovieType> Find(Func<MovieType, bool> predicate)
        {
            return movieRentContext.MovieType.Where(predicate).ToList();
        }

        public IEnumerable<MovieType> Get()
        {
            return movieRentContext.MovieType.ToList();
        }
    }
}
