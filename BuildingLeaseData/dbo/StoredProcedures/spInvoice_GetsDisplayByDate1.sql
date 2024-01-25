CREATE PROCEDURE [dbo].[spInvoice_GetsDisplayByDate1]
	@InvoiceDate datetime,
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	/* 호실과 임차인을 선택해서 입력할 경우 사용 */
	if exists (select 1
			from dbo.[Invoice]  invoice 
			left join dbo.[BuildingRoomCode] room
				on invoice.BuildingRoomCodeId = room.Id
			where InvoiceDate = @InvoiceDate and room.BuildingCodeId = @BuildingCodeId)

		select invoice.Id, 
		invoice.InvoiceDate, 
		invoice.BuildingRoomCodeId, 
		invoice.LesseeId, 
		invoice.BillIssueDay, 
		invoice.MonthlyRent, 
		invoice.MonthlyRentVAT,
		invoice.MaintenanceFee,
		invoice.MaintenanceFeeVAT,
		invoice.ElectricBill,
		invoice.ElectricBillVAT,
		invoice.WaterBill,
		invoice.RoadOccupancyFee,
		invoice.RoadOccupancyFeeVAT,
		invoice.TrafficCausingCharge,
		invoice.TrafficCausingChargeVAT,
		invoice.LineTotal
		from dbo.[Invoice]  invoice 
		left join dbo.[BuildingRoomCode] room
		 on invoice.BuildingRoomCodeId = room.Id
		where InvoiceDate = @InvoiceDate and room.BuildingCodeId = @BuildingCodeId
		order by room.DisplaySeq;
	else
		select 0 Id, 
		null InvoiceDate, 
		Id as BuildingRoomCodeId, 
		0 LesseeId, 
		null BillIssueDay, 
		0 MonthlyRent, 
		0 MonthlyRentVAT,
		0 MaintenanceFee,
		0 MaintenanceFeeVAT,
		0 ElectricBill,
		0 ElectricBillVAT,
		0 WaterBill,
		0 RoadOccupancyFee,
		0 RoadOccupancyFeeVAT,
		0 TrafficCausingCharge,
		0 TrafficCausingChargeVAT,
		0 LineTotal
		from dbo.[BuildingRoomCode]
		where BuildingCodeId = @BuildingCodeId
		order by DisplaySeq;
END