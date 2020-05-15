using APIpimv_unip.Models;
using APIpimv_unip.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ListAsync();
        Task<UsuarioResponse> SaveAsync(Usuario usuario);
        Task<UsuarioResponse> UpdateAsync(string login, Usuario usuario);
        Task<UsuarioResponse> DeleteAsync(string login);
    }
}
