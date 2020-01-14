namespace Thinning.Application.Test.Command.AcceptTest
{
    using MediatR;
    
    public class AcceptTestCommand : IRequest
    {
        public string Guid { get; set; }
        public bool Accepted { get; set; }
    }
}
