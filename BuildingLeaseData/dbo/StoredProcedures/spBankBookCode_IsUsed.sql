CREATE PROCEDURE [dbo].[spBankBookCode_IsUsed]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	if (Exists (
		select 1
		from dbo.[CashBook]
		where BankBookCodeId = @Id)		
		or Exists (
		select 1
		from dbo.[MaintenanceFeeDetailsSetting]
		where BankBookCodeId = @Id))

		select Exist =1;
	else
		select Exist = 0;
END