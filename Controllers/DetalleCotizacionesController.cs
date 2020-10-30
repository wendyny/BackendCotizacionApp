using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendCotizacionApp.DataContext;
using BackendCotizacionApp.Models;

namespace BackendCotizacionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCotizacionesController : ControllerBase
    {
        private readonly CotizacionAppDbContext _context;

        public DetalleCotizacionesController(CotizacionAppDbContext context)
        {
            _context = context;
        }

        // GET: api/DetalleCotizaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleCotizacion>>> GetDetallesCotizacion()
        {
            return await _context.DetallesCotizacion.ToListAsync();
        }

        // GET: api/DetalleCotizaciones/5
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

        // PUT: api/DetalleCotizaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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

        // POST: api/DetalleCotizaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DetalleCotizacion>> PostDetalleCotizacion(DetalleCotizacion detalleCotizacion)
        {
            _context.DetallesCotizacion.Add(detalleCotizacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleCotizacion", new { id = detalleCotizacion.idDetalle }, detalleCotizacion);
        }

        // DELETE: api/DetalleCotizaciones/5
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
