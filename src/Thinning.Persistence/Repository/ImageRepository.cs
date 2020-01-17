namespace Thinning.Persistence.Repository
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using Dapper;
    using Thinning.Domain;
    using Thinning.Domain.Dao.Image;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;

    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(IDatabaseConnection databaseConnection)
            : base(databaseConnection)
        {
        }

        public async Task<IEnumerable<TestImageDto>> GetTestImagesAsync(int testId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@testId", testId);

            using var connection = _databaseConnection.GetOpenConnection();
            return await connection.QueryAsync<TestImageDto>("GetTestImages", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
