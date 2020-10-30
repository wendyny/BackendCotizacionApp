using BackendCotizacionApp.DataContext;
using BackendCotizacionApp.DomainServices;
using BackendCotizacionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCotizacionApp.AppServices
{
    public class ClienteAppService
    {
        private readonly CotizacionAppDbContext _baseDatos;
        private readonly ClienteDomainService _clienteDomainService;

        public ClienteAppService(CotizacionAppDbContext _context, ClienteDomainService clienteDomainService)
        {
            _baseDatos = _context;
            _clienteDomainService = clienteDomainService;
        }
        public async Task<string> PostClienteApplicationService(Cliente cliente)
        {

            var respuestaDomainService = _clienteDomainService.PostClienteDomainService(cliente);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Clientes.Add(cliente);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
    }
}
