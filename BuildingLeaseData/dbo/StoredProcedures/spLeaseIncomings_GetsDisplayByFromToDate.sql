CREATE PROCEDURE [dbo].[spLeaseIncomings_GetsDisplayByFromToDate]
	@FromDate DateTime,
	@ToDate DateTime
AS
/*
- 수입 기준
- 계약 전에(청구데이터가 만들어지기 전) 수입이 발생시 수입 누락을 해결
*/
IF (DATEDIFF(month, @FromDate, @ToDate) + 1 >= 1)
	BEGIN
		with wDate
		as 
		(
			select top (DATEDIFF(month, @FromDate, @ToDate) + 1)
				withDate = DATEADD(month, row_number() over(order by object_id) - 1, datetrunc(month, @FromDate))
			from sys.all_objects
		)
		,
		BuildingRoomCode as
		(
			/*건물*/
			select room.Id as BuildingRoomCodeId, BuildingCodeId,
				building.DisplaySeq as DisplaySeq
			from dbo.[BuildingRoomCode] room
			left join dbo.[BuildingCode] building
				on room.BuildingCodeId = building.Id
		)
		, 
		LeaseContract
		as
		(
			/*임대차 계약: 계약 전에(청구데이터가 만들어지기 전) 수입이 발생시 수입 누락을 해결하기 위함*/
			select distinct BuildingRoomCodeId, LesseeId
			from dbo.[LeaseContract]
		)
		,
		Invoice
		as
		(
			/*청구액*/
			select datetrunc(month, InvoiceDate) as InvoiceDate, LesseeId,
				sum(LineTotal) as InvoiceAmount
			from dbo.[Invoice]
			where InvoiceDate >= @FromDate
				and InvoiceDate <= @ToDate
			group by datetrunc(month, InvoiceDate), LesseeId
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
	

		select withdate as InvoiceDate, room.BuildingCodeId, room.DisplaySeq,
			sum(isnull(InvoiceAmount,0)) as InvoiceAmount, /*당월 청구액*/
			sum(isnull(IncomingsAmount,0)) as IncomingsAmount, /*당월 수입액*/
			sum(isnull(LossAmount,0)) as LossAmount /*당월 결손액*/
		from wDate
		cross join BuildingRoomCode room
		left join LeaseContract
			on room.BuildingRoomCodeId = LeaseContract.BuildingRoomCodeId
		left join Invoice
			on Invoice.LesseeId = LeaseContract.LesseeId
			and Invoice.InvoiceDate = wdate.withdate
		left join Incomings
			on Incomings.LesseeId = LeaseContract.LesseeId
			and Incomings.TransactionDate = wdate.withdate
		left join Loss
			on Loss.LesseeId = LeaseContract.LesseeId
			and Loss.TransactionDate = wdate.withdate
		group by withdate, room.BuildingCodeId, room.DisplaySeq
		order by withdate, room.DisplaySeq;
	END
GO


