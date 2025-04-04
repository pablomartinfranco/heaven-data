using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Heaven.Data
{
  public partial interface IRepository<TEntity>
  {
    Task<bool> ExistsAsync(object key);

    Task<TEntity> CreateAsync(TEntity entity);

    //Task<object> CreateAsync(TEntity entity, string output);

    Task<bool> CreateAsync(IEnumerable<TEntity> entities);

    Task<TEntity> GetAsync(object key);

    Task<bool> UpdateAsync(TEntity entity);

    Task<bool> UpdateAsync(IEnumerable<TEntity> entities);

    Task<bool> DeleteAsync(TEntity entity);

    Task<bool> DeleteAsync(IEnumerable<TEntity> entities);

    Task<IEnumerable<TEntity>> ListAsync();

    Task<IEnumerable<TEntity>> FindByAsync(string field, object value);

    Task<IEnumerable<TEntity>> FindLikeAsync(string field, object value);

    Task<TEntity> FirstByAsync(string field, object value);

    Task<TEntity> FirstLikeAsync(string field, object value);

    Task<int> ExecuteAsync(string sql, object param = null, CommandType commandType = CommandType.Text);

    Task<T> ExecuteScalarAsync<T>(string sql, object param = null, CommandType commandType = CommandType.Text);

    Task<TEntity> QueryFirstOrDefaultAsync(string sql, object param = null, CommandType commandType = CommandType.Text);

    Task<TEntity> QuerySingleOrDefaultAsync(string sql, object param = null, CommandType commandType = CommandType.Text);

    Task<IEnumerable<TEntity>> QueryAsync(string sql, object param = null, CommandType commandType = CommandType.Text);

    Task<IEnumerable<TEntity>> QueryAsync<TSecond>(string sql, Func<TEntity, TSecond, TEntity> map, object param = null, CommandType commandType = CommandType.Text);

    Task<IEnumerable<TEntity>> QueryAsync<TSecond, TThird>(string sql, Func<TEntity, TSecond, TThird, TEntity> map, object param = null, CommandType commandType = CommandType.Text);

    Task<IEnumerable<TEntity>> QueryAsync<TSecond, TThird, TFourth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TEntity> map, object param = null, CommandType commandType = CommandType.Text);

    Task<IEnumerable<TEntity>> QueryAsync<TSecond, TThird, TFourth, TFifth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TEntity> map, object param = null, CommandType commandType = CommandType.Text);

    Task<IEnumerable<TEntity>> QueryAsync<TSecond, TThird, TFourth, TFifth, TSixth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> map, object param = null, CommandType commandType = CommandType.Text);

    Task<IEnumerable<TEntity>> QueryAsync<TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> map, object param = null, CommandType commandType = CommandType.Text);
  }
}