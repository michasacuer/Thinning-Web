namespace Thinning.Persistence.Repository
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using Dapper;
    using Thinning.Domain;
    using Thinning.Domain.Dao.TestRun;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;

    public class TestRunRepository : BaseRepository<TestRun>, ITestRunRepository
    {
        public TestRunRepository(IDatabaseConnection databaseConnection)
            : base(databaseConnection)
        {
        }

        public async Task<IEnumerable<TestRunDto>> GetTestLineTestRunsAsync(IEnumerable<int> testLineIds)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            foreach (int id in testLineIds)
            {
                dataTable.Rows.Add(id);
            }

            var connection = _databaseConnection.GetOpenConnection();

            return await connection.QueryAsync<TestRunDto>(
                "GetTestRunsFromTestLines",
                new { Ids = dataTable.AsTableValuedParameter("dbo.IntTableType") },
                commandType: CommandType.StoredProcedure);
        }
    }
}
