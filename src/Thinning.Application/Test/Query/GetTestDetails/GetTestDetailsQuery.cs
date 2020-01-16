namespace Thinning.Application.Test.Query.GetTestDetails
{
    using MediatR;
    using Thinning.Domain.Dao.Test;

    public class GetTestDetailsQuery : IRequest<TestDetailsDto>
    {
        public int TestId { get; set; }
    }
}
