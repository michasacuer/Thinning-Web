namespace Thinning.Domain.Dao.Test
{
    using Thinning.Domain.Dao.TestPcInfo;
    using Thinning.Domain.Enum;

    public class TestDto
    {
        public int TestId { get; set; }
        public int TestLineCount { get; set; }
        public ActivationStatusCode ActivationStatusCode { get; set; }
        public PcInfoDto TestPcInfo { get; set; }
        public double AvarageExecutionTime { get; set; }
    }
}
