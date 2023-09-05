using DL.Context;
using DL.Entities;
using DL.Interfaces;
using DL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.UnitOfWork
{
    internal class AutoRentDbUnitOfWork : IUnitOfWork
    {
        private readonly AutoRentContext autoRentContext;
        private CarRepository? carRepository;
        private CarTypeRepository? carTypeRepository;
        private UserRepository? userRepository;
        public AutoRentDbUnitOfWork(string connection)
        {
            autoRentContext = new AutoRentContext(new DbContextOptionsBuilder()
                .UseSqlServer(connection)
                .Options);
        }
        public IRepository<Car> Car
        {
            get
            {
                if (carRepository == null)
                {
                    carRepository = new CarRepository(autoRentContext);
                }
                return carRepository;
            }
        }


        public IRepository<CarType> CarType
        {
            get
            {
                if (carTypeRepository == null)
                {
                    carTypeRepository = new CarTypeRepository(autoRentContext);
                }
                return carTypeRepository;
            }
        }

        public IRepository<User> User
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(autoRentContext);
                }
                return userRepository;
            }
        }

        public void Save()
        {
            autoRentContext.SaveChanges();
        }
    }
}
