using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendCotizacionApp.DataContext;
using BackendCotizacionApp.Models;
using BackendCotizacionApp.AppServices;

namespace BackendCotizacionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCotizacionesController : ControllerBase
    {
        private readonly CotizacionAppDbContext _context;
        private readonly DetalleCotizacionAppService _detalleCotizacionAppService;

        public DetalleCotizacionesController(CotizacionAppDbContext context, DetalleCotizacionAppService detalleCotizacionAppService)
        {
            _context = context;
            _detalleCotizacionAppService = detalleCotizacionAppService;
        }

         
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleCotizacion>>> GetDetallesCotizacion()
        {
            return await _context.DetallesCotizacion.ToListAsync();
        }

         
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleCotizacion>> GetDetalleCotizacion(int id)
        {
            var detalleCotizacion = await _context.DetallesCotizacion.FindAsync(id);

            if (detalleCotizacion == null)
            {
                return NotFound();
            }

            return detalleCotizacion;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleCotizacion(int id, DetalleCotizacion detalleCotizacion)
        {
            if (id != detalleCotizacion.idDetalle)
            {
                return BadRequest();
            }

            _context.Entry(detalleCotizacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleCotizacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpPost]
        public async Task<ActionResult<DetalleCotizacion>> PostDetalleCotizacion(DetalleCotizacion detalleCotizacion)
        {
            var respuestaDetalleAppService = await _detalleCotizacionAppService.PostDetalleCotizacionApplicationService(detalleCotizacion);

            bool noHayErroresEnLasValidaciones = respuestaDetalleAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return CreatedAtAction(nameof(GetDetalleCotizacion), new { id = detalleCotizacion.idDetalle }, detalleCotizacion);
            }
            return BadRequest(respuestaDetalleAppService);

        }

         
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalleCotizacion>> DeleteDetalleCotizacion(int id)
        {
            var detalleCotizacion = await _context.DetallesCotizacion.FindAsync(id);
            if (detalleCotizacion == null)
            {
                return NotFound();
            }

            _context.DetallesCotizacion.Remove(detalleCotizacion);
            await _context.SaveChangesAsync();

            return detalleCotizacion;
        }

        private bool DetalleCotizacionExists(int id)
        {
            return _context.DetallesCotizacion.Any(e => e.idDetalle == id);
        }
    }
}
