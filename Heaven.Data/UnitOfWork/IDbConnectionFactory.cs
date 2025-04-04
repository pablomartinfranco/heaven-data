using System;
using System.Data;
using System.Threading.Tasks;

namespace Heaven.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateOpenConnection();
    }
}