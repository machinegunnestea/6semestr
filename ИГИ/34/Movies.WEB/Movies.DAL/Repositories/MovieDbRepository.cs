using Microsoft.EntityFrameworkCore;
using Movies.DAL.Base;
using Movies.DAL.Context;
using Movies.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Repositories
{
    public class MovieDbRepository : IRepository<Movie>
    {
        private readonly AppDbContext _context;

        public MovieDbRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Create(Movie item)
        {
            _context.Movies.Add(item);
        }

        public void Delete(int id)
        {
            var item = _context.Movies.Find(id);
            if (item != null)
            {
                _context.Movies.Remove(item);
            }
            else
            {
                throw new Exception("Такой человек не найден");
            }
        }

        public IEnumerable<Movie> Find(Func<Movie, bool> predicate)
        {
            return _context.Movies.Where(predicate).ToList();
        }

        public IEnumerable<Movie> Get()
        {
            return _context.Movies.ToList();
        }

        public Movie Get(int id)
        {
            var item = _context.Movies.Find(id);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception("Такой человек не найден");
            }
        }

        public void Update(Movie item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

    }
}
