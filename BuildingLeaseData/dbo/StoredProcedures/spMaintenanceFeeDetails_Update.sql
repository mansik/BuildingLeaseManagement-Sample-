CREATE PROCEDURE [dbo].[spMaintenanceFeeDetails_Update]
	@Id int,
	@MaintenanceFeeDetailsDate DATETIME,
	@BuildingRoomCodeId      INT,
	@LesseeId                INT,
	@ReceivableAmount        MONEY,
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

	update dbo.[MaintenanceFeeDetails]
	set
    MaintenanceFeeDetailsDate = @MaintenanceFeeDetailsDate,
	BuildingRoomCodeId = @BuildingRoomCodeId,
	LesseeId = @LesseeId,
	ReceivableAmount = @ReceivableAmount,    
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