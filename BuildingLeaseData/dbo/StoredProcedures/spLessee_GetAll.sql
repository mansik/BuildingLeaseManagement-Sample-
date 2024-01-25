CREATE PROCEDURE [dbo].[spLessee_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[Lessee]
	where Id <> 1;
END