using APIpimv_unip.Models;
using APIpimv_unip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public class EquipamentoRepository : BaseRepository, IEquipamentoRepository
    {
        public EquipamentoRepository(AppDbContext context) : base (context){}

        public async Task AddAsync(Equipamento equipamento)
        {
            await _context.Equipamento.AddAsync(equipamento);
        }

        public async Task<Equipamento> FindByIdAsync(int id)
        {
            return await _context.Equipamento.FindAsync(id);
        }

        public async Task<IEnumerable<Equipamento>> ListAsync()
        {
            return await _context.Equipamento.Include(e => e.Setor)
                                              .ToListAsync();
        }

        public void Remove(Equipamento equipamento)
        {
            _context.Equipamento.Remove(equipamento);
        }

        public void Update(Equipamento equipamento)
        {
            _context.Equipamento.Update(equipamento);
        }
    }
}
