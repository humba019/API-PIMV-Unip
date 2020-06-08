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
    [Route("unip/pim5/emprestimo")]
    public class EmprestimosController : Controller
    {
        private readonly IEmprestimoService _emprestimoService;
        private readonly IMapper _mapper;

        public EmprestimosController(IEmprestimoService emprestimoService, IMapper mapper)
        {
            _emprestimoService = emprestimoService;
            _mapper = mapper;
        }



        // GET: unip/pim5/emprestimo
        [HttpGet]
        public async Task<IEnumerable<EmprestimoResource>> GetAllAsync()
        {
            var emprestimos = await _emprestimoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Emprestimo>, IEnumerable<EmprestimoResource>>(emprestimos);

            return resources;
        }

        // POST: unip/pim5/emprestimo
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EmprestimoResource>> PostAsync([FromBody] SaveEmprestimoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var emprestimo = _mapper.Map<SaveEmprestimoResource, Emprestimo>(resource);
            var result = await _emprestimoService.SaveAsync(emprestimo);

            if (!result.Success)
                return BadRequest(result.Message);

            var emprestimoResource = _mapper.Map<Emprestimo, EmprestimoResource>(result.Emprestimo);
            return Ok(emprestimoResource);

        }
        // PUT: unip/pim5/emprestimo/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<EmprestimoResource>> PutAsync(int id, [FromBody] SaveEmprestimoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var emprestimo = _mapper.Map<SaveEmprestimoResource, Emprestimo>(resource);
            var result = await _emprestimoService.UpdateAsync(id, emprestimo);

            if (!result.Success)
                return BadRequest(result.Message);

            var emprestimoResource = _mapper.Map<Emprestimo, EmprestimoResource>(result.Emprestimo);
            return Ok(emprestimoResource);

        }

        // DELETE: unip/pim5/emprestimo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmprestimoResource>> DeleteAsync(int id)
        {
            var result = await _emprestimoService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var emprestimoResource = _mapper.Map<Emprestimo, EmprestimoResource>(result.Emprestimo);
            return Ok(emprestimoResource);
        }
    }
}
