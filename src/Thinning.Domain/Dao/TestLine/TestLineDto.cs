namespace Thinning.Domain.Dao.TestLine
{
    using System.Collections.Generic;
    using Thinning.Domain.Dao.Image;
    using Thinning.Domain.Dao.TestRun;

    public class TestLineDto
    {
        public int TestLineId { get; set; }
        public TestImageDto Image { get; set; }
        public int? AlgorithmId { get; set; }
        public string AlgorithmName { get; set; }
        public int Iterations { get; set; }
        public IEnumerable<TestRunDto> AlgorithmTestRuns { get; set; }
    }
}
