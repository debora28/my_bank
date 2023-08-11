﻿using Microsoft.AspNetCore.Mvc;
using MyLastApi.Repositories;
using MyLastApi.Model;

namespace MyLastApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuarioController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        //GETALL 
        [HttpGet]
        public async Task<IEnumerable<Usuario>> GetAll()
        {
            var usuarios = await _usuariosRepository.GetUsuarios();
            if (usuarios == null)
            {
                return (IEnumerable<Usuario>)NotFound("Não há registros.");
            }
            else
            {
                return usuarios;
            }
        }

        //GETONE
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetOne(int id)
        {
            var usuario = await _usuariosRepository.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound(new { message = $"Usuário de id={id} não encontrado." });
            }
            else
            {
                return usuario;
            }
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            if (usuario == null) { return BadRequest(); }
            else
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    try
                    {
                        var usuarioNovo = await _usuariosRepository.CreateUsuario(usuario);
                        return CreatedAtAction(nameof(GetAll), new { id = usuarioNovo.Id }, usuarioNovo);
                    }
                    catch
                    {
                        return BadRequest(new { message = "Falha inesperada." });
                    }
                }
            }
        }

        //PUT
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null) { return NotFound(); }
            else
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    try
                    {
                        if (id == usuario.Id)
                        {
                            await _usuariosRepository.UpdateUsuario(usuario);
                            return Ok();
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }
                    catch
                    {
                        return BadRequest();
                    }
                }
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
                try
                {
                    if (id == usuario.Id)
                    {
                        await _usuariosRepository.DeleteUsuario(usuario.Id);
                        return Ok();
                    }
                    else
                    {
                        return NotFound(new { message = $"Usuário de id={id} não encontrado." });
                    }
                }
                catch
                {
                    return BadRequest();
                }
                
            }
        }
    }
}
