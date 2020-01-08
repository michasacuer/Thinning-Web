namespace Thinning.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Thinning.Domain;
    using Thinning.Persistence.Interfaces;

    public class ThinningDbContext : DbContext, IThinningDbContext
    {
        public ThinningDbContext(DbContextOptions<ThinningDbContext> options)
            : base(options)
        {
        }

        public DbSet<Algorithm> Algorithms { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestLine> TestLines { get; set; }
        public DbSet<TestRun> TestRuns { get; set; }
        public DbSet<TestPcInfo> TestPcInfos { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ThinningDbContext).Assembly);
        }
    }
}
