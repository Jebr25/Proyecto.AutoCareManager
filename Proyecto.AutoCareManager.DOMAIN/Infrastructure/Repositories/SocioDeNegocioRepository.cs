using Microsoft.EntityFrameworkCore;
using Proyecto.AutoCareManager.DOMAIN.Core.Entities;
using Proyecto.AutoCareManager.DOMAIN.Core.Interfaces;
using Proyecto.AutoCareManager.DOMAIN.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.AutoCareManager.DOMAIN.Infrastructure.Repositories
{
    public class SocioDeNegocioRepository : ISocioDeNegocioRepository
    {
        private readonly AutocaremanagerContext _context;

        public SocioDeNegocioRepository(AutocaremanagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TbSocioDeNegocio>> GetTbSocioDeNegocio()
        {
            var socioNegocio = await _context.TbSocioDeNegocio.ToListAsync();
            return socioNegocio;
        }

        public async Task<TbSocioDeNegocio> GetSocioDeNegocio(int CodSN)
        {
            return await _context.TbSocioDeNegocio.Where(x => x.CodSn == CodSN).FirstOrDefaultAsync();
        }
        public async Task<bool> Insert(TbSocioDeNegocio socioNegocio)
        {
            await _context.TbSocioDeNegocio.AddAsync(socioNegocio);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(TbSocioDeNegocio socioNegocio)
        {
            _context.TbSocioDeNegocio.Update(socioNegocio);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int CodSN)
        {
            var socioNegocio = await _context.TbSocioDeNegocio.FindAsync(CodSN);
            return (socioNegocio != null);

        }


    }
}
