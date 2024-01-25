CREATE PROCEDURE [dbo].[spBuildingRoomCode_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[BuildingRoomCode]
	where Id = @Id;
END