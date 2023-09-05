using def.ModelsForEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace def.Configuration
{
    public class BetConfiguration: IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Command);
            builder.Property(x => x.Pay);
            builder.Property(x => x.Name);
        }
    }
}
