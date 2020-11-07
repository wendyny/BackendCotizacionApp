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
    public class ProductosController : ControllerBase
    {
        private readonly CotizacionAppDbContext _context;
        private readonly ProductoAppService _productoAppService;

        public ProductosController(CotizacionAppDbContext context, ProductoAppService productoAppService)
        {
            _context = context;
            _productoAppService = productoAppService;
        }

         
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.Include(p=>p.Usuario).Include(c=>c.Categoria).Include(d=>d.detalleCotizaciones).ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.Include(p => p.Usuario).Include(c => c.Categoria).Include(d => d.detalleCotizaciones).FirstOrDefaultAsync(p => p.idProducto==id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

         
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.idProducto)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            
                await _context.SaveChangesAsync();
           
            return NoContent();
        }

         
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {

            var respuestaProductoAppService = await _productoAppService.PostProductoApplicationService(producto);

            bool noHayErroresEnLasValidaciones = respuestaProductoAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return CreatedAtAction(nameof(GetProducto), new { id = producto.idProducto }, producto);
            }
            return BadRequest(respuestaProductoAppService);
     
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<Producto>> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return producto;
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.idProducto == id);
        }
    }
}
