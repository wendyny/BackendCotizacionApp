using BackendCotizacionApp.Models;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCotizacionApp.DomainServices
{
    public class ProductoDomainService
    {
        public string GetProductoDomainService(int id, Producto producto)
        {
            if (producto == null)
            {
                return "El producto no existe";
            }
            return null;
        }
        public string PostProductoDomainService(Producto producto)
        {
            if (producto.urlFotoProducto == "")
            {
                return "Por favor ingrese el URL de la foto del producto/ u o servicio";
            }
            if (producto.descripcionProducto == "")
            {
                return "Por favor ingrese una descripcion del producto/u o servicio";
            }
            if (producto.precio == 0)
            {
                return "Por favor ingrese valor > a 0";
            }
            if (producto.tipo == 0)
            {
                return "Por favor ingrese un tipo de categoria valido";
            }
            if (producto.idUsuario == 0)
            {
                return "Por favor ingrese un id de usuario valido";
            }
            if (producto.idCategoria!=producto.tipo)
            {
                return "Por favor ingrese un id de categoria valido";
            }

           
            return null;
        }
    }
}
