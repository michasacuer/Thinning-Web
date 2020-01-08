namespace Thinning.Web
{
    using Autofac;
    using Thinning.Persistence;
    using Thinning.Persistence.Interfaces;

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
        }
    }
}
