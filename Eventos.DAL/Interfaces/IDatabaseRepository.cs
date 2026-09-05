using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Eventos.DAL.Interfaces
{
    internal interface IDatabaseRepository
    {
        Task<IEnumerable<T>> QueryAsync<T>(
           string sql,
           object? parameters = null,
           IDbTransaction? transaction = null
       );

        Task<T?> QueryFirstOrDefaultAsync<T>(
            string sql,
            object? parameters = null,
            IDbTransaction? transaction = null
        );

        Task<int> ExecuteAsync(
            string sql,
            object? parameters = null,
            IDbTransaction? transaction = null
        );

        Task<T?> ExecuteScalarAsync<T>(
            string sql,
            object? parameters = null,
            IDbTransaction? transaction = null
        );
    }
}
