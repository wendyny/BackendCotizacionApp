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
    public class UsuariosController : ControllerBase
    {
        private readonly CotizacionAppDbContext _context;
        private readonly UsuarioAppService _usuarioAppService;

        public UsuariosController(CotizacionAppDbContext context, UsuarioAppService usuarioAppService)
        {
            _context = context;
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.Include(p => p.Productos).Include(c=>c.Cotizaciones).ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.Include(p => p.Productos).Include(c => c.Cotizaciones).FirstOrDefaultAsync(u => u.idUsuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.idUsuario)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;


            await _context.SaveChangesAsync();
                  return NoContent();
        }

        
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            var respuestaUsuarioAppService = await _usuarioAppService.PostUsuarioApplicationService(usuario);
            bool noHayErrorEnValidaciones = respuestaUsuarioAppService == null;
            if (noHayErrorEnValidaciones)
            {
                return CreatedAtAction("GetUsuario", new { id = usuario.idUsuario }, usuario);
            }

            return BadRequest(respuestaUsuarioAppService);    
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.idUsuario == id);
        }
    }
}
