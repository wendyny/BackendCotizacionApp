using BackendCotizacionApp.DataContext;
using BackendCotizacionApp.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BackendCotizacionApp.Models;

namespace BackendCotizacionApp.AppServices
{
    public class CategoriaAppService
    {
        private readonly CotizacionAppDbContext _baseDatos;
        private readonly CategoriaDomainService _categoriaDomainService;

        public CategoriaAppService(CotizacionAppDbContext _context, CategoriaDomainService categoriaDomainService)
        {
            _baseDatos = _context;
            _categoriaDomainService = categoriaDomainService;
        }
        public async Task<string> PostCategoriaApplicationService(Categoria categoria)
        {
           var respuestaDomainService = _categoriaDomainService.PostCategoriaDomainService(categoria);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Categorias.Add(categoria);
            await _baseDatos.SaveChangesAsync();

            return null;

        }
        public async Task<string> GetCategoriaApplicationService(int id)
        {
            var categoria = await _baseDatos.Categorias.FirstOrDefaultAsync(c => c.idCategoria == id);
            var respuestaDomainService = _categoriaDomainService.PostCategoriaDomainService(categoria);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }
            return null;
        }
    }
}
