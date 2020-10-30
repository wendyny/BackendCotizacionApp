using BackendCotizacionApp.DataContext;
using BackendCotizacionApp.DomainServices;
using BackendCotizacionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCotizacionApp.AppServices
{
       public class UsuarioAppService
    {
        private readonly CotizacionAppDbContext _baseDatos;
        private readonly UsuarioDomainService _usuarioDomainService;

        public UsuarioAppService(CotizacionAppDbContext _context, UsuarioDomainService usuarioDomainService)
        {
            _baseDatos = _context;
            _usuarioDomainService = usuarioDomainService;
        }
        public async Task<string> PostUsuarioApplicationService(Usuario usuario)
        {
            var respuestaDomainService = _usuarioDomainService.PostUsuarioDomainService(usuario);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Usuarios.Add(usuario);
            await _baseDatos.SaveChangesAsync();

            return null;

        }

    }
}
