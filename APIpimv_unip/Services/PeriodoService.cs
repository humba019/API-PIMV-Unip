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
    public class PeriodoService : IPeriodoService
    {
        private readonly IPeriodoRepository _periodoRepository;
        private readonly IUnitOfWork _unitOfWOrk;

        public PeriodoService(IPeriodoRepository periodoRepository, IUnitOfWork unitOfWOrk)
        {
            this._periodoRepository = periodoRepository;
            this._unitOfWOrk = unitOfWOrk;
        }

        public async Task<PeriodoResponse> DeleteAsync(int id)
        {
            var exist = await _periodoRepository.FindByIdAsync(id);

            if (exist == null)
                return new PeriodoResponse("Periodo not found");

            try
            {
                _periodoRepository.Remove(exist);
                await _unitOfWOrk.CompleteAsync();

                return new PeriodoResponse(exist);
            }
            catch (Exception e)
            {
                return new PeriodoResponse($"An error occurred when deleting the periodo: {e.Message}");
            }
        }

        public async Task<IEnumerable<Periodo>> ListAsync()
        {
            return await _periodoRepository.ListAsync();
        }

        public async Task<PeriodoResponse> SaveAsync(Periodo periodo)
        {
            try
            {
                await _periodoRepository.AddAsync(periodo);
                await _unitOfWOrk.CompleteAsync();

                return new PeriodoResponse(periodo);
            }
            catch (Exception e)
            {
                return new PeriodoResponse($"An error occurred when saving the periodo: {e.Message}");
            }
        }

        public async Task<PeriodoResponse> UpdateAsync(int id, Periodo periodo)
        {
            var exist = await _periodoRepository.FindByIdAsync(id);

            if (exist == null)
                return new PeriodoResponse("Periodo not found");

            exist.Descricao = periodo.Descricao;
            exist.HoraInicio = periodo.HoraInicio;
            exist.HoraFim = periodo.HoraFim;
            exist.AtividadePeriodo = periodo.AtividadePeriodo;

            try
            {
                _periodoRepository.Update(exist);
                await _unitOfWOrk.CompleteAsync();

                return new PeriodoResponse(exist);
            }
            catch (Exception e)
            {
                return new PeriodoResponse($"An error occurred when updating the periodo: {e.Message}");
            }
        }
    }
}
