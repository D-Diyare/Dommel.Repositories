using System;
using System.Threading.Tasks;

namespace Dommel.Repositories.UnitOfWork.Async
{
    public interface IAsyncUnitOfWork : IDisposable
    {
        Task<bool> SaveChangesAsync();
    }
}