namespace Thinning.Persistence.Repository
{
    using System.Threading;
    using System.Threading.Tasks;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;

    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        protected readonly IThinningDbContext _thinningDbContext;

        public BaseRepository(IThinningDbContext thinningDbContext)
        {
            _thinningDbContext = thinningDbContext;
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _thinningDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
