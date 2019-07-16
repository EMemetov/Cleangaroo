CREATE PROCEDURE SearchCustCleaner
	@DayWeek VARCHAR(9),
	@InitialTime DATETIME,
	@FinishTime DATETIME
AS
	SELECT s.idCleaner FROM ScheduleCleaner s
		WHERE (dayWeek = @DayWeek) AND (@InitialTime >= s.initialTime) 
		AND (@FinishTime <= finishTime)