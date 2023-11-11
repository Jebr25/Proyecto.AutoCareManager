// IVehiculoService.cs
using Proyecto.AutoCareManager.DOMAIN.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto.AutoCareManager.DOMAIN.Core.Interfaces
{
    public interface IVehiculoService
    {
        Task<IEnumerable<ConsultaVehiculoDTO>> GetAllVehiculos();
        Task<ConsultaVehiculoDTO> GetVehiculoById(int codVehiculo);
        Task<bool> CreateVehiculo(CrearVehiculoDTO vehiculoDTO);
        Task<bool> UpdateVehiculo(ActualizarVehiculoDTO vehiculoDTO);
        Task<bool> DeleteVehiculo(int codVehiculo);
    }
}
