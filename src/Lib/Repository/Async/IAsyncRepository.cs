using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dommel.Repositories.Repository.Async
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync<T2>(int id);
        Task<T> GetByIdAsync<T2, T3>(int id);
        Task<T> GetByIdAsync<T2, T3, T4>(int id);
        Task<T> GetByIdAsync<T2, T3, T4, T5>(int id);
        Task<T> GetByIdAsync<T2, T3, T4, T5, T6>(int id);

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync<T2>();
        Task<IEnumerable<T>> GetAllAsync<T2, T3>();
        Task<IEnumerable<T>> GetAllAsync<T2, T3, T4>();
        Task<IEnumerable<T>> GetAllAsync<T2, T3, T4, T5>();
        Task<IEnumerable<T>> GetAllAsync<T2, T3, T4, T5, T6>();

        Task<object> InsertAsync(T entity);

        Task<bool> DeleteAsync(T entity);
        Task<int> DeleteMultipleAsync(Expression<Func<T, bool>> predicate);
        Task<int> DeleteAllAsync();

        Task<bool> UpdateAsync(T entity);


        Task<IEnumerable<T>> SelectAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> SelectPagedAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}