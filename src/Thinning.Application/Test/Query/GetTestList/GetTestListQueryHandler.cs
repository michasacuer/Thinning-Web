namespace Thinning.Application.Test.Query.GetTestList
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Thinning.Domain.Dao;
    using Thinning.Domain.Dao.Test;
    using Thinning.Service.Interfaces;

    public class GetTestListQueryHandler : IRequestHandler<GetTestListQuery, GridResponse<TestDto>>
    {
        private readonly ITestService _testService;

        public GetTestListQueryHandler(ITestService testService)
        {
            _testService = testService;
        }

        public async Task<GridResponse<TestDto>> Handle(GetTestListQuery request, CancellationToken cancellationToken)
        {
            return await _testService.GetTestList(request.Size, request.Skip, request.OrderDir, request.OrderBy);
        }
    }
}
