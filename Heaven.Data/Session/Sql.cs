using Sequel;
using System.Data;

namespace Heaven.Data
{
    public partial class Sql : ISql
    {
        private readonly IDbConnectionFactory connectionFactory;

        private SqlBuilder sqlBuilder = new();

        public Sql(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IDbConnection OpenConnectionAsync()
        {
            return connectionFactory.CreateOpenConnection();
        }
    }
}