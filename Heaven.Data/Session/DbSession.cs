using System.Data;

namespace Heaven.Data
{
    public partial class DbSession : DbContext, IDbSession
    {
        public DbSession(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
            Contrib = new Contrib(this);
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new()
        {
            return new Repository<TEntity>() { DbContext = this };
        }

        public Contrib Contrib { get; private set; }

        public new IDbConnection Connection =>
          UnitOfWork.Transaction.Connection;

        public new IDbTransaction Transaction =>
          UnitOfWork.Transaction;
    }
}
