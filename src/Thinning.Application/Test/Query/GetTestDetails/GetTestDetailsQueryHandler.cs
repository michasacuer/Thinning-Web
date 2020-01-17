namespace Thinning.Application.Test.Query.GetTestDetails
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Thinning.Application.Exception;
    using Thinning.Domain.Dao.Test;
    using Thinning.Domain.Dao.TestLine;
    using Thinning.Domain.Dao.TestPcInfo;
    using Thinning.Domain.Dao.TestRun;
    using Thinning.Persistence.Interfaces.Repository;

    public class GetTestDetailsQueryHandler : IRequestHandler<GetTestDetailsQuery, TestDetailsDto>
    {
        private readonly ITestRepository _testRepository;
        private readonly IPcInfoRepository _pcInfoRepository;
        private readonly ITestLineRepository _testLineRepository;
        private readonly ITestRunRepository _testRunRepository;
        private readonly IImageRepository _imageRepository;

        public GetTestDetailsQueryHandler(
            ITestRepository testRepository,
            IPcInfoRepository pcInfoRepository,
            ITestLineRepository testLineRepository,
            ITestRunRepository testRunRepository,
            IImageRepository imageRepository)
        {
            _testRepository = testRepository;
            _pcInfoRepository = pcInfoRepository;
            _testLineRepository = testLineRepository;
            _testRunRepository = testRunRepository;
            _imageRepository = imageRepository;
        }

        public async Task<TestDetailsDto> Handle(GetTestDetailsQuery request, CancellationToken cancellationToken)
        {
            var test = await _testRepository.GetTestByIdAsync(request.TestId)
                    ?? throw new EntityNotFoundException("Test not found in dbo.Tests");

            test.PcInfo = await GetTestPcInfo(test.TestId);
            test.TestLines = await GetFullTestLines(test.TestId);
            test = await AttachImagesToTest(test);

            return test;
        }

        private async Task<PcInfoDto> GetTestPcInfo(int testId) => await _pcInfoRepository.GetTestPcInfo(testId);

        private async Task<IEnumerable<TestLineDto>> GetFullTestLines(int testId)
        {
            var testLines = await _testLineRepository.GetTestLinesAsync(testId);
            var testRuns = await _testRunRepository.GetTestLineTestRunsAsync(testLines.Select(line => line.TestLineId));

            foreach (var testLine in testLines)
            {
                testLine.AlgorithmTestRuns = new List<TestRunDto>();
                testLine.AlgorithmTestRuns = testRuns.Where(run => run.TestLinesId == testLine.TestLineId);
            }

            return testLines;
        }

        private async Task<TestDetailsDto> AttachImagesToTest(TestDetailsDto test)
        {
            var images = await _imageRepository.GetTestImagesAsync(test.TestId);
            test.BaseImage = images.First(image => image.TestImage);
            foreach (var testLine in test.TestLines)
            {
                testLine.Image = images.First(image => image.TestLineId == testLine.TestLineId);
            }

            return test;
        }
    }
}
