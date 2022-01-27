using Entidades.Entity;
using Microsoft.EntityFrameworkCore;
using Persistencia.Config;

namespace Persistencia
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Geolocalizar> Geolocalizar { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new GeolocalizarConfig());
        }
    }
}
