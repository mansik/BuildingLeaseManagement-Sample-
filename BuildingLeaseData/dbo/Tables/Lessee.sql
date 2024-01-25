CREATE TABLE [dbo].[Lessee] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [Lessee]            [dbo].[Name]   NOT NULL,
    [Owner]             [dbo].[Name]   NULL,
    [RRN]               NVARCHAR (15)  NULL,
    [BRN]               NVARCHAR (12)  NULL,
    [Contact]           NVARCHAR (200) NULL,
    [UnderContractFlag] [dbo].[Flag]   CONSTRAINT [DF_Lessee_UnderContractFlag] DEFAULT ((1)) NOT NULL,
    [BillIssueDay]      NVARCHAR (20)  NULL,
    [Notes]             NVARCHAR (200) NULL,
    [InsertUserId]      INT            NULL,
    [InsertDate]        DATETIME       CONSTRAINT [DF_Lessee_InsertDate] DEFAULT (getutcdate()) NOT NULL,
    [UpdateUserId]      INT            NULL,
    [UpdateDate]        DATETIME       CONSTRAINT [DF_Lessee_UpdateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Lessee] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'임차인(거래처)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Lessee';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'임차인', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Lessee', @level2type = N'COLUMN', @level2name = N'Lessee';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'대표자', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Lessee', @level2type = N'COLUMN', @level2name = N'Owner';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'주민번호', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Lessee', @level2type = N'COLUMN', @level2name = N'RRN';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'사업자등록번호', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Lessee', @level2type = N'COLUMN', @level2name = N'BRN';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'연락처', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Lessee', @level2type = N'COLUMN', @level2name = N'Contact';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1 = 계약중, 0 = 계약종료', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Lessee', @level2type = N'COLUMN', @level2name = N'UnderContractFlag';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'계산서발급일', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Lessee', @level2type = N'COLUMN', @level2name = N'BillIssueDay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'비고', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Lessee', @level2type = N'COLUMN', @level2name = N'Notes';

