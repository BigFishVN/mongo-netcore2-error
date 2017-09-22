namespace Contract.Interfaces
{
    /// <summary>
    /// The DbBuilder interface.
    /// </summary>
    public interface IDbBuilder
    {
        string GetDatabaseName();

        string GetConnectionString();
    }
}