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
    public class ClientesController : ControllerBase
    {
        private readonly CotizacionAppDbContext _context;
        private readonly ClienteAppService _clienteAppService;

        public ClientesController(CotizacionAppDbContext context, ClienteAppService clienteAppService)
        {
            _context = context;
            _clienteAppService = clienteAppService;

        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.Include(c => c.Cotizaciones).ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.Include(c => c.Cotizaciones).FirstOrDefaultAsync(c => c.idCliente == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.idCliente)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

           
                await _context.SaveChangesAsync();
            

            return NoContent();
        }

       
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {

            var respuestaClienteAppService = await _clienteAppService.PostClienteApplicationService(cliente);
            bool noHayErrorEnValidaciones = respuestaClienteAppService == null;
            if (noHayErrorEnValidaciones)
            {
                return CreatedAtAction(nameof(GetCliente), new { id = cliente.idCliente }, cliente);
            }

            return BadRequest(respuestaClienteAppService);   
            
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.idCliente == id);
        }
    }
}
