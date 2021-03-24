using System;
using System.Data;
using System.Threading.Tasks;
using Dommel.Repositories.Connection;

namespace Dommel.Repositories.UnitOfWork.Async
{
    public abstract class AsyncUnitOfWork : IAsyncUnitOfWork
    {
        private IDbConnection _connection;
        private bool _disposed;
        private IDbTransaction _transaction;

        protected AsyncUnitOfWork(IConnection connection, IConnectionHelper connectionHelper)
        {
            _connection = connection.Connection(connectionHelper.ConnectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        /// <summary>
        /// Disposing...
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Saving changes asynchronously to database.
        /// </summary>
        /// <returns>Whether the changes has been made.</returns>
        public Task<bool> SaveChangesAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    _transaction?.Commit();
                    return true;
                }
                catch
                {
                    _transaction?.Rollback();
                    return false;
                }
                finally
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = _connection.BeginTransaction();
                        ResetRepositories();
                    }
                }
            });
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }

                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
            }

            _disposed = true;
        }

        /// <summary>
        /// Resetting repositories.
        /// </summary>
        protected abstract void ResetRepositories();
    }
}