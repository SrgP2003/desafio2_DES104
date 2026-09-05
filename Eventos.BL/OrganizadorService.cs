using AutoMapper;
using Eventos.BL.Interfaces;
using Eventos.DAL.Interfaces;
using Eventos.Entities.DTO;
using Eventos.Entities.Models;

namespace Eventos.BL
{
    public class OrganizadorService : IOrganizadorService
    {
        private readonly IOrganizadorRepository
            _organizadorRepository;

        private readonly IMapper _mapper;

        public OrganizadorService(
            IOrganizadorRepository organizadorRepository,
            IMapper mapper)
        {
            _organizadorRepository = organizadorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrganizadorDto>> GetAllAsync()
        {
            var organizadores =
                await _organizadorRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<OrganizadorDto>>(
                organizadores
            );
        }

        public async Task<OrganizadorDto?> GetByIdAsync(int id)
        {
            var organizador =
                await _organizadorRepository.GetByIdAsync(id);

            if (organizador == null)
            {
                return null;
            }

            return _mapper.Map<OrganizadorDto>(organizador);
        }

        public async Task<OrganizadorDto?> InsertAsync(
            OrganizadorDto organizadorDto)
        {
            var organizador =
                _mapper.Map<Organizador>(organizadorDto);

            var id =
                await _organizadorRepository.InsertAsync(
                    organizador
                );

            if (id <= 0)
            {
                return null;
            }

            organizador.Id = id;

            return _mapper.Map<OrganizadorDto>(
                organizador
            );
        }

        public async Task<OrganizadorDto?> UpdateAsync(
            int id,
            OrganizadorDto organizadorDto)
        {
            var existente =
                await _organizadorRepository.GetByIdAsync(id);

            if (existente == null)
            {
                return null;
            }

            var organizador =
                _mapper.Map<Organizador>(organizadorDto);

            organizador.Id = id;

            var affectedRows =
                await _organizadorRepository.UpdateAsync(
                    organizador
                );

            if (affectedRows <= 0)
            {
                return null;
            }

            return _mapper.Map<OrganizadorDto>(
                organizador
            );
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existente =
                await _organizadorRepository.GetByIdAsync(id);

            if (existente == null)
            {
                return false;
            }

            var affectedRows =
                await _organizadorRepository.DeleteAsync(id);

            return affectedRows > 0;
        }
    }
}