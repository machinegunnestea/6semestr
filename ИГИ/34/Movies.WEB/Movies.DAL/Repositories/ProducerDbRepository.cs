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
    public class ProducerDbRepository : IRepository<Producer>
    {
        private readonly AppDbContext _context;

        public ProducerDbRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Create(Producer item)
        {
            _context.Producers.Add(item);
        }

        public void Delete(int id)
        {
            var item = _context.Producers.Find(id);
            if (item != null)
            {
                _context.Producers.Remove(item);
            }
            else
            {
                throw new Exception("Такой человек не найден");
            }
        }

        public IEnumerable<Producer> Find(Func<Producer, bool> predicate)
        {
            return _context.Producers.Where(predicate).ToList();
        }

        public IEnumerable<Producer> Get()
        {
            return _context.Producers.ToList();
        }

        public Producer Get(int id)
        {
            var item = _context.Producers.Find(id);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception("Такой человек не найден");
            }
        }

        public void Update(Producer item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

    }
}
