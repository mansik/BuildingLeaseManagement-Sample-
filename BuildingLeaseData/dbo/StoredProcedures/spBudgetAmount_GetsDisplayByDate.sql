CREATE PROCEDURE [dbo].[spBudgetAmount_GetsDisplayByDate]
	@FiscalYear int,
	@InOutgoings int
AS
BEGIN
	SET NOCOUNT ON
	
	select budget.Id, 
		hang.AccountHangName, 
		account.Id as AccountCodeId, 
		isnull(budget.BudgetAmount,0) as BudgetAmount
	from dbo.[AccountCode] account
	inner join dbo.[AccountHangCode] hang
	 on account.AccountHangCodeId = hang.Id 
	 and InOutgoings = @InOutgoings
	left join dbo.[BudgetAmount] budget
	 on account.Id = budget.AccountCodeId
	 and FiscalYear = @FiscalYear
	order by hang.DisplaySeq, account.DisplaySeq;
END