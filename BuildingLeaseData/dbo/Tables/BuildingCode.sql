CREATE TABLE [dbo].[BuildingCode] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [BuildingName] [dbo].[Name]   NOT NULL,
    [Notes]        NVARCHAR (200) NULL,
    [DisplaySeq]   INT            CONSTRAINT [DF_BuildingCode_DisplaySeq] DEFAULT ((1)) NOT NULL,
    [UseFlag]      [dbo].[Flag]   CONSTRAINT [DF_BuildingCode_UseFlag] DEFAULT ((1)) NOT NULL,
    [InsertUserId] INT            NULL,
    [InsertDate]   DATETIME       CONSTRAINT [DF_BuildingCode_InsertDate] DEFAULT (getutcdate()) NOT NULL,
    [UpdateUserId] INT            NULL,
    [UpdateDate]   DATETIME       CONSTRAINT [DF_BuildingCode_UpdateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_BuildingCode] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'건물코드', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BuildingCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'건물명', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BuildingCode', @level2type = N'COLUMN', @level2name = N'BuildingName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'비고', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BuildingCode', @level2type = N'COLUMN', @level2name = N'Notes';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'화면표시순서', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BuildingCode', @level2type = N'COLUMN', @level2name = N'DisplaySeq';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'사용여부, 1 = use, 0 = not use', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BuildingCode', @level2type = N'COLUMN', @level2name = N'UseFlag';

