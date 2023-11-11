using Microsoft.AspNetCore.Mvc;
using Proyecto.AutoCareManager.DOMAIN.Core.DTO;
using Proyecto.AutoCareManager.DOMAIN.Core.Interfaces;
using System.Threading.Tasks;

namespace Proyecto.AutoCareManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculoController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        [HttpGet("Listar vehiculos")]
        public async Task<IActionResult> GetAll()
        {
            var vehiculos = await _vehiculoService.GetAllVehiculos();
            return Ok(vehiculos);
        }

        [HttpPost("Registrar vehiculo")]
        public async Task<IActionResult> Create([FromBody] CrearVehiculoDTO vehiculoDTO)
        {
            var result = await _vehiculoService.CreateVehiculo(vehiculoDTO);
            if (!result)
            {
                return BadRequest("No se pudo registrar el vehículo");
            }
            return Ok("Vehículo registrado con éxito");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehiculo = await _vehiculoService.GetVehiculoById(id);
            if (vehiculo == null)
            {
                return NotFound("Vehículo no encontrado");
            }
            return Ok(vehiculo);
        }

        [HttpPut("Actualizar vehiculo/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActualizarVehiculoDTO vehiculoDTO)
        {
            if (id != vehiculoDTO.CodVehiculo)
            {
                return BadRequest("El ID del vehículo no coincide");
            }

            var result = await _vehiculoService.UpdateVehiculo(vehiculoDTO);
            if (!result)
            {
                return BadRequest("No se pudo actualizar el vehículo");
            }
            return Ok("Vehículo actualizado con éxito");
        }

        [HttpDelete("Eliminar vehiculo/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _vehiculoService.DeleteVehiculo(id);
            if (!result)
            {
                return BadRequest("No se pudo eliminar el vehículo");
            }
            return Ok("Vehículo eliminado con éxito");
        }
    }
}
