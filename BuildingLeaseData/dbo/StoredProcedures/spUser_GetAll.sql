CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[User];
END