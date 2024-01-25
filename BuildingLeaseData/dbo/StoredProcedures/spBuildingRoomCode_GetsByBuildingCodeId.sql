CREATE PROCEDURE [dbo].[spBuildingRoomCode_GetsByBuildingCodeId]
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[BuildingRoomCode]
	where BuildingCodeId = @BuildingCodeId
	order by DisplaySeq;
END