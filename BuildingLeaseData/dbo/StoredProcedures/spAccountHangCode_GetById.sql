CREATE PROCEDURE [dbo].[spAccountHangCode_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[AccountHangCode]
	where Id = @Id;
END