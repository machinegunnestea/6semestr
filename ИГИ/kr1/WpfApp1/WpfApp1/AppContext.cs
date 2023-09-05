using Microsoft.EntityFrameworkCore;

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
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
    }
}
