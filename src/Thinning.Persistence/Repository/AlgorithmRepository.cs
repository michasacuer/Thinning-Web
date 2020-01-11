﻿namespace Thinning.Persistence.Repository
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using Dapper;
    using Thinning.Domain;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;

    public class AlgorithmRepository : BaseRepository<Algorithm>, IAlgorithmRepository
    {
        private IDatabaseConnection _connection;

        public AlgorithmRepository(IThinningDbContext thinningDbContext, IDatabaseConnection connection) 
            : base(thinningDbContext)
        {
            _connection = connection;
        }

        public Task<bool> AddAlgorithmAsync(string algorithmName)
        {

        }

        public async Task<IEnumerable<Algorithm>> GetAlgorithmsByNameAsync(IEnumerable<string> names)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@names", names);

            var connection = _connection.GetOpenConnection();   
            return await connection.QueryAsync<Algorithm>("GetAlgorithmsByName", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
