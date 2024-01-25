CREATE PROCEDURE [dbo].[spBuildingCode_Insert]
	@BuildingName dbo.[Name],
	@Notes nvarchar(200),
	@DisplaySeq int,
	@UseFlag dbo.[Flag],
	@InsertUserId int,
	@UpdateUserId int,
	@Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[BuildingCode]
                (BuildingName,
				Notes,
				DisplaySeq,
                UseFlag,
                InsertUserId,
                UpdateUserId)
	    values
               (@BuildingName,
			   @Notes,
			   @DisplaySeq,
               @UseFlag,
               @InsertUserId,
               @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END