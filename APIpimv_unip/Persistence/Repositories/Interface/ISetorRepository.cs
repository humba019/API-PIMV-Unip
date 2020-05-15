using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Repositories
{
    public interface ISetorRepository
    {
        Task<IEnumerable<Setor>> ListAsync();
        Task AddAsync(Setor setor);
        Task<Setor> FindByIdAsync(int id);
        void Update(Setor setor);
        void Remove(Setor setor);
    }
}
