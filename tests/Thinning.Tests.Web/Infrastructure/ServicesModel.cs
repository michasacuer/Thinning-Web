namespace Thinning.Tests.Web.Infrastructure
{
    using Thinning.Persistence.Interfaces;

    public class ServicesModel
    {
        public IThinningDbContext Context { get; set; }
        public IDatabaseConnection Connection { get; set; }
    }
}
