using APIpimv_unip.Models;
using APIpimv_unip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public class AdvertenciaRepository : BaseRepository, IAdvertenciaRepository
    {
        public AdvertenciaRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Advertencia advertencia)
        {
            await _context.Advertencia.AddAsync(advertencia);
        }

        public async Task<IEnumerable<Advertencia>> ListAsync()
        {
            return await _context.Advertencia.ToListAsync();
        }

        public async Task<Advertencia> FindByIdAsync(int id)
        {
            return await _context.Advertencia.FindAsync(id);
        }

        public void Update(Advertencia advertencia)
        {
            _context.Advertencia.Update(advertencia);
        }

        public void Remove(Advertencia advertencia)
        {
            _context.Advertencia.Remove(advertencia);
        }
    }
}
