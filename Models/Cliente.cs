using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace BackendCotizacionApp.Models
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        public string nombreCliente { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public List<Cotizacion> Cotizaciones { get; set; }
    }
}
