using Dommel.Repositories.Connection;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Dommel.Repositories.UnitOfWork.Async
{
    public abstract class AsyncUnitOfWork : IAsyncUnitOfWork
    {
        protected IDbConnection Connection;
        private bool _disposed;
        private IDbTransaction _transaction;

        protected AsyncUnitOfWork(IConnection connection, IConnectionHelper connectionHelper)
        {
            Connection = connection.Connection(connectionHelper.ConnectionString);
            Connection.Open();
            _transaction = Connection.BeginTransaction();
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
                        _transaction = Connection.BeginTransaction();
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

                if (Connection != null)
                {
                    Connection.Dispose();
                    Connection = null;
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