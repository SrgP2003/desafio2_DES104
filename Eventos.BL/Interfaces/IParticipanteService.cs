using System;
using System.Collections.Generic;
using System.Text;
using Eventos.Entities.DTO;

namespace Eventos.BL.Interfaces
{
    public interface IParticipanteService
    {
        Task<IEnumerable<ParticipanteDto>> GetAllAsync();

        Task<ParticipanteDto?> GetByIdAsync(int id);

        Task<ParticipanteDto?> InsertAsync(
            ParticipanteDto participante);

        Task<ParticipanteDto?> UpdateAsync(
            int id,
            ParticipanteDto participante);

        Task<bool> DeleteAsync(int id);
    }
}
