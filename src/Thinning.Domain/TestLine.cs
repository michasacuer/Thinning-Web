namespace Thinning.Domain
{
    using System.Collections.Generic;
    using System.Linq;
    using Thinning.Domain.Dao.TestLine;

    public class TestLine
    {
        public int TestLineId { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
        public int AlgorithmId { get; set; }
        public Algorithm Algorithm { get; set; }
        public int Iterations { get; set; }
        public double AvgExecutionTime { get; set; }

        public ICollection<TestRun> TestRuns { get; set; }

        public TestLine()
        {
        }

        public TestLine(TestLineDao testLineDao)
        {
            AlgorithmId = testLineDao.AlgorithmId.GetValueOrDefault();
            Iterations = testLineDao.Iterations;

            var times = testLineDao.AlgorithmTestRuns.Select(run => run.Time);
            AvgExecutionTime = times.ToList().Average();

            foreach (var run in testLineDao.AlgorithmTestRuns)
            {
                TestRuns.Add(new TestRun(run));
            }
        }
    }
}
