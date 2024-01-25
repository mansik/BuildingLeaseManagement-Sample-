CREATE TABLE [dbo].[LeaseContract] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [LesseeId]            INT            NOT NULL,
    [BuildingRoomCodeId]  INT            NULL,
    [ContractStartDate]   DATETIME       NULL,
    [ContractEndDate]     DATETIME       NULL,
    [Deposit]             MONEY          CONSTRAINT [DF_LeaseContract_Deposit] DEFAULT ((0)) NOT NULL,
    [MonthlyRent]         MONEY          CONSTRAINT [DF_LeaseContract_MonthlyRent] DEFAULT ((0)) NOT NULL,
    [MonthlyRentVAT]      MONEY          CONSTRAINT [DF_LeaseContract_MonthlyRentVAT] DEFAULT ((0)) NOT NULL,
    [MonthlyRentTotal]    AS             ([MonthlyRent]+[MonthlyRentVAT]),
    [MaintenanceFee]      MONEY          CONSTRAINT [DF_LeaseContract_MaintenanceFee] DEFAULT ((0)) NOT NULL,
    [MaintenanceFeeVAT]   MONEY          CONSTRAINT [DF_LeaseContract_MaintenanceFeeVAT] DEFAULT ((0)) NOT NULL,
    [MaintenanceFeeTotal] AS             ([MaintenanceFee]+[MaintenanceFeeVAT]),
    [Notes]               NVARCHAR (200) NULL,
    [InsertUserId]        INT            NULL,
    [InsertDate]          DATETIME       CONSTRAINT [DF_LeaseContract_InsertDate] DEFAULT (getutcdate()) NOT NULL,
    [UpdateUserId]        INT            NULL,
    [UpdateDate]          DATETIME       CONSTRAINT [DF_LeaseContract_UpdateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_LeaseContract] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LeaseContract_BuildingCode] FOREIGN KEY ([BuildingRoomCodeId]) REFERENCES [dbo].[BuildingRoomCode] ([Id]),
    CONSTRAINT [FK_LeaseContract_Lessee] FOREIGN KEY ([LesseeId]) REFERENCES [dbo].[Lessee] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'임대차 계약', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LeaseContract';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'FK, 임차인', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LeaseContract', @level2type = N'COLUMN', @level2name = N'LesseeId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'FK, 건물세대코드', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LeaseContract', @level2type = N'COLUMN', @level2name = N'BuildingRoomCodeId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'계약기간', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LeaseContract', @level2type = N'COLUMN', @level2name = N'ContractStartDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'계약기간', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LeaseContract', @level2type = N'COLUMN', @level2name = N'ContractEndDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'보증금', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LeaseContract', @level2type = N'COLUMN', @level2name = N'Deposit';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'월임대료', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LeaseContract', @level2type = N'COLUMN', @level2name = N'MonthlyRent';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'월임대료 부가세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LeaseContract', @level2type = N'COLUMN', @level2name = N'MonthlyRentVAT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'월임대료 합계', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LeaseContract', @level2type = N'COLUMN', @level2name = N'MonthlyRentTotal';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'관리비', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LeaseContract', @level2type = N'COLUMN', @level2name = N'MaintenanceFee';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'관리비 부가세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LeaseContract', @level2type = N'COLUMN', @level2name = N'MaintenanceFeeVAT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'관리비 합계', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LeaseContract', @level2type = N'COLUMN', @level2name = N'MaintenanceFeeTotal';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'비고', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LeaseContract', @level2type = N'COLUMN', @level2name = N'Notes';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LeaseContract', @level2type = N'COLUMN', @level2name = N'InsertUserId';

