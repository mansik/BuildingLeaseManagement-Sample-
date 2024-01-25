CREATE PROCEDURE [dbo].[spInvoice_Update]
	@Id int,
	@InvoiceDate DATETIME,
	@BuildingRoomCodeId      INT,
	@LesseeId                INT,
	@BillIssueDay            NVARCHAR(20),    
	@MonthlyRent             MONEY,
	@MonthlyRentVAT          MONEY,
	@MaintenanceFee          MONEY,
	@MaintenanceFeeVAT       MONEY,
	@ElectricBill            MONEY,
	@ElectricBillVAT         MONEY,
	@WaterBill               MONEY,
	@RoadOccupancyFee        MONEY,
	@RoadOccupancyFeeVAT     MONEY,
	@TrafficCausingCharge    MONEY,
	@TrafficCausingChargeVAT    MONEY,
	@UpdateUserId int
AS
BEGIN
    SET NOCOUNT ON

	update dbo.[Invoice]
	set
    InvoiceDate = @InvoiceDate,
	BuildingRoomCodeId = @BuildingRoomCodeId,
	LesseeId = @LesseeId,
	BillIssueDay = @BillIssueDay,    
	MonthlyRent = @MonthlyRent,
	MonthlyRentVAT = @MonthlyRentVAT,
	MaintenanceFee =@MaintenanceFee,
	MaintenanceFeeVAT = @MaintenanceFeeVAT,
	ElectricBill = @ElectricBill,
	ElectricBillVAT = @ElectricBillVAT,
	WaterBill = @WaterBill,
	RoadOccupancyFee = @RoadOccupancyFee,
	RoadOccupancyFeeVAT = @RoadOccupancyFeeVAT,
	TrafficCausingCharge = @TrafficCausingCharge,
	TrafficCausingChargeVAT = @TrafficCausingChargeVAT,
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END