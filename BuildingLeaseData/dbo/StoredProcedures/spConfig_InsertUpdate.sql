CREATE PROCEDURE [dbo].[spConfig_InsertUpdate]
	@OfficeTel nvarchar(20),
	@OfficeEmail nvarchar(50),
	@LastExpenseNumber int
AS
BEGIN
    SET NOCOUNT ON

	if Exists (select 1 
			from dbo.[Config])

		update dbo.[Config]
		set
		OfficeTel = @OfficeTel,
		OfficeEmail = @OfficeEmail,
		LastExpenseNumber = @LastExpenseNumber;
	else
		insert into dbo.[Config]
					(OfficeTel,
					OfficeEmail,
					LastExpenseNumber)
			values
				   (@OfficeTel,
				   @OfficeEmail,
				   @LastExpenseNumber);
END