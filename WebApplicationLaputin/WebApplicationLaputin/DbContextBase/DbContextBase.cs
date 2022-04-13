using Microsoft.EntityFrameworkCore;
using WebApplicationLaputin.Configurations;
using WebApplicationLaputin.Models;

namespace WebApplicationLaputin.DbContextBases
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(DbContextOptions<DbContextBase> options) : base(options)
        {
        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Valve> Valves { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UnitConfiguration());
            builder.ApplyConfiguration(new ValveConfiguration());
            builder.ApplyConfiguration(new SensorConfiguration());
            builder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}
