using APIpimv_unip.Models;
using APIpimv_unip.Persistence.Repositories;
using APIpimv_unip.Repositories;
using APIpimv_unip.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services
{
    public class EquipamentoService : IEquipamentoService
    {
        private readonly IEquipamentoRepository _equipamentoRespoitory;
        private readonly ISetorRepository _setorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EquipamentoService(IEquipamentoRepository equipamentoRespoitory, ISetorRepository setorRepository, IUnitOfWork unitOfWork)
        {
            this._equipamentoRespoitory = equipamentoRespoitory;
            this._setorRepository = setorRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<EquipamentoResponse> SaveAsync(Equipamento equipamento)
        {
            try
            {   
                var exist = await _setorRepository.FindByIdAsync(equipamento.IdSetor);

                if (exist == null)
                    return new EquipamentoResponse($"Setor {equipamento.IdSetor} not found");

                await _equipamentoRespoitory.AddAsync(equipamento);
                await _unitOfWork.CompleteAsync();

                return new EquipamentoResponse(equipamento);
            }
            catch (Exception e)
            {
                return new EquipamentoResponse($"An error occurred when saving the equipamento: {e.Message}");
            }
        }
        public async Task<IEnumerable<Equipamento>> ListAsync()
        {
            return await _equipamentoRespoitory.ListAsync();
        }


        public async Task<EquipamentoResponse> UpdateAsync(int id, Equipamento equipamento)
        {
            var exist = await _equipamentoRespoitory.FindByIdAsync(id);

            if (exist == null)
                return new EquipamentoResponse("Equipamento not found");

            exist.Descricao = equipamento.Descricao;
            exist.Quantidade = equipamento.Quantidade;
            exist.IdSetor = equipamento.IdSetor;

            try
            {
                _equipamentoRespoitory.Update(exist);
                await _unitOfWork.CompleteAsync();

                return new EquipamentoResponse(exist);
            }
            catch (Exception e)
            {
                return new EquipamentoResponse($"An error occurred when updating the equipamento: {e.Message}");
            }
        }
        public async Task<EquipamentoResponse> DeleteAsync(int id)
        {
            var exist = await _equipamentoRespoitory.FindByIdAsync(id);

            if (exist == null)
                return new EquipamentoResponse("Equipamento not found");

            try
            {
                _equipamentoRespoitory.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return new EquipamentoResponse(exist);
            }
            catch (Exception e)
            {
                return new EquipamentoResponse($"An error occurred when deleting the equipamento: {e.Message}");
            }
        }
    }
}
