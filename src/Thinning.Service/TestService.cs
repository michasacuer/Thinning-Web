namespace Thinning.Service
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Thinning.Domain;
    using Thinning.Domain.Dao.Test;
    using Thinning.Domain.Enum;
    using Thinning.Persistence.Interfaces.Repository;
    using Thinning.Service.Interfaces;

    public class TestService : ITestService
    {
        private ITestRepository _testRepository;
        private IAlgorithmRepository _algorithmRepository;

        public TestService(ITestRepository testRepository, IAlgorithmRepository algorithmRepository)
        {
            _testRepository = testRepository;
            _algorithmRepository = algorithmRepository;
        }

        public async Task AddTestAsync(AddTestDao request)
        {
            await AlgorithmIdsToRequest(request);
            
            var test = new Test(request);
            test.ActivationStatusCode = ActivationStatusCode.Audit;
            test.ActivationUrl = new Guid().ToString();

            await _testRepository.AddTestAsync(test);
            await _testRepository.CommitAsync();
        }

        private async Task AlgorithmIdsToRequest(AddTestDao request)
        {
            var algorithmNames = request.TestLines.Select(line => line.AlgorithmName);
            var testAlgorithms = await _algorithmRepository.GetAlgorithmsByNameAsync(algorithmNames);

            var notMatchedNames = algorithmNames.Where(name => !testAlgorithms.Any(algorithm => algorithm.Name == name));
            if (notMatchedNames.Any())
            {
                foreach (string name in notMatchedNames)
                {
                    await _algorithmRepository.AddAlgorithmAsync(name);
                }

                await _algorithmRepository.CommitAsync();
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
    }
}
