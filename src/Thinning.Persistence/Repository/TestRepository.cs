namespace Thinning.Persistence.Repository
{
    using System.Data;
    using System.Threading.Tasks;
    using Dapper;
    using Thinning.Domain;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;

    public class TestRepository : BaseRepository<Test>, ITestRepository
    {
        public TestRepository(IDatabaseConnection databaseConnection)
            : base(databaseConnection)
        {
        }

        public async Task<Test> GetTestById(int testId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@testId", testId);

            var connection = _databaseConnection.GetOpenConnection();
            return await connection.QueryFirstOrDefaultAsync<Test>("GetTestById", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
