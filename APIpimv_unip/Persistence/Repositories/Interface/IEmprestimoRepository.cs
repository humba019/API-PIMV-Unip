using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public interface IEmprestimoRepository
    {
        Task<IEnumerable<Emprestimo>> ListAsync();
        Task AddAsync(Emprestimo emprestimo);
        Task<Emprestimo> FindByIdAsync(int id);
        void Update(Emprestimo emprestimo);
        void Remove(Emprestimo emprestimo);
    }
}
