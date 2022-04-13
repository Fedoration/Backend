using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationLaputin.Models;

namespace WebApplicationLaputin.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.Property(m => m.Login)
                .HasMaxLength(50)
                .HasDefaultValue("Unknown")
                .IsRequired();

            builder.Property(m => m.Password)
                .HasMaxLength(255);

            builder.Property(m => m.Role)
                .HasMaxLength(255);

        }
    }
}
