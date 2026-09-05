using System;
using System.Collections.Generic;
using System.Text;
using Eventos.Entities.DTO;

namespace Eventos.BL.Interfaces
{
    public interface IOrganizadorService
    {
        Task<IEnumerable<OrganizadorDto>> GetAllAsync();

        Task<OrganizadorDto?> GetByIdAsync(int id);

        Task<OrganizadorDto?> InsertAsync(
            OrganizadorDto organizador);

        Task<OrganizadorDto?> UpdateAsync(
            int id,
            OrganizadorDto organizador);

        Task<bool> DeleteAsync(int id);
    }
}
