CREATE PROCEDURE [dbo].[spInvoice_Insert]
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
	@InsertUserId int,
	@UpdateUserId int,
	@Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[Invoice]
                (InvoiceDate,
				BuildingRoomCodeId,
				LesseeId,
				BillIssueDay,    
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
               (@InvoiceDate,
				@BuildingRoomCodeId,
				@LesseeId,
				@BillIssueDay,    
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