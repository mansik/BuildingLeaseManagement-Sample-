CREATE PROCEDURE [dbo].[spIncomingsDetails_GetsDisplayByFromToDate]
	@SearchDate DateTime,
	@TotalCalcByYearFlag bit
AS
/*당해 년도에 계약 종료된 것도 모두 조회(년초부터 모두 조회)*/
if (@TotalCalcByYearFlag = 1)
	BEGIN
		/*연초부터 누계 계산*/
		with BuildingRoomCode as
		(
			/*건물*/
			select room.Id as BuildingRoomCodeId, BuildingCodeId, [Floor], Room,
				building.DisplaySeq as DisplaySeq1, 
				room.DisplaySeq as DisplaySeq2
			from dbo.[BuildingRoomCode] room
			left join dbo.[BuildingCode] building
				on room.BuildingCodeId = building.Id
		)
		, 
		LeaseContract
		as
		(
			/*임대차 계약: 당해 년도에 계약 종료된 것도 모두 조회하기 위함(년초부터 모두 조회)*/
			select distinct BuildingRoomCodeId, LesseeId
			from dbo.[LeaseContract]
			where ContractEndDate >= datetrunc(year, @SearchDate)
		)
		,
		PreviousInvoice
		as
		(
			/*이전 청구액 합계*/
			select LesseeId, sum(LineTotal) PreviousInvoiceAmount
			from dbo.[Invoice]
			where InvoiceDate < @SearchDate
			group by LesseeId
		)
		,	
		PreviousIncomings
		as
		(
			/*이전 수입액-결손액 합계*/
				select LesseeId,
					isnull(sum(DepositAmount),0) - isnull(sum(LossAmount),0) as PreviousIncomingsAmount
				from dbo.[CashBook]
				where TransactionDate < @SearchDate	
					and DelFlag = 0
					and InOutgoings in (0 ,2)
				group by LesseeId
		)
		,
		Invoice
		as
		(
			/*청구액*/		
			select BuildingRoomCodeId, LesseeId, LineTotal as InvoiceAmount
			from dbo.[Invoice]
			where InvoiceDate = @SearchDate
		)
		,
		InvoiceTotal
		as
		(
			/*청구액 누계*/
			select LesseeId, sum(LineTotal) as InvoiceTotalAmount
			from dbo.[Invoice]
			where InvoiceDate >= datetrunc(year, @SearchDate)
				and InvoiceDate <= @SearchDate
			group by LesseeId
		)
		,
		Incomings
		as
		(
			/*수입액*/
			select LesseeId,
				sum(DepositAmount) as IncomingsAmount
			from dbo.[CashBook]
			where TransactionDate >= @SearchDate 
				and TransactionDate <= eomonth(@SearchDate)
				and DelFlag = 0
				and InOutgoings = 0 
			group by LesseeId
		)
		,
		IncomingsTotal
		as
		(
			/*수입액 누계*/
			select LesseeId, 
				sum(DepositAmount) as IncomingsTotalAmount
			from dbo.[CashBook]
			where TransactionDate >= datetrunc(year, @SearchDate)
				and TransactionDate <= eomonth(@SearchDate)
				and DelFlag = 0
				and InOutgoings = 0 
			group by LesseeId
		)
		,
		Loss
		as
		(
			/*결손액*/
			select LesseeId,
				sum(LossAmount) as LossAmount
			from dbo.[CashBook]
			where TransactionDate >= @SearchDate 
				and TransactionDate <= eomonth(@SearchDate)
				and DelFlag = 0
				and InOutgoings = 2 
			group by LesseeId
		)
		,
		LossTotal
		as
		(
			/*결손액 누계*/
			select LesseeId, 
				sum(LossAmount) as LossTotalAmount
			from dbo.[CashBook]
			where TransactionDate >= datetrunc(year, @SearchDate)
				and TransactionDate <= eomonth(@SearchDate)
				and DelFlag = 0
				and InOutgoings = 2 
			group by LesseeId
		)

		select room.BuildingCodeId, [Floor], Room,
			LeaseContract.LesseeId, 
			isnull(PreviousInvoiceAmount,0) - isnull(PreviousIncomingsAmount,0) as PreviousReceivableAmount, /*전월 미수금(청구액-수입액-결손액)*/
			isnull(InvoiceAmount,0) as InvoiceAmount, /*당월 청구액*/
			isnull(InvoiceTotalAmount,0) as InvoiceTotalAmount, /*청구액 누계*/
			isnull(IncomingsAmount,0) as IncomingsAmount, /*당월 수입액*/
			isnull(IncomingsTotalAmount,0) as IncomingsTotalAmount, /*수입액 누계*/
			isnull(LossAmount,0) as LossAmount, /*당월 결손액*/
			isnull(LossTotalAmount,0) as LossTotalAmount, /*결손액 누계*/
			isnull(InvoiceAmount,0) - isnull(IncomingsAmount,0) - isnull(LossAmount,0) as ReceivableAmount, /*당월 미수금*/
			isnull(PreviousInvoiceAmount,0) - isnull(PreviousIncomingsAmount,0) +  isnull(InvoiceAmount,0) - isnull(IncomingsAmount,0) - isnull(LossAmount,0) as ReceivableTotalAmount /*총 미수금*/
		from BuildingRoomCode room
		left join LeaseContract
			on room.BuildingRoomCodeId = LeaseContract.BuildingRoomCodeId
		left join Invoice
			on Invoice.BuildingRoomCodeId = LeaseContract.BuildingRoomCodeId
			and Invoice.LesseeId = LeaseContract.LesseeId
		left join InvoiceTotal
			on InvoiceTotal.LesseeId = LeaseContract.LesseeId
		left join Incomings
			on Incomings.LesseeId = LeaseContract.LesseeId
		left join IncomingsTotal
			on IncomingsTotal.LesseeId = LeaseContract.LesseeId
		left join Loss
			on Loss.LesseeId = LeaseContract.LesseeId
		left join LossTotal
			on LossTotal.LesseeId = LeaseContract.LesseeId
		left join PreviousInvoice
			on PreviousInvoice.LesseeId = LeaseContract.LesseeId
		left join PreviousIncomings
			on PreviousIncomings.LesseeId = LeaseContract.LesseeId		  
		order by DisplaySeq1, DisplaySeq2, room.BuildingCodeId, [Floor], Room;
	END
else
	BEGIN
		/*계약시작부터 누계 계산*/
		with BuildingRoomCode as
		(
			/*건물*/
			select room.Id as BuildingRoomCodeId, BuildingCodeId, [Floor], Room,
				building.DisplaySeq as DisplaySeq1, 
				room.DisplaySeq as DisplaySeq2
			from dbo.[BuildingRoomCode] room
			left join dbo.[BuildingCode] building
			  on room.BuildingCodeId = building.Id
		)
		, 
		LeaseContract
		as
		(
			/*임대차 계약: 당해 년도에 계약 종료된 것도 모두 조회하기 위함(년초부터 모두 조회)*/
			select distinct BuildingRoomCodeId, LesseeId
			from dbo.[LeaseContract]
			where ContractEndDate >= datetrunc(year, @SearchDate)
		)
		,
		PreviousInvoice
		as
		(
			/*이전 청구액 합계*/
			select LesseeId, sum(LineTotal) PreviousInvoiceAmount
			from dbo.[Invoice]
			where InvoiceDate < @SearchDate
			group by LesseeId	
		)
		,	
		PreviousIncomings
		as
		(
			/*이전 수입액-결손액 합계*/
				select LesseeId,
					isnull(sum(DepositAmount),0) - isnull(sum(LossAmount),0) as PreviousIncomingsAmount
				from dbo.[CashBook]
				where TransactionDate < @SearchDate	
					and DelFlag = 0
					and InOutgoings in (0 ,2)
				group by LesseeId	
		)
		,
		Invoice
		as
		(
			/*청구액*/		
			select BuildingRoomCodeId, LesseeId, LineTotal as InvoiceAmount
			from dbo.[Invoice]
			where InvoiceDate = @SearchDate
		)
		,
		InvoiceTotal
		as
		(
			/*청구액 누계*/
			select LesseeId, sum(LineTotal) as InvoiceTotalAmount
			from dbo.[Invoice]
			where InvoiceDate <= @SearchDate
			group by LesseeId
		)
		,
		Incomings
		as
		(
			/*수입액*/
			select LesseeId,
				sum(DepositAmount) as IncomingsAmount
			from dbo.[CashBook]
			where TransactionDate >= @SearchDate 
				and TransactionDate <= eomonth(@SearchDate)
				and DelFlag = 0
				and InOutgoings = 0 
			group by LesseeId
		)
		,
		IncomingsTotal
		as
		(
			/*수입액 누계*/
			select LesseeId, 
				sum(DepositAmount) as IncomingsTotalAmount
			from dbo.[CashBook]
			where TransactionDate <= eomonth(@SearchDate)
				and DelFlag = 0
				and InOutgoings = 0 
			group by LesseeId
		)
		,
		Loss
		as
		(
			/*결손액*/
			select LesseeId,
				sum(LossAmount) as LossAmount
			from dbo.[CashBook]
			where TransactionDate >= @SearchDate 
				and TransactionDate <= eomonth(@SearchDate)
				and DelFlag = 0
				and InOutgoings = 2 
			group by LesseeId
		)
		,
		LossTotal
		as
		(
			/*결손액 누계*/
			select LesseeId, 
				sum(LossAmount) as LossTotalAmount
			from dbo.[CashBook]
			where TransactionDate <= eomonth(@SearchDate)
				and DelFlag = 0
				and InOutgoings = 2 
			group by LesseeId
		)

		select room.BuildingCodeId, [Floor], Room,
			LeaseContract.LesseeId, 
			isnull(PreviousInvoiceAmount,0) - isnull(PreviousIncomingsAmount,0) as PreviousReceivableAmount, /*전월 미수금(청구액-수입액-결손액)*/
			isnull(InvoiceAmount,0) as InvoiceAmount, /*당월 청구액*/
			isnull(InvoiceTotalAmount,0) as InvoiceTotalAmount, /*청구액 누계*/
			isnull(IncomingsAmount,0) as IncomingsAmount, /*당월 수입액*/
			isnull(IncomingsTotalAmount,0) as IncomingsTotalAmount, /*수입액 누계*/
			isnull(LossAmount,0) as LossAmount, /*당월 결손액*/
			isnull(LossTotalAmount,0) as LossTotalAmount, /*결손액 누계*/
			isnull(InvoiceAmount,0) - isnull(IncomingsAmount,0) - isnull(LossAmount,0) as ReceivableAmount, /*당월 미수금*/
			isnull(PreviousInvoiceAmount,0) - isnull(PreviousIncomingsAmount,0) +  isnull(InvoiceAmount,0) - isnull(IncomingsAmount,0) - isnull(LossAmount,0) as ReceivableTotalAmount /*총 미수금*/
		from BuildingRoomCode room
		left join LeaseContract
			on room.BuildingRoomCodeId = LeaseContract.BuildingRoomCodeId
		left join Invoice
			on Invoice.BuildingRoomCodeId = LeaseContract.BuildingRoomCodeId
			and Invoice.LesseeId = LeaseContract.LesseeId
		left join InvoiceTotal
			on InvoiceTotal.LesseeId = LeaseContract.LesseeId
		left join Incomings
			on Incomings.LesseeId = LeaseContract.LesseeId
		left join IncomingsTotal
			on IncomingsTotal.LesseeId = LeaseContract.LesseeId
		left join Loss
			on Loss.LesseeId = LeaseContract.LesseeId
		left join LossTotal
			on LossTotal.LesseeId = LeaseContract.LesseeId
		left join PreviousInvoice
			on PreviousInvoice.LesseeId = LeaseContract.LesseeId
		left join PreviousIncomings
			on PreviousIncomings.LesseeId = LeaseContract.LesseeId
		order by DisplaySeq1, DisplaySeq2, room.BuildingCodeId, [Floor], Room;
	END
GO


