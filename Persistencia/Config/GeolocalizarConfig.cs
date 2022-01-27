using Entidades.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistencia.Config
{
    public class GeolocalizarConfig : IEntityTypeConfiguration<Geolocalizar>
    {
       

        public void Configure(EntityTypeBuilder<Geolocalizar> builder)
        {
            builder.ToTable("geolocalizar")
                .HasIndex(x => x.Id);
            builder.Property(x => x.Calle)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Numero)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(x => x.Pais)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Provincia)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Codigo_Postal)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.Ciudad)
                .IsRequired()
                .HasMaxLength(50);
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
