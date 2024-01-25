CREATE PROCEDURE [dbo].[spAccountHangCode_Exists]
	@AccountHangName dbo.[Name],
	@InOutgoings int
AS
BEGIN
	SET NOCOUNT ON

	if Exists (
		select 1
		from dbo.[AccountHangCode]
		where AccountHangName = @AccountHangName and InOutgoings = @InOutgoings)

		select Exist =1;
	else
		select Exist = 0;
END