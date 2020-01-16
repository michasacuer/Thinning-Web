namespace Thinning.Persistence.Interfaces.Repository
{
    using System.Threading.Tasks;
    using Thinning.Domain.Dao.TestPcInfo;

    public interface IPcInfoRepository
    {
        Task<PcInfoDto> GetTestPcInfo(int testId);
    }
}
