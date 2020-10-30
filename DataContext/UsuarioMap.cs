using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCotizacionApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendCotizacionApp.DataContext
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios", "dbo");
            builder.HasKey(u => u.idUsuario);
            builder.Property(u => u.idUsuario).IsRequired().UseIdentityColumn();
            builder.Property(u => u.nombreUsuario).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(u => u.password).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(u => u.informacion).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
        }
    }
}
