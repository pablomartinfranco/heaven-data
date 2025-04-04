using Dapper;
using Sequel;
using System;
using System.Collections.Generic;
using System.Data;

namespace Heaven.Data
{
    public partial class DbSession : DbContext, IDbSession
    {
        public IEnumerable<T> Query<T>(string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.Query<T>(sql, param, Transaction, buffered, commandTimeout, commandType);
        }

        public IEnumerable<T> Query<T>(Sql sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sql.ToString();
            sql.New();
            return Connection.Query<T>(statement, param, Transaction, buffered, commandTimeout, commandType);
        }

        public IEnumerable<T> Query<T>(ref Sql sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sql.ToString();
            sql.New();
            return Connection.Query<T>(statement, param, Transaction, buffered, commandTimeout, commandType);
        }

        public IEnumerable<T> Query<T>(string sql, Type[] types, Func<object[], T> map,
            object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.Query(sql, types, map, param, Transaction, buffered, splitOn, commandTimeout, commandType);
        }

        public IEnumerable<T> Query<T>(Sql sql, Type[] types, Func<object[], T> map,
            object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sql.ToString();
            sql.New();
            return Connection.Query(statement, types, map, param, Transaction, buffered, splitOn, commandTimeout, commandType);
        }

        public IEnumerable<T> Query<T>(ref Sql sql, Type[] types, Func<object[], T> map,
            object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sql.ToString();
            sql.New();
            return Connection.Query(statement, types, map, param, Transaction, buffered, splitOn, commandTimeout, commandType);
        }

        public T QueryFirst<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.QueryFirst<T>(sql, param, Transaction, commandTimeout, commandType);
        }

        public T QueryFirst<T>(Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sql.ToString();
            sql.New();
            return Connection.QueryFirst<T>(statement, param, Transaction, commandTimeout, commandType);
        }

        public T QueryFirst<T>(ref Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sql.ToString();
            sql.New();
            return Connection.QueryFirst<T>(statement, param, Transaction, commandTimeout, commandType);
        }

        public T QueryFirstOrDefault<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.QueryFirstOrDefault<T>(sql, param, Transaction, commandTimeout, commandType);
        }

        public T QueryFirstOrDefault<T>(Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sql.ToString();
            sql.New();
            return Connection.QueryFirstOrDefault<T>(statement, param, Transaction, commandTimeout, commandType);
        }

        public T QueryFirstOrDefault<T>(ref Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sql.ToString();
            sql.New();
            return Connection.QueryFirstOrDefault<T>(statement, param, Transaction, commandTimeout, commandType);
        }

        public T QuerySingle<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.QuerySingle<T>(sql, param, Transaction, commandTimeout, commandType);
        }

        public T QuerySingle<T>(Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sql.ToString();
            sql.New();
            return Connection.QuerySingle<T>(statement, param, Transaction, commandTimeout, commandType);
        }

        public T QuerySingle<T>(ref Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sql.ToString();
            sql.New();
            return Connection.QuerySingle<T>(statement, param, Transaction, commandTimeout, commandType);
        }

        public T QuerySingleOrDefault<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.QuerySingleOrDefault<T>(sql, param, Transaction, commandTimeout, commandType);
        }

        public T QuerySingleOrDefault<T>(Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sql.ToString();
            sql.New();
            return Connection.QuerySingleOrDefault<T>(statement, param, Transaction, commandTimeout, commandType);
        }

        public T QuerySingleOrDefault<T>(ref Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sql.ToString();
            sql.New();
            return Connection.QuerySingleOrDefault<T>(statement, param, Transaction, commandTimeout, commandType);
        }

        public int Execute(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.Execute(sql, param, Transaction, commandTimeout, commandType);
        }

        public int Execute(Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sql.ToString();
            sql.New();
            return Connection.Execute(statement, param, Transaction, commandTimeout, commandType);
        }

        public int Execute(ref Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sql.ToString();
            sql.New();
            return Connection.Execute(statement, param, Transaction, commandTimeout, commandType);
        }

        public T ExecuteScalar<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.ExecuteScalar<T>(sql, param, Transaction, commandTimeout, commandType);
        }

        public T ExecuteScalar<T>(Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sql.ToString();
            sql.New();
            return Connection.ExecuteScalar<T>(statement, param, Transaction, commandTimeout, commandType);
        }

        public T ExecuteScalar<T>(ref Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var statement = sql.ToString();
            sql.New();
            return Connection.ExecuteScalar<T>(statement, param, Transaction, commandTimeout, commandType);
        }

        public DataTable ExecuteReader(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var result = new DataTable();

            result.Load(Connection.ExecuteReader(sql, param, Transaction, commandTimeout, commandType));

            return result;
        }

        public DataTable ExecuteReader(Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var result = new DataTable();
            var statement = sql.ToString();
            sql.New();

            result.Load(Connection.ExecuteReader(statement, param, Transaction, commandTimeout, commandType));

            return result;
        }

        public DataTable ExecuteReader(ref Sql sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var result = new DataTable();
            var statement = sql.ToString();
            sql.New();

            result.Load(Connection.ExecuteReader(statement, param, Transaction, commandTimeout, commandType));

            return result;
        }
    }
}
