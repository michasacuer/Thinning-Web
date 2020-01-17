CREATE PROCEDURE GetTestRunsFromTestLines

@Ids dbo.IntTableType READONLY

AS
BEGIN
	SELECT tr.TestLinesId, tr.RunCount, tr.Time FROM TestRuns tr WHERE tr.TestLinesId IN (SELECT Id FROM @Ids) ORDER BY tr.TestLinesId, tr.RunCount;
END