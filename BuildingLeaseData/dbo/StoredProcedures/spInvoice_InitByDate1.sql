CREATE PROCEDURE [dbo].[spInvoice_InitByDate1]
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
	select Id = case 
					when invoice.Id is not null then invoice.Id
					else 0
					end,
		InvoiceDate = case 
					when invoice.Id is not null then invoice.InvoiceDate
					else null
					end, 
		room.Id as BuildingRoomCodeId, 
		LesseeId = case
					when invoice.Id is not null then invoice.LesseeId
					when lc.Id is not null then lc.LesseeId
					else 0
					end,
		BillIssueDay = case 
					when invoice.Id is not null then invoice.BillIssueDay
					when lc.Id is not null then (select BillIssueDay from dbo.[Lessee] where Id = lc.LesseeId)
					else null
					end, 
		MonthlyRent = case
					when invoice.Id is not null then invoice.MonthlyRent
					when lc.Id is not null then lc.MonthlyRent
					else 0
					end, 
		MonthlyRentVAT = case
					when invoice.Id is not null then invoice.MonthlyRentVAT
					when lc.Id is not null then lc.MonthlyRentVAT
					else 0
					end,
		MaintenanceFee = case
					when invoice.Id is not null then invoice.MaintenanceFee
					when lc.Id is not null then lc.MaintenanceFee
					else 0
					end,
		MaintenanceFeeVAT = case
					when invoice.Id is not null then invoice.MaintenanceFeeVAT
					when lc.Id is not null then lc.MaintenanceFeeVAT
					else 0
					end,
		ElectricBill = case
					when invoice.Id is not null then invoice.ElectricBill					
					else 0
					end,
		ElectricBillVAT = case
					when invoice.Id is not null then invoice.ElectricBillVAT					
					else 0
					end,
		WaterBill = case
					when invoice.Id is not null then invoice.WaterBill					
					else 0
					end,
		RoadOccupancyFee = case
					when invoice.Id is not null then invoice.RoadOccupancyFee					
					else 0
					end,
		RoadOccupancyFeeVAT = case
					when invoice.Id is not null then invoice.RoadOccupancyFeeVAT					
					else 0
					end,
		TrafficCausingCharge = case
					when invoice.Id is not null then invoice.TrafficCausingCharge					
					else 0
					end,
		TrafficCausingChargeVAT = case
					when invoice.Id is not null then invoice.TrafficCausingChargeVAT					
					else 0
					end,
		LineTotal = case
					when invoice.Id is not null then invoice.LineTotal					
					else 0
					end
	from dbo.[BuildingRoomCode] room
	left join dbo.[LeaseContract] lc
		on room.Id = lc.BuildingRoomCodeId
		and lc.ContractStartDate <= eomonth(@InvoiceDate) /*계약일이 해당 월에 포함되면 보이게*/
		and lc.ContractEndDate >= @InvoiceDate
	left join dbo.[Invoice] invoice
		on invoice.BuildingRoomCodeId = room.Id
		and invoice.LesseeId = lc.Id
		and invoice.InvoiceDate = @InvoiceDate
	where room.BuildingCodeId = @BuildingCodeId
	and room.UseFlag = 1
	order by room.DisplaySeq, LesseeId;
END