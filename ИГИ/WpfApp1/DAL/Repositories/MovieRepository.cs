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
    internal class MovieRepository : IRepository<Movie>
    {
        private readonly MovieRentContext movieRentContext;
        public MovieRepository(MovieRentContext movieRentContext)
        {
            this.movieRentContext = movieRentContext;
        }
        public void Create(Movie item)
        {
            movieRentContext.Movie.Add(item);
            movieRentContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = movieRentContext.Movie.Find(id);
            if (item != null)
            {
                movieRentContext.Movie.Remove(item);
            }
            else
            {
                throw new Exception("Такой фильм не найден");
            }
            movieRentContext.SaveChanges();
        }

        public IEnumerable<Movie> Find(Func<Movie, bool> predicate)
        {
            return movieRentContext.Movie.Where(predicate).ToList();
        }

        public IEnumerable<Movie> Get()
        {
            return movieRentContext.Movie.ToList();
        }
    }
}
