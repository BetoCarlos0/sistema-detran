using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema.Detran.Domain;
using System;

namespace Sistema.Detran.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IVeiculoDetran _veiculoDetran;

        public VeiculosController(IVeiculoRepository veiculoRepository, IVeiculoDetran veiculoDetran)
        {
            _veiculoRepository = veiculoRepository;
            _veiculoDetran = veiculoDetran;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_veiculoRepository.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var veiculo = _veiculoRepository.GetVeiculo(id);

            if(veiculo == null)
                    return NotFound();
            return Ok(veiculo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Veiculo veiculo)
        {
            _veiculoRepository.Add(veiculo);
            return CreatedAtAction(nameof(Get), new { id = veiculo.Id }, veiculo);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Veiculo veiculo)
        {
            _veiculoRepository.Update(veiculo);

            return NoContent();
        }
        
        [HttpPut("{id}/vistoria")]
        public IActionResult Put(Guid id)
        {
            _veiculoDetran.AgendaVistoria(id);

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var veiculo = _veiculoRepository.GetVeiculo(id);
            if (veiculo == null)
                return NotFound();

            _veiculoRepository.Delete(veiculo);

            return NoContent();
        }
    }
}
