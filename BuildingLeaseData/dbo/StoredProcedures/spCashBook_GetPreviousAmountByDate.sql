CREATE PROCEDURE [dbo].[spCashBook_GetPreviousAmountByDate]
	@BaseDate DateTime
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	/* 입금액 - 출금액 */
	select isnull(sum(DepositAmount),0) - isnull(sum(WithdrawalAmount),0) as PreviousAmount
	from dbo.[CashBook]
	where TransactionDate < @BaseDate
	and DelFlag = 0
END