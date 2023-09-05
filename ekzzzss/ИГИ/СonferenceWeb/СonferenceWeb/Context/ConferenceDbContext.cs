using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using СonferenceWeb.Entities;

namespace СonferenceWeb.Context
{
    public class ConferenceDbContext : DbContext
    {
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Talk> Talks { get; set; }
        public DbSet<Members> Members { get; set; }
        public ConferenceDbContext(DbContextOptions<ConferenceDbContext> options)
            : base(options)
        {

        }
    }
}
