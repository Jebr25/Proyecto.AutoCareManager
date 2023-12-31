﻿using Microsoft.EntityFrameworkCore;
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
    internal class TallerRepository : ITallerRepository
    {
        private readonly AutocaremanagerContext _context;

        public TallerRepository(AutocaremanagerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TbTaller>> GetTalleres()
        {
            var taller = await _context.TbTaller.ToListAsync();
            return taller;

        }

        public async Task<TbTaller> GetTaller(int CodTaller)
        {
            //return _context.User.Find(id);

            return await _context.TbTaller.Where(x => x.CodTaller == CodTaller).FirstOrDefaultAsync();

        }

        public async Task<bool> Insert(TbTaller taller)
        {
            await _context.TbTaller.AddAsync(taller);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(TbTaller taller)
        {
            _context.TbTaller.Update(taller);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int CodTaller)
        {
            var taller = await _context.TbTaller.FindAsync(CodTaller);
            return (taller != null);
        }


    }
}
