using System.Collections.Generic;
using System.Threading.Tasks;

namespace Heaven.Data
{
    public partial interface IContrib
    {
        T Get<T>(int id, int? commandTimeout = null) where T : class;

        T Get<T>(string id, int? commandTimeout = null) where T : class;

        IEnumerable<T> GetAll<T>(int? commandTimeout = null) where T : class;

        int Insert<T>(T entity, int? commandTimeout = null) where T : class;

        bool Update<T>(T entity, int? commandTimeout = null) where T : class;

        bool Delete<T>(T entity, int? commandTimeout = null) where T : class;

        bool DeleteAll<T>(int? commandTimeout = null) where T : class;

        Task<T> GetAsync<T>(int id, int? commandTimeout = null) where T : class;

        Task<T> GetAsync<T>(string id, int? commandTimeout = null) where T : class;

        Task<IEnumerable<T>> GetAllAsync<T>(int? commandTimeout = null) where T : class;

        Task<int> InsertAsync<T>(T entity, int? commandTimeout = null, ISqlAdapter sqlAdapter = null) where T : class;

        Task<bool> UpdateAsync<T>(T entity, int? commandTimeout = null) where T : class;

        Task<bool> DeleteAsync<T>(T entity, int? commandTimeout = null) where T : class;

        Task<bool> DeleteAllAsync<T>(int? commandTimeout = null) where T : class;
    }
}
