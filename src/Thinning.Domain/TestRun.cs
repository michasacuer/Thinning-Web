namespace Thinning.Domain
{
    public class TestRun
    {
        public int TestRunId { get; set; }
        public int TestLinesId { get; set; }
        public TestLine TestLines { get; set; }
        public decimal Time { get; set; }
        public int RunCount { get; set; }
    }
}
