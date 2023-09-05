using Movies.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Base
{
    public interface IUnitOfWork
    {
        public IRepository<Movie> Movies { get; }
        public IRepository<Producer> Producers { get; }
        public IRepository<Screenwriter> Screenwriters { get; }
        void Save();
    }
}
