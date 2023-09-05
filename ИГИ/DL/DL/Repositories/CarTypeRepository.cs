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
    internal class CarTypeRepository : IRepository<CarType>
    {
        private readonly AutoRentContext autoRentContext;
        public CarTypeRepository(AutoRentContext autoRentContext)
        {
            this.autoRentContext = autoRentContext;
        }
        public void Create(CarType item)
        {
            autoRentContext.CarType.Add(item);
            autoRentContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = autoRentContext.CarType.Find(id);
            if (item != null)
            {
                autoRentContext.CarType.Remove(item);
            }
            else
            {
                throw new Exception("Такой тип не найден");
            }
            autoRentContext.SaveChanges();
        }

        public IEnumerable<CarType> Find(Func<CarType, bool> predicate)
        {
            return autoRentContext.CarType.Where(predicate).ToList();
        }

        public IEnumerable<CarType> Get()
        {
            return autoRentContext.CarType.ToList();
        }
    }
}
