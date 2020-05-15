using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public interface IEquipamentoRepository
    {
        Task<IEnumerable<Equipamento>> ListAsync();
        Task AddAsync(Equipamento equipamento);
        Task<Equipamento> FindByIdAsync(int id);
        void Update(Equipamento equipamento);
        void Remove(Equipamento equipamento);
    }
}
