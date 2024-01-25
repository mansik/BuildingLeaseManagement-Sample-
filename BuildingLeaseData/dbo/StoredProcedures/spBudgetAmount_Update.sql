CREATE PROCEDURE [dbo].[spBudgetAmount_Update]
	@Id int,
	@FiscalYear int,
	@AccountCodeId int,
	@BudgetAmount money,	
	@UpdateUserId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[BudgetAmount]
	set 
	FiscalYear = @FiscalYear,
	AccountCodeId = @AccountCodeId,
	BudgetAmount = @BudgetAmount,	
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END