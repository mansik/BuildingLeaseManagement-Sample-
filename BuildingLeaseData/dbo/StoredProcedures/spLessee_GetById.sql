CREATE PROCEDURE [dbo].[spLessee_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[Lessee]
	where Id = @Id;
END