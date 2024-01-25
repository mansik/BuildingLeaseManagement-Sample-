CREATE PROCEDURE [dbo].[spConfig_GetLastExpenseNumber]
AS
BEGIN
    SET NOCOUNT ON

	select top 1 LastExpenseNumber 
	from dbo.[Config];
END