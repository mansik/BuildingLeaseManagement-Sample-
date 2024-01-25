CREATE PROCEDURE [dbo].[spInvoice_InitByDate]
	@InvoiceDate datetime,
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	delete from dbo.[Invoice]
	where InvoiceDate = @InvoiceDate
	and Exists (select 1 from dbo.[BuildingRoomCode] 
				where Id = Invoice.BuildingRoomCodeId 
				and BuildingCodeId = @BuildingCodeId);

	/* LeaseContract 사용: 동일 임차인이 계약이 여러건일 경우 모두 나타남 -> 사용자가 삭제해야 함. */
	insert into dbo.[Invoice] ([InvoiceDate]
           ,[BuildingRoomCodeId]
           ,[LesseeId]
           ,[BillIssueDay]
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
	select	InvoiceDate = @InvoiceDate, 
		room.Id as BuildingRoomCodeId, 
		LesseeId = case					
					when lc.Id is not null then lc.LesseeId
					else 1 /* 초기값 */
					end,
		BillIssueDay = case
					when lc.Id is not null then (select BillIssueDay from dbo.[Lessee] where Id = lc.LesseeId)
					else null
					end, 
		MonthlyRent = case
					when lc.Id is not null then lc.MonthlyRent
					else 0
					end, 
		MonthlyRentVAT = case
					when lc.Id is not null then lc.MonthlyRentVAT
					else 0
					end,
		MaintenanceFee = case
					when lc.Id is not null then lc.MaintenanceFee
					else 0
					end,
		MaintenanceFeeVAT = case
					when lc.Id is not null then lc.MaintenanceFeeVAT
					else 0
					end,
		ElectricBill = 0,
		ElectricBillVAT = 0,
		WaterBill = 0,
		RoadOccupancyFee = 0,
		RoadOccupancyFeeVAT = 0,
		TrafficCausingCharge = 0,
		TrafficCausingChargeVAT = 0,
		InsertUserId = 1,
		UpdateUserId = 1
	from dbo.[BuildingRoomCode] room
	left join dbo.[LeaseContract] lc
		on room.Id = lc.BuildingRoomCodeId
		and lc.ContractStartDate <= eomonth(@InvoiceDate) /*계약일이 해당 월에 포함되면 보이게*/
		and lc.ContractEndDate >= @InvoiceDate	
	where room.BuildingCodeId = @BuildingCodeId
	and room.UseFlag = 1;
END