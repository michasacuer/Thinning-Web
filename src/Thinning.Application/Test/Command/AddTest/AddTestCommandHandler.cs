namespace Thinning.Application.Test.Command.AddTest
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Thinning.Domain.Dao.Test;
    using Thinning.Service.Interfaces;

    public class AddTestCommandHandler : AsyncRequestHandler<AddTestCommand>
    {
        public ITestService _testService;

        public AddTestCommandHandler(ITestService testService)
        {
            _testService = testService;
        }

        protected override async Task Handle(AddTestCommand request, CancellationToken cancellationToken)
        {
            await _testService.AddTestAsync(new AddTestDao(request.Sent, request.TestLines, request.PcInfo, request.Images));
        }
    }
}
