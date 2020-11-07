using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCotizacionApp.DataContext;
using BackendCotizacionApp.DomainServices;
using BackendCotizacionApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendCotizacionApp.AppServices
{
    public class CotizacionAppService
    {
        private readonly CotizacionAppDbContext _baseDatos;
        private readonly CotizacionDomainService _cotizacionDomainService;

        public CotizacionAppService(CotizacionAppDbContext _context, CotizacionDomainService cotizacionDomainService)
        {
            _baseDatos = _context;
            _cotizacionDomainService = cotizacionDomainService;
        }
        public async Task<string> PostCotizacionApplicationService(Cotizacion cotizacion)
        {
            var respuestaDomainService = _cotizacionDomainService.PostCotizacionDomainService(cotizacion);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Cotizaciones.Add(cotizacion);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> GetCotizacionApplicationService(int id)
        {
            var cotizacion = await _baseDatos.Cotizaciones.FirstOrDefaultAsync(c => c.idCotizacion == id);
            var respuestaDomainService = _cotizacionDomainService.PostCotizacionDomainService(cotizacion);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            return null;
        }
    }
}
