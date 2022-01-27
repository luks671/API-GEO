using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rabbit.Persistencia.Entity;

namespace Rabbit.Persistencia.Config
{
    public class GeolocalizarConfig : IEntityTypeConfiguration<Geolocalizar>
    {
        public void Configure(EntityTypeBuilder<Geolocalizar> builder)
        {
            builder.ToTable("geolocalizar")
                .HasIndex(x => x.Id);
            builder.Property(x => x.Latitud)
                .HasMaxLength(100);
            builder.Property(x => x.Longitud)
                .HasMaxLength(100);
            builder.Property(x => x.Estado)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
