using Dapper;
using Sequel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Heaven.Data
{
    public partial class DbSession : DbContext, IDbSession
    {
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await Connection.QueryAsync<T>(sql, param, Transaction, commandTimeout, commandType);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, Type[] types, Func<object[], T> map,
            object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return await Connection.QueryAsync(sql, types, map, param, Transaction, buffered, splitOn, commandTimeout, commandType);
        }

        public async Task<T> QueryFirstAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await Connection.QueryFirstAsync<T>(sql, param, Transaction, commandTimeout, commandType);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await Connection.QueryFirstOrDefaultAsync<T>(sql, param, Transaction, commandTimeout, commandType);
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await Connection.QuerySingleAsync<T>(sql, param, Transaction, commandTimeout, commandType);
        }

        public async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await Connection.QuerySingleOrDefaultAsync<T>(sql, param, Transaction, commandTimeout, commandType);
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await Connection.ExecuteAsync(sql, param, Transaction, commandTimeout, commandType);
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await Connection.ExecuteScalarAsync<T>(sql, param, Transaction, commandTimeout, commandType);
        }

        public async Task<DataTable> ExecuteReaderAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var result = new DataTable();

            result.Load(await Connection.ExecuteReaderAsync(sql, param, Transaction, commandTimeout, commandType));

            return result;
        }
    }
}
