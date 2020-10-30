using BackendCotizacionApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendCotizacionApp.DataContext
{
    public class ProductoMap : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos", "dbo");
            builder.HasKey(p => p.idProducto);
            builder.Property(p => p.idProducto).IsRequired().UseIdentityColumn();
           
            builder.HasOne(u => u.Usuario)
                .WithMany(u => u.Productos)
                .HasForeignKey(u => u.idUsuario);

            builder.HasOne(c => c.Categoria)
                .WithMany(c => c.ProductosPorCategoria)
                .HasForeignKey(c => c.idCategoria);
        }
    }
}
