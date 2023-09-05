using DL.Context;
using DL.Entities;
using DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Repositories
{
    internal class UserRepository : IRepository<User>
    {
        private readonly AutoRentContext autoRentContext;
        public UserRepository(AutoRentContext autoRentContext)
        {
            this.autoRentContext = autoRentContext;
        }
        public void Create(User item)
        {
            autoRentContext.User.Add(item);
            autoRentContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = autoRentContext.User.Find(id);
            if (item != null)
            {
                autoRentContext.User.Remove(item);
            }
            else
            {
                throw new Exception("Такой пользователь не найден");
            }
            autoRentContext.SaveChanges();
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return autoRentContext.User.Where(predicate).ToList();
        }

        public IEnumerable<User> Get()
        {
            return autoRentContext.User.ToList();
        }
    }
}
