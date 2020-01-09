namespace Thinning.Persistence.Interfaces.Repository
{
    using System.Threading.Tasks;
    using Thinning.Domain;
    
    public interface ITestRepository
    {
        Task AddAsync(Test test);
    }
}
