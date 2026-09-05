using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Eventos.Entities.Models;

namespace Eventos.DAL.Interfaces
{
    public interface IEventoRepository
    {
        Task<IEnumerable<Evento>> GetAllAsync();

        Task<Evento?> GetByIdAsync(int id);

        Task<int> InsertAsync(Evento evento);

        Task<int> UpdateAsync(Evento evento);

        Task<int> DeleteAsync(int id);
    }
}
