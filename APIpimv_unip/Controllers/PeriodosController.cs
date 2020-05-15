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
    [Route("unip/pim5/periodo")]
    public class PeriodosController : Controller
    {
        private readonly IPeriodoService _periodoService;
        private readonly IMapper _mapper;

        public PeriodosController(IPeriodoService periodoService, IMapper mapper)
        {
            _periodoService = periodoService;
            _mapper = mapper;
        }


        // GET: unip/pim5/periodo
        [HttpGet]
        public async Task<IEnumerable<PeriodoResource>> GetAllAsync()
        {
            var periodos = await _periodoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Periodo>, IEnumerable<PeriodoResource>>(periodos);

            return resources;
        }

        // POST: unip/pim5/periodo
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePeriodoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var periodo = _mapper.Map<SavePeriodoResource, Periodo>(resource);
            var result = await _periodoService.SaveAsync(periodo);

            if (!result.Success)
                return BadRequest(result.Message);

            var periodoResource = _mapper.Map<Periodo, PeriodoResource>(result.Periodo);
            return Ok(periodoResource);

        }
        // PUT: unip/pim5/periodo/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePeriodoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var periodo = _mapper.Map<SavePeriodoResource, Periodo>(resource);
            var result = await _periodoService.UpdateAsync(id, periodo);

            if (!result.Success)
                return BadRequest(result.Message);

            var periodoResource = _mapper.Map<Periodo, PeriodoResource>(result.Periodo);
            return Ok(periodoResource);

        }

        // DELETE: unip/pim5/periodo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _periodoService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var periodoResource = _mapper.Map<Periodo, PeriodoResource>(result.Periodo);
            return Ok(periodoResource);
        }
    }
}
