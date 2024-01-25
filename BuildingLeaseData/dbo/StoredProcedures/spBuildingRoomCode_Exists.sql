CREATE PROCEDURE [dbo].[spBuildingRoomCode_Exists]
	@Room nvarchar(20),
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	if Exists (
		select 1
		from dbo.[BuildingRoomCode]
		where [Room] = @Room and BuildingCodeId = @BuildingCodeId)

		select Exist = 1;
	else
		select Exist = 0;
END