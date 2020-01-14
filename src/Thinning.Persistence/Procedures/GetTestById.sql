CREATE PROCEDURE [dbo].[GetTestById]

@testId INT

AS
BEGIN
	SELECT TestId, ActivationStatusCode, ActivationUrl FROM Tests WHERE @testId = TestId
END