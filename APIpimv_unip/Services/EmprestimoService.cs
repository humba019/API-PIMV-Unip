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
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository, 
                                    IEquipamentoRepository equipamentoRepository, 
                                        IUsuarioRepository usuarioRepository, 
                                            IUnitOfWork unitOfWork)
        {
            this._emprestimoRepository = emprestimoRepository;
            this._equipamentoRepository = equipamentoRepository;
            this._usuarioRepository = usuarioRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<EmprestimoResponse> DeleteAsync(int id)
        {
            var exist = await _emprestimoRepository.FindByIdAsync(id);

            if (exist == null)
                return new EmprestimoResponse("Emprestimo not found");

            try
            {
                _emprestimoRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return new EmprestimoResponse(exist);
            }
            catch (Exception e)
            {
                return new EmprestimoResponse($"An error occurred when deleting the emprestimo: {e.Message}");
            }
        }

        public async Task<IEnumerable<Emprestimo>> ListAsync()
        {
            return await _emprestimoRepository.ListAsync();
        }

        public async Task<EmprestimoResponse> SaveAsync(Emprestimo emprestimo)
        {
            try
            {
                var equipamento = _equipamentoRepository.FindByIdAsync(emprestimo.IdEquipamento);

                if (equipamento == null)
                    return new EmprestimoResponse("Equipamento not found");

                var usuario = _usuarioRepository.FindByIdAsync(emprestimo.Login);

                if (usuario == null)
                    return new EmprestimoResponse("Usuario not found");

                await _emprestimoRepository.AddAsync(emprestimo);
                await _unitOfWork.CompleteAsync();

                return new EmprestimoResponse(emprestimo);

            }
            catch (Exception e)
            {
                return new EmprestimoResponse($"An error occurred when saving the emprestimo: {e.Message}");
            }
        }

        public async Task<EmprestimoResponse> UpdateAsync(int id, Emprestimo emprestimo)
        {
            var exist = await _emprestimoRepository.FindByIdAsync(id);

            if (exist == null)
                return new EmprestimoResponse("Emprestimo not found");

            exist.IdEquipamento = emprestimo.IdEquipamento;
            exist.Login = emprestimo.Login;
            exist.RelatorioDevolucao = emprestimo.RelatorioDevolucao;
            exist.DataDevolucao = emprestimo.DataDevolucao;
            exist.AtividadeEmprestimo = emprestimo.AtividadeEmprestimo;

            try
            {
                var equipamento = _equipamentoRepository.FindByIdAsync(emprestimo.IdEquipamento);

                if (equipamento == null)
                    return new EmprestimoResponse("Equipamento not found");

                var usuario = _usuarioRepository.FindByIdAsync(emprestimo.Login);

                if (usuario == null)
                    return new EmprestimoResponse("Usuario not found");

                await _emprestimoRepository.AddAsync(emprestimo);
                await _unitOfWork.CompleteAsync();

                return new EmprestimoResponse(emprestimo);

            }
            catch (Exception e)
            {
                return new EmprestimoResponse($"An error occurred when updating the emprestimo: {e.Message}");
            }
        }
    }
}
