CREATE PROCEDURE [dbo].[spMaintenanceFeeDetailsSetting_GetByDate]
	@MaintenanceFeeDetailsDate datetime,
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[MaintenanceFeeDetailsSetting]
	where MaintenanceFeeDetailsDate = @MaintenanceFeeDetailsDate and BuildingCodeId = @BuildingCodeId;	
END