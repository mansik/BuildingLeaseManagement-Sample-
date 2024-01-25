CREATE PROCEDURE [dbo].[spBuildingRoomCode_Insert]
	@BuildingCodeId int,
	@Room nvarchar(10),
	@Floor nvarchar(10),	
	@Area decimal(18,2),
	@Notes nvarchar(200),
	@DisplaySeq int,
	@UseFlag dbo.[Flag],
	@InsertUserId int,
	@UpdateUserId int,
	@Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[BuildingRoomCode]
                (BuildingCodeId,
				Room,
				[Floor],
				Area,
				Notes,
				DisplaySeq,
				UseFlag,
                InsertUserId,
                UpdateUserId)
	    values
               (@BuildingCodeId,
			   @Room,
			   @Floor,
			   @Area,
			   @Notes,
			   @DisplaySeq,
			   @UseFlag,
               @InsertUserId,
               @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END