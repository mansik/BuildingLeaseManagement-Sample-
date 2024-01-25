CREATE PROCEDURE [dbo].[spLessee_Exists]
	@Lessee dbo.[Name]
AS
BEGIN
	SET NOCOUNT ON

	if Exists (
		select 1
		from dbo.[Lessee]
		where Lessee = @Lessee)

		select Exist =1;
	else
		select Exist = 0;
END