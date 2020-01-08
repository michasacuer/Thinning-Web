namespace Thinning.Persistence.Interfaces
{
    using System.Data;
    
    public interface IDatabaseConnection
    {
        IDbConnection GetOpenConnection();
    }
}
