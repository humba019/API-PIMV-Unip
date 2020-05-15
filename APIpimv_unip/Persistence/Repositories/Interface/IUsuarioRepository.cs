using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ListAsync();
        Task AddAsync(Usuario usuario);
        Task<Usuario> FindByIdAsync(string login);
        void Update(Usuario usuario);
        void Remove(Usuario usuario);
    }
}
