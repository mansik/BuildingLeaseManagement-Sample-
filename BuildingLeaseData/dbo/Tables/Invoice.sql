CREATE TABLE [dbo].[Invoice] (
    [Id]                      INT           IDENTITY (1, 1) NOT NULL,
    [InvoiceDate]             DATETIME      NOT NULL,
    [BuildingRoomCodeId]      INT           NOT NULL,
    [LesseeId]                INT           NOT NULL,
    [BillIssueDay]            NVARCHAR (20) NULL,
    [MonthlyRent]             MONEY         CONSTRAINT [DF_Invoice_MonthlyRent] DEFAULT ((0)) NOT NULL,
    [MonthlyRentVAT]          MONEY         CONSTRAINT [DF_Invoice_MonthlyRentVAT] DEFAULT ((0)) NOT NULL,
    [MaintenanceFee]          MONEY         CONSTRAINT [DF_Invoice_MaintenanceFee] DEFAULT ((0)) NOT NULL,
    [MaintenanceFeeVAT]       MONEY         CONSTRAINT [DF_Invoice_MaintenanceFeeVAT] DEFAULT ((0)) NOT NULL,
    [ElectricBill]            MONEY         CONSTRAINT [DF_Invoice_ElectricBill] DEFAULT ((0)) NOT NULL,
    [ElectricBillVAT]         MONEY         CONSTRAINT [DF_Invoice_ElectricBillVAT] DEFAULT ((0)) NOT NULL,
    [WaterBill]               MONEY         CONSTRAINT [DF_Invoice_WaterBill] DEFAULT ((0)) NOT NULL,
    [RoadOccupancyFee]        MONEY         CONSTRAINT [DF_Invoice_RoadOccupancyFee] DEFAULT ((0)) NOT NULL,
    [RoadOccupancyFeeVAT]     MONEY         CONSTRAINT [DF_Invoice_RoadOccupancyFeeVAT] DEFAULT ((0)) NOT NULL,
    [TrafficCausingCharge]    MONEY         CONSTRAINT [DF_Invoice_TrafficCausingCharge] DEFAULT ((0)) NOT NULL,
    [TrafficCausingChargeVAT] MONEY         CONSTRAINT [DF_Invoice_TrafficCausingChargeVAT] DEFAULT ((0)) NOT NULL,
    [LineTotal]               AS            (((((([MonthlyRent]+[MonthlyRentVAT])+([MaintenanceFee]+[MaintenanceFeeVAT]))+([ElectricBill]+[ElectricBillVAT]))+([RoadOccupancyFee]+[RoadOccupancyFeeVAT]))+([TrafficCausingCharge]+[TrafficCausingChargeVAT]))+[WaterBill]),
    [InsertUserId]            INT           NULL,
    [InsertDate]              DATETIME      CONSTRAINT [DF_Invoice_InsertDate] DEFAULT (getutcdate()) NOT NULL,
    [UpdateUserId]            INT           NULL,
    [UpdateDate]              DATETIME      CONSTRAINT [DF_Invoice_UpdateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Invoice_BuildingRoomCode] FOREIGN KEY ([BuildingRoomCodeId]) REFERENCES [dbo].[BuildingRoomCode] ([Id]),
    CONSTRAINT [FK_Invoice_Lessee] FOREIGN KEY ([LesseeId]) REFERENCES [dbo].[Lessee] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'청구서', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'청구서 월분(년월만 사용,일은 01, 2023-02-01)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'InvoiceDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'FK, 호실', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'BuildingRoomCodeId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'FK, 임차인', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'LesseeId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'계산서발급일, Lessee에서 가져와서 저장', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'BillIssueDay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'월임대료', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'MonthlyRent';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'월임대료 부가세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'MonthlyRentVAT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'관리비', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'MaintenanceFee';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'관리비 부가세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'MaintenanceFeeVAT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'전기세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'ElectricBill';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'전기세 부가세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'ElectricBillVAT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'수도세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'WaterBill';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'도로점용료', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'RoadOccupancyFee';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'도로점용료 부가세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'RoadOccupancyFeeVAT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'교통유발부담금', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'TrafficCausingCharge';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'교통유발부담금 부가세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'TrafficCausingChargeVAT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'월임대료+관리비+전기세+수도세+도로점용료+교통유발부담금+각 부가세', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'LineTotal';

