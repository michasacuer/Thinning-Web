namespace Thinning.Persistence.Repository
{
    using System.Threading.Tasks;
    using Thinning.Domain;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;

    public class TestRepository : BaseRepository<Test>, ITestRepository
    {
        public TestRepository(IThinningDbContext thinningDbContext)
            : base(thinningDbContext)
        {
        }

        public async Task AddTestAsync(Test test)
        {
            await _thinningDbContext.Tests.AddAsync(test);
        }
    }
}
