namespace Thinning.Tests.Web.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using Thinning.Domain;
    using Thinning.Domain.Enum;
    using Thinning.Persistence;
    
    public class ContextDataSeeding
    {
        public static void Run(ref ThinningDbContext context)
        {
            var tests = new List<Test>();
            for (int i = 0; i < 10; i++)
            {
                tests.Add(new Test
                {
                    ActivationStatusCode = ActivationStatusCode.Audit,
                    ActivationUrl = Guid.NewGuid().ToString().Replace('-', '&'),
                    Sent = DateTime.Now
                });
            }

            context.Tests.AddRange(tests);
            context.SaveChanges();

            var algorithms = new List<Algorithm>();
            for (int i = 0; i < 4; i++)
            {
                algorithms.Add(new Algorithm { Name = $"Algorithm{i + 1}" });
            }

            context.Algorithms.AddRange(algorithms);
            context.SaveChanges();

            var testLines = new List<TestLine>();
            for (int i = 0; i < 10; i++)
            {
                testLines.Add(new TestLine
                {
                    TestId = i,
                    AlgorithmId = i % 2 == 0 ? 1 : 2,
                    Iterations = 10
                });
            }

            context.TestLines.AddRange(testLines);
            context.SaveChanges();

            Random random = new Random();
            var testRuns = new List<TestRun>();
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    testRuns.Add(new TestRun
                    {
                        TestLinesId = j + 1,
                        RunCount = i + 1,
                        Time = random.NextDouble() * (10 - 1) + 1
                    });
                }
            }

            context.TestRuns.AddRange(testRuns);
            context.SaveChanges();
        }
    }
}
