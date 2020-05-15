using APIpimv_unip.Models;
using APIpimv_unip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public class ProfessorRepository : BaseRepository, IProfessorRepository
    {
        public ProfessorRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Professor professor)
        {
            await _context.Professor.AddAsync(professor);
        }

        public async Task<Professor> FindByIdAsync(int id)
        {
            return await _context.Professor.FindAsync(id);
        }

        public async Task<IEnumerable<Professor>> ListAsync()
        {
            return await _context.Professor.Include(e => e.Usuario)
                                           .Include(e => e.Disciplina)
                                                .ToListAsync();
        }

        public void Remove(Professor professor)
        {
            _context.Professor.Remove(professor);
        }

        public void Update(Professor professor)
        {
            _context.Professor.Update(professor);
        }
    }
}
