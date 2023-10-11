using Proyecto.AutoCareManager.DOMAIN.Core.DTO;
using Proyecto.AutoCareManager.DOMAIN.Core.Entities;

namespace Proyecto.AutoCareManager.DOMAIN.Core.Interfaces
{
    public interface IArticuloRepository
    {
        Task<IEnumerable<TbArticulo>> GetAll();
        Task<TbArticulo> GetById(int id);
        Task<bool> Insert(TbArticulo articulo);
        Task<bool> Update(ArticuloActualizarDTO articuloActualizarDTO);
        Task<bool> Delete(int id);

    }
}