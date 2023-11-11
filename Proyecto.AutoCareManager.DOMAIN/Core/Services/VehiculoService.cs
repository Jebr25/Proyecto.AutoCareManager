// VehiculoService.cs
using Proyecto.AutoCareManager.DOMAIN.Core.DTO;
using Proyecto.AutoCareManager.DOMAIN.Core.Entities;
using Proyecto.AutoCareManager.DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.AutoCareManager.DOMAIN.Core.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;

        public VehiculoService(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public async Task<IEnumerable<ConsultaVehiculoDTO>> GetAllVehiculos()
        {
            var vehiculos = await _vehiculoRepository.GetAllVehiculosAsync();
            return vehiculos.Select(v => new ConsultaVehiculoDTO
            {
                CodVehiculo = v.CodVehiculo,
                Placa = v.Placa,
                Marca = v.Marca,
                Modelo = v.Modelo,
                Año = v.Año,
                FecUltMant = v.FecUltMant,
                CodSN = v.CodSn
            }).ToList();
        }

        public async Task<ConsultaVehiculoDTO> GetVehiculoById(int codVehiculo)
        {
            var vehiculo = await _vehiculoRepository.GetVehiculoByIdAsync(codVehiculo);
            if (vehiculo == null) return null;

            return new ConsultaVehiculoDTO
            {
                CodVehiculo = vehiculo.CodVehiculo,
                Placa = vehiculo.Placa,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Año = vehiculo.Año,
                FecUltMant = vehiculo.FecUltMant,
                CodSN = vehiculo.CodSn
            };
        }

        public async Task<bool> CreateVehiculo(CrearVehiculoDTO vehiculoDTO)
        {
            var vehiculo = new TbVehiculo
            {
                Placa = vehiculoDTO.Placa,
                Marca = vehiculoDTO.Marca,
                Modelo = vehiculoDTO.Modelo,
                Año = vehiculoDTO.Año,
                FecUltMant = vehiculoDTO.FecUltMant,
                CodSn = vehiculoDTO.CodSN
            };

            return await _vehiculoRepository.CreateVehiculoAsync(vehiculo);
        }

        public async Task<bool> UpdateVehiculo(ActualizarVehiculoDTO vehiculoDTO)
        {
            var vehiculo = new TbVehiculo
            {
                CodVehiculo = vehiculoDTO.CodVehiculo,
                Placa = vehiculoDTO.Placa,
                Marca = vehiculoDTO.Marca,
                Modelo = vehiculoDTO.Modelo,
                Año = vehiculoDTO.Año,
                FecUltMant = vehiculoDTO.FecUltMant,
                CodSn = vehiculoDTO.CodSN
            };

            return await _vehiculoRepository.UpdateVehiculoAsync(vehiculo);
        }

        public async Task<bool> DeleteVehiculo(int codVehiculo)
        {
            return await _vehiculoRepository.DeleteVehiculoAsync(codVehiculo);
        }
    }
}

