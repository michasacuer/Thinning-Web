namespace Thinning.Persistence.Repository
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Thinning.Domain;
    using Thinning.Domain.Dao.Image;
    using Thinning.Domain.Dao.TestLine;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;

    public class TestLineRepository : BaseRepository<TestLine>, ITestLineRepository
    {
        public TestLineRepository(IDatabaseConnection databaseConnection)
            : base(databaseConnection)
        {
        }

        public async Task<IEnumerable<TestLineDto>> GetTestLinesAsync(int testId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@testId", testId);

            using var connection = _databaseConnection.GetOpenConnection();
            var results = await connection.QueryMultipleAsync("GetTestLines", parameters, commandType: CommandType.StoredProcedure);

            var testLines = results.Read<TestLineDto>().AsList();
            var images = results.Read<TestImageDto>().AsList();

            foreach (var testLine in testLines)
            {
                testLine.Image = images.First(image => image.TestLineId == testLine.TestLineId);
            }

            return testLines;
        }
    }
}
