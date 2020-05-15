using APIpimv_unip.Models;
using APIpimv_unip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public class PeriodoRepository : BaseRepository, IPeriodoRepository
    {
        public PeriodoRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Periodo periodo)
        {
            await _context.Periodo.AddAsync(periodo);
        }

        public async Task<Periodo> FindByIdAsync(int id)
        {
            return await _context.Periodo.FindAsync(id);
        }

        public async Task<IEnumerable<Periodo>> ListAsync()
        {
            return await _context.Periodo.ToListAsync();
        }

        public void Remove(Periodo periodo)
        {
            _context.Periodo.Remove(periodo);
        }

        public void Update(Periodo periodo)
        {
            _context.Periodo.Update(periodo);
        }
    }
}
