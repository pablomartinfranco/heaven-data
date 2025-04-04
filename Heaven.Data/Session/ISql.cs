using Sequel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Heaven.Data
{
    public interface ISql
    {
        IDbConnection OpenConnectionAsync();

        //// Dapper

        IEnumerable<T> Query<T>(object parameters = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);

        IEnumerable<T> Query<T>(Type[] types, Func<object[], T> map, object parameters = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        T QueryFirst<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        T QueryFirstOrDefault<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        T QuerySingle<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        T QuerySingleOrDefault<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        int Execute(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        T ExecuteScalar<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        int ExecuteNonQuery();

        int ExecuteNonQuery(SqlTransaction transaction);

        DataTable ExecuteReader(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        //// Dapper Async

        Task<IEnumerable<T>> QueryAsync<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<IEnumerable<T>> QueryAsync<T>(Type[] types, Func<object[], T> map, object parameters = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        Task<T> QueryFirstAsync<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<T> QueryFirstOrDefaultAsync<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<T> QuerySingleAsync<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<T> QuerySingleOrDefaultAsync<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<int> ExecuteAsync(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<T> ExecuteScalarAsync<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<int> ExecuteNonQueryAsync();

        Task<int> ExecuteNonQueryAsync(SqlTransaction transaction);

        Task<DataTable> ExecuteReaderAsync(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        //// Sequel

        string ToString();

        SqlBuilder GetBuilder();

        Sql New();

        Sql Script(params string[] predicates);

        Sql Into(params string[] into);

        Sql Exists();

        Sql From(string table);

        Sql From(string table, string alias);

        Sql From(SqlBuilder derivedTable, string alias);

        Sql Delete();

        Sql Delete(string alias);

        Sql GroupBy(params string[] columns);

        Sql Having(params string[] predicate);

        Sql Insert(string table);

        Sql Join(string tableAndPredicate);

        Sql Join(string table, string predicate);

        Sql Join(string table, string alias, string predicate);

        Sql Join(SqlBuilder derivedTable, string alias, string predicate);

        Sql LeftJoin(string tableAndPredicate);

        Sql LeftJoin(string table, string predicate);

        Sql LeftJoin(string table, string alias, string predicate);

        Sql LeftJoin(SqlBuilder derivedTable, string alias, string predicate);

        Sql OrderBy(params string[] columns);

        Sql OrderByDesc(params string[] columns);

        Sql RightJoin(string tableAndPredicate);

        Sql RightJoin(string table, string predicate);

        Sql RightJoin(string table, string alias, string predicate);

        Sql RightJoin(SqlBuilder derivedTable, string alias, string predicate);

        Sql Select(params string[] columns);

        Sql SelectWithAlias(string alias, params string[] columns);

        Sql Set(params string[] columnAndValuePairs);

        Sql Update(string tableOrAlias);

        Sql Value(params string[] columnAndValuePairs);

        Sql Values(params string[] columnAndValuePairs);

        Sql Where(params string[] predicates);

        Sql WhereOr(params string[] predicates);

        // MSSQLServer
        Sql CrossApply(string tvf, string alias);

        Sql CrossApply(SqlBuilder sqlBuilder, string alias);

        Sql Top(int n);

        Sql OffsetFetch(int offset, int fetch);

        Sql ScopeIdentity();

        Sql Output(params string[] predicates);

        // MySQL
        Sql Limit(int n);

        Sql LastInsertId();

        // Shortcuts
        Sql Exists<T>(int id) where T : class;

        Sql Exists<T>(string id) where T : class;

        Sql Into<T>() where T : class;

        Sql From<T>() where T : class;

        Sql From<T>(string alias) where T : class;

        Sql Join<T>(string predicate) where T : class;

        Sql Join<T>(string alias, string predicate) where T : class;

        Sql LeftJoin<T>(string predicate) where T : class;

        Sql LeftJoin<T>(string alias, string predicate) where T : class;

        Sql RightJoin<T>(string predicate) where T : class;

        Sql RightJoin<T>(string alias, string predicate) where T : class;

        Sql InsertInto<T>(string database, string schema) where T : class;

        Sql InsertIntoValue<T>(string database, string schema, params (string name, dynamic value)[] fields) where T : class;

        Sql InsertIntoValue<T>(string database, string schema) where T : class;

        Sql SelectFrom<T>() where T : class;

        Sql SelectFrom<T>(int id) where T : class;

        Sql SelectFrom<T>(string id) where T : class;

        Sql SelectWithAlias<T>(string alias) where T : class;

        Sql SelectWithAliasFrom<T>(string alias) where T : class;

        Sql Update<T>() where T : class;

        Sql DeleteFrom<T>() where T : class;

        Sql DeleteFrom<T>(int id) where T : class;

        Sql DeleteFrom<T>(string id) where T : class;
    }
}
