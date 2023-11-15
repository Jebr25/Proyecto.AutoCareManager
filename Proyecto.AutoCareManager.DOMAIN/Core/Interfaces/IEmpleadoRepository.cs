<<<<<<< HEAD
<<<<<<< HEAD
﻿using Proyecto.AutoCareManager.DOMAIN.Core.DTO;
using Proyecto.AutoCareManager.DOMAIN.Core.Entities;
=======
﻿using Proyecto.AutoCareManager.DOMAIN.Core.Entities;
>>>>>>> 8229652052ff8ae0b330b3b9f6efdeb93f60b8d0
=======
﻿using Proyecto.AutoCareManager.DOMAIN.Core.Entities;
>>>>>>> 8229652052ff8ae0b330b3b9f6efdeb93f60b8d0

namespace Proyecto.AutoCareManager.DOMAIN.Core.Interfaces
{
    public interface IEmpleadoRepository
    {
<<<<<<< HEAD
<<<<<<< HEAD
        Task<bool> Delete(int id);
        Task<IEnumerable<TbEmpleado>> GetAll();
        Task<IEnumerable<EmpleadoDTO>> GetAllDTO();
        Task<TbEmpleado> GetById(int id);
        Task<EmpleadoDTO> GetByIdDTO(int id);
        Task<bool> Insert(TbEmpleado empleado);
        Task<bool> Insert(EmpleadoDTO empleadoDTO);
        Task<bool> Update(EmpleadoActualizarDTO empleadoActualizarDTO);
=======
=======
>>>>>>> 8229652052ff8ae0b330b3b9f6efdeb93f60b8d0
        Task<bool> Delete(int CodEmpleado);
        Task<IEnumerable<TbEmpleado>> GetEmpleados();
        Task<TbEmpleado> GetEmpleados(int CodEmpleado);
        Task<bool> Insert(TbEmpleado empleado);
        Task<bool> Update(TbEmpleado empleado);
<<<<<<< HEAD
>>>>>>> 8229652052ff8ae0b330b3b9f6efdeb93f60b8d0
=======
>>>>>>> 8229652052ff8ae0b330b3b9f6efdeb93f60b8d0
    }
}