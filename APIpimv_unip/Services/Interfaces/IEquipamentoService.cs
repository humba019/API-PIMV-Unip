using APIpimv_unip.Models;
using APIpimv_unip.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services
{
    public interface IEquipamentoService
    {
        Task<IEnumerable<Equipamento>> ListAsync();
        Task<EquipamentoResponse> SaveAsync(Equipamento equipamento);
        Task<EquipamentoResponse> UpdateAsync(int id, Equipamento equipamento);
        Task<EquipamentoResponse> DeleteAsync(int id);
    }
}
