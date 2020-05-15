using APIpimv_unip.Models;
using APIpimv_unip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Persistence.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
        }

        public async Task<IEnumerable<Usuario>> ListAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<Usuario> FindByIdAsync(string login)
        {
            return await _context.Usuario.FindAsync(login);
        }

        public void Update(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
        }

        public void Remove(Usuario usuario)
        {
            _context.Usuario.Remove(usuario);
        }
    }
}
