USE [SERVOSASAIR]
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica1'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica1', @level2type=N'COLUMN',@level2name=N'FechaLimite'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica1', @level2type=N'COLUMN',@level2name=N'Encargado'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'DocumentosSunat'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'DocumentosSunat', @level2type=N'COLUMN',@level2name=N'FechaPago'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'DocumentosSunat', @level2type=N'COLUMN',@level2name=N'MontoaPagar'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'DocumentosSunat', @level2type=N'COLUMN',@level2name=N'Encargado'

GO
/****** Object:  StoredProcedure [dbo].[tmp_DoSomethingWithEmployees]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[tmp_DoSomethingWithEmployees]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIU]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_VEHIU]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIS_UnReg]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_VEHIS_UnReg]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIS_TableData]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_VEHIS_TableData]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIS_Filtrado]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_VEHIS_Filtrado]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIS_Datos]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_VEHIS_Datos]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIS]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_VEHIS]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHII]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_VEHII]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHID]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_VEHID]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEALU]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_VEALU]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEALS_TodosNoEnviados]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_VEALS_TodosNoEnviados]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEALI]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_VEALI]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_UpdateDataToTable]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_UpdateDataToTable]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_TYPES_AllByTable]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_TYPES_AllByTable]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_SELECTTABLES]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_SELECTTABLES]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERU]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_OPERU]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERS_UnReg]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_OPERS_UnReg]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERS_Filtrado]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_OPERS_Filtrado]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERS_Datos]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_OPERS_Datos]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERS]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_OPERS]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERI]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_OPERI]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERD]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_OPERD]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_LISTTABLESANDCOLUMNS]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_LISTTABLESANDCOLUMNS]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_InsertDataToTable]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_InsertDataToTable]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_DROPCOLUMNTABLE]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_DROPCOLUMNTABLE]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_CREATETABLE]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_CREATETABLE]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_ALLTABLESREFERENCINGVEHICLES]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_ALLTABLESREFERENCINGVEHICLES]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_ADDCOLUMNTABLE]    Script Date: 5/18/2016 08:18:43 ******/
DROP PROCEDURE [dbo].[SAIR_ADDCOLUMNTABLE]
GO
ALTER TABLE [vehiclevars].[RevisionTecnica1] DROP CONSTRAINT [RevisionTecnica1_VEHI_FK]
GO
ALTER TABLE [vehiclevars].[DocumentosSunat] DROP CONSTRAINT [DocumentosSunat_VEHI_FK]
GO
ALTER TABLE [dbo].[SAIR_VehicleAlerts] DROP CONSTRAINT [SAIR_VEAL_FK_SAIR_VEHI]
GO
ALTER TABLE [dbo].[SAIR_VEHICLE] DROP CONSTRAINT [SAIR_VEHIFK_TYPESTATE]
GO
ALTER TABLE [dbo].[SAIR_VEHICLE] DROP CONSTRAINT [SAIR_VEHIFK_TYPE]
GO
ALTER TABLE [dbo].[SAIR_OPERARIOS] DROP CONSTRAINT [FK__SAIR_OPER__VEHI___182C9B23]
GO
/****** Object:  Table [vehiclevars].[RevisionTecnica1]    Script Date: 5/18/2016 08:18:43 ******/
DROP TABLE [vehiclevars].[RevisionTecnica1]
GO
/****** Object:  Table [vehiclevars].[DocumentosSunat]    Script Date: 5/18/2016 08:18:43 ******/
DROP TABLE [vehiclevars].[DocumentosSunat]
GO
/****** Object:  Table [dbo].[SAIR_VehicleAlerts]    Script Date: 5/18/2016 08:18:43 ******/
DROP TABLE [dbo].[SAIR_VehicleAlerts]
GO
/****** Object:  Table [dbo].[SAIR_VEHICLE]    Script Date: 5/18/2016 08:18:43 ******/
DROP TABLE [dbo].[SAIR_VEHICLE]
GO
/****** Object:  Table [dbo].[SAIR_TYPES]    Script Date: 5/18/2016 08:18:43 ******/
DROP TABLE [dbo].[SAIR_TYPES]
GO
/****** Object:  Table [dbo].[SAIR_OPERARIOS]    Script Date: 5/18/2016 08:18:43 ******/
DROP TABLE [dbo].[SAIR_OPERARIOS]
GO
/****** Object:  UserDefinedFunction [dbo].[SAIR_RemoveNonAlphaCharacters]    Script Date: 5/18/2016 08:18:43 ******/
DROP FUNCTION [dbo].[SAIR_RemoveNonAlphaCharacters]
GO
/****** Object:  UserDefinedFunction [dbo].[SAIR_RemoveAccentsAndNormalizeTest]    Script Date: 5/18/2016 08:18:43 ******/
DROP FUNCTION [dbo].[SAIR_RemoveAccentsAndNormalizeTest]
GO
/****** Object:  UserDefinedTableType [vehiclevars].[ValuesList]    Script Date: 5/18/2016 08:18:43 ******/
DROP TYPE [vehiclevars].[ValuesList]
GO
/****** Object:  UserDefinedTableType [vehiclevars].[ColumnValueDictionary]    Script Date: 5/18/2016 08:18:43 ******/
DROP TYPE [vehiclevars].[ColumnValueDictionary]
GO
/****** Object:  UserDefinedTableType [vehiclevars].[ColumnList]    Script Date: 5/18/2016 08:18:43 ******/
DROP TYPE [vehiclevars].[ColumnList]
GO
/****** Object:  UserDefinedTableType [dbo].[tmp_EmployeeList]    Script Date: 5/18/2016 08:18:43 ******/
DROP TYPE [dbo].[tmp_EmployeeList]
GO
USE [SERVOSASAIR]
GO
/****** Object:  Sequence [dbo].[SAIR_VALUESFORVEHICLEITEM]    Script Date: 5/18/2016 08:18:43 ******/
DROP SEQUENCE [dbo].[SAIR_VALUESFORVEHICLEITEM]
GO
/****** Object:  Schema [vehiclevars]    Script Date: 5/18/2016 08:18:43 ******/
DROP SCHEMA [vehiclevars]
GO
USE [master]
GO
/****** Object:  Database [SERVOSASAIR]    Script Date: 5/18/2016 08:18:43 ******/
DROP DATABASE [SERVOSASAIR]
GO
/****** Object:  Database [SERVOSASAIR]    Script Date: 5/18/2016 08:18:43 ******/
CREATE DATABASE [SERVOSASAIR]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SERVOSASAIR', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SERVOSASAIR.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SERVOSASAIR_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SERVOSASAIR_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SERVOSASAIR] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SERVOSASAIR].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SERVOSASAIR] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET ARITHABORT OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SERVOSASAIR] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SERVOSASAIR] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SERVOSASAIR] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SERVOSASAIR] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SERVOSASAIR] SET  MULTI_USER 
GO
ALTER DATABASE [SERVOSASAIR] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SERVOSASAIR] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SERVOSASAIR] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SERVOSASAIR] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SERVOSASAIR] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SERVOSASAIR]
GO
/****** Object:  Schema [vehiclevars]    Script Date: 5/18/2016 08:18:43 ******/
CREATE SCHEMA [vehiclevars]
GO
USE [SERVOSASAIR]
GO
/****** Object:  Sequence [dbo].[SAIR_VALUESFORVEHICLEITEM]    Script Date: 5/18/2016 08:18:43 ******/
CREATE SEQUENCE [dbo].[SAIR_VALUESFORVEHICLEITEM] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -9223372036854775808
 MAXVALUE 9223372036854775807
 CACHE 
GO
/****** Object:  UserDefinedTableType [dbo].[tmp_EmployeeList]    Script Date: 5/18/2016 08:18:43 ******/
CREATE TYPE [dbo].[tmp_EmployeeList] AS TABLE(
	[EmployeeID] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [vehiclevars].[ColumnList]    Script Date: 5/18/2016 08:18:43 ******/
CREATE TYPE [vehiclevars].[ColumnList] AS TABLE(
	[ColumnName] [nvarchar](80) NULL
)
GO
/****** Object:  UserDefinedTableType [vehiclevars].[ColumnValueDictionary]    Script Date: 5/18/2016 08:18:43 ******/
CREATE TYPE [vehiclevars].[ColumnValueDictionary] AS TABLE(
	[ColumnaName] [nvarchar](80) NULL,
	[ColumnValue] [nvarchar](80) NULL
)
GO
/****** Object:  UserDefinedTableType [vehiclevars].[ValuesList]    Script Date: 5/18/2016 08:18:43 ******/
CREATE TYPE [vehiclevars].[ValuesList] AS TABLE(
	[ColumnValue] [nvarchar](80) NULL
)
GO
/****** Object:  UserDefinedFunction [dbo].[SAIR_RemoveAccentsAndNormalizeTest]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SAIR_RemoveAccentsAndNormalizeTest]
(@textToReplace varChar(1000))
	RETURNS varChar(1000)
AS
BEGIN
	select @textToReplace = REPLACE(LTRIM(RTRIM(@textToReplace)), ' ', '') collate SQL_Latin1_General_Cp1251_CS_AS
	RETURN @textToReplace
END
GO
/****** Object:  UserDefinedFunction [dbo].[SAIR_RemoveNonAlphaCharacters]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SAIR_RemoveNonAlphaCharacters](@textToReplace VarChar(1000))
RETURNS VarChar(1000)
AS
BEGIN

    DECLARE @KeepValues as varchar(50)
    SET @KeepValues = '%[^a-zA-Z0-9]%'
    While PatIndex(@KeepValues, @textToReplace) > 0
        Set @textToReplace = Stuff(@textToReplace, PatIndex(@KeepValues, @textToReplace), 1, '')

    Return @textToReplace
END
GO
/****** Object:  Table [dbo].[SAIR_OPERARIOS]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SAIR_OPERARIOS](
	[OPER_Id] [int] IDENTITY(1,1) NOT NULL,
	[OPER_cApellidoPaterno] [nvarchar](40) NULL,
	[OPER_cApellidoMaterno] [nvarchar](40) NULL,
	[OPER_cNombre] [nvarchar](40) NULL,
	[OPER_cCorreo] [nvarchar](60) NULL,
	[VEHI_Id] [int] NULL,
	[PUES_Id] [int] NULL,
 CONSTRAINT [PK__SAIR_OPE__738AC7A6B290B23D] PRIMARY KEY CLUSTERED 
(
	[OPER_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SAIR_TYPES]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SAIR_TYPES](
	[TYPE_cCodTable] [nvarchar](4) NOT NULL,
	[TYPE_cCodType] [nvarchar](4) NOT NULL,
	[TYPE_cDescription] [nvarchar](80) NULL,
	[TYPE_cNotes] [nvarchar](200) NULL,
 CONSTRAINT [SAIR_TYPE_PK] PRIMARY KEY CLUSTERED 
(
	[TYPE_cCodTable] ASC,
	[TYPE_cCodType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SAIR_VEHICLE]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SAIR_VEHICLE](
	[Item] [int] NOT NULL CONSTRAINT [SAIR_VEHIDF_ItemValores]  DEFAULT (NEXT VALUE FOR [SAIR_VALUESFORVEHICLEITEM]),
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[PlacaTracto] [nvarchar](30) NULL,
	[PlacaTolva] [nvarchar](30) NULL,
	[CodigoMarca] [int] NULL,
	[CodigoEstado] [int] NULL,
	[TYPE_cTABBRND] [nvarchar](4) NULL,
	[TYPE_cCODBRND] [nvarchar](4) NULL,
	[TYPE_cTABVSTA] [nvarchar](4) NULL,
	[TYPE_cCODVSTA] [nvarchar](4) NULL,
 CONSTRAINT [SAIR_VEHIPK] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SAIR_VehicleAlerts]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SAIR_VehicleAlerts](
	[VEAL_Id] [int] IDENTITY(1,1) NOT NULL,
	[VEAL_TableName] [nvarchar](80) NULL,
	[VEAL_DaysToAlert] [int] NOT NULL,
	[VEAL_DateToAlert] [datetime] NULL,
	[VEAL_AlertName] [nvarchar](80) NULL,
	[VEAL_AlertSended] [bit] NULL,
	[VEHI_ID] [int] NOT NULL,
	[VEAL_TokenSMS] [nvarchar](80) NULL,
	[VEAL_SendDate] [datetime] NULL,
	[VEAL_Recipients] [nvarchar](max) NULL,
 CONSTRAINT [SAIR_VEAL_PK] PRIMARY KEY CLUSTERED 
(
	[VEAL_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [vehiclevars].[DocumentosSunat]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [vehiclevars].[DocumentosSunat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SAIR_VEHIID] [int] NOT NULL,
	[DiasAlerta] [int] NULL,
	[RutaDocumento] [nvarchar](800) NULL,
	[Encargado] [nvarchar](240) NULL,
	[MontoaPagar] [int] NULL,
	[FechaPago] [datetime] NULL,
 CONSTRAINT [DocumentosSunatPK] PRIMARY KEY CLUSTERED 
(
	[SAIR_VEHIID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [vehiclevars].[RevisionTecnica1]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [vehiclevars].[RevisionTecnica1](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SAIR_VEHIID] [int] NOT NULL,
	[DiasAlerta] [int] NULL,
	[RutaDocumento] [nvarchar](800) NULL,
	[Encargado] [nvarchar](240) NULL,
	[FechaLimite] [datetime] NULL,
 CONSTRAINT [RevisionTecnica1PK] PRIMARY KEY CLUSTERED 
(
	[SAIR_VEHIID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[SAIR_OPERARIOS] ON 

INSERT [dbo].[SAIR_OPERARIOS] ([OPER_Id], [OPER_cApellidoPaterno], [OPER_cApellidoMaterno], [OPER_cNombre], [OPER_cCorreo], [VEHI_Id], [PUES_Id]) VALUES (1, N'ahhhh', N'ahhhh', N'cccccss', NULL, 1, 0)
INSERT [dbo].[SAIR_OPERARIOS] ([OPER_Id], [OPER_cApellidoPaterno], [OPER_cApellidoMaterno], [OPER_cNombre], [OPER_cCorreo], [VEHI_Id], [PUES_Id]) VALUES (2, N'VIllanueva', N'Rodriguez', N'Rosario', NULL, 6, 0)
SET IDENTITY_INSERT [dbo].[SAIR_OPERARIOS] OFF
INSERT [dbo].[SAIR_TYPES] ([TYPE_cCodTable], [TYPE_cCodType], [TYPE_cDescription], [TYPE_cNotes]) VALUES (N'BRND', N'001', N'Toyota', N'')
INSERT [dbo].[SAIR_TYPES] ([TYPE_cCodTable], [TYPE_cCodType], [TYPE_cDescription], [TYPE_cNotes]) VALUES (N'BRND', N'002', N'Hyundai', N'')
INSERT [dbo].[SAIR_TYPES] ([TYPE_cCodTable], [TYPE_cCodType], [TYPE_cDescription], [TYPE_cNotes]) VALUES (N'BRND', N'003', N'Mercedes Benz', N'')
INSERT [dbo].[SAIR_TYPES] ([TYPE_cCodTable], [TYPE_cCodType], [TYPE_cDescription], [TYPE_cNotes]) VALUES (N'VSTA', N'001', N'Observado', N'')
INSERT [dbo].[SAIR_TYPES] ([TYPE_cCodTable], [TYPE_cCodType], [TYPE_cDescription], [TYPE_cNotes]) VALUES (N'VSTA', N'002', N'Revisar', N'')
INSERT [dbo].[SAIR_TYPES] ([TYPE_cCodTable], [TYPE_cCodType], [TYPE_cDescription], [TYPE_cNotes]) VALUES (N'VSTA', N'003', N'Conforme', N'')
SET IDENTITY_INSERT [dbo].[SAIR_VEHICLE] ON 

INSERT [dbo].[SAIR_VEHICLE] ([Item], [Codigo], [PlacaTracto], [PlacaTolva], [CodigoMarca], [CodigoEstado], [TYPE_cTABBRND], [TYPE_cCODBRND], [TYPE_cTABVSTA], [TYPE_cCODVSTA]) VALUES (1, 1, N'CM-546', N'VPM-654', 0, 1, N'BRND', N'002', N'VSTA', N'002')
INSERT [dbo].[SAIR_VEHICLE] ([Item], [Codigo], [PlacaTracto], [PlacaTolva], [CodigoMarca], [CodigoEstado], [TYPE_cTABBRND], [TYPE_cCODBRND], [TYPE_cTABVSTA], [TYPE_cCODVSTA]) VALUES (2, 2, N'ABC-562', N'TRB-952', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[SAIR_VEHICLE] ([Item], [Codigo], [PlacaTracto], [PlacaTolva], [CodigoMarca], [CodigoEstado], [TYPE_cTABBRND], [TYPE_cCODBRND], [TYPE_cTABVSTA], [TYPE_cCODVSTA]) VALUES (4, 4, N'MNG-9865', N'AAA--366', 0, 2, NULL, NULL, NULL, NULL)
INSERT [dbo].[SAIR_VEHICLE] ([Item], [Codigo], [PlacaTracto], [PlacaTolva], [CodigoMarca], [CodigoEstado], [TYPE_cTABBRND], [TYPE_cCODBRND], [TYPE_cTABVSTA], [TYPE_cCODVSTA]) VALUES (5, 5, N'jajajaja', N'jojojojo', 2, 2, NULL, NULL, NULL, NULL)
INSERT [dbo].[SAIR_VEHICLE] ([Item], [Codigo], [PlacaTracto], [PlacaTolva], [CodigoMarca], [CodigoEstado], [TYPE_cTABBRND], [TYPE_cCODBRND], [TYPE_cTABVSTA], [TYPE_cCODVSTA]) VALUES (6, 6, N'AAAA-b54', N'NNNN-43', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[SAIR_VEHICLE] ([Item], [Codigo], [PlacaTracto], [PlacaTolva], [CodigoMarca], [CodigoEstado], [TYPE_cTABBRND], [TYPE_cCODBRND], [TYPE_cTABVSTA], [TYPE_cCODVSTA]) VALUES (57, 8, N'NAH-343', N'TEG-436', NULL, NULL, N'BRND', N'003', N'VSTA', N'003')
SET IDENTITY_INSERT [dbo].[SAIR_VEHICLE] OFF
SET IDENTITY_INSERT [dbo].[SAIR_VehicleAlerts] ON 

INSERT [dbo].[SAIR_VehicleAlerts] ([VEAL_Id], [VEAL_TableName], [VEAL_DaysToAlert], [VEAL_DateToAlert], [VEAL_AlertName], [VEAL_AlertSended], [VEHI_ID], [VEAL_TokenSMS], [VEAL_SendDate], [VEAL_Recipients]) VALUES (2, N'DocumentosSunat', 6, CAST(N'2016-05-21 00:00:00.000' AS DateTime), N'FechaPago', 1, 4, N'TMPTEST', CAST(N'2016-05-15 11:11:10.167' AS DateTime), N'51950313361')
INSERT [dbo].[SAIR_VehicleAlerts] ([VEAL_Id], [VEAL_TableName], [VEAL_DaysToAlert], [VEAL_DateToAlert], [VEAL_AlertName], [VEAL_AlertSended], [VEHI_ID], [VEAL_TokenSMS], [VEAL_SendDate], [VEAL_Recipients]) VALUES (3, N'DocumentosSunat', 3, CAST(N'2016-05-16 00:00:00.000' AS DateTime), N'FechaPago', 1, 5, N'1559519122217160976', NULL, NULL)
SET IDENTITY_INSERT [dbo].[SAIR_VehicleAlerts] OFF
SET IDENTITY_INSERT [vehiclevars].[DocumentosSunat] ON 

INSERT [vehiclevars].[DocumentosSunat] ([id], [SAIR_VEHIID], [DiasAlerta], [RutaDocumento], [Encargado], [MontoaPagar], [FechaPago]) VALUES (4, 4, 6, NULL, N'Marilyn Escobedo', 1234, CAST(N'2016-05-21 00:00:00.000' AS DateTime))
INSERT [vehiclevars].[DocumentosSunat] ([id], [SAIR_VEHIID], [DiasAlerta], [RutaDocumento], [Encargado], [MontoaPagar], [FechaPago]) VALUES (5, 5, 3, NULL, N'Yesbella Gutierrez', 563, CAST(N'2016-05-16 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [vehiclevars].[DocumentosSunat] OFF
ALTER TABLE [dbo].[SAIR_OPERARIOS]  WITH CHECK ADD  CONSTRAINT [FK__SAIR_OPER__VEHI___182C9B23] FOREIGN KEY([VEHI_Id])
REFERENCES [dbo].[SAIR_VEHICLE] ([Codigo])
GO
ALTER TABLE [dbo].[SAIR_OPERARIOS] CHECK CONSTRAINT [FK__SAIR_OPER__VEHI___182C9B23]
GO
ALTER TABLE [dbo].[SAIR_VEHICLE]  WITH CHECK ADD  CONSTRAINT [SAIR_VEHIFK_TYPE] FOREIGN KEY([TYPE_cTABBRND], [TYPE_cCODBRND])
REFERENCES [dbo].[SAIR_TYPES] ([TYPE_cCodTable], [TYPE_cCodType])
GO
ALTER TABLE [dbo].[SAIR_VEHICLE] CHECK CONSTRAINT [SAIR_VEHIFK_TYPE]
GO
ALTER TABLE [dbo].[SAIR_VEHICLE]  WITH CHECK ADD  CONSTRAINT [SAIR_VEHIFK_TYPESTATE] FOREIGN KEY([TYPE_cTABVSTA], [TYPE_cCODVSTA])
REFERENCES [dbo].[SAIR_TYPES] ([TYPE_cCodTable], [TYPE_cCodType])
GO
ALTER TABLE [dbo].[SAIR_VEHICLE] CHECK CONSTRAINT [SAIR_VEHIFK_TYPESTATE]
GO
ALTER TABLE [dbo].[SAIR_VehicleAlerts]  WITH CHECK ADD  CONSTRAINT [SAIR_VEAL_FK_SAIR_VEHI] FOREIGN KEY([VEHI_ID])
REFERENCES [dbo].[SAIR_VEHICLE] ([Codigo])
GO
ALTER TABLE [dbo].[SAIR_VehicleAlerts] CHECK CONSTRAINT [SAIR_VEAL_FK_SAIR_VEHI]
GO
ALTER TABLE [vehiclevars].[DocumentosSunat]  WITH CHECK ADD  CONSTRAINT [DocumentosSunat_VEHI_FK] FOREIGN KEY([SAIR_VEHIID])
REFERENCES [dbo].[SAIR_VEHICLE] ([Codigo])
GO
ALTER TABLE [vehiclevars].[DocumentosSunat] CHECK CONSTRAINT [DocumentosSunat_VEHI_FK]
GO
ALTER TABLE [vehiclevars].[RevisionTecnica1]  WITH CHECK ADD  CONSTRAINT [RevisionTecnica1_VEHI_FK] FOREIGN KEY([SAIR_VEHIID])
REFERENCES [dbo].[SAIR_VEHICLE] ([Codigo])
GO
ALTER TABLE [vehiclevars].[RevisionTecnica1] CHECK CONSTRAINT [RevisionTecnica1_VEHI_FK]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_ADDCOLUMNTABLE]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_ADDCOLUMNTABLE]
(
    @normalizedTableName nvarchar(200),
    @columnName nvarchar(200),
    @columnType nvarchar(50),
    @normalizedColumnName  nvarchar(200) output
)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);
    set @normalizedColumnName = dbo.SAIR_RemoveAccentsAndNormalizeTest(@columnName)
    SELECT @sql = 'alter table vehiclevars.' + QUOTENAME(@normalizedTableName) + ' add ' + QUOTENAME(@normalizedColumnName) + ' ' + @columnType
    PRINT @sql
    EXEC sp_executesql @sql

    EXEC sys.sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = @columnName, 
    @level0type = N'SCHEMA', @level0name = 'vehiclevars', 
    @level1type = N'TABLE',  @level1name = @normalizedTableName,
    @level2type = N'COLUMN',  @level2name = @normalizedColumnName;


END;
GO
/****** Object:  StoredProcedure [dbo].[SAIR_ALLTABLESREFERENCINGVEHICLES]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_ALLTABLESREFERENCINGVEHICLES]
AS
BEGIN
	select cast(f.name as varchar(255)) as foreign_key_name
	, cast(c.name as varchar(255)) as foreign_table
	, cast(fc.name as varchar(255)) as foreign_column
	, cast(p.name as varchar(255)) as parent_table
	, cast(rc.name as varchar(255)) as parent_column
	from  sysobjects f
	inner join sysobjects c on f.parent_obj = c.id
	inner join sysreferences r on f.id = r.constid
	inner join sysobjects p on r.rkeyid = p.id
	inner join syscolumns rc on r.rkeyid = rc.id and r.rkey1 = rc.colid
	inner join syscolumns fc on r.fkeyid = fc.id and r.fkey1 = fc.colid
	where f.type = 'F' AND p.name = 'SAIR_VEHICLE' AND fc.name = 'SAIR_VEHIID'
END

GO
/****** Object:  StoredProcedure [dbo].[SAIR_CREATETABLE]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_CREATETABLE]
(
    @newTableName NVARCHAR(200),
    @tableNormalizedName NVARCHAR(200) OUT,
	@objectId INT OUT
)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX)
    SET @tableNormalizedName = dbo.SAIR_RemoveAccentsAndNormalizeTest(@newTableName)
    SELECT @sql = 'create table vehiclevars.' + QUOTENAME(@tableNormalizedName) + '(id int identity(1,1), SAIR_VEHIID int not null, DiasAlerta int null, RutaDocumento nvarchar(800))'
    PRINT @sql

    EXEC sp_executesql @sql

    PRINT 'EL antiguo nombre es: ' + @newTableName

    EXEC sys.sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = @newTableName, 
    @level0type = N'SCHEMA', @level0name = 'vehiclevars', 
    @level1type = N'TABLE',  @level1name = @tableNormalizedName;

    declare @foreignKeySQL NVARCHAR(MAX)

    SELECT @foreignKeySQL = 'alter table [vehiclevars].' + QUOTENAME(@tableNormalizedName) + ' add constraint ' + @tableNormalizedName
        + '_VEHI_FK foreign key (SAIR_VEHIID) REFERENCES dbo.SAIR_VEHICLE(Codigo)';
    PRINT @foreignKeySQL;
    EXEC sp_executesql @foreignKeySQL

    declare @primaryKeySQL NVARCHAR(MAX)

    SELECT @primaryKeySQL = 'alter table [vehiclevars].' + QUOTENAME(@tableNormalizedName) + ' add constraint ' + @tableNormalizedName
        + 'PK primary key(SAIR_VEHIID)';
    PRINT @primaryKeySQL;

    EXEC sp_executesql @primaryKeySQL;

	SELECT @objectId = OBJECT_ID('vehiclevars.' + @tableNormalizedName)

END
GO
/****** Object:  StoredProcedure [dbo].[SAIR_DROPCOLUMNTABLE]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_DROPCOLUMNTABLE]
(
    @tableName nvarchar(200),
    @columnName nvarchar(200)
)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);
    -- SET @columnName = dbo.SAIR_RemoveAccentsAndNormalizeTest(@columnName)
    SELECT @sql = 'alter table vehiclevars.' + QUOTENAME(@tableName) + ' drop COLUMN' + QUOTENAME(@columnName) + ' '
    PRINT @sql
    EXEC sp_executesql @sql
END;
GO
/****** Object:  StoredProcedure [dbo].[SAIR_InsertDataToTable]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_InsertDataToTable]
	@columnsDeclaration AS vehiclevars.ColumnList READONLY,
	@columnsValues AS vehiclevars.ValuesList READONLY,
	@tableName AS NVARCHAR(80)
AS
BEGIN
	DECLARE @columnsPrepared NVARCHAR(MAX);
	SELECT @columnsPrepared = COALESCE(@columnsPrepared + ',', '') + ColumnName
	FROM @columnsDeclaration;
	DECLARE @valuesPrepared NVARCHAR(MAX);
	SELECT @valuesPrepared = COALESCE(@valuesPrepared + ',', '') + ColumnValue FROM
	@columnsValues

	DECLARE @sqlQuery NVARCHAR(MAX);
	SELECT @sqlQuery = 'INSERT INTO [vehiclevars].' + QUOTENAME(@tableName) +
	'(' + @columnsPrepared + ') VALUES ('
	+ @valuesPrepared + ')';
	SELECT @sqlQuery;
	EXEC sp_executesql @sqlQuery;
END
GO
/****** Object:  StoredProcedure [dbo].[SAIR_LISTTABLESANDCOLUMNS]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_LISTTABLESANDCOLUMNS]
	@schemaName nvarchar(40)
AS
BEGIN
	SELECT TAB.object_id TableObjectId, TAB.name TableNormalizedName, EPT.value TableName, TAB.schema_id SchemaId, SCH.name SchemaName
	, COL.name ColumnNormalizedName, EPC.value ColumnName , COL.user_type_id UserType , COL.system_type_id SystemType, TYP.name TypeName
	FROM sys.tables TAB
	LEFT JOIN sys.schemas SCH
	ON TAB.schema_id = SCH.schema_id
	LEFT JOIN sys.extended_properties EPT
	ON TAB.object_id = EPT.major_id AND EPT.minor_id = 0
	LEFT JOIN sys.columns COL
	ON TAB.object_id = COl.object_id
	LEFT JOIN sys.extended_properties EPC
	ON COl.object_id = EPC.major_id AND col.column_id = EPC.minor_id
	LEFT JOIN sys.types TYP
	ON TYP.system_type_id = COL.system_type_id AND TYP.user_type_id = COL.user_type_id
	WHERE SCH.name = @schemaName;
END
GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERD]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_OPERD]
	@OPER_Id [int]
WITH EXECUTE AS CALLER
AS
BEGIN
	delete from SAIR_OPERARIOS
		where OPER_Id = @OPER_Id;
END


GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERI]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[SAIR_OPERI]
 @OPER_cApellidoPaterno [nvarchar](40),
 @OPER_cApellidoMaterno [nvarchar](40),
 @OPER_cNombre [nvarchar](40),
 @OPER_cCorreo [nvarchar](60),
 @VEHI_Id [int],
 @PUES_Id [int],
 @OPER_Id [int] OUTPUT
WITH EXECUTE AS CALLER
AS
BEGIN
 insert into SAIR_OPERARIOS
  (OPER_cApellidoPaterno, OPER_cApellidoMaterno, OPER_cNombre, OPER_cCorreo,VEHI_Id,PUES_Id)
  values
  (@OPER_cApellidoPaterno, @OPER_cApellidoMaterno, @OPER_cNombre, @OPER_cCorreo,@VEHI_Id,@PUES_Id);
  set @OPER_Id =  SCOPE_IDENTITY()
END


GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERS]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_OPERS]
WITH EXECUTE AS CALLER
AS
BEGIN
	select OPER.OPER_Id, OPER.OPER_cApellidoPaterno, OPER.OPER_cApellidoMaterno, 
	OPER.OPER_cNombre, OPER.OPER_cCorreo, OPER.VEHI_Id,VEHI.PlacaTracto AS VEHI_cDescripcion,OPER.PUES_Id
	from SAIR_OPERARIOS OPER LEFT JOIN SAIR_VEHICLE VEHI ON OPER.VEHI_Id=VEHI.Codigo;
END

GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERS_Datos]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_OPERS_Datos]
	@tableName [nvarchar](60)
WITH EXECUTE AS CALLER
AS
BEGIN
   declare @sqlSelectTableData nvarchar(max);

   select @sqlSelectTableData = 'SELECT ''' + @tableName + ''' AS TableName, OPER.OPER_Id DriverCode, OPER.* FROM [dbo].[SAIR_OPERARIOS] OPER LEFT JOIN [vehiclevars].' + QUOTENAME(@tableName) 
    + ' VEDA  ON OPER.OPER_Id = VEDA.SAIR_VEHIID '
    
    print @sqlSelectTableData

    exec sp_executesql @sqlSelectTableData
END


GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERS_Filtrado]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_OPERS_Filtrado]
	@prmStart [int],
	@prmEnd [int]
WITH EXECUTE AS CALLER
AS
DECLARE @totalRows int
BEGIN
	SELECT @totalRows = count(*) from SAIR_OPERARIOS;

	select DATA.* from
	(
		select ROW_NUMBER() OVER(ORDER BY OPER.OPER_Id) RowNumber, @totalRows AS TotalRows,OPER.OPER_Id,
		OPER.OPER_cApellidoPaterno, OPER.OPER_cApellidoMaterno, 
		OPER.OPER_cNombre, OPER.OPER_cCorreo,OPER.VEHI_Id, VEHI.PlacaTracto AS VEHI_cDescripcion, OPER.PUES_Id
		from SAIR_OPERARIOS OPER LEFT JOIN SAIR_VEHICLE VEHI ON OPER.VEHI_Id=VEHI.Codigo 
	) DATA
	where DATA.RowNUmber >= @prmStart and DATA.RowNUmber <= @prmEnd;
END


GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERS_UnReg]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_OPERS_UnReg]
	@OPER_Id [int]
WITH EXECUTE AS CALLER
AS
BEGIN
	select OPER.OPER_Id,OPER.OPER_cApellidoPaterno,
	OPER.OPER_cApellidoMaterno, OPER.OPER_cNombre,
	OPER.OPER_cCorreo, VEHI.PlacaTolva AS VEHI_cDescripcion,OPER.PUES_id
		from SAIR_OPERARIOS OPER LEFT JOIN SAIR_VEHICLE VEHI ON OPER.VEHI_Id=VEHI.Codigo
	WHERE OPER.OPER_Id= @OPER_Id;
END


GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERU]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_OPERU]
	@OPER_Id [int],
	@OPER_cApellidoPaterno [nvarchar](40),
	@OPER_cApellidoMaterno [nvarchar](40),
	@OPER_cNombre [nvarchar](40),
	@OPER_cCorreo [nvarchar](60),
	@VEHI_Id [int],
	@PUES_Id [int]
WITH EXECUTE AS CALLER
AS
BEGIN
	update SAIR_OPERARIOS
		set OPER_cApellidoPaterno = @OPER_cApellidoPaterno,
		OPER_cApellidoMaterno = @OPER_cApellidoMaterno,
		OPER_cNombre= @OPER_cNombre,
		OPER_cCorreo = @OPER_cCorreo,
		VEHI_Id=@VEHI_Id,
		PUES_Id=@PUES_Id
		where OPER_Id= @OPER_Id;
END


GO
/****** Object:  StoredProcedure [dbo].[SAIR_SELECTTABLES]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_SELECTTABLES]
AS
BEGIN
    SELECT AOB.NAME AS TableNormalizedName, EPR.value AS TableName FROM sys.all_objects AOB
    LEFT JOIN sys.extended_properties EPR
    ON aob.object_id = EPR.major_id
    JOIN sys.schemas SCH
    ON AOB.schema_id = SCH.schema_id
    WHERE AOB.type = 'U' AND SCH.name = 'vehiclevars';
END

GO
/****** Object:  StoredProcedure [dbo].[SAIR_TYPES_AllByTable]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_TYPES_AllByTable]
	@TYPE_cCodTable NVARCHAR(4)
AS
BEGIN
	SELECT STYP.TYPE_cCodTable + '|@|' + STYP.TYPE_cCodType AS TYPE_CodeConcatenated
		, STYP.TYPE_cCodTable
		, STYP.TYPE_cCodType
		, STYP.TYPE_cDescription
		, STYP.TYPE_cNotes
		FROM dbo.SAIR_TYPES STYP
		WHERE STYP.TYPE_cCodTable = @TYPE_cCodTable;
END

GO
/****** Object:  StoredProcedure [dbo].[SAIR_UpdateDataToTable]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_UpdateDataToTable]
	@columnsDictionaryDeclarationAndValue AS vehiclevars.ColumnValueDictionary READONLY,
	@tableName AS NVARCHAR(80),
	@vehicleId AS INT
AS
BEGIN
	DECLARE @cursorColumnAndValues CURSOR;
	DECLARE @updateSQL NVARCHAR(MAX);

	DECLARE @iColumnName NVARCHAR(80),
		@iColumnValue NVARCHAR(80);

	SET @updateSQL = 'UPDATE [vehiclevars].' + QUOTENAME(@tableName) + ' SET ';

	SET @cursorColumnAndValues = CURSOR FOR
		SELECT ColumnaName, ColumnValue FROM
			@columnsDictionaryDeclarationAndValue;

	OPEN @cursorColumnAndValues
		FETCH NEXT FROM @cursorColumnAndValues
		INTO @iColumnName, @iColumnValue

	WHILE @@FETCH_STATUS = 0
	BEGIN

		SET @updateSQL += @iColumnName + ' = ' + @iColumnValue + ', '

		FETCH NEXT FROM @cursorColumnAndValues
			INTO @iColumnName, @iColumnValue
	END

	SET @updateSQL = SUBSTRING(@updateSQL, 1, LEN(@updateSQL) - 1)
	SET @updateSQL += ' WHERE SAIR_VEHIID = ' + CAST(@vehicleId AS NVARCHAR(20)) + ';'

	PRINT @updateSQL
	EXEC sp_executesql @updateSQL;
END
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEALI]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEALI]
	@VEAL_TableName nvarchar(80),
	@VEAL_DaysToAlert int,
	@VEAL_DateToAlert datetime,
	@VEAL_AlertName nvarchar(80),
	@VEAL_AlertSended bit,
	@VEHI_ID int
AS
BEGIN
	INSERT INTO dbo.SAIR_VehicleAlerts
	        ( VEAL_TableName ,
	          VEAL_DaysToAlert ,
	          VEAL_DateToAlert ,
	          VEAL_AlertName ,
	          VEAL_AlertSended,
			  VEHI_ID
	        )
	VALUES  ( @VEAL_TableName , -- VEAL_TableName - nvarchar(80)
	          @VEAL_DaysToAlert , -- VEAL_DaysToAlert - int
	          @VEAL_DateToAlert , -- VEAL_DateToAlert - datetime
	          @VEAL_AlertName , -- VEAL_AlertName - nvarchar(80)
	          0,  -- VEAL_AlertSended - bit
			  @VEHI_ID
	        );
END

GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEALS_TodosNoEnviados]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEALS_TodosNoEnviados]
AS
BEGIN 
	SELECT VEAL.VEAL_Id, VEAL.VEAL_TableName, VEAL.VEAL_DaysToAlert, VEAL.VEAL_DateToAlert, VEAL.VEAL_AlertName, VEAL.VEAL_AlertSended
	, VEAL.VEHI_ID FROM dbo.SAIR_VehicleAlerts VEAL
	WHERE VEAL.VEAL_AlertSended = 0;
END

GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEALU]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEALU]
	@VEAL_Id int,
	@VEAL_TokenSMS nvarchar(80),
	@VEAL_SendDate datetime,
	@VEAL_Recipients nvarchar(max)
AS
BEGIN
	UPDATE dbo.SAIR_VehicleAlerts
	SET VEAL_AlertSended = 1,
	VEAL_TokenSMS = @VEAL_TokenSMS,
	VEAL_SendDate = @VEAL_SendDate,
	VEAL_Recipients = @VEAL_Recipients
	WHERE VEAL_Id = @VEAL_Id;
END

GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHID]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHID]
(
	@Codigo int
)
AS
BEGIN
	delete from SAIR_VEHICLE
		where Codigo = @Codigo;
END
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHII]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHII]
(
	@PlacaTracto nvarchar(60),
	@PlacaTolva nvarchar(60),
	@TYPE_cTABBRND nvarchar(4),
	@TYPE_cCODBRND nvarchar(4),
	-- @CodigoMarca int,
	-- @CodigoEstado int,
	@TYPE_cTABVSTA nvarchar(4),
	@TYPE_cCODVSTA nvarchar(4),
	@Codigo int out
)
AS
BEGIN
	insert into SAIR_VEHICLE
		(PlacaTracto, PlacaTolva, TYPE_cTABBRND, TYPE_cCODBRND, TYPE_cTABVSTA, TYPE_cCODVSTA)
		values
		(@PlacaTracto, @PlacaTolva, @TYPE_cTABBRND, @TYPE_cCODBRND, @TYPE_cTABVSTA, @TYPE_cCODVSTA);
		set @Codigo =  SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIS]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHIS]
AS
BEGIN
	select VEHI.Item, VEHI.Codigo, VEHI.PlacaTracto, VEHI.PlacaTolva, VEHI.TYPE_cTABBRND, VEHI.TYPE_cCODBRND, VEHI.TYPE_cTABVSTA, VEHI.TYPE_cCODVSTA
		, BRND.TYPE_cDescription AS Marca, VSTA.TYPE_cDescription AS Estado
	from SAIR_VEHICLE VEHI
	LEFT JOIN SAIR_TYPES BRND
	ON VEHI.TYPE_cTABBRND = BRND.TYPE_cCodTable AND VEHI.TYPE_cCODBRND = BRND.TYPE_cCodType
	LEFT JOIN SAIR_TYPES VSTA
	ON VEHI.TYPE_cTABVSTA = VSTA.TYPE_cCodTable AND VEHI.TYPE_cCODVSTA = VSTA.TYPE_cCodType;
END

GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIS_Datos]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHIS_Datos]
    @tableName nvarchar(60)
AS
BEGIN
   declare @sqlSelectTableData nvarchar(max);

   select @sqlSelectTableData = 'SELECT ''' + @tableName + ''' AS TableName, VEHI.Codigo VehicleCode, VEDA.* FROM [dbo].[SAIR_VEHICLE] VEHI LEFT JOIN [vehiclevars].' + QUOTENAME(@tableName) 
    + ' VEDA  ON VEHI.Codigo = VEDA.SAIR_VEHIID '
    
    print @sqlSelectTableData

    exec sp_executesql @sqlSelectTableData
END
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIS_Filtrado]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SAIR_VEHIS_Filtrado]
	@prmStart int,
	@prmEnd int
AS
	DECLARE @totalRows int
BEGIN
	SELECT @totalRows = count(*) from SAIR_VEHICLE;

	select DATA.* from
	(
		select ROW_NUMBER() OVER(ORDER BY VEHI.Codigo) RowNumber, @totalRows AS TotalRows, VEHI.Item, VEHI.Codigo, VEHI.PlacaTracto, VEHI.PlacaTolva, VEHI.TYPE_cTABBRND, VEHI.TYPE_cCODBRND, VEHI.TYPE_cTABVSTA, VEHI.TYPE_cCODVSTA
		from SAIR_VEHICLE VEHI
	) DATA
	where DATA.RowNUmber >= @prmStart and DATA.RowNUmber <= @prmEnd;
END


GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIS_TableData]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHIS_TableData]
	@tableName nvarchar(80),
	@vehicleId int
AS
BEGIN
	DECLARE @columnsTable NVARCHAR(MAX) = STUFF((SELECT ', CAST(' +   QUOTENAME(name) + ' AS NVARCHAR(80)) AS ' + name 
	FROM sys.columns
	WHERE objecT_id = OBJECT_ID('vehiclevars.' + @tableName)
	FOR XML PATH(''), TYPE).value('.', 'VARCHAR(MAX)')
	, 1, 1, '')
	, @listColumns NVARCHAR(MAX) = STUFF((SELECT ',' +   QUOTENAME(name)
	FROM sys.columns
	WHERE objecT_id = OBJECT_ID('vehiclevars.' + @tableName)
	FOR XML PATH(''), TYPE).value('.', 'VARCHAR(MAX)')
	, 1, 1, '')
	, @tableDataSQL NVARCHAR(MAX);

	SET @tableDataSQL = 'SELECT  TAB.name TableName,
				TAB.object_id ObjectId,
				COL.name ColumnName,
				COL.column_id ColumnId,
				U.ColumnValue TableValue,
				T.name ColumnType
		FROM sys.tables TAB
		INNER JOIN SYS.columns COL
			ON TAB.object_id = COL.object_id
		INNER JOIN sys.types T
			ON T.user_type_id = COL.system_type_id 
		LEFT JOIN
		(
			SELECT ColumnName, ColumnValue
			FROM ( SELECT ' + @columnsTable + ' FROM vehiclevars.' + @tableName + ' where SAIR_VEHIID = ' + CAST(@vehicleId AS NVARCHAR(60)) + ' ) AS P
			UNPIVOT
			( ColumnValue FOR ColumnName IN (' + @listColumns + ' )
			) as unpvt
		) as U
		ON U.ColumnName = COL.name
		WHERE TAB.name = '''+ @tableName + '''';

	EXEC sp_executesql @tableDataSQL
END

GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIS_UnReg]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHIS_UnReg]
	@Codigo INT
AS
BEGIN
	SELECT VEHI.Item, VEHI.Codigo, VEHI.PlacaTracto, VEHI.PlacaTolva, VEHi.TYPE_cTABBRND, VEHI.TYPE_cCODBRND, VEHI.TYPE_cTABVSTA, VEHI.TYPE_cCODVSTA
		FROM SAIR_VEHICLE VEHI
	WHERE VEHI.Codigo = @Codigo;
END
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIU]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHIU]
(
	@Codigo int,
	@PlacaTracto nvarchar(60),
	@PlacaTolva nvarchar(60),
	@TYPE_cTABBRND nvarchar(4),
	@TYPE_cCODBRND nvarchar(4),
	-- @CodigoMarca int,
	-- @CodigoEstado int,
	@TYPE_cTABVSTA nvarchar(4),
	@TYPE_cCODVSTA nvarchar(4)
)
AS
BEGIN
	update SAIR_VEHICLE
		set PlacaTracto = @PlacaTracto,
		PlacaTolva = @PlacaTolva,
		TYPE_cTABBRND = @TYPE_cTABBRND,
		TYPE_cCODBRND = @TYPE_cCODBRND,
		-- CodigoMarca = @CodigoMarca,
		TYPE_cTABVSTA = @TYPE_cTABVSTA,
		TYPE_cCODVSTA = @TYPE_cCODVSTA
		-- CodigoEstado = @CodigoEstado
		where Codigo = @Codigo;
END
GO
/****** Object:  StoredProcedure [dbo].[tmp_DoSomethingWithEmployees]    Script Date: 5/18/2016 08:18:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tmp_DoSomethingWithEmployees]
  @List AS dbo.tmp_EmployeeList READONLY
AS
BEGIN
  SET NOCOUNT ON;
  SELECT EmployeeID FROM @List; 
END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Encargado' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'DocumentosSunat', @level2type=N'COLUMN',@level2name=N'Encargado'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto a Pagar' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'DocumentosSunat', @level2type=N'COLUMN',@level2name=N'MontoaPagar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha Pago' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'DocumentosSunat', @level2type=N'COLUMN',@level2name=N'FechaPago'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DocumentosSunat' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'DocumentosSunat'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Encargado' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica1', @level2type=N'COLUMN',@level2name=N'Encargado'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FechaLimite' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica1', @level2type=N'COLUMN',@level2name=N'FechaLimite'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'RevisionTecnica1' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica1'
GO
USE [master]
GO
ALTER DATABASE [SERVOSASAIR] SET  READ_WRITE 
GO
