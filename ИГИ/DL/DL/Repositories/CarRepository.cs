using DL.Context;
using DL.Entities;
using DL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Repositories
{
    internal class CarRepository : IRepository<Car>
    {
        private readonly AutoRentContext autoRentContext;
        public CarRepository(AutoRentContext autoRentContext)
        {
            this.autoRentContext = autoRentContext;
        }
        public void Create(Car item)
        {
            autoRentContext.Car.Add(item);
            autoRentContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = autoRentContext.Car.Find(id);
            if (item != null)
            {
                autoRentContext.Car.Remove(item);
            }
            else
            {
                throw new Exception("Такая машина не найдена");
            }
            autoRentContext.SaveChanges();
        }

        public IEnumerable<Car> Find(Func<Car, bool> predicate)
        {
            return autoRentContext.Car.Where(predicate).ToList();
        }

        public IEnumerable<Car> Get()
        {
            return autoRentContext.Car.ToList();
        }
    }
}
