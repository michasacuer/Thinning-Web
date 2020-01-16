namespace Thinning.Persistence.Interfaces.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Thinning.Domain.Dao.TestRun;

    public interface ITestRunRepository
    {;
        Task<IEnumerable<TestRunDto>> GetTestLineTestRunsAsync()
    }
}
