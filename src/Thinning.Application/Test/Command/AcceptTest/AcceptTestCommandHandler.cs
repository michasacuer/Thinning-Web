namespace Thinning.Application.Test.Command.AcceptTest
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Thinning.Domain.Dao.Test;
    using Thinning.Service.Interfaces;

    public class AcceptTestCommandHandler : AsyncRequestHandler<AcceptTestCommand>
    {
        public ITestService _testService;

        public AcceptTestCommandHandler(ITestService testService)
        {
            _testService = testService;
        }

        protected override async Task Handle(AcceptTestCommand request, CancellationToken cancellationToken)
        {
            await _testService.AcceptTestAsync(new AcceptTestDao(request.Guid, request.Accepted));
        }
    }
}
