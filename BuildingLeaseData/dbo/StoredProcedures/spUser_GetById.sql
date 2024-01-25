CREATE PROCEDURE [dbo].[spUser_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[User]
	where Id = @Id;
END