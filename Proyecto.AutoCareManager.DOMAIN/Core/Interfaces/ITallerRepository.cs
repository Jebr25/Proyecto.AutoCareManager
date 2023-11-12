using Proyecto.AutoCareManager.DOMAIN.Core.Entities;

namespace Proyecto.AutoCareManager.DOMAIN.Core.Interfaces
{
    internal interface ITallerRepository
    {
        Task<bool> Delete(int CodTaller);
        Task<TbTaller> GetTaller(int CodTaller);
        Task<IEnumerable<TbTaller>> GetTalleres();
        Task<bool> Insert(TbTaller taller);
        Task<bool> Update(TbTaller taller);
    }
}