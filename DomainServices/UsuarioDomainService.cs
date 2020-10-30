using BackendCotizacionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCotizacionApp.DomainServices
{
    public class UsuarioDomainService
    {

        public string GetUsuarioDomainService(int id, Usuario usuario)
        {
            if (usuario == null)
            {
                return "El usuario no existe";
            }
            return null;
        }
        public string PostUsuarioDomainService(Usuario usuario)
        {
            if (usuario.nombreUsuario == "")
            {
                return "Por favor ingrese un nombre de usuario";
            }

            if (usuario.password == "")
            {
                return "Por favor ingrese una contrase;a";
            }
            if (usuario.informacion == "")
            {
                return "Por favor ingrese su informacion";
            }

            return null;
        }
    }
}
