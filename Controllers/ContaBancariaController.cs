using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLastApi.Model;
using MyLastApi.Models;
using MyLastApi.Repositories;

namespace MyLastApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaBancariaController : Controller
    {
        private readonly IContasBancariasRepository _contasBancariasRepository;

        public ContaBancariaController(IContasBancariasRepository contasBancariasRepository)
        {
            _contasBancariasRepository = contasBancariasRepository;
        }

        // GET: ContaBancariaController
        [HttpGet]
        public async Task<IEnumerable<ContaBancaria>> GetAll()
        {
            return await _contasBancariasRepository.GetContas();
        }

        // GET: ContaBancariaController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaBancaria>> GetOne(int id)
        {
            return await _contasBancariasRepository.GetConta(id);
        }

        // GET: ContaBancariaController/Create
        [HttpPost]
        public async Task<ActionResult<ContaBancaria>> Post([FromBody] ContaBancaria conta)
        {
            if (conta == null)
            {
                return BadRequest();
            }
            else
            {
                var contaNova = await _contasBancariasRepository.CreateConta(conta);
                return CreatedAtAction(nameof(GetAll), new {id = contaNova.IdConta }, contaNova);
            }
        }

        [HttpPut]
        // GET: ContaBancariaController/Edit/5
        public async Task<ActionResult> Put(int id, [FromBody] ContaBancaria conta)
        {
            if (id == conta.IdConta)
            {
                await _contasBancariasRepository.UpdateConta(conta);
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE: ContaBancariaController/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var conta = await _contasBancariasRepository.GetConta(id);

            if (conta == null)
            {
                return NotFound();
            }
            else
            {
                await _contasBancariasRepository.DeleteConta(conta.IdConta);
                return NoContent();
            }
        }
    }
}
