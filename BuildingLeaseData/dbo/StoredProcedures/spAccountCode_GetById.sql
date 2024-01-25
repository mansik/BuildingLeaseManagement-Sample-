CREATE PROCEDURE [dbo].[spAccountCode_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[AccountCode]
	where Id = @Id;
END