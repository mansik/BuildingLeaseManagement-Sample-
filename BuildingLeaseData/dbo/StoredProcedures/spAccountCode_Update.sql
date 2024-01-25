CREATE PROCEDURE [dbo].[spAccountCode_Update]
	@Id int,
	@AccountHangCodeId int,
	@AccountName dbo.[Name],
	@DisplaySeq int,	
	@UseFlag dbo.[Flag],	
	@UpdateUserId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[AccountCode]
	set 
	AccountHangCodeId = @AccountHangCodeId,
	AccountName = @AccountName,	
	DisplaySeq = @DisplaySeq,
	UseFlag = @UseFlag,	
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END