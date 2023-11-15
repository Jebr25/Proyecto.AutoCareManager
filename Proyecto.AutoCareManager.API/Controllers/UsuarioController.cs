using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.AutoCareManager.DOMAIN.Core.DTO;
using Proyecto.AutoCareManager.DOMAIN.Core.Entities;
using Proyecto.AutoCareManager.DOMAIN.Core.Interfaces;
using Proyecto.AutoCareManager.DOMAIN.Infrastructure.Repositories;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Proyecto.AutoCareManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioService usuarioService, IUsuarioRepository usuarioRepository)
        {
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository; 
        }

        //[HttpGet("Listar usuarios")]
        //public async Task<IActionResult> GetAll()
        //{
        //    var categories = await _usuarioRepository.GetAll();
        //    return Ok(categories);
        //}

        [HttpGet("Listar usuarios")]
        public async Task<IActionResult> GetAllDTO()
        {
            try
            {
                var usuariosDTO = await _usuarioRepository.GetAllDTO();
                return Ok(usuariosDTO);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost("Sign Up")]
        public async Task<IActionResult> SignUp([FromBody] UsuarioRegistroDTO usuarioRegistroDTO)
        {
            var result = await _usuarioService.SignUp(usuarioRegistroDTO);
            if (result != true)
            {
                return BadRequest("El Usuario ya esta registrado en la base de datos");
            }
            else
            {
                return Ok(result);
            }            
        }

        [HttpPost("Sign In")]
        public async Task<IActionResult> SignIn([FromBody] UsuarioAuthDTO usuarioAuthDTO)
        {
            var result = await _usuarioService.SignIn(usuarioAuthDTO);

            if (result == null)
            {
                return BadRequest("Credenciales incorrectas, no tienes acceso");
            }
            else
            {
                return Ok(result);
            }
        }

        //[HttpPut("Actualizar usuario por id/{id}")]
        //public async Task<IActionResult> UpdateById(int id, [FromBody] TbUsuario usuario)
        //{
        //    var result = await _usuarioRepository.UpdateById(new TbUsuario
        //    {
        //        UserCode = id,
        //        Email = usuario.Email,
        //        Password = usuario.Password,
        //        FirmaUsuario = usuario.FirmaUsuario,
        //        Nombres = usuario.Nombres,
        //        Apellidos = usuario.Apellidos, 
        //        TipoUsuario = usuario.TipoUsuario
        //    });

        //    if (!result)
        //    {
        //        return BadRequest("El usuario no existe o no tiene cambios que actualizar en los registros");
        //    }

        //    return Ok(result);
        //}

        //[HttpPut("Actualizar usuario por id/{id}")]
        //public async Task<IActionResult> UpdateByIdDTO(int id, [FromBody] UsuarioActualizarDTO usuarioActualizarDTO)
        //{
        //    var result = await _usuarioRepository.UpdateByIdDTO(new UsuarioActualizarDTO
        //    {
        //        UserCode = id,
        //        Email = usuarioActualizarDTO.Email,
        //        Password = usuarioActualizarDTO.Password,
        //        FirmaUsuario = usuarioActualizarDTO.FirmaUsuario,
        //        Nombres = usuarioActualizarDTO.Nombres,
        //        Apellidos = usuarioActualizarDTO.Apellidos,
        //        TipoUsuario = usuarioActualizarDTO.TipoUsuario
        //    });

        //    if (!result)
        //    {
        //        return BadRequest("El usuario no existe o no tiene cambios que actualizar en los registros");
        //    }

        //    return Ok(result);
        //}

        [HttpPut("Actualizar usuario por id/{id}")]
        public async Task<IActionResult> UpdateByIdDTO(int id, [FromBody] UsuarioActualizarDTO usuarioActualizarDTO)
        {
            try
            {
                var result = await _usuarioRepository.UpdateByIdDTO(id, usuarioActualizarDTO);

                if (!result)
                {
                    return BadRequest("El usuario no existe o no tiene cambios que actualizar en los registros");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Error interno del servidor");
            }
        }

        //[HttpPut("Actualizar usuario por email/{email}")]
        //public async Task<IActionResult> UpdateByEmail(string email, [FromBody] TbUsuario usuario)
        //{
        //    var result = await _usuarioRepository.UpdateByEmail(email, usuario);

        //    if (!result)
        //    {
        //        return BadRequest("El usuario no existe o no tiene cambios que actualizar en los registros");
        //    }

        //    return Ok(result);
        //}

        [HttpPut("Actualizar usuario por email/{email}")]
        public async Task<IActionResult> UpdateByEmailDTO(string email, [FromBody] UsuarioActualizarDTO usuarioActualizarDTO)
        {
            try
            {
                var result = await _usuarioRepository.UpdateByEmailDTO(email, usuarioActualizarDTO);

                if (!result)
                {
                    return BadRequest("El usuario no existe o no tiene cambios que actualizar en los registros");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("Eliminar usuario por id/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _usuarioRepository.DeleteById(id);
            if (!result)
                return BadRequest("No se pudo emilinar el usuario por ID");

            return Ok(result);
        }

        [HttpDelete("Eliminar usuario por email/{email}")]
        public async Task<IActionResult> DeleteByEmail(string email)
        {
            var result = await _usuarioRepository.DeleteByEmail(email);
            if (!result)
                return BadRequest("No se pudo emilinar el usuario por correo electrónico");

            return Ok(result);
        }
    }
}
