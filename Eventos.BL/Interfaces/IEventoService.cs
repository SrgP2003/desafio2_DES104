using System;
using System.Collections.Generic;
using System.Text;
using Eventos.Entities.DTO;

namespace Eventos.BL.Interfaces
{
    public interface IEventoService
    {
        Task<IEnumerable<EventoDto>> GetAllAsync();

        Task<EventoDto?> GetByIdAsync(int id);

        Task<EventoDto?> InsertAsync(EventoDto evento);

        Task<EventoDto?> UpdateAsync(int id, EventoDto evento);

        Task<bool> DeleteAsync(int id);
    }
}
