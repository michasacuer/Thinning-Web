namespace Thinning.Tests.Web.Infrastructure
{
    using Xunit;
    using Thinning.Persistence.Interfaces;

    public class ServicesFixture
    {
        public IThinningDbContext Context { get; private set; }
        public IDatabaseConnection Connection { get; private set; }

        public ServicesFixture()
        {
            var servicesModel = ServicesFactory.CreateProperServices();
            Context = servicesModel.Context;
            Connection = servicesModel.Connection;
        }

        [CollectionDefinition("ServicesTestCollection")]
        public class QueryCollection : ICollectionFixture<ServicesFixture>
        {
        }
    }
}
