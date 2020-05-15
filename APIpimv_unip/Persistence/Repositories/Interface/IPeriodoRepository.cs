using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public interface IPeriodoRepository
    {
        Task<IEnumerable<Periodo>> ListAsync();
        Task AddAsync(Periodo periodo);
        Task<Periodo> FindByIdAsync(int id);
        void Update(Periodo periodo);
        void Remove(Periodo periodo);
    }
}
