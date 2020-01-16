CREATE PROCEDURE [dbo].[GetTestList]

@size INT,
@skip INT,
@orderDir VARCHAR(4),
@orderBy VARCHAR(20),
@totalCount INT OUTPUT

AS 
BEGIN
	CREATE TABLE #Ids (
		TestId INT
	);

	INSERT INTO #Ids SELECT TestId FROM Tests;

	SELECT t.TestId, t.ActivationStatusCode, COUNT(tl.TestId) AS TestLineCount, SUM(tl.Iterations) AS AllIterations, AVG(tl.AvgExecutionTime) AS AvarageExecutionTime
	FROM Tests t JOIN TestLines tl ON t.TestId = tl.TestId 
	GROUP BY t.TestId, t.ActivationStatusCode 
	ORDER BY 
		CASE WHEN @orderDir = 'asc'AND @orderBy = 'TestId' THEN t.TestId END,
		CASE WHEN @orderDir = 'desc' AND @orderBy = 'TestId' THEN t.TestId END DESC,
		CASE WHEN @orderDir = 'asc' AND @orderBy = 'AllIterations' THEN SUM(tl.Iterations) END,
		CASE WHEN @orderDir = 'desc' AND @orderBy = 'AllIterations' THEN SUM(tl.Iterations) END DESC,
		CASE WHEN @orderDir = 'asc' AND @orderBy = 'AvarageExecutionTime' THEN AVG(tl.AvgExecutionTime) END,
		CASE WHEN @orderDir = 'desc' AND @orderBy = 'AvarageExecutionTime' THEN AVG(tl.AvgExecutionTime) END DESC
	OFFSET @skip ROWS
	FETCH NEXT @size ROWS ONLY;

	SELECT @totalCount = COUNT(TestId) FROM #Ids

	DROP TABLE #Ids;

END