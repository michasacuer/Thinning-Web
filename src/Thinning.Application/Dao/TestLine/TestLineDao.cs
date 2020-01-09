namespace Thinning.Service.Dao.TestLine
{
    using System.Collections.Generic;
    using Thinning.Service.Dao.TestRun;

    public class TestLineDao
    {
        public string AlgorithmName { get; set; }
        public int Iterations { get; set; }
        public List<TestRunDao> AlgorithmTestRuns { get; set; }
    }
}
