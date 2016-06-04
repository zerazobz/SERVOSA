EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica', @level2type=N'COLUMN',@level2name=N'ThisShit'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica', @level2type=N'COLUMN',@level2name=N'Representante2'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica', @level2type=N'COLUMN',@level2name=N'Alerta'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica', @level2type=N'COLUMN',@level2name=N'Impuesto'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica', @level2type=N'COLUMN',@level2name=N'Encargado'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'DocumentosSunat'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'DocumentosSunat', @level2type=N'COLUMN',@level2name=N'FechadePago'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'DocumentosSunat', @level2type=N'COLUMN',@level2name=N'MontoaPagar'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'DocumentosSunat', @level2type=N'COLUMN',@level2name=N'Representante'

GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIU]    Script Date: 4/28/2016 08:04:27 ******/
DROP PROCEDURE [dbo].[SAIR_VEHIU]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIS_Filtrado]    Script Date: 4/28/2016 08:04:27 ******/
DROP PROCEDURE [dbo].[SAIR_VEHIS_Filtrado]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIS]    Script Date: 4/28/2016 08:04:27 ******/
DROP PROCEDURE [dbo].[SAIR_VEHIS]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHII]    Script Date: 4/28/2016 08:04:27 ******/
DROP PROCEDURE [dbo].[SAIR_VEHII]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHID]    Script Date: 4/28/2016 08:04:27 ******/
DROP PROCEDURE [dbo].[SAIR_VEHID]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_SELECTTABLES]    Script Date: 4/28/2016 08:04:27 ******/
DROP PROCEDURE [dbo].[SAIR_SELECTTABLES]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_LISTTABLESANDCOLUMNS]    Script Date: 4/28/2016 08:04:27 ******/
DROP PROCEDURE [dbo].[SAIR_LISTTABLESANDCOLUMNS]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_DROPCOLUMNTABLE]    Script Date: 4/28/2016 08:04:27 ******/
DROP PROCEDURE [dbo].[SAIR_DROPCOLUMNTABLE]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_CREATETABLE]    Script Date: 4/28/2016 08:04:27 ******/
DROP PROCEDURE [dbo].[SAIR_CREATETABLE]
GO
/****** Object:  StoredProcedure [dbo].[SAIR_ADDCOLUMNTABLE]    Script Date: 4/28/2016 08:04:27 ******/
DROP PROCEDURE [dbo].[SAIR_ADDCOLUMNTABLE]
GO
/****** Object:  Table [vehiclevars].[RevisionTecnica]    Script Date: 4/28/2016 08:04:27 ******/
DROP TABLE [vehiclevars].[RevisionTecnica]
GO
/****** Object:  Table [vehiclevars].[DocumentosSunat]    Script Date: 4/28/2016 08:04:27 ******/
DROP TABLE [vehiclevars].[DocumentosSunat]
GO
/****** Object:  Table [dbo].[SAIR_VEHICLE]    Script Date: 4/28/2016 08:04:27 ******/
DROP TABLE [dbo].[SAIR_VEHICLE]
GO
/****** Object:  UserDefinedFunction [dbo].[SAIR_RemoveNonAlphaCharacters]    Script Date: 4/28/2016 08:04:27 ******/
DROP FUNCTION [dbo].[SAIR_RemoveNonAlphaCharacters]
GO
/****** Object:  UserDefinedFunction [dbo].[SAIR_RemoveAccentsAndNormalizeTest]    Script Date: 4/28/2016 08:04:27 ******/
DROP FUNCTION [dbo].[SAIR_RemoveAccentsAndNormalizeTest]
GO
/****** Object:  Sequence [dbo].[SAIR_VALUESFORVEHICLEITEM]    Script Date: 4/28/2016 08:04:27 ******/
DROP SEQUENCE [dbo].[SAIR_VALUESFORVEHICLEITEM]
GO
/****** Object:  Schema [vehiclevars]    Script Date: 4/28/2016 08:04:27 ******/
DROP SCHEMA [vehiclevars]
GO
/****** Object:  Database [SERVOSASAIR]    Script Date: 4/28/2016 08:04:27 ******/
DROP DATABASE [SERVOSASAIR]
GO
/****** Object:  Database [SERVOSASAIR]    Script Date: 4/28/2016 08:04:27 ******/
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
/****** Object:  Schema [vehiclevars]    Script Date: 4/28/2016 08:04:27 ******/
CREATE SCHEMA [vehiclevars]
GO
/****** Object:  Sequence [dbo].[SAIR_VALUESFORVEHICLEITEM]    Script Date: 4/28/2016 08:04:27 ******/
CREATE SEQUENCE [dbo].[SAIR_VALUESFORVEHICLEITEM] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -9223372036854775808
 MAXVALUE 9223372036854775807
 CACHE 
GO
/****** Object:  UserDefinedFunction [dbo].[SAIR_RemoveAccentsAndNormalizeTest]    Script Date: 4/28/2016 08:04:27 ******/
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
/****** Object:  UserDefinedFunction [dbo].[SAIR_RemoveNonAlphaCharacters]    Script Date: 4/28/2016 08:04:27 ******/
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
/****** Object:  Table [dbo].[SAIR_VEHICLE]    Script Date: 4/28/2016 08:04:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SAIR_VEHICLE](
	[Item] [int] NOT NULL CONSTRAINT [SAIR_VEHIDF_ItemValores]  DEFAULT (NEXT VALUE FOR [SAIR_VALUESFORVEHICLEITEM]),
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[PlacaTracto] [nvarchar](30) NULL,
	[PlacaTolva] [nvarchar](30) NULL,
	[CodigoMarca] [int] NOT NULL,
	[CodigoEstado] [int] NOT NULL,
 CONSTRAINT [SAIR_VEHIPK] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [vehiclevars].[DocumentosSunat]    Script Date: 4/28/2016 08:04:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [vehiclevars].[DocumentosSunat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Representante] [nvarchar](80) NULL,
	[MontoaPagar] [int] NULL,
	[FechadePago] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [vehiclevars].[RevisionTecnica]    Script Date: 4/28/2016 08:04:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [vehiclevars].[RevisionTecnica](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Encargado] [nvarchar](80) NULL,
	[Impuesto] [int] NULL,
	[Alerta] [datetime] NULL,
	[Representante2] [nvarchar](80) NULL,
	[ThisShit] [nvarchar](80) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[SAIR_VEHICLE] ON 

INSERT [dbo].[SAIR_VEHICLE] ([Item], [Codigo], [PlacaTracto], [PlacaTolva], [CodigoMarca], [CodigoEstado]) VALUES (1, 1, N'CM-546', N'VPM-654', 0, 1)
INSERT [dbo].[SAIR_VEHICLE] ([Item], [Codigo], [PlacaTracto], [PlacaTolva], [CodigoMarca], [CodigoEstado]) VALUES (2, 2, N'ABC-562', N'TRB-952', 1, 0)
INSERT [dbo].[SAIR_VEHICLE] ([Item], [Codigo], [PlacaTracto], [PlacaTolva], [CodigoMarca], [CodigoEstado]) VALUES (4, 4, N'MNG-9865', N'AAA--366', 0, 2)
INSERT [dbo].[SAIR_VEHICLE] ([Item], [Codigo], [PlacaTracto], [PlacaTolva], [CodigoMarca], [CodigoEstado]) VALUES (5, 5, N'jajajaja', N'jojojojo', 2, 2)
SET IDENTITY_INSERT [dbo].[SAIR_VEHICLE] OFF
/****** Object:  StoredProcedure [dbo].[SAIR_ADDCOLUMNTABLE]    Script Date: 4/28/2016 08:04:27 ******/
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
/****** Object:  StoredProcedure [dbo].[SAIR_CREATETABLE]    Script Date: 4/28/2016 08:04:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_CREATETABLE]
(
    @newTableName NVARCHAR(200),
    @tableNormalizedName NVARCHAR(200) OUT
)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX)
    SET @tableNormalizedName = dbo.SAIR_RemoveAccentsAndNormalizeTest(@newTableName)
    --SET @tableNormalizedName = @newTableName
    --DECLARE @tableDesc NVARCHAR(50)
    SELECT @sql = 'create table vehiclevars.' + QUOTENAME(@tableNormalizedName) + '(id int identity(1,1) primary key )'
    PRINT @sql

    EXEC sp_executesql @sql

	PRINT 'EL antiguo nombre es: ' + @newTableName

    EXEC sys.sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = @newTableName, 
    @level0type = N'SCHEMA', @level0name = 'vehiclevars', 
    @level1type = N'TABLE',  @level1name = @tableNormalizedName;
END

GO
/****** Object:  StoredProcedure [dbo].[SAIR_DROPCOLUMNTABLE]    Script Date: 4/28/2016 08:04:27 ******/
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
/****** Object:  StoredProcedure [dbo].[SAIR_LISTTABLESANDCOLUMNS]    Script Date: 4/28/2016 08:04:27 ******/
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
/****** Object:  StoredProcedure [dbo].[SAIR_SELECTTABLES]    Script Date: 4/28/2016 08:04:27 ******/
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
/****** Object:  StoredProcedure [dbo].[SAIR_VEHID]    Script Date: 4/28/2016 08:04:27 ******/
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
/****** Object:  StoredProcedure [dbo].[SAIR_VEHII]    Script Date: 4/28/2016 08:04:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHII]
(
	@PlacaTracto nvarchar(60),
	@PlacaTolva nvarchar(60),
	@CodigoMarca int,
	@CodigoEstado int,
	@Codigo int out
)
AS
BEGIN
	insert into SAIR_VEHICLE
		(PlacaTracto, PlacaTolva, CodigoMarca, CodigoEstado)
		values
		(@PlacaTracto, @PlacaTolva, @CodigoMarca, @CodigoEstado);
		set @Codigo =  SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIS]    Script Date: 4/28/2016 08:04:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHIS]
AS
BEGIN
	select VEHI.Item, VEHI.Codigo, VEHI.PlacaTracto, VEHI.PlacaTolva, VEHI.CodigoMarca, VEHI.CodigoEstado
	from SAIR_VEHICLE VEHI;
END

GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIS_Filtrado]    Script Date: 4/28/2016 08:04:27 ******/
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
		select ROW_NUMBER() OVER(ORDER BY VEHI.Codigo) RowNumber, @totalRows AS TotalRows, VEHI.Item, VEHI.Codigo, VEHI.PlacaTracto, VEHI.PlacaTolva, VEHI.CodigoMarca, VEHI.CodigoEstado
		from SAIR_VEHICLE VEHI
	) DATA
	where DATA.RowNUmber >= @prmStart and DATA.RowNUmber <= @prmEnd;
END

GO
/****** Object:  StoredProcedure [dbo].[SAIR_VEHIU]    Script Date: 4/28/2016 08:04:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHIU]
(
	@Codigo int,
	@PlacaTracto nvarchar(60),
	@PlacaTolva nvarchar(60),
	@CodigoMarca int,
	@CodigoEstado int
	
)
AS
BEGIN
	update SAIR_VEHICLE
		set PlacaTracto = @PlacaTracto,
		PlacaTolva = @PlacaTolva,
		CodigoMarca = @CodigoMarca,
		CodigoEstado = @CodigoEstado
		where Codigo = @Codigo;
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Representante' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'DocumentosSunat', @level2type=N'COLUMN',@level2name=N'Representante'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto a Pagar' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'DocumentosSunat', @level2type=N'COLUMN',@level2name=N'MontoaPagar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de Pago' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'DocumentosSunat', @level2type=N'COLUMN',@level2name=N'FechadePago'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Documentos Sunat' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'DocumentosSunat'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Encargado' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica', @level2type=N'COLUMN',@level2name=N'Encargado'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Impuesto' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica', @level2type=N'COLUMN',@level2name=N'Impuesto'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Alerta' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica', @level2type=N'COLUMN',@level2name=N'Alerta'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Representante2' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica', @level2type=N'COLUMN',@level2name=N'Representante2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ThisShit' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica', @level2type=N'COLUMN',@level2name=N'ThisShit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Revision Tecnica' , @level0type=N'SCHEMA',@level0name=N'vehiclevars', @level1type=N'TABLE',@level1name=N'RevisionTecnica'
GO
ALTER DATABASE [SERVOSASAIR] SET  READ_WRITE 
GO
