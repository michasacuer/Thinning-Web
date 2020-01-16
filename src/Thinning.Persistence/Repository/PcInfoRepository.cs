namespace Thinning.Persistence.Repository
{
    using System.Data;
    using System.Threading.Tasks;
    using Dapper;
    using Thinning.Domain;
    using Thinning.Domain.Dao.TestPcInfo;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;

    public class PcInfoRepository : BaseRepository<TestPcInfo>, IPcInfoRepository
    {
        public PcInfoRepository(IDatabaseConnection databaseConnection) 
            : base(databaseConnection)
        {
        }

        public async Task<PcInfoDto> GetTestPcInfo(int testId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@testId", testId);

            var connection = _databaseConnection.GetOpenConnection();
            return await connection.QueryFirstAsync<PcInfoDto>("GetPcInfo", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
