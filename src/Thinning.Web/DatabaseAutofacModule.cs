namespace Thinning.Web
{
    using Autofac;
    using Thinning.Persistence;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;
    using Thinning.Persistence.Repository;

    public class DatabaseAutofacModule : Module
    {
        private readonly string _connectionString;

        public DatabaseAutofacModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new DatabaseConnection(_connectionString))
                .As<IDatabaseConnection>()
                .InstancePerLifetimeScope();

            builder.Register(c => new TestRepository(new DatabaseConnection(_connectionString)))
                .As<ITestRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new TestLineRepository(new DatabaseConnection(_connectionString)))
                .As<ITestLineRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new AlgorithmRepository(new DatabaseConnection(_connectionString)))
                .As<IAlgorithmRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new TestRunRepository(new DatabaseConnection(_connectionString)))
                .As<ITestRunRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new PcInfoRepository(new DatabaseConnection(_connectionString)))
                .As<IPcInfoRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
