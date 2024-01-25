CREATE TABLE [dbo].[MaintenanceFeeDetailsSetting] (
    [Id]                        INT           IDENTITY (1, 1) NOT NULL,
    [MaintenanceFeeDetailsDate] DATETIME      NOT NULL,
    [BuildingCodeId]            INT           NOT NULL,
    [ElectricBillTerm]          NVARCHAR (30) CONSTRAINT [DF_MaintenanceFeeDetailsSetting_ElectricBill] DEFAULT ((0)) NOT NULL,
    [WaterBillTerm]             NVARCHAR (30) CONSTRAINT [DF_MaintenanceFeeDetailsSetting_WaterBill] DEFAULT ((0)) NOT NULL,
    [RoadOccupancyFeeTerm]      NVARCHAR (30) CONSTRAINT [DF_MaintenanceFeeDetailsSetting_RoadOccupancyFee] DEFAULT ((0)) NOT NULL,
    [TrafficCausingChargeTerm]  NVARCHAR (30) CONSTRAINT [DF_MaintenanceFeeDetailsSetting_TrafficCausingCharge] DEFAULT ((0)) NOT NULL,
    [BankBookCodeId]            INT           NOT NULL,
    [PaymentDueDate]            DATETIME      NULL,
    [BillIssueDate]             DATETIME      NULL,
    [InsertUserId]              INT           NULL,
    [InsertDate]                DATETIME      CONSTRAINT [DF_MaintenanceFeeDetailsSetting_InsertDate] DEFAULT (getutcdate()) NOT NULL,
    [UpdateUserId]              INT           NULL,
    [UpdateDate]                DATETIME      CONSTRAINT [DF_MaintenanceFeeDetailsSetting_UpdateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_MaintenanceFeeDetailsSetting] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MaintenanceFeeDetailsSetting_BankBookCode] FOREIGN KEY ([BankBookCodeId]) REFERENCES [dbo].[BankBookCode] ([Id]),
    CONSTRAINT [FK_MaintenanceFeeDetailsSetting_BuildingCode] FOREIGN KEY ([BuildingCodeId]) REFERENCES [dbo].[BuildingCode] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'관리비명세서셋팅', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetailsSetting';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'관리비명세서 월분(년월만 사용,일은 01, 2023-02-01)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetailsSetting', @level2type = N'COLUMN', @level2name = N'MaintenanceFeeDetailsDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'FK, 건물코드', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetailsSetting', @level2type = N'COLUMN', @level2name = N'BuildingCodeId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'전기세 기간', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetailsSetting', @level2type = N'COLUMN', @level2name = N'ElectricBillTerm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'수도세 기간', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetailsSetting', @level2type = N'COLUMN', @level2name = N'WaterBillTerm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'도로점용료 기간', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetailsSetting', @level2type = N'COLUMN', @level2name = N'RoadOccupancyFeeTerm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'교통유발부담금 기간', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetailsSetting', @level2type = N'COLUMN', @level2name = N'TrafficCausingChargeTerm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'FK, 통장코드', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetailsSetting', @level2type = N'COLUMN', @level2name = N'BankBookCodeId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'납부기한', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetailsSetting', @level2type = N'COLUMN', @level2name = N'PaymentDueDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'발행일', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetailsSetting', @level2type = N'COLUMN', @level2name = N'BillIssueDate';

