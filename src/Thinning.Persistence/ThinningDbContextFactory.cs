namespace Thinning.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Thinning.Persistence.Infrastructure;
    
    public class ThinningDbContextFactory : DesignTimeDbContextFactoryBase<ThinningDbContext>
    {
        protected override ThinningDbContext CreateNewInstance(DbContextOptions<ThinningDbContext> options)
        {
            return new ThinningDbContext(options);
        }
    }
}
