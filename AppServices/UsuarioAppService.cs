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
       public class UsuarioAppService
    {
        private readonly CotizacionAppDbContext _baseDatos;
        private readonly UsuarioDomainService _usuarioDomainService;

        public UsuarioAppService(CotizacionAppDbContext _context, UsuarioDomainService usuarioDomainService)
        {
            _baseDatos = _context;
            _usuarioDomainService = usuarioDomainService;
        }
        public async Task<string> GetUsuarioApplicationService(int id)
        {
            var usuario = await _baseDatos.Usuarios.FirstOrDefaultAsync(c => c.idUsuario == id);
            var respuestaDomainService = _usuarioDomainService.GetUsuarioDomainService(id,usuario);

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
