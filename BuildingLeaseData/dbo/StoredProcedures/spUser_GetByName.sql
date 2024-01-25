CREATE PROCEDURE [dbo].[spUser_GetByName]
	@UserName nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[User]
	where UserName = @UserName;
END