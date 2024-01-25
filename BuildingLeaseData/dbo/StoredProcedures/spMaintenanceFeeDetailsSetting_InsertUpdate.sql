CREATE PROCEDURE [dbo].[spMaintenanceFeeDetailsSetting_InsertUpdate]
	@MaintenanceFeeDetailsDate DATETIME,
	@BuildingCodeId INT,		
	@ElectricBillTerm NVARCHAR(30),	
	@WaterBillTerm NVARCHAR(30),
	@RoadOccupancyFeeTerm NVARCHAR(30),	
	@TrafficCausingChargeTerm NVARCHAR(30),	
	@BankBookCodeId INT,
	@PaymentDueDate DATETIME,
	@BillIssueDate DATETIME,
	@InsertUserId int,
	@UpdateUserId int
AS
BEGIN
    SET NOCOUNT ON

	if Exists (select 1 
			from dbo.[MaintenanceFeeDetailsSetting] 
			where MaintenanceFeeDetailsDate = @MaintenanceFeeDetailsDate 
			and BuildingCodeId = @BuildingCodeId)

		update dbo.[MaintenanceFeeDetailsSetting]
		set
		MaintenanceFeeDetailsDate = @MaintenanceFeeDetailsDate,
		BuildingCodeId = @BuildingCodeId,
		ElectricBillTerm = @ElectricBillTerm,
		WaterBillTerm = @WaterBillTerm,
		RoadOccupancyFeeTerm = @RoadOccupancyFeeTerm,
		TrafficCausingChargeTerm = @TrafficCausingChargeTerm,
		BankBookCodeId = @BankBookCodeId,
		PaymentDueDate = @PaymentDueDate,
		BillIssueDate = @BillIssueDate,    
		UpdateUserId = @UpdateUserId,
		UpdateDate = getutcdate()
		where MaintenanceFeeDetailsDate = @MaintenanceFeeDetailsDate 
		and BuildingCodeId = @BuildingCodeId;
	else
		insert into dbo.[MaintenanceFeeDetailsSetting]
					(MaintenanceFeeDetailsDate,
					BuildingCodeId,				
					ElectricBillTerm,				
					WaterBillTerm,
					RoadOccupancyFeeTerm,
					TrafficCausingChargeTerm,
					BankBookCodeId,
					PaymentDueDate,
					BillIssueDate,
					InsertUserId,
					UpdateUserId)
			values
				   (@MaintenanceFeeDetailsDate,
				   @BuildingCodeId,
				   @ElectricBillTerm,				
				   @WaterBillTerm,
				   @RoadOccupancyFeeTerm,
				   @TrafficCausingChargeTerm,
				   @BankBookCodeId,
				   @PaymentDueDate,
				   @BillIssueDate,
				   @InsertUserId,
				   @UpdateUserId);
END