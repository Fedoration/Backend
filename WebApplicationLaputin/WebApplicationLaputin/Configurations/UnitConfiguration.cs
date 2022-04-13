using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationLaputin.Models;

namespace WebApplicationLaputin.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.Property(m => m.Name)
                .HasMaxLength(50)
                .HasDefaultValue("Unknown")
                .IsRequired();
        }
    }
}
