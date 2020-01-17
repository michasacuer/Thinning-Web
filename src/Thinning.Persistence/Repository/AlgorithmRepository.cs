namespace Thinning.Persistence.Repository
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Thinning.Domain;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;

    public class AlgorithmRepository : BaseRepository<Algorithm>, IAlgorithmRepository
    {
        public AlgorithmRepository(IDatabaseConnection databaseConnection) 
            : base(databaseConnection)
        {
        }

        public async Task<IEnumerable<Algorithm>> GetAlgorithmsByNameAsync(IEnumerable<string> names)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@names", string.Join(",", names.ToArray()));

            using var connection = _databaseConnection.GetOpenConnection();   
            return await connection.QueryAsync<Algorithm>("GetAlgorithmsByName", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
