using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Movie> Movie { get; }
        public IRepository<MovieType> MovieType { get; }
        public IRepository<User> User { get; }
        void Save();
    }
}
