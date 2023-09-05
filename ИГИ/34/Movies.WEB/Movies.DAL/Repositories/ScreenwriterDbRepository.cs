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
    public class ScreenwriterDbRepository : IRepository<Screenwriter>
    {
        private readonly AppDbContext _context;

        public ScreenwriterDbRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Create(Screenwriter item)
        {
            _context.Screenwriters.Add(item);
        }

        public void Delete(int id)
        {
            var item = _context.Screenwriters.Find(id);
            if (item != null)
            {
                _context.Screenwriters.Remove(item);
            }
            else
            {
                throw new Exception("Такой человек не найден");
            }
        }

        public IEnumerable<Screenwriter> Find(Func<Screenwriter, bool> predicate)
        {
            return _context.Screenwriters.Where(predicate).ToList();
        }

        public IEnumerable<Screenwriter> Get()
        {
            return _context.Screenwriters.ToList();
        }

        public Screenwriter Get(int id)
        {
            var item = _context.Screenwriters.Find(id);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception("Такой человек не найден");
            }
        }

        public void Update(Screenwriter item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
