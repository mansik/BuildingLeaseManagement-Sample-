CREATE PROCEDURE [dbo].[spBuildingCode_Update]
	@Id int,
	@BuildingName dbo.[Name],
	@Notes nvarchar(200),
	@DisplaySeq int,
	@UseFlag dbo.[Flag],	
	@UpdateUserId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[BuildingCode]
	set 	
	BuildingName = @BuildingName,
	Notes = @Notes,
	DisplaySeq = @DisplaySeq,
	UseFlag = @UseFlag,	
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END