namespace Thinning.Tests.Web.Test.Command
{
    using System.Threading;
    using System.Threading.Tasks;
    using Shouldly;
    using Xunit;
    using Thinning.Application.Test.Command.AcceptTest;
    using Thinning.Domain.Enum;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Repository;
    using Thinning.Service;
    using Thinning.Service.Interfaces;
    using Thinning.Tests.Web.Infrastructure;

    [Collection("ServicesTestCollection")]
    public class AcceptTestCommandTests
    {
        private readonly ITestService _testService;
        private readonly IThinningDbContext _context;

        public AcceptTestCommandTests(ServicesFixture fixture)
        {
            _context = fixture.Context;
            _testService = new TestService(
                new TestRepository(fixture.Connection),
                new AlgorithmRepository(fixture.Connection),
                fixture.Context);
        }

        [Fact]
        public async Task AcceptCommandShouldChangeTestStatusCodeToAccepted()
        {
            var test = _context.Tests.Find(1);
            var command = new AcceptTestCommand
            {
                Accepted = true,
                Guid = test.ActivationUrl
            };

            var commandHandler = new AcceptTestCommandHandler(_testService);
            await commandHandler.Handle(command, CancellationToken.None);

            var acceptedTest = _context.Tests.Find(1);
            acceptedTest.ShouldNotBeNull();
            acceptedTest.ActivationStatusCode.ShouldBe(ActivationStatusCode.Accepted);
        }
    }
}
