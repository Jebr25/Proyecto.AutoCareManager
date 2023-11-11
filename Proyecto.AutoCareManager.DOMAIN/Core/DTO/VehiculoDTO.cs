using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.AutoCareManager.DOMAIN.Core.DTO
{
    public class VehiculoDTO
    {
        public int CodVehiculo { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Año { get; set; }
        public DateTime? FecUltMant { get; set; }
        public int CodSN { get; set; } // Suponiendo que este es el ID del socio de negocio (cliente)
    }

    public class CrearVehiculoDTO
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Año { get; set; }
        public DateTime? FecUltMant { get; set; }
        public int CodSN { get; set; }
    }

    public class ActualizarVehiculoDTO
    {
        public int CodVehiculo { get; set; } // Se usa para identificar el vehículo a actualizar
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Año { get; set; }
        public DateTime? FecUltMant { get; set; }
        public int CodSN { get; set; }
    }

    public class ConsultaVehiculoDTO
    {
        public int CodVehiculo { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Año { get; set; }
        public DateTime? FecUltMant { get; set; }
        public int CodSN { get; set; }
    }
}
