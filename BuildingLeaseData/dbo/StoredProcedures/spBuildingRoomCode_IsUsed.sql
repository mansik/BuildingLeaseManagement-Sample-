CREATE PROCEDURE [dbo].[spBuildingRoomCode_IsUsed]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	if (Exists (
		select 1
		from dbo.[Invoice]
		where BuildingRoomCodeId = @Id)
		or Exists (
		select 1
		from dbo.[LeaseContract]
		where BuildingRoomCodeId = @Id)
		or Exists (
		select 1
		from dbo.[MaintenanceFeeDetails]
		where BuildingRoomCodeId = @Id))

		select Exist =1;
	else
		select Exist = 0;
END