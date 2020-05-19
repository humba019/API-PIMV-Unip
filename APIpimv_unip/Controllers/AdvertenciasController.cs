using APIpimv_unip.Extensions;
using APIpimv_unip.Models;
using APIpimv_unip.Resources;
using APIpimv_unip.Resources.Entity;
using APIpimv_unip.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIpimv_unip.Controllers
{
    [Route("unip/pim5/advertencia")]
    public class AdvertenciasController : Controller
    {
        private readonly IAdvertenciaService _advertenciaService;
        private readonly IMapper _mapper;

        public AdvertenciasController(IAdvertenciaService advertenciaService, IMapper mapper)
        {
            _advertenciaService = advertenciaService;
            _mapper = mapper;
        }

        // GET: unip/pim5/advertencia
        [HttpGet]
        public async Task<IEnumerable<AdvertenciaResource>> GetAllAsync()
        {
            var advertencias = await _advertenciaService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Advertencia>, IEnumerable<AdvertenciaResource>>(advertencias);

            return resources;
        }

        // POST: unip/pim5/advertencia
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AdvertenciaResource>> PostAsync([FromBody] SaveAdvertenciaResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var advertencia = _mapper.Map<SaveAdvertenciaResource, Advertencia>(resource);
            var result = await _advertenciaService.SaveAsync(advertencia);

            var advertenciaResource = _mapper.Map<Advertencia, AdvertenciaResource>(result.Advertencia);

            return Ok(advertenciaResource);

        }
        // PUT: unip/pim5/advertencia/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAdvertenciaResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var advertencia = _mapper.Map<SaveAdvertenciaResource, Advertencia>(resource);
            var result = await _advertenciaService.UpdateAsync(id, advertencia);

            if (!result.Success)
                return BadRequest(result.Message);

            var advertenciaResource = _mapper.Map<Advertencia, AdvertenciaResource>(result.Advertencia);
            return Ok(advertenciaResource);

        }

        // DELETE: unip/pim5/advertencia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _advertenciaService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var advertenciaResource = _mapper.Map<Advertencia, AdvertenciaResource>(result.Advertencia);
            return Ok(advertenciaResource);
        }
    }
}
