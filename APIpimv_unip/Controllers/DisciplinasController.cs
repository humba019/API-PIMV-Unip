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
    [Route("unip/pim5/disciplina")]
    public class DisciplinasController : Controller
    {
        private readonly IDisciplinaService _disciplinaService;
        private readonly IMapper _mapper;

        public DisciplinasController(IDisciplinaService disciplinaService, IMapper mapper)
        {
            _disciplinaService = disciplinaService;
            _mapper = mapper;
        }


        // GET: unip/pim5/disciplina
        [HttpGet]
        public async Task<IEnumerable<DisciplinaResource>> GetAllAsync()
        {
            var disciplinas = await _disciplinaService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Disciplina>, IEnumerable<DisciplinaResource>>(disciplinas);

            return resources;
        }

        // POST: unip/pim5/disciplina
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDisciplinaResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var disciplina = _mapper.Map<SaveDisciplinaResource, Disciplina>(resource);
            var result = await _disciplinaService.SaveAsync(disciplina);

            if (!result.Success)
                return BadRequest(result.Message);

            var disciplinaResource = _mapper.Map<Disciplina, DisciplinaResource>(result.Disciplina);
            return Ok(disciplinaResource);

        }
        // PUT: unip/pim5/disciplina/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDisciplinaResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var disciplina = _mapper.Map<SaveDisciplinaResource, Disciplina>(resource);
            var result = await _disciplinaService.UpdateAsync(id, disciplina);

            if (!result.Success)
                return BadRequest(result.Message);

            var disciplinaResource = _mapper.Map<Disciplina, DisciplinaResource>(result.Disciplina);
            return Ok(disciplinaResource);

        }

        // DELETE: unip/pim5/disciplina/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _disciplinaService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var disciplinaResource = _mapper.Map<Disciplina, DisciplinaResource>(result.Disciplina);
            return Ok(disciplinaResource);
        }
    }
}
