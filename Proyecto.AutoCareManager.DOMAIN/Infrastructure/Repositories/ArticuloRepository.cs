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
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly AutocaremanagerContext _dbContext;
        private object articuloDTO;

        public ArticuloRepository(AutocaremanagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TbArticulo>> GetAll()
        {
            return await _dbContext.TbArticulo.ToListAsync();
        }

        public async Task<TbArticulo> GetById(int id)
        {
            return await _dbContext.TbArticulo.Where(x => x.CodArticulo == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(TbArticulo articulo)
        {
            await _dbContext.TbArticulo.AddAsync(articulo);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(ArticuloActualizarDTO articuloActualizarDTO)
        {
            var existingArticulo = await _dbContext.TbArticulo.FindAsync(articuloActualizarDTO.CodArticulo);

            if (existingArticulo == null)
            {
                return false;
            }

            // Verifica si las propiedades están presentes en el JSON.
            if (articuloActualizarDTO.DesArticulo != null)
            {
                existingArticulo.DesArticulo = articuloActualizarDTO.DesArticulo;
            }

            if (articuloActualizarDTO.ArtInventariable != null)
            {
                existingArticulo.ArtInventariable = articuloActualizarDTO.ArtInventariable;
            }

            if (articuloActualizarDTO.TipoServicio != null)
            {
                existingArticulo.TipoServicio = articuloActualizarDTO.TipoServicio;
            }

            if (articuloActualizarDTO.UnidadMedida != null)
            {
                existingArticulo.UnidadMedida = articuloActualizarDTO.UnidadMedida;
            }

            if (articuloActualizarDTO.Fabricante != null)
            {
                existingArticulo.Fabricante = articuloActualizarDTO.Fabricante;
            }

            if (articuloActualizarDTO.ImpVenta != null)
            {
                existingArticulo.ImpVenta = articuloActualizarDTO.ImpVenta;
            }

            if (articuloActualizarDTO.Estado != null)
            {
                existingArticulo.Estado = articuloActualizarDTO.Estado;
            }

            var rows = await _dbContext.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var articulo = await _dbContext.TbArticulo.Where(x => x.CodArticulo == id).FirstOrDefaultAsync();

            if (articulo == null)
                return false;

            _dbContext.TbArticulo.Remove(articulo);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        /*
        public async Task<bool> Update(TbArticulo articulo)
        {
            var existingArticulo = await _dbContext.TbArticulo.FindAsync(articulo.CodArticulo);

            if (existingArticulo == null)
            {
                return false;
            }

            existingArticulo.DesArticulo = articulo.DesArticulo;
            existingArticulo.ArtInventariable = articulo.ArtInventariable;
            existingArticulo.TipoServicio = articulo.TipoServicio;
            existingArticulo.UnidadMedida = articulo.UnidadMedida;
            existingArticulo.Fabricante = articulo.Fabricante;
            existingArticulo.ImpVenta = articulo.ImpVenta;
            existingArticulo.Estado = articulo.Estado;

            var rows = await _dbContext.SaveChangesAsync();

            return rows > 0;
        }
        */

    }
}
