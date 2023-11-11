using Proyecto.AutoCareManager.DOMAIN.Core.Entities;

namespace Proyecto.AutoCareManager.DOMAIN.Core.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<bool> Delete(int CodEmpleado);
        Task<IEnumerable<TbEmpleado>> GetEmpleados();
        Task<TbEmpleado> GetEmpleados(int CodEmpleado);
        Task<bool> Insert(TbEmpleado empleado);
        Task<bool> Update(TbEmpleado empleado);
    }
}