CREATE PROCEDURE GetTestLines

@testId INT

AS
BEGIN
	SELECT tl.TestLineId, tl.Iterations, a.Name AS AlgorithmName, a.AlgorithmId
	FROM TestLines tl
	JOIN Algorithms a ON tl.AlgorithmId = a.AlgorithmId
	WHERE @testId = tl.TestId;

	SELECT tl.TestLineId, i.ImageContent, i.OriginalWidth, i.OriginalHeight, i.OriginalBpp
	FROM Images i
	JOIN TestLines tl ON tl.TestLineId = i.TestLineId
	WHERE @testId = tl.TestId;
END