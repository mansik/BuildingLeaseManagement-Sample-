CREATE TABLE [dbo].[BuildingRoomCode] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [BuildingCodeId] INT             NOT NULL,
    [Room]           NVARCHAR (10)   NULL,
    [Floor]          NVARCHAR (10)   NULL,
    [Area]           DECIMAL (18, 2) NULL,
    [Notes]          NVARCHAR (200)  NULL,
    [DisplaySeq]     INT             CONSTRAINT [DF_BuildingRoomCode_DisplaySeq] DEFAULT ((1)) NOT NULL,
    [UseFlag]        [dbo].[Flag]    CONSTRAINT [DF_BuildingRoomCode_UseFlag] DEFAULT ((1)) NOT NULL,
    [InsertUserId]   INT             NULL,
    [InsertDate]     DATETIME        CONSTRAINT [DF_BuildingRoomCode_InsertDate] DEFAULT (getutcdate()) NOT NULL,
    [UpdateUserId]   INT             NULL,
    [UpdateDate]     DATETIME        CONSTRAINT [DF_BuildingRoomCode_UpdateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_BuildingRoomCode] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BuildingRoomCode_BuildingCode] FOREIGN KEY ([BuildingCodeId]) REFERENCES [dbo].[BuildingCode] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'건물호실코드', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BuildingRoomCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'FK, 건물코드', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BuildingRoomCode', @level2type = N'COLUMN', @level2name = N'BuildingCodeId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'호실', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BuildingRoomCode', @level2type = N'COLUMN', @level2name = N'Room';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'층', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BuildingRoomCode', @level2type = N'COLUMN', @level2name = N'Floor';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'면적', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BuildingRoomCode', @level2type = N'COLUMN', @level2name = N'Area';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'비고', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BuildingRoomCode', @level2type = N'COLUMN', @level2name = N'Notes';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'화면표시순서', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BuildingRoomCode', @level2type = N'COLUMN', @level2name = N'DisplaySeq';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'사용여부, 1 = use, 0 = not use', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BuildingRoomCode', @level2type = N'COLUMN', @level2name = N'UseFlag';

