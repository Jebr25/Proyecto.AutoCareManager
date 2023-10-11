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

        public async Task<IEnumerable<TbUsuario>> GetAll()
        {
            return await _dbContext.TbUsuario.ToListAsync();
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
