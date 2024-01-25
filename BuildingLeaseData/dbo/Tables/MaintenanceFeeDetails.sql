CREATE TABLE [dbo].[MaintenanceFeeDetails] (
    [Id]                        INT      IDENTITY (1, 1) NOT NULL,
    [MaintenanceFeeDetailsDate] DATETIME NOT NULL,
    [BuildingRoomCodeId]        INT      NOT NULL,
    [LesseeId]                  INT      NOT NULL,
    [ReceivableAmount]          MONEY    CONSTRAINT [DF_MaintenanceFeeDetails_ReceivableAmount] DEFAULT ((0)) NOT NULL,
    [MonthlyRent]               MONEY    CONSTRAINT [DF_MaintenanceFeeDetails_MonthlyRent] DEFAULT ((0)) NOT NULL,
    [MonthlyRentVAT]            MONEY    CONSTRAINT [DF_MaintenanceFeeDetails_MonthlyRentVAT] DEFAULT ((0)) NOT NULL,
    [MaintenanceFee]            MONEY    CONSTRAINT [DF_MaintenanceFeeDetails_MaintenanceFee] DEFAULT ((0)) NOT NULL,
    [MaintenanceFeeVAT]         MONEY    CONSTRAINT [DF_MaintenanceFeeDetails_MaintenanceFeeVAT] DEFAULT ((0)) NOT NULL,
    [ElectricBill]              MONEY    CONSTRAINT [DF_MaintenanceFeeDetails_ElectricBill] DEFAULT ((0)) NOT NULL,
    [ElectricBillVAT]           MONEY    CONSTRAINT [DF_MaintenanceFeeDetails_ElectricBillVAT] DEFAULT ((0)) NOT NULL,
    [WaterBill]                 MONEY    CONSTRAINT [DF_MaintenanceFeeDetails_WaterBill] DEFAULT ((0)) NOT NULL,
    [RoadOccupancyFee]          MONEY    CONSTRAINT [DF_MaintenanceFeeDetails_RoadOccupancyFee] DEFAULT ((0)) NOT NULL,
    [RoadOccupancyFeeVAT]       MONEY    CONSTRAINT [DF_MaintenanceFeeDetails_RoadOccupancyFeeVAT] DEFAULT ((0)) NOT NULL,
    [TrafficCausingCharge]      MONEY    CONSTRAINT [DF_MaintenanceFeeDetails_TrafficCausingCharge] DEFAULT ((0)) NOT NULL,
    [TrafficCausingChargeVAT]   MONEY    CONSTRAINT [DF_MaintenanceFeeDetails_TrafficCausingCharge1] DEFAULT ((0)) NOT NULL,
    [LineTotal]                 AS       ((((((([MonthlyRent]+[MonthlyRentVAT])+[MaintenanceFee])+[MaintenanceFeeVAT])+([ElectricBill]+[ElectricBillVAT]))+[WaterBill])+([RoadOccupancyFee]+[RoadOccupancyFeeVAT]))+[TrafficCausingCharge]),
    [InsertUserId]              INT      NULL,
    [InsertDate]                DATETIME CONSTRAINT [DF_MaintenanceFeeDetails_InsertDate] DEFAULT (getutcdate()) NOT NULL,
    [UpdateUserId]              INT      NULL,
    [UpdateDate]                DATETIME CONSTRAINT [DF_MaintenanceFeeDetails_UpdateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_MaintenanceFeeDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MaintenanceFeeDetails_BuildingRoomCode] FOREIGN KEY ([BuildingRoomCodeId]) REFERENCES [dbo].[BuildingRoomCode] ([Id]),
    CONSTRAINT [FK_MaintenanceFeeDetails_Lessee] FOREIGN KEY ([LesseeId]) REFERENCES [dbo].[Lessee] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'관리비 명세서', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetails';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'관리비명세서 월분(년월만 사용,일은 01, 2023-02-01)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetails', @level2type = N'COLUMN', @level2name = N'MaintenanceFeeDetailsDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'FK, 호실', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetails', @level2type = N'COLUMN', @level2name = N'BuildingRoomCodeId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'FK, 임차인', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetails', @level2type = N'COLUMN', @level2name = N'LesseeId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'월임대료', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetails', @level2type = N'COLUMN', @level2name = N'MonthlyRent';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'월임대료 부가세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetails', @level2type = N'COLUMN', @level2name = N'MonthlyRentVAT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'관리비', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetails', @level2type = N'COLUMN', @level2name = N'MaintenanceFee';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'관리비 부가세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetails', @level2type = N'COLUMN', @level2name = N'MaintenanceFeeVAT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'전기세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetails', @level2type = N'COLUMN', @level2name = N'ElectricBill';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'전기세 부가세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetails', @level2type = N'COLUMN', @level2name = N'ElectricBillVAT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'수도세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetails', @level2type = N'COLUMN', @level2name = N'WaterBill';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'도로점용료', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetails', @level2type = N'COLUMN', @level2name = N'RoadOccupancyFee';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'도로점용료 부가세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetails', @level2type = N'COLUMN', @level2name = N'RoadOccupancyFeeVAT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'교통유발부담금', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetails', @level2type = N'COLUMN', @level2name = N'TrafficCausingCharge';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'교통유발부담금 부가세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetails', @level2type = N'COLUMN', @level2name = N'TrafficCausingChargeVAT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'월임대료+관리비+전기세+수도세+도로점용료+교통유발부담금+각 부가세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MaintenanceFeeDetails', @level2type = N'COLUMN', @level2name = N'LineTotal';

