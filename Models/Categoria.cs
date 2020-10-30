using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCotizacionApp.Models
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        public string nombreCategoria { get; set; }
        public List<Producto> ProductosPorCategoria { get; set; }

    }
}
