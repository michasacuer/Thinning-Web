namespace Thinning.Domain
{
    using Thinning.Domain.Dao.TestRun;
    
    public class TestRun
    {
        public int TestRunId { get; set; }
        public int TestLinesId { get; set; }
        public TestLine TestLines { get; set; }
        public double Time { get; set; }
        public int RunCount { get; set; }

        public TestRun()
        {
        }

        public TestRun(TestRunDao testRunDao)
        {
            Time = testRunDao.Time;
            RunCount = testRunDao.RunCount;
        }
    }
}
