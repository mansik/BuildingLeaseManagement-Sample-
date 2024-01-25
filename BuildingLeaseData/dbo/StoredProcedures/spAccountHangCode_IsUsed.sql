CREATE PROCEDURE [dbo].[spAccountHangCode_IsUsed]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	if Exists (
		select 1
		from dbo.[AccountCode]
		where AccountHangCodeId = @Id)

		select Exist =1;
	else
		select Exist = 0;
END