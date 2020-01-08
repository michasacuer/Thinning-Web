namespace Thinning.Persistence.Interfaces
{
    using Microsoft.EntityFrameworkCore;
    using Thinning.Domain;
    
    public interface IThinningDbContext
    {
        DbSet<Algorithm> Algorithms { get; set; }
        DbSet<Test> Tests { get; set; }
        DbSet<TestLine> TestLines { get; set; }
        DbSet<TestRun> TestRuns { get; set; }
        DbSet<TestPcInfo> TestPcInfos { get; set; }
        DbSet<Image> Images { get; set; }
    }
}
