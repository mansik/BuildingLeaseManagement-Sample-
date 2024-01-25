CREATE PROCEDURE [dbo].[spOutgoingsBookTotal_GetsDisplayByFromToDate]
	@FromDate DateTime,
	@ToDate DateTime
AS
with Account as
(
	/*지출부 계정과목*/
	select account.Id as AccountCodeId, hang.AccountHangName, account.AccountName,
	InOutgoings, hang.DisplaySeq as DisplaySeq1, account.DisplaySeq as DisplaySeq2
	from dbo.[AccountHangCode] hang
	left join dbo.[AccountCode] account
	 on hang.Id = account.AccountHangCodeId
	where account.UseFlag = 1 and InOutgoings = 1
)
,
Budget
as
(
	/*예산액*/
	select AccountCodeId, BudgetAmount
	from dbo.[BudgetAmount] budget
	where FiscalYear = year(@FromDate)
	and Exists (select 1
		from dbo.[AccountCode] account
		inner join dbo.[AccountHangCode] hang
		  on account.AccountHangCodeId = hang.Id
		where account.Id = budget.AccountCodeId and hang.InOutgoings = 1)
)
,
Deposit
as
(
	/*지출액*/
	select AccountCodeId, sum(WithdrawalAmount) as OutgoingsAmount
	from dbo.[CashBook] cb
	where TransactionDate >= @FromDate 
	and TransactionDate <= @ToDate
	and DelFlag = 0
	and InOutgoings = 1 
	group by AccountCodeId
)

select AccountHangName, AccountName, BudgetAmount, OutgoingsAmount
from Account
left join Budget
 on Account.AccountCodeId = Budget.AccountCodeId
left join Deposit
 on Account.AccountCodeId = Deposit.AccountCodeId
order by Account.DisplaySeq1, account.DisplaySeq2;