namespace Thinning.Persistence
{
    using System.Threading.Tasks;
    using Dapper;
    using Thinning.Persistence.Interfaces;

    public class DatabaseCreation : IDatabaseCreation
    {
        private readonly IDatabaseConnection _connection;

        public DatabaseCreation(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> CreateDatabase()
        {
            var connection = _connection.GetOpenConnection();
        
            int created = await connection.ExecuteAsync(SqlQuery.CreateDatabase);

            throw new System.NotImplementedException();
        }
    }
}
