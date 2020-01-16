namespace Thinning.Application.Test.Query.GetTestDetails
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Thinning.Domain.Dao.Test;
    using Thinning.Service.Interfaces;

    public class GetTestDetailsQueryHandler : IRequestHandler<GetTestDetailsQuery, TestDetailsDto>
    {
        private readonly ITestService _testService;

        public GetTestDetailsQueryHandler(ITestService testService)
        {
            _testService = testService;
        }

        public async Task<TestDetailsDto> Handle(GetTestDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _testService.GetTestDetailsAsync(request.TestId);
        }
    }
}
