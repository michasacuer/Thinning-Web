namespace Thinning.Domain
{
    using System.Collections.Generic;
    using Thinning.Domain.Dao.Test;
    using Thinning.Domain.Enum;
    
    public class Test
    {
        public int TestId { get; set; }
        public ActivationStatusCode ActivationStatusCode { get; set; }
        public string ActivationUrl { get; set; }

        public ICollection<TestLine> TestLines { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<TestPcInfo> TestPcInfos { get; set; }

        public Test()
        {
        }

        public Test(AddTestDao request)
        {
            foreach (var testLine in request.TestLines)
            {
                TestLines.Add(new TestLine(testLine));
            };

            foreach (var image in request.Images)
            {
                Images.Add(new Image(image));
            }

            TestPcInfos.Add(new TestPcInfo(request.PcInfo));
        }
    }
}
