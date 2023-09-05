using def.ModelsForEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace def.Configuration
{
    public class FightCommandConfiguration : IEntityTypeConfiguration<FightCommand>
    {
        public void Configure(EntityTypeBuilder<FightCommand> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date);
            builder.Property(x => x.CommandOne);
            builder.Property(x => x.CommandTwo);
        }
    }
}
