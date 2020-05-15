using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public interface IProfessorRepository
    {
        Task<IEnumerable<Professor>> ListAsync();
        Task AddAsync(Professor professor);
        Task<Professor> FindByIdAsync(int id);
        void Update(Professor professor);
        void Remove(Professor professor);
    }
}
