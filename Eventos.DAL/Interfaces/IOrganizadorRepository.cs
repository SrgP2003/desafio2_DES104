using System;
using System.Collections.Generic;
using System.Text;
using Eventos.Entities.Models;

namespace Eventos.DAL.Interfaces
{
    internal interface IOrganizadorRepository
    {
        Task<IEnumerable<Organizador>> GetAllAsync();

        Task<Organizador?> GetByIdAsync(int id);

        Task<int> InsertAsync(Organizador organizador);

        Task<int> UpdateAsync(Organizador organizador);

        Task<int> DeleteAsync(int id);
    }
}
