using BackendCotizacionApp.DataContext;
using BackendCotizacionApp.DomainServices;
using BackendCotizacionApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCotizacionApp.AppServices
{
    public class ProductoAppService
    {
        private readonly CotizacionAppDbContext _baseDatos;
        private readonly ProductoDomainService _productoDomainService;

        public ProductoAppService(CotizacionAppDbContext _context, ProductoDomainService productoDomainService)
        {
            _baseDatos = _context;
            _productoDomainService = productoDomainService;
        }
        public async Task<string> PostProductoApplicationService(Producto producto)
        {
            var respuestaDomainService = _productoDomainService.PostProductoDomainService(producto);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Productos.Add(producto);
            await _baseDatos.SaveChangesAsync();

            return null;

        }
        public async Task<string> GetProductoApplicationService(int id)
        {
            var producto = await _baseDatos.Productos.FirstOrDefaultAsync(p => p.idProducto == id);
            var respuestaDomainService = _productoDomainService.GetProductoDomainService(id, producto);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            return null;
        }
    }
}
