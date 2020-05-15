using APIpimv_unip.Models;
using APIpimv_unip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public class DisciplinaRepository : BaseRepository, IDisciplinaRepository
    {
        public DisciplinaRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Disciplina disciplina)
        {
            await _context.Disciplina.AddAsync(disciplina);
        }

        public async Task<IEnumerable<Disciplina>> ListAsync()
        {
            return await _context.Disciplina.Include(d => d.Periodo)
                                                .ToListAsync();
        }

        public async Task<Disciplina> FindByIdAsync(int id)
        {
            return await _context.Disciplina.FindAsync(id);
        }

        public void Update(Disciplina disciplina)
        {
            _context.Disciplina.Update(disciplina);
        }

        public void Remove(Disciplina disciplina)
        {
            _context.Disciplina.Remove(disciplina);
        }
    }
}
