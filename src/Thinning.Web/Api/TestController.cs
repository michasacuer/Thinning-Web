namespace Thinning.Web.Api
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Thinning.Application.Test.Command.AcceptTest;
    using Thinning.Application.Test.Command.AddTest;
    using Thinning.Application.Test.Query.GetTestDetails;
    using Thinning.Application.Test.Query.GetTestList;
    using Thinning.Domain.Dao;
    using Thinning.Domain.Dao.Test;

    public class TestController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTest(AddTestCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("audit")]
        public async Task<IActionResult> AddTest(AcceptTestCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("list")]
        public async Task<ActionResult<GridResponse<TestDto>>> GetTestList(GetTestListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("details/{testId}")]
        public async Task<ActionResult<TestDetailsDto>> GetTestDetails(int testId)
        {
            return Ok(await Mediator.Send(new GetTestDetailsQuery { TestId = testId }));
        }
    }
}
