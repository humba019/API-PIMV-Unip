using APIpimv_unip.Models;
using APIpimv_unip.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services.Interfaces
{
    public interface IEmprestimoService
    {
        Task<IEnumerable<Emprestimo>> ListAsync();
        Task<EmprestimoResponse> SaveAsync(Emprestimo emprestimo);
        Task<EmprestimoResponse> UpdateAsync(int id, Emprestimo emprestimo);
        Task<EmprestimoResponse> DeleteAsync(int id);
    }
}
