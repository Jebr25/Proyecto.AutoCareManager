using Proyecto.AutoCareManager.DOMAIN.Core.Entities;

namespace Proyecto.AutoCareManager.DOMAIN.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<TbUsuario>> GetAll();
        Task<bool> IsEmailRegistered(string email);
        Task<TbUsuario> SignIn(string email, string password);
        Task<bool> SignUp(TbUsuario usuario);
        Task<bool> UpdateById(TbUsuario usuario);
        Task<bool> UpdateByEmail(string email, TbUsuario usuario);
        Task<bool> DeleteById(int id);
        Task<bool> DeleteByEmail(string email);
    }
}