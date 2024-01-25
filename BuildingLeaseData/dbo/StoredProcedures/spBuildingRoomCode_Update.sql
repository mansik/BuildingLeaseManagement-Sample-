CREATE PROCEDURE [dbo].[spBuildingRoomCode_Update]
	@Id int,
	@BuildingCodeId int,
	@Room nvarchar(10),
	@Floor nvarchar(10),	
	@Area decimal(18,2),
	@Notes nvarchar(200),
	@DisplaySeq int,
	@UseFlag dbo.[Flag],
	@UpdateUserId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[BuildingRoomCode]
	set 	
	BuildingCodeId = @BuildingCodeId,
	Room = @Room,
	[Floor] = @Floor,
	Area = @Area,
	Notes = @Notes,
	DisplaySeq = @DisplaySeq,
	UseFlag = @UseFlag,
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END