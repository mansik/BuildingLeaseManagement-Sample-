CREATE PROCEDURE [dbo].[spBankBookCode_Delete]
	@Id int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	delete 
	from dbo.[BankBookCode]
	where Id = @Id;
END