CREATE PROCEDURE [dbo].[spBuildingRoomCode_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[BuildingRoomCode]
	order by DisplaySeq;
END