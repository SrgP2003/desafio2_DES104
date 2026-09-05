using System;
using System.Collections.Generic;
using System.Text;
using Eventos.Entities.Models;

namespace Eventos.DAL.Interfaces
{
    internal interface IParticipanteRepository
    {

        Task<IEnumerable<Participante>> GetAllAsync();

        Task<Participante?> GetByIdAsync(int id);

        Task<int> InsertAsync(Participante participante);

        Task<int> UpdateAsync(Participante participante);

        Task<int> DeleteAsync(int id);
    }
}
