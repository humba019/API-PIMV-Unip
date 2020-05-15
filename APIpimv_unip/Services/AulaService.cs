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
    public class AulaService : IAulaService
    {
        private readonly IAulaRepository _aulaRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AulaService(IAulaRepository aulaRepository, IDisciplinaRepository disciplinaRepository, IUnitOfWork unitOfWork)
        {
            this._aulaRepository = aulaRepository;
            this._disciplinaRepository = disciplinaRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<AulaResponse> DeleteAsync(int id)
        {
            var exist = await _aulaRepository.FindByIdAsync(id);
            if (exist == null)
                new AulaResponse("Aula not found");

            try
            {
                _aulaRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return new AulaResponse(exist);
            }
            catch(Exception e)
            {
                return new AulaResponse($"An error occurred when deleting the aula: {e.Message}");
            }
        }

        public async Task<IEnumerable<Aula>> ListAsync()
        {
            return await _aulaRepository.ListAsync();
        }

        public async Task<AulaResponse> SaveAsync(Aula aula)
        {
            try
            {
                var disciplina = _disciplinaRepository.FindByIdAsync(aula.IdDisciplina);
                if (disciplina == null)
                    return new AulaResponse("Disciplina not found");

                await _aulaRepository.AddAsync(aula);
                await _unitOfWork.CompleteAsync();

                return new AulaResponse(aula);
            }
            catch (Exception e)
            {
                return new AulaResponse($"An error occurred when saving the aula: {e.Message}");
            }
        }

        public async Task<AulaResponse> UpdateAsync(int id, Aula aula)
        {
            var exist = await _aulaRepository.FindByIdAsync(id);
            if (exist == null)
                new AulaResponse("Aula not found");

            exist.Andar = aula.Andar;
            exist.Descricao = aula.Descricao;
            exist.IdDisciplina = aula.IdDisciplina;           

            try
            {
                var disciplina = _disciplinaRepository.FindByIdAsync(exist.IdDisciplina);
                if (disciplina == null)
                    return new AulaResponse("Disciplina not found");

                _aulaRepository.Update(exist);
                await _unitOfWork.CompleteAsync();

                return new AulaResponse(exist);
            }
            catch (Exception e)
            {
                return new AulaResponse($"An error occurred when updating the aula: {e.Message}");
            }
        }
    }
}
