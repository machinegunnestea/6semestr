using def.Configuration;
using def.ModelsForEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace def
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
            {

            }

        public ApplicationContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(ConnectionString.ConnectString())
                    .LogTo(s => System.Diagnostics.Debug.WriteLine(s), LogLevel.Trace);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            if (Database.IsRelational())
            {
                modelBuilder.ApplyConfiguration(new BetConfiguration());
                modelBuilder.ApplyConfiguration(new FightCommandConfiguration());

            }
        }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<FightCommand> FightCommands { get; set; }

    }
}
