using Dommel.Repositories.Connection;

namespace Dommel.Repositories.Demo.Connection
{
    public class ConnectionHelper : IConnectionHelper
    {
        public string ConnectionString => @"Data Source=.\Database.db;Version=3;";
    }
}