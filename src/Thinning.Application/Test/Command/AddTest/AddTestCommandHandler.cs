namespace Thinning.Application.Test.Command.AddTest
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Thinning.Domain.Dao.Test;
    using Thinning.Service.Interfaces;

    public class AddTestCommandHandler : IRequestHandler<AddTestCommand>
    {
        public ITestService _testService;

        public AddTestCommandHandler(ITestService testService)
        {
            _testService = testService;
        }

        public async Task<Unit> Handle(AddTestCommand request, CancellationToken cancellationToken)
        {
            await _testService.AddTestAsync(new AddTestDao(request.Sent, request.TestLines, request.PcInfo, request.Images));

            return Unit.Value;
        }
    }
}
