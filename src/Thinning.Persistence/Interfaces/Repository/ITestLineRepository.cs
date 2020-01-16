namespace Thinning.Persistence.Interfaces.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Thinning.Domain.Dao.TestLine;

    public interface ITestLineRepository
    {
        Task<IEnumerable<TestLineDto>> GetTestLinesAsync(int testId);
    }
}
