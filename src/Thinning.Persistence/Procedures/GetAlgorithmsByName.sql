CREATE PROCEDURE [dbo].[GetAlgorithmsByName]

@names NVARCHAR(MAX)

AS
BEGIN
	SELECT AlgorithmId, Name From Algorithms WHERE Name IN (SELECT Item FROM dbo.SplitString(@names, ','))
END