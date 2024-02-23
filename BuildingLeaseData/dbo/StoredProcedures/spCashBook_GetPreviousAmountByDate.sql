CREATE PROCEDURE [dbo].[spCashBook_GetPreviousAmountByDate]
	@BaseDate DateTime
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	/* 이월금 = 입금액 - 출금액 */
	select isnull(sum(DepositAmount),0) - isnull(sum(WithdrawalAmount),0) as PreviousAmount
	from dbo.[CashBook] main
	where TransactionDate < @BaseDate
	and DelFlag = 0
	/* 2024-01-01년부터 사용시 2024-01-01이전에 입력된 "전년도 이월금(AccountCodeId: 5, 9)"은 이월금 계산에 포함하며, 수입액은 제외한다. */
	and NOT EXISTS ( select 1 
				from dbo.[CashBook] sub
				where main.Id = sub.Id
				and sub.TransactionDate < '2024-01-01'
				and sub.AccountCodeId NOT IN (5, 9))
END