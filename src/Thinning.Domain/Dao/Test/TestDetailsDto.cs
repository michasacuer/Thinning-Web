namespace Thinning.Domain.Dao.Test
{
    using System;
    using System.Collections.Generic;
    using Thinning.Domain;
    using Thinning.Domain.Dao.TestLine;
    using Thinning.Domain.Dao.TestPcInfo;
    using Thinning.Domain.Enum;

    public class TestDetailsDto
    {
        public int TestId { get; set; }
        public ActivationStatusCode ActivationStatusCode { get; set; }
        public string ActivationUrl { get; set; }
        public DateTime Sent { get; set; }
        public Image BaseImage { get; set; }
        public IEnumerable<TestLineDao> TestLines { get; set; }
        public PcInfoDto PcInfo { get; set; }
    }
}
