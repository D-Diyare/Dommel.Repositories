using System.Data;
using Dommel.Repositories.Demo.Entities;
using Dommel.Repositories.Repository.Sync;

namespace Dommel.Repositories.Demo.Repository
{
    public class CategoryRepository : SyncRepository<Category>
    {
        public CategoryRepository(IDbConnection connection) : base(connection)
        {
        }
    }
}