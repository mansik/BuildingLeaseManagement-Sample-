CREATE PROCEDURE [dbo].[spAccountHangCode_Insert]
	@InOutgoings int,
    @AccountHangName dbo.[Name],
    @DisplaySeq int,
    @UseFlag [dbo].[Flag],
    @InsertUserId int,
	@UpdateUserId int,
    @Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[AccountHangCode]
                (InOutgoings,
				AccountHangName,                
                DisplaySeq,
                UseFlag,
                InsertUserId,
				UpdateUserId)
	    values
               (@InOutgoings,
			   @AccountHangName,
               @DisplaySeq,
               @UseFlag,
               @InsertUserId,
			   @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END