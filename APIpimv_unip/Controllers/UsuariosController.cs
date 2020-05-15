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
    [Route("unip/pim5/usuario")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }


        // GET: unip/pim5/usuario
        [HttpGet]
        public async Task<IEnumerable<UsuarioResource>> GetAllAsync()
        {
            var usuarios = await _usuarioService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioResource>>(usuarios);

            return resources;
        }

        // POST: unip/pim5/usuario
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUsuarioResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var usuario = _mapper.Map<SaveUsuarioResource, Usuario>(resource);
            var result = await _usuarioService.SaveAsync(usuario);

            if (!result.Success)
                return BadRequest(result.Message);

            var usuarioResource = _mapper.Map<Usuario, UsuarioResource>(result.Usuario);
            return Ok(usuarioResource);

        }
        // PUT: unip/pim5/usuario/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{login}")]
        public async Task<IActionResult> PutAsync(string login, [FromBody] SaveUsuarioResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var usuario = _mapper.Map<SaveUsuarioResource, Usuario>(resource);
            var result = await _usuarioService.UpdateAsync(login, usuario);

            if (!result.Success)
                return BadRequest(result.Message);

            var usuarioResource = _mapper.Map<Usuario, UsuarioResource>(result.Usuario);
            return Ok(usuarioResource);

        }

        // DELETE: unip/pim5/usuario/5
        [HttpDelete("{login}")]
        public async Task<IActionResult> DeleteAsync(string login)
        {
            var result = await _usuarioService.DeleteAsync(login);
            if (!result.Success)
                return BadRequest(result.Message);

            var usuarioResource = _mapper.Map<Usuario, UsuarioResource>(result.Usuario);
            return Ok(usuarioResource);
        }
    }
}
