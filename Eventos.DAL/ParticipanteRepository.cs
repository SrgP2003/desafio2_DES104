using Eventos.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Eventos.Entities.Models;

namespace Eventos.DAL
{
    internal class ParticipanteRepository : IParticipanteRepository
    {
        private readonly IDatabaseRepository _databaseRepository;

        public ParticipanteRepository(
            IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public async Task<IEnumerable<Participante>> GetAllAsync()
        {
            const string sql = """
                SELECT
                    Id,
                    Nombre,
                    Email,
                    EventoId
                FROM Participantes
                ORDER BY Id;
                """;

            return await _databaseRepository
                .QueryAsync<Participante>(sql);
        }

        public async Task<Participante?> GetByIdAsync(int id)
        {
            const string sql = """
                SELECT
                    Id,
                    Nombre,
                    Email,
                    EventoId
                FROM Participantes
                WHERE Id = @Id;
                """;

            return await _databaseRepository
                .QueryFirstOrDefaultAsync<Participante>(
                    sql,
                    new { Id = id }
                );
        }

        public async Task<int> InsertAsync(
            Participante participante)
        {
            const string sql = """
                INSERT INTO Participantes
                (
                    Nombre,
                    Email,
                    EventoId
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @Nombre,
                    @Email,
                    @EventoId
                );
                """;

            var id = await _databaseRepository
                .ExecuteScalarAsync<int>(
                    sql,
                    participante
                );

            return id;
        }

        public async Task<int> UpdateAsync(
            Participante participante)
        {
            const string sql = """
                UPDATE Participantes
                SET
                    Nombre = @Nombre,
                    Email = @Email,
                    EventoId = @EventoId
                WHERE Id = @Id;
                """;

            return await _databaseRepository
                .ExecuteAsync(
                    sql,
                    participante
                );
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string sql = """
                DELETE FROM Participantes
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