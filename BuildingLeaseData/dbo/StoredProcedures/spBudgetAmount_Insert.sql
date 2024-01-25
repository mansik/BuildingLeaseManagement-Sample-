CREATE PROCEDURE [dbo].[spBudgetAmount_Insert]
	@FiscalYear int,
	@AccountCodeId int,
	@BudgetAmount money,
    @InsertUserId int,
	@UpdateUserId int,
    @Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[BudgetAmount]
                (FiscalYear,
				AccountCodeId,
				BudgetAmount,                
                InsertUserId,
				UpdateUserId)
	    values
               (@FiscalYear,
			   @AccountCodeId,
			   @BudgetAmount,
               
               @InsertUserId,
			   @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END