namespace Thinning.Domain
{
    using System.Collections.Generic;
    
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
    }
}
