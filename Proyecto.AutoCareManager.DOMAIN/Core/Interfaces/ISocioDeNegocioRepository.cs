using Proyecto.AutoCareManager.DOMAIN.Core.Entities;

namespace Proyecto.AutoCareManager.DOMAIN.Core.Interfaces
{
    public interface ISocioDeNegocioRepository
    {
        Task<bool> Delete(int CodSN);
        Task<TbSocioDeNegocio> GetSocioDeNegocio(int CodSN);
        Task<IEnumerable<TbSocioDeNegocio>> GetTbSocioDeNegocio();
        Task<bool> Insert(TbSocioDeNegocio socioNegocio);
        Task<bool> Update(TbSocioDeNegocio socioNegocio);
    }
}