
CREATE PROCEDURE [dbo].[spCashBook_Insert]    
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
    @InsertUserId int,
	@UpdateUserId int,
    @Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[CashBook]
                (TransactionDate,
				TransactionDetails,
				BankBookCodeId,
				LesseeId,
				AccountCodeId,
				Creditor,
				ExpenseNumber,
				DepositAmount,
				WithdrawalAmount,
				LossAmount,
				Notes,
				InOutgoings,
				DelFlag,
                InsertUserId,
				UpdateUserId)
	    values
               (@TransactionDate,
				@TransactionDetails,
				@BankBookCodeId,
				@LesseeId,
				@AccountCodeId,
				@Creditor,
				@ExpenseNumber,
				@DepositAmount,
				@WithdrawalAmount,
				@LossAmount,
				@Notes,
				@InOutgoings,
				@DelFlag,
				@InsertUserId,
				@UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END