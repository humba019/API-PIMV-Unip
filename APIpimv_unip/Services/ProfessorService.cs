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
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProfessorService(IProfessorRepository professorRepository, 
                                    IDisciplinaRepository disciplinaRepository, 
                                        IUsuarioRepository usuarioRepository, 
                                            IUnitOfWork unitOfWork)
        {
            this._professorRepository = professorRepository;
            this._disciplinaRepository = disciplinaRepository;
            this._usuarioRepository = usuarioRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<ProfessorResponse> DeleteAsync(int id)
        {
            var exist = await _professorRepository.FindByIdAsync(id);

            if (exist == null)
                return new ProfessorResponse("Professor not found");

            try
            {
                _professorRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return new ProfessorResponse(exist);
            }
            catch (Exception e)
            {
                return new ProfessorResponse($"An error occurred when deleting the professor: {e.Message}");
            }
        }

        public async Task<IEnumerable<Professor>> ListAsync()
        {
            return await _professorRepository.ListAsync();
        }

        public async Task<ProfessorResponse> SaveAsync(Professor professor)
        {
            try
            {
                var disciplina = await _disciplinaRepository.FindByIdAsync(professor.IdDisciplina);
                if (disciplina == null)
                    return new ProfessorResponse("Disciplina not found");

                var usuario = await _usuarioRepository.FindByIdAsync(professor.Login);
                if (usuario == null)
                    return new ProfessorResponse("Usuario not found");

                await _professorRepository.AddAsync(professor);
                await _unitOfWork.CompleteAsync();

                return new ProfessorResponse(professor);
            }
            catch (Exception e)
            {
                return new ProfessorResponse($"An error occurred when saving the professor: {e.Message}");
            }
        }

        public async Task<ProfessorResponse> UpdateAsync(int id, Professor professor)
        {
            var exist = await _professorRepository.FindByIdAsync(id);

            if (exist == null)
                return new ProfessorResponse("Professor not found");

            exist.IdDisciplina = professor.IdDisciplina;
            exist.Login = professor.Login;

            try
            {
                var disciplina = await _disciplinaRepository.FindByIdAsync(exist.IdDisciplina);
                if (disciplina == null)
                    return new ProfessorResponse("Disciplina not found");

                var usuario = await _usuarioRepository.FindByIdAsync(exist.Login);
                if (usuario == null)
                    return new ProfessorResponse("Usuario not found");

                _professorRepository.Update(exist);
                await _unitOfWork.CompleteAsync();

                return new ProfessorResponse(exist);
            }
            catch (Exception e)
            {
                return new ProfessorResponse($"An error occurred when updating the professor: {e.Message}");
            }
        }
    }
}
