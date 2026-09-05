using Eventos.BL.Interfaces;
using Eventos.Entities.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Desafio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrganizadorController : ControllerBase
    {
        private readonly IOrganizadorService _organizadorService;

        public OrganizadorController(
            IOrganizadorService organizadorService)
        {
            _organizadorService = organizadorService;
        }

        // GET: api/Organizador
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result =
                await _organizadorService.GetAllAsync();

            return Ok(result);
        }

        // GET: api/Organizador/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var result =
                await _organizadorService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Organizador
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] OrganizadorDto organizadorDto)
        {
            var result =
                await _organizadorService.InsertAsync(
                    organizadorDto
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

        // PUT: api/Organizador/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] OrganizadorDto organizadorDto)
        {
            var result =
                await _organizadorService.UpdateAsync(
                    id,
                    organizadorDto
                );

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // DELETE: api/Organizador/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result =
                await _organizadorService.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
