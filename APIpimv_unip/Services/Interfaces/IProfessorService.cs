using APIpimv_unip.Models;
using APIpimv_unip.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services.Interfaces
{
    public interface IProfessorService
    {
        Task<IEnumerable<Professor>> ListAsync();
        Task<ProfessorResponse> SaveAsync(Professor professor);
        Task<ProfessorResponse> UpdateAsync(int id, Professor professor);
        Task<ProfessorResponse> DeleteAsync(int id);
    }
}
