CREATE PROCEDURE [dbo].[spAccountCode_Insert]
	@AccountHangCodeId int,
	@AccountName dbo.[Name],
    @DisplaySeq int,
    @UseFlag [dbo].[Flag],
    @InsertUserId int,
	@UpdateUserId int,
    @Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[AccountCode]
                (AccountHangCodeId,
				AccountName,                
                DisplaySeq,
                UseFlag,
                InsertUserId,
				UpdateUserId)
	    values
               (@AccountHangCodeId,
			   @AccountName,
               @DisplaySeq,
               @UseFlag,
               @InsertUserId,
			   @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END