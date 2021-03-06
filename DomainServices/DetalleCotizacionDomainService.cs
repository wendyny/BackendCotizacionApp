﻿using BackendCotizacionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCotizacionApp.DomainServices
{
    public class DetalleCotizacionDomainService
    {
        public string GetDetalleCotizacionDomainService(int id, DetalleCotizacion detalleCotizacion)
        {
            if (detalleCotizacion == null)
            {
                return "El detalle de cotizacion no existe";
            }
            return null;
        }
        public string PostDetalleCotizacionDomainService(DetalleCotizacion detalleCotizacion)
        {
           
            if (detalleCotizacion.cantidadProducto == 0)
            {
                return "Por favor ingrese la cantidad del producto deseado";
            }

            return null;
        }
    }
}
