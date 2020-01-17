namespace Thinning.Application.Test.Command.AcceptTest
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Thinning.Application.Exception;
    using Thinning.Domain.Enum;
    using Thinning.Persistence.Interfaces;

    public class AcceptTestCommandHandler : IRequestHandler<AcceptTestCommand>
    {
        public readonly IThinningDbContext _context;

        public AcceptTestCommandHandler(IThinningDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AcceptTestCommand request, CancellationToken cancellationToken)
        {
            var test = await _context.Tests.FirstOrDefaultAsync(test => test.ActivationUrl == request.Guid)
                    ?? throw new EntityNotFoundException($"Entity from dbo.Tests with Guid {request.Guid} not found");

            if (test.ActivationStatusCode == ActivationStatusCode.Audit)
            {
                test.ActivationStatusCode = request.Accepted ? ActivationStatusCode.Accepted : ActivationStatusCode.Rejected;
                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
