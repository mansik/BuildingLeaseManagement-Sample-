CREATE PROCEDURE [dbo].[spCashBook_Update]    
    @Id int,
	@TransactionDate datetime,
	@TransactionDetails nvarchar(100),
	@BankBookCodeId int,
	@LesseeId int,
	@AccountCodeId int,
	@Creditor nvarchar(50),
	@ExpenseNumber int,
	@DepositAmount money,
	@WithdrawalAmount money,
	@LossAmount money,
	@Notes nvarchar(50),
	@InOutgoings int,
	@DelFlag [dbo].[Flag],
    @UpdateUserId int
AS
BEGIN    
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[CashBook]
	set 
	TransactionDate = @TransactionDate,
	TransactionDetails = @TransactionDetails,
	BankBookCodeId = @BankBookCodeId,
	LesseeId = @LesseeId,
	AccountCodeId = @AccountCodeId,
	Creditor = @Creditor,
	ExpenseNumber = @ExpenseNumber,
	DepositAmount = @DepositAmount,
	WithdrawalAmount = @WithdrawalAmount,
	LossAmount = @LossAmount,
	Notes = @Notes,
	InOutgoings = @InOutgoings,
	DelFlag = @DelFlag,
	UpdateUserId = @UpdateUserId,	
	UpdateDate = getutcdate()
	where Id = @Id;
END