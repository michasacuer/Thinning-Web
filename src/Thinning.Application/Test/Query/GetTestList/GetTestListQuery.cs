namespace Thinning.Application.Test.Query.GetTestList
{
    using MediatR;
    using Thinning.Domain.Dao;
    using Thinning.Domain.Dao.Test;

    public class GetTestListQuery : PaginationModel, IRequest<GridResponse<TestDto>>
    {
    }
}
