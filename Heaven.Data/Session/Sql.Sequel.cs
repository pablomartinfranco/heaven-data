using Sequel;
using Sequel.MsSql;
using Sequel.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heaven.Data
{
    public partial class Sql : ISql
    {
        public override string ToString() => sqlBuilder.ToSql();

        public SqlBuilder GetBuilder() { return sqlBuilder; }

        public Sql New() { sqlBuilder = new SqlBuilder(); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Script" />
        public Sql Script(params string[] predicates) { sqlBuilder.Script(predicates); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Into" />
        public Sql Into(params string[] into) { sqlBuilder.Into(into); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Exists" />
        public Sql Exists() { sqlBuilder.Exists(sqlBuilder); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.From" />
        public Sql From(string table) { sqlBuilder.From(table); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.From" />
        public Sql From(string table, string alias) { sqlBuilder.From(table, alias); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.From" />
        public Sql From(SqlBuilder derivedTable, string alias) { sqlBuilder.From(derivedTable, alias); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Delete" />
        public Sql Delete() { sqlBuilder.Delete(); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Delete" />
        public Sql Delete(string alias) { sqlBuilder.Delete(alias); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.GroupBy" />
        public Sql GroupBy(params string[] columns) { sqlBuilder.GroupBy(columns); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Having" />
        public Sql Having(params string[] predicate) { sqlBuilder.Having(predicate); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Insert" />
        public Sql Insert(string table) { sqlBuilder.Insert(table); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Join" />
        public Sql Join(string tableAndPredicate) { sqlBuilder.Join(tableAndPredicate); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Join" />
        public Sql Join(string table, string predicate) { sqlBuilder.Join(table, predicate); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Join" />
        public Sql Join(string table, string alias, string predicate) { sqlBuilder.Join(table, alias, predicate); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Join" />
        public Sql Join(SqlBuilder derivedTable, string alias, string predicate) { sqlBuilder.Join(derivedTable, alias, predicate); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.LeftJoin" />
        public Sql LeftJoin(string tableAndPredicate) { sqlBuilder.LeftJoin(tableAndPredicate); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.LeftJoin" />
        public Sql LeftJoin(string table, string predicate) { sqlBuilder.LeftJoin(table, predicate); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.LeftJoin" />
        public Sql LeftJoin(string table, string alias, string predicate) { sqlBuilder.LeftJoin(table, alias, predicate); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.LeftJoin" />
        public Sql LeftJoin(SqlBuilder derivedTable, string alias, string predicate) { sqlBuilder.LeftJoin(derivedTable, alias, predicate); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.OrderBy" />
        public Sql OrderBy(params string[] columns) { sqlBuilder.OrderBy(columns); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.OrderByDesc" />
        public Sql OrderByDesc(params string[] columns) { sqlBuilder.OrderByDesc(columns); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.RightJoin" />
        public Sql RightJoin(string tableAndPredicate) { sqlBuilder.RightJoin(tableAndPredicate); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.RightJoin" />
        public Sql RightJoin(string table, string predicate) { sqlBuilder.RightJoin(table, predicate); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.RightJoin" />
        public Sql RightJoin(string table, string alias, string predicate) { sqlBuilder.RightJoin(table, alias, predicate); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.RightJoin" />
        public Sql RightJoin(SqlBuilder derivedTable, string alias, string predicate) { sqlBuilder.RightJoin(derivedTable, alias, predicate); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Select" />
        public Sql Select(params string[] columns) { sqlBuilder.Select(columns.Length != 0 ? columns : new string[]{"*"}); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.SelectWithAlias" />
        public Sql SelectWithAlias(string alias, params string[] columns) { sqlBuilder.SelectWithAlias(alias, columns); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Set" />
        public Sql Set(params string[] columnAndValuePairs) { sqlBuilder.Set(columnAndValuePairs); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Update" />
        public Sql Update(string tableOrAlias) { sqlBuilder.Update(tableOrAlias); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Value" />
        public Sql Value(params string[] values) { sqlBuilder.Value(values); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Values" />
        public Sql Values(params string[] commaSeparatedValues) { sqlBuilder.Values(commaSeparatedValues); return this; }

        /// <inheritdoc cref = "SqlBuilderExtensions.Where" />
        public Sql Where(params string[] predicates) {
            if (predicates == null || (predicates.Where(p => !string.IsNullOrWhiteSpace(p)).ToArray() is var ps && ps.Length == 0)) return this;
            sqlBuilder.Where(ps); return this;
        }

        /// <inheritdoc cref = "SqlBuilderExtensions.WhereOr" />
        public Sql WhereOr(params string[] predicates) {
            if (predicates == null || (predicates.Where(p => !string.IsNullOrWhiteSpace(p)).ToArray() is var ps && ps.Length == 0)) return this;
            sqlBuilder.WhereOr(predicates); return this;
        }

        // MSSQLServer

        /// <inheritdoc cref = "MsSqlBuilderExtensions.CrossApply" />
        public Sql CrossApply(string tvf, string alias) { sqlBuilder.CrossApply(tvf, alias); return this; }

        /// <inheritdoc cref = "MsSqlBuilderExtensions.CrossApply" />
        public Sql CrossApply(SqlBuilder derivedTable, string alias) { sqlBuilder.CrossApply(derivedTable, alias); return this; }

        /// <inheritdoc cref = "MsSqlBuilderExtensions.Top" />
        public Sql Top(int n) { sqlBuilder.Top(n); return this; }

        /// <inheritdoc cref = "MsSqlBuilderExtensions.OffsetFetch" />
        public Sql OffsetFetch(int offset, int fetch) { sqlBuilder.OffsetFetch(offset, fetch); return this; }

        /// <inheritdoc cref = "MsSqlBuilderExtensions.ScopeIdentity" />
        public Sql ScopeIdentity() { sqlBuilder.ScopeIdentity(); return this; }

        /// <inheritdoc cref = "MsSqlBuilderExtensions.Output" />
        public Sql Output(params string[] predicates) { sqlBuilder.Output(predicates); return this; }

        // MySQL

        /// <inheritdoc cref = "MySqlBuilderExtensions.Limit" />
        public Sql Limit(int n) {  sqlBuilder.Limit(n); return this; }

        /// <inheritdoc cref = "MySqlBuilderExtensions.LastInsertId" />
        public Sql LastInsertId() { sqlBuilder.LastInsertId(); return this; }

        // Shortcuts

        public Sql Exists<T>(int id) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.Select(mapper.Columns)
                .From(mapper.TableQualified)
                .Where($"id = {id}")
                .Exists(sqlBuilder);
            return this;
        }

        public Sql Exists<T>(string id) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.Select(mapper.Columns)
                .From(mapper.TableQualified)
                .Where($"id LIKE '{id}'")
                .Exists(sqlBuilder);
            return this;
        }

        public Sql Into<T>() where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.Into(mapper.NonKeyColumns);
            return this;
        }

        public Sql Value<T>() where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.Into(mapper.NonKeyColumns)
                .Value(mapper.NonKeyFields.Select(nkf => $"@{nkf}").ToArray());
            return this;
        }

        public Sql From<T>() where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.From(mapper.TableQualified);
            return this;
        }

        public Sql From<T>(string alias) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.From(mapper.TableQualified, alias);
            return this;
        }

        public Sql Join<T>(string predicate) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.Join(mapper.TableQualified, predicate);
            return this;
        }

        public Sql Join<T>(params string[] predicates) where T : class
        {
            var mapper = new SqlMapper<T>();

            if (predicates.Any(x => !string.IsNullOrEmpty(x)))
            {
                sqlBuilder.Join(
                    mapper.TableQualified,
                    string.Join(" ON ", predicates.Where(x => !string.IsNullOrEmpty(x)))
                );
            }
            else
            {
                sqlBuilder.Join(
                    mapper.TableQualified
                );
            }

            return this;
        }

        public Sql Join<T>(string alias, string predicate) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.Join(mapper.TableQualified, alias, predicate);
            return this;
        }

        public Sql Join<T>(string alias, params string[] predicates) where T : class
        {
            var mapper = new SqlMapper<T>();

            if (predicates.Any(x => !string.IsNullOrEmpty(x)))
            {
                sqlBuilder.Join(
                    mapper.TableQualified,
                    alias,
                    string.Join(" ON ", predicates.Where(x => !string.IsNullOrEmpty(x)))
                );
            }
            else
            {
                sqlBuilder.Join(
                    mapper.TableQualified,
                    alias,
                    string.Empty
                );
            }

            return this;
        }

        public Sql LeftJoin<T>(string predicate) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.LeftJoin(mapper.TableQualified, predicate);
            return this;
        }

        public Sql LeftJoin<T>(string alias, string predicate) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.LeftJoin(mapper.TableQualified, alias, predicate);
            return this;
        }

        public Sql RightJoin<T>(string predicate) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.RightJoin(mapper.TableQualified, predicate);
            return this;
        }

        public Sql RightJoin<T>(string alias, string predicate) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.RightJoin(mapper.TableQualified, alias, predicate);
            return this;
        }

        public Sql InsertInto<T>(string database = "", string schema = "dbo") where T : class
        {
            var mapper = new SqlMapper<T>(database, schema);
            sqlBuilder.Insert(mapper.TableQualified)
                .Into(mapper.NonKeyColumns);
            return this;
        }

        public Sql InsertIntoValue<T>(string database = "", string schema = "dbo", params (string name, dynamic value)[] fields) where T : class
        {
            var mapper = new SqlMapper<T>(database, schema);
            sqlBuilder.Insert(mapper.TableQualified)
                .Into(fields.Select(f => f.name).ToArray())
                .Value(fields.Select(f => (string) mapper.Parse(f.value)).ToArray());
            return this;
        }

        public Sql InsertIntoValue<T>(string database = "", string schema = "dbo") where T : class
        {
            var mapper = new SqlMapper<T>(database, schema);
            sqlBuilder.Insert(mapper.TableQualified)
                .Into(mapper.NonKeyFields)
                .Value(mapper.NonKeyFields.Select(nkf => $"@{nkf}").ToArray());
            return this;
        }

        public Sql SelectFrom<T>() where T : class
        { 
            var mapper = new SqlMapper<T>();
            sqlBuilder.Select(mapper.Columns)
                .From(mapper.TableQualified);
            return this;
        }

        public Sql SelectFrom<T>(int id) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.Select(mapper.Columns)
                .From(mapper.TableQualified)
                .Where($"id = {id}");
            return this;
        }

        public Sql SelectFrom<T>(string id) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.Select(mapper.Columns)
                .From(mapper.TableQualified)
                .Where($"id LIKE '{id}'");
            return this;
        }

        public Sql SelectWithAlias<T>(string alias) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.SelectWithAlias(alias, mapper.Fields);
            return this;
        }

        public Sql SelectWithAliasFrom<T>(string alias) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.SelectWithAlias(alias, mapper.Fields)
                .From(mapper.TableQualified, alias);
            return this;
        }

        public Sql Update<T>() where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.Update(mapper.TableQualified);
            return this;
        }

        public Sql Set<T>() where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.Set(mapper.NonKeyFields.Select(nkf => $"{nkf} = @{nkf}").ToArray());
            return this;
        }

        public Sql Set(string name, dynamic value)
        {
            var mapper = new SqlMapper<object>();
            sqlBuilder.Set(name + " = " + (string)mapper.Parse(value));
            return this;
        }

        public Sql Set(params (string name, dynamic value)[] fields)
        {
            var mapper = new SqlMapper<object>();
            sqlBuilder.Set(fields.Select(f => f.name + " = " + (string)mapper.Parse(f.value)).ToArray());
            return this;
        }

        public Sql UpdateSet<T>() where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.Update(mapper.TableQualified)
                .Set(mapper.NonKeyFields.Select(nkf => $"{nkf} = @{nkf}").ToArray());
            return this;
        }

        public Sql UpdateSet<T>(params string[] columnAndValuePairs) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.Update(mapper.TableQualified).Set(columnAndValuePairs);
            return this;
        }

        public Sql UpdateSet<T>(params (string name, dynamic value)[] fields) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.Update(mapper.TableQualified)
                .Set(fields.Select(f => f.name + " = " + (string)mapper.Parse(f.value)).ToArray());
            return this;
        }

        public Sql DeleteFrom<T>() where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.Delete()
                .From(mapper.TableQualified); 
            return this;
        }

        public Sql DeleteFrom<T>(int id) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.Delete()
                .From(mapper.TableQualified)
                .Where($"id = {id}"); 
            return this;
        }

        public Sql DeleteFrom<T>(string id) where T : class
        {
            var mapper = new SqlMapper<T>();
            sqlBuilder.Delete()
                .From(mapper.TableQualified)
                .Where($"id LIKE '{id}'");
            return this;
        }

        public Sql CreateTableIfNotExists<T>(bool temporal = false, bool tableAttribute = false) where T : class
        {
            var mapper = new SqlMapper<T>();
            var columnsWithType = mapper.Properties
                .Aggregate(new StringBuilder(),
                (s, p) => s.Append($", {p.Name} {mapper.Parse(p.PropertyType)}"),
                s => s.Remove(0, 2).ToString());
            columnsWithType = !string.IsNullOrEmpty(columnsWithType) ? $" ({columnsWithType})" : "";
            var table = !tableAttribute ? nameof(T) : mapper.Table;
            table = !temporal ? table : $"#{table}";
            var create = $@"
            IF NOT EXISTS(SELECT name FROM tempdb.sys.tables WHERE name like '{table}%')
            BEGIN
                CREATE TABLE {table}{columnsWithType};
            END;
            GO
            ";
            sqlBuilder.Script(create);
            return this;
        }

        public Sql CreateTableIfNotExists(string name, Dictionary<string, Type> propertyTypePairs = null)
        {
            var mapper = new SqlMapper<object>();
            var columnsWithType = propertyTypePairs?.Aggregate(new StringBuilder(),
                (s, p) => s.Append($", {p.Key} {mapper.Parse(p.Value)}"),
                s => s.Remove(0, 2).ToString()) ?? "";
            columnsWithType = !string.IsNullOrEmpty(columnsWithType) ? $" ({columnsWithType})" : "";
            var create = $@"
            IF NOT EXISTS(SELECT name FROM tempdb.sys.tables WHERE name like '{name}%')
            BEGIN
                CREATE TABLE {name}{columnsWithType};
            END;
            GO
            ";
            sqlBuilder.Script(create);
            return this;
        }

        public Sql DropTableIfExists<T>(bool temporal = false, bool tableAttribute = false) where T : class
        {
            var mapper = new SqlMapper<T>();
            var table = !tableAttribute ? nameof(T) : mapper.Table;
            table = !temporal ? table : $"#{table}";
            var create = $"DROP TABLE IF EXISTS {table}";
            sqlBuilder.Script(create);
            return this;
        }

        public Sql DropTableIfExists(string name)
        {
            sqlBuilder.Script($"DROP TABLE IF EXISTS {name}");
            return this;
        }
    }
}
