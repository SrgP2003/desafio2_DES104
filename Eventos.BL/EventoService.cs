using AutoMapper;
using Eventos.BL.Interfaces;
using Eventos.DAL.Interfaces;
using Eventos.Entities.DTO;
using Eventos.Entities.Models;
using Microsoft.Extensions.Logging;

namespace Eventos.BL
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IMapper _mapper;

        public EventoService(
            IEventoRepository eventoRepository,
            IMapper mapper)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventoDto>> GetAllAsync()
        {
            var eventos = await _eventoRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<EventoDto>>(eventos);
        }

        public async Task<EventoDto?> GetByIdAsync(int id)
        {
            var evento = await _eventoRepository.GetByIdAsync(id);

            if (evento == null)
            {
                return null;
            }

            return _mapper.Map<EventoDto>(evento);
        }

        public async Task<EventoDto?> InsertAsync(EventoDto eventoDto)
        {
            var evento = _mapper.Map<Evento>(eventoDto);

            var id = await _eventoRepository.InsertAsync(evento);

            if (id <= 0)
            {
                return null;
            }

            evento.Id = id;

            return _mapper.Map<EventoDto>(evento);
        }

        public async Task<EventoDto?> UpdateAsync(
            int id,
            EventoDto eventoDto)
        {
            var existente = await _eventoRepository.GetByIdAsync(id);

            if (existente == null)
            {
                return null;
            }

            var evento = _mapper.Map<Evento>(eventoDto);

            evento.Id = id;

            var affectedRows =
                await _eventoRepository.UpdateAsync(evento);

            if (affectedRows <= 0)
            {
                return null;
            }

            return _mapper.Map<EventoDto>(evento);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existente = await _eventoRepository.GetByIdAsync(id);

            if (existente == null)
            {
                return false;
            }

            var affectedRows =
                await _eventoRepository.DeleteAsync(id);

            return affectedRows > 0;
        }
    }
}