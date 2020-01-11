namespace Thinning.Persistence.Interfaces.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Thinning.Domain;

    public interface IAlgorithmRepository : IBaseRepository<Algorithm>
    {
        Task<IEnumerable<Algorithm>> GetAlgorithmsByNameAsync(IEnumerable<string> names);
        Task<bool> AddAlgorithmAsync(string algorithmName);
    }
}
