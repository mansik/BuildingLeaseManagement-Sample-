CREATE PROCEDURE [dbo].[spBankBookCode_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[BankBookCode]
	order by DisplaySeq;
END