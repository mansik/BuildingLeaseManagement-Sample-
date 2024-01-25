CREATE PROCEDURE [dbo].[spGradeType_Update]
	@Id int,
	@GradeTypeName dbo.[Name],
	@DisplaySeq int,	
	@UseFlag dbo.Flag,	
	@UpdateUserId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[GradeType]
	set 
	GradeTypeName = @GradeTypeName,	
	DisplaySeq = @DisplaySeq,
	UseFlag = @UseFlag,	
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END