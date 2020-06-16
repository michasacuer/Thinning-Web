namespace Thinning.Application.Test.Command.AddTest
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Thinning.Domain;
    using Thinning.Domain.Dao.Test;
    using Thinning.Domain.Enum;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;

    public class AddTestCommandHandler : IRequestHandler<AddTestCommand>
    {
        private readonly IThinningDbContext _context;
        private readonly IAlgorithmRepository _algorithmRepository;

        public AddTestCommandHandler(IThinningDbContext context, IAlgorithmRepository algorithmRepository)
        {
            _context = context;
            _algorithmRepository = algorithmRepository;
        }

        public async Task<Unit> Handle(AddTestCommand request, CancellationToken cancellationToken)
        {
            await AlgorithmIdsToRequestAsync(request);

            var test = new Test(new AddTestDao(request.Sent, request.TestLines, request.PcInfo, request.Images));
            test.ActivationStatusCode = ActivationStatusCode.Audit;
            test.ActivationUrl = Guid.NewGuid().ToString().Replace('-', '&');

            await _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();

            MapImagesToTestLines(test);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }

        private async Task AlgorithmIdsToRequestAsync(AddTestCommand request)
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
