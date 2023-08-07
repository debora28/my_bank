using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MyLastApi.Models.Entities.Usuarios;
using MyLastApi.Repositories;
using MyLastApi.Model;
using System;
//using MyLastApi.Services;

namespace MyLastApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;
        //private readonly IValidacaoCpf _validacaoCpf;

        public UsuarioController(IUsuariosRepository usuariosRepository /*, IValidacaoCpf validacaoCpf*/)
        {
            _usuariosRepository = usuariosRepository;
            //_validacaoCpf = validacaoCpf;
        }

        //GETALL 
        [HttpGet]
        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _usuariosRepository.GetUsuarios();
        }

        //GETONE
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetOne(int id)
        {
            return await _usuariosRepository.GetUsuario(id);
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            if (usuario == null) { return BadRequest(); }
            else
            {
                //bool validado = !_validacaoCpf.ValidaCpf(usuario.Cpf);
                //if (validado == true)
                //{
                //    var usuarioNovo = await _usuariosRepository.CreateUsuario(usuario);
                //    return CreatedAtAction(nameof(GetAll), new { id = usuarioNovo.Id }, usuarioNovo);
                //}
                //else
                //{
                //    return BadRequest();
                //}
                var usuarioNovo = await _usuariosRepository.CreateUsuario(usuario);
                return CreatedAtAction(nameof(GetAll), new { id = usuarioNovo.Id }, usuarioNovo);
            }
        }

        //PUT
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] Usuario usuario)
        {
            if (id == usuario.Id)
            {
                await _usuariosRepository.UpdateUsuario(usuario);
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuario = await _usuariosRepository.GetUsuario(id);

            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                await _usuariosRepository.DeleteUsuario(usuario.Id);
                return NoContent();
            }
        }
    }
}
