using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCotizacionApp.Models;

namespace BackendCotizacionApp.DomainServices
{
    public class CotizacionDomainService
    {
        public string GetCotizacionDomainService(int id, Cotizacion cotizacion)
        {
            if (cotizacion == null)
            {
                return "No existe la cotizacion ";
            }
            return null;
        }
        public string PostCotizacionDomainService(Cotizacion cotizacion)
        {

            if (cotizacion.Usuario.idUsuario == 0)
            {
                return "El id del usuario es invalido";
            }
            if (cotizacion.Cliente.idCliente==0)
            {
                return "El id del cliente es invalido";
            }

            return null;
        }
    }
}
