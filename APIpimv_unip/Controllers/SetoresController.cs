using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIpimv_unip.Models;
using APIpimv_unip.Services;
using AutoMapper;
using APIpimv_unip.Resources;
using APIpimv_unip.Extensions;

namespace APIpimv_unip.Controllers
{
    [Route("unip/pim5/setor")]
    public class SetoresController : Controller
    {
        private readonly ISetorService _setorService;
        private readonly IMapper _mapper;

        public SetoresController(ISetorService setorService, IMapper mapper)
        {        
            _setorService = setorService;
            _mapper = mapper; 
        }

        // GET: unip/pim5/setor
        [HttpGet]
        public async Task<IEnumerable<SetorResource>> GetAllAsync()
        {
            var setores = await _setorService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Setor>, IEnumerable< SetorResource >> (setores);
                
            return resources;
        }

        // POST: unip/pim5/setor
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SetorResource>> PostAsync([FromBody] SaveSetorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var setor = _mapper.Map<SaveSetorResource, Setor>(resource);
            var result = await _setorService.SaveAsync(setor);

            if (!result.Success)
                return BadRequest(result.Message);

            var setorResource = _mapper.Map<Setor, SetorResource>(result.Setor);
            return Ok(setorResource);

        }
        // PUT: unip/pim5/setor/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<SetorResource>> PutAsync(int id, [FromBody] SaveSetorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var setor = _mapper.Map<SaveSetorResource, Setor>(resource);
            var result = await _setorService.UpdateAsync(id, setor);

            if (!result.Success)
                return BadRequest(result.Message);

            var setorResource = _mapper.Map<Setor, SetorResource>(result.Setor);
            return Ok(setorResource);

        }

        // DELETE: unip/pim5/setor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SetorResource>> DeleteAsync(int id)
        {
            var result = await _setorService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var setorResource = _mapper.Map<Setor, SetorResource>(result.Setor);
            return Ok(setorResource);
        }
        /*
        // GET: unip/pim5/setor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Setor>> GetSetor(long id)
        {
            var setor = await _context.Setores.FindAsync(id);

            if (setor == null)
            {
                return NotFound();
            }

            return setor;
        }
        */
    }
}
