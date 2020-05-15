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
    public class SetorService : ISetorService
    {
        private readonly ISetorRepository _setorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SetorService(ISetorRepository setorRepository, IUnitOfWork unitOfWork)
        {
            this._setorRepository = setorRepository;
            this._unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Setor>> ListAsync()
        {
            return await _setorRepository.ListAsync();
        }

        public async Task<SaveSetorResponse> SaveAsync(Setor setor)
        {
            try
            {
                await _setorRepository.AddAsync(setor);
                await _unitOfWork.CompleteAsync();

                return new SaveSetorResponse(setor);
            }
            catch(Exception e)
            {
                return new SaveSetorResponse($"An error occurred when saving the category: {e.Message}");
            }
        }

        public async Task<SaveSetorResponse> UpdateAsync(int id, Setor setor)
        {
            var exist = await _setorRepository.FindByIdAsync(id);

            if (exist == null)
                return new SaveSetorResponse("Setor not found");

            exist.Descricao = setor.Descricao;
            exist.AtividadeSetor = setor.AtividadeSetor;

            try
            {
                _setorRepository.Update(exist);
                await _unitOfWork.CompleteAsync();

                return new SaveSetorResponse(exist);
            }
            catch(Exception e)
            {
                return new SaveSetorResponse($"An error occurred when updating the setor: {e.Message}");
            }
        }

        public async Task<SaveSetorResponse> DeleteAsync(int id)
        {
            var exist = await _setorRepository.FindByIdAsync(id);

            if (exist == null)
                return new SaveSetorResponse("Setor not found");

            try
            {
                _setorRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return new SaveSetorResponse(exist);
            }
            catch (Exception e)
            {
                return new SaveSetorResponse($"An error occurred when deleting the setor: {e.Message}");
            }

        }

    }
}
