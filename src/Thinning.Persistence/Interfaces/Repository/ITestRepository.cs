namespace Thinning.Persistence.Interfaces.Repository
{
    using System.Threading.Tasks;
    using Thinning.Domain;
    using Thinning.Domain.Dao;
    using Thinning.Domain.Dao.Test;

    public interface ITestRepository : IBaseRepository<Test>
    {
        Task<Test> GetTestById(int testId);
        Task<GridResponse<TestDto>> GetTestList(int size, int skip, string orderDir, string orderBy);
    }
}
