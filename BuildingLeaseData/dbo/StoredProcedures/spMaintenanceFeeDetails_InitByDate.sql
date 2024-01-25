CREATE PROCEDURE [dbo].[spMaintenanceFeeDetails_InitByDate]
	@MaintenanceFeeDetailsDate datetime,
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	delete from dbo.[MaintenanceFeeDetails]
	where MaintenanceFeeDetailsDate = @MaintenanceFeeDetailsDate
	and Exists (select 1 from dbo.[BuildingRoomCode] 
				where Id = MaintenanceFeeDetails.BuildingRoomCodeId 
				and BuildingCodeId = @BuildingCodeId);

	insert into dbo.[MaintenanceFeeDetails] 
           ([MaintenanceFeeDetailsDate]
           ,[BuildingRoomCodeId]
           ,[LesseeId]
           ,[ReceivableAmount]
           ,[MonthlyRent]
           ,[MonthlyRentVAT]
           ,[MaintenanceFee]
           ,[MaintenanceFeeVAT]
           ,[ElectricBill]
           ,[ElectricBillVAT]
           ,[WaterBill]
           ,[RoadOccupancyFee]
           ,[RoadOccupancyFeeVAT]
           ,[TrafficCausingCharge]
           ,[TrafficCausingChargeVAT]
           ,[InsertUserId]           
           ,[UpdateUserId])
	select	InvoiceDate, 
		BuildingRoomCodeId, 
		case					
			when Id is not null then LesseeId
			else 1 /* 초기값 */
		end as LesseeId,
		(
			(select isnull(sum(LineTotal),0) /* 청구서 총액 */
			from dbo.[Invoice]
			where InvoiceDate < @MaintenanceFeeDetailsDate
			and LesseeId = main.LesseeId)
			- 
			(select isnull(sum(DepositAmount),0) /* 입금액 */
			from dbo.[CashBook]
			where TransactionDate < @MaintenanceFeeDetailsDate
			and LesseeId = main.LesseeId
			and InOutgoings = 0
			and DelFlag = 0)			
			- 
			(select isnull(sum(LossAmount),0) /* 결손액 */
			from dbo.[CashBook]
			where TransactionDate < @MaintenanceFeeDetailsDate
			and LesseeId = main.LesseeId
			and InOutgoings = 2
			and DelFlag = 0)
		) as ReceivableAmount, 
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
		InsertUserId = 1,
		UpdateUserId = 1
	from dbo.[Invoice] main
	where main.InvoiceDate = @MaintenanceFeeDetailsDate 
	and Exists (select 1 from dbo.[BuildingRoomCode] 
				where Id = main.BuildingRoomCodeId 
				and BuildingCodeId = @BuildingCodeId
				and UseFlag = 1);
END