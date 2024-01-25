CREATE PROCEDURE [dbo].[spMaintenanceFeeDetails_GetsDisplayByDate]
	@MaintenanceFeeDetailsDate datetime,
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	select main.*,
	le.Lessee,
	room.Area
	from dbo.[MaintenanceFeeDetails] main
	left join dbo.[BuildingRoomCode] room
		on main.BuildingRoomCodeId = room.Id
	left join dbo.[Lessee] le
		on main.LesseeId = le.Id	
	where main.MaintenanceFeeDetailsDate = @MaintenanceFeeDetailsDate and room.BuildingCodeId = @BuildingCodeId
	order by room.DisplaySeq;
END