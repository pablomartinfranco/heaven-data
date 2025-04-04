namespace Sequel
{
    public interface ISqlMapper<TEntity>
    {
        string Schema { get; }
        string Database { get; }
        string Table { get; }
        string TableQualified { get; }
        string Key { get; }
        string KeyQualified { get; }
        string ExplicitKey { get; }
        string ExplicitKeyQualified { get; }
        string[] Fields { get; }
        string[] FieldsQualified { get; }
        string[] NonKeyFields { get; }
        string[] NonKeyFieldsQualified { get; }
        SqlBuilder CreateSql { get; }
        SqlBuilder ReadSql { get; }
        SqlBuilder UpdateSql { get; }
        SqlBuilder DeleteSql { get; }
        string Columns { get; }
        string ColumnsQualified { get; }
        string NonKeyColumns { get; }
        string NonKeyColumnsQualified { get; }
        string Parse(dynamic value);
    }
}