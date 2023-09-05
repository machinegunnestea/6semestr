using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Car> Car { get; }
        public IRepository<CarType> CarType { get; }
        public IRepository<User> User { get; }
        void Save();
    }
}
