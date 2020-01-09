namespace Thinning.Persistence.Repository
{
    using System.Threading.Tasks;
    using Thinning.Domain;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;

    public class TestRepository : BaseRepository<Test>, ITestRepository
    {
        private readonly IThinningDbContext _thinningDbContext;

        public TestRepository(IThinningDbContext thinningDbContext)
            : base(thinningDbContext)
        {
        }

        public async Task AddAsync(Test test)
        {
            await _thinningDbContext.Tests.AddAsync(test);
        }
    }
}
