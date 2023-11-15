using Proyecto.AutoCareManager.DOMAIN.Core.DTO;
using Proyecto.AutoCareManager.DOMAIN.Core.Entities;

namespace Proyecto.AutoCareManager.DOMAIN.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<TbUsuario>> GetAll();
        Task<IEnumerable<UsuarioDTO>> GetAllDTO();
        Task<bool> IsEmailRegistered(string email);
        Task<TbUsuario> SignIn(string email, string password);
        Task<bool> SignUp(TbUsuario usuario);
        Task<bool> UpdateById(TbUsuario usuario);

        //Task<bool> UpdateByIdDTO(UsuarioActualizarDTO usuarioActualizarDTO);
        Task<bool> UpdateByIdDTO(int id, UsuarioActualizarDTO usuarioActualizarDTO);
        Task<bool> UpdateByEmail(string email, TbUsuario usuario);
        Task<bool> UpdateByEmailDTO(string email, UsuarioActualizarDTO usuarioActualizarDTO);
        Task<bool> DeleteById(int id);
        Task<bool> DeleteByEmail(string email);
    }
}