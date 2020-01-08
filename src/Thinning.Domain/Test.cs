namespace Thinning.Domain
{
    using System.Collections.Generic;
    using Thinning.Domain.Enum;
    
    public class Test
    {
        public int TestId { get; set; }
        public ActivationStatusCode ActivationStatusCode { get; set; }
        public string ActivationUrl { get; set; }

        public ICollection<TestLine> TestLines { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<TestPcInfo> TestPcInfos { get; set; }
    }
}
