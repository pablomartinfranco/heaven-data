using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Heaven.Data
{
    public class Contrib : IContrib
    {
        private readonly IDbContext db;

        public Contrib(IDbContext dbContext)
        {
            db = dbContext;
        }

        public T Get<T>(int id, int? commandTimeout = null) where T : class
        {
            return db.Connection.Get<T>(id, db.Transaction, commandTimeout);
        }

        public T Get<T>(string id, int? commandTimeout = null) where T : class
        {
            return db.Connection.Get<T>(id, db.Transaction, commandTimeout);
        }

        public IEnumerable<T> GetAll<T>(int? commandTimeout = null) where T : class
        {
            return db.Connection.GetAll<T>(db.Transaction, commandTimeout);
        }

        public int Insert<T>(T entity, int? commandTimeout = null) where T : class
        {
            return db.Connection.Insert(entity, db.Transaction, commandTimeout);
        }

        public bool Update<T>(T entity, int? commandTimeout = null) where T : class
        {
            return db.Connection.Update(entity, db.Transaction, commandTimeout);
        }

        public bool Delete<T>(T entity, int? commandTimeout = null) where T : class
        {
            return db.Connection.Delete(entity, db.Transaction, commandTimeout);
        }

        public bool DeleteAll<T>(int? commandTimeout = null) where T : class
        {
            return db.Connection.DeleteAll<T>(db.Transaction, commandTimeout);
        }

        public async Task<T> GetAsync<T>(int id, int? commandTimeout = null) where T : class
        {
            return await db.Connection.GetAsync<T>(id, db.Transaction, commandTimeout);
        }

        public async Task<T> GetAsync<T>(string id, int? commandTimeout = null) where T : class
        {
            return await db.Connection.GetAsync<T>(id, db.Transaction, commandTimeout);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(int? commandTimeout = null) where T : class
        {
            return await db.Connection.GetAllAsync<T>(db.Transaction, commandTimeout);
        }

        public async Task<int> InsertAsync<T>(T entity, int? commandTimeout = null, ISqlAdapter sqlAdapter = null) where T : class
        {
            return await db.Connection.InsertAsync(entity, db.Transaction, commandTimeout, sqlAdapter);
        }

        public async Task<bool> UpdateAsync<T>(T entity, int? commandTimeout = null) where T : class
        {
            return await db.Connection.UpdateAsync(entity, db.Transaction, commandTimeout);
        }

        public async Task<bool> DeleteAsync<T>(T entity, int? commandTimeout = null) where T : class
        {
            return await db.Connection.DeleteAsync(entity, db.Transaction, commandTimeout);
        }

        public async Task<bool> DeleteAllAsync<T>(int? commandTimeout = null) where T : class
        {
            return await db.Connection.DeleteAllAsync<T>(db.Transaction, commandTimeout);
        }
    }
}