using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationLaputin.Models;

namespace WebApplicationLaputin.Configurations
{
    public class SensorConfiguration : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.Property(m => m.Name)
                .HasMaxLength(50)
                .HasDefaultValue("Unknown")
                .IsRequired();

            builder.Property(m => m.Type)
                .HasMaxLength(50)
                .HasDefaultValue("Unknown")
                .IsRequired();

            builder.Property(m => m.Description)
                .HasMaxLength(255);

            builder.Property(m => m.Dimension)
                .HasMaxLength(255);

            builder.HasOne(m => m.Unit)
                .WithMany()
                .HasForeignKey(m => m.UnitId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
