using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public interface IAdvertenciaRepository
    {
        Task<IEnumerable<Advertencia>> ListAsync();
        Task AddAsync(Advertencia advertencia);
        Task<Advertencia> FindByIdAsync(int id);
        void Update(Advertencia advertencia);
        void Remove(Advertencia advertencia);
    }
    
}
