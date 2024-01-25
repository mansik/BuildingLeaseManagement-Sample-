CREATE PROCEDURE [dbo].[spLeaseContract_Update]
	@Id int,
	@LesseeId INT,
    @BuildingRoomCodeId INT,
    @ContractStartDate DATETIME,
    @ContractEndDate DATETIME,
    @Deposit MONEY,
    @MonthlyRent MONEY,
    @MonthlyRentVAT MONEY,    
    @MaintenanceFee MONEY,
    @MaintenanceFeeVAT MONEY,
	@Notes nvarchar(200),	
	@UpdateUserId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[LeaseContract]
	set 	
	LesseeId = @LesseeId,
	BuildingRoomCodeId = @BuildingRoomCodeId,
	ContractStartDate = @ContractStartDate,
	ContractEndDate = @ContractEndDate,
	Deposit = @Deposit,
	MonthlyRent = @MonthlyRent,
	MonthlyRentVAT = @MonthlyRentVAT,
	MaintenanceFee = @MaintenanceFee,
	MaintenanceFeeVAT = @MaintenanceFeeVAT,
	Notes = @Notes,
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END