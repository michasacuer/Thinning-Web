namespace Thinning.Persistence.Interfaces.Repository
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IBaseRepository<T>
        where T : class
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
