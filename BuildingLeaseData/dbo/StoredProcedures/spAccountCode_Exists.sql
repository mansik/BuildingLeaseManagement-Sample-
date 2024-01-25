CREATE PROCEDURE [dbo].[spAccountCode_Exists]	
	@AccountName dbo.[Name],
	@AccountHangCodeId int	
AS
BEGIN
	SET NOCOUNT ON

	if Exists (
		select 1
		from dbo.[AccountCode]
		where AccountName = @AccountName and AccountHangCodeId = @AccountHangCodeId)		

		select Exist =1;
	else
		select Exist = 0;
END