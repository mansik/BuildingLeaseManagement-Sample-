CREATE PROCEDURE [dbo].[spGradeType_Insert]    
    @GradeTypeName dbo.[Name],    
    @DisplaySeq int,
    @UseFlag [dbo].[Flag],
    @InsertUserId int,
	@UpdateUserId int,
    @Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[GradeType]
                (GradeTypeName,                
                DisplaySeq,
                UseFlag,
                InsertUserId,
				UpdateUserId)
	    values
               (@GradeTypeName,
               @DisplaySeq,
               @UseFlag,
               @InsertUserId,
			   @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END