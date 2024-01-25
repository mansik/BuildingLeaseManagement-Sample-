CREATE PROCEDURE [dbo].[spBankBookCode_Exists]
	@BankBookName nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON

	
	if Exists (
		select 1
		from dbo.[BankBookCode]
		where BankBookName = @BankBookName)

		select Exist = 1;
	else
		select Exist = 0;
END