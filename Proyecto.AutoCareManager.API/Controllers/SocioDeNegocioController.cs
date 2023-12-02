using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.AutoCareManager.DOMAIN.Core.Entities;
using Proyecto.AutoCareManager.DOMAIN.Core.Interfaces;

namespace Proyecto.AutoCareManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioDeNegocioController : ControllerBase
    {
        private readonly ISocioDeNegocioRepository _socioDeNegocioRepository;

        public SocioDeNegocioController(ISocioDeNegocioRepository socioDeNegocioRepository)
        {
            _socioDeNegocioRepository = socioDeNegocioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var socioNegocio = await _socioDeNegocioRepository.GetTbSocioDeNegocio();
            return Ok(socioNegocio);
        }

        [HttpGet("{NumIdentificacion}")]

        public async Task<IActionResult> GetTbSocioDeNegocio(int NumIdentificacion)
        {
            var identificacion = await _socioDeNegocioRepository.GetSocioDeNegocio(NumIdentificacion);
            return Ok(identificacion);
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] TbSocioDeNegocio identificacion)
        {
            var result = await _socioDeNegocioRepository.Insert(identificacion);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int Identificacion, [FromBody] TbSocioDeNegocio socioDeNegocio)
        {
            if (Identificacion != socioDeNegocio.NumIdent)
                return BadRequest();
            var result = await _socioDeNegocioRepository.Update(socioDeNegocio);
            return Ok(result); 
        }
        [HttpDelete("{NumIdentificacion}")]

        public async Task<IActionResult> Delete(int Identificacion )
        {
            var result = await _socioDeNegocioRepository.Delete(Identificacion);
            return Ok(result);
        }



    }
}
