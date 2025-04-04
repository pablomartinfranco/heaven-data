using Dapper;
using Sequel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Heaven.Data
{
  public partial class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
  {
    public readonly ISqlMapper<TEntity> sqlMapper;

    public Repository(
      IDbContext dbContext,
      ISqlMapper<TEntity> sqlMapper)
    {
      DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
      this.sqlMapper = sqlMapper ?? throw new ArgumentNullException(nameof(sqlMapper));
    }

    public Repository(IDbContext dbContext) : this(dbContext, new SqlMapper<TEntity>()) { }

    public Repository(SqlMapper<TEntity> sqlMapper = null)
    { 
      this.sqlMapper = sqlMapper ?? new SqlMapper<TEntity>();
    }

    public IDbContext DbContext { get; set; }

    private IDbConnection Connection =>
      DbContext.UnitOfWork.Transaction.Connection;

    private IDbTransaction Transaction =>
      DbContext.UnitOfWork.Transaction;

    public bool Exists(object key)
    {
      var sql = new SqlBuilder()
        .Select("COUNT(1)")
        .From(sqlMapper.Table)
        .Where($"{sqlMapper.Key} = @key")
        .ToSql();

      return ExecuteScalar<bool>(sql, new { key });
    }

    //public int Create(TEntity entity)
    //{
    //  return Connection.QuerySingleOrDefault<int>($"{sqlMapper.CreateSql.ToSql()}; SELECT SCOPE_IDENTITY();", entity, Transaction);
    //}

    public TEntity Create(TEntity entity)
    {
      return Connection.QuerySingleOrDefault<TEntity>($"{sqlMapper.CreateSql.ToSql()} OUTPUT INSERTED.*", entity, Transaction);
    }

    public bool Create(IEnumerable<TEntity> entities)
    {
      return (Execute(sqlMapper.CreateSql.ToSql(), entities)) == entities.Count();
    }

    public TEntity Get(object key)
    {
      return QuerySingleOrDefault(sqlMapper.ReadSql.Where($"{sqlMapper.Key} = @key").ToSql(), new { key });
    }

    public bool Update(TEntity entity)
    {
      return (Execute(sqlMapper.UpdateSql.ToSql(), entity)) == 1;
    }

    public bool Update(IEnumerable<TEntity> entities)
    {
      return (Execute(sqlMapper.UpdateSql.ToSql(), entities)) == entities.Count();
    }

    public bool Delete(TEntity entity)
    {
      return (Execute(sqlMapper.DeleteSql.ToSql(), entity)) == 1;
    }

    public bool Delete(IEnumerable<TEntity> entities)
    {
      return (Execute(sqlMapper.DeleteSql.ToSql(), entities)) == entities.Count();
    }

    public IEnumerable<TEntity> List()
    {
      return Query(sqlMapper.ReadSql.ToSql());
    }

    public IEnumerable<TEntity> FindBy(string field, object value)
    {
      return Query(sqlMapper.ReadSql.Where($"{field} = @value").ToSql(), new { value });
    }

    public IEnumerable<TEntity> FindLike(string field, object value)
    {
      return Query(sqlMapper.ReadSql.Where($"{field} LIKE @value").ToSql(), new { value });
    }

    public TEntity FirstBy(string field, object value)
    {
      return QueryFirstOrDefault(sqlMapper.ReadSql.Where($"{field} = @value").ToSql(), new { value });
    }

    public TEntity FirstLike(string field, object value)
    {
      return QueryFirstOrDefault(sqlMapper.ReadSql.Where($"{field} LIKE @value").ToSql(), new { value });
    }

    public int Execute(string sql, object param = null, CommandType commandType = CommandType.Text)
    {
      return Connection.Execute(sql, param, Transaction);
    }

    public T ExecuteScalar<T>(string sql, object param = null, CommandType commandType = CommandType.Text)
    {
      return Connection.ExecuteScalar<T>(sql, param, Transaction);
    }

    public TEntity QueryFirstOrDefault(string sql, object param = null, CommandType commandType = CommandType.Text)
    {
      return Connection.QueryFirstOrDefault<TEntity>(sql, param, Transaction);
    }

    public TEntity QuerySingleOrDefault(string sql, object param = null, CommandType commandType = CommandType.Text)
    {
      return Connection.QuerySingleOrDefault<TEntity>(sql, param, Transaction);
    }

    public IEnumerable<TEntity> Query(string sql, object param = null, CommandType commandType = CommandType.Text)
    {
      return Connection.Query<TEntity>(sql, param, Transaction);
    }

    public IEnumerable<TEntity> Query<TSecond>(string sql, Func<TEntity, TSecond, TEntity> map, object param = null, CommandType commandType = CommandType.Text)
    {
      return Connection.Query(sql, map, param, Transaction);
    }

    public IEnumerable<TEntity> Query<TSecond, TThird>(string sql, Func<TEntity, TSecond, TThird, TEntity> map, object param = null, CommandType commandType = CommandType.Text)
    {
      return Connection.Query(sql, map, param, Transaction);
    }

    public IEnumerable<TEntity> Query<TSecond, TThird, TFourth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TEntity> map, object param = null, CommandType commandType = CommandType.Text)
    {
      return Connection.Query(sql, map, param, Transaction);
    }

    public IEnumerable<TEntity> Query<TSecond, TThird, TFourth, TFifth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TEntity> map, object param = null, CommandType commandType = CommandType.Text)
    {
      return Connection.Query(sql, map, param, Transaction);
    }

    public IEnumerable<TEntity> Query<TSecond, TThird, TFourth, TFifth, TSixth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> map, object param = null, CommandType commandType = CommandType.Text)
    {
      return Connection.Query(sql, map, param, Transaction);
    }

    public IEnumerable<TEntity> Query<TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> map, object param = null, CommandType commandType = CommandType.Text)
    {
      return Connection.Query(sql, map, param, Transaction);
    }
  }
}