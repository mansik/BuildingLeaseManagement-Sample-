CREATE PROCEDURE [dbo].[spOutgoingsBook_GetsDisplayByFromToDate]
	@FromDate DateTime,
	@ToDate DateTime,
	@AccountCodeId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	select TransactionDate,
		'(' + bank.BankBookName + ') ' + cb.TransactionDetails as TransactionDetailsDisplay,
		Creditor, ExpenseNumber, WithdrawalAmount as OutgoingsAmount
	from dbo.[CashBook] cb 
	left join dbo.[BankBookCode] bank 
	  on cb.BankBookCodeId = bank.Id
	left join dbo.[Lessee] le
	  on cb.LesseeId = le.Id
	where TransactionDate >= @FromDate and TransactionDate <= @ToDate and AccountCodeId = @AccountCodeId and InOutgoings = 1 and DelFlag = 0
	order by TransactionDate;
END