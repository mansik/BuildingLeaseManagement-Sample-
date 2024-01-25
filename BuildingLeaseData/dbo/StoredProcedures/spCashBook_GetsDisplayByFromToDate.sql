CREATE PROCEDURE [dbo].[spCashBook_GetsDisplayByFromToDate]
	@FromDate DateTime,
	@ToDate DateTime
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	select cb.*,
		iif(cb.InOutgoings = 2, '', '(' + bank.BankBookName + ') ') + 
		iif(cb.InOutgoings = 1, '', le.Lessee + ' ') + 
		cb.TransactionDetails AS TransactionDetailsDisplay
	from dbo.[CashBook] cb 
	left join dbo.[BankBookCode] bank 
	  on cb.BankBookCodeId = bank.Id
	left join dbo.[Lessee] le
	  on cb.LesseeId = le.Id
	where cb.TransactionDate >= @FromDate and cb.TransactionDate <= @ToDate
	order by cb.TransactionDate, cb.Id;	
END