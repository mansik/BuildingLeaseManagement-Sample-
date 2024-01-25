CREATE TABLE [dbo].[GradeType] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [GradeTypeName] [dbo].[Name] NOT NULL,
    [DisplaySeq]    INT          CONSTRAINT [DF_GradeType_DisplaySeq] DEFAULT ((1)) NOT NULL,
    [UseFlag]       [dbo].[Flag] CONSTRAINT [DF_GradeType_UseFlag] DEFAULT ((1)) NOT NULL,
    [InsertUserId]  INT          NULL,
    [InsertDate]    DATETIME     CONSTRAINT [DF_GradeType_InsertDate] DEFAULT (getutcdate()) NOT NULL,
    [UpdateUserId]  INT          NULL,
    [UpdateDate]    DATETIME     CONSTRAINT [DF_GradeType_UpdateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_GradeType] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'사용자 등급', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GradeType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'등급유형명칭', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GradeType', @level2type = N'COLUMN', @level2name = N'GradeTypeName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'화면표시순서', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GradeType', @level2type = N'COLUMN', @level2name = N'DisplaySeq';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'사용여부, 1 = use, 0 = not use', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GradeType', @level2type = N'COLUMN', @level2name = N'UseFlag';

