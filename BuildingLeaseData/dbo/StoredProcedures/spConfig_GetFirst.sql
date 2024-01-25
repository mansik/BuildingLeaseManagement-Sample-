CREATE PROCEDURE [dbo].[spConfig_GetFirst]
AS
BEGIN
    SET NOCOUNT ON

	select top 1 * 
	from dbo.[Config];
END