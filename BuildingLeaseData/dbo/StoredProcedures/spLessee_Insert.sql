CREATE PROCEDURE [dbo].[spLessee_Insert]
	@Lessee dbo.[Name],
	@Owner dbo.[Name],
	@RRN nvarchar(15),
	@BRN nvarchar(12),
	@Contact nvarchar(200),
	@UnderContractFlag dbo.[Flag],
	@BillIssueDay nvarchar(20),
	@Notes nvarchar(200),	
	@InsertUserId int,
	@UpdateUserId int,
	@Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[Lessee]
                (Lessee,
				[Owner],
				RRN,
				BRN,
				Contact,
				UnderContractFlag,
				BillIssueDay,
				Notes,
                InsertUserId,
                UpdateUserId)
	    values
               (@Lessee,
			   @Owner,
			   @RRN,
			   @BRN,
			   @Contact,
			   @UnderContractFlag,
			   @BillIssueDay,
			   @Notes,
               @InsertUserId,
               @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END