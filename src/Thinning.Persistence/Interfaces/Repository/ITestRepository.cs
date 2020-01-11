namespace Thinning.Persistence.Interfaces.Repository
{
    using System.Threading.Tasks;
    using Thinning.Domain;
    
    public interface ITestRepository : IBaseRepository<Test>
    {
        Task AddTestAsync(Test test);
    }
}
