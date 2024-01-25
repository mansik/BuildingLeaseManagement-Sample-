CREATE PROCEDURE [dbo].[spBuildingCode_Exists]
	@BuildingName dbo.[Name]
AS
BEGIN
	SET NOCOUNT ON
	
	if Exists (
		select 1
		from dbo.[BuildingCode]
		where BuildingName = @BuildingName)

		select Exist =1;
	else
		select Exist = 0;
END