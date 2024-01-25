CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@UserName nvarchar(20),
	@Password nvarchar(100),
	@GradeTypeId int,
	@UseFlag dbo.Flag,	
	@UpdateUserId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[User]
	set 
	UserName = @UserName,
	[Password] = @Password,
	GradeTypeId = @GradeTypeId,
	UseFlag = @UseFlag,	
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END