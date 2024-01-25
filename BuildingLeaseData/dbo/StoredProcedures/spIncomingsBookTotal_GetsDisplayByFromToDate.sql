CREATE PROCEDURE [dbo].[spIncomingsBookTotal_GetsDisplayByFromToDate]
	@FromDate DateTime,
	@ToDate DateTime
AS
with Account as
(
	/*수입부 계정과목*/
	select account.Id as AccountCodeId, hang.AccountHangName, account.AccountName,
	InOutgoings, hang.DisplaySeq as DisplaySeq1, account.DisplaySeq as DisplaySeq2
	from dbo.[AccountHangCode] hang
	left join dbo.[AccountCode] account
	 on hang.Id = account.AccountHangCodeId
	where account.UseFlag = 1 and InOutgoings = 0
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
		where account.Id = budget.AccountCodeId and hang.InOutgoings = 0)
)
,
Deposit
as
(
	/*수입액*/
	select AccountCodeId,	
	sum(DepositAmount) as IncomingsAmount
	from dbo.[CashBook]
	where TransactionDate >= @FromDate 
	and TransactionDate <= @ToDate
	and DelFlag = 0
	and InOutgoings = 0 
	group by AccountCodeId
	/*전년도 이월금*/
	/*
	union all	
	select case when account.AccountHangCodeId = 1 then 5 
	        when account.AccountHangCodeId = 2 then 9
		end as AccountCodeId,	
	sum(cb.DepositAmount) - sum(cb.LossAmount) as IncomingsAmount /* 수입액 - 결손액 */
	from dbo.[CashBook] cb
	inner join dbo.[AccountCode] account
	  on account.Id = cb.AccountCodeId	
	where cb.TransactionDate < datetrunc(year, @FromDate)
	and cb.DelFlag = 0
	and cb.InOutgoings in (0, 2)
	group by account.AccountHangCodeId
	*/
)
,
Loss
as
(
	/*결손액*/
	select AccountCodeId,	
	sum(LossAmount) as LossAmount
	from dbo.[CashBook]
	where TransactionDate >= @FromDate 
	and TransactionDate <= @ToDate
	and DelFlag = 0
	and InOutgoings = 2 
	group by AccountCodeId
)

select AccountHangName, 
	AccountName, 
	isnull(BudgetAmount,0) as BudgetAmount, 
	isnull(IncomingsAmount,0) as IncomingsAmount,
	isnull(LossAmount,0) as LossAmount,
	isnull(BudgetAmount,0)-isnull(IncomingsAmount,0)-isnull(LossAmount,0) as DifferenceAmount
from Account
left join Budget
	on Account.AccountCodeId = Budget.AccountCodeId
left join Deposit
	on Account.AccountCodeId = Deposit.AccountCodeId
left join Loss
	on Account.AccountCodeId = Loss.AccountCodeId
order by Account.DisplaySeq1, account.DisplaySeq2;