CREATE PROCEDURE [dbo].[spAccountHangCode_GetsByInOutgoings]
	@InOutgoings int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[AccountHangCode]
	where InOutgoings = @InOutgoings
	order by DisplaySeq;
END