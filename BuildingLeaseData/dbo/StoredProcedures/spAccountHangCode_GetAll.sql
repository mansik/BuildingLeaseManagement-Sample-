CREATE PROCEDURE [dbo].[spAccountHangCode_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[AccountHangCode]
	order by DisplaySeq;
END