using APIpimv_unip.Models;
using APIpimv_unip.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services.Interfaces
{
    public interface IDisciplinaService
    {
        Task<IEnumerable<Disciplina>> ListAsync();
        Task<DisciplinaResponse> SaveAsync(Disciplina disciplina);
        Task<DisciplinaResponse> UpdateAsync(int id, Disciplina disciplina);
        Task<DisciplinaResponse> DeleteAsync(int id);
    }
}
