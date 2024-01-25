CREATE PROCEDURE [dbo].[spMaintenanceFeeDetails_Insert]
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
	@InsertUserId int,
	@UpdateUserId int,
	@Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[MaintenanceFeeDetails]
                (MaintenanceFeeDetailsDate,
				BuildingRoomCodeId,
				LesseeId,
				ReceivableAmount,    
				MonthlyRent,
				MonthlyRentVAT,
				MaintenanceFee,
				MaintenanceFeeVAT,
				ElectricBill,
				ElectricBillVAT,
				WaterBill,
				RoadOccupancyFee,
				RoadOccupancyFeeVAT,
				TrafficCausingCharge,
				TrafficCausingChargeVAT,
                InsertUserId,
                UpdateUserId)
	    values
               (@MaintenanceFeeDetailsDate,
				@BuildingRoomCodeId,
				@LesseeId,
				@ReceivableAmount,    
				@MonthlyRent,
				@MonthlyRentVAT,
				@MaintenanceFee,
				@MaintenanceFeeVAT,
				@ElectricBill,
				@ElectricBillVAT,
				@WaterBill,
				@RoadOccupancyFee,
				@RoadOccupancyFeeVAT,
				@TrafficCausingCharge,
				@TrafficCausingChargeVAT,
               @InsertUserId,
               @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END