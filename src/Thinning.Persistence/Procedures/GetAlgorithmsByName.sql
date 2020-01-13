CREATE PROCEDURE [dbo].[GetAlgorithmsByName]

@names NVARCHAR(MAX)

AS
BEGIN
	SELECT ALgorithmId, Name From Algorithms WHERE Name IN (SELECT Item FROM dbo.SplitString(@names, ','))
END