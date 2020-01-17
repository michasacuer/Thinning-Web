namespace Thinning.Tests.Web.Test.Command
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Shouldly;
    using Xunit;
    using Thinning.Application.Test.Command.AddTest;
    using Thinning.Domain;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Repository;
    using Thinning.Tests.Web.Infrastructure;
    using Thinning.Tests.Web.TestImplementation;
    using Thinning.Domain.Dao.Image;
    using Thinning.Domain.Dao.TestLine;
    using Thinning.Domain.Dao.TestPcInfo;

    [Collection("ServicesTestCollection")]
    public class AddTestCommandTests
    {
        private readonly IThinningDbContext _context;

        public AddTestCommandTests(ServicesFixture fixture)
        {
            _context = fixture.Context;
        }
    }
}
