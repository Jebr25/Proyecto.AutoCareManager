using Proyecto.AutoCareManager.DOMAIN.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto.AutoCareManager.DOMAIN.Core.Interfaces
{
    public interface IFacturaVentaService
    {
        Task<IEnumerable<ConsultaFacturaVentaDTO>> GetAllFacturas();
        Task<ConsultaFacturaVentaDTO> GetFacturaById(int id);
        Task<bool> CreateFactura(CrearFacturaVentaDTO facturaVentaDTO);
        Task<bool> UpdateFactura(int id, ActualizarFacturaVentaDTO facturaVentaDTO);
        Task<bool> DeleteFactura(int id);
    }
}
