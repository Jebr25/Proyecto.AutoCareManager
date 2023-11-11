
// FacturaVentaService.cs
using Proyecto.AutoCareManager.DOMAIN.Core.Entities;
using Proyecto.AutoCareManager.DOMAIN.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto.AutoCareManager.DOMAIN.Infrastructure.Data;

namespace Proyecto.AutoCareManager.DOMAIN.Infrastructure.Repositories
{
    public class FacturaVentaRepository : IFacturaVentaRepository
    {
        private readonly AutocaremanagerContext _context;

        public FacturaVentaRepository(AutocaremanagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TbFactVentaCab>> GetAllFacturas()
        {
            return await _context.TbFactVentaCab.ToListAsync();
        }

        public async Task<TbFactVentaCab> GetFacturaById(int id)
        {
            return await _context.TbFactVentaCab.FindAsync(id);
        }

        public async Task<bool> InsertFactura(TbFactVentaCab facturaVentaCab)
        {
            _context.TbFactVentaCab.Add(facturaVentaCab);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateFactura(TbFactVentaCab facturaVentaCab)
        {
            _context.TbFactVentaCab.Update(facturaVentaCab);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteFactura(int id)
        {
            var facturaVentaCab = await _context.TbFactVentaCab.FindAsync(id);
            if (facturaVentaCab == null)
            {
                return false;
            }
            _context.TbFactVentaCab.Remove(facturaVentaCab);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Métodos para trabajar con los detalles de la factura
        public async Task<IEnumerable<TbFactVentaDet>> GetAllDetalles()
        {
            return await _context.TbFactVentaDet.ToListAsync();
        }

        public async Task<TbFactVentaDet> GetDetalleById(int docId, int numLinea)
        {
            return await _context.TbFactVentaDet
                .FirstOrDefaultAsync(det => det.DocId == docId && det.NumLinea == numLinea);
        }

        public async Task<bool> InsertDetalle(TbFactVentaDet facturaVentaDetalle)
        {
            _context.TbFactVentaDet.Add(facturaVentaDetalle);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateDetalle(TbFactVentaDet facturaVentaDetalle)
        {
            _context.TbFactVentaDet.Update(facturaVentaDetalle);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteDetalle(int docId, int numLinea)
        {
            var detalle = await _context.TbFactVentaDet
                .FirstOrDefaultAsync(det => det.DocId == docId && det.NumLinea == numLinea);
            if (detalle == null)
            {
                return false;
            }
            _context.TbFactVentaDet.Remove(detalle);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
