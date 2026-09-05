using AutoMapper;
using Eventos.BL.Interfaces;
using Eventos.DAL.Interfaces;
using Eventos.Entities.DTO;
using Eventos.Entities.Models;

namespace Eventos.BL
{
    public class ParticipanteService : IParticipanteService
    {
        private readonly IParticipanteRepository
            _participanteRepository;

        private readonly IMapper _mapper;

        public ParticipanteService(
            IParticipanteRepository participanteRepository,
            IMapper mapper)
        {
            _participanteRepository = participanteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParticipanteDto>> GetAllAsync()
        {
            var participantes =
                await _participanteRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ParticipanteDto>>(
                participantes
            );
        }

        public async Task<ParticipanteDto?> GetByIdAsync(int id)
        {
            var participante =
                await _participanteRepository.GetByIdAsync(id);

            if (participante == null)
            {
                return null;
            }

            return _mapper.Map<ParticipanteDto>(participante);
        }

        public async Task<ParticipanteDto?> InsertAsync(
            ParticipanteDto participanteDto)
        {
            var participante =
                _mapper.Map<Participante>(participanteDto);

            var id =
                await _participanteRepository.InsertAsync(
                    participante
                );

            if (id <= 0)
            {
                return null;
            }

            participante.Id = id;

            return _mapper.Map<ParticipanteDto>(
                participante
            );
        }

        public async Task<ParticipanteDto?> UpdateAsync(
            int id,
            ParticipanteDto participanteDto)
        {
            var existente =
                await _participanteRepository.GetByIdAsync(id);

            if (existente == null)
            {
                return null;
            }

            var participante =
                _mapper.Map<Participante>(participanteDto);

            participante.Id = id;

            var affectedRows =
                await _participanteRepository.UpdateAsync(
                    participante
                );

            if (affectedRows <= 0)
            {
                return null;
            }

            return _mapper.Map<ParticipanteDto>(
                participante
            );
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existente =
                await _participanteRepository.GetByIdAsync(id);

            if (existente == null)
            {
                return false;
            }

            var affectedRows =
                await _participanteRepository.DeleteAsync(id);

            return affectedRows > 0;
        }
    }
}