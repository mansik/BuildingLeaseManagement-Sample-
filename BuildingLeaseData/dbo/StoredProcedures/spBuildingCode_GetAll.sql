CREATE PROCEDURE [dbo].[spBuildingCode_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[BuildingCode]
	order by DisplaySeq;
END