using APIpimv_unip.Models;
using APIpimv_unip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public class AulaRepository : BaseRepository, IAulaRepository
    {
        public AulaRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Aula aula)
        {
            await _context.Aula.AddAsync(aula);
        }

        public async Task<IEnumerable<Aula>> ListAsync()
        {
            return await _context.Aula.Include(a => a.Disciplina)
                                            .ToListAsync();
        }

        public async Task<Aula> FindByIdAsync(int id)
        {
            return await _context.Aula.FindAsync(id);
        }

        public void Update(Aula aula)
        {
            _context.Aula.Update(aula);
        }

        public void Remove(Aula aula)
        {
            _context.Aula.Remove(aula);
        }
    }
}
