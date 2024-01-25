CREATE PROCEDURE [dbo].[spCashBook_GetAll]
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	select *
	from dbo.[CashBook];
END