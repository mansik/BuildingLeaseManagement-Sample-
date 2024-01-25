CREATE PROCEDURE [dbo].[spLeaseIncomings_GetsDisplayByFromToDate]
	@FromDate DateTime,
	@ToDate DateTime
AS
BEGIN
	with BuildingRoomCode as
	(
		/*건물*/
		select room.Id as BuildingRoomCodeId, BuildingCodeId,
			building.DisplaySeq as DisplaySeq
		from dbo.[BuildingRoomCode] room
		left join dbo.[BuildingCode] building
			on room.BuildingCodeId = building.Id
	)
	,
	Invoice
	as
	(
		/*청구액*/
		select datetrunc(month, InvoiceDate) as InvoiceDate, BuildingRoomCodeId, LesseeId,
		sum(LineTotal) as InvoiceAmount
		from dbo.[Invoice]
		where InvoiceDate >= @FromDate
		and InvoiceDate <= @ToDate
		group by datetrunc(month, InvoiceDate),BuildingRoomCodeId, LesseeId
	)	
	,
	Incomings
	as
	(
		/*수입액*/
		select datetrunc(month, TransactionDate) as TransactionDate, LesseeId,
		sum(DepositAmount) as IncomingsAmount
		from dbo.[CashBook]
		where TransactionDate >= @FromDate 
		and TransactionDate <= @ToDate
		and DelFlag = 0
		and InOutgoings = 0 
		group by datetrunc(month, TransactionDate), LesseeId
	)	
	,
	Loss
	as
	(
		/*결손액*/
		select datetrunc(month, TransactionDate) as TransactionDate, LesseeId,
		sum(LossAmount) as LossAmount
		from dbo.[CashBook]
		where TransactionDate >= @FromDate 
		and TransactionDate <= @ToDate
		and DelFlag = 0
		and InOutgoings = 2 
		group by datetrunc(month, TransactionDate), LesseeId
	)
	

	select room.BuildingCodeId,	Invoice.InvoiceDate, room.DisplaySeq,
		sum(isnull(InvoiceAmount,0)) as InvoiceAmount, /*당월 청구액*/
		sum(isnull(IncomingsAmount,0)) as IncomingsAmount, /*당월 수입액*/
		sum(isnull(LossAmount,0)) as LossAmount /*당월 결손액*/
	from BuildingRoomCode room
	left join Invoice
	  on Invoice.BuildingRoomCodeId = room.BuildingRoomCodeId
	left join Incomings
	  on Incomings.LesseeId = Invoice.LesseeId
	  and Incomings.TransactionDate = Invoice.InvoiceDate
	left join Loss
	  on Loss.LesseeId = Invoice.LesseeId
	  and Loss.TransactionDate = Invoice.InvoiceDate
	where Invoice.InvoiceDate is not null
	group by room.BuildingCodeId, Invoice.InvoiceDate, room.DisplaySeq
	order by Invoice.InvoiceDate, room.DisplaySeq;
END