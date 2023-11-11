using Microsoft.AspNetCore.Mvc;
using Proyecto.AutoCareManager.DOMAIN.Core.DTO;
using Proyecto.AutoCareManager.DOMAIN.Core.Interfaces;
using System.Threading.Tasks;

namespace Proyecto.AutoCareManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaVentaController : ControllerBase
    {
        private readonly IFacturaVentaService _facturaVentaService;
        private readonly IFacturaVentaRepository _facturaVentaRepository;

        public FacturaVentaController(IFacturaVentaService facturaVentaService, IFacturaVentaRepository facturaVentaRepository)
        {
            _facturaVentaService = facturaVentaService;
            _facturaVentaRepository = facturaVentaRepository;
        }

        [HttpGet("Listar facturas")]
        public async Task<IActionResult> GetAllFacturas()
        {
            var facturas = await _facturaVentaRepository.GetAllFacturas();
            return Ok(facturas);
        }

        [HttpPost("Registrar factura")]
        public async Task<IActionResult> Register([FromBody] CrearFacturaVentaDTO facturaVentaDTO)
        {
            var result = await _facturaVentaService.CreateFactura(facturaVentaDTO); // Asegúrate de que el método se llame 'CreateFactura' en IFacturaVentaService
            if (!result)
            {
                return BadRequest("No se pudo registrar la factura de venta");
            }
            return Ok(result);
        }

        [HttpPut("Actualizar factura/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActualizarFacturaVentaDTO facturaVentaDTO)
        {
            var result = await _facturaVentaService.UpdateFactura(id, facturaVentaDTO); // Asegúrate de que el método se llame 'UpdateFactura' en IFacturaVentaService
            if (!result)
            {
                return BadRequest("No se pudo actualizar la factura de venta");
            }
            return Ok(result);
        }

        [HttpDelete("Eliminar factura/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _facturaVentaRepository.DeleteFactura(id); // Cambia a 'DeleteFactura' para que coincida con IFacturaVentaRepository
            if (!result)
            {
                return BadRequest("No se pudo eliminar la factura de venta");
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var factura = await _facturaVentaRepository.GetFacturaById(id); // Cambia a 'GetFacturaById' para que coincida con IFacturaVentaRepository
            if (factura == null)
            {
                return NotFound("Factura de venta no encontrada");
            }
            return Ok(factura);
        }
    }
}
