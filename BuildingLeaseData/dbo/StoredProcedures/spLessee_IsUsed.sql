CREATE PROCEDURE [dbo].[spLessee_IsUsed]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	if (Exists (
		select 1
		from dbo.[CashBook]
		where LesseeId = @Id)
		or Exists (
		select 1
		from dbo.[Invoice]
		where LesseeId = @Id)
		or Exists (
		select 1
		from dbo.[LeaseContract]
		where LesseeId = @Id)
		or Exists (
		select 1
		from dbo.[MaintenanceFeeDetails]
		where LesseeId = @Id))

		select Exist =1;
	else
		select Exist = 0;
END