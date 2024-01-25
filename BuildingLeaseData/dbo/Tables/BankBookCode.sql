CREATE TABLE [dbo].[BankBookCode] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [BankBookName]  NVARCHAR (20)  NOT NULL,
    [BankName]      [dbo].[Name]   NULL,
    [AccountNumber] NVARCHAR (20)  NULL,
    [Notes]         NVARCHAR (200) NULL,
    [DisplaySeq]    INT            CONSTRAINT [DF_BankBookCode_DisplaySeq] DEFAULT ((1)) NOT NULL,
    [UseFlag]       [dbo].[Flag]   CONSTRAINT [DF_BankBookCode_UseFlag] DEFAULT ((1)) NOT NULL,
    [InsertUserId]  INT            NULL,
    [InsertDate]    DATETIME       CONSTRAINT [DF_BankBookCode_InsertDate] DEFAULT (getutcdate()) NOT NULL,
    [UpdateUserId]  INT            NULL,
    [UpdateDate]    DATETIME       CONSTRAINT [DF_BankBookCode_UpdateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_BankBookCode] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'통장코드', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BankBookCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'통장명칭', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BankBookCode', @level2type = N'COLUMN', @level2name = N'BankBookName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'은행명', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BankBookCode', @level2type = N'COLUMN', @level2name = N'BankName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'계좌번호', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BankBookCode', @level2type = N'COLUMN', @level2name = N'AccountNumber';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'비고', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BankBookCode', @level2type = N'COLUMN', @level2name = N'Notes';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'화면표시순서', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BankBookCode', @level2type = N'COLUMN', @level2name = N'DisplaySeq';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'사용여부, 1 = use, 0 = not use', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BankBookCode', @level2type = N'COLUMN', @level2name = N'UseFlag';

