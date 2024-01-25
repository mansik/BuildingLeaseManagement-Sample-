CREATE TABLE [dbo].[Config] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [OfficeTel]         NVARCHAR (20) NULL,
    [OfficeEmail]       NVARCHAR (50) NULL,
    [LastExpenseNumber] INT           NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Config', @level2type = N'COLUMN', @level2name = N'OfficeTel';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Config', @level2type = N'COLUMN', @level2name = N'OfficeEmail';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'금전출납부 - 마지막 지출번호, 자동증가용', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Config', @level2type = N'COLUMN', @level2name = N'LastExpenseNumber';

