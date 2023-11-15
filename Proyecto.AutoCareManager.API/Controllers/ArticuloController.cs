using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Proyecto.AutoCareManager.DOMAIN.Core.DTO;
using Proyecto.AutoCareManager.DOMAIN.Core.Entities;
using Proyecto.AutoCareManager.DOMAIN.Core.Interfaces;

namespace Proyecto.AutoCareManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloRepository _articuloRepository;

        public ArticuloController(IArticuloRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }
        [HttpGet("Listar articulos")]
        public async Task<IActionResult> GetAll()
        {
            var articulos = await _articuloRepository.GetAll();
            return Ok(articulos);
        }

        [HttpGet("Obtener articulo por id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var articulos = await _articuloRepository.GetById(id);
            return Ok(articulos);
        }

        [HttpPost("Registrar articulo")]
        public async Task<IActionResult> Create(TbArticulo articulo)
        {
            var result = await _articuloRepository.Insert(articulo);
            if (!result)
                return BadRequest("No es posible registrar el artículo.");
            else
                return Ok(result);
        }

        [HttpPut("Actualizar articulo por id/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ArticuloActualizarDTO articuloActualizarDTO)
        {
            var result = await _articuloRepository.Update(new ArticuloActualizarDTO
            {
                CodArticulo = id,
                DesArticulo = articuloActualizarDTO.DesArticulo,
                ArtInventariable = articuloActualizarDTO.ArtInventariable,
                TipoServicio = articuloActualizarDTO.TipoServicio,
                UnidadMedida = articuloActualizarDTO.UnidadMedida,
                Fabricante = articuloActualizarDTO.Fabricante,
                ImpVenta = articuloActualizarDTO.ImpVenta,
                Estado = articuloActualizarDTO.Estado
            });

            if (!result)
            {
                return BadRequest("El artículo no existe o no tiene cambios que actualizar en los registros");
            }

            return Ok(result);
        }


        [HttpDelete("Eliminar articulo por id/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _articuloRepository.Delete(id);
            if (!result)
                return BadRequest("No es posible eliminar el articulo");
            else
                return Ok(result);
        }

        /*
        [HttpPut("Actualizar articulo por id/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TbArticulo articulo)
        {
            var result = await _articuloRepository.Update(id, articulo);

            if (!result)
            {
                return BadRequest("No es posible actualizar el artículo. Puede que el artículo no exista");
            }

            return Ok(result);
        }
        /*

        /*
        [HttpPut("Actualizar articulo por id/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ArticuloDTO articuloDTO)
        {
            var existingArticulo = await _articuloRepository.GetById(id);

            if (existingArticulo == null)
            {
                return BadRequest();
            }

            if (!string.IsNullOrEmpty(articuloDTO.DesArticulo))
            {
                existingArticulo.DesArticulo = articuloDTO.DesArticulo;
            }
            if (!string.IsNullOrEmpty(articuloDTO.ArtInventariable))
            {
                existingArticulo.ArtInventariable = articuloDTO.ArtInventariable;
            }
            if (!string.IsNullOrEmpty(articuloDTO.TipoServicio))
            {
                existingArticulo.TipoServicio = articuloDTO.TipoServicio;
            }
            if (!string.IsNullOrEmpty(articuloDTO.UnidadMedida))
            {
                existingArticulo.UnidadMedida = articuloDTO.UnidadMedida;
            }
            if (!string.IsNullOrEmpty(articuloDTO.Fabricante))
            {
                existingArticulo.Fabricante = articuloDTO.Fabricante;
            }
            if (!string.IsNullOrEmpty(articuloDTO.ImpVenta))
            {
                existingArticulo.ImpVenta = articuloDTO.ImpVenta;
            }
            if (!string.IsNullOrEmpty(articuloDTO.Estado))
            {
                existingArticulo.Estado = articuloDTO.Estado;
            }

            var result = await _articuloRepository.Update(existingArticulo);

            if (!result)
            {
                return BadRequest("No es posible actualizar el artículo.");
            }

            return Ok(result);

        }
        */

        /*
        [HttpPut("Actualizar articulo por id/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ArticuloActualizarDTO articuloActualizarDTO)
        {
            var existingArticulo = await _articuloRepository.GetById(id);

            if (existingArticulo == null)
            {
                return BadRequest("No es posible actualizar el artículo. Puede que el artículo no exista");
            }

            // Verifica si las propiedades están presentes en el JSON.
            if (articuloActualizarDTO.DesArticulo != null)
            {
                existingArticulo.DesArticulo = articuloActualizarDTO.DesArticulo;
            }

            if (articuloActualizarDTO.ArtInventariable != null)
            {
                existingArticulo.ArtInventariable = articuloActualizarDTO.ArtInventariable;
            }

            if (articuloActualizarDTO.TipoServicio != null)
            {
                existingArticulo.TipoServicio = articuloActualizarDTO.TipoServicio;
            }

            if (articuloActualizarDTO.UnidadMedida != null)
            {
                existingArticulo.UnidadMedida = articuloActualizarDTO.UnidadMedida;
            }

            if (articuloActualizarDTO.Fabricante != null)
            {
                existingArticulo.Fabricante = articuloActualizarDTO.Fabricante;
            }

            if (articuloActualizarDTO.ImpVenta != null)
            {
                existingArticulo.ImpVenta = articuloActualizarDTO.ImpVenta;
            }

            if (articuloActualizarDTO.Estado != null)
            {
                existingArticulo.Estado = articuloActualizarDTO.Estado;
            }

            var result = await _articuloRepository.Update(existingArticulo);

            if (!result)
            {
                return BadRequest("No es posible actualizar el artículo.");
            }

            return Ok(result);
        }
        */

    }
}
