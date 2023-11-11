using Proyecto.AutoCareManager.DOMAIN.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto.AutoCareManager.DOMAIN.Core.Interfaces
{
    public interface IFacturaVentaRepository
    {
        // Suponiendo que tus métodos trabajen con la cabecera y detalles de la factura
        Task<IEnumerable<TbFactVentaCab>> GetAllFacturas();
        Task<TbFactVentaCab> GetFacturaById(int id);
        Task<bool> InsertFactura(TbFactVentaCab facturaVentaCab);
        Task<bool> UpdateFactura(TbFactVentaCab facturaVentaCab);
        Task<bool> DeleteFactura(int id);

        // Métodos para trabajar con detalles de la factura, si los necesitas
        Task<IEnumerable<TbFactVentaDet>> GetAllDetalles();
        Task<TbFactVentaDet> GetDetalleById(int docId, int numLinea);
        Task<bool> InsertDetalle(TbFactVentaDet facturaVentaDetalle);
        Task<bool> UpdateDetalle(TbFactVentaDet facturaVentaDetalle);
        Task<bool> DeleteDetalle(int docId, int numLinea);
    }
}
