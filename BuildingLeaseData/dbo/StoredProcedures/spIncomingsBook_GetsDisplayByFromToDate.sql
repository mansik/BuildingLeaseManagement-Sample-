CREATE PROCEDURE [dbo].[spIncomingsBook_GetsDisplayByFromToDate]
	@FromDate DateTime,
	@ToDate DateTime,
	@LesseeId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/
	with withTable as (
		/* 청구액 */
		/*
		select datetrunc(month, InvoiceDate) as TransactionDate,
		format(datetrunc(month,InvoiceDate), 'MM월 청구액(임대료)') as TransactionDetailsDisplay,
		MonthlyRent + MonthlyRentVAT as InvoiceAmount,
		0 as IncomingsAmount,	
		0 as LossAmount, 
		0 as ReceivableAmount,
		0 as DisplaySeq
		from dbo.[Invoice]
		where InvoiceDate >= @FromDate
		and InvoiceDate <= @ToDate
		and LesseeId = @LesseeId
		union all
		select datetrunc(month, InvoiceDate) as TransactionDate,
		format(datetrunc(month,InvoiceDate), 'MM월 청구액(관리비)') as TransactionDetailsDisplay,
		MaintenanceFee + MaintenanceFeeVAT as InvoiceAmount,
		0 as IncomingsAmount,	
		0 as LossAmount, 
		0 as ReceivableAmount,
		0 as DisplaySeq
		from dbo.[Invoice]
		where InvoiceDate >= @FromDate
		and InvoiceDate <= @ToDate
		and LesseeId = @LesseeId
		union all
		select datetrunc(month, InvoiceDate) as TransactionDate,
		format(datetrunc(month,InvoiceDate), 'MM월 청구액(전기요금)') as TransactionDetailsDisplay,
		ElectricBill + ElectricBillVAT as InvoiceAmount,
		0 as IncomingsAmount,	
		0 as LossAmount, 
		0 as ReceivableAmount,
		0 as DisplaySeq
		from dbo.[Invoice]
		where InvoiceDate >= @FromDate
		and InvoiceDate <= @ToDate
		and LesseeId = @LesseeId
		union all
		select datetrunc(month, InvoiceDate) as TransactionDate,
		format(datetrunc(month,InvoiceDate), 'MM월 청구액(수도료)') as TransactionDetailsDisplay,
		WaterBill as InvoiceAmount,
		0 as IncomingsAmount,	
		0 as LossAmount, 
		0 as ReceivableAmount,
		0 as DisplaySeq
		from dbo.[Invoice]
		where InvoiceDate >= @FromDate
		and InvoiceDate <= @ToDate
		and LesseeId = @LesseeId
		union all
		select datetrunc(month, InvoiceDate) as TransactionDate,
		format(datetrunc(month,InvoiceDate), 'MM월 청구액(도로점용료)') as TransactionDetailsDisplay,
		RoadOccupancyFee + RoadOccupancyFeeVAT as InvoiceAmount,
		0 as IncomingsAmount,	
		0 as LossAmount, 
		0 as ReceivableAmount,
		0 as DisplaySeq
		from dbo.[Invoice]
		where InvoiceDate >= @FromDate
		and InvoiceDate <= @ToDate
		and LesseeId = @LesseeId
		union all
		select datetrunc(month, InvoiceDate) as TransactionDate,
		format(datetrunc(month,InvoiceDate), 'MM월 청구액(교통유발부담금)') as TransactionDetailsDisplay,
		TrafficCausingCharge + TrafficCausingChargeVAT as InvoiceAmount,
		0 as IncomingsAmount,	
		0 as LossAmount, 
		0 as ReceivableAmount,
		0 as DisplaySeq
		from dbo.[Invoice]
		where InvoiceDate >= @FromDate
		and InvoiceDate <= @ToDate
		and LesseeId = @LesseeId
		*/
		select datetrunc(month, InvoiceDate) as TransactionDate,
		format(datetrunc(month,InvoiceDate), 'MM월 청구액') as TransactionDetailsDisplay,
		isnull(LineTotal,0) as InvoiceAmount,
		0 as IncomingsAmount,	
		0 as LossAmount, 
		0 as ReceivableAmount,
		0 as DisplaySeq
		from dbo.[Invoice]
		where InvoiceDate >= @FromDate
		and InvoiceDate <= @ToDate
		and LesseeId = @LesseeId
		union all
		/* 수입액 */
		select TransactionDate, 
			TransactionDetails as TransactionDetailsDisplay, 
			0 as InvoiceAmount, 
			DepositAmount as IncomingsAmount,
			0 as LossAmount,
			0 as ReceivableAmount, 
			Id as displaySeq
		from dbo.[CashBook]
		where TransactionDate >= @FromDate and TransactionDate <= @ToDate 
		and LesseeId = @LesseeId
		and InOutgoings = 0
		and DelFlag = 0	
		union all
		/* 결손액 */
		select TransactionDate, 
			TransactionDetails as TransactionDetailsDisplay, 
			0 as InvoiceAmount, 
			0 as IncomingsAmount,
			LossAmount,
			0 as ReceivableAmount, 
			Id as displaySeq
		from dbo.[CashBook]
		where TransactionDate >= @FromDate and TransactionDate <= @ToDate 
		and LesseeId = @LesseeId
		and InOutgoings = 2
		and DelFlag = 0				
		union all
		/* 미수금 */
		select datetrunc(month, @FromDate) as TransactionDate,		
		'전월 미수금' as TransactionDetailsDisplay,
		0 as InvoiceAmount,
		0 as IncomingsAmount,	
		0 as LossAmount, 
		/* 미수금 = 청구서 총액 - 입금액 - 결손액 */
		/* 청구서 총액 */
		(select isnull(sum(LineTotal),0)
		from dbo.[Invoice]
		where InvoiceDate < @FromDate
		and LesseeId = @LesseeId)		
		- 
		/* 입금액 */
		(select isnull(sum(DepositAmount),0)
		from dbo.[CashBook]
		where TransactionDate < @FromDate
		and LesseeId = @LesseeId
		and InOutgoings = 0
		and DelFlag = 0)		
		- 
		/* 결손액 */
		(select isnull(sum(LossAmount),0)
		from dbo.[CashBook]
		where TransactionDate < @FromDate
		and LesseeId = @LesseeId
		and InOutgoings = 2
		and DelFlag = 0) as ReceivableAmount,
		-1 as DisplaySeq
		)

		select * from withTable
		order by TransactionDate, DisplaySeq;
END