using System;
using System.Collections.Generic;
using System.Text;
using Eventos.DAL.Interfaces;
using Eventos.Entities.Models;

namespace Eventos.DAL
{
    internal class OrganizadorRepository : IOrganizadorRepository
    {
        private readonly IDatabaseRepository _databaseRepository;

        public OrganizadorRepository(
            IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public async Task<IEnumerable<Organizador>> GetAllAsync()
        {
            const string sql = """
                SELECT
                    Id,
                    Nombre,
                    Cargo,
                    EventoId
                FROM Organizadores
                ORDER BY Id;
                """;

            return await _databaseRepository
                .QueryAsync<Organizador>(sql);
        }

        public async Task<Organizador?> GetByIdAsync(int id)
        {
            const string sql = """
                SELECT
                    Id,
                    Nombre,
                    Cargo,
                    EventoId
                FROM Organizadores
                WHERE Id = @Id;
                """;

            return await _databaseRepository
                .QueryFirstOrDefaultAsync<Organizador>(
                    sql,
                    new { Id = id }
                );
        }

        public async Task<int> InsertAsync(
            Organizador organizador)
        {
            const string sql = """
                INSERT INTO Organizadores
                (
                    Nombre,
                    Cargo,
                    EventoId
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @Nombre,
                    @Cargo,
                    @EventoId
                );
                """;

            var id = await _databaseRepository
                .ExecuteScalarAsync<int>(
                    sql,
                    organizador
                );

            return id;
        }

        public async Task<int> UpdateAsync(
            Organizador organizador)
        {
            const string sql = """
                UPDATE Organizadores
                SET
                    Nombre = @Nombre,
                    Cargo = @Cargo,
                    EventoId = @EventoId
                WHERE Id = @Id;
                """;

            return await _databaseRepository
                .ExecuteAsync(
                    sql,
                    organizador
                );
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string sql = """
                DELETE FROM Organizadores
                WHERE Id = @Id;
                """;

            return await _databaseRepository
                .ExecuteAsync(
                    sql,
                    new { Id = id }
                );
        }
    }
}