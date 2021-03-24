namespace Dommel.Repositories.Connection
{
    public interface IConnectionHelper
    {
        /// <summary>
        /// Connection string needs to connect to external database.
        /// </summary>
        string ConnectionString { get; }
    }
}