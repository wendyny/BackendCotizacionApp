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
    public class CategoriasController : ControllerBase
    {
        private readonly CotizacionAppDbContext _context;
        private readonly CategoriaAppService _categoriaAppService;

        public CategoriasController(CotizacionAppDbContext context, CategoriaAppService categoriaAppService)
        {
            _context = context;
            _categoriaAppService = categoriaAppService;
        }

         
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias.Include(p=>p.ProductosPorCategoria).ToListAsync();
        }

         
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categorias.Include(p => p.ProductosPorCategoria).FirstOrDefaultAsync(c=>c.idCategoria==id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.idCategoria)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;
             await _context.SaveChangesAsync();
           
           
            return NoContent();
        }

         
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            var respuestaCategoriaAppService = await _categoriaAppService.PostCategoriaApplicationService(categoria);

            bool noHayErroresEnLasValidaciones = respuestaCategoriaAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return CreatedAtAction(nameof(GetCategoria), new { id = categoria.idCategoria }, categoria);
            }
            return BadRequest(respuestaCategoriaAppService);

        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> DeleteCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.idCategoria == id);
        }
    }
}
