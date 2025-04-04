using Dapper;
using Sequel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Heaven.Data
{
  public partial class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
  {
    public async Task<bool> ExistsAsync(object key)
    {
      var sql = new SqlBuilder()
        .Select("COUNT(1)")
        .From(sqlMapper.Table)
        .Where($"{sqlMapper.Key} = @key")
        .ToSql();

      return await ExecuteScalarAsync<bool>(sql, new { key });
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
      return await Connection.QuerySingleOrDefaultAsync<TEntity>($"{sqlMapper.CreateSql.ToSql()} OUTPUT INSERTED.*", entity, Transaction);
    }

    //public async Task<object> CreateAsync(TEntity entity, string output)
    //{
    //  return await Connection.QuerySingleOrDefaultAsync<object>($"{sqlMapper.CreateSql.ToSql()} OUTPUT INSERTED.{(output.Any() ? output : '*')}", entity, Transaction);
    //}

    public async Task<bool> CreateAsync(IEnumerable<TEntity> entities)
    {
      return (await ExecuteAsync(sqlMapper.CreateSql.ToSql(), entities)) == entities.Count();
    }

    public async Task<TEntity> GetAsync(object key)
    {
      return await QuerySingleOrDefaultAsync(sqlMapper.ReadSql.Where($"{sqlMapper.Key} = @key").ToSql(), new { key });
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
      return (await ExecuteAsync(sqlMapper.UpdateSql.ToSql(), entity)) == 1;
    }

    public async Task<bool> UpdateAsync(IEnumerable<TEntity> entities)
    {
      return (await ExecuteAsync(sqlMapper.UpdateSql.ToSql(), entities)) == entities.Count();
    }

    public async Task<bool> DeleteAsync(TEntity entity)
    {
      return (await ExecuteAsync(sqlMapper.DeleteSql.ToSql(), entity)) == 1;
    }

    public async Task<bool> DeleteAsync(IEnumerable<TEntity> entities)
    {
      return (await ExecuteAsync(sqlMapper.DeleteSql.ToSql(), entities)) == entities.Count();
    }

    public async Task<IEnumerable<TEntity>> ListAsync()
    {
      return await QueryAsync(sqlMapper.ReadSql.ToSql());
    }

    public async Task<IEnumerable<TEntity>> FindByAsync(string field, object value)
    {
      return await QueryAsync(sqlMapper.ReadSql.Where($"{field} = @value").ToSql(), new { value });
    }

    public async Task<IEnumerable<TEntity>> FindLikeAsync(string field, object value)
    {
      return await QueryAsync(sqlMapper.ReadSql.Where($"{field} LIKE @value").ToSql(), new { value });
    }

    public async Task<TEntity> FirstByAsync(string field, object value)
    {
      return await QueryFirstOrDefaultAsync(sqlMapper.ReadSql.Where($"{field} = @value").ToSql(), new { value });
    }

    public async Task<TEntity> FirstLikeAsync(string field, object value)
    {
      return await QueryFirstOrDefaultAsync(sqlMapper.ReadSql.Where($"{field} LIKE @value").ToSql(), new { value });
    }

    public async Task<int> ExecuteAsync(string sql, object param = null, CommandType commandType = CommandType.Text)
    {
      return await Connection.ExecuteAsync(sql, param, Transaction);
    }

    public async Task<T> ExecuteScalarAsync<T>(string sql, object param = null, CommandType commandType = CommandType.Text)
    {
      return await Connection.ExecuteScalarAsync<T>(sql, param, Transaction);
    }

    public async Task<TEntity> QueryFirstOrDefaultAsync(string sql, object param = null, CommandType commandType = CommandType.Text)
    {
      return await Connection.QueryFirstOrDefaultAsync<TEntity>(sql, param, Transaction);
    }

    public async Task<TEntity> QuerySingleOrDefaultAsync(string sql, object param = null, CommandType commandType = CommandType.Text)
    {
      return await Connection.QuerySingleOrDefaultAsync<TEntity>(sql, param, Transaction);
    }

    public async Task<IEnumerable<TEntity>> QueryAsync(string sql, object param = null, CommandType commandType = CommandType.Text)
    {
      return await Connection.QueryAsync<TEntity>(sql, param, Transaction);
    }

    public async Task<IEnumerable<TEntity>> QueryAsync<TSecond>(string sql, Func<TEntity, TSecond, TEntity> map, object param = null, CommandType commandType = CommandType.Text)
    {
      return await Connection.QueryAsync(sql, map, param, Transaction);
    }

    public async Task<IEnumerable<TEntity>> QueryAsync<TSecond, TThird>(string sql, Func<TEntity, TSecond, TThird, TEntity> map, object param = null, CommandType commandType = CommandType.Text)
    {
      return await Connection.QueryAsync(sql, map, param, Transaction);
    }

    public async Task<IEnumerable<TEntity>> QueryAsync<TSecond, TThird, TFourth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TEntity> map, object param = null, CommandType commandType = CommandType.Text)
    {
      return await Connection.QueryAsync(sql, map, param, Transaction);
    }

    public async Task<IEnumerable<TEntity>> QueryAsync<TSecond, TThird, TFourth, TFifth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TEntity> map, object param = null, CommandType commandType = CommandType.Text)
    {
      return await Connection.QueryAsync(sql, map, param, Transaction);
    }

    public async Task<IEnumerable<TEntity>> QueryAsync<TSecond, TThird, TFourth, TFifth, TSixth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> map, object param = null, CommandType commandType = CommandType.Text)
    {
      return await Connection.QueryAsync(sql, map, param, Transaction);
    }

    public async Task<IEnumerable<TEntity>> QueryAsync<TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> map, object param = null, CommandType commandType = CommandType.Text)
    {
      return await Connection.QueryAsync(sql, map, param, Transaction);
    }
  }
}