CREATE PROCEDURE [dbo].[spGradeType_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[GradeType]
	where Id = @Id;
END