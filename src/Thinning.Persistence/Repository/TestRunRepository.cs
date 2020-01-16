namespace Thinning.Persistence.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Thinning.Domain;
    using Thinning.Domain.Dao.TestRun;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;

    public class TestRunRepository : BaseRepository<TestRun>, ITestRunRepository
    {
        public TestRunRepository(IDatabaseConnection databaseConnection)
            : base(databaseConnection)
        {
        }

        public Task<IEnumerable<TestRunDto>> GetTestLineTestRunsAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
