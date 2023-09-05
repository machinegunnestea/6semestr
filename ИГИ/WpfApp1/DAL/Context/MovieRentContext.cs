using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class MovieRentContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieType> MovieType { get; set; }
        public DbSet<User> User { get; set; }
        public MovieRentContext(DbContextOptions options) : base(options)
        {

        }
    }
}
