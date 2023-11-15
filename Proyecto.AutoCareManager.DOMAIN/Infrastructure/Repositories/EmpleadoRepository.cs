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
    public class EmpleadoRepository : IEmpleadoRepository
    {
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
        public async Task<bool> InsertDTO(EmpleadoDTO empleadoDTO)
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

        //------------------------Update By Id() CON DTO-----------------------
        public async Task<bool> UpdateByIdDTO(int id, EmpleadoActualizarDTO empleadoActualizarDTO)
        {
            //var existingEmpleado = await _dbContext.TbEmpleado.FindAsync(empleadoActualizarDTO.CodEmpleado);
            var existingEmpleado = await _dbContext.TbEmpleado.FirstOrDefaultAsync(u => u.CodEmpleado == id);

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

        public async Task<bool> DeleteById(int id)
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

