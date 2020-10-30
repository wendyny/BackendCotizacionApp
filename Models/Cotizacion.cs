using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace BackendCotizacionApp.Models
{
    public class Cotizacion
    {
        [Key]
        public int idCotizacion { get; set; }
        public int idCliente { get; set; }
        public int idUsuario { get; set; }
        public int oferta { get; set; }
        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }

    }
}
