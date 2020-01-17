CREATE PROCEDURE GetTestImages

@testId INT

AS
BEGIN
	SELECT TestId, TestLineId, OriginalWidth, OriginalHeight, OriginalBpp, ImageContent, TestImage FROM Images WHERE @testId = TestId;
END