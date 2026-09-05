using Microsoft.AspNetCore.Mvc;
using Eventos.BL.Interfaces;
using Eventos.Entities.DTO;

namespace Desafio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        // GET: api/Evento
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _eventoService.GetAllAsync();

            return Ok(result);
        }

        // GET: api/Evento/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _eventoService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Evento
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] EventoDto eventoDto)
        {
            var result = await _eventoService.InsertAsync(eventoDto);

            if (result == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Codigo },
                result
            );
        }

        // PUT: api/Evento/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] EventoDto eventoDto)
        {
            var result =
                await _eventoService.UpdateAsync(id, eventoDto);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // DELETE: api/Evento/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _eventoService.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
