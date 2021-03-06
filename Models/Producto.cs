﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BackendCotizacionApp.Models
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        public string urlFotoProducto { get; set; }
        public string descripcionProducto { get; set; }
        public double precio { get; set; }
        public int tipo { get; set; }
        public int idUsuario { get; set; }
        public int idCategoria { get; set; }
        public Usuario Usuario { get; set; }
        public Categoria Categoria { get; set; }
        public List<DetalleCotizacion> detalleCotizaciones { get; set; }

    }
}
