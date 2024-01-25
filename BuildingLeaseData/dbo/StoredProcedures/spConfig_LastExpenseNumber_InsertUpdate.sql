CREATE PROCEDURE [dbo].[spConfig_LastExpenseNumber_InsertUpdate]
　@LastExpenseNumber int
AS
BEGIN
    SET NOCOUNT ON

	if Exists (select 1 from dbo.[Config])		
		update dbo.[Config]
		set LastExpenseNumber = @LastExpenseNumber
		where LastExpenseNumber < @LastExpenseNumber;
	else
		insert into dbo.[Config] (LastExpenseNumber)
			values (@LastExpenseNumber);
END