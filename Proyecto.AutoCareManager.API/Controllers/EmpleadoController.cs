using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.AutoCareManager.DOMAIN.Core.DTO;
using Proyecto.AutoCareManager.DOMAIN.Core.Entities;
using Proyecto.AutoCareManager.DOMAIN.Core.Interfaces;
using Proyecto.AutoCareManager.DOMAIN.Infrastructure.Repositories;

namespace Proyecto.AutoCareManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoController(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        //[HttpGet("listar empleados")]
        //public async Task<IActionResult> getall()
        //{
        //    var empleados = await _empleadoRepository.GetAll();
        //    return Ok(empleados);
        //}

        [HttpGet("Listar empleados")]
        public async Task<IActionResult> GetAllDTO()
        {
            try
            {
                var empleadosDTO = await _empleadoRepository.GetAllDTO();
                return Ok(empleadosDTO);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Error interno del servidor");
            }
        }

        //[HttpGet("Obtener empleado por id/{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var empleados = await _empleadoRepository.GetById(id);
        //    return Ok(empleados);
        //}

        [HttpGet("Obtener empleado por id/{id}")]
        public async Task<IActionResult> GetByIdDTO(int id)
        {
            try
            {
                var empleadoDTO = await _empleadoRepository.GetByIdDTO(id);

                // Verificar si el empleado existe
                if (empleadoDTO == null)
                {
                    return NotFound($"Empleado con ID {id} no encontrado");
                }

                return Ok(empleadoDTO);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Error interno del servidor");
            }
        }

        //[HttpPost("Registrar empleado")]
        //public async Task<IActionResult> Create(TbEmpleado empleado)
        //{
        //    var result = await _empleadoRepository.Insert(empleado);
        //    if (!result)
        //        return BadRequest("No es posible registrar el artículo.");
        //    else
        //        return Ok(result);
        //}

        [HttpPost("Registrar empleado")]
        public async Task<IActionResult> Create(EmpleadoDTO empleadoDTO)
        {
            try
            {
                var result = await _empleadoRepository.InsertDTO(empleadoDTO);

                if (result)
                    return Ok(result);
                else
                    return BadRequest("No es posible registrar el empleado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }

        //[HttpPut("Actualizar empleado por id/{id}")]
        //public async Task<IActionResult> UpdateByDTO(int id, [FromBody] EmpleadoActualizarDTO empleadoActualizarDTO)
        //{
        //    var result = await _empleadoRepository.UpdateByIdDTO(new EmpleadoActualizarDTO
        //    {
        //        CodEmpleado = id,
        //        Nombres = empleadoActualizarDTO.Nombres,
        //        Apellidos = empleadoActualizarDTO.Apellidos,
        //        NumIdent = empleadoActualizarDTO.NumIdent,
        //        Cargo = empleadoActualizarDTO.Cargo,
        //        Estado = empleadoActualizarDTO.Estado,
        //        CodTaller = empleadoActualizarDTO.CodTaller,
        //        UserCode = empleadoActualizarDTO.UserCode
        //    });

        //    if (!result)
        //    {
        //        return BadRequest("El empleado no existe o no tiene cambios que actualizar en los registros");
        //    }

        //    return Ok(result);
        //}

        [HttpPut("Actualizar empleado por id/{id}")]
        public async Task<IActionResult> UpdateByIdDTO(int id, [FromBody] EmpleadoActualizarDTO empleadoActualizarDTO)
        {
            try
            {
                var result = await _empleadoRepository.UpdateByIdDTO(id, empleadoActualizarDTO);

                if (!result)
                {
                    return BadRequest("El empleado no existe o no tiene cambios que actualizar en los registros");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("Eliminar empleado por id/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _empleadoRepository.DeleteById(id);
            if (!result)
                return BadRequest("No es posible eliminar el empleado");
            else
                return Ok(result);
        }

    }
}
