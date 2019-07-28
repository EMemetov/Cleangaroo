CREATE TRIGGER TGR_CustomerSub_AI
ON CustomerSubscription
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE
	@Periodicity INTEGER,
	@idAppointment INTEGER,
	@IdServPrice INTEGER,
	@IdCust INTEGER,
	@FinishDate DATE,
	@StartDate DATE,
	@StartTime DATETIME,
	@HoursRequested INTEGER,
	@Idcleaner INTEGER,
	@isSubscription BIT,
    @VALOR  DECIMAL(10,2)
 
    SELECT @idAppointment = idAppointment, @Periodicity = Periodicity,
	  @FinishDate = finishDate FROM INSERTED
    SELECT @IdServPrice = idServicePrice, @IdCust = idCustomer,
		@StartDate=ctDateRequestService, @Idcleaner=idCleaner,
		@HoursRequested = ctHoursRequested, @StartTime=startTime,
		@isSubscription = isSubscription FROM Appointment
		WHERE idAppointment = @idAppointment
 
   WHILE (DATEADD(DAY,@Periodicity,@StartDate) <= @FinishDate) and (@isSubscription=1)
	BEGIN
		INSERT INTO Appointment (idServicePrice, idCustomer, ctDateRequestService,
			ctHoursRequested, idCleaner, startTime, isSubscription) 
			VALUES
			(@IdServPrice, @IdCust, DATEADD(DAY,@Periodicity,@StartDate), @HoursRequested,
			@Idcleaner, @StartTime, 1)
			
		SET @StartDate = DATEADD(DAY,@Periodicity,@StartDate)
	END

END
