using Eventos.BL.Interfaces;
using Eventos.Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Desafio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipanteController : ControllerBase
    {
        private readonly IParticipanteService _participanteService;

        public ParticipanteController(
            IParticipanteService participanteService)
        {
            _participanteService = participanteService;
        }

        // GET: api/Participante
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result =
                await _participanteService.GetAllAsync();

            return Ok(result);
        }

        // GET: api/Participante/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var result =
                await _participanteService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Participante
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] ParticipanteDto participanteDto)
        {
            var result =
                await _participanteService.InsertAsync(
                    participanteDto
                );

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

        // PUT: api/Participante/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] ParticipanteDto participanteDto)
        {
            var result =
                await _participanteService.UpdateAsync(
                    id,
                    participanteDto
                );

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // DELETE: api/Participante/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result =
                await _participanteService.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
