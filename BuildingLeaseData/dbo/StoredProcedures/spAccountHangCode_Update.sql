CREATE PROCEDURE [dbo].[spAccountHangCode_Update]
	@Id int,
	@InOutgoings  int,
	@AccountHangName dbo.[Name],
	@DisplaySeq int,	
	@UseFlag dbo.[Flag],	
	@UpdateUserId int	 
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[AccountHangCode]
	set 
	InOutgoings = @InOutgoings,
	AccountHangName = @AccountHangName,	
	DisplaySeq = @DisplaySeq,
	UseFlag = @UseFlag,	
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END