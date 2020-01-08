namespace Thinning.Domain
{
    public class TestPcInfo
    {
        public int TestPcInfoId { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
        public string Cpu { get; set; }
        public string Gpu { get; set; }
        public string Os { get; set; }
        public string Memory { get; set; }
    }
}
