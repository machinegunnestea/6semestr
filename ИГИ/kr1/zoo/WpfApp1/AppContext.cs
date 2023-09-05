using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Entities;

namespace WpfApp1
{
    public class AppContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public AppContext() : base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Cats;Trusted_Connection=True;");
        }
    }
}
