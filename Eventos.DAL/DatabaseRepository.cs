using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Eventos.Common;
using Eventos.DAL.Interfaces;

namespace Eventos.DAL
{
    internal class DatabaseRepository : IDatabaseRepository
    {
        private readonly string _connectionString;

        public DatabaseRepository(IOptions<AppSettings> appSettings)
        {
            _connectionString = appSettings.Value.ConnectionString;
        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(
            string sql,
            object? parameters = null,
            IDbTransaction? transaction = null)
        {
            try
            {
                if (transaction != null)
                {
                    return await transaction.Connection!
                        .QueryAsync<T>(sql, parameters, transaction);
                }

                await using var connection = CreateConnection();

                return await connection.QueryAsync<T>(
                    sql,
                    parameters
                );
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error ejecutando QueryAsync: {ex.Message}",
                    ex
                );
            }
        }

        public async Task<T?> QueryFirstOrDefaultAsync<T>(
            string sql,
            object? parameters = null,
            IDbTransaction? transaction = null)
        {
            try
            {
                if (transaction != null)
                {
                    return await transaction.Connection!
                        .QueryFirstOrDefaultAsync<T>(
                            sql,
                            parameters,
                            transaction
                        );
                }

                await using var connection = CreateConnection();

                return await connection.QueryFirstOrDefaultAsync<T>(
                    sql,
                    parameters
                );
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error ejecutando QueryFirstOrDefaultAsync: {ex.Message}",
                    ex
                );
            }
        }

        public async Task<int> ExecuteAsync(
            string sql,
            object? parameters = null,
            IDbTransaction? transaction = null)
        {
            try
            {
                if (transaction != null)
                {
                    return await transaction.Connection!
                        .ExecuteAsync(
                            sql,
                            parameters,
                            transaction
                        );
                }

                await using var connection = CreateConnection();

                return await connection.ExecuteAsync(
                    sql,
                    parameters
                );
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error ejecutando ExecuteAsync: {ex.Message}",
                    ex
                );
            }
        }

        public async Task<T?> ExecuteScalarAsync<T>(
            string sql,
            object? parameters = null,
            IDbTransaction? transaction = null)
        {
            try
            {
                if (transaction != null)
                {
                    return await transaction.Connection!
                        .ExecuteScalarAsync<T>(
                            sql,
                            parameters,
                            transaction
                        );
                }

                await using var connection = CreateConnection();

                return await connection.ExecuteScalarAsync<T>(
                    sql,
                    parameters
                );
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error ejecutando ExecuteScalarAsync: {ex.Message}",
                    ex
                );
            }
        }
    }
}