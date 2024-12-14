CREATE PROCEDURE [dbo].[spIncomingsDetails_�����_GetsDisplayByFromToDate]
	@SearchDate DateTime,
	@TotalCalcByYearFlag bit
AS
/*�߿�!! ��� ����� ���� ��ȸ �ȵ�*/
if (@TotalCalcByYearFlag = 1)
	BEGIN
		/*���ʺ��� ���� ���*/
		with BuildingRoomCode as
		(
			/*�ǹ�*/
			select room.Id as BuildingRoomCodeId, BuildingCodeId, [Floor], Room,
				building.DisplaySeq as DisplaySeq1, 
				room.DisplaySeq as DisplaySeq2
			from dbo.[BuildingRoomCode] room
			left join dbo.[BuildingCode] building
				on room.BuildingCodeId = building.Id
		)
		,
		PreviousInvoice
		as
		(
			/*���� û���� �հ�*/
			select LesseeId, sum(LineTotal) PreviousInvoiceAmount
			from dbo.[Invoice]
			where InvoiceDate < @SearchDate
			group by LesseeId
		)
		,	
		PreviousIncomings
		as
		(
			/*���� ���Ծ�-��վ� �հ�*/
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
			/*û����*/
			select BuildingRoomCodeId, LesseeId, LineTotal as InvoiceAmount
			from dbo.[Invoice]
			where InvoiceDate = @SearchDate
		)
		,
		InvoiceTotal
		as
		(
			/*û���� ����*/
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
			/*���Ծ�*/
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
			/*���Ծ� ����*/
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
			/*��վ�*/
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
			/*��վ� ����*/
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
			Invoice.LesseeId, 
			isnull(PreviousInvoiceAmount,0) - isnull(PreviousIncomingsAmount,0) as PreviousReceivableAmount, /*���� �̼���(û����-���Ծ�-��վ�)*/
			isnull(InvoiceAmount,0) as InvoiceAmount, /*��� û����*/
			isnull(InvoiceTotalAmount,0) as InvoiceTotalAmount, /*û���� ����*/
			isnull(IncomingsAmount,0) as IncomingsAmount, /*��� ���Ծ�*/
			isnull(IncomingsTotalAmount,0) as IncomingsTotalAmount, /*���Ծ� ����*/
			isnull(LossAmount,0) as LossAmount, /*��� ��վ�*/
			isnull(LossTotalAmount,0) as LossTotalAmount, /*��վ� ����*/
			isnull(InvoiceAmount,0) - isnull(IncomingsAmount,0) - isnull(LossAmount,0) as ReceivableAmount, /*��� �̼���*/
			isnull(PreviousInvoiceAmount,0) - isnull(PreviousIncomingsAmount,0) +  isnull(InvoiceAmount,0) - isnull(IncomingsAmount,0) - isnull(LossAmount,0) as ReceivableTotalAmount /*�� �̼���*/
		from BuildingRoomCode room
		left join Invoice
			on Invoice.BuildingRoomCodeId = room.BuildingRoomCodeId
		left join InvoiceTotal
			on InvoiceTotal.LesseeId = Invoice.LesseeId
		left join Incomings
			on Incomings.LesseeId = Invoice.LesseeId
		left join IncomingsTotal
			on IncomingsTotal.LesseeId = Invoice.LesseeId
		left join Loss
			on Loss.LesseeId = Invoice.LesseeId
		left join LossTotal
			on LossTotal.LesseeId = Invoice.LesseeId
		left join PreviousInvoice
			on PreviousInvoice.LesseeId = Invoice.LesseeId
		left join PreviousIncomings
			on PreviousIncomings.LesseeId = Invoice.LesseeId
		order by DisplaySeq1, DisplaySeq2, room.BuildingCodeId, [Floor], Room;
	END
else
	BEGIN
		/*�����ۺ��� ���� ���*/
		with BuildingRoomCode as
		(
			/*�ǹ�*/
			select room.Id as BuildingRoomCodeId, BuildingCodeId, [Floor], Room,
				building.DisplaySeq as DisplaySeq1, 
				room.DisplaySeq as DisplaySeq2
			from dbo.[BuildingRoomCode] room
			left join dbo.[BuildingCode] building
			  on room.BuildingCodeId = building.Id
		)
		,
		PreviousInvoice
		as
		(
			/*���� û���� �հ�*/
			select LesseeId, sum(LineTotal) PreviousInvoiceAmount
			from dbo.[Invoice]
			where InvoiceDate < @SearchDate
			group by LesseeId	
		)
		,	
		PreviousIncomings
		as
		(
			/*���� ���Ծ�-��վ� �հ�*/
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
			/*û����*/
			select BuildingRoomCodeId, LesseeId, LineTotal as InvoiceAmount
			from dbo.[Invoice]
			where InvoiceDate = @SearchDate
		)
		,
		InvoiceTotal
		as
		(
			/*û���� ����*/
			select LesseeId, sum(LineTotal) as InvoiceTotalAmount
			from dbo.[Invoice]
			where InvoiceDate <= @SearchDate
			group by LesseeId
		)
		,
		Incomings
		as
		(
			/*���Ծ�*/
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
			/*���Ծ� ����*/
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
			/*��վ�*/
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
			/*��վ� ����*/
			select LesseeId, 
				sum(LossAmount) as LossTotalAmount
			from dbo.[CashBook]
			where TransactionDate <= eomonth(@SearchDate)
				and DelFlag = 0
				and InOutgoings = 2 
			group by LesseeId
		)

		select room.BuildingCodeId, [Floor], Room,
			Invoice.LesseeId, 
			isnull(PreviousInvoiceAmount,0) - isnull(PreviousIncomingsAmount,0) as PreviousReceivableAmount, /*���� �̼���(û����-���Ծ�-��վ�)*/
			isnull(InvoiceAmount,0) as InvoiceAmount, /*��� û����*/
			isnull(InvoiceTotalAmount,0) as InvoiceTotalAmount, /*û���� ����*/
			isnull(IncomingsAmount,0) as IncomingsAmount, /*��� ���Ծ�*/
			isnull(IncomingsTotalAmount,0) as IncomingsTotalAmount, /*���Ծ� ����*/
			isnull(LossAmount,0) as LossAmount, /*��� ��վ�*/
			isnull(LossTotalAmount,0) as LossTotalAmount, /*��վ� ����*/
			isnull(InvoiceAmount,0) - isnull(IncomingsAmount,0) - isnull(LossAmount,0) as ReceivableAmount, /*��� �̼���*/
			isnull(PreviousInvoiceAmount,0) - isnull(PreviousIncomingsAmount,0) +  isnull(InvoiceAmount,0) - isnull(IncomingsAmount,0) - isnull(LossAmount,0) as ReceivableTotalAmount /*�� �̼���*/
		from BuildingRoomCode room
		left join Invoice
			on Invoice.BuildingRoomCodeId = room.BuildingRoomCodeId
		left join InvoiceTotal
			on InvoiceTotal.LesseeId = Invoice.LesseeId
		left join Incomings
			on Incomings.LesseeId = Invoice.LesseeId
		left join IncomingsTotal
			on IncomingsTotal.LesseeId = Invoice.LesseeId
		left join Loss
			on Loss.LesseeId = Invoice.LesseeId
		left join LossTotal
			on LossTotal.LesseeId = Invoice.LesseeId
		left join PreviousInvoice
			on PreviousInvoice.LesseeId = Invoice.LesseeId
		left join PreviousIncomings
			on PreviousIncomings.LesseeId = Invoice.LesseeId
		order by DisplaySeq1, DisplaySeq2, room.BuildingCodeId, [Floor], Room;
	END
GO


