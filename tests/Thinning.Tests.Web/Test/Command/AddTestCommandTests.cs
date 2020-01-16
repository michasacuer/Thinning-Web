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
    using Thinning.Service;
    using Thinning.Service.Interfaces;
    using Thinning.Tests.Web.Infrastructure;
    using Thinning.Tests.Web.TestImplementation;
    using Thinning.Domain.Dao.Image;
    using Thinning.Domain.Dao.TestLine;
    using Thinning.Domain.Dao.TestPcInfo;

    [Collection("ServicesTestCollection")]
    public class AddTestCommandTests
    {
        private readonly ITestService _testService;
        private readonly IThinningDbContext _context;

        public AddTestCommandTests(ServicesFixture fixture)
        {
            _context = fixture.Context;
            _testService = new TestService(
                new TestRepository(fixture.Connection),
                new TestAlgorithmRepository(fixture.Context),
                fixture.Context);
        }

        public async Task AddTestShouldAddTestIntoDatabase()
        {
            var images = new List<ImageDao>();
            images.Add(new ImageDao
            {
                AlgorithmName = "Algorithm1"
            });
            images.Add(new ImageDao
            {
                AlgorithmName = "Algorithm2"
            });

            var command = new AddTestCommand
            {
                Sent = DateTime.Now,
                TestLines = new List<TestLineDao>(),
                Images = images,
                PcInfo = new PcInfoDao()
            };

            var commandHandler = new AddTestCommandHandler(_testService);
            await commandHandler.Handle(command, CancellationToken.None);
        }
    }
}
