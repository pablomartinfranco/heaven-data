using System;
using System.Collections.Generic;
using System.Data;

namespace Heaven.Data
{
  public partial interface IRepository<TEntity>
  {
    IDbContext DbContext { get; set; }

    bool Exists(object key);

    //int Create(TEntity entity);

    TEntity Create(TEntity entity);

    bool Create(IEnumerable<TEntity> entities);

    TEntity Get(object key);

    bool Update(TEntity entity);

    bool Update(IEnumerable<TEntity> entities);

    bool Delete(TEntity entity);

    bool Delete(IEnumerable<TEntity> entities);

    IEnumerable<TEntity> List();

    IEnumerable<TEntity> FindBy(string field, object value);

    IEnumerable<TEntity> FindLike(string field, object value);

    TEntity FirstBy(string field, object value);

    TEntity FirstLike(string field, object value);

    int Execute(string sql, object param = null, CommandType commandType = CommandType.Text);

    T ExecuteScalar<T>(string sql, object param = null, CommandType commandType = CommandType.Text);

    TEntity QueryFirstOrDefault(string sql, object param = null, CommandType commandType = CommandType.Text);

    TEntity QuerySingleOrDefault(string sql, object param = null, CommandType commandType = CommandType.Text);

    IEnumerable<TEntity> Query(string sql, object param = null, CommandType commandType = CommandType.Text);

    IEnumerable<TEntity> Query<TSecond>(string sql, Func<TEntity, TSecond, TEntity> map, object param = null, CommandType commandType = CommandType.Text);

    IEnumerable<TEntity> Query<TSecond, TThird>(string sql, Func<TEntity, TSecond, TThird, TEntity> map, object param = null, CommandType commandType = CommandType.Text);

    IEnumerable<TEntity> Query<TSecond, TThird, TFourth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TEntity> map, object param = null, CommandType commandType = CommandType.Text);

    IEnumerable<TEntity> Query<TSecond, TThird, TFourth, TFifth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TEntity> map, object param = null, CommandType commandType = CommandType.Text);

    IEnumerable<TEntity> Query<TSecond, TThird, TFourth, TFifth, TSixth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> map, object param = null, CommandType commandType = CommandType.Text);

    IEnumerable<TEntity> Query<TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> map, object param = null, CommandType commandType = CommandType.Text);
  }
}