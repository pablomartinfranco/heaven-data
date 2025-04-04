using Dapper;
using Sequel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Heaven.Data
{
    public partial class Sql : ISql
    {
        /// <inheritdoc cref = "SqlMapper.Query" />
        public IEnumerable<T> Query<T>(object parameters = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            return connection.Query<T>(statement, parameters, transaction, buffered, commandTimeout, commandType);
        }

        /// <inheritdoc cref = "SqlMapper.Query" />
        public IEnumerable<T> Query<T>(Type[] types, Func<object[], T> map,
            object parameters = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            return connection.Query(statement, types, map, parameters, transaction, buffered, splitOn, commandTimeout, commandType);
        }

        /// <inheritdoc cref = "SqlMapper.QueryFirst" />
        public T QueryFirst<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            return connection.QueryFirst<T>(statement, parameters, transaction, commandTimeout, commandType);
        }

        /// <inheritdoc cref = "SqlMapper.QueryFirstOrDefault" />
        public T QueryFirstOrDefault<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            return connection.QueryFirstOrDefault<T>(statement, parameters, transaction, commandTimeout, commandType);
        }

        /// <inheritdoc cref = "SqlMapper.QuerySingle" />
        public T QuerySingle<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            return connection.QuerySingle<T>(statement, parameters, transaction, commandTimeout, commandType);
        }

        /// <inheritdoc cref = "SqlMapper.QuerySingleOrDefault" />
        public T QuerySingleOrDefault<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            return connection.QuerySingleOrDefault<T>(statement, parameters, transaction, commandTimeout, commandType);
        }

        /// <inheritdoc cref = "SqlMapper.Execute" />
        public int Execute(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            return connection.Execute(statement, parameters, transaction, commandTimeout, commandType);
        }

        /// <inheritdoc cref = "SqlMapper.ExecuteScalar" />
        public T ExecuteScalar<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            return connection.ExecuteScalar<T>(statement, parameters, transaction, commandTimeout, commandType);
        }

        /// <inheritdoc cref = "SqlCommand.ExecuteNonQuery" />
        public int ExecuteNonQuery()
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement);

            sqlBuilder = new SqlBuilder();
            using var connection = (SqlConnection)OpenConnectionAsync();
            using var command = new SqlCommand(statement, connection);
            return command.ExecuteNonQuery();
        }

        /// <inheritdoc cref = "SqlCommand.ExecuteNonQuery" />
        public int ExecuteNonQuery(SqlTransaction transaction)
        {
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement);

            sqlBuilder = new SqlBuilder();
            using var connnection = transaction.Connection;
            using var command = new SqlCommand(statement, connnection, transaction);
            return command.ExecuteNonQuery();
        }

        /// <inheritdoc cref = "SqlMapper.ExecuteReader" />
        public DataTable ExecuteReader(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var result = new DataTable();
            var statement = sqlBuilder.ToSql();

            if (Debugger.IsAttached) TraceQuery(statement, parameters);

            sqlBuilder = new SqlBuilder();
            using var connection = transaction?.Connection ?? OpenConnectionAsync();
            result.Load(connection.ExecuteReader(statement, parameters, transaction, commandTimeout, commandType));
            return result;
        }
    }
}
