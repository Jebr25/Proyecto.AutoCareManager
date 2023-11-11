// VehiculoRepository.cs
using Proyecto.AutoCareManager.DOMAIN.Core.Entities;
using Proyecto.AutoCareManager.DOMAIN.Core.Interfaces;
using Proyecto.AutoCareManager.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.AutoCareManager.DOMAIN.Infrastructure.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly AutocaremanagerContext _context;

        public VehiculoRepository(AutocaremanagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TbVehiculo>> GetAllVehiculosAsync()
        {
            return await _context.TbVehiculo.ToListAsync();
        }

        public async Task<TbVehiculo> GetVehiculoByIdAsync(int codVehiculo)
        {
            return await _context.TbVehiculo
                .FirstOrDefaultAsync(v => v.CodVehiculo == codVehiculo);
        }

        public async Task<bool> CreateVehiculoAsync(TbVehiculo vehiculo)
        {
            _context.TbVehiculo.Add(vehiculo);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateVehiculoAsync(TbVehiculo vehiculo)
        {
            _context.TbVehiculo.Update(vehiculo);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteVehiculoAsync(int codVehiculo)
        {
            var vehiculo = await _context.TbVehiculo
                .FindAsync(codVehiculo);
            if (vehiculo == null) return false;

            _context.TbVehiculo.Remove(vehiculo);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
