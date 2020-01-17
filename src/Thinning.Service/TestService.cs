namespace Thinning.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Thinning.Domain;
    using Thinning.Domain.Dao;
    using Thinning.Domain.Dao.Test;
    using Thinning.Domain.Dao.TestRun;
    using Thinning.Domain.Enum;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;
    using Thinning.Service.Exception;
    using Thinning.Service.Interfaces;

    public class TestService : ITestService
    {
        private ITestRepository _testRepository;
        private IAlgorithmRepository _algorithmRepository;
        private IPcInfoRepository _pcInfoRepository;
        private ITestLineRepository _testLineRepository;
        private ITestRunRepository _testRunRepository;
        private IThinningDbContext _context;

        public TestService(
            ITestRepository testRepository,
            IAlgorithmRepository algorithmRepository,
            IThinningDbContext context,
            IPcInfoRepository pcInfoRepository,
            ITestLineRepository testLineRepository,
            ITestRunRepository testRunRepository)
        {
            _testRepository = testRepository;
            _algorithmRepository = algorithmRepository;
            _pcInfoRepository = pcInfoRepository;
            _testLineRepository = testLineRepository;
            _testRunRepository = testRunRepository;
            _context = context;
        }

        public async Task AcceptTestAsync(AcceptTestDao request)
        {
            var test = await _context.Tests.FirstOrDefaultAsync(test => test.ActivationUrl == request.Guid)
                    ?? throw new EntityNotFoundException($"Entity from dbo.Tests with Guid {request.Guid} not found");

            if (test.ActivationStatusCode == ActivationStatusCode.Audit)
            {
                test.ActivationStatusCode = request.Accepted ? ActivationStatusCode.Accepted : ActivationStatusCode.Rejected;
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddTestAsync(AddTestDao request)
        {
            await AlgorithmIdsToRequest(request);
            
            var test = new Test(request);
            test.ActivationStatusCode = ActivationStatusCode.Audit;
            test.ActivationUrl = Guid.NewGuid().ToString().Replace('-', '&');

            await _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();

            MapImagesToTestLines(test);
            await _context.SaveChangesAsync();
        }

        public async Task<TestDetailsDto> GetTestDetailsAsync(int testId)
        {
            var test = await _testRepository.GetTestByIdAsync(testId)
                    ?? throw new EntityNotFoundException("Test not found in dbo.Tests");

            test.PcInfo = await _pcInfoRepository.GetTestPcInfo(testId);
            test.TestLines = await _testLineRepository.GetTestLinesAsync(testId);

            var testRuns = await _testRunRepository.GetTestLineTestRunsAsync(test.TestLines.Select(line => line.TestLineId));
            foreach (var testLine in test.TestLines)
            {
                testLine.AlgorithmTestRuns = new List<TestRunDto>();
                testLine.AlgorithmTestRuns = testRuns.Where(run => run.TestLinesId == testLine.TestLineId);
            }

            return test;
        }

        public async Task<GridResponse<TestDto>> GetTestListAsync(int size, int skip, string orderDir, string orderBy)
        {
            size = size == 0 ? 5 : size;
            orderDir = string.IsNullOrWhiteSpace(orderDir) ? "asc" : orderDir;
            orderBy = string.IsNullOrWhiteSpace(orderBy) ? "TestId" : orderBy;

            var grid = await _testRepository.GetTestListAsync(size, skip, orderDir, orderBy);
            foreach (var test in grid.List)
            {
                test.TestPcInfo = await _pcInfoRepository.GetTestPcInfo(test.TestId);
            }

            return grid;
        }

        private async Task AlgorithmIdsToRequest(AddTestDao request)
        {
            var algorithmNames = request.Images.Select(image => image.AlgorithmName);
            var testAlgorithms = await _algorithmRepository.GetAlgorithmsByNameAsync(algorithmNames);

            var notMatchedNames = algorithmNames.Where(name => !testAlgorithms.Any(algorithm => algorithm.Name == name));
            if (notMatchedNames.Any())
            {
                foreach (string name in notMatchedNames)
                {
                    await _context.Algorithms.AddAsync(new Algorithm { Name = name });
                }

                await _context.SaveChangesAsync();
                testAlgorithms = await _algorithmRepository.GetAlgorithmsByNameAsync(algorithmNames);
            }

            foreach (var testLine in request.TestLines)
            {
                testLine.AlgorithmId =
                    testAlgorithms.Where(algorithm => algorithm.Name == testLine.AlgorithmName).First().AlgorithmId;
            }

            foreach (var image in request.Images)
            {
                image.AlgorithmId =
                    testAlgorithms.Where(algorithm => algorithm.Name == image.AlgorithmName).First().AlgorithmId;
            }
        }

        private void MapImagesToTestLines(Test test)
        {
            foreach (var image in test.Images)
            {
                if (!image.TestImage)
                {
                    image.TestLineId =
                        test.TestLines.Where(testLine => testLine.TestId == image.TestId && testLine.AlgorithmId == image.AlgorithmId)
                                      .First().TestLineId;
                }
            }
        }
    }
}
