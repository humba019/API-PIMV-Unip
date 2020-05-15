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
    public class AdvertenciaService : IAdvertenciaService
    {
        public readonly IAdvertenciaRepository _advertenciaRepository;
        public readonly IUnitOfWork _unitOfWork;

        public AdvertenciaService(IAdvertenciaRepository advertenciaRepository, IUnitOfWork unitOfWork)
        {
            this._advertenciaRepository = advertenciaRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<AdvertenciaResponse> DeleteAsync(int id)
        {
            var exist = await _advertenciaRepository.FindByIdAsync(id);

            if (exist == null)
                return new AdvertenciaResponse("Advertencia not found");

            try
            {
                _advertenciaRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return new AdvertenciaResponse(exist);
            }
            catch (Exception e)
            {
                return new AdvertenciaResponse($"An error occurred when deleting the advertencia: { e.Message }");
            }
        }

        public async Task<IEnumerable<Advertencia>> ListAsync()
        {
            return await _advertenciaRepository.ListAsync();
        }

        public async Task<AdvertenciaResponse> SaveAsync(Advertencia advertencia)
        {
            try
            {
                await _advertenciaRepository.AddAsync(advertencia);
                await _unitOfWork.CompleteAsync();

                return new AdvertenciaResponse(advertencia);
            }
            catch (Exception e) 
            {
                return new AdvertenciaResponse($"An error occurred when saving the advertencia: {e.Message}");
            }
        }

        public async Task<AdvertenciaResponse> UpdateAsync(int id, Advertencia advertencia)
        {
            var exist = await _advertenciaRepository.FindByIdAsync(id);
            if (exist == null)
                return new AdvertenciaResponse("Advertencia not found");

            exist.Descricao = advertencia.Descricao;
            exist.Nivel = advertencia.Nivel;

            try
            {
                _advertenciaRepository.Update(exist);
                await _unitOfWork.CompleteAsync();

                return new AdvertenciaResponse(exist);
            }
            catch (Exception e) {
                return new AdvertenciaResponse($"An error occurred when updating the advertencia: { e.Message }");
            }
        }
    }
}
