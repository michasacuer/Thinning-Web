namespace Thinning.Domain
{
    using System;
    using System.Collections.Generic;
    using Thinning.Domain.Dao.Test;
    using Thinning.Domain.Enum;
    
    public class Test
    {
        public int TestId { get; set; }
        public ActivationStatusCode ActivationStatusCode { get; set; }
        public string ActivationUrl { get; set; }
        public DateTime Sent { get; set; }

        public ICollection<TestLine> TestLines { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<TestPcInfo> TestPcInfos { get; set; }

        public Test()
        {
        }

        public Test(AddTestDao request)
        {
            Sent = request.Sent;
            TestLines = new List<TestLine>();
            Images = new List<Image>();
            TestPcInfos = new List<TestPcInfo>();

            foreach (var testLine in request.TestLines)
            {
                TestLines.Add(new TestLine(testLine));
            }

            foreach (var image in request.Images)
            {
                Images.Add(new Image(image));
            }

            TestPcInfos.Add(new TestPcInfo(request.PcInfo));
        }
    }
}
