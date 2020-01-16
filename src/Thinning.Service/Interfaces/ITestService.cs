namespace Thinning.Service.Interfaces
{
    using System.Threading.Tasks;
    using Thinning.Domain.Dao;
    using Thinning.Domain.Dao.Test;

    public interface ITestService
    {
        Task AddTestAsync(AddTestDao request);
        Task AcceptTestAsync(AcceptTestDao request);
        Task<GridResponse<TestDto>> GetTestList(int size, int skip, string orderDir, string orderBy);
    }
}
