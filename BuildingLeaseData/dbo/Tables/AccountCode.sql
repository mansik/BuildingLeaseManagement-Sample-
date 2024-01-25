CREATE TABLE [dbo].[AccountCode] (
    [Id]                INT          IDENTITY (1, 1) NOT NULL,
    [AccountHangCodeId] INT          NOT NULL,
    [AccountName]       [dbo].[Name] NOT NULL,
    [DisplaySeq]        INT          CONSTRAINT [DF_AccountCode_DisplaySeq] DEFAULT ((1)) NOT NULL,
    [UseFlag]           [dbo].[Flag] CONSTRAINT [DF_AccountCode_UseFlag] DEFAULT ((1)) NOT NULL,
    [InsertUserId]      INT          NULL,
    [InsertDate]        DATETIME     CONSTRAINT [DF_AccountCode_InsertDate] DEFAULT (getutcdate()) NOT NULL,
    [UpdateUserId]      INT          NULL,
    [UpdateDate]        DATETIME     CONSTRAINT [DF_AccountCode_UpdateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_AccountCode] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AccountCode_AccountHangCode] FOREIGN KEY ([AccountHangCodeId]) REFERENCES [dbo].[AccountHangCode] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'계정과목코드(항/목중 목)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'FK, 계정과목 항 코드, 관/항/목중 항을 의미', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountCode', @level2type = N'COLUMN', @level2name = N'AccountHangCodeId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'계정과목 목 명칭,  관/항/목중 목을 의미', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountCode', @level2type = N'COLUMN', @level2name = N'AccountName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'화면표시순서', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountCode', @level2type = N'COLUMN', @level2name = N'DisplaySeq';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'사용여부, 1 = use, 0 = not use', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountCode', @level2type = N'COLUMN', @level2name = N'UseFlag';

