CREATE PROCEDURE [dbo].[spGradeType_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[GradeType]
	order by DisplaySeq;
END