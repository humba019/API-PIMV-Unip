using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public interface IDisciplinaRepository
    {
        Task<IEnumerable<Disciplina>> ListAsync();
        Task AddAsync(Disciplina disciplina);
        Task<Disciplina> FindByIdAsync(int id);
        void Update(Disciplina disciplina);
        void Remove(Disciplina disciplina);
    }
}
