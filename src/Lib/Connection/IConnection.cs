using System.Data;

namespace Dommel.Repositories.Connection
{
    public interface IConnection
    {
        /// <summary>
        /// IDbConnection such as SqlConnection, MySqlConnection, SqliteConnection ...
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        /// <returns>Connection based on given details.</returns>
        IDbConnection Connection(string connectionString);
    }
}