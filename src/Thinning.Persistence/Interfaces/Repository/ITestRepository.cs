namespace Thinning.Persistence.Interfaces.Repository
{
    using System.Threading.Tasks;
    using Thinning.Domain;
    using Thinning.Domain.Dao;
    using Thinning.Domain.Dao.Test;

    public interface ITestRepository : IBaseRepository<Test>
    {
        Task<TestDetailsDto> GetTestByIdAsync(int testId);
        Task<GridResponse<TestDto>> GetTestListAsync(int size, int skip, string orderDir, string orderBy);
    }
}
