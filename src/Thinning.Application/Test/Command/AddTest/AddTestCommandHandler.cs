namespace Thinning.Application.Test.Command.AddTest
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddTestCommandHandler : AsyncRequestHandler<AddTestCommand>
    {
        protected override Task Handle(AddTestCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
