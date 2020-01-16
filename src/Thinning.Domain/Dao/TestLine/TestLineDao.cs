namespace Thinning.Domain.Dao.TestLine
{
    using System.Collections.Generic;
    using Thinning.Domain.Dao.Image;
    using Thinning.Domain.Dao.TestRun;

    public class TestLineDao
    {
        public int? AlgorithmId { get; set; }
        public string AlgorithmName { get; set; }
        public int Iterations { get; set; }
        public List<TestRunDao> AlgorithmTestRuns { get; set; }
    }
}
