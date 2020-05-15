using APIpimv_unip.Models;
using APIpimv_unip.Persistence.Contexts;
using APIpimv_unip.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public class SetorRepository : BaseRepository, ISetorRepository
    {
        public SetorRepository(AppDbContext context) : base (context) {}

        public async Task AddAsync(Setor setor)
        {
           await _context.Setor.AddAsync(setor);
        }

        public async Task<IEnumerable<Setor>> ListAsync()
        {
            return await _context.Setor.ToListAsync();
        }

        public async Task<Setor> FindByIdAsync(int id)
        {
            return await _context.Setor.FindAsync(id);
        }

        public void Update(Setor setor)
        {
            _context.Setor.Update(setor);
        }

        public void Remove(Setor setor)
        {
            _context.Setor.Remove(setor);
        }
    }
}
