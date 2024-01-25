CREATE TABLE [dbo].[AccountHangCode] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [InOutgoings]     INT          NOT NULL,
    [AccountHangName] [dbo].[Name] NOT NULL,
    [DisplaySeq]      INT          NOT NULL,
    [UseFlag]         [dbo].[Flag] CONSTRAINT [DF_AccountHangCategory_UseFlag] DEFAULT ((1)) NOT NULL,
    [InsertUserId]    INT          NULL,
    [InsertDate]      DATETIME     CONSTRAINT [DF_AccountHangCategory_InsertDate] DEFAULT (getutcdate()) NOT NULL,
    [UpdateUserId]    INT          NULL,
    [UpdateDate]      DATETIME     CONSTRAINT [DF_AccountHangCategory_UpdateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_AccountHangCategory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_AccountHangCode_InOutgoings] CHECK ([InOutgoings]=(1) OR [InOutgoings]=(0))
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'계정과목의 항코드(항/목중 항)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountHangCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'수입/지출, 0 = 수입, 1 = 지출', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountHangCode', @level2type = N'COLUMN', @level2name = N'InOutgoings';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'계정과목의 항명칭', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountHangCode', @level2type = N'COLUMN', @level2name = N'AccountHangName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'화면표시순서', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountHangCode', @level2type = N'COLUMN', @level2name = N'DisplaySeq';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'사용여부, 1 = use, 0 = not use', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountHangCode', @level2type = N'COLUMN', @level2name = N'UseFlag';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountHangCode', @level2type = N'COLUMN', @level2name = N'InsertUserId';

