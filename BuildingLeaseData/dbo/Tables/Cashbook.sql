CREATE TABLE [dbo].[CashBook] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [TransactionDate]    DATETIME       NOT NULL,
    [TransactionDetails] NVARCHAR (100) NOT NULL,
    [BankBookCodeId]     INT            NULL,
    [LesseeId]           INT            NULL,
    [AccountCodeId]      INT            NULL,
    [Creditor]           NVARCHAR (50)  NULL,
    [ExpenseNumber]      INT            NULL,
    [DepositAmount]      MONEY          CONSTRAINT [DF_CashBook_DepositAmount] DEFAULT ((0)) NOT NULL,
    [WithdrawalAmount]   MONEY          CONSTRAINT [DF_CashBook_WithdrawalAmount] DEFAULT ((0)) NOT NULL,
    [LossAmount]         MONEY          CONSTRAINT [DF_CashBook_LossAmount] DEFAULT ((0)) NOT NULL,
    [Notes]              NVARCHAR (50)  NULL,
    [InOutgoings]        INT            NOT NULL,
    [DelFlag]            [dbo].[Flag]   CONSTRAINT [DF_CashBook_UseFlag] DEFAULT ((0)) NOT NULL,
    [InsertUserId]       INT            NULL,
    [InsertDate]         DATETIME       CONSTRAINT [DF_CashBook_InsertDate] DEFAULT (getutcdate()) NOT NULL,
    [UpdateUserId]       INT            NULL,
    [UpdateDate]         DATETIME       CONSTRAINT [DF_CashBook_UpdateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_CashBook] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CashBook_BankBookCode] FOREIGN KEY ([BankBookCodeId]) REFERENCES [dbo].[BankBookCode] ([Id]),
    CONSTRAINT [FK_CashBook_Lessee] FOREIGN KEY ([LesseeId]) REFERENCES [dbo].[Lessee] ([Id]),
    CONSTRAINT [FK_CashBook_AccountCode] FOREIGN KEY ([AccountCodeId]) REFERENCES [dbo].[AccountCode] ([Id]),
    CONSTRAINT [CK_CashBook_InOutgoings] CHECK ([InOutgoings]=(2) OR [InOutgoings]=(1) OR [InOutgoings]=(0))
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'금전출납부', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CashBook';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'거래일자', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CashBook', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'적요', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CashBook', @level2type = N'COLUMN', @level2name = N'TransactionDetails';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'FK, 통장코드', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CashBook', @level2type = N'COLUMN', @level2name = N'BankBookCodeId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'FK, 임차인', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CashBook', @level2type = N'COLUMN', @level2name = N'LesseeId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'FK, 계정과목코드', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CashBook', @level2type = N'COLUMN', @level2name = N'AccountCodeId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'채주', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CashBook', @level2type = N'COLUMN', @level2name = N'Creditor';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'지출번호', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CashBook', @level2type = N'COLUMN', @level2name = N'ExpenseNumber';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'입금액', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CashBook', @level2type = N'COLUMN', @level2name = N'DepositAmount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'출금액', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CashBook', @level2type = N'COLUMN', @level2name = N'WithdrawalAmount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'결손액', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CashBook', @level2type = N'COLUMN', @level2name = N'LossAmount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'비고', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CashBook', @level2type = N'COLUMN', @level2name = N'Notes';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'입금/출금, 0 = 입금(수입), 1 = 출금(지출), 2 = 결손액', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CashBook', @level2type = N'COLUMN', @level2name = N'InOutgoings';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'삭제여부, 1 = Delete, 0 = not Delete', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CashBook', @level2type = N'COLUMN', @level2name = N'DelFlag';

