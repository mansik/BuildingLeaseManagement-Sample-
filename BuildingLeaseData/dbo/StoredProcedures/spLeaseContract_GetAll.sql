CREATE PROCEDURE [dbo].[spLeaseContract_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[LeaseContract]
	order by ContractStartDate desc;
END