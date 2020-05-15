using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public interface IAulaRepository
    {
        Task<IEnumerable<Aula>> ListAsync();
        Task AddAsync(Aula aula);
        Task<Aula> FindByIdAsync(int id);
        void Update(Aula aula);
        void Remove(Aula aula);
    }
}
