CREATE PROCEDURE [dbo].[spBankBookCode_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[BankBookCode]
	where Id = @Id;
END