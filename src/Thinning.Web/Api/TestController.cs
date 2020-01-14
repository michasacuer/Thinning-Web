﻿namespace Thinning.Web.Api
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Thinning.Application.Test.Command.AcceptTest;
    using Thinning.Application.Test.Command.AddTest;

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
    }
}
