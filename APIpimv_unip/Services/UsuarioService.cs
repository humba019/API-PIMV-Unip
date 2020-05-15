using APIpimv_unip.Models;
using APIpimv_unip.Persistence.Repositories;
using APIpimv_unip.Services.Communication;
using APIpimv_unip.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            this._usuarioRepository = usuarioRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<UsuarioResponse> DeleteAsync(string login)
        {
            var exist = await _usuarioRepository.FindByIdAsync(login);

            if (exist == null)
                return new UsuarioResponse("Usuario not found");

            try
            {
                _usuarioRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return new UsuarioResponse(exist);
            }
            catch (Exception e)
            {
                return new UsuarioResponse($"An error occurred when deleting the usuario: {e.Message}");
            }
        }

        public async Task<IEnumerable<Usuario>> ListAsync()
        {
            return await _usuarioRepository.ListAsync();
        }

        public async Task<UsuarioResponse> SaveAsync(Usuario usuario)
        {
            try
            {
                await _usuarioRepository.AddAsync(usuario);
                await _unitOfWork.CompleteAsync();

                return new UsuarioResponse(usuario);
            }
            catch (Exception e)
            {
                return new UsuarioResponse($"An error occurred when saving the usuario: {e.Message}");
            }
        }

        public async Task<UsuarioResponse> UpdateAsync(string login, Usuario usuario)
        {
            var exist = await _usuarioRepository.FindByIdAsync(login);

            if (exist == null)
                return new UsuarioResponse("Usuario not found");

            exist.Nome = usuario.Nome;
            exist.Sobrenome = usuario.Sobrenome;
            exist.Login = usuario.Login;
            exist.Rg = usuario.Rg;
            exist.Cpf = usuario.Cpf;

            try
            {
                _usuarioRepository.Update(exist);
                await _unitOfWork.CompleteAsync();

                return new UsuarioResponse(exist);
            }
            catch (Exception e)
            {
                return new UsuarioResponse($"An error occurred when updating the usuario: {e.Message}");
            }
        }
    }
}
