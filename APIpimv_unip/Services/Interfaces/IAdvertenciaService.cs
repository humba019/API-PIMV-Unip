using APIpimv_unip.Models;
using APIpimv_unip.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services.Interfaces
{
    public interface IAdvertenciaService
    {
        Task<IEnumerable<Advertencia>> ListAsync();
        Task<AdvertenciaResponse> SaveAsync(Advertencia advertencia);
        Task<AdvertenciaResponse> UpdateAsync(int id, Advertencia advertencia);
        Task<AdvertenciaResponse> DeleteAsync(int id);
    }
}
