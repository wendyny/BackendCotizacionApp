using BackendCotizacionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCotizacionApp.DomainServices
{
    public class CategoriaDomainService
    {
        public string GetCategoriaDomainService(int id, Categoria categoria)
        {
            if (categoria == null)
            {
                return "La categoria no existe";
            }
            return null;
        }
        public string PostCategoriaDomainService(Categoria categoria)
        {
            if (categoria.nombreCategoria == "")
            {
                return "Por favor ingrese una categoria: Producto o Servicio";
            }

            
            return null;
        }
    }
}
