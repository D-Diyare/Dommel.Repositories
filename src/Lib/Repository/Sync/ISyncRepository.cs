using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dommel.Repositories.Repository.Sync
{
    public interface ISyncRepository<T> where T : class
    {
        T GetById(int id);
        T GetById<T2>(int id);
        T GetById<T2, T3>(int id);
        T GetById<T2, T3, T4>(int id);
        T GetById<T2, T3, T4, T5>(int id);
        T GetById<T2, T3, T4, T5, T6>(int id);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll<T2>();
        IEnumerable<T> GetAll<T2, T3>();
        IEnumerable<T> GetAll<T2, T3, T4>();
        IEnumerable<T> GetAll<T2, T3, T4, T5>();
        IEnumerable<T> GetAll<T2, T3, T4, T5, T6>();

        object Insert(T entity);

        bool Delete(T entity);
        int DeleteMultiple(Expression<Func<T, bool>> predicate);
        int DeleteAll();

        bool Update(T entity);

        IEnumerable<T> Select(Expression<Func<T, bool>> predicate);
        IEnumerable<T> SelectPaged(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize);

        T FirstOrDefault(Expression<Func<T, bool>> predicate);
    }
}