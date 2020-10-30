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
    public class CotizacionesController : ControllerBase
    {
        private readonly CotizacionAppDbContext _context;
        private readonly CotizacionAppService _cotizacionAppService;

        public CotizacionesController(CotizacionAppDbContext context, CotizacionAppService cotizacionAppService)
        {
            _context = context;
            _cotizacionAppService = cotizacionAppService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cotizacion>>> GetCotizaciones()
        {
            return await _context.Cotizaciones.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Cotizacion>> GetCotizacion(int id)
        {
            var cotizacion = await _context.Cotizaciones.FindAsync(id);

            if (cotizacion == null)
            {
                return NotFound();
            }

            return cotizacion;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCotizacion(int id, Cotizacion cotizacion)
        {
            if (id != cotizacion.idCotizacion)
            {
                return BadRequest();
            }

            _context.Entry(cotizacion).State = EntityState.Modified;


            await _context.SaveChangesAsync();


            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Cotizacion>> PostCotizacion(Cotizacion cotizacion)
        {
            _context.Cotizaciones.Add(cotizacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCotizacion", new { id = cotizacion.idCotizacion }, cotizacion);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Cotizacion>> DeleteCotizacion(int id)
        {
            var cotizacion = await _context.Cotizaciones.FindAsync(id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            _context.Cotizaciones.Remove(cotizacion);
            await _context.SaveChangesAsync();

            return cotizacion;
        }

        private bool CotizacionExists(int id)
        {
            return _context.Cotizaciones.Any(e => e.idCotizacion == id);
        }
    }
}

