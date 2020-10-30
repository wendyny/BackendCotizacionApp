using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCotizacionApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BackendCotizacionApp.DataContext
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias", "dbo");
            builder.HasKey(c => c.idCategoria);
            builder.Property(c => c.idCategoria).IsRequired().UseIdentityColumn();
            builder.Property(c => c.nombreCategoria).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
        }
    }
}
