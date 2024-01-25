CREATE PROCEDURE [dbo].[spBankBookCode_Update]	
	@BankBookName nvarchar(20),
	@BankName dbo.[Name],
	@AccountNumber nvarchar(20),
	@Notes nvarchar(200),
	@DisplaySeq int,
	@UseFlag dbo.[Flag],
	@UpdateUserId int,
	@Id int out
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[BankBookCode]
	set 	
	BankBookName = @BankBookName,
	BankName = @BankName,
	AccountNumber = @AccountNumber,
	Notes = @Notes,
	DisplaySeq = @DisplaySeq,
	UseFlag = @UseFlag,	
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END