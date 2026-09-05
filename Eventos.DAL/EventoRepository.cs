using Eventos.DAL.Interfaces;
using Eventos.Entities.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.DAL
{
    internal class EventoRepository : IEventoRepository
    {
        private readonly IDatabaseRepository _databaseRepository;

        public EventoRepository(
            IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public async Task<IEnumerable<Evento>> GetAllAsync()
        {
            const string sql = """
                SELECT
                    Id,
                    Nombre,
                    Fecha,
                    Lugar
                FROM Eventos
                ORDER BY Id;
                """;

            return await _databaseRepository
                .QueryAsync<Evento>(sql);
        }

        public async Task<Evento?> GetByIdAsync(int id)
        {
            const string sql = """
                SELECT
                    Id,
                    Nombre,
                    Fecha,
                    Lugar
                FROM Eventos
                WHERE Id = @Id;
                """;

            return await _databaseRepository
                .QueryFirstOrDefaultAsync<Evento>(
                    sql,
                    new { Id = id }
                );
        }

        public async Task<int> InsertAsync(Evento evento)
        {
            const string sql = """
                INSERT INTO Eventos
                (
                    Nombre,
                    Fecha,
                    Lugar
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @Nombre,
                    @Fecha,
                    @Lugar
                );
                """;

            var id = await _databaseRepository
                .ExecuteScalarAsync<int>(
                    sql,
                    evento
                );

            return id;
        }

        public async Task<int> UpdateAsync(Evento evento)
        {
            const string sql = """
                UPDATE Eventos
                SET
                    Nombre = @Nombre,
                    Fecha = @Fecha,
                    Lugar = @Lugar
                WHERE Id = @Id;
                """;

            return await _databaseRepository
                .ExecuteAsync(
                    sql,
                    evento
                );
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string sql = """
                DELETE FROM Eventos
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
