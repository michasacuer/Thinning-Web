﻿namespace Thinning.Application.Test.Command.AddTest
{
    using MediatR;
    using System.Collections.Generic;
    using Thinning.Domain.Dao.Image;
    using Thinning.Domain.Dao.TestLine;
    using Thinning.Domain.Dao.TestPcInfo;

    public class AddTestCommand : IRequest
    {
        public List<TestLineDao> TestLines { get; set; }
        public PcInfoDao PcInfo { get; set; }
        public List<ImageDao> Images { get; set; }
    }
}