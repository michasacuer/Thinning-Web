namespace Thinning.Persistence
{
    using System.IO;
    using System.Text;
    using Dapper;
    using Thinning.Persistence.Interfaces;
    
    public class CreateProcedures
    {
        private readonly IDatabaseConnection _connection;

        public CreateProcedures(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public void Execute()
        {
            var files = Directory.GetFiles(
                    Directory.GetCurrentDirectory() + string.Format("{0}..{0}Thinning.Persistence\\Procedures",
                    Path.DirectorySeparatorChar));

            using var connection = _connection.GetOpenConnection();
            foreach (string file in files)
            {
                connection.Execute(File.ReadAllText(file, Encoding.UTF8));
            }
        }
    }
}
