using DL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DL.Context
{
    public class AutoRentContext:DbContext
    {
        public DbSet<Car> Car { get; set; }
        public DbSet<CarType> CarType { get; set; }
        public DbSet<User> User { get; set; }
        public AutoRentContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
