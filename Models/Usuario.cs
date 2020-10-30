using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCotizacionApp.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string password { get; set; }
        public string informacion { get; set; }
        public List<Producto> Productos { get; set; }
        public List<Cotizacion> Cotizaciones { get; set; }


    }
}
