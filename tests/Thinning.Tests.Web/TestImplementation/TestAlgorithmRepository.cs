namespace Thinning.Tests.Web.TestImplementation
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Thinning.Domain;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;

    public class TestAlgorithmRepository : IAlgorithmRepository
    {
        private readonly IThinningDbContext _context;

        public TestAlgorithmRepository(IThinningDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Algorithm>> GetAlgorithmsByNameAsync(IEnumerable<string> names)
        {
            var algorithmNames = string.Join(',', names);

            var algorithms = _context.Algorithms.FromSqlRaw(
                @$"
                     SELECT * From Algorithms WHERE Name IN (STRING_SPLIT({algorithmNames}, ','));        
        
                ").AsEnumerable();


            return algorithms;
        }
    }
}
