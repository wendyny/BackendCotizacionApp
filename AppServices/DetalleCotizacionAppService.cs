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
    public class DetalleCotizacionAppService
    {
        private readonly CotizacionAppDbContext _baseDatos;
        private readonly DetalleCotizacionDomainService _detalleCotizacionDomainService;

        public DetalleCotizacionAppService(CotizacionAppDbContext _context, DetalleCotizacionDomainService detalleCotizacionDomainService)
        {
            _baseDatos = _context;
            _detalleCotizacionDomainService = detalleCotizacionDomainService;
        }
        public async Task<string> PostDetalleCotizacionApplicationService(DetalleCotizacion detalleCotizacion )
        {
            
            var respuestaDomainService = _detalleCotizacionDomainService.PostDetalleCotizacionDomainService(detalleCotizacion);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.DetallesCotizacion.Add(detalleCotizacion);
            await _baseDatos.SaveChangesAsync();

            return null;

        }
        public async Task<string> GetDetalleCotizacionApplicationService(int id)
        {
            var detalle= await _baseDatos.DetallesCotizacion.FirstOrDefaultAsync(d => d.idDetalle == id);
            var respuestaDomainService = _detalleCotizacionDomainService.GetDetalleCotizacionDomainService(id, detalle);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            return null;
        }
    }
}
