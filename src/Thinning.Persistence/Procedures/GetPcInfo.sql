CREATE PROCEDURE GetPcInfo

@testId INT

AS
BEGIN
	SELECT TestId, Cpu, Gpu, Os, Memory FROM TestPcInfos WHERE TestId = @testId;
END