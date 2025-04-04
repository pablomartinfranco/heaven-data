using Dapper;
using Sequel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Heaven.Data
{
    public partial class Sql : ISql
    {
        private static void TraceQuery(string statement, object parameters = null)
        {
            Trace.WriteLine($"\n{statement}");
            Trace.WriteLineIf(parameters != null, parameters);
        }

        private static string Unparameterize(string statement, object parameters)
        {
            return "";
        }

        /// <inheritdoc cref = "SqlMapper.QueryAsync" />
        public async Task<IEnumerable<T>> QueryAsync<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            return await connection.QueryAsync<T>(statement, parameters, transaction, commandTimeout, commandType);
        }

        /// <inheritdoc cref = "SqlMapper.QueryAsync" />
        public async Task<IEnumerable<T>> QueryAsync<T>(Type[] types, Func<object[], T> map,
            object parameters = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            return await connection.QueryAsync(statement, types, map, parameters, transaction, buffered, splitOn, commandTimeout, commandType);
        }

        /// <inheritdoc cref = "SqlMapper.QueryFirstAsync" />
        public async Task<T> QueryFirstAsync<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            return await connection.QueryFirstAsync<T>(statement, parameters, transaction, commandTimeout, commandType);
        }

        /// <inheritdoc cref = "SqlMapper.QueryFirstOrDefaultAsync" />
        public async Task<T> QueryFirstOrDefaultAsync<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            return await connection.QueryFirstOrDefaultAsync<T>(statement, parameters, transaction, commandTimeout, commandType);
        }

        /// <inheritdoc cref = "SqlMapper.QuerySingleAsync" />
        public async Task<T> QuerySingleAsync<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            return await connection.QuerySingleAsync<T>(statement, parameters, transaction, commandTimeout, commandType);
        }

        /// <inheritdoc cref = "SqlMapper.QuerySingleOrDefaultAsync" />
        public async Task<T> QuerySingleOrDefaultAsync<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            return await connection.QuerySingleOrDefaultAsync<T>(statement, parameters, transaction, commandTimeout, commandType);
        }

        /// <inheritdoc cref = "SqlMapper.ExecuteAsync" />
        public async Task<int> ExecuteAsync(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            return await connection.ExecuteAsync(statement, parameters, transaction, commandTimeout, commandType);
        }

        /// <inheritdoc cref = "SqlMapper.ExecuteScalarAsync" />
        public async Task<T> ExecuteScalarAsync<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            return await connection.ExecuteScalarAsync<T>(statement, parameters, transaction, commandTimeout, commandType);
        }

        /// <inheritdoc cref = "SqlCommand.ExecuteNonQueryAsync" />
        public async Task<int> ExecuteNonQueryAsync()
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement);

            sqlBuilder = new SqlBuilder();
            using var connection = (SqlConnection)OpenConnectionAsync();
            using var command = new SqlCommand(statement, connection);
            return await command.ExecuteNonQueryAsync();
        }

        /// <inheritdoc cref = "SqlCommand.ExecuteNonQueryAsync" />
        public async Task<int> ExecuteNonQueryAsync(SqlTransaction transaction)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction.Connection;
            using var command = new SqlCommand(statement, connection, transaction);
            return await command.ExecuteNonQueryAsync();
        }

        /// <inheritdoc cref = "SqlMapper.ExecuteReaderAsync" />
        public async Task<DataTable> ExecuteReaderAsync(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var result = new DataTable();
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            result.Load(await connection.ExecuteReaderAsync(statement, parameters, transaction, commandTimeout, commandType));
            return result;
        }
    }
}
