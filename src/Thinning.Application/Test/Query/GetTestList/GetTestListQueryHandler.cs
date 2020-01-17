namespace Thinning.Application.Test.Query.GetTestList
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Thinning.Domain.Dao;
    using Thinning.Domain.Dao.Test;
    using Thinning.Persistence.Interfaces.Repository;

    public class GetTestListQueryHandler : IRequestHandler<GetTestListQuery, GridResponse<TestDto>>
    {
        private readonly ITestRepository _testRepository;
        private readonly IPcInfoRepository _pcInfoRepository;

        public GetTestListQueryHandler(ITestRepository testRepository, IPcInfoRepository pcInfoRepository)
        {
            _testRepository = testRepository;
            _pcInfoRepository = pcInfoRepository;
        }

        public async Task<GridResponse<TestDto>> Handle(GetTestListQuery request, CancellationToken cancellationToken)
        {
            int size = request.Size == 0 ? 5 : request.Size;
            int skip = request.Skip;
            string orderDir = string.IsNullOrWhiteSpace(request.OrderDir) ? "asc" : request.OrderDir;
            string orderBy = string.IsNullOrWhiteSpace(request.OrderBy) ? "TestId" : request.OrderBy;

            var grid = await _testRepository.GetTestListAsync(size, skip, orderDir, orderBy);
            foreach (var test in grid.List)
            {
                test.TestPcInfo = await _pcInfoRepository.GetTestPcInfo(test.TestId);
            }

            return grid;
        }
    }
}
