CREATE PROCEDURE [dbo].[spAccountCode_IsUsed]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	if (Exists (
		select 1
		from dbo.[CashBook]
		where AccountCodeId = @Id)
		or Exists (
		select 1
		from dbo.[BudgetAmount]
		where AccountCodeId = @Id))

		select Exist =1;
	else
		select Exist = 0;
END