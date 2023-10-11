using Proyecto.AutoCareManager.DOMAIN.Core.DTO;
using Proyecto.AutoCareManager.DOMAIN.Core.Entities;
using Proyecto.AutoCareManager.DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.AutoCareManager.DOMAIN.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        //private readonly IJWTFactory _jwtFactory;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> SignUp(UsuarioRegistroDTO usuarioDTO)
        {
            var existsUser = await _usuarioRepository.IsEmailRegistered(usuarioDTO.Email);

            if (existsUser == true)
            {
                return false;
            }

            var usuario = new TbUsuario()
            {
                Email = usuarioDTO.Email,
                Password = usuarioDTO.Password,
                FirmaUsuario = usuarioDTO.FirmaUsuario,
                Nombres = usuarioDTO.Nombres,
                Apellidos = usuarioDTO.Apellidos,
                TipoUsuario = usuarioDTO.TipoUsuario,
            };

            var result = await _usuarioRepository.SignUp(usuario);

            return result;
        }

        public async Task<UsuarioRespuestaDTO> SignIn(UsuarioAuthDTO usuarioAuthDTO)
        {
            var usuario = await _usuarioRepository.SignIn(usuarioAuthDTO.Email, usuarioAuthDTO.Password);

            if (usuario == null) return null;

            var usuarioDTO = new UsuarioRespuestaDTO()
            {
                UserCode = usuario.UserCode,
                Email = usuario.Email,
                FirmaUsuario = usuario.FirmaUsuario,
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                TipoUsuario = usuario.TipoUsuario == "E" ? "Empleado" :
                              usuario.TipoUsuario == "A" ? "Administrador" :
                              usuario.TipoUsuario == "C" ? "Cliente" : "Desconocido"
        };

            return usuarioDTO;

        }

    }
}
