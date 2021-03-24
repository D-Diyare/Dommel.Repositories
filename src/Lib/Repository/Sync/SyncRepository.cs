using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace Dommel.Repositories.Repository.Sync
{
    public class SyncRepository<T> : ISyncRepository<T> where T : class
    {
        public SyncRepository(IDbConnection connection)
        {
            Connection = connection;
        }

        public IDbConnection Connection { get; set; }

        public T GetById(int id)
        {
            return Connection.Get<T>(id);
        }

        public T GetById<T2>(int id)
        {
            return Connection.Get<T, T2, T>(id);
        }

        public T GetById<T2, T3>(int id)
        {
            return Connection.Get<T, T2, T3, T>(id);
        }

        public T GetById<T2, T3, T4>(int id)
        {
            return Connection.Get<T, T2, T3, T4, T>(id);
        }

        public T GetById<T2, T3, T4, T5>(int id)
        {
            return Connection.Get<T, T2, T3, T4, T5, T>(id);
        }

        public T GetById<T2, T3, T4, T5, T6>(int id)
        {
            return Connection.Get<T, T2, T3, T4, T5, T6, T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Connection.GetAll<T>();
        }

        public IEnumerable<T> GetAll<T2>()
        {
            return Connection.GetAll<T, T2, T>();
        }

        public IEnumerable<T> GetAll<T2, T3>()
        {
            return Connection.GetAll<T, T2, T3, T>();
        }

        public IEnumerable<T> GetAll<T2, T3, T4>()
        {
            return Connection.GetAll<T, T2, T3, T4, T>();
        }

        public IEnumerable<T> GetAll<T2, T3, T4, T5>()
        {
            return Connection.GetAll<T, T2, T3, T4, T5, T>();
        }

        public IEnumerable<T> GetAll<T2, T3, T4, T5, T6>()
        {
            return Connection.GetAll<T, T2, T3, T4, T5, T6, T>();
        }

        public object Insert(T entity)
        {
            return Connection.Insert(entity);
        }

        public bool Delete(T entity)
        {
            return Connection.Delete(entity);
        }

        public int DeleteMultiple(Expression<Func<T, bool>> predicate)
        {
            return Connection.DeleteMultiple(predicate);
        }

        public int DeleteAll()
        {
            return Connection.DeleteAll<T>();
        }

        public bool Update(T entity)
        {
            return Connection.Update(entity);
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> predicate)
        {
            return Connection.Select(predicate);
        }

        public IEnumerable<T> SelectPaged(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize)
        {
            return Connection.SelectPaged(predicate, pageNumber, pageSize);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Connection.FirstOrDefault(predicate);
        }
    }
}