USE [SERVOSASAIR]
GO
/****** Object:  Table [dbo].[SAIR_OPERARIOS]    Script Date: 07/05/2016 09:11:04 p.m. ******/
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
PRIMARY KEY CLUSTERED 
(
	[OPER_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SAIR_OPERARIOS]  WITH CHECK ADD FOREIGN KEY([VEHI_Id])
REFERENCES [dbo].[SAIR_VEHICLE] ([Codigo])
GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERD]    Script Date: 07/05/2016 09:11:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_OPERD]
(
	@OPER_Id int
)
AS
BEGIN
	delete from SAIR_OPERARIOS
		where OPER_Id = @OPER_Id;
END

GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERI]    Script Date: 07/05/2016 09:11:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[SAIR_OPERI]
(
	@OPER_cApellidoPaterno nvarchar(40),
	@OPER_cApellidoMaterno nvarchar(40),	
	@OPER_cNombre nvarchar(40),
	@OPER_cCorreo nvarchar(60),
	@VEHI_Id Integer,
	@OPER_Id int out
)
AS
BEGIN
	insert into SAIR_OPERARIOS
		(OPER_cApellidoPaterno, OPER_cApellidoMaterno, OPER_cNombre, OPER_cCorreo,VEHI_Id)
		values
		(@OPER_cApellidoPaterno, @OPER_cApellidoMaterno, @OPER_cNombre, @OPER_cCorreo,@VEHI_Id);
		set @OPER_Id =  SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERS]    Script Date: 07/05/2016 09:11:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SAIR_OPERS]
AS
BEGIN
	select OPER.OPER_Id, OPER.OPER_cApellidoPaterno, OPER.OPER_cApellidoMaterno, 
	OPER.OPER_cNombre, OPER.OPER_cCorreo, OPER.VEHI_Id,VEHI.PlacaTracto AS VEHI_cDescripcion,OPER.PUES_Id
	from SAIR_OPERARIOS OPER LEFT JOIN SAIR_VEHICLE VEHI ON OPER.VEHI_Id=VEHI.Codigo;
END
GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERS_Filtrado]    Script Date: 07/05/2016 09:11:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[SAIR_OPERS_Filtrado]
	@prmStart int,
	@prmEnd int
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
/****** Object:  StoredProcedure [dbo].[SAIR_OPERS_UnReg]    Script Date: 07/05/2016 09:11:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SAIR_OPERS_UnReg]
	@OPER_Id INT
AS
BEGIN
	select OPER.OPER_Id,OPER.OPER_cApellidoPaterno,
	OPER.OPER_cApellidoMaterno, OPER.OPER_cNombre,
	OPER.OPER_cCorreo, VEHI.PlacaTolva AS VEHI_cDescripcion,OPER.PUES_id
		from SAIR_OPERARIOS OPER LEFT JOIN SAIR_VEHICLE VEHI ON OPER.VEHI_Id=VEHI.Codigo
	WHERE OPER.OPER_Id= @OPER_Id;
END

GO
/****** Object:  StoredProcedure [dbo].[SAIR_OPERU]    Script Date: 07/05/2016 09:11:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SAIR_OPERU]
(
	@OPER_Id int,
	@OPER_cApellidoPaterno nvarchar(40),
	@OPER_cApellidoMaterno nvarchar(40),
	@OPER_cNombre nvarchar(40),
	@OPER_cCorreo nvarchar(60),
	@VEHI_Id int,
	@PUES_Id int
)
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
