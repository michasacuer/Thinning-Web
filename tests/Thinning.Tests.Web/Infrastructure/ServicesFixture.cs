namespace Thinning.Tests.Web.Infrastructure
{
    using Xunit;

    public class ServicesFixture
    {
        public ServicesFixture()
        {
            var servicesModel = ServicesFactory.CreateProperServices();
        }

        [CollectionDefinition("ServicesTestCollection")]
        public class QueryCollection : ICollectionFixture<ServicesFixture>
        {
        }
    }
}
