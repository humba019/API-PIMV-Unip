using APIpimv_unip.Models;
using APIpimv_unip.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services.Interfaces
{
    public interface IAulaService
    {
        Task<IEnumerable<Aula>> ListAsync();
        Task<AulaResponse> SaveAsync(Aula aula);
        Task<AulaResponse> UpdateAsync(int id, Aula aula);
        Task<AulaResponse> DeleteAsync(int id);
    }
}
