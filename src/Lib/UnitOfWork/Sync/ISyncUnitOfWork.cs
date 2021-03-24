using System;

namespace Dommel.Repositories.UnitOfWork.Sync
{
    public interface ISyncUnitOfWork : IDisposable
    {
        bool SaveChanges();
    }
}