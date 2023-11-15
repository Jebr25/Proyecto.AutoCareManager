using Microsoft.EntityFrameworkCore;
using Proyecto.AutoCareManager.DOMAIN.Core.DTO;
using Proyecto.AutoCareManager.DOMAIN.Core.Entities;
using Proyecto.AutoCareManager.DOMAIN.Core.Interfaces;
using Proyecto.AutoCareManager.DOMAIN.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.AutoCareManager.DOMAIN.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AutocaremanagerContext _dbContext;

        public UsuarioRepository(AutocaremanagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        //------------------------Get All() SIN DTO-----------------------
        public async Task<IEnumerable<TbUsuario>> GetAll()
        {
            return await _dbContext.TbUsuario.ToListAsync();
        }

        //------------------------Get All() CON DTO-----------------------
        public async Task<IEnumerable<UsuarioDTO>> GetAllDTO()
        {
            var usuarios = await _dbContext.TbUsuario.ToListAsync();

            var usuariosDTO = usuarios.Select(e => new UsuarioDTO
            {
                UserCode = e.UserCode,
                Email = e.Email,
                Password = e.Password,
                FirmaUsuario = e.FirmaUsuario,
                Nombres = e.Nombres,
                Apellidos = e.Apellidos,
                TipoUsuario = e.TipoUsuario,
            }).ToList();

            return usuariosDTO;
        }

        public async Task<TbUsuario> SignIn(string email, string password)
        {
            return await _dbContext.TbUsuario.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
        }

        public async Task<bool> SignUp(TbUsuario usuario)
        {
            await _dbContext.TbUsuario.AddAsync(usuario);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> IsEmailRegistered(string email)
        {
            return await _dbContext.TbUsuario.Where(x => x.Email == email).AnyAsync();
        }

        //------------------------Update By Id() SIN DTO-----------------------
        public async Task<bool> UpdateById(TbUsuario usuario)
        {
            var existingUsuario = await _dbContext.TbUsuario.FindAsync(usuario.UserCode);

            if (existingUsuario == null)
            {
                return false;
            }

            // Verifica si las propiedades están presentes en el JSON.
            if (usuario.Email != null)
            {
                existingUsuario.Email = usuario.Email;
            }

            if (usuario.Password != null)
            {
                existingUsuario.Password = usuario.Password;
            }

            if (usuario.FirmaUsuario != null)
            {
                existingUsuario.FirmaUsuario = usuario.FirmaUsuario;
            }

            if (usuario.Nombres != null)
            {
                existingUsuario.Nombres = usuario.Nombres;
            }

            if (usuario.Apellidos != null)
            {
                existingUsuario.Apellidos = usuario.Apellidos;
            }

            if (usuario.TipoUsuario != null)
            {
                existingUsuario.TipoUsuario = usuario.TipoUsuario;
            }

            var rows = await _dbContext.SaveChangesAsync();

            return rows > 0;
        }

        //------------------------Update By Id() CON DTO-----------------------
        public async Task<bool> UpdateByIdDTO(int id, UsuarioActualizarDTO usuarioActualizarDTO)
        {
            //var existingUsuario = await _dbContext.TbUsuario.FindAsync(usuarioActualizarDTO.UserCode);
            var existingUsuario = await _dbContext.TbUsuario.FirstOrDefaultAsync(u => u.UserCode == id);

            if (existingUsuario == null)
            {
                return false;
            }

            // Actualizar las propiedades desde el DTO solo si están presentes
            if (usuarioActualizarDTO.Email != null)
            {
                existingUsuario.Email = usuarioActualizarDTO.Email;
            }

            if (usuarioActualizarDTO.Password != null)
            {
                existingUsuario.Password = usuarioActualizarDTO.Password;
            }

            if (usuarioActualizarDTO.FirmaUsuario != null)
            {
                existingUsuario.FirmaUsuario = usuarioActualizarDTO.FirmaUsuario;
            }

            if (usuarioActualizarDTO.Nombres != null)
            {
                existingUsuario.Nombres = usuarioActualizarDTO.Nombres;
            }

            if (usuarioActualizarDTO.Apellidos != null)
            {
                existingUsuario.Apellidos = usuarioActualizarDTO.Apellidos;
            }

            if (usuarioActualizarDTO.TipoUsuario != null)
            {
                existingUsuario.TipoUsuario = usuarioActualizarDTO.TipoUsuario;
            }

            var rows = await _dbContext.SaveChangesAsync();

            return rows > 0;
        }

        //------------------------Update By Email() SIN DTO-----------------------
        public async Task<bool> UpdateByEmail(string email, TbUsuario usuario)
        {
            var existingUsuario = await _dbContext.TbUsuario.FirstOrDefaultAsync(u => u.Email == email);

            if (existingUsuario == null)
            {
                return false;
            }

            // Verifica si las propiedades están presentes en el JSON.
            if (usuario.Password != null)
            {
                existingUsuario.Password = usuario.Password;
            }

            if (usuario.FirmaUsuario != null)
            {
                existingUsuario.FirmaUsuario = usuario.FirmaUsuario;
            }

            if (usuario.Nombres != null)
            {
                existingUsuario.Nombres = usuario.Nombres;
            }

            if (usuario.Apellidos != null)
            {
                existingUsuario.Apellidos = usuario.Apellidos;
            }

            if (usuario.TipoUsuario != null)
            {
                existingUsuario.TipoUsuario = usuario.TipoUsuario;
            }

            var rows = await _dbContext.SaveChangesAsync();

            return rows > 0;
        }

        //------------------------Update By Email() CON DTO-----------------------
        public async Task<bool> UpdateByEmailDTO(string email, UsuarioActualizarDTO usuarioActualizarDTO)
        {
            var existingUsuario = await _dbContext.TbUsuario.FirstOrDefaultAsync(u => u.Email == email);

            if (existingUsuario == null)
            {
                return false;
            }

            // Actualizar las propiedades desde el DTO solo si están presentes
            if (usuarioActualizarDTO.Password != null)
            {
                existingUsuario.Password = usuarioActualizarDTO.Password;
            }

            if (usuarioActualizarDTO.FirmaUsuario != null)
            {
                existingUsuario.FirmaUsuario = usuarioActualizarDTO.FirmaUsuario;
            }

            if (usuarioActualizarDTO.Nombres != null)
            {
                existingUsuario.Nombres = usuarioActualizarDTO.Nombres;
            }

            if (usuarioActualizarDTO.Apellidos != null)
            {
                existingUsuario.Apellidos = usuarioActualizarDTO.Apellidos;
            }

            if (usuarioActualizarDTO.TipoUsuario != null)
            {
                existingUsuario.TipoUsuario = usuarioActualizarDTO.TipoUsuario;
            }

            var rows = await _dbContext.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> DeleteById(int id)
        {
            var usuario = await _dbContext.TbUsuario.Where(x => x.UserCode == id).FirstOrDefaultAsync();

            if (usuario == null)
                return false;

            _dbContext.TbUsuario.Remove(usuario);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteByEmail(string email)
        {
            var usuario = await _dbContext.TbUsuario.Where(x => x.Email == email).FirstOrDefaultAsync();

            if (usuario == null)
                return false;

            _dbContext.TbUsuario.Remove(usuario);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
