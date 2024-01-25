CREATE PROCEDURE [dbo].[spAccountCode_GetAll]
	@AccountHangCodeId int = null
AS
BEGIN
	SET NOCOUNT ON
	
	if (@AccountHangCodeId is null)
		BEGIN
			select *
			from dbo.[AccountCode]
			order by DisplaySeq;
		END
	else
		BEGIN
			select *
			from dbo.[AccountCode]
			where AccountHangCodeId  = @AccountHangCodeId			
			order by DisplaySeq;
		END	
END