using Dapper.Contrib.Extensions;
using Sequel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Heaven.Data
{
    public class SqlMapper<TEntity> : ISqlMapper<TEntity> where TEntity : class
    {
        public SqlMapper(string database = "", string schema = "dbo")
        {
            Schema = schema;

            Database = database;
        }

        public readonly IEnumerable<PropertyInfo> Properties = typeof(TEntity).GetProperties()
            .Where(p => !Attribute.IsDefined(p, typeof(WriteAttribute)) ||
            Attribute.IsDefined(p, typeof(WriteAttribute)) && p.GetCustomAttribute<WriteAttribute>().Write);

        public string Schema { get; }

        public string Database { get; }

        public string Table => typeof(TEntity).GetCustomAttribute<TableAttribute>(false)?.Name
            ?? throw new CustomAttributeFormatException(nameof(TEntity));

        public string Key => Properties.FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>(false) != null)?.Name ?? "";

        public string ExplicitKey => Properties.FirstOrDefault(p => p.GetCustomAttribute<ExplicitKeyAttribute>(false) != null)?.Name ?? "";

        public string TableQualified => Database != "" ? $"{Database}.{Schema}.{Table}" : $"{Schema}.{Table}";

        public string KeyQualified => Key != "" ? $"{TableQualified}.{Key}" : "";

        public string ExplicitKeyQualified => ExplicitKey != "" ? $"{TableQualified}.{KeyQualified}" : "";

        public string[] Fields => Properties.Select(p => p.Name).ToArray();

        public string[] FieldsQualified => Fields.Select(f => $"{TableQualified}.{f}").ToArray();

        public string[] NonKeyFields => Fields.Where(f => f != Key).ToArray();

        public string[] NonKeyFieldsQualified => FieldsQualified.Where(fq => fq != KeyQualified && fq != ExplicitKeyQualified).ToArray();

        public SqlBuilder CreateSql => new SqlBuilder().Insert(TableQualified).Into(NonKeyFields).Value(NonKeyFields.Select(f => $"@{f}").ToArray());

        public SqlBuilder ReadSql => new SqlBuilder().Select(Fields).From(TableQualified);

        public SqlBuilder UpdateSql => new SqlBuilder().Update(TableQualified).Set(NonKeyFields.Zip(Fields, (fq, f) => $"{fq} = @{f}").ToArray()).Where($"{Key} = @{Key}");

        public SqlBuilder DeleteSql => new SqlBuilder().Delete(TableQualified).Where($"{Key} = @{Key}");

        public string Columns => Fields.Aggregate(new StringBuilder(), (s, f) => s.Append(", " + f), s => s.Remove(0, 2).ToString());

        public string ColumnsQualified => FieldsQualified.Aggregate(new StringBuilder(), (s, fq) => s.Append(", " + fq), s => s.Remove(0, 2).ToString());

        public string NonKeyColumns => NonKeyFields.Aggregate(new StringBuilder(), (s, f) => s.Append(", " + f), s => s.Remove(0, 2).ToString());

        public string NonKeyColumnsQualified => NonKeyFieldsQualified.Aggregate(new StringBuilder(), (s, fq) => s.Append(", " + fq), s => s.Remove(0, 2).ToString());

        public string Parse(dynamic value) => value switch
        {
            string  => $"'{value}'",
            int     => $"{value}",
            long    => $"{value}",
            float   => $"{value}",
            double  => $"{value}",
            bool    => value is true ? "1" : "0",
            DateTime => $"'{value}'",
            _ => throw new ArgumentException("Error while matching type"),
        };

        public string TypeOf(dynamic value) => value switch
        {
            string  => "text",
            byte[]  => "binary",
            byte    => "tinyint",
            short   => "smallint",
            int     => "int",
            long    => "bigint",
            float   => "real",
            double  => "float",
            decimal => "money",
            bool    => "bit",
            Guid    => "uniqueidentifier",
            DateTime => "datetime",
            _ => throw new ArgumentException("Error while matching type"),
        };
    }
}