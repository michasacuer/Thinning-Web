namespace Thinning.Service
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Thinning.Domain;
    using Thinning.Domain.Dao.Test;
    using Thinning.Domain.Enum;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;
    using Thinning.Service.Exception;
    using Thinning.Service.Interfaces;

    public class TestService : ITestService
    {
        private ITestRepository _testRepository;
        private IAlgorithmRepository _algorithmRepository;
        private IThinningDbContext _context;

        public TestService(ITestRepository testRepository, IAlgorithmRepository algorithmRepository, IThinningDbContext context)
        {
            _testRepository = testRepository;
            _algorithmRepository = algorithmRepository;
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
