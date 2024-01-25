CREATE PROCEDURE [dbo].[spBankBookCode_Insert]
	@BankBookName nvarchar(20),
	@BankName dbo.[Name],
	@AccountNumber nvarchar(20),
	@Notes nvarchar(200),
	@DisplaySeq int,
	@UseFlag dbo.[Flag],
	@InsertUserId int,
	@UpdateUserId int,
	@Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[BankBookCode]
                (BankBookName,
				BankName,
				AccountNumber,
				Notes,
                DisplaySeq,
                UseFlag,
                InsertUserId,
                UpdateUserId)
	    values
               (@BankBookName,
			   @BankName,
			   @AccountNumber,
			   @Notes,
               @DisplaySeq,
               @UseFlag,
               @InsertUserId,
               @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END