namespace Thinning.Persistence.Interfaces
{
    using System.Threading.Tasks;
    
    public interface IDatabaseCreation
    {
        Task<bool> CreateDatabase();
    }
}
