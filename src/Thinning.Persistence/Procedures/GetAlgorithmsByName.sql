CREATE PROCEDURE GetAlgorithmsByName

@names StringList READONLY

AS
BEGIN
	SELECT ALgorithmId, Name From Algorithms WHERE Name IN (SELECT Item FROM @names)
END