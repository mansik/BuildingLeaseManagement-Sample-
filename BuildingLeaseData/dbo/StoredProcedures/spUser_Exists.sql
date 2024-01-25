CREATE PROCEDURE [dbo].[spUser_Exists]
	@UserName nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON

	if Exists (
		select 1
		from dbo.[User]
	where UserName = @UserName)

		select Exist =1;
	else
		select Exist = 0;
END