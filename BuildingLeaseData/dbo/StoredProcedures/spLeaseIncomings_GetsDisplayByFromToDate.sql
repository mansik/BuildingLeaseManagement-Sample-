CREATE PROCEDURE [dbo].[spLeaseIncomings_GetsDisplayByFromToDate]
	@FromDate DateTime,
	@ToDate DateTime
AS
/*
- ���� ����
- ��� ����(û�������Ͱ� ��������� ��) ������ �߻��� ���� ������ �ذ�
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
			/*�ǹ�*/
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
			/*�Ӵ��� ���: ��� ����(û�������Ͱ� ��������� ��) ������ �߻��� ���� ������ �ذ��ϱ� ����*/
			select distinct BuildingRoomCodeId, LesseeId
			from dbo.[LeaseContract]
		)
		,
		Invoice
		as
		(
			/*û����*/
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
			/*���Ծ�*/
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
			/*��վ�*/
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
			sum(isnull(InvoiceAmount,0)) as InvoiceAmount, /*��� û����*/
			sum(isnull(IncomingsAmount,0)) as IncomingsAmount, /*��� ���Ծ�*/
			sum(isnull(LossAmount,0)) as LossAmount /*��� ��վ�*/
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


