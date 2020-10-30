using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCotizacionApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendCotizacionApp.DataContext
{
    public class DetalleCotizacionMap : IEntityTypeConfiguration<DetalleCotizacion>
    {
        public void Configure(EntityTypeBuilder<DetalleCotizacion> builder)
        {
            builder.ToTable("DetallesCotizacion", "dbo");
            builder.HasKey( d=> d.idDetalle);
            builder.Property(d => d.idDetalle).IsRequired().UseIdentityColumn();
            builder.Property(d => d.cantidadProducto).HasColumnType("int").IsRequired();
            builder.HasOne(c => c.Producto)
                .WithMany(c => c.detalleCotizaciones)
                .HasForeignKey(c => c.idProducto);


        }
    }
}
