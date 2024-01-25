CREATE PROCEDURE [dbo].[spLessee_Update]
	@Id int,
	@Lessee dbo.[Name],
	@Owner dbo.[Name],
	@RRN nvarchar(15),
	@BRN nvarchar(12),
	@Contact nvarchar(200),
	@UnderContractFlag dbo.[Flag],
	@BillIssueDay nvarchar(20),
	@Notes nvarchar(200),	
	@UpdateUserId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[Lessee]
	set 	
	Lessee = @Lessee,
	[Owner] = @Owner,
	RRN = @RRN,
	BRN = @BRN,
	Contact = @Contact,
	UnderContractFlag = @UnderContractFlag,
	BillIssueDay = @BillIssueDay,
	Notes = @Notes,
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END