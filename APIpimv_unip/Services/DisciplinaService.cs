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
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IPeriodoRepository _periodoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DisciplinaService(IDisciplinaRepository disciplinaRepository, IPeriodoRepository periodoRepository, IUnitOfWork unitOfWork)
        {
            this._disciplinaRepository = disciplinaRepository;
            this._periodoRepository = periodoRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<DisciplinaResponse> DeleteAsync(int id)
        {
            var exist = await _disciplinaRepository.FindByIdAsync(id);

            if (exist == null)
                return new DisciplinaResponse("Disciplina not found");

            try
            {
                _disciplinaRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return new DisciplinaResponse(exist);
            }
            catch(Exception e)
            {
                return new DisciplinaResponse($"An error occurred when deleting the disciplina: {e.Message}");
            }
        }

        public async Task<IEnumerable<Disciplina>> ListAsync()
        {
            return await _disciplinaRepository.ListAsync();
        }

        public async Task<DisciplinaResponse> SaveAsync(Disciplina disciplina)
        {
            try
            {
                var periodo = _periodoRepository.FindByIdAsync(disciplina.IdPeriodo);

                if (periodo == null)
                    return new DisciplinaResponse("Periodo not found");

                await _disciplinaRepository.AddAsync(disciplina);
                await _unitOfWork.CompleteAsync();

                return new DisciplinaResponse(disciplina);
            }
            catch(Exception e)
            {
                return new DisciplinaResponse($"An error occurred when saving the disciplina: {e.Message}");
            }
        }

        public async Task<DisciplinaResponse> UpdateAsync(int id, Disciplina disciplina)
        {
            var exist = await _disciplinaRepository.FindByIdAsync(id);

            if (exist == null)
                return new DisciplinaResponse("Disciplina not found");

            exist.Descricao = disciplina.Descricao;
            exist.CargaHora = disciplina.CargaHora;
            exist.AreaAcademica = disciplina.AreaAcademica;
            exist.IdPeriodo = disciplina.IdPeriodo;
            exist.AtividadeDisciplina = disciplina.AtividadeDisciplina;           

            try
            {
                var periodo = _periodoRepository.FindByIdAsync(exist.IdPeriodo);

                if (periodo == null)
                    return new DisciplinaResponse("Periodo not found");

                _disciplinaRepository.Update(exist);
                await _unitOfWork.CompleteAsync();

                return new DisciplinaResponse(exist);
            }
            catch (Exception e)
            {
                return new DisciplinaResponse($"An error occurred when updating the disciplina: {e.Message}");
            }
        }
    }
}
