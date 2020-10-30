using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCotizacionApp.Models
{
    public class DetalleCotizacion
    {
        public int idDetalle { get; set; }
        public int idProducto { get; set; }
        public int cantidadProducto { get; set; }
        public Producto Producto { get; set; }
    }
}
