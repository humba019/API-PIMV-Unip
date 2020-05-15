﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIpimv_unip.Models;
using APIpimv_unip.Services;
using AutoMapper;
using APIpimv_unip.Resources;
using APIpimv_unip.Extensions;

namespace APIpimv_unip.Controllers
{
    [Route("unip/pim5/equipamento")]
    public class EquipamentosController : Controller
    {
        private readonly IEquipamentoService _equipamentoService;
        private readonly IMapper _mapper;

        public EquipamentosController(IEquipamentoService equipamentoService, IMapper mapper)
        {
            _equipamentoService = equipamentoService;
            _mapper = mapper;
        }

        // GET: unip/pim5/equipamento
        [HttpGet]
        public async Task<IEnumerable<EquipamentoResource>> ListAsync()
        {
            var equipamentos = await _equipamentoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Equipamento>, IEnumerable<EquipamentoResource>>(equipamentos);

            return resources;
        }
        /*
        // GET: unip/pim5/equipamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<equipamento>> Getequipamento(long id)
        {
            var equipamento = await _context.equipamentos.FindAsync(id);

            if (equipamento == null)
            {
                return NotFound();
            }

            return equipamento;
        }
        */

        // PUT: unip/pim5/equipamento/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEquipamentoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var equipamento = _mapper.Map<SaveEquipamentoResource, Equipamento>(resource);
            var result = await _equipamentoService.UpdateAsync(id, equipamento);

            if (!result.Success)
                return BadRequest(result.Message);

            var equipamentoResource = _mapper.Map<Equipamento, EquipamentoResource>(result.Equipamento);
            return Ok(equipamentoResource);

        }

        // POST: unip/pim5/equipamento
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveEquipamentoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var equipamento = _mapper.Map<SaveEquipamentoResource, Equipamento>(resource);
            var result = await _equipamentoService.SaveAsync(equipamento);

            if (!result.Success)
                return BadRequest(result.Message);

            var equipamentoResource = _mapper.Map<Equipamento, EquipamentoResource>(result.Equipamento);
            return Ok(equipamentoResource);

        }

        // DELETE: unip/pim5/equipamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _equipamentoService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var equipamentoResource = _mapper.Map<Equipamento, EquipamentoResource>(result.Equipamento);
            return Ok(equipamentoResource);
        }

    }
}
