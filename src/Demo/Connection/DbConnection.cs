using System.Data;
using System.Data.SQLite;
using Dommel.Repositories.Connection;

namespace Dommel.Repositories.Demo.Connection
{
    public class DbConnection : IConnection
    {
        public IDbConnection Connection(string connectionString)
        {
            return new SQLiteConnection(connectionString);
        }
    }
}