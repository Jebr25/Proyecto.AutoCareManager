using Proyecto.AutoCareManager.DOMAIN.Core.DTO;

namespace Proyecto.AutoCareManager.DOMAIN.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> SignUp(UsuarioRegistroDTO usuarioDTO);
        Task<UsuarioRespuestaDTO> SignIn(UsuarioAuthDTO usuarioAuthDTO);
    }
}