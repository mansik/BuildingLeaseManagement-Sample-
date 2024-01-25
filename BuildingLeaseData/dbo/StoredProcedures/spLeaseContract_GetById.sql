CREATE PROCEDURE [dbo].[spLeaseContract_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[LeaseContract]
	where Id = @Id;
END