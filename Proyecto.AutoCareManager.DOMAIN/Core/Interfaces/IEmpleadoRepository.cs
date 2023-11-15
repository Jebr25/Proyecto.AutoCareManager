using Proyecto.AutoCareManager.DOMAIN.Core.DTO;
using Proyecto.AutoCareManager.DOMAIN.Core.Entities;

namespace Proyecto.AutoCareManager.DOMAIN.Core.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<TbEmpleado>> GetAll();
        Task<IEnumerable<EmpleadoDTO>> GetAllDTO();
        Task<TbEmpleado> GetById(int id);
        Task<EmpleadoDTO> GetByIdDTO(int id);
        Task<bool> Insert(TbEmpleado empleado);
        Task<bool> InsertDTO(EmpleadoDTO empleadoDTO);
        Task<bool> UpdateByIdDTO(int id, EmpleadoActualizarDTO empleadoActualizarDTO);
        Task<bool> DeleteById(int id);

    }
}