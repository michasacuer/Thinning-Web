namespace Thinning.Domain.Dao.Test
{
    using System;
    using System.Collections.Generic;
    using Thinning.Domain.Dao.Image;
    using Thinning.Domain.Dao.TestLine;
    using Thinning.Domain.Dao.TestPcInfo;
    
    public class AddTestDao
    {
        public AddTestDao(DateTime sent, List<TestLineDao> testLines, PcInfoDao pcInfo, List<ImageDao> images)
        {
            Sent = sent;
            TestLines = testLines;
            PcInfo = pcInfo;
            Images = images;
        }

        public PcInfoDao PcInfo { get; set; }
        public List<TestLineDao> TestLines { get; set; }
        public List<ImageDao> Images { get; set; }
        public DateTime Sent { get; set; }
    }
}
