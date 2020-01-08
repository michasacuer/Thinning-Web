namespace Thinning.Repository.Interfaces
{
    using System.Data;
    
    public interface IDatabaseConnection
    {
        IDbConnection GetOpenConnection();
    }
}
