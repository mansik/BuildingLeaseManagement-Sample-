CREATE PROCEDURE [dbo].[spBuildingCode_IsUsed]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	if (Exists (
		select 1
		from dbo.[BuildingRoomCode]
		where BuildingCodeId = @Id)
		or Exists (
		select 1
		from dbo.[MaintenanceFeeDetailsSetting]
		where BuildingCodeId = @Id))

		select Exist =1;
	else
		select Exist = 0;
END