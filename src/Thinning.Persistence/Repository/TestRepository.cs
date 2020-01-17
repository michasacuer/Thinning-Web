namespace Thinning.Persistence.Repository
{
    using System.Data;
    using System.Threading.Tasks;
    using Dapper;
    using Thinning.Domain;
    using Thinning.Domain.Dao;
    using Thinning.Domain.Dao.Test;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;

    public class TestRepository : BaseRepository<Test>, ITestRepository
    {
        public TestRepository(IDatabaseConnection databaseConnection)
            : base(databaseConnection)
        {
        }

        public async Task<TestDetailsDto> GetTestByIdAsync(int testId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@testId", testId);

            var connection = _databaseConnection.GetOpenConnection();
            return await connection.QueryFirstOrDefaultAsync<TestDetailsDto>("GetTestById", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GridResponse<TestDto>> GetTestListAsync(int size, int skip, string orderDir, string orderBy)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@size", size);
            parameters.Add("@skip", skip);
            parameters.Add("@orderDir", orderDir);
            parameters.Add("@orderBy", orderBy);
            parameters.Add("@totalCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using var connection = _databaseConnection.GetOpenConnection();

            var tests = await connection.QueryAsync<TestDto>("GetTestList", parameters, commandType: CommandType.StoredProcedure);
            int totalCount = parameters.Get<int>("@totalCount");

            return new GridResponse<TestDto> { List = tests.AsList(), Size = totalCount };
        }
    }
}
