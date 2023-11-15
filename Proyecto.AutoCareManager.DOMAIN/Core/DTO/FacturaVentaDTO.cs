using Proyecto.AutoCareManager.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.AutoCareManager.DOMAIN.Core.DTO
{
    public class FacturaVentaDetalleDTO
    {
        public int DocId { get; set; }

        public int NumLinea { get; set; }

        public int CodArticulo { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal Subtotal { get; set; }

        public virtual TbArticulo CodArticuloNavigation { get; set; } = null!;

        public virtual TbFactVentaCab Doc { get; set; } = null!;
    }


    public class FacturaVentaCabeceraDTO
    {
        public int DocID { get; set; }
        // Supongamos que tienes estas propiedades adicionales en tu tabla de cabecera
        public DateTime Fecha { get; set; }
        public int ClienteID { get; set; }
        public decimal TotalFactura { get; set; }
        public List<FacturaVentaDetalleDTO> Detalles { get; set; }
    }

    public class FacturaDetalleDTO
    {
        public int NumLinea { get; set; }
        public int CodArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }
    }

    public class CrearFacturaVentaDTO
    {
        public int CodSn { get; set; }
        public DateTime FecDocumento { get; set; }
        public DateTime FecVencimiento { get; set; }
        public DateTime ProxFecMant { get; set; }
        public string CondicionPago { get; set; }
        public string Moneda { get; set; }
        public string NumSerieFiscal { get; set; }
        public string NumCorrelativo { get; set; }
        public string Comentarios { get; set; }
        public decimal DocTotal { get; set; }
        public int CodEmpleado { get; set; }
        public int ActId { get; set; }

        public List<FacturaDetalleDTO> Detalles { get; set; }
    }


    public class ActualizarFacturaVentaDTO
    {
        public int DocID { get; set; } // Se necesita para identificar la factura a actualizar
        public DateTime Fecha { get; set; }
        public int ClienteID { get; set; }
        public List<FacturaVentaDetalleDTO> Detalles { get; set; }
    }

    public class ConsultaFacturaVentaDTO
    {
        public int DocID { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteID { get; set; }
        public decimal TotalFactura { get; set; }
        public List<FacturaVentaDetalleDTO> Detalles { get; set; }
    }

}
