namespace Thinning.Domain.Dao.Test
{
    using System.Collections.Generic;
    using Thinning.Domain.Dao.Image;
    using Thinning.Domain.Dao.TestLine;
    using Thinning.Domain.Dao.TestPcInfo;
    
    public class AddTestDao
    {
        public AddTestDao(List<TestLineDao> testLines, PcInfoDao pcInfo, List<ImageDao> images)
        {
            TestLines = testLines;
            PcInfo = pcInfo;
            Images = images;
        }

        public List<TestLineDao> TestLines { get; set; }
        public PcInfoDao PcInfo { get; set; }
        public List<ImageDao> Images { get; set; }
    }
}
