using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.AutoCareManager.DOMAIN.Core.DTO
{
    public class EmpleadoDTO
    {
        public int CodEmpleado { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string NumIdent { get; set; } = null!;

        public string? Cargo { get; set; }

        public string Estado { get; set; } = null!;

        public int CodTaller { get; set; }

        public int? UserCode { get; set; }
    }

    public class EmpleadoActualizarDTO
    {
        public int CodEmpleado { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string NumIdent { get; set; } = null!;

        public string? Cargo { get; set; }

        public string Estado { get; set; } = null!;

        public int CodTaller { get; set; }

        public int? UserCode { get; set; }
    }
}
