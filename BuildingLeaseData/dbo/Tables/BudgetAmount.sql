CREATE TABLE [dbo].[BudgetAmount] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [FiscalYear]    INT      NOT NULL,
    [AccountCodeId] INT      NULL,
    [BudgetAmount]  MONEY    CONSTRAINT [DF_BudgetAmount_BudgetAmount] DEFAULT ((0)) NOT NULL,
    [InsertUserId]  INT      NULL,
    [InsertDate]    DATETIME CONSTRAINT [DF_BudgetAmount_InsertDate] DEFAULT (getutcdate()) NOT NULL,
    [UpdateUserId]  INT      NULL,
    [UpdateDate]    DATETIME CONSTRAINT [DF_BudgetAmount_UpdateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_BudgetAmount] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BudgetAmount_AccountCode] FOREIGN KEY ([AccountCodeId]) REFERENCES [dbo].[AccountCode] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'예산액', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BudgetAmount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'회계년도', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BudgetAmount', @level2type = N'COLUMN', @level2name = N'FiscalYear';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'FK, 계정과목코드', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BudgetAmount', @level2type = N'COLUMN', @level2name = N'AccountCodeId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'예산액', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BudgetAmount', @level2type = N'COLUMN', @level2name = N'BudgetAmount';

