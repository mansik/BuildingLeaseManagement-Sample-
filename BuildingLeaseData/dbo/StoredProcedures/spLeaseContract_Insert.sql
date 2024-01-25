CREATE PROCEDURE [dbo].[spLeaseContract_Insert]
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
	@InsertUserId int,
	@UpdateUserId int,
	@Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[LeaseContract]
                (LesseeId,
                BuildingRoomCodeId,
                ContractStartDate,
                ContractEndDate,                
                Deposit,
                MonthlyRent,
                MonthlyRentVAT,
                MaintenanceFee,
                MaintenanceFeeVAT,
                Notes,
                InsertUserId,
                UpdateUserId)
	    values
               (@LesseeId,
               @BuildingRoomCodeId,
               @ContractStartDate,
               @ContractEndDate,
               @Deposit,
               @MonthlyRent,
               @MonthlyRentVAT,
               @MaintenanceFee,
               @MaintenanceFeeVAT,
			   @Notes,
               @InsertUserId,
               @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END