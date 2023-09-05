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
    internal class UserRepository : IRepository<User>
    {
        private readonly MovieRentContext movieRentContext;
        public UserRepository(MovieRentContext movieRentContext)
        {
            this.movieRentContext = movieRentContext;
        }
        public void Create(User item)
        {
            movieRentContext.User.Add(item);
            movieRentContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = movieRentContext.User.Find(id);
            if (item != null)
            {
                movieRentContext.User.Remove(item);
            }
            else
            {
                throw new Exception("Такой пользователь не найден");
            }
            movieRentContext.SaveChanges();
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return movieRentContext.User.Where(predicate).ToList();
        }

        public IEnumerable<User> Get()
        {
            return movieRentContext.User.ToList();
        }
    }
}
