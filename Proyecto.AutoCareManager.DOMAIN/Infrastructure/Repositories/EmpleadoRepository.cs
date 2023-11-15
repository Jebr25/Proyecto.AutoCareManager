using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
<<<<<<< HEAD
using Proyecto.AutoCareManager.DOMAIN.Core.DTO;
=======
>>>>>>> 8229652052ff8ae0b330b3b9f6efdeb93f60b8d0
=======
>>>>>>> 8229652052ff8ae0b330b3b9f6efdeb93f60b8d0
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
    public class EmpleadoRepository : IEmpleadoRepository
    {
<<<<<<< HEAD
<<<<<<< HEAD
        private readonly AutocaremanagerContext _dbContext;

        public EmpleadoRepository(AutocaremanagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        //------------------------Get All() SIN DTO-----------------------
        public async Task<IEnumerable<TbEmpleado>> GetAll()
        {
            return await _dbContext.TbEmpleado.ToListAsync();
        }

        //------------------------Get All() CON DTO-----------------------
        public async Task<IEnumerable<EmpleadoDTO>> GetAllDTO()
        {
            var empleados = await _dbContext.TbEmpleado.ToListAsync();

            var empleadosDTO = empleados.Select(e => new EmpleadoDTO
            {
                CodEmpleado = e.CodEmpleado,
                Nombres = e.Nombres,
                Apellidos = e.Apellidos,
                NumIdent = e.NumIdent,
                Cargo = e.Cargo,
                Estado = e.Estado,
                CodTaller = e.CodTaller,
                UserCode = e.UserCode
            }).ToList();

            return empleadosDTO;
        }

        //------------------------Get By Id() SIN DTO-----------------------
        public async Task<TbEmpleado> GetById(int id)
        {
            return await _dbContext.TbEmpleado.Where(x => x.CodEmpleado == id).FirstOrDefaultAsync();
        }

        //------------------------Get By Id() CON DTO-----------------------
        public async Task<EmpleadoDTO> GetByIdDTO(int id)
        {
            var empleado = await _dbContext.TbEmpleado
                .Where(x => x.CodEmpleado == id)
                .FirstOrDefaultAsync();

            // Verificar si el empleado existe
            if (empleado == null)
            {
                return null;
            }

            var empleadoDTO = new EmpleadoDTO
            {
                CodEmpleado = empleado.CodEmpleado,
                Nombres = empleado.Nombres,
                Apellidos = empleado.Apellidos,
                NumIdent = empleado.NumIdent,
                Cargo = empleado.Cargo,
                Estado = empleado.Estado,
                CodTaller = empleado.CodTaller,
                UserCode = empleado.UserCode
            };

            return empleadoDTO;
        }

        //------------------------Insert() SIN DTO-----------------------
        public async Task<bool> Insert(TbEmpleado empleado)
        {
            await _dbContext.TbEmpleado.AddAsync(empleado);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        //------------------------Insert() CON DTO-----------------------
        public async Task<bool> Insert(EmpleadoDTO empleadoDTO)
        {
            var empleado = new TbEmpleado
            {
                Nombres = empleadoDTO.Nombres,
                Apellidos = empleadoDTO.Apellidos,
                NumIdent = empleadoDTO.NumIdent,
                Cargo = empleadoDTO.Cargo,
                Estado = empleadoDTO.Estado,
                CodTaller = empleadoDTO.CodTaller,
                UserCode = empleadoDTO.UserCode
            };

            await _dbContext.TbEmpleado.AddAsync(empleado);

            var rows = await _dbContext.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> Update(EmpleadoActualizarDTO empleadoActualizarDTO)
        {
            var existingEmpleado = await _dbContext.TbEmpleado.FindAsync(empleadoActualizarDTO.CodEmpleado);

            if (existingEmpleado == null)
            {
                return false;
            }

            // Verifica si las propiedades están presentes en el JSON.
            if (empleadoActualizarDTO.Nombres != null)
            {
                existingEmpleado.Nombres = empleadoActualizarDTO.Nombres;
            }

            if (empleadoActualizarDTO.Apellidos != null)
            {
                existingEmpleado.Apellidos = empleadoActualizarDTO.Apellidos;
            }

            if (empleadoActualizarDTO.NumIdent != null)
            {
                existingEmpleado.NumIdent = empleadoActualizarDTO.NumIdent;
            }

            if (empleadoActualizarDTO.Cargo != null)
            {
                existingEmpleado.Cargo = empleadoActualizarDTO.Cargo;
            }

            if (empleadoActualizarDTO.Estado != null)
            {
                existingEmpleado.Estado = empleadoActualizarDTO.Estado;
            }

            if (empleadoActualizarDTO.CodTaller != null)
            {
                existingEmpleado.CodTaller = empleadoActualizarDTO.CodTaller;
            }

            if (empleadoActualizarDTO.UserCode != null)
            {
                existingEmpleado.UserCode = empleadoActualizarDTO.UserCode;
            }

            var rows = await _dbContext.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var empleado = await _dbContext.TbEmpleado.Where(x => x.CodEmpleado == id).FirstOrDefaultAsync();

            if (empleado == null)
                return false;

            _dbContext.TbEmpleado.Remove(empleado);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

    }
}
=======
=======
>>>>>>> 8229652052ff8ae0b330b3b9f6efdeb93f60b8d0
        private readonly AutocaremanagerContext _context;

        public EmpleadoRepository(AutocaremanagerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TbEmpleado>> GetEmpleados()
        {
            var users = await _context.TbEmpleado.ToListAsync();
            return users;

        }

        public async Task<TbEmpleado> GetEmpleados(int CodEmpleado)
        {
            //return _context.User.Find(id);

            return await _context.TbEmpleado.Where(x => x.CodEmpleado == CodEmpleado).FirstOrDefaultAsync();

        }

        public async Task<bool> Insert(TbEmpleado empleado)
        {
            await _context.TbEmpleado.AddAsync(empleado);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(TbEmpleado empleado)
        {
            _context.TbEmpleado.Update(empleado);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int CodEmpleado)
        {
            var user = await _context.TbEmpleado.FindAsync(CodEmpleado);
            return (user != null);
        }



    }


}

<<<<<<< HEAD
>>>>>>> 8229652052ff8ae0b330b3b9f6efdeb93f60b8d0
=======
>>>>>>> 8229652052ff8ae0b330b3b9f6efdeb93f60b8d0
