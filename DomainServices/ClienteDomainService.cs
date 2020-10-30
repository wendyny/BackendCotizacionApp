using BackendCotizacionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCotizacionApp.DomainServices
{
    public class ClienteDomainService
    {
       
        public string GetClienteDomainService(int id, Cliente cliente)
        {
            if (cliente == null)
            {
                return "El cliente no existe";
            }
            return null;
        }
        public string PostClienteDomainService(Cliente cliente)
        {
            if (cliente.nombreCliente == "")
            {
                return "Por favor ingrese un nombre";
            }

            if (cliente.email =="")
            {
                return "Por favor ingrese un correo valido";
            }
            if (cliente.telefono == "")
            {
                return "Por favor ingrese un telefono";
            }

            return null;
        }
    }
}
