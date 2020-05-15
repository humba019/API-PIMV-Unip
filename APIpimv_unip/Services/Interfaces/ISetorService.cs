using APIpimv_unip.Models;
using APIpimv_unip.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services
{
    public interface ISetorService
    {
        Task<IEnumerable<Setor>> ListAsync();
        Task<SaveSetorResponse> SaveAsync(Setor setor);
        Task<SaveSetorResponse> UpdateAsync(int id, Setor setor);
        Task<SaveSetorResponse> DeleteAsync(int id);

    }
}
