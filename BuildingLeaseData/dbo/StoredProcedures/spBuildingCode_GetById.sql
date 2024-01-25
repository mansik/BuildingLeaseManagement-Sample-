CREATE PROCEDURE [dbo].[spBuildingCode_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[BuildingCode]
	where Id = @Id;
END