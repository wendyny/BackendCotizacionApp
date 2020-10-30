using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCotizacionApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendCotizacionApp.DataContext
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes", "dbo");
            builder.HasKey(c => c.idCliente);
            builder.Property(c => c.idCliente).IsRequired().UseIdentityColumn();
            builder.Property(c => c.nombreCliente).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(c => c.email).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(c => c.telefono).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();

        }
    }
}
