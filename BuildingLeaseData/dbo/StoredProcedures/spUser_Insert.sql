CREATE PROCEDURE [dbo].[spUser_Insert]    
    @UserName nvarchar(20),
    @Password nvarchar(100),
    @GradeTypeId int,
    @UseFlag [dbo].[Flag],
    @InsertUserId int,	
	@UpdateUserId int,
    @Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[User]
                (UserName,
                [Password],
                GradeTypeId,
                UseFlag,
                InsertUserId,
				UpdateUserId)
	    values
               (@UserName,
               @Password,
               @GradeTypeId,
               @UseFlag,
               @InsertUserId,
			   @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END