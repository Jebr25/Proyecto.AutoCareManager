// IVehiculoRepository.cs
using Proyecto.AutoCareManager.DOMAIN.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto.AutoCareManager.DOMAIN.Core.Interfaces
{
    public interface IVehiculoRepository
    {
        Task<IEnumerable<TbVehiculo>> GetAllVehiculosAsync();
        Task<TbVehiculo> GetVehiculoByIdAsync(int codVehiculo);
        Task<bool> CreateVehiculoAsync(TbVehiculo vehiculo);
        Task<bool> UpdateVehiculoAsync(TbVehiculo vehiculo);
        Task<bool> DeleteVehiculoAsync(int codVehiculo);
    }
}
