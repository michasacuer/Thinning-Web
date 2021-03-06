﻿namespace Thinning.Tests.Web.Test.Command
{
    using System.Threading;
    using System.Threading.Tasks;
    using Shouldly;
    using Xunit;
    using Thinning.Application.Exception;
    using Thinning.Application.Test.Command.AcceptTest;
    using Thinning.Domain.Enum;
    using Thinning.Persistence.Interfaces;
    using Thinning.Tests.Web.Infrastructure;

    [Collection("ServicesTestCollection")]
    public class AcceptTestCommandTests
    {
        private readonly IThinningDbContext _context;

        public AcceptTestCommandTests(ServicesFixture fixture)
        {
            _context = fixture.Context;
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

            var commandHandler = new AcceptTestCommandHandler(_context);
            await commandHandler.Handle(command, CancellationToken.None);

            var acceptedTest = _context.Tests.Find(1);
            acceptedTest.ShouldNotBeNull();
            acceptedTest.ActivationStatusCode.ShouldBe(ActivationStatusCode.Accepted);
        }

        [Fact]
        public async Task AcceptComandShouldThrowIfTestNotFound()
        {
            var command = new AcceptTestCommand
            {
                Accepted = true,
                Guid = "SomeRandom"
            };

            var commandHandler = new AcceptTestCommandHandler(_context);
            await commandHandler.Handle(command, CancellationToken.None).ShouldThrowAsync<EntityNotFoundException>();
        }
    }
}
