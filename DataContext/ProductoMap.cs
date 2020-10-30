using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCotizacionApp.Models;
using Microsoft.EntityFrameworkCore;
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
            builder.Property(p => p.urlFotoProducto).HasColumnType("nvarchar(Max)").IsRequired();
            builder.Property(p => p.descripcionProducto).HasColumnType("nvarchar(Max)").IsRequired();
            builder.Property(p => p.precio).HasColumnType("double").IsRequired();
            builder.Property(p => p.tipo).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            
            builder.HasOne(u =>u.Usuario)
                .WithMany(u => u.Productos)
                .HasForeignKey(u => u.idUsuario);

            builder.HasOne(c => c.Categoria)
                .WithMany(c => c.ProductosPorCategoria)
                .HasForeignKey(c => c.idCategoria);
        }
    }
}
