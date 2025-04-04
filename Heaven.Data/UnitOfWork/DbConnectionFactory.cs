using System;
using System.Data;
using System.Threading.Tasks;

namespace Heaven.Data
{
public class DbConnectionFactory : IDbConnectionFactory
{
  private readonly Func<IDbConnection> connectionFactoryFn;

  /// <summary>
  /// Responsible for instantiating new IDbConnection's
  /// </summary>
  /// <param name="connectionFactoryFn">Should return open IDbConnection instance</param>
  public DbConnectionFactory(Func<IDbConnection> connectionFactoryFn)
  {
    this.connectionFactoryFn = connectionFactoryFn ?? throw new ArgumentNullException(nameof(connectionFactoryFn));
  }

  public IDbConnection CreateOpenConnection()
  {
    return connectionFactoryFn();
  }
}
}