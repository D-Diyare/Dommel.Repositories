using Dommel.Repositories.Connection;
using Dommel.Repositories.Demo.Entities;
using Dommel.Repositories.Demo.Repository;
using Dommel.Repositories.Repository.Sync;
using Dommel.Repositories.UnitOfWork.Sync;

namespace Dommel.Repositories.Demo.UnitOfWork
{
    public class AppDbContext : SyncUnitOfWork
    {
        private ISyncRepository<Category> _categories;

        private ISyncRepository<Product> _products;


        public AppDbContext(IConnection connection, IConnectionHelper connectionHelper)
            : base(connection, connectionHelper)
        {
        }

        public ISyncRepository<Product> Products =>
            _products ?? new ProductRepository(Connection);

        public ISyncRepository<Category> Categories =>
            _categories ?? new CategoryRepository(Connection);


        protected override void ResetRepositories()
        {
            _products = null;
            _categories = null;
        }
    }
}