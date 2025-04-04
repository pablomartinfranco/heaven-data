using Sequel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Heaven.Data
{
    public interface IDbSession : IDbContext
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new();

        Contrib Contrib { get; }

        new IDbConnection Connection { get; }

        new IDbTransaction Transaction { get; }

        //// Dapper

        IEnumerable<T> Query<T>(string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);

        IEnumerable<T> Query<T>(Sql sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);

        IEnumerable<T> Query<T>(string sql, Type[] types, Func<object[], T> map,
            object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        IEnumerable<T> Query<T>(Sql sql, Type[] types, Func<object[], T> map,
            object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        T QueryFirst<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        T QueryFirst<T>(Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        T QueryFirstOrDefault<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        T QueryFirstOrDefault<T>(Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        T QuerySingle<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        
        T QuerySingle<T>(Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        T QuerySingleOrDefault<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        T QuerySingleOrDefault<T>(Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        int Execute(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        int Execute(Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        T ExecuteScalar<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        T ExecuteScalar<T>(Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        DataTable ExecuteReader(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        DataTable ExecuteReader(Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        //// Dapper Async

        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<IEnumerable<T>> QueryAsync<T>(string sql, Type[] types, Func<object[], T> map,
            object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        Task<T> QueryFirstAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<T> QuerySingleAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<T> ExecuteScalarAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<DataTable> ExecuteReaderAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
    }
}
