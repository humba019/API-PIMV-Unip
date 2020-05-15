using APIpimv_unip.Models;
using APIpimv_unip.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services.Interfaces
{
    public interface IPeriodoService
    {
        Task<IEnumerable<Periodo>> ListAsync();
        Task<PeriodoResponse> SaveAsync(Periodo periodo);
        Task<PeriodoResponse> UpdateAsync(int id, Periodo periodo);
        Task<PeriodoResponse> DeleteAsync(int id);
    }
}
