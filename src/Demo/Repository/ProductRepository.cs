using System.Data;
using Dommel.Repositories.Demo.Entities;
using Dommel.Repositories.Repository.Sync;

namespace Dommel.Repositories.Demo.Repository
{
    public class ProductRepository : SyncRepository<Product>
    {
        public ProductRepository(IDbConnection connection) : base(connection)
        {
        }
    }
}