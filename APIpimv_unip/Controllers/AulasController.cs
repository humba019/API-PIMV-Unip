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
    [Route("unip/pim5/aula")]
    public class AulasController : Controller
    {
        private readonly IAulaService _aulaService;
        private readonly IMapper _mapper;

        public AulasController(IAulaService aulaService, IMapper mapper)
        {
            _aulaService = aulaService;
            _mapper = mapper;
        }

        // GET: unip/pim5/aula
        [HttpGet]
        public async Task<IEnumerable<AulaResource>> GetAllAsync()
        {
            var aulas = await _aulaService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Aula>, IEnumerable<AulaResource>>(aulas);

            return resources;
        }

        // POST: unip/pim5/aula
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAulaResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var aula = _mapper.Map<SaveAulaResource, Aula>(resource);
            var result = await _aulaService.SaveAsync(aula);

            if (!result.Success)
                return BadRequest(result.Message);

            var aulaResource = _mapper.Map<Aula, AulaResource>(result.Aula);
            return Ok(aulaResource);

        }
        // PUT: unip/pim5/aula/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAulaResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var aula = _mapper.Map<SaveAulaResource, Aula>(resource);
            var result = await _aulaService.UpdateAsync(id, aula);

            if (!result.Success)
                return BadRequest(result.Message);

            var aulaResource = _mapper.Map<Aula, AulaResource>(result.Aula);
            return Ok(aulaResource);

        }

        // DELETE: unip/pim5/aula/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _aulaService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var aulaResource = _mapper.Map<Aula, AulaResource>(result.Aula);
            return Ok(aulaResource);
        }
    }
}
