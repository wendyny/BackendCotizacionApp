using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCotizacionApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BackendCotizacionApp.DataContext
{
    public class CotizacionMap : IEntityTypeConfiguration<Cotizacion>
    {
        public void Configure(EntityTypeBuilder<Cotizacion> builder)
        {
            builder.ToTable("Cotizaciones", "dbo");
            builder.HasKey(c => c.idCotizacion);
            builder.Property(c => c.idCotizacion).IsRequired().UseIdentityColumn();
            builder.Property(c => c.oferta).HasColumnType("int");
            builder.HasOne(c => c.Cliente)
                .WithMany(c => c.Cotizaciones)
                .HasForeignKey(c => c.idCliente);
            builder.HasOne(u => u.Usuario)
                .WithMany(u => u.Cotizaciones)
                .HasForeignKey(u => u.idUsuario);
        }
    }
}
