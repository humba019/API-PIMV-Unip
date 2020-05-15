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
    [Route("unip/pim5/professor")]
    public class ProfessoresController : Controller
    {
        private readonly IProfessorService _professorService;
        private readonly IMapper _mapper;

        public ProfessoresController(IProfessorService professorService, IMapper mapper)
        {
            _professorService = professorService;
            _mapper = mapper;
        }


        // GET: unip/pim5/professor
        [HttpGet]
        public async Task<IEnumerable<ProfessorResource>> GetAllAsync()
        {
            var professores = await _professorService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Professor>, IEnumerable<ProfessorResource>>(professores);

            return resources;
        }

        // POST: unip/pim5/professor
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProfessorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var professor = _mapper.Map<SaveProfessorResource, Professor>(resource);
            var result = await _professorService.SaveAsync(professor);

            if (!result.Success)
                return BadRequest(result.Message);

            var professorResource = _mapper.Map<Professor, ProfessorResource>(result.Professor);
            return Ok(professorResource);

        }
        // PUT: unip/pim5/professor/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProfessorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var professor = _mapper.Map<SaveProfessorResource, Professor>(resource);
            var result = await _professorService.UpdateAsync(id, professor);

            if (!result.Success)
                return BadRequest(result.Message);

            var professorResource = _mapper.Map<Professor, ProfessorResource>(result.Professor);
            return Ok(professorResource);

        }

        // DELETE: unip/pim5/professor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _professorService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var professorResource = _mapper.Map<Professor, ProfessorResource>(result.Professor);
            return Ok(professorResource);
        }
    }
}
