USE [master]
GO
/****** Object:  Database [BuildingLease]    Script Date: 2023-12-21 오후 6:19:48 ******/
CREATE DATABASE [BuildingLease]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BuildingLease', FILENAME = N'D:\DATA\BuildingLease.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BuildingLease_log', FILENAME = N'D:\DATA\BuildingLease_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BuildingLease] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BuildingLease].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BuildingLease] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BuildingLease] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BuildingLease] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BuildingLease] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BuildingLease] SET ARITHABORT OFF 
GO
ALTER DATABASE [BuildingLease] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BuildingLease] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BuildingLease] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BuildingLease] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BuildingLease] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BuildingLease] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BuildingLease] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BuildingLease] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BuildingLease] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BuildingLease] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BuildingLease] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BuildingLease] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BuildingLease] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BuildingLease] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BuildingLease] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BuildingLease] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BuildingLease] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BuildingLease] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BuildingLease] SET  MULTI_USER 
GO
ALTER DATABASE [BuildingLease] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BuildingLease] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BuildingLease] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BuildingLease] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BuildingLease] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BuildingLease] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BuildingLease] SET QUERY_STORE = ON
GO
ALTER DATABASE [BuildingLease] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BuildingLease]
GO
/****** Object:  UserDefinedDataType [dbo].[Flag]    Script Date: 2023-12-21 오후 6:19:48 ******/
CREATE TYPE [dbo].[Flag] FROM [bit] NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[Name]    Script Date: 2023-12-21 오후 6:19:48 ******/
CREATE TYPE [dbo].[Name] FROM [nvarchar](50) NULL
GO
/****** Object:  UserDefinedDataType [dbo].[Phone]    Script Date: 2023-12-21 오후 6:19:48 ******/
CREATE TYPE [dbo].[Phone] FROM [nvarchar](15) NULL
GO
/****** Object:  Table [dbo].[AccountCode]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountHangCodeId] [int] NOT NULL,
	[AccountName] [dbo].[Name] NOT NULL,
	[DisplaySeq] [int] NOT NULL,
	[UseFlag] [dbo].[Flag] NOT NULL,
	[InsertUserId] [int] NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateUserId] [int] NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AccountCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountHangCode]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountHangCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InOutgoings] [int] NOT NULL,
	[AccountHangName] [dbo].[Name] NOT NULL,
	[DisplaySeq] [int] NOT NULL,
	[UseFlag] [dbo].[Flag] NOT NULL,
	[InsertUserId] [int] NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateUserId] [int] NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AccountHangCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BankBookCode]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankBookCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BankBookName] [nvarchar](20) NOT NULL,
	[BankName] [dbo].[Name] NULL,
	[AccountNumber] [nvarchar](20) NULL,
	[Notes] [nvarchar](200) NULL,
	[DisplaySeq] [int] NOT NULL,
	[UseFlag] [dbo].[Flag] NOT NULL,
	[InsertUserId] [int] NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateUserId] [int] NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_BankBookCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudgetAmount]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetAmount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FiscalYear] [int] NOT NULL,
	[AccountCodeId] [int] NULL,
	[BudgetAmount] [money] NOT NULL,
	[InsertUserId] [int] NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateUserId] [int] NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_BudgetAmount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuildingCode]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuildingCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuildingName] [dbo].[Name] NOT NULL,
	[Notes] [nvarchar](200) NULL,
	[DisplaySeq] [int] NOT NULL,
	[UseFlag] [dbo].[Flag] NOT NULL,
	[InsertUserId] [int] NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateUserId] [int] NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_BuildingCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuildingRoomCode]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuildingRoomCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuildingCodeId] [int] NOT NULL,
	[Room] [nvarchar](10) NULL,
	[Floor] [nvarchar](10) NULL,
	[Area] [decimal](18, 2) NULL,
	[Notes] [nvarchar](200) NULL,
	[DisplaySeq] [int] NOT NULL,
	[UseFlag] [dbo].[Flag] NOT NULL,
	[InsertUserId] [int] NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateUserId] [int] NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_BuildingRoomCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CashBook]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[TransactionDetails] [nvarchar](100) NOT NULL,
	[BankBookCodeId] [int] NULL,
	[LesseeId] [int] NULL,
	[AccountCodeId] [int] NULL,
	[Creditor] [nvarchar](50) NULL,
	[ExpenseNumber] [int] NULL,
	[DepositAmount] [money] NOT NULL,
	[WithdrawalAmount] [money] NOT NULL,
	[LossAmount] [money] NOT NULL,
	[Notes] [nvarchar](50) NULL,
	[InOutgoings] [int] NOT NULL,
	[DelFlag] [dbo].[Flag] NOT NULL,
	[InsertUserId] [int] NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateUserId] [int] NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CashBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Config]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Config](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OfficeTel] [nvarchar](20) NULL,
	[OfficeEmail] [nvarchar](50) NULL,
	[LastExpenseNumber] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradeType]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradeType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GradeTypeName] [dbo].[Name] NOT NULL,
	[DisplaySeq] [int] NOT NULL,
	[UseFlag] [dbo].[Flag] NOT NULL,
	[InsertUserId] [int] NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateUserId] [int] NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GradeType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[BuildingRoomCodeId] [int] NOT NULL,
	[LesseeId] [int] NOT NULL,
	[BillIssueDay] [nvarchar](20) NULL,
	[MonthlyRent] [money] NOT NULL,
	[MonthlyRentVAT] [money] NOT NULL,
	[MaintenanceFee] [money] NOT NULL,
	[MaintenanceFeeVAT] [money] NOT NULL,
	[ElectricBill] [money] NOT NULL,
	[ElectricBillVAT] [money] NOT NULL,
	[WaterBill] [money] NOT NULL,
	[RoadOccupancyFee] [money] NOT NULL,
	[RoadOccupancyFeeVAT] [money] NOT NULL,
	[TrafficCausingCharge] [money] NOT NULL,
	[TrafficCausingChargeVAT] [money] NOT NULL,
	[LineTotal]  AS (((((([MonthlyRent]+[MonthlyRentVAT])+([MaintenanceFee]+[MaintenanceFeeVAT]))+([ElectricBill]+[ElectricBillVAT]))+([RoadOccupancyFee]+[RoadOccupancyFeeVAT]))+([TrafficCausingCharge]+[TrafficCausingChargeVAT]))+[WaterBill]),
	[InsertUserId] [int] NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateUserId] [int] NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaseContract]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaseContract](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LesseeId] [int] NOT NULL,
	[BuildingRoomCodeId] [int] NULL,
	[ContractStartDate] [datetime] NULL,
	[ContractEndDate] [datetime] NULL,
	[Deposit] [money] NOT NULL,
	[MonthlyRent] [money] NOT NULL,
	[MonthlyRentVAT] [money] NOT NULL,
	[MonthlyRentTotal]  AS ([MonthlyRent]+[MonthlyRentVAT]),
	[MaintenanceFee] [money] NOT NULL,
	[MaintenanceFeeVAT] [money] NOT NULL,
	[MaintenanceFeeTotal]  AS ([MaintenanceFee]+[MaintenanceFeeVAT]),
	[Notes] [nvarchar](200) NULL,
	[InsertUserId] [int] NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateUserId] [int] NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_LeaseContract] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lessee]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Lessee] [dbo].[Name] NOT NULL,
	[Owner] [dbo].[Name] NULL,
	[RRN] [nvarchar](15) NULL,
	[BRN] [nvarchar](12) NULL,
	[Contact] [nvarchar](200) NULL,
	[UnderContractFlag] [dbo].[Flag] NOT NULL,
	[BillIssueDay] [nvarchar](20) NULL,
	[Notes] [nvarchar](200) NULL,
	[InsertUserId] [int] NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateUserId] [int] NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Lessee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaintenanceFeeDetails]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaintenanceFeeDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaintenanceFeeDetailsDate] [datetime] NOT NULL,
	[BuildingRoomCodeId] [int] NOT NULL,
	[LesseeId] [int] NOT NULL,
	[ReceivableAmount] [money] NOT NULL,
	[MonthlyRent] [money] NOT NULL,
	[MonthlyRentVAT] [money] NOT NULL,
	[MaintenanceFee] [money] NOT NULL,
	[MaintenanceFeeVAT] [money] NOT NULL,
	[ElectricBill] [money] NOT NULL,
	[ElectricBillVAT] [money] NOT NULL,
	[WaterBill] [money] NOT NULL,
	[RoadOccupancyFee] [money] NOT NULL,
	[RoadOccupancyFeeVAT] [money] NOT NULL,
	[TrafficCausingCharge] [money] NOT NULL,
	[TrafficCausingChargeVAT] [money] NOT NULL,
	[LineTotal]  AS ((((((([MonthlyRent]+[MonthlyRentVAT])+[MaintenanceFee])+[MaintenanceFeeVAT])+([ElectricBill]+[ElectricBillVAT]))+[WaterBill])+([RoadOccupancyFee]+[RoadOccupancyFeeVAT]))+[TrafficCausingCharge]),
	[InsertUserId] [int] NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateUserId] [int] NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_MaintenanceFeeDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaintenanceFeeDetailsSetting]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaintenanceFeeDetailsSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaintenanceFeeDetailsDate] [datetime] NOT NULL,
	[BuildingCodeId] [int] NOT NULL,
	[ElectricBillTerm] [nvarchar](30) NOT NULL,
	[WaterBillTerm] [nvarchar](30) NOT NULL,
	[RoadOccupancyFeeTerm] [nvarchar](30) NOT NULL,
	[TrafficCausingChargeTerm] [nvarchar](30) NOT NULL,
	[BankBookCodeId] [int] NOT NULL,
	[PaymentDueDate] [datetime] NULL,
	[BillIssueDate] [datetime] NULL,
	[InsertUserId] [int] NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateUserId] [int] NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_MaintenanceFeeDetailsSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](100) NULL,
	[GradeTypeId] [int] NOT NULL,
	[UseFlag] [dbo].[Flag] NOT NULL,
	[InsertUserId] [int] NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateUserId] [int] NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccountCode] ADD  CONSTRAINT [DF_AccountCode_DisplaySeq]  DEFAULT ((1)) FOR [DisplaySeq]
GO
ALTER TABLE [dbo].[AccountCode] ADD  CONSTRAINT [DF_AccountCode_UseFlag]  DEFAULT ((1)) FOR [UseFlag]
GO
ALTER TABLE [dbo].[AccountCode] ADD  CONSTRAINT [DF_AccountCode_InsertDate]  DEFAULT (getutcdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[AccountCode] ADD  CONSTRAINT [DF_AccountCode_UpdateDate]  DEFAULT (getutcdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[AccountHangCode] ADD  CONSTRAINT [DF_AccountHangCategory_UseFlag]  DEFAULT ((1)) FOR [UseFlag]
GO
ALTER TABLE [dbo].[AccountHangCode] ADD  CONSTRAINT [DF_AccountHangCategory_InsertDate]  DEFAULT (getutcdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[AccountHangCode] ADD  CONSTRAINT [DF_AccountHangCategory_UpdateDate]  DEFAULT (getutcdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[BankBookCode] ADD  CONSTRAINT [DF_BankBookCode_DisplaySeq]  DEFAULT ((1)) FOR [DisplaySeq]
GO
ALTER TABLE [dbo].[BankBookCode] ADD  CONSTRAINT [DF_BankBookCode_UseFlag]  DEFAULT ((1)) FOR [UseFlag]
GO
ALTER TABLE [dbo].[BankBookCode] ADD  CONSTRAINT [DF_BankBookCode_InsertDate]  DEFAULT (getutcdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[BankBookCode] ADD  CONSTRAINT [DF_BankBookCode_UpdateDate]  DEFAULT (getutcdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[BudgetAmount] ADD  CONSTRAINT [DF_BudgetAmount_BudgetAmount]  DEFAULT ((0)) FOR [BudgetAmount]
GO
ALTER TABLE [dbo].[BudgetAmount] ADD  CONSTRAINT [DF_BudgetAmount_InsertDate]  DEFAULT (getutcdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[BudgetAmount] ADD  CONSTRAINT [DF_BudgetAmount_UpdateDate]  DEFAULT (getutcdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[BuildingCode] ADD  CONSTRAINT [DF_BuildingCode_DisplaySeq]  DEFAULT ((1)) FOR [DisplaySeq]
GO
ALTER TABLE [dbo].[BuildingCode] ADD  CONSTRAINT [DF_BuildingCode_UseFlag]  DEFAULT ((1)) FOR [UseFlag]
GO
ALTER TABLE [dbo].[BuildingCode] ADD  CONSTRAINT [DF_BuildingCode_InsertDate]  DEFAULT (getutcdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[BuildingCode] ADD  CONSTRAINT [DF_BuildingCode_UpdateDate]  DEFAULT (getutcdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[BuildingRoomCode] ADD  CONSTRAINT [DF_BuildingRoomCode_DisplaySeq]  DEFAULT ((1)) FOR [DisplaySeq]
GO
ALTER TABLE [dbo].[BuildingRoomCode] ADD  CONSTRAINT [DF_BuildingRoomCode_UseFlag]  DEFAULT ((1)) FOR [UseFlag]
GO
ALTER TABLE [dbo].[BuildingRoomCode] ADD  CONSTRAINT [DF_BuildingRoomCode_InsertDate]  DEFAULT (getutcdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[BuildingRoomCode] ADD  CONSTRAINT [DF_BuildingRoomCode_UpdateDate]  DEFAULT (getutcdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[CashBook] ADD  CONSTRAINT [DF_CashBook_DepositAmount]  DEFAULT ((0)) FOR [DepositAmount]
GO
ALTER TABLE [dbo].[CashBook] ADD  CONSTRAINT [DF_CashBook_WithdrawalAmount]  DEFAULT ((0)) FOR [WithdrawalAmount]
GO
ALTER TABLE [dbo].[CashBook] ADD  CONSTRAINT [DF_CashBook_LossAmount]  DEFAULT ((0)) FOR [LossAmount]
GO
ALTER TABLE [dbo].[CashBook] ADD  CONSTRAINT [DF_CashBook_UseFlag]  DEFAULT ((0)) FOR [DelFlag]
GO
ALTER TABLE [dbo].[CashBook] ADD  CONSTRAINT [DF_CashBook_InsertDate]  DEFAULT (getutcdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[CashBook] ADD  CONSTRAINT [DF_CashBook_UpdateDate]  DEFAULT (getutcdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[GradeType] ADD  CONSTRAINT [DF_GradeType_DisplaySeq]  DEFAULT ((1)) FOR [DisplaySeq]
GO
ALTER TABLE [dbo].[GradeType] ADD  CONSTRAINT [DF_GradeType_UseFlag]  DEFAULT ((1)) FOR [UseFlag]
GO
ALTER TABLE [dbo].[GradeType] ADD  CONSTRAINT [DF_GradeType_InsertDate]  DEFAULT (getutcdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[GradeType] ADD  CONSTRAINT [DF_GradeType_UpdateDate]  DEFAULT (getutcdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_MonthlyRent]  DEFAULT ((0)) FOR [MonthlyRent]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_MonthlyRentVAT]  DEFAULT ((0)) FOR [MonthlyRentVAT]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_MaintenanceFee]  DEFAULT ((0)) FOR [MaintenanceFee]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_MaintenanceFeeVAT]  DEFAULT ((0)) FOR [MaintenanceFeeVAT]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_ElectricBill]  DEFAULT ((0)) FOR [ElectricBill]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_ElectricBillVAT]  DEFAULT ((0)) FOR [ElectricBillVAT]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_WaterBill]  DEFAULT ((0)) FOR [WaterBill]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_RoadOccupancyFee]  DEFAULT ((0)) FOR [RoadOccupancyFee]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_RoadOccupancyFeeVAT]  DEFAULT ((0)) FOR [RoadOccupancyFeeVAT]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_TrafficCausingCharge]  DEFAULT ((0)) FOR [TrafficCausingCharge]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_TrafficCausingChargeVAT]  DEFAULT ((0)) FOR [TrafficCausingChargeVAT]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_InsertDate]  DEFAULT (getutcdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_UpdateDate]  DEFAULT (getutcdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[LeaseContract] ADD  CONSTRAINT [DF_LeaseContract_Deposit]  DEFAULT ((0)) FOR [Deposit]
GO
ALTER TABLE [dbo].[LeaseContract] ADD  CONSTRAINT [DF_LeaseContract_MonthlyRent]  DEFAULT ((0)) FOR [MonthlyRent]
GO
ALTER TABLE [dbo].[LeaseContract] ADD  CONSTRAINT [DF_LeaseContract_MonthlyRentVAT]  DEFAULT ((0)) FOR [MonthlyRentVAT]
GO
ALTER TABLE [dbo].[LeaseContract] ADD  CONSTRAINT [DF_LeaseContract_MaintenanceFee]  DEFAULT ((0)) FOR [MaintenanceFee]
GO
ALTER TABLE [dbo].[LeaseContract] ADD  CONSTRAINT [DF_LeaseContract_MaintenanceFeeVAT]  DEFAULT ((0)) FOR [MaintenanceFeeVAT]
GO
ALTER TABLE [dbo].[LeaseContract] ADD  CONSTRAINT [DF_LeaseContract_InsertDate]  DEFAULT (getutcdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[LeaseContract] ADD  CONSTRAINT [DF_LeaseContract_UpdateDate]  DEFAULT (getutcdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Lessee] ADD  CONSTRAINT [DF_Lessee_UnderContractFlag]  DEFAULT ((1)) FOR [UnderContractFlag]
GO
ALTER TABLE [dbo].[Lessee] ADD  CONSTRAINT [DF_Lessee_InsertDate]  DEFAULT (getutcdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[Lessee] ADD  CONSTRAINT [DF_Lessee_UpdateDate]  DEFAULT (getutcdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails] ADD  CONSTRAINT [DF_MaintenanceFeeDetails_ReceivableAmount]  DEFAULT ((0)) FOR [ReceivableAmount]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails] ADD  CONSTRAINT [DF_MaintenanceFeeDetails_MonthlyRent]  DEFAULT ((0)) FOR [MonthlyRent]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails] ADD  CONSTRAINT [DF_MaintenanceFeeDetails_MonthlyRentVAT]  DEFAULT ((0)) FOR [MonthlyRentVAT]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails] ADD  CONSTRAINT [DF_MaintenanceFeeDetails_MaintenanceFee]  DEFAULT ((0)) FOR [MaintenanceFee]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails] ADD  CONSTRAINT [DF_MaintenanceFeeDetails_MaintenanceFeeVAT]  DEFAULT ((0)) FOR [MaintenanceFeeVAT]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails] ADD  CONSTRAINT [DF_MaintenanceFeeDetails_ElectricBill]  DEFAULT ((0)) FOR [ElectricBill]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails] ADD  CONSTRAINT [DF_MaintenanceFeeDetails_ElectricBillVAT]  DEFAULT ((0)) FOR [ElectricBillVAT]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails] ADD  CONSTRAINT [DF_MaintenanceFeeDetails_WaterBill]  DEFAULT ((0)) FOR [WaterBill]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails] ADD  CONSTRAINT [DF_MaintenanceFeeDetails_RoadOccupancyFee]  DEFAULT ((0)) FOR [RoadOccupancyFee]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails] ADD  CONSTRAINT [DF_MaintenanceFeeDetails_RoadOccupancyFeeVAT]  DEFAULT ((0)) FOR [RoadOccupancyFeeVAT]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails] ADD  CONSTRAINT [DF_MaintenanceFeeDetails_TrafficCausingCharge]  DEFAULT ((0)) FOR [TrafficCausingCharge]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails] ADD  CONSTRAINT [DF_MaintenanceFeeDetails_TrafficCausingCharge1]  DEFAULT ((0)) FOR [TrafficCausingChargeVAT]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails] ADD  CONSTRAINT [DF_MaintenanceFeeDetails_InsertDate]  DEFAULT (getutcdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails] ADD  CONSTRAINT [DF_MaintenanceFeeDetails_UpdateDate]  DEFAULT (getutcdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetailsSetting] ADD  CONSTRAINT [DF_MaintenanceFeeDetailsSetting_ElectricBill]  DEFAULT ((0)) FOR [ElectricBillTerm]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetailsSetting] ADD  CONSTRAINT [DF_MaintenanceFeeDetailsSetting_WaterBill]  DEFAULT ((0)) FOR [WaterBillTerm]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetailsSetting] ADD  CONSTRAINT [DF_MaintenanceFeeDetailsSetting_RoadOccupancyFee]  DEFAULT ((0)) FOR [RoadOccupancyFeeTerm]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetailsSetting] ADD  CONSTRAINT [DF_MaintenanceFeeDetailsSetting_TrafficCausingCharge]  DEFAULT ((0)) FOR [TrafficCausingChargeTerm]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetailsSetting] ADD  CONSTRAINT [DF_MaintenanceFeeDetailsSetting_InsertDate]  DEFAULT (getutcdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetailsSetting] ADD  CONSTRAINT [DF_MaintenanceFeeDetailsSetting_UpdateDate]  DEFAULT (getutcdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Grade]  DEFAULT ((1)) FOR [GradeTypeId]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_Users_UseFlag]  DEFAULT ((1)) FOR [UseFlag]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_InsertDate]  DEFAULT (getutcdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_UpdateDate]  DEFAULT (getutcdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[AccountCode]  WITH NOCHECK ADD  CONSTRAINT [FK_AccountCode_AccountHangCode] FOREIGN KEY([AccountHangCodeId])
REFERENCES [dbo].[AccountHangCode] ([Id])
GO
ALTER TABLE [dbo].[AccountCode] CHECK CONSTRAINT [FK_AccountCode_AccountHangCode]
GO
ALTER TABLE [dbo].[BudgetAmount]  WITH CHECK ADD  CONSTRAINT [FK_BudgetAmount_AccountCode] FOREIGN KEY([AccountCodeId])
REFERENCES [dbo].[AccountCode] ([Id])
GO
ALTER TABLE [dbo].[BudgetAmount] CHECK CONSTRAINT [FK_BudgetAmount_AccountCode]
GO
ALTER TABLE [dbo].[BuildingRoomCode]  WITH CHECK ADD  CONSTRAINT [FK_BuildingRoomCode_BuildingCode] FOREIGN KEY([BuildingCodeId])
REFERENCES [dbo].[BuildingCode] ([Id])
GO
ALTER TABLE [dbo].[BuildingRoomCode] CHECK CONSTRAINT [FK_BuildingRoomCode_BuildingCode]
GO
ALTER TABLE [dbo].[CashBook]  WITH CHECK ADD  CONSTRAINT [FK_CashBook_AccountCode] FOREIGN KEY([AccountCodeId])
REFERENCES [dbo].[AccountCode] ([Id])
GO
ALTER TABLE [dbo].[CashBook] CHECK CONSTRAINT [FK_CashBook_AccountCode]
GO
ALTER TABLE [dbo].[CashBook]  WITH CHECK ADD  CONSTRAINT [FK_CashBook_BankBookCode] FOREIGN KEY([BankBookCodeId])
REFERENCES [dbo].[BankBookCode] ([Id])
GO
ALTER TABLE [dbo].[CashBook] CHECK CONSTRAINT [FK_CashBook_BankBookCode]
GO
ALTER TABLE [dbo].[CashBook]  WITH CHECK ADD  CONSTRAINT [FK_CashBook_Lessee] FOREIGN KEY([LesseeId])
REFERENCES [dbo].[Lessee] ([Id])
GO
ALTER TABLE [dbo].[CashBook] CHECK CONSTRAINT [FK_CashBook_Lessee]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_BuildingRoomCode] FOREIGN KEY([BuildingRoomCodeId])
REFERENCES [dbo].[BuildingRoomCode] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_BuildingRoomCode]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Lessee] FOREIGN KEY([LesseeId])
REFERENCES [dbo].[Lessee] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Lessee]
GO
ALTER TABLE [dbo].[LeaseContract]  WITH CHECK ADD  CONSTRAINT [FK_LeaseContract_BuildingCode] FOREIGN KEY([BuildingRoomCodeId])
REFERENCES [dbo].[BuildingRoomCode] ([Id])
GO
ALTER TABLE [dbo].[LeaseContract] CHECK CONSTRAINT [FK_LeaseContract_BuildingCode]
GO
ALTER TABLE [dbo].[LeaseContract]  WITH CHECK ADD  CONSTRAINT [FK_LeaseContract_Lessee] FOREIGN KEY([LesseeId])
REFERENCES [dbo].[Lessee] ([Id])
GO
ALTER TABLE [dbo].[LeaseContract] CHECK CONSTRAINT [FK_LeaseContract_Lessee]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails]  WITH CHECK ADD  CONSTRAINT [FK_MaintenanceFeeDetails_BuildingRoomCode] FOREIGN KEY([BuildingRoomCodeId])
REFERENCES [dbo].[BuildingRoomCode] ([Id])
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails] CHECK CONSTRAINT [FK_MaintenanceFeeDetails_BuildingRoomCode]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails]  WITH CHECK ADD  CONSTRAINT [FK_MaintenanceFeeDetails_Lessee] FOREIGN KEY([LesseeId])
REFERENCES [dbo].[Lessee] ([Id])
GO
ALTER TABLE [dbo].[MaintenanceFeeDetails] CHECK CONSTRAINT [FK_MaintenanceFeeDetails_Lessee]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetailsSetting]  WITH CHECK ADD  CONSTRAINT [FK_MaintenanceFeeDetailsSetting_BankBookCode] FOREIGN KEY([BankBookCodeId])
REFERENCES [dbo].[BankBookCode] ([Id])
GO
ALTER TABLE [dbo].[MaintenanceFeeDetailsSetting] CHECK CONSTRAINT [FK_MaintenanceFeeDetailsSetting_BankBookCode]
GO
ALTER TABLE [dbo].[MaintenanceFeeDetailsSetting]  WITH CHECK ADD  CONSTRAINT [FK_MaintenanceFeeDetailsSetting_BuildingCode] FOREIGN KEY([BuildingCodeId])
REFERENCES [dbo].[BuildingCode] ([Id])
GO
ALTER TABLE [dbo].[MaintenanceFeeDetailsSetting] CHECK CONSTRAINT [FK_MaintenanceFeeDetailsSetting_BuildingCode]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_GradeType] FOREIGN KEY([GradeTypeId])
REFERENCES [dbo].[GradeType] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_GradeType]
GO
ALTER TABLE [dbo].[AccountHangCode]  WITH CHECK ADD  CONSTRAINT [CK_AccountHangCode_InOutgoings] CHECK  (([InOutgoings]=(1) OR [InOutgoings]=(0)))
GO
ALTER TABLE [dbo].[AccountHangCode] CHECK CONSTRAINT [CK_AccountHangCode_InOutgoings]
GO
ALTER TABLE [dbo].[CashBook]  WITH CHECK ADD  CONSTRAINT [CK_CashBook_InOutgoings] CHECK  (([InOutgoings]=(2) OR [InOutgoings]=(1) OR [InOutgoings]=(0)))
GO
ALTER TABLE [dbo].[CashBook] CHECK CONSTRAINT [CK_CashBook_InOutgoings]
GO
/****** Object:  StoredProcedure [dbo].[sp_DBBackup]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DBBackup]
　@BackupPath nvarchar(100),  
  @FullFileName nvarchar(200) out
AS
BEGIN
	
	declare @DBName nvarchar(50), @FileName nvarchar(100), @Name nvarchar(50);
	set @DBName = DB_NAME()	
	set @FileName = @DBName + N'_' + format(dateadd(hour, 9, getutcdate()),N'yyyyMMdd_HHmmss') + N'.bak'
	set @FullFileName = iif(right(@BackupPath,1) = N'\', @BackupPath, @BackupPath+ N'\') + @FileName
	set @Name = @DBName + N'전체 테이터베이스 백업'

	BACKUP DATABASE @DBName 
	TO  DISK = @FullFileName 
	WITH 
		NOFORMAT, 
		NOINIT,
		NAME = @Name;	
END
GO
/****** Object:  StoredProcedure [dbo].[spAccountCode_Delete]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAccountCode_Delete]
	@Id int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	delete 
	from dbo.[AccountCode]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spAccountCode_Exists]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAccountCode_Exists]	
	@AccountName dbo.[Name],
	@AccountHangCodeId int	
AS
BEGIN
	SET NOCOUNT ON

	if Exists (
		select 1
		from dbo.[AccountCode]
		where AccountName = @AccountName and AccountHangCodeId = @AccountHangCodeId)		

		select Exist =1;
	else
		select Exist = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[spAccountCode_GetAll]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAccountCode_GetAll]
	@AccountHangCodeId int = null
AS
BEGIN
	SET NOCOUNT ON
	
	if (@AccountHangCodeId is null)
		BEGIN
			select *
			from dbo.[AccountCode]
			order by DisplaySeq;
		END
	else
		BEGIN
			select *
			from dbo.[AccountCode]
			where AccountHangCodeId  = @AccountHangCodeId			
			order by DisplaySeq;
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[spAccountCode_GetAllDisplay]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAccountCode_GetAllDisplay]
AS
BEGIN
	SET NOCOUNT ON
	
	select account.Id, hang.AccountHangName, account.AccountName, hang.InOutgoings 
	from dbo.[AccountCode] account
	inner join dbo.[AccountHangCode] hang
		on account.AccountHangCodeId = hang.Id 
	order by hang.InOutgoings, hang.DisplaySeq, account.DisplaySeq;
END
GO
/****** Object:  StoredProcedure [dbo].[spAccountCode_GetById]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAccountCode_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[AccountCode]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spAccountCode_Insert]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAccountCode_Insert]
	@AccountHangCodeId int,
	@AccountName dbo.[Name],
    @DisplaySeq int,
    @UseFlag [dbo].[Flag],
    @InsertUserId int,
	@UpdateUserId int,
    @Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[AccountCode]
                (AccountHangCodeId,
				AccountName,                
                DisplaySeq,
                UseFlag,
                InsertUserId,
				UpdateUserId)
	    values
               (@AccountHangCodeId,
			   @AccountName,
               @DisplaySeq,
               @UseFlag,
               @InsertUserId,
			   @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spAccountCode_IsUsed]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAccountCode_IsUsed]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	if (Exists (
		select 1
		from dbo.[CashBook]
		where AccountCodeId = @Id)
		or Exists (
		select 1
		from dbo.[BudgetAmount]
		where AccountCodeId = @Id))

		select Exist =1;
	else
		select Exist = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[spAccountCode_Update]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAccountCode_Update]
	@Id int,
	@AccountHangCodeId int,
	@AccountName dbo.[Name],
	@DisplaySeq int,	
	@UseFlag dbo.[Flag],	
	@UpdateUserId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[AccountCode]
	set 
	AccountHangCodeId = @AccountHangCodeId,
	AccountName = @AccountName,	
	DisplaySeq = @DisplaySeq,
	UseFlag = @UseFlag,	
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spAccountHangCode_Delete]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAccountHangCode_Delete]
	@Id int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	delete 
	from dbo.[AccountHangCode]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spAccountHangCode_Exists]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAccountHangCode_Exists]
	@AccountHangName dbo.[Name],
	@InOutgoings int
AS
BEGIN
	SET NOCOUNT ON

	if Exists (
		select 1
		from dbo.[AccountHangCode]
		where AccountHangName = @AccountHangName and InOutgoings = @InOutgoings)

		select Exist =1;
	else
		select Exist = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[spAccountHangCode_GetAll]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAccountHangCode_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[AccountHangCode]
	order by DisplaySeq;
END
GO
/****** Object:  StoredProcedure [dbo].[spAccountHangCode_GetById]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAccountHangCode_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[AccountHangCode]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spAccountHangCode_GetsByInOutgoings]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAccountHangCode_GetsByInOutgoings]
	@InOutgoings int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[AccountHangCode]
	where InOutgoings = @InOutgoings
	order by DisplaySeq;
END
GO
/****** Object:  StoredProcedure [dbo].[spAccountHangCode_Insert]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAccountHangCode_Insert]
	@InOutgoings int,
    @AccountHangName dbo.[Name],
    @DisplaySeq int,
    @UseFlag [dbo].[Flag],
    @InsertUserId int,
	@UpdateUserId int,
    @Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[AccountHangCode]
                (InOutgoings,
				AccountHangName,                
                DisplaySeq,
                UseFlag,
                InsertUserId,
				UpdateUserId)
	    values
               (@InOutgoings,
			   @AccountHangName,
               @DisplaySeq,
               @UseFlag,
               @InsertUserId,
			   @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spAccountHangCode_IsUsed]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAccountHangCode_IsUsed]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	if Exists (
		select 1
		from dbo.[AccountCode]
		where AccountHangCodeId = @Id)

		select Exist =1;
	else
		select Exist = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[spAccountHangCode_Update]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAccountHangCode_Update]
	@Id int,
	@InOutgoings  int,
	@AccountHangName dbo.[Name],
	@DisplaySeq int,	
	@UseFlag dbo.[Flag],	
	@UpdateUserId int	 
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[AccountHangCode]
	set 
	InOutgoings = @InOutgoings,
	AccountHangName = @AccountHangName,	
	DisplaySeq = @DisplaySeq,
	UseFlag = @UseFlag,	
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spBankBookCode_Delete]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBankBookCode_Delete]
	@Id int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	delete 
	from dbo.[BankBookCode]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spBankBookCode_Exists]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBankBookCode_Exists]
	@BankBookName nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON

	
	if Exists (
		select 1
		from dbo.[BankBookCode]
		where BankBookName = @BankBookName)

		select Exist = 1;
	else
		select Exist = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[spBankBookCode_GetAll]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBankBookCode_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[BankBookCode]
	order by DisplaySeq;
END
GO
/****** Object:  StoredProcedure [dbo].[spBankBookCode_GetById]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBankBookCode_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[BankBookCode]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spBankBookCode_Insert]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBankBookCode_Insert]
	@BankBookName nvarchar(20),
	@BankName dbo.[Name],
	@AccountNumber nvarchar(20),
	@Notes nvarchar(200),
	@DisplaySeq int,
	@UseFlag dbo.[Flag],
	@InsertUserId int,
	@UpdateUserId int,
	@Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[BankBookCode]
                (BankBookName,
				BankName,
				AccountNumber,
				Notes,
                DisplaySeq,
                UseFlag,
                InsertUserId,
                UpdateUserId)
	    values
               (@BankBookName,
			   @BankName,
			   @AccountNumber,
			   @Notes,
               @DisplaySeq,
               @UseFlag,
               @InsertUserId,
               @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spBankBookCode_IsUsed]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBankBookCode_IsUsed]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	if (Exists (
		select 1
		from dbo.[CashBook]
		where BankBookCodeId = @Id)		
		or Exists (
		select 1
		from dbo.[MaintenanceFeeDetailsSetting]
		where BankBookCodeId = @Id))

		select Exist =1;
	else
		select Exist = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[spBankBookCode_Update]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBankBookCode_Update]	
	@BankBookName nvarchar(20),
	@BankName dbo.[Name],
	@AccountNumber nvarchar(20),
	@Notes nvarchar(200),
	@DisplaySeq int,
	@UseFlag dbo.[Flag],
	@UpdateUserId int,
	@Id int out
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[BankBookCode]
	set 	
	BankBookName = @BankBookName,
	BankName = @BankName,
	AccountNumber = @AccountNumber,
	Notes = @Notes,
	DisplaySeq = @DisplaySeq,
	UseFlag = @UseFlag,	
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spBudgetAmount_GetsDisplayByDate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBudgetAmount_GetsDisplayByDate]
	@FiscalYear int,
	@InOutgoings int
AS
BEGIN
	SET NOCOUNT ON
	
	select budget.Id, 
		hang.AccountHangName, 
		account.Id as AccountCodeId, 
		isnull(budget.BudgetAmount,0) as BudgetAmount
	from dbo.[AccountCode] account
	inner join dbo.[AccountHangCode] hang
	 on account.AccountHangCodeId = hang.Id 
	 and InOutgoings = @InOutgoings
	left join dbo.[BudgetAmount] budget
	 on account.Id = budget.AccountCodeId
	 and FiscalYear = @FiscalYear
	order by hang.DisplaySeq, account.DisplaySeq;
END
GO
/****** Object:  StoredProcedure [dbo].[spBudgetAmount_Insert]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBudgetAmount_Insert]
	@FiscalYear int,
	@AccountCodeId int,
	@BudgetAmount money,
    @InsertUserId int,
	@UpdateUserId int,
    @Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[BudgetAmount]
                (FiscalYear,
				AccountCodeId,
				BudgetAmount,                
                InsertUserId,
				UpdateUserId)
	    values
               (@FiscalYear,
			   @AccountCodeId,
			   @BudgetAmount,
               
               @InsertUserId,
			   @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spBudgetAmount_Update]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBudgetAmount_Update]
	@Id int,
	@FiscalYear int,
	@AccountCodeId int,
	@BudgetAmount money,	
	@UpdateUserId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[BudgetAmount]
	set 
	FiscalYear = @FiscalYear,
	AccountCodeId = @AccountCodeId,
	BudgetAmount = @BudgetAmount,	
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spBuildingCode_Delete]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuildingCode_Delete]
	@Id int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	delete 
	from dbo.[BuildingCode]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spBuildingCode_Exists]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuildingCode_Exists]
	@BuildingName dbo.[Name]
AS
BEGIN
	SET NOCOUNT ON
	
	if Exists (
		select 1
		from dbo.[BuildingCode]
		where BuildingName = @BuildingName)

		select Exist =1;
	else
		select Exist = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[spBuildingCode_GetAll]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuildingCode_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[BuildingCode]
	order by DisplaySeq;
END
GO
/****** Object:  StoredProcedure [dbo].[spBuildingCode_GetById]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuildingCode_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[BuildingCode]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spBuildingCode_Insert]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuildingCode_Insert]
	@BuildingName dbo.[Name],
	@Notes nvarchar(200),
	@DisplaySeq int,
	@UseFlag dbo.[Flag],
	@InsertUserId int,
	@UpdateUserId int,
	@Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[BuildingCode]
                (BuildingName,
				Notes,
				DisplaySeq,
                UseFlag,
                InsertUserId,
                UpdateUserId)
	    values
               (@BuildingName,
			   @Notes,
			   @DisplaySeq,
               @UseFlag,
               @InsertUserId,
               @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spBuildingCode_IsUsed]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuildingCode_IsUsed]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	if (Exists (
		select 1
		from dbo.[BuildingRoomCode]
		where BuildingCodeId = @Id)
		or Exists (
		select 1
		from dbo.[MaintenanceFeeDetailsSetting]
		where BuildingCodeId = @Id))

		select Exist =1;
	else
		select Exist = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[spBuildingCode_Update]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuildingCode_Update]
	@Id int,
	@BuildingName dbo.[Name],
	@Notes nvarchar(200),
	@DisplaySeq int,
	@UseFlag dbo.[Flag],	
	@UpdateUserId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[BuildingCode]
	set 	
	BuildingName = @BuildingName,
	Notes = @Notes,
	DisplaySeq = @DisplaySeq,
	UseFlag = @UseFlag,	
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spBuildingRoomCode_Delete]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuildingRoomCode_Delete]
	@Id int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	delete 
	from dbo.[BuildingRoomCode]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spBuildingRoomCode_Exists]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuildingRoomCode_Exists]
	@Room nvarchar(20),
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	if Exists (
		select 1
		from dbo.[BuildingRoomCode]
		where [Room] = @Room and BuildingCodeId = @BuildingCodeId)

		select Exist = 1;
	else
		select Exist = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[spBuildingRoomCode_GetAll]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuildingRoomCode_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[BuildingRoomCode]
	order by DisplaySeq;
END
GO
/****** Object:  StoredProcedure [dbo].[spBuildingRoomCode_GetById]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuildingRoomCode_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[BuildingRoomCode]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spBuildingRoomCode_GetsByBuildingCodeId]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuildingRoomCode_GetsByBuildingCodeId]
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[BuildingRoomCode]
	where BuildingCodeId = @BuildingCodeId
	order by DisplaySeq;
END
GO
/****** Object:  StoredProcedure [dbo].[spBuildingRoomCode_Insert]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuildingRoomCode_Insert]
	@BuildingCodeId int,
	@Room nvarchar(10),
	@Floor nvarchar(10),	
	@Area decimal(18,2),
	@Notes nvarchar(200),
	@DisplaySeq int,
	@UseFlag dbo.[Flag],
	@InsertUserId int,
	@UpdateUserId int,
	@Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[BuildingRoomCode]
                (BuildingCodeId,
				Room,
				[Floor],
				Area,
				Notes,
				DisplaySeq,
				UseFlag,
                InsertUserId,
                UpdateUserId)
	    values
               (@BuildingCodeId,
			   @Room,
			   @Floor,
			   @Area,
			   @Notes,
			   @DisplaySeq,
			   @UseFlag,
               @InsertUserId,
               @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spBuildingRoomCode_IsUsed]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuildingRoomCode_IsUsed]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	if (Exists (
		select 1
		from dbo.[Invoice]
		where BuildingRoomCodeId = @Id)
		or Exists (
		select 1
		from dbo.[LeaseContract]
		where BuildingRoomCodeId = @Id)
		or Exists (
		select 1
		from dbo.[MaintenanceFeeDetails]
		where BuildingRoomCodeId = @Id))

		select Exist =1;
	else
		select Exist = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[spBuildingRoomCode_Update]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuildingRoomCode_Update]
	@Id int,
	@BuildingCodeId int,
	@Room nvarchar(10),
	@Floor nvarchar(10),	
	@Area decimal(18,2),
	@Notes nvarchar(200),
	@DisplaySeq int,
	@UseFlag dbo.[Flag],
	@UpdateUserId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[BuildingRoomCode]
	set 	
	BuildingCodeId = @BuildingCodeId,
	Room = @Room,
	[Floor] = @Floor,
	Area = @Area,
	Notes = @Notes,
	DisplaySeq = @DisplaySeq,
	UseFlag = @UseFlag,
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spCashBook_Delete]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCashBook_Delete]
	@Id int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[CashBook]
	set DelFlag = 1	
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spCashBook_GetAll]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCashBook_GetAll]
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	select *
	from dbo.[CashBook];
END
GO
/****** Object:  StoredProcedure [dbo].[spCashBook_GetPreviousAmountByDate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCashBook_GetPreviousAmountByDate]
	@BaseDate DateTime
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	/* 이월금 = 입금액 - 출금액 */
	/* 이월금 계산에서 제외: 최초 사용시 임차인별 미납금 및 선납금은 "임대 및 관리료 수입"등 수입항목으로 잡으며, 제외한다. */	
	/* 이월금 계산에 포함: 최초 사용시 통장의 잔액은 "전년도 이월금" 항목(AccountCodeId: 5, 9)으로 잡아서 포함한다 .*/
	select isnull(sum(DepositAmount),0) - isnull(sum(WithdrawalAmount),0) as PreviousAmount
	from dbo.[CashBook] main
	where TransactionDate < @BaseDate
	and DelFlag = 0
	/* 2024-01-01년부터 사용시 2024-01-01이전에 입력된 "전년도 이월금"은 이월금 계산에 포함하며, 수입액은 제외한다. */
	and NOT EXISTS ( select 1 
				from dbo.[CashBook] sub
				where main.Id = sub.Id
				and sub.TransactionDate < '2024-01-01' 
				and sub.AccountCodeId NOT IN (5, 9)) 
   
END
GO
/****** Object:  StoredProcedure [dbo].[spCashBook_GetsDisplayByFromToDate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCashBook_GetsDisplayByFromToDate]
	@FromDate DateTime,
	@ToDate DateTime
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	select cb.*,
		iif(cb.InOutgoings = 2, '', '(' + bank.BankBookName + ') ') + 
		iif(cb.InOutgoings = 1, '', le.Lessee + ' ') + 
		cb.TransactionDetails AS TransactionDetailsDisplay
	from dbo.[CashBook] cb 
	left join dbo.[BankBookCode] bank 
	  on cb.BankBookCodeId = bank.Id
	left join dbo.[Lessee] le
	  on cb.LesseeId = le.Id
	where cb.TransactionDate >= @FromDate and cb.TransactionDate <= @ToDate
	order by cb.TransactionDate, cb.Id;	
END
GO
/****** Object:  StoredProcedure [dbo].[spCashBook_Insert]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCashBook_Insert]    
	@TransactionDate datetime,
	@TransactionDetails nvarchar(100),
	@BankBookCodeId int,
	@LesseeId int,
	@AccountCodeId int,
	@Creditor nvarchar(50),
	@ExpenseNumber int,
	@DepositAmount money,
	@WithdrawalAmount money,
	@LossAmount money,
	@Notes nvarchar(50),
	@InOutgoings int,
	@DelFlag [dbo].[Flag],
    @InsertUserId int,
	@UpdateUserId int,
    @Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[CashBook]
                (TransactionDate,
				TransactionDetails,
				BankBookCodeId,
				LesseeId,
				AccountCodeId,
				Creditor,
				ExpenseNumber,
				DepositAmount,
				WithdrawalAmount,
				LossAmount,
				Notes,
				InOutgoings,
				DelFlag,
                InsertUserId,
				UpdateUserId)
	    values
               (@TransactionDate,
				@TransactionDetails,
				@BankBookCodeId,
				@LesseeId,
				@AccountCodeId,
				@Creditor,
				@ExpenseNumber,
				@DepositAmount,
				@WithdrawalAmount,
				@LossAmount,
				@Notes,
				@InOutgoings,
				@DelFlag,
				@InsertUserId,
				@UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spCashBook_Update]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCashBook_Update]    
    @Id int,
	@TransactionDate datetime,
	@TransactionDetails nvarchar(100),
	@BankBookCodeId int,
	@LesseeId int,
	@AccountCodeId int,
	@Creditor nvarchar(50),
	@ExpenseNumber int,
	@DepositAmount money,
	@WithdrawalAmount money,
	@LossAmount money,
	@Notes nvarchar(50),
	@InOutgoings int,
	@DelFlag [dbo].[Flag],
    @UpdateUserId int
AS
BEGIN    
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[CashBook]
	set 
	TransactionDate = @TransactionDate,
	TransactionDetails = @TransactionDetails,
	BankBookCodeId = @BankBookCodeId,
	LesseeId = @LesseeId,
	AccountCodeId = @AccountCodeId,
	Creditor = @Creditor,
	ExpenseNumber = @ExpenseNumber,
	DepositAmount = @DepositAmount,
	WithdrawalAmount = @WithdrawalAmount,
	LossAmount = @LossAmount,
	Notes = @Notes,
	InOutgoings = @InOutgoings,
	DelFlag = @DelFlag,
	UpdateUserId = @UpdateUserId,	
	UpdateDate = getutcdate()
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spConfig_GetFirst]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spConfig_GetFirst]
AS
BEGIN
    SET NOCOUNT ON

	select top 1 * 
	from dbo.[Config];
END
GO
/****** Object:  StoredProcedure [dbo].[spConfig_GetLastExpenseNumber]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spConfig_GetLastExpenseNumber]
AS
BEGIN
    SET NOCOUNT ON

	select top 1 LastExpenseNumber 
	from dbo.[Config];
END
GO
/****** Object:  StoredProcedure [dbo].[spConfig_InsertUpdate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spConfig_InsertUpdate]
	@OfficeTel nvarchar(20),
	@OfficeEmail nvarchar(50),
	@LastExpenseNumber int
AS
BEGIN
    SET NOCOUNT ON

	if Exists (select 1 
			from dbo.[Config])

		update dbo.[Config]
		set
		OfficeTel = @OfficeTel,
		OfficeEmail = @OfficeEmail,
		LastExpenseNumber = @LastExpenseNumber;
	else
		insert into dbo.[Config]
					(OfficeTel,
					OfficeEmail,
					LastExpenseNumber)
			values
				   (@OfficeTel,
				   @OfficeEmail,
				   @LastExpenseNumber);
END
GO
/****** Object:  StoredProcedure [dbo].[spConfig_LastExpenseNumber_InsertUpdate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spConfig_LastExpenseNumber_InsertUpdate]
　@LastExpenseNumber int
AS
BEGIN
    SET NOCOUNT ON

	if Exists (select 1 from dbo.[Config])		
		update dbo.[Config]
		set LastExpenseNumber = @LastExpenseNumber
		where LastExpenseNumber < @LastExpenseNumber;
	else
		insert into dbo.[Config] (LastExpenseNumber)
			values (@LastExpenseNumber);
END
GO
/****** Object:  StoredProcedure [dbo].[spGradeType_Delete]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGradeType_Delete]
	@Id int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	delete 
	from dbo.[GradeType]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spGradeType_GetAll]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGradeType_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[GradeType]
	order by DisplaySeq;
END
GO
/****** Object:  StoredProcedure [dbo].[spGradeType_GetById]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGradeType_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[GradeType]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spGradeType_Insert]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGradeType_Insert]    
    @GradeTypeName dbo.[Name],    
    @DisplaySeq int,
    @UseFlag [dbo].[Flag],
    @InsertUserId int,
	@UpdateUserId int,
    @Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[GradeType]
                (GradeTypeName,                
                DisplaySeq,
                UseFlag,
                InsertUserId,
				UpdateUserId)
	    values
               (@GradeTypeName,
               @DisplaySeq,
               @UseFlag,
               @InsertUserId,
			   @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spGradeType_Update]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGradeType_Update]
	@Id int,
	@GradeTypeName dbo.[Name],
	@DisplaySeq int,	
	@UseFlag dbo.Flag,	
	@UpdateUserId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[GradeType]
	set 
	GradeTypeName = @GradeTypeName,	
	DisplaySeq = @DisplaySeq,
	UseFlag = @UseFlag,	
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spIncomingsBook_GetsDisplayByFromToDate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spIncomingsBook_GetsDisplayByFromToDate]
	@FromDate DateTime,
	@ToDate DateTime,
	@LesseeId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/
	with withTable as (
		/* 청구액 */
		/*
		select datetrunc(month, InvoiceDate) as TransactionDate,
		format(datetrunc(month,InvoiceDate), 'MM월 청구액(임대료)') as TransactionDetailsDisplay,
		MonthlyRent + MonthlyRentVAT as InvoiceAmount,
		0 as IncomingsAmount,	
		0 as LossAmount, 
		0 as ReceivableAmount,
		0 as DisplaySeq
		from dbo.[Invoice]
		where InvoiceDate >= @FromDate
		and InvoiceDate <= @ToDate
		and LesseeId = @LesseeId
		union all
		select datetrunc(month, InvoiceDate) as TransactionDate,
		format(datetrunc(month,InvoiceDate), 'MM월 청구액(관리비)') as TransactionDetailsDisplay,
		MaintenanceFee + MaintenanceFeeVAT as InvoiceAmount,
		0 as IncomingsAmount,	
		0 as LossAmount, 
		0 as ReceivableAmount,
		0 as DisplaySeq
		from dbo.[Invoice]
		where InvoiceDate >= @FromDate
		and InvoiceDate <= @ToDate
		and LesseeId = @LesseeId
		union all
		select datetrunc(month, InvoiceDate) as TransactionDate,
		format(datetrunc(month,InvoiceDate), 'MM월 청구액(전기요금)') as TransactionDetailsDisplay,
		ElectricBill + ElectricBillVAT as InvoiceAmount,
		0 as IncomingsAmount,	
		0 as LossAmount, 
		0 as ReceivableAmount,
		0 as DisplaySeq
		from dbo.[Invoice]
		where InvoiceDate >= @FromDate
		and InvoiceDate <= @ToDate
		and LesseeId = @LesseeId
		union all
		select datetrunc(month, InvoiceDate) as TransactionDate,
		format(datetrunc(month,InvoiceDate), 'MM월 청구액(수도료)') as TransactionDetailsDisplay,
		WaterBill as InvoiceAmount,
		0 as IncomingsAmount,	
		0 as LossAmount, 
		0 as ReceivableAmount,
		0 as DisplaySeq
		from dbo.[Invoice]
		where InvoiceDate >= @FromDate
		and InvoiceDate <= @ToDate
		and LesseeId = @LesseeId
		union all
		select datetrunc(month, InvoiceDate) as TransactionDate,
		format(datetrunc(month,InvoiceDate), 'MM월 청구액(도로점용료)') as TransactionDetailsDisplay,
		RoadOccupancyFee + RoadOccupancyFeeVAT as InvoiceAmount,
		0 as IncomingsAmount,	
		0 as LossAmount, 
		0 as ReceivableAmount,
		0 as DisplaySeq
		from dbo.[Invoice]
		where InvoiceDate >= @FromDate
		and InvoiceDate <= @ToDate
		and LesseeId = @LesseeId
		union all
		select datetrunc(month, InvoiceDate) as TransactionDate,
		format(datetrunc(month,InvoiceDate), 'MM월 청구액(교통유발부담금)') as TransactionDetailsDisplay,
		TrafficCausingCharge + TrafficCausingChargeVAT as InvoiceAmount,
		0 as IncomingsAmount,	
		0 as LossAmount, 
		0 as ReceivableAmount,
		0 as DisplaySeq
		from dbo.[Invoice]
		where InvoiceDate >= @FromDate
		and InvoiceDate <= @ToDate
		and LesseeId = @LesseeId
		*/
		select datetrunc(month, InvoiceDate) as TransactionDate,
		format(datetrunc(month,InvoiceDate), 'MM월 청구액') as TransactionDetailsDisplay,
		isnull(LineTotal,0) as InvoiceAmount,
		0 as IncomingsAmount,	
		0 as LossAmount, 
		0 as ReceivableAmount,
		0 as DisplaySeq
		from dbo.[Invoice]
		where InvoiceDate >= @FromDate
		and InvoiceDate <= @ToDate
		and LesseeId = @LesseeId
		union all
		/* 수입액 */
		select TransactionDate, 
			TransactionDetails as TransactionDetailsDisplay, 
			0 as InvoiceAmount, 
			DepositAmount as IncomingsAmount,
			0 as LossAmount,
			0 as ReceivableAmount, 
			Id as displaySeq
		from dbo.[CashBook]
		where TransactionDate >= @FromDate and TransactionDate <= @ToDate 
		and LesseeId = @LesseeId
		and InOutgoings = 0
		and DelFlag = 0	
		union all
		/* 결손액 */
		select TransactionDate, 
			TransactionDetails as TransactionDetailsDisplay, 
			0 as InvoiceAmount, 
			0 as IncomingsAmount,
			LossAmount,
			0 as ReceivableAmount, 
			Id as displaySeq
		from dbo.[CashBook]
		where TransactionDate >= @FromDate and TransactionDate <= @ToDate 
		and LesseeId = @LesseeId
		and InOutgoings = 2
		and DelFlag = 0				
		union all
		/* 미수금 */
		select datetrunc(month, @FromDate) as TransactionDate,		
		'전월 미수금' as TransactionDetailsDisplay,
		0 as InvoiceAmount,
		0 as IncomingsAmount,	
		0 as LossAmount, 
		/* 미수금 = 청구서 총액 - 입금액 - 결손액 */
		/* 청구서 총액 */
		(select isnull(sum(LineTotal),0)
		from dbo.[Invoice]
		where InvoiceDate < @FromDate
		and LesseeId = @LesseeId)		
		- 
		/* 입금액 */
		(select isnull(sum(DepositAmount),0)
		from dbo.[CashBook]
		where TransactionDate < @FromDate
		and LesseeId = @LesseeId
		and InOutgoings = 0
		and DelFlag = 0)		
		- 
		/* 결손액 */
		(select isnull(sum(LossAmount),0)
		from dbo.[CashBook]
		where TransactionDate < @FromDate
		and LesseeId = @LesseeId
		and InOutgoings = 2
		and DelFlag = 0) as ReceivableAmount,
		-1 as DisplaySeq
		)

		select * from withTable
		order by TransactionDate, DisplaySeq;
END
GO
/****** Object:  StoredProcedure [dbo].[spIncomingsBookTotal_GetsDisplayByFromToDate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spIncomingsBookTotal_GetsDisplayByFromToDate]
	@FromDate DateTime,
	@ToDate DateTime
AS
with Account as
(
	/*수입부 계정과목*/
	select account.Id as AccountCodeId, hang.AccountHangName, account.AccountName,
	InOutgoings, hang.DisplaySeq as DisplaySeq1, account.DisplaySeq as DisplaySeq2
	from dbo.[AccountHangCode] hang
	left join dbo.[AccountCode] account
	 on hang.Id = account.AccountHangCodeId
	where account.UseFlag = 1 and InOutgoings = 0
)
,
Budget
as
(
	/*예산액*/
	select AccountCodeId, BudgetAmount
	from dbo.[BudgetAmount] budget
	where FiscalYear = year(@FromDate)
	and Exists (select 1
		from dbo.[AccountCode] account
		inner join dbo.[AccountHangCode] hang
		  on account.AccountHangCodeId = hang.Id
		where account.Id = budget.AccountCodeId and hang.InOutgoings = 0)
)
,
Deposit
as
(
	/*수입액*/
	select AccountCodeId,	
	sum(DepositAmount) as IncomingsAmount
	from dbo.[CashBook]
	where TransactionDate >= @FromDate 
	and TransactionDate <= @ToDate
	and DelFlag = 0
	and InOutgoings = 0 
	group by AccountCodeId
	/*전년도 이월금*/
	/*
	union all	
	select case when account.AccountHangCodeId = 1 then 5 
	        when account.AccountHangCodeId = 2 then 9
		end as AccountCodeId,	
	sum(cb.DepositAmount) - sum(cb.LossAmount) as IncomingsAmount /* 수입액 - 결손액 */
	from dbo.[CashBook] cb
	inner join dbo.[AccountCode] account
	  on account.Id = cb.AccountCodeId	
	where cb.TransactionDate < datetrunc(year, @FromDate)
	and cb.DelFlag = 0
	and cb.InOutgoings in (0, 2)
	group by account.AccountHangCodeId
	*/
)
,
Loss
as
(
	/*결손액*/
	select AccountCodeId,	
	sum(LossAmount) as LossAmount
	from dbo.[CashBook]
	where TransactionDate >= @FromDate 
	and TransactionDate <= @ToDate
	and DelFlag = 0
	and InOutgoings = 2 
	group by AccountCodeId
)

select AccountHangName, 
	AccountName, 
	isnull(BudgetAmount,0) as BudgetAmount, 
	isnull(IncomingsAmount,0) as IncomingsAmount,
	isnull(LossAmount,0) as LossAmount,
	isnull(BudgetAmount,0)-isnull(IncomingsAmount,0)-isnull(LossAmount,0) as DifferenceAmount
from Account
left join Budget
	on Account.AccountCodeId = Budget.AccountCodeId
left join Deposit
	on Account.AccountCodeId = Deposit.AccountCodeId
left join Loss
	on Account.AccountCodeId = Loss.AccountCodeId
order by Account.DisplaySeq1, account.DisplaySeq2;
GO
/****** Object:  StoredProcedure [dbo].[spIncomingsDetails_GetsDisplayByFromToDate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spIncomingsDetails_GetsDisplayByFromToDate]
	@SearchDate DateTime,
	@TotalCalcByYearFlag bit
AS
if @TotalCalcByYearFlag = 1
	/*연초부터 누계 계산*/
	with BuildingRoomCode as
	(
		/*건물*/
		select room.Id as BuildingRoomCodeId, BuildingCodeId, [Floor], Room,
			building.DisplaySeq as DisplaySeq1, 
			room.DisplaySeq as DisplaySeq2
		from dbo.[BuildingRoomCode] room
		left join dbo.[BuildingCode] building
			on room.BuildingCodeId = building.Id
	)
	,
	PreviousInvoice
	as
	(
		/*이전 청구액 합계*/
		select LesseeId, sum(LineTotal) PreviousInvoiceAmount
		from dbo.[Invoice]
		where InvoiceDate < @SearchDate
		group by LesseeId
	)
	,	
	PreviousIncomings
	as
	(
		/*이전 수입액-결손액 합계*/
			select LesseeId,
			isnull(sum(DepositAmount),0) - isnull(sum(LossAmount),0) as PreviousIncomingsAmount
			from dbo.[CashBook]
			where TransactionDate < @SearchDate	
			and DelFlag = 0
			and InOutgoings in (0 ,2)
			group by LesseeId
	)
	,
	Invoice
	as
	(
		/*청구액*/
		select BuildingRoomCodeId, LesseeId, LineTotal as InvoiceAmount
		from dbo.[Invoice]
		where InvoiceDate = @SearchDate
	)
	,
	InvoiceTotal
	as
	(
		/*청구액 누계*/
		select LesseeId, sum(LineTotal) as InvoiceTotalAmount
		from dbo.[Invoice]
		where InvoiceDate >= datetrunc(year, @SearchDate)
		and InvoiceDate <= @SearchDate
		group by LesseeId
	)
	,
	Incomings
	as
	(
		/*수입액*/
		select LesseeId,
		sum(DepositAmount) as IncomingsAmount
		from dbo.[CashBook]
		where TransactionDate >= @SearchDate 
		and TransactionDate <= eomonth(@SearchDate)
		and DelFlag = 0
		and InOutgoings = 0 
		group by LesseeId
	)
	,
	IncomingsTotal
	as
	(
		/*수입액 누계*/
		select LesseeId, 
		sum(DepositAmount) as IncomingsTotalAmount
		from dbo.[CashBook]
		where TransactionDate >= datetrunc(year, @SearchDate)
		and TransactionDate <= eomonth(@SearchDate)
		and DelFlag = 0
		and InOutgoings = 0 
		group by LesseeId
	)
	,
	Loss
	as
	(
		/*결손액*/
		select LesseeId,
		sum(LossAmount) as LossAmount
		from dbo.[CashBook]
		where TransactionDate >= @SearchDate 
		and TransactionDate <= eomonth(@SearchDate)
		and DelFlag = 0
		and InOutgoings = 2 
		group by LesseeId
	)
	,
	LossTotal
	as
	(
		/*결손액 누계*/
		select LesseeId, 
			sum(LossAmount) as LossTotalAmount
		from dbo.[CashBook]
		where TransactionDate >= datetrunc(year, @SearchDate)
		and TransactionDate <= eomonth(@SearchDate)
		and DelFlag = 0
		and InOutgoings = 2 
		group by LesseeId
	)

	select room.BuildingCodeId, [Floor], Room,
		Invoice.LesseeId, 
		isnull(PreviousInvoiceAmount,0) - isnull(PreviousIncomingsAmount,0) as PreviousReceivableAmount, /*전월 미수금(청구액-수입액-결손액)*/
		isnull(InvoiceAmount,0) as InvoiceAmount, /*당월 청구액*/
		isnull(InvoiceTotalAmount,0) as InvoiceTotalAmount, /*청구액 누계*/
		isnull(IncomingsAmount,0) as IncomingsAmount, /*당월 수입액*/
		isnull(IncomingsTotalAmount,0) as IncomingsTotalAmount, /*수입액 누계*/
		isnull(LossAmount,0) as LossAmount, /*당월 결손액*/
		isnull(LossTotalAmount,0) as LossTotalAmount, /*결손액 누계*/
		isnull(InvoiceAmount,0) - isnull(IncomingsAmount,0) - isnull(LossAmount,0) as ReceivableAmount, /*당월 미수금*/
		isnull(PreviousInvoiceAmount,0) - isnull(PreviousIncomingsAmount,0) +  isnull(InvoiceAmount,0) - isnull(IncomingsAmount,0) - isnull(LossAmount,0) as ReceivableTotalAmount /*총 미수금*/
	from BuildingRoomCode room
	left join Invoice
	  on Invoice.BuildingRoomCodeId = room.BuildingRoomCodeId
	left join InvoiceTotal
	  on InvoiceTotal.LesseeId = Invoice.LesseeId
	left join Incomings
	  on Incomings.LesseeId = Invoice.LesseeId
	left join IncomingsTotal
	  on IncomingsTotal.LesseeId = Invoice.LesseeId
	left join Loss
	  on Loss.LesseeId = Invoice.LesseeId
	left join LossTotal
	  on LossTotal.LesseeId = Invoice.LesseeId
	left join PreviousInvoice
	  on PreviousInvoice.LesseeId = Invoice.LesseeId
	left join PreviousIncomings
	  on PreviousIncomings.LesseeId = Invoice.LesseeId
	order by DisplaySeq1, DisplaySeq2, room.BuildingCodeId, [Floor], Room;
else
	/*계약시작부터 누계 계산*/
	with BuildingRoomCode as
	(
		/*건물*/
		select room.Id as BuildingRoomCodeId, BuildingCodeId, [Floor], Room,
			building.DisplaySeq as DisplaySeq1, 
			room.DisplaySeq as DisplaySeq2
		from dbo.[BuildingRoomCode] room
		left join dbo.[BuildingCode] building
		  on room.BuildingCodeId = building.Id
	)
	,
	PreviousInvoice
	as
	(
		/*이전 청구액 합계*/
		select LesseeId, sum(LineTotal) PreviousInvoiceAmount
		from dbo.[Invoice]
		where InvoiceDate < @SearchDate
		group by LesseeId	
	)
	,	
	PreviousIncomings
	as
	(
		/*이전 수입액-결손액 합계*/
			select LesseeId,
			isnull(sum(DepositAmount),0) - isnull(sum(LossAmount),0) as PreviousIncomingsAmount
			from dbo.[CashBook]
			where TransactionDate < @SearchDate	
			and DelFlag = 0
			and InOutgoings in (0 ,2)
			group by LesseeId	
	)
	,
	Invoice
	as
	(
		/*청구액*/
		select BuildingRoomCodeId, LesseeId, LineTotal as InvoiceAmount
		from dbo.[Invoice]
		where InvoiceDate = @SearchDate
	)
	,
	InvoiceTotal
	as
	(
		/*청구액 누계*/
		select LesseeId, sum(LineTotal) as InvoiceTotalAmount
		from dbo.[Invoice]
		where InvoiceDate <= @SearchDate
		group by LesseeId
	)
	,
	Incomings
	as
	(
		/*수입액*/
		select LesseeId,
		sum(DepositAmount) as IncomingsAmount
		from dbo.[CashBook]
		where TransactionDate >= @SearchDate 
		and TransactionDate <= eomonth(@SearchDate)
		and DelFlag = 0
		and InOutgoings = 0 
		group by LesseeId
	)
	,
	IncomingsTotal
	as
	(
		/*수입액 누계*/
		select LesseeId, 
		sum(DepositAmount) as IncomingsTotalAmount
		from dbo.[CashBook]
		where TransactionDate <= eomonth(@SearchDate)
		and DelFlag = 0
		and InOutgoings = 0 
		group by LesseeId
	)
	,
	Loss
	as
	(
		/*결손액*/
		select LesseeId,
		sum(LossAmount) as LossAmount
		from dbo.[CashBook]
		where TransactionDate >= @SearchDate 
		and TransactionDate <= eomonth(@SearchDate)
		and DelFlag = 0
		and InOutgoings = 2 
		group by LesseeId
	)
	,
	LossTotal
	as
	(
		/*결손액 누계*/
		select LesseeId, 
		sum(LossAmount) as LossTotalAmount
		from dbo.[CashBook]
		where TransactionDate <= eomonth(@SearchDate)
		and DelFlag = 0
		and InOutgoings = 2 
		group by LesseeId
	)

	select room.BuildingCodeId, [Floor], Room,
		Invoice.LesseeId, 
		isnull(PreviousInvoiceAmount,0) - isnull(PreviousIncomingsAmount,0) as PreviousReceivableAmount, /*전월 미수금(청구액-수입액-결손액)*/
		isnull(InvoiceAmount,0) as InvoiceAmount, /*당월 청구액*/
		isnull(InvoiceTotalAmount,0) as InvoiceTotalAmount, /*청구액 누계*/
		isnull(IncomingsAmount,0) as IncomingsAmount, /*당월 수입액*/
		isnull(IncomingsTotalAmount,0) as IncomingsTotalAmount, /*수입액 누계*/
		isnull(LossAmount,0) as LossAmount, /*당월 결손액*/
		isnull(LossTotalAmount,0) as LossTotalAmount, /*결손액 누계*/
		isnull(InvoiceAmount,0) - isnull(IncomingsAmount,0) - isnull(LossAmount,0) as ReceivableAmount, /*당월 미수금*/
		isnull(PreviousInvoiceAmount,0) - isnull(PreviousIncomingsAmount,0) +  isnull(InvoiceAmount,0) - isnull(IncomingsAmount,0) - isnull(LossAmount,0) as ReceivableTotalAmount /*총 미수금*/
	from BuildingRoomCode room
	left join Invoice
	  on Invoice.BuildingRoomCodeId = room.BuildingRoomCodeId
	left join InvoiceTotal
	  on InvoiceTotal.LesseeId = Invoice.LesseeId
	left join Incomings
	  on Incomings.LesseeId = Invoice.LesseeId
	left join IncomingsTotal
	  on IncomingsTotal.LesseeId = Invoice.LesseeId
	left join Loss
	  on Loss.LesseeId = Invoice.LesseeId
	left join LossTotal
	  on LossTotal.LesseeId = Invoice.LesseeId
	left join PreviousInvoice
	  on PreviousInvoice.LesseeId = Invoice.LesseeId
	left join PreviousIncomings
	  on PreviousIncomings.LesseeId = Invoice.LesseeId
	order by DisplaySeq1, DisplaySeq2, room.BuildingCodeId, [Floor], Room;
GO
/****** Object:  StoredProcedure [dbo].[spInvoice_Delete]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInvoice_Delete]
	@Id int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	delete 
	from dbo.[Invoice]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spInvoice_GetAll]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInvoice_GetAll]
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	select *
	from dbo.[Invoice];
END
GO
/****** Object:  StoredProcedure [dbo].[spInvoice_GetAllDisplayByDate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInvoice_GetAllDisplayByDate]
	@InvoiceDate datetime
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	select room.BuildingCodeId, Invoice.*
	from dbo.[Invoice]
	left join dbo.[BuildingRoomCode] room
		on room.Id = Invoice.BuildingRoomCodeId
	left join dbo.[BuildingCode] building
		on building.Id = room.BuildingCodeId
	where InvoiceDate = @InvoiceDate
	order by building.DisplaySeq, room.DisplaySeq;
END
GO
/****** Object:  StoredProcedure [dbo].[spInvoice_GetsDisplayByDate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInvoice_GetsDisplayByDate]
	@InvoiceDate datetime,
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	select invoice.*
	from dbo.[Invoice]  invoice 
	left join dbo.[BuildingRoomCode] room
		on invoice.BuildingRoomCodeId = room.Id
	where InvoiceDate = @InvoiceDate and room.BuildingCodeId = @BuildingCodeId
	order by room.DisplaySeq;
END
GO
/****** Object:  StoredProcedure [dbo].[spInvoice_GetsDisplayByDate1]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInvoice_GetsDisplayByDate1]
	@InvoiceDate datetime,
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	/* 호실과 임차인을 선택해서 입력할 경우 사용 */
	if exists (select 1
			from dbo.[Invoice]  invoice 
			left join dbo.[BuildingRoomCode] room
				on invoice.BuildingRoomCodeId = room.Id
			where InvoiceDate = @InvoiceDate and room.BuildingCodeId = @BuildingCodeId)

		select invoice.Id, 
		invoice.InvoiceDate, 
		invoice.BuildingRoomCodeId, 
		invoice.LesseeId, 
		invoice.BillIssueDay, 
		invoice.MonthlyRent, 
		invoice.MonthlyRentVAT,
		invoice.MaintenanceFee,
		invoice.MaintenanceFeeVAT,
		invoice.ElectricBill,
		invoice.ElectricBillVAT,
		invoice.WaterBill,
		invoice.RoadOccupancyFee,
		invoice.RoadOccupancyFeeVAT,
		invoice.TrafficCausingCharge,
		invoice.TrafficCausingChargeVAT,
		invoice.LineTotal
		from dbo.[Invoice]  invoice 
		left join dbo.[BuildingRoomCode] room
		 on invoice.BuildingRoomCodeId = room.Id
		where InvoiceDate = @InvoiceDate and room.BuildingCodeId = @BuildingCodeId
		order by room.DisplaySeq;
	else
		select 0 Id, 
		null InvoiceDate, 
		Id as BuildingRoomCodeId, 
		0 LesseeId, 
		null BillIssueDay, 
		0 MonthlyRent, 
		0 MonthlyRentVAT,
		0 MaintenanceFee,
		0 MaintenanceFeeVAT,
		0 ElectricBill,
		0 ElectricBillVAT,
		0 WaterBill,
		0 RoadOccupancyFee,
		0 RoadOccupancyFeeVAT,
		0 TrafficCausingCharge,
		0 TrafficCausingChargeVAT,
		0 LineTotal
		from dbo.[BuildingRoomCode]
		where BuildingCodeId = @BuildingCodeId
		order by DisplaySeq;
END
GO
/****** Object:  StoredProcedure [dbo].[spInvoice_InitByDate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInvoice_InitByDate]
	@InvoiceDate datetime,
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	delete from dbo.[Invoice]
	where InvoiceDate = @InvoiceDate
	and Exists (select 1 from dbo.[BuildingRoomCode] 
				where Id = Invoice.BuildingRoomCodeId 
				and BuildingCodeId = @BuildingCodeId);

	/* LeaseContract 사용: 동일 임차인이 계약이 여러건일 경우 모두 나타남 -> 사용자가 삭제해야 함. */
	insert into dbo.[Invoice] ([InvoiceDate]
           ,[BuildingRoomCodeId]
           ,[LesseeId]
           ,[BillIssueDay]
           ,[MonthlyRent]
           ,[MonthlyRentVAT]
           ,[MaintenanceFee]
           ,[MaintenanceFeeVAT]
           ,[ElectricBill]
           ,[ElectricBillVAT]
           ,[WaterBill]
           ,[RoadOccupancyFee]
           ,[RoadOccupancyFeeVAT]
           ,[TrafficCausingCharge]
           ,[TrafficCausingChargeVAT]
           ,[InsertUserId]           
           ,[UpdateUserId])
	select	InvoiceDate = @InvoiceDate, 
		room.Id as BuildingRoomCodeId, 
		LesseeId = case					
					when lc.Id is not null then lc.LesseeId
					else 1 /* 초기값 */
					end,
		BillIssueDay = case
					when lc.Id is not null then (select BillIssueDay from dbo.[Lessee] where Id = lc.LesseeId)
					else null
					end, 
		MonthlyRent = case
					when lc.Id is not null then lc.MonthlyRent
					else 0
					end, 
		MonthlyRentVAT = case
					when lc.Id is not null then lc.MonthlyRentVAT
					else 0
					end,
		MaintenanceFee = case
					when lc.Id is not null then lc.MaintenanceFee
					else 0
					end,
		MaintenanceFeeVAT = case
					when lc.Id is not null then lc.MaintenanceFeeVAT
					else 0
					end,
		ElectricBill = 0,
		ElectricBillVAT = 0,
		WaterBill = 0,
		RoadOccupancyFee = 0,
		RoadOccupancyFeeVAT = 0,
		TrafficCausingCharge = 0,
		TrafficCausingChargeVAT = 0,
		InsertUserId = 1,
		UpdateUserId = 1
	from dbo.[BuildingRoomCode] room
	left join dbo.[LeaseContract] lc
		on room.Id = lc.BuildingRoomCodeId
		and lc.ContractStartDate <= eomonth(@InvoiceDate) /*계약일이 해당 월에 포함되면 보이게*/
		and lc.ContractEndDate >= @InvoiceDate
	where room.BuildingCodeId = @BuildingCodeId
	and room.UseFlag = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[spInvoice_InitByDate1]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInvoice_InitByDate1]
	@InvoiceDate datetime,
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	delete from dbo.[Invoice]
	where InvoiceDate = @InvoiceDate
	and Exists (select 1 from dbo.[BuildingRoomCode] 
				where Id = Invoice.BuildingRoomCodeId 
				and BuildingCodeId = @BuildingCodeId);

	/* LeaseContract 사용: 동일 임차인이 계약이 여러건일 경우 모두 나타남 -> 사용자가 삭제해야 함. */
	select Id = case 
					when invoice.Id is not null then invoice.Id
					else 0
					end,
		InvoiceDate = case 
					when invoice.Id is not null then invoice.InvoiceDate
					else null
					end, 
		room.Id as BuildingRoomCodeId, 
		LesseeId = case
					when invoice.Id is not null then invoice.LesseeId
					when lc.Id is not null then lc.LesseeId
					else 0
					end,
		BillIssueDay = case 
					when invoice.Id is not null then invoice.BillIssueDay
					when lc.Id is not null then (select BillIssueDay from dbo.[Lessee] where Id = lc.LesseeId)
					else null
					end, 
		MonthlyRent = case
					when invoice.Id is not null then invoice.MonthlyRent
					when lc.Id is not null then lc.MonthlyRent
					else 0
					end, 
		MonthlyRentVAT = case
					when invoice.Id is not null then invoice.MonthlyRentVAT
					when lc.Id is not null then lc.MonthlyRentVAT
					else 0
					end,
		MaintenanceFee = case
					when invoice.Id is not null then invoice.MaintenanceFee
					when lc.Id is not null then lc.MaintenanceFee
					else 0
					end,
		MaintenanceFeeVAT = case
					when invoice.Id is not null then invoice.MaintenanceFeeVAT
					when lc.Id is not null then lc.MaintenanceFeeVAT
					else 0
					end,
		ElectricBill = case
					when invoice.Id is not null then invoice.ElectricBill					
					else 0
					end,
		ElectricBillVAT = case
					when invoice.Id is not null then invoice.ElectricBillVAT					
					else 0
					end,
		WaterBill = case
					when invoice.Id is not null then invoice.WaterBill					
					else 0
					end,
		RoadOccupancyFee = case
					when invoice.Id is not null then invoice.RoadOccupancyFee					
					else 0
					end,
		RoadOccupancyFeeVAT = case
					when invoice.Id is not null then invoice.RoadOccupancyFeeVAT					
					else 0
					end,
		TrafficCausingCharge = case
					when invoice.Id is not null then invoice.TrafficCausingCharge					
					else 0
					end,
		TrafficCausingChargeVAT = case
					when invoice.Id is not null then invoice.TrafficCausingChargeVAT					
					else 0
					end,
		LineTotal = case
					when invoice.Id is not null then invoice.LineTotal					
					else 0
					end
	from dbo.[BuildingRoomCode] room
	left join dbo.[LeaseContract] lc
		on room.Id = lc.BuildingRoomCodeId
		and lc.ContractStartDate <= eomonth(@InvoiceDate) /*계약일이 해당 월에 포함되면 보이게*/
		and lc.ContractEndDate >= @InvoiceDate
	left join dbo.[Invoice] invoice
		on invoice.BuildingRoomCodeId = room.Id
		and invoice.LesseeId = lc.Id
		and invoice.InvoiceDate = @InvoiceDate
	where room.BuildingCodeId = @BuildingCodeId
	and room.UseFlag = 1
	order by room.DisplaySeq, LesseeId;
END
GO
/****** Object:  StoredProcedure [dbo].[spInvoice_Insert]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInvoice_Insert]
	@InvoiceDate DATETIME,
	@BuildingRoomCodeId      INT,
	@LesseeId                INT,
	@BillIssueDay            NVARCHAR(20),    
	@MonthlyRent             MONEY,
	@MonthlyRentVAT          MONEY,
	@MaintenanceFee          MONEY,
	@MaintenanceFeeVAT       MONEY,
	@ElectricBill            MONEY,
	@ElectricBillVAT         MONEY,
	@WaterBill               MONEY,
	@RoadOccupancyFee        MONEY,
	@RoadOccupancyFeeVAT     MONEY,
	@TrafficCausingCharge    MONEY,
	@TrafficCausingChargeVAT    MONEY,
	@InsertUserId int,
	@UpdateUserId int,
	@Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[Invoice]
                (InvoiceDate,
				BuildingRoomCodeId,
				LesseeId,
				BillIssueDay,    
				MonthlyRent,
				MonthlyRentVAT,
				MaintenanceFee,
				MaintenanceFeeVAT,
				ElectricBill,
				ElectricBillVAT,
				WaterBill,
				RoadOccupancyFee,
				RoadOccupancyFeeVAT,
				TrafficCausingCharge,
				TrafficCausingChargeVAT,
                InsertUserId,
                UpdateUserId)
	    values
               (@InvoiceDate,
				@BuildingRoomCodeId,
				@LesseeId,
				@BillIssueDay,    
				@MonthlyRent,
				@MonthlyRentVAT,
				@MaintenanceFee,
				@MaintenanceFeeVAT,
				@ElectricBill,
				@ElectricBillVAT,
				@WaterBill,
				@RoadOccupancyFee,
				@RoadOccupancyFeeVAT,
				@TrafficCausingCharge,
				@TrafficCausingChargeVAT,
               @InsertUserId,
               @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spInvoice_Update]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInvoice_Update]
	@Id int,
	@InvoiceDate DATETIME,
	@BuildingRoomCodeId      INT,
	@LesseeId                INT,
	@BillIssueDay            NVARCHAR(20),    
	@MonthlyRent             MONEY,
	@MonthlyRentVAT          MONEY,
	@MaintenanceFee          MONEY,
	@MaintenanceFeeVAT       MONEY,
	@ElectricBill            MONEY,
	@ElectricBillVAT         MONEY,
	@WaterBill               MONEY,
	@RoadOccupancyFee        MONEY,
	@RoadOccupancyFeeVAT     MONEY,
	@TrafficCausingCharge    MONEY,
	@TrafficCausingChargeVAT    MONEY,
	@UpdateUserId int
AS
BEGIN
    SET NOCOUNT ON

	update dbo.[Invoice]
	set
    InvoiceDate = @InvoiceDate,
	BuildingRoomCodeId = @BuildingRoomCodeId,
	LesseeId = @LesseeId,
	BillIssueDay = @BillIssueDay,    
	MonthlyRent = @MonthlyRent,
	MonthlyRentVAT = @MonthlyRentVAT,
	MaintenanceFee =@MaintenanceFee,
	MaintenanceFeeVAT = @MaintenanceFeeVAT,
	ElectricBill = @ElectricBill,
	ElectricBillVAT = @ElectricBillVAT,
	WaterBill = @WaterBill,
	RoadOccupancyFee = @RoadOccupancyFee,
	RoadOccupancyFeeVAT = @RoadOccupancyFeeVAT,
	TrafficCausingCharge = @TrafficCausingCharge,
	TrafficCausingChargeVAT = @TrafficCausingChargeVAT,
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spLeaseContract_Delete]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLeaseContract_Delete]
	@Id int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	delete 
	from dbo.[LeaseContract]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spLeaseContract_GetAll]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLeaseContract_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[LeaseContract]
	order by ContractStartDate desc;
END
GO
/****** Object:  StoredProcedure [dbo].[spLeaseContract_GetAllDisplay]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLeaseContract_GetAllDisplay]
AS
BEGIN
	SET NOCOUNT ON
	/* 열이름 자동 나열하는 방법
		BuildingLease.UserDB의 저장프로시저에서 열어서 
		select c.*으로 입력하고 *에 마우스 우측클릭해서 리펙터링 
		-> 와일드 카드 확장하면 열이름이 자동 완성된다.
	*/
	select c.*,
	       r.BuildingCodeId, r.[Floor], r.Room
	from dbo.[LeaseContract] c
	left join dbo.[BuildingRoomCode] r
	  on c.BuildingRoomCodeId = r.Id
	order by ContractStartDate desc;
END
GO
/****** Object:  StoredProcedure [dbo].[spLeaseContract_GetById]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLeaseContract_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[LeaseContract]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spLeaseContract_GetsDisplayByLesseeId]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLeaseContract_GetsDisplayByLesseeId]
	@LesseeId int
AS
BEGIN
	SET NOCOUNT ON
	/* 열이름 자동 나열하는 방법
		BuildingLease.UserDB의 저장프로시저에서 열어서 
		select c.*으로 입력하고 *에 마우스 우측클릭해서 리펙터링 
		-> 와일드 카드 확장하면 열이름이 자동 완성된다.
	*/
	select c.*,
	       r.BuildingCodeId, r.[Floor], r.Room
	from dbo.[LeaseContract] c
	left join dbo.[BuildingRoomCode] r
	  on c.BuildingRoomCodeId = r.Id
	where c.LesseeId = @LesseeId
	order by c.ContractStartDate desc;
END
GO
/****** Object:  StoredProcedure [dbo].[spLeaseContract_Insert]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLeaseContract_Insert]
	@LesseeId INT,
    @BuildingRoomCodeId INT,
    @ContractStartDate DATETIME,
    @ContractEndDate DATETIME,
    @Deposit MONEY,
    @MonthlyRent MONEY,
    @MonthlyRentVAT MONEY,
    @MaintenanceFee MONEY,
    @MaintenanceFeeVAT MONEY,
	@Notes nvarchar(200),	
	@InsertUserId int,
	@UpdateUserId int,
	@Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[LeaseContract]
                (LesseeId,
                BuildingRoomCodeId,
                ContractStartDate,
                ContractEndDate,                
                Deposit,
                MonthlyRent,
                MonthlyRentVAT,
                MaintenanceFee,
                MaintenanceFeeVAT,
                Notes,
                InsertUserId,
                UpdateUserId)
	    values
               (@LesseeId,
               @BuildingRoomCodeId,
               @ContractStartDate,
               @ContractEndDate,
               @Deposit,
               @MonthlyRent,
               @MonthlyRentVAT,
               @MaintenanceFee,
               @MaintenanceFeeVAT,
			   @Notes,
               @InsertUserId,
               @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spLeaseContract_Update]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLeaseContract_Update]
	@Id int,
	@LesseeId INT,
    @BuildingRoomCodeId INT,
    @ContractStartDate DATETIME,
    @ContractEndDate DATETIME,
    @Deposit MONEY,
    @MonthlyRent MONEY,
    @MonthlyRentVAT MONEY,    
    @MaintenanceFee MONEY,
    @MaintenanceFeeVAT MONEY,
	@Notes nvarchar(200),	
	@UpdateUserId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[LeaseContract]
	set 	
	LesseeId = @LesseeId,
	BuildingRoomCodeId = @BuildingRoomCodeId,
	ContractStartDate = @ContractStartDate,
	ContractEndDate = @ContractEndDate,
	Deposit = @Deposit,
	MonthlyRent = @MonthlyRent,
	MonthlyRentVAT = @MonthlyRentVAT,
	MaintenanceFee = @MaintenanceFee,
	MaintenanceFeeVAT = @MaintenanceFeeVAT,
	Notes = @Notes,
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spLeaseIncomings_GetsDisplayByFromToDate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLeaseIncomings_GetsDisplayByFromToDate]
	@FromDate DateTime,
	@ToDate DateTime
AS
BEGIN
	with BuildingRoomCode as
	(
		/*건물*/
		select room.Id as BuildingRoomCodeId, BuildingCodeId,
			building.DisplaySeq as DisplaySeq
		from dbo.[BuildingRoomCode] room
		left join dbo.[BuildingCode] building
			on room.BuildingCodeId = building.Id
	)
	,
	Invoice
	as
	(
		/*청구액*/
		select datetrunc(month, InvoiceDate) as InvoiceDate, BuildingRoomCodeId, LesseeId,
		sum(LineTotal) as InvoiceAmount
		from dbo.[Invoice]
		where InvoiceDate >= @FromDate
		and InvoiceDate <= @ToDate
		group by datetrunc(month, InvoiceDate),BuildingRoomCodeId, LesseeId
	)	
	,
	Incomings
	as
	(
		/*수입액*/
		select datetrunc(month, TransactionDate) as TransactionDate, LesseeId,
		sum(DepositAmount) as IncomingsAmount
		from dbo.[CashBook]
		where TransactionDate >= @FromDate 
		and TransactionDate <= @ToDate
		and DelFlag = 0
		and InOutgoings = 0 
		group by datetrunc(month, TransactionDate), LesseeId
	)	
	,
	Loss
	as
	(
		/*결손액*/
		select datetrunc(month, TransactionDate) as TransactionDate, LesseeId,
		sum(LossAmount) as LossAmount
		from dbo.[CashBook]
		where TransactionDate >= @FromDate 
		and TransactionDate <= @ToDate
		and DelFlag = 0
		and InOutgoings = 2 
		group by datetrunc(month, TransactionDate), LesseeId
	)
	

	select room.BuildingCodeId,	Invoice.InvoiceDate, room.DisplaySeq,
		sum(isnull(InvoiceAmount,0)) as InvoiceAmount, /*당월 청구액*/
		sum(isnull(IncomingsAmount,0)) as IncomingsAmount, /*당월 수입액*/
		sum(isnull(LossAmount,0)) as LossAmount /*당월 결손액*/
	from BuildingRoomCode room
	left join Invoice
	  on Invoice.BuildingRoomCodeId = room.BuildingRoomCodeId
	left join Incomings
	  on Incomings.LesseeId = Invoice.LesseeId
	  and Incomings.TransactionDate = Invoice.InvoiceDate
	left join Loss
	  on Loss.LesseeId = Invoice.LesseeId
	  and Loss.TransactionDate = Invoice.InvoiceDate
	where Invoice.InvoiceDate is not null
	group by room.BuildingCodeId, Invoice.InvoiceDate, room.DisplaySeq
	order by Invoice.InvoiceDate, room.DisplaySeq;
END
GO
/****** Object:  StoredProcedure [dbo].[spLessee_Delete]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLessee_Delete]
	@Id int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	delete 
	from dbo.[Lessee]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spLessee_Exists]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLessee_Exists]
	@Lessee dbo.[Name]
AS
BEGIN
	SET NOCOUNT ON

	if Exists (
		select 1
		from dbo.[Lessee]
		where Lessee = @Lessee)

		select Exist =1;
	else
		select Exist = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[spLessee_GetAll]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLessee_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[Lessee]
	where Id <> 1;
END
GO
/****** Object:  StoredProcedure [dbo].[spLessee_GetById]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLessee_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[Lessee]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spLessee_Insert]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLessee_Insert]
	@Lessee dbo.[Name],
	@Owner dbo.[Name],
	@RRN nvarchar(15),
	@BRN nvarchar(12),
	@Contact nvarchar(200),
	@UnderContractFlag dbo.[Flag],
	@BillIssueDay nvarchar(20),
	@Notes nvarchar(200),	
	@InsertUserId int,
	@UpdateUserId int,
	@Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[Lessee]
                (Lessee,
				[Owner],
				RRN,
				BRN,
				Contact,
				UnderContractFlag,
				BillIssueDay,
				Notes,
                InsertUserId,
                UpdateUserId)
	    values
               (@Lessee,
			   @Owner,
			   @RRN,
			   @BRN,
			   @Contact,
			   @UnderContractFlag,
			   @BillIssueDay,
			   @Notes,
               @InsertUserId,
               @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spLessee_IsUsed]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLessee_IsUsed]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	if (Exists (
		select 1
		from dbo.[CashBook]
		where LesseeId = @Id)
		or Exists (
		select 1
		from dbo.[Invoice]
		where LesseeId = @Id)
		or Exists (
		select 1
		from dbo.[LeaseContract]
		where LesseeId = @Id)
		or Exists (
		select 1
		from dbo.[MaintenanceFeeDetails]
		where LesseeId = @Id))

		select Exist =1;
	else
		select Exist = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[spLessee_Update]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLessee_Update]
	@Id int,
	@Lessee dbo.[Name],
	@Owner dbo.[Name],
	@RRN nvarchar(15),
	@BRN nvarchar(12),
	@Contact nvarchar(200),
	@UnderContractFlag dbo.[Flag],
	@BillIssueDay nvarchar(20),
	@Notes nvarchar(200),	
	@UpdateUserId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[Lessee]
	set 	
	Lessee = @Lessee,
	[Owner] = @Owner,
	RRN = @RRN,
	BRN = @BRN,
	Contact = @Contact,
	UnderContractFlag = @UnderContractFlag,
	BillIssueDay = @BillIssueDay,
	Notes = @Notes,
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spMaintenanceFeeDetails_GetsDisplayByDate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spMaintenanceFeeDetails_GetsDisplayByDate]
	@MaintenanceFeeDetailsDate datetime,
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	select main.*,
	le.Lessee,
	room.Area
	from dbo.[MaintenanceFeeDetails] main
	left join dbo.[BuildingRoomCode] room
		on main.BuildingRoomCodeId = room.Id
	left join dbo.[Lessee] le
		on main.LesseeId = le.Id	
	where main.MaintenanceFeeDetailsDate = @MaintenanceFeeDetailsDate and room.BuildingCodeId = @BuildingCodeId
	order by room.DisplaySeq;
END
GO
/****** Object:  StoredProcedure [dbo].[spMaintenanceFeeDetails_InitByDate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spMaintenanceFeeDetails_InitByDate]
	@MaintenanceFeeDetailsDate datetime,
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	delete from dbo.[MaintenanceFeeDetails]
	where MaintenanceFeeDetailsDate = @MaintenanceFeeDetailsDate
	and Exists (select 1 from dbo.[BuildingRoomCode] 
				where Id = MaintenanceFeeDetails.BuildingRoomCodeId 
				and BuildingCodeId = @BuildingCodeId);

	insert into dbo.[MaintenanceFeeDetails] 
           ([MaintenanceFeeDetailsDate]
           ,[BuildingRoomCodeId]
           ,[LesseeId]
           ,[ReceivableAmount]
           ,[MonthlyRent]
           ,[MonthlyRentVAT]
           ,[MaintenanceFee]
           ,[MaintenanceFeeVAT]
           ,[ElectricBill]
           ,[ElectricBillVAT]
           ,[WaterBill]
           ,[RoadOccupancyFee]
           ,[RoadOccupancyFeeVAT]
           ,[TrafficCausingCharge]
           ,[TrafficCausingChargeVAT]
           ,[InsertUserId]           
           ,[UpdateUserId])
	select	InvoiceDate, 
		BuildingRoomCodeId, 
		case					
			when Id is not null then LesseeId
			else 1 /* 초기값 */
		end as LesseeId,
		(
			(select isnull(sum(LineTotal),0) /* 청구서 총액 */
			from dbo.[Invoice]
			where InvoiceDate < @MaintenanceFeeDetailsDate
			and LesseeId = main.LesseeId)
			- 
			(select isnull(sum(DepositAmount),0) /* 입금액 */
			from dbo.[CashBook]
			where TransactionDate < @MaintenanceFeeDetailsDate
			and LesseeId = main.LesseeId
			and InOutgoings = 0
			and DelFlag = 0)			
			- 
			(select isnull(sum(LossAmount),0) /* 결손액 */
			from dbo.[CashBook]
			where TransactionDate < @MaintenanceFeeDetailsDate
			and LesseeId = main.LesseeId
			and InOutgoings = 2
			and DelFlag = 0)
		) as ReceivableAmount, 
		MonthlyRent, 
		MonthlyRentVAT,
		MaintenanceFee,
		MaintenanceFeeVAT,
		ElectricBill,
		ElectricBillVAT,
		WaterBill,
		RoadOccupancyFee,
		RoadOccupancyFeeVAT,
		TrafficCausingCharge,
		TrafficCausingChargeVAT,
		InsertUserId = 1,
		UpdateUserId = 1
	from dbo.[Invoice] main
	where main.InvoiceDate = @MaintenanceFeeDetailsDate 
	and Exists (select 1 from dbo.[BuildingRoomCode] 
				where Id = main.BuildingRoomCodeId 
				and BuildingCodeId = @BuildingCodeId
				and UseFlag = 1);
END
GO
/****** Object:  StoredProcedure [dbo].[spMaintenanceFeeDetails_Insert]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spMaintenanceFeeDetails_Insert]
	@MaintenanceFeeDetailsDate DATETIME,
	@BuildingRoomCodeId      INT,
	@LesseeId                INT,
	@ReceivableAmount        MONEY,
	@MonthlyRent             MONEY,
	@MonthlyRentVAT          MONEY,
	@MaintenanceFee          MONEY,
	@MaintenanceFeeVAT       MONEY,
	@ElectricBill            MONEY,
	@ElectricBillVAT         MONEY,
	@WaterBill               MONEY,
	@RoadOccupancyFee        MONEY,
	@RoadOccupancyFeeVAT     MONEY,
	@TrafficCausingCharge    MONEY,
	@TrafficCausingChargeVAT    MONEY,
	@InsertUserId int,
	@UpdateUserId int,
	@Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[MaintenanceFeeDetails]
                (MaintenanceFeeDetailsDate,
				BuildingRoomCodeId,
				LesseeId,
				ReceivableAmount,    
				MonthlyRent,
				MonthlyRentVAT,
				MaintenanceFee,
				MaintenanceFeeVAT,
				ElectricBill,
				ElectricBillVAT,
				WaterBill,
				RoadOccupancyFee,
				RoadOccupancyFeeVAT,
				TrafficCausingCharge,
				TrafficCausingChargeVAT,
                InsertUserId,
                UpdateUserId)
	    values
               (@MaintenanceFeeDetailsDate,
				@BuildingRoomCodeId,
				@LesseeId,
				@ReceivableAmount,    
				@MonthlyRent,
				@MonthlyRentVAT,
				@MaintenanceFee,
				@MaintenanceFeeVAT,
				@ElectricBill,
				@ElectricBillVAT,
				@WaterBill,
				@RoadOccupancyFee,
				@RoadOccupancyFeeVAT,
				@TrafficCausingCharge,
				@TrafficCausingChargeVAT,
               @InsertUserId,
               @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spMaintenanceFeeDetails_Update]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spMaintenanceFeeDetails_Update]
	@Id int,
	@MaintenanceFeeDetailsDate DATETIME,
	@BuildingRoomCodeId      INT,
	@LesseeId                INT,
	@ReceivableAmount        MONEY,
	@MonthlyRent             MONEY,
	@MonthlyRentVAT          MONEY,
	@MaintenanceFee          MONEY,
	@MaintenanceFeeVAT       MONEY,
	@ElectricBill            MONEY,
	@ElectricBillVAT         MONEY,
	@WaterBill               MONEY,
	@RoadOccupancyFee        MONEY,
	@RoadOccupancyFeeVAT     MONEY,
	@TrafficCausingCharge    MONEY,
	@TrafficCausingChargeVAT    MONEY,
	@UpdateUserId int
AS
BEGIN
    SET NOCOUNT ON

	update dbo.[MaintenanceFeeDetails]
	set
    MaintenanceFeeDetailsDate = @MaintenanceFeeDetailsDate,
	BuildingRoomCodeId = @BuildingRoomCodeId,
	LesseeId = @LesseeId,
	ReceivableAmount = @ReceivableAmount,    
	MonthlyRent = @MonthlyRent,
	MonthlyRentVAT = @MonthlyRentVAT,
	MaintenanceFee =@MaintenanceFee,
	MaintenanceFeeVAT = @MaintenanceFeeVAT,
	ElectricBill = @ElectricBill,
	ElectricBillVAT = @ElectricBillVAT,
	WaterBill = @WaterBill,
	RoadOccupancyFee = @RoadOccupancyFee,
	RoadOccupancyFeeVAT = @RoadOccupancyFeeVAT,
	TrafficCausingCharge = @TrafficCausingCharge,
	TrafficCausingChargeVAT = @TrafficCausingChargeVAT,
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spMaintenanceFeeDetailsSetting_GetByDate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spMaintenanceFeeDetailsSetting_GetByDate]
	@MaintenanceFeeDetailsDate datetime,
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[MaintenanceFeeDetailsSetting]
	where MaintenanceFeeDetailsDate = @MaintenanceFeeDetailsDate and BuildingCodeId = @BuildingCodeId;	
END
GO
/****** Object:  StoredProcedure [dbo].[spMaintenanceFeeDetailsSetting_InsertUpdate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spMaintenanceFeeDetailsSetting_InsertUpdate]
	@MaintenanceFeeDetailsDate DATETIME,
	@BuildingCodeId INT,		
	@ElectricBillTerm NVARCHAR(30),	
	@WaterBillTerm NVARCHAR(30),
	@RoadOccupancyFeeTerm NVARCHAR(30),	
	@TrafficCausingChargeTerm NVARCHAR(30),	
	@BankBookCodeId INT,
	@PaymentDueDate DATETIME,
	@BillIssueDate DATETIME,
	@InsertUserId int,
	@UpdateUserId int
AS
BEGIN
    SET NOCOUNT ON

	if Exists (select 1 
			from dbo.[MaintenanceFeeDetailsSetting] 
			where MaintenanceFeeDetailsDate = @MaintenanceFeeDetailsDate 
			and BuildingCodeId = @BuildingCodeId)

		update dbo.[MaintenanceFeeDetailsSetting]
		set
		MaintenanceFeeDetailsDate = @MaintenanceFeeDetailsDate,
		BuildingCodeId = @BuildingCodeId,
		ElectricBillTerm = @ElectricBillTerm,
		WaterBillTerm = @WaterBillTerm,
		RoadOccupancyFeeTerm = @RoadOccupancyFeeTerm,
		TrafficCausingChargeTerm = @TrafficCausingChargeTerm,
		BankBookCodeId = @BankBookCodeId,
		PaymentDueDate = @PaymentDueDate,
		BillIssueDate = @BillIssueDate,    
		UpdateUserId = @UpdateUserId,
		UpdateDate = getutcdate()
		where MaintenanceFeeDetailsDate = @MaintenanceFeeDetailsDate 
		and BuildingCodeId = @BuildingCodeId;
	else
		insert into dbo.[MaintenanceFeeDetailsSetting]
					(MaintenanceFeeDetailsDate,
					BuildingCodeId,				
					ElectricBillTerm,				
					WaterBillTerm,
					RoadOccupancyFeeTerm,
					TrafficCausingChargeTerm,
					BankBookCodeId,
					PaymentDueDate,
					BillIssueDate,
					InsertUserId,
					UpdateUserId)
			values
				   (@MaintenanceFeeDetailsDate,
				   @BuildingCodeId,
				   @ElectricBillTerm,				
				   @WaterBillTerm,
				   @RoadOccupancyFeeTerm,
				   @TrafficCausingChargeTerm,
				   @BankBookCodeId,
				   @PaymentDueDate,
				   @BillIssueDate,
				   @InsertUserId,
				   @UpdateUserId);
END
GO
/****** Object:  StoredProcedure [dbo].[spOutgoingsBook_GetsDisplayByFromToDate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spOutgoingsBook_GetsDisplayByFromToDate]
	@FromDate DateTime,
	@ToDate DateTime,
	@AccountCodeId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	select TransactionDate,
		'(' + bank.BankBookName + ') ' + cb.TransactionDetails as TransactionDetailsDisplay,
		Creditor, ExpenseNumber, WithdrawalAmount as OutgoingsAmount
	from dbo.[CashBook] cb 
	left join dbo.[BankBookCode] bank 
	  on cb.BankBookCodeId = bank.Id
	left join dbo.[Lessee] le
	  on cb.LesseeId = le.Id
	where TransactionDate >= @FromDate and TransactionDate <= @ToDate and AccountCodeId = @AccountCodeId and InOutgoings = 1 and DelFlag = 0
	order by TransactionDate;
END
GO
/****** Object:  StoredProcedure [dbo].[spOutgoingsBookTotal_GetsDisplayByFromToDate]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spOutgoingsBookTotal_GetsDisplayByFromToDate]
	@FromDate DateTime,
	@ToDate DateTime
AS
with Account as
(
	/*지출부 계정과목*/
	select account.Id as AccountCodeId, hang.AccountHangName, account.AccountName,
	InOutgoings, hang.DisplaySeq as DisplaySeq1, account.DisplaySeq as DisplaySeq2
	from dbo.[AccountHangCode] hang
	left join dbo.[AccountCode] account
	 on hang.Id = account.AccountHangCodeId
	where account.UseFlag = 1 and InOutgoings = 1
)
,
Budget
as
(
	/*예산액*/
	select AccountCodeId, BudgetAmount
	from dbo.[BudgetAmount] budget
	where FiscalYear = year(@FromDate)
	and Exists (select 1
		from dbo.[AccountCode] account
		inner join dbo.[AccountHangCode] hang
		  on account.AccountHangCodeId = hang.Id
		where account.Id = budget.AccountCodeId and hang.InOutgoings = 1)
)
,
Deposit
as
(
	/*지출액*/
	select AccountCodeId, sum(WithdrawalAmount) as OutgoingsAmount
	from dbo.[CashBook] cb
	where TransactionDate >= @FromDate 
	and TransactionDate <= @ToDate
	and DelFlag = 0
	and InOutgoings = 1 
	group by AccountCodeId
)

select AccountHangName, AccountName, BudgetAmount, OutgoingsAmount
from Account
left join Budget
 on Account.AccountCodeId = Budget.AccountCodeId
left join Deposit
 on Account.AccountCodeId = Deposit.AccountCodeId
order by Account.DisplaySeq1, account.DisplaySeq2;
GO
/****** Object:  StoredProcedure [dbo].[spUser_Delete]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	delete 
	from dbo.[User]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spUser_Exists]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUser_Exists]
	@UserName nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON

	if Exists (
		select 1
		from dbo.[User]
	where UserName = @UserName)

		select Exist =1;
	else
		select Exist = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[spUser_GetAll]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[User];
END
GO
/****** Object:  StoredProcedure [dbo].[spUser_GetById]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUser_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[User]
	where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spUser_GetByName]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUser_GetByName]
	@UserName nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON

	select *
	from dbo.[User]
	where UserName = @UserName;
END
GO
/****** Object:  StoredProcedure [dbo].[spUser_Insert]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUser_Insert]    
    @UserName nvarchar(20),
    @Password nvarchar(100),
    @GradeTypeId int,
    @UseFlag [dbo].[Flag],
    @InsertUserId int,	
	@UpdateUserId int,
    @Id int out
AS
BEGIN
    SET NOCOUNT ON

	insert into dbo.[User]
                (UserName,
                [Password],
                GradeTypeId,
                UseFlag,
                InsertUserId,
				UpdateUserId)
	    values
               (@UserName,
               @Password,
               @GradeTypeId,
               @UseFlag,
               @InsertUserId,
			   @UpdateUserId);

	set @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spUser_Update]    Script Date: 2023-12-21 오후 6:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@UserName nvarchar(20),
	@Password nvarchar(100),
	@GradeTypeId int,
	@UseFlag dbo.Flag,	
	@UpdateUserId int
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	update dbo.[User]
	set 
	UserName = @UserName,
	[Password] = @Password,
	GradeTypeId = @GradeTypeId,
	UseFlag = @UseFlag,	
	UpdateUserId = @UpdateUserId,
	UpdateDate = getutcdate()
	where Id = @Id;
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK, 계정과목 항 코드, 관/항/목중 항을 의미' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountCode', @level2type=N'COLUMN',@level2name=N'AccountHangCodeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'계정과목 목 명칭,  관/항/목중 목을 의미' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountCode', @level2type=N'COLUMN',@level2name=N'AccountName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'화면표시순서' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountCode', @level2type=N'COLUMN',@level2name=N'DisplaySeq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용여부, 1 = use, 0 = not use' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountCode', @level2type=N'COLUMN',@level2name=N'UseFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'계정과목코드(항/목중 목)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'수입/지출, 0 = 수입, 1 = 지출' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountHangCode', @level2type=N'COLUMN',@level2name=N'InOutgoings'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'계정과목의 항명칭' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountHangCode', @level2type=N'COLUMN',@level2name=N'AccountHangName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'화면표시순서' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountHangCode', @level2type=N'COLUMN',@level2name=N'DisplaySeq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용여부, 1 = use, 0 = not use' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountHangCode', @level2type=N'COLUMN',@level2name=N'UseFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountHangCode', @level2type=N'COLUMN',@level2name=N'InsertUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'계정과목의 항코드(항/목중 항)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountHangCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'통장명칭' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BankBookCode', @level2type=N'COLUMN',@level2name=N'BankBookName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'은행명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BankBookCode', @level2type=N'COLUMN',@level2name=N'BankName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'계좌번호' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BankBookCode', @level2type=N'COLUMN',@level2name=N'AccountNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'비고' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BankBookCode', @level2type=N'COLUMN',@level2name=N'Notes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'화면표시순서' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BankBookCode', @level2type=N'COLUMN',@level2name=N'DisplaySeq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용여부, 1 = use, 0 = not use' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BankBookCode', @level2type=N'COLUMN',@level2name=N'UseFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'통장코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BankBookCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'회계년도' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BudgetAmount', @level2type=N'COLUMN',@level2name=N'FiscalYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK, 계정과목코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BudgetAmount', @level2type=N'COLUMN',@level2name=N'AccountCodeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'예산액' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BudgetAmount', @level2type=N'COLUMN',@level2name=N'BudgetAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'예산액' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BudgetAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'건물명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuildingCode', @level2type=N'COLUMN',@level2name=N'BuildingName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'비고' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuildingCode', @level2type=N'COLUMN',@level2name=N'Notes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'화면표시순서' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuildingCode', @level2type=N'COLUMN',@level2name=N'DisplaySeq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용여부, 1 = use, 0 = not use' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuildingCode', @level2type=N'COLUMN',@level2name=N'UseFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'건물코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuildingCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK, 건물코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuildingRoomCode', @level2type=N'COLUMN',@level2name=N'BuildingCodeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'호실' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuildingRoomCode', @level2type=N'COLUMN',@level2name=N'Room'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'층' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuildingRoomCode', @level2type=N'COLUMN',@level2name=N'Floor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'면적' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuildingRoomCode', @level2type=N'COLUMN',@level2name=N'Area'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'비고' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuildingRoomCode', @level2type=N'COLUMN',@level2name=N'Notes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'화면표시순서' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuildingRoomCode', @level2type=N'COLUMN',@level2name=N'DisplaySeq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용여부, 1 = use, 0 = not use' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuildingRoomCode', @level2type=N'COLUMN',@level2name=N'UseFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'건물호실코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuildingRoomCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'거래일자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CashBook', @level2type=N'COLUMN',@level2name=N'TransactionDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'적요' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CashBook', @level2type=N'COLUMN',@level2name=N'TransactionDetails'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK, 통장코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CashBook', @level2type=N'COLUMN',@level2name=N'BankBookCodeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK, 임차인' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CashBook', @level2type=N'COLUMN',@level2name=N'LesseeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK, 계정과목코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CashBook', @level2type=N'COLUMN',@level2name=N'AccountCodeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'채주' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CashBook', @level2type=N'COLUMN',@level2name=N'Creditor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'지출번호' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CashBook', @level2type=N'COLUMN',@level2name=N'ExpenseNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'입금액' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CashBook', @level2type=N'COLUMN',@level2name=N'DepositAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'출금액' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CashBook', @level2type=N'COLUMN',@level2name=N'WithdrawalAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'결손액' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CashBook', @level2type=N'COLUMN',@level2name=N'LossAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'비고' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CashBook', @level2type=N'COLUMN',@level2name=N'Notes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'입금/출금, 0 = 입금(수입), 1 = 출금(지출), 2 = 결손액' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CashBook', @level2type=N'COLUMN',@level2name=N'InOutgoings'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'삭제여부, 1 = Delete, 0 = not Delete' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CashBook', @level2type=N'COLUMN',@level2name=N'DelFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'금전출납부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CashBook'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Config', @level2type=N'COLUMN',@level2name=N'OfficeTel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Config', @level2type=N'COLUMN',@level2name=N'OfficeEmail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'금전출납부 - 마지막 지출번호, 자동증가용' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Config', @level2type=N'COLUMN',@level2name=N'LastExpenseNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등급유형명칭' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GradeType', @level2type=N'COLUMN',@level2name=N'GradeTypeName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'화면표시순서' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GradeType', @level2type=N'COLUMN',@level2name=N'DisplaySeq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용여부, 1 = use, 0 = not use' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GradeType', @level2type=N'COLUMN',@level2name=N'UseFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용자 등급' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GradeType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'청구서 월분(년월만 사용,일은 01, 2023-02-01)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'InvoiceDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK, 호실' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'BuildingRoomCodeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK, 임차인' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'LesseeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'계산서발급일, Lessee에서 가져와서 저장' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'BillIssueDay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'월임대료' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'MonthlyRent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'월임대료 부가세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'MonthlyRentVAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'관리비' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'MaintenanceFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'관리비 부가세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'MaintenanceFeeVAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'전기세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'ElectricBill'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'전기세 부가세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'ElectricBillVAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'수도세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'WaterBill'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'도로점용료' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'RoadOccupancyFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'도로점용료 부가세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'RoadOccupancyFeeVAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'교통유발부담금' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'TrafficCausingCharge'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'교통유발부담금 부가세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'TrafficCausingChargeVAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'월임대료+관리비+전기세+수도세+도로점용료+교통유발부담금+각 부가세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'LineTotal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'청구서' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK, 임차인' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LeaseContract', @level2type=N'COLUMN',@level2name=N'LesseeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK, 건물세대코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LeaseContract', @level2type=N'COLUMN',@level2name=N'BuildingRoomCodeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'계약기간' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LeaseContract', @level2type=N'COLUMN',@level2name=N'ContractStartDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'계약기간' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LeaseContract', @level2type=N'COLUMN',@level2name=N'ContractEndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'보증금' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LeaseContract', @level2type=N'COLUMN',@level2name=N'Deposit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'월임대료' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LeaseContract', @level2type=N'COLUMN',@level2name=N'MonthlyRent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'월임대료 부가세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LeaseContract', @level2type=N'COLUMN',@level2name=N'MonthlyRentVAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'월임대료 합계' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LeaseContract', @level2type=N'COLUMN',@level2name=N'MonthlyRentTotal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'관리비' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LeaseContract', @level2type=N'COLUMN',@level2name=N'MaintenanceFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'관리비 부가세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LeaseContract', @level2type=N'COLUMN',@level2name=N'MaintenanceFeeVAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'관리비 합계' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LeaseContract', @level2type=N'COLUMN',@level2name=N'MaintenanceFeeTotal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'비고' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LeaseContract', @level2type=N'COLUMN',@level2name=N'Notes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LeaseContract', @level2type=N'COLUMN',@level2name=N'InsertUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'임대차 계약' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LeaseContract'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'임차인' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lessee', @level2type=N'COLUMN',@level2name=N'Lessee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'대표자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lessee', @level2type=N'COLUMN',@level2name=N'Owner'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'주민번호' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lessee', @level2type=N'COLUMN',@level2name=N'RRN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사업자등록번호' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lessee', @level2type=N'COLUMN',@level2name=N'BRN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'연락처' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lessee', @level2type=N'COLUMN',@level2name=N'Contact'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 = 계약중, 0 = 계약종료' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lessee', @level2type=N'COLUMN',@level2name=N'UnderContractFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'계산서발급일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lessee', @level2type=N'COLUMN',@level2name=N'BillIssueDay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'비고' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lessee', @level2type=N'COLUMN',@level2name=N'Notes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'임차인(거래처)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lessee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'관리비명세서 월분(년월만 사용,일은 01, 2023-02-01)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetails', @level2type=N'COLUMN',@level2name=N'MaintenanceFeeDetailsDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK, 호실' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetails', @level2type=N'COLUMN',@level2name=N'BuildingRoomCodeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK, 임차인' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetails', @level2type=N'COLUMN',@level2name=N'LesseeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'월임대료' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetails', @level2type=N'COLUMN',@level2name=N'MonthlyRent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'월임대료 부가세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetails', @level2type=N'COLUMN',@level2name=N'MonthlyRentVAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'관리비' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetails', @level2type=N'COLUMN',@level2name=N'MaintenanceFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'관리비 부가세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetails', @level2type=N'COLUMN',@level2name=N'MaintenanceFeeVAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'전기세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetails', @level2type=N'COLUMN',@level2name=N'ElectricBill'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'전기세 부가세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetails', @level2type=N'COLUMN',@level2name=N'ElectricBillVAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'수도세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetails', @level2type=N'COLUMN',@level2name=N'WaterBill'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'도로점용료' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetails', @level2type=N'COLUMN',@level2name=N'RoadOccupancyFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'도로점용료 부가세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetails', @level2type=N'COLUMN',@level2name=N'RoadOccupancyFeeVAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'교통유발부담금' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetails', @level2type=N'COLUMN',@level2name=N'TrafficCausingCharge'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'교통유발부담금 부가세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetails', @level2type=N'COLUMN',@level2name=N'TrafficCausingChargeVAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'월임대료+관리비+전기세+수도세+도로점용료+교통유발부담금+각 부가세' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetails', @level2type=N'COLUMN',@level2name=N'LineTotal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'관리비 명세서' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetails'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'관리비명세서 월분(년월만 사용,일은 01, 2023-02-01)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetailsSetting', @level2type=N'COLUMN',@level2name=N'MaintenanceFeeDetailsDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK, 건물코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetailsSetting', @level2type=N'COLUMN',@level2name=N'BuildingCodeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'전기세 기간' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetailsSetting', @level2type=N'COLUMN',@level2name=N'ElectricBillTerm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'수도세 기간' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetailsSetting', @level2type=N'COLUMN',@level2name=N'WaterBillTerm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'도로점용료 기간' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetailsSetting', @level2type=N'COLUMN',@level2name=N'RoadOccupancyFeeTerm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'교통유발부담금 기간' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetailsSetting', @level2type=N'COLUMN',@level2name=N'TrafficCausingChargeTerm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK, 통장코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetailsSetting', @level2type=N'COLUMN',@level2name=N'BankBookCodeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'납부기한' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetailsSetting', @level2type=N'COLUMN',@level2name=N'PaymentDueDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'발행일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetailsSetting', @level2type=N'COLUMN',@level2name=N'BillIssueDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'관리비명세서셋팅' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaintenanceFeeDetailsSetting'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'비밀번호' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1=관리자, 2=사용자, 사용자 등급' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'GradeTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 = use, 0 = not use' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'UseFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User'
GO
USE [master]
GO
ALTER DATABASE [BuildingLease] SET  READ_WRITE 
GO
