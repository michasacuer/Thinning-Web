namespace Thinning.Persistence.Repository
{
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;

    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        protected readonly IDatabaseConnection _databaseConnection;

        public BaseRepository(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
    }
}
