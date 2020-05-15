using APIpimv_unip.Models;
using APIpimv_unip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public class EmprestimoRepository : BaseRepository, IEmprestimoRepository
    {
        public EmprestimoRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Emprestimo emprestimo)
        {
            await _context.Emprestimo.AddAsync(emprestimo);
        }

        public async Task<IEnumerable<Emprestimo>> ListAsync()
        {
            return await _context.Emprestimo.Include(e => e.Usuario)
                                            .Include(e => e.Equipamento)
                                                .ToListAsync();
        }

        public async Task<Emprestimo> FindByIdAsync(int id)
        {
            return await _context.Emprestimo.FindAsync(id);
        }

        public void Update(Emprestimo emprestimo)
        {
            _context.Emprestimo.Update(emprestimo);
        }

        public void Remove(Emprestimo emprestimo)
        {
            _context.Emprestimo.Remove(emprestimo);
        }
    }
}
