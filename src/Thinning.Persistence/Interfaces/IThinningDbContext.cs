namespace Thinning.Persistence.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Thinning.Domain;
    
    public interface IThinningDbContext
    {
        DbSet<Algorithm> Algorithms { get; set; }
        DbSet<Test> Tests { get; set; }
        DbSet<TestLine> TestLines { get; set; }
        DbSet<TestRun> TestRuns { get; set; }
        DbSet<TestPcInfo> TestPcInfos { get; set; }
        DbSet<Image> Images { get; set; }
        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
