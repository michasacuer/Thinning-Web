namespace Thinning.Persistence.Interfaces.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Thinning.Domain.Dao.Image;

    public interface IImageRepository
    {
        Task<IEnumerable<TestImageDto>> GetTestImagesAsync(int testId);
    }
}
