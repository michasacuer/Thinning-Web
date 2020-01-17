namespace Thinning.Application.Test.Query.GetTestDetails
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Thinning.Application.Exception;
    using Thinning.Domain.Dao.Test;
    using Thinning.Domain.Dao.TestRun;
    using Thinning.Persistence.Interfaces.Repository;

    public class GetTestDetailsQueryHandler : IRequestHandler<GetTestDetailsQuery, TestDetailsDto>
    {
        private readonly ITestRepository _testRepository;
        private readonly IPcInfoRepository _pcInfoRepository;
        private readonly ITestLineRepository _testLineRepository;
        private readonly ITestRunRepository _testRunRepository;

        public GetTestDetailsQueryHandler(
            ITestRepository testRepository,
            IPcInfoRepository pcInfoRepository,
            ITestLineRepository testLineRepository,
            ITestRunRepository testRunRepository)
        {
            _testRepository = testRepository;
            _pcInfoRepository = pcInfoRepository;
            _testLineRepository = testLineRepository;
            _testRunRepository = testRunRepository;
        }

        public async Task<TestDetailsDto> Handle(GetTestDetailsQuery request, CancellationToken cancellationToken)
        {
            var test = await _testRepository.GetTestByIdAsync(request.TestId)
                    ?? throw new EntityNotFoundException("Test not found in dbo.Tests");

            test.PcInfo = await _pcInfoRepository.GetTestPcInfo(request.TestId);
            test.TestLines = await _testLineRepository.GetTestLinesAsync(request.TestId);

            var testRuns = await _testRunRepository.GetTestLineTestRunsAsync(test.TestLines.Select(line => line.TestLineId));
            foreach (var testLine in test.TestLines)
            {
                testLine.AlgorithmTestRuns = new List<TestRunDto>();
                testLine.AlgorithmTestRuns = testRuns.Where(run => run.TestLinesId == testLine.TestLineId);
            }

            return test;
        }
    }
}
