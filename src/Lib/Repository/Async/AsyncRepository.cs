using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dommel.Repositories.Repository.Async
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        public AsyncRepository(IDbConnection connection)
        {
            Connection = connection;
        }

        protected IDbConnection Connection { get; set; }

        public Task<T> GetByIdAsync(int id)
        {
            return Connection.GetAsync<T>(id);
        }

        public Task<T> GetByIdAsync<T2>(int id)
        {
            return Connection.GetAsync<T, T2, T>(id);
        }

        public Task<T> GetByIdAsync<T2, T3>(int id)
        {
            return Connection.GetAsync<T, T2, T3, T>(id);
        }

        public Task<T> GetByIdAsync<T2, T3, T4>(int id)
        {
            return Connection.GetAsync<T, T2, T3, T4, T>(id);
        }

        public Task<T> GetByIdAsync<T2, T3, T4, T5>(int id)
        {
            return Connection.GetAsync<T, T2, T3, T4, T5, T>(id);
        }

        public Task<T> GetByIdAsync<T2, T3, T4, T5, T6>(int id)
        {
            return Connection.GetAsync<T, T2, T3, T4, T5, T6, T>(id);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Connection.GetAllAsync<T>();
        }

        public Task<IEnumerable<T>> GetAllAsync<T2>()
        {
            return Connection.GetAllAsync<T, T2, T>();
        }

        public Task<IEnumerable<T>> GetAllAsync<T2, T3>()
        {
            return Connection.GetAllAsync<T, T2, T3, T>();
        }

        public Task<IEnumerable<T>> GetAllAsync<T2, T3, T4>()
        {
            return Connection.GetAllAsync<T, T2, T3, T4, T>();
        }

        public Task<IEnumerable<T>> GetAllAsync<T2, T3, T4, T5>()
        {
            return Connection.GetAllAsync<T, T2, T3, T4, T5, T>();
        }

        public Task<IEnumerable<T>> GetAllAsync<T2, T3, T4, T5, T6>()
        {
            return Connection.GetAllAsync<T, T2, T3, T4, T5, T6, T>();
        }

        public Task<object> InsertAsync(T entity)
        {
            return Connection.InsertAsync(entity);
        }

        public Task<bool> DeleteAsync(T entity)
        {
            return Connection.DeleteAsync(entity);
        }

        public Task<int> DeleteAllAsync()
        {
            return Connection.DeleteAllAsync<T>();
        }

        public Task<int> DeleteMultipleAsync(Expression<Func<T, bool>> predicate)
        {
            return Connection.DeleteMultipleAsync(predicate);
        }

        public Task<bool> UpdateAsync(T entity)
        {
            return Connection.UpdateAsync(entity);
        }

        public Task<IEnumerable<T>> SelectAsync(Expression<Func<T, bool>> predicate)
        {
            return Connection.SelectAsync(predicate);
        }

        public Task<IEnumerable<T>> SelectPagedAsync(Expression<Func<T, bool>> predicate,
            int pageNumber, int pageSize)
        {
            return Connection.SelectPagedAsync(predicate, pageNumber, pageSize);
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return Connection.FirstOrDefaultAsync(predicate);
        }
    }
}