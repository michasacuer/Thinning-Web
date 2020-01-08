namespace Thinning.Web
{
    using Autofac;
    using Thinning.Repository;
    using Thinning.Repository.Interfaces;

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
