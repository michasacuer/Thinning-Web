namespace Thinning.Application.Test.Command.AddTest
{
    using MediatR;
    using System.Collections.Generic;
    using Thinning.Service.Dao.Image;
    using Thinning.Service.Dao.TestLine;
    using Thinning.Service.Dao.TestPcInfo;

    public class AddTestCommand : IRequest
    {
        public List<TestLineDao> TestLines { get; set; }
        public PcInfoDao PcInfo { get; set; }
        public List<ImageDao> Images { get; set; }
    }
}
