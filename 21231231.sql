USE [Transunion]
GO
/****** Object:  User [LinkedSrvLogin]    Script Date: 3/12/2021 3:21:04 PM ******/
CREATE USER [LinkedSrvLogin] FOR LOGIN [LinkedSrvLogin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [ReportServerUser]    Script Date: 3/12/2021 3:21:04 PM ******/
CREATE USER [ReportServerUser] FOR LOGIN [ReportServerUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [robispo]    Script Date: 3/12/2021 3:21:04 PM ******/
CREATE USER [robispo] FOR LOGIN [robispo] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [STATETRUSTLIFE\pveneiker]    Script Date: 3/12/2021 3:21:04 PM ******/
CREATE USER [STATETRUSTLIFE\pveneiker] FOR LOGIN [STATETRUSTLIFE\pveneiker] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [transunionuser]    Script Date: 3/12/2021 3:21:04 PM ******/
CREATE USER [transunionuser] FOR LOGIN [transunionuser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [Developer]    Script Date: 3/12/2021 3:21:04 PM ******/
CREATE ROLE [Developer]
GO
/****** Object:  DatabaseRole [LinkedServer]    Script Date: 3/12/2021 3:21:05 PM ******/
CREATE ROLE [LinkedServer]
GO
/****** Object:  DatabaseRole [ReportServer]    Script Date: 3/12/2021 3:21:05 PM ******/
CREATE ROLE [ReportServer]
GO
ALTER ROLE [LinkedServer] ADD MEMBER [LinkedSrvLogin]
GO
ALTER ROLE [ReportServer] ADD MEMBER [ReportServerUser]
GO
ALTER ROLE [db_datareader] ADD MEMBER [robispo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [STATETRUSTLIFE\pveneiker]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [transunionuser]
GO
ALTER ROLE [db_datareader] ADD MEMBER [transunionuser]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [transunionuser]
GO
/****** Object:  Schema [Global]    Script Date: 3/12/2021 3:21:05 PM ******/
CREATE SCHEMA [Global]
GO
/****** Object:  Schema [Transunion]    Script Date: 3/12/2021 3:21:05 PM ******/
CREATE SCHEMA [Transunion]
GO
/****** Object:  UserDefinedFunction [Transunion].[FN_INDIVIDUO_DECLINAR]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-10-11
-- Description:	Verificar si declinar o no un individuo
-- =============================================
CREATE FUNCTION [Transunion].[FN_INDIVIDUO_DECLINAR]
(
	@Individuo_Id int
)
RETURNS bit
AS
BEGIN
	declare @Result bit
	declare @UltimoComportamientoReportado int
	declare @MontoAConsiderar numeric(18,2)

	set @MontoAConsiderar = 200000.00;

	set @UltimoComportamientoReportado = isnull((
		select		
			max([Transunion].[FN_ULTIMO_COMPORTAMIENTO_REPORTADO]([Comportamiento]))
		from
			[Transunion].[TU_INDIVIDUO_TRANSACCION]
		where 
				[Individuo_Id] = @Individuo_Id 
			and [Tipo_Transaccion_Id] = 1
			and ltrim(rtrim([Categoria])) like 'PR%'
			and [LimiteCredito] >= @MontoAConsiderar
	),0) 

	--Si el prestamo es mayor a RD$200,000.00 y esta en atraso por más de 120 días
	--, entonces declinar de lo contrario continuar.
	set @Result = iif(@UltimoComportamientoReportado >= 4,1,0);

	RETURN @Result

/*
	El monto de los prestamos a considerar es de RD$200,000.00
	•	- / No hubo reporte ese mes
	•	0 / Al Dia 
	•	1 / Atraso a 30 dias
	•	2 / Atraso a 60 dias
	•	3 / Atraso a 90 dias
	•	4 / Atraso a 120 dias
	•	5 / Atraso a 150 dias
	•	6 / Atraso a 180 dias
	•	7 / Atraso a 181 dias+
*/
END

GO
/****** Object:  Table [Transunion].[TU_INDIVIDUO]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transunion].[TU_INDIVIDUO](
	[Individuo_Id] [int] NOT NULL,
	[PrimerNombre] [varchar](60) NULL,
	[SegundoNombre] [varchar](60) NULL,
	[PrimerApellido] [varchar](60) NULL,
	[SegundoApellido] [varchar](60) NULL,
	[Cedula] [varchar](60) NOT NULL,
	[CedulaVieja] [varchar](60) NULL,
	[Sexo] [varchar](30) NULL,
	[Pasaporte] [varchar](150) NULL,
	[LugarNacimiento] [varchar](150) NULL,
	[FechaNacimiento] [date] NOT NULL,
	[EstadoCivil] [varchar](150) NULL,
	[Edad] [int] NOT NULL,
	[Ocupacion] [varchar](150) NULL,
	[Categoria] [varchar](150) NULL,
	[Conyuge] [varchar](500) NULL,
	[CedulaConyuge] [varchar](60) NULL,
	[Padre] [varchar](500) NULL,
	[Madre] [varchar](500) NULL,
	[Photo] [varbinary](max) NULL,
	[Score] [int] NOT NULL,
	[Segmentacion] [varchar](4000) NULL,
	[Reason1] [varchar](4000) NULL,
	[Reason2] [varchar](4000) NULL,
	[Reason3] [varchar](4000) NULL,
	[Last] [bit] NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [varchar](60) NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [varchar](60) NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TU_INDIVIDUO] PRIMARY KEY CLUSTERED 
(
	[Individuo_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Transunion].[TU_INDIVIDUO_TRANSACCION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transunion].[TU_INDIVIDUO_TRANSACCION](
	[Individuo_Id] [int] NOT NULL,
	[Tipo_Transaccion_Id] [int] NOT NULL,
	[Transaccion_Id] [int] NOT NULL,
	[Categoria] [varchar](100) NULL,
	[Suscriptor] [varchar](100) NULL,
	[FechaApertura] [date] NULL,
	[FechaUltimaAct] [date] NULL,
	[FechaVencimiento] [date] NULL,
	[FechaUltimaTrx] [date] NULL,
	[LimiteCredito] [numeric](18, 2) NOT NULL,
	[Balance] [numeric](18, 2) NOT NULL,
	[MontoAtraso] [numeric](18, 2) NOT NULL,
	[Estatus] [varchar](100) NULL,
	[Comportamiento] [varchar](100) NULL,
	[NoCuotas] [int] NOT NULL,
	[MontoCuotas] [numeric](18, 2) NOT NULL,
	[U_Categoria] [varchar](100) NULL,
	[U_Suscriptor] [varchar](100) NULL,
	[U_FechaApertura] [varchar](100) NULL,
	[U_FechaUltimaAct] [varchar](100) NULL,
	[U_FechaVencimiento] [varchar](100) NULL,
	[U_FechaUltimaTrx] [varchar](100) NULL,
	[U_LimiteCredito] [varchar](100) NULL,
	[U_Balance] [varchar](100) NULL,
	[U_MontoAtraso] [varchar](100) NULL,
	[U_Estatus] [varchar](100) NULL,
	[U_Comportamiento] [varchar](100) NULL,
	[U_NoCuotas] [varchar](100) NULL,
	[U_MontoCuotas] [varchar](100) NULL,
	[Transferido] [varchar](100) NULL,
	[Impugnado] [varchar](100) NULL,
	[D30] [varchar](100) NULL,
	[D60] [varchar](100) NULL,
	[D90] [varchar](100) NULL,
	[D120] [varchar](100) NULL,
	[D150] [varchar](100) NULL,
	[U_D30] [varchar](100) NULL,
	[U_D60] [varchar](100) NULL,
	[U_D90] [varchar](100) NULL,
	[U_D120] [varchar](100) NULL,
	[U_D150] [varchar](100) NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [varchar](60) NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [varchar](60) NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TU_INDIVIDUO_TRANSACCION] PRIMARY KEY CLUSTERED 
(
	[Individuo_Id] ASC,
	[Tipo_Transaccion_Id] ASC,
	[Transaccion_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [Transunion].[VW_GET_AUTOMATIC_DECLINATION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2017-04-03
-- Description:	Info about automatic declination
-- =============================================
CREATE VIEW [Transunion].[VW_GET_AUTOMATIC_DECLINATION]
AS
	select
		 tit.[Individuo_Id]
		,tit.[Tipo_Transaccion_Id]
		,tit.[Transaccion_Id]
		,tit.[Categoria]
		,tit.[Suscriptor]
		,tit.[FechaApertura]
		,tit.[FechaUltimaAct]
		,tit.[FechaVencimiento]
		,tit.[FechaUltimaTrx]
		,tit.[LimiteCredito]
		,tit.[Balance]
		,tit.[MontoAtraso]
		,tit.[Estatus]
		,tit.[Comportamiento]
		,ti.[Cedula]
	from
				   [Transunion].[TU_INDIVIDUO_TRANSACCION] tit
		inner join [Transunion].[TU_INDIVIDUO] ti
			on		ti.[Individuo_Id] = tit.[Individuo_Id]
	where 
			tit.[Tipo_Transaccion_Id] = 1
		and ti.[Last] = 1

GO
/****** Object:  View [Global].[VW_GET_TRANSACCION_VALIDATE]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [Global].[VW_GET_TRANSACCION_VALIDATE]
AS
select top 1000
	 a.[Cedula]
	,b.[Individuo_Id]
	,b.[Tipo_Transaccion_Id]
	,b.[Transaccion_Id]
	,b.[Categoria]
	,b.[Suscriptor]
	,b.[LimiteCredito]
	,b.[Balance]
	,b.[MontoAtraso]
	,b.[Estatus]
	,b.[Comportamiento]
from 
			   [Transunion].[TU_INDIVIDUO] a
	inner join [Transunion].[TU_INDIVIDUO_TRANSACCION] b
		on		b.[Individuo_Id] =  a.[Individuo_Id]
order by
	 b.[Tipo_Transaccion_Id]
	,b.[Categoria]
	,b.[LimiteCredito] desc

GO
/****** Object:  Table [Global].[ST_COMPANY]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Global].[ST_COMPANY](
	[Corp_Id] [int] NOT NULL,
	[Company_Id] [int] NOT NULL,
	[Company_Desc] [varchar](150) NOT NULL,
	[Company_Status] [bit] NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Create_UsrId] [int] NOT NULL,
	[Modi_UsrId] [int] NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ST_COMPANY] PRIMARY KEY CLUSTERED 
(
	[Corp_Id] ASC,
	[Company_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Global].[ST_PROJECT]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Global].[ST_PROJECT](
	[Corp_Id] [int] NOT NULL,
	[Project_Id] [int] NOT NULL,
	[Project_Desc] [varchar](60) NOT NULL,
	[Project_Name_Key] [varchar](60) NOT NULL,
	[Project_Status] [bit] NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [int] NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [int] NULL,
	[Hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ST_PROJECT] PRIMARY KEY CLUSTERED 
(
	[Corp_Id] ASC,
	[Project_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Global].[GS_LOG_TYPE]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Global].[GS_LOG_TYPE](
	[Log_Type_Id] [int] NOT NULL,
	[Log_Type_Desc] [varchar](60) NOT NULL,
	[Name_Key] [varchar](60) NOT NULL,
	[Log_Type_Status] [bit] NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [int] NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [int] NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_GS_LOG_TYPE] PRIMARY KEY CLUSTERED 
(
	[Log_Type_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Global].[GS_LOG]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Global].[GS_LOG](
	[Log_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Log_Type_Id] [int] NOT NULL,
	[Corp_Id] [int] NULL,
	[Company_Id] [int] NULL,
	[Project_Id] [int] NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[Log_Value] [varchar](max) NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[HostName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_GS_LOG] PRIMARY KEY CLUSTERED 
(
	[Log_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [Global].[VW_GET_GS_LOG_SERVICES]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [Global].[VW_GET_GS_LOG_SERVICES]
AS
	select top 1000
		 gl.[Log_Id]		
		,glt.[Log_Type_Desc]
		,gl.[Create_Date]
		,gl.[Identifier]
		,gl.[Log_Value]		
		,sp.[Project_Desc]
		,sc.[Company_Desc]		
		,gl.[HostName]
		,gl.[Log_Type_Id]
		,gl.[Corp_Id]
		,gl.[Company_Id]
		,gl.[Project_Id]
	from
				   [Global].[GS_LOG] gl
		inner join [Global].[GS_LOG_TYPE] glt
			on		glt.[Log_Type_Id] = gl.[Log_Type_Id]
		left join [Global].[ST_PROJECT] sp
			on		sp.[Corp_Id] = gl.[Corp_Id]
				and sp.[Project_Id] = gl.[Project_Id]
		left join [Global].[ST_COMPANY] sc
			on		sc.[Corp_Id] = gl.[Corp_Id]
				and sc.[Company_Id] = gl.[Company_Id]
	where 
			gl.[Corp_Id] = 1
		and gl.[Project_Id] in (18)
	order by 
		[Log_Id] desc


GO
/****** Object:  Table [Transunion].[TU_RIESGO]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transunion].[TU_RIESGO](
	[Riesgo_Id] [int] NOT NULL,
	[Rango_Desde] [int] NOT NULL,
	[Rango_Hasta] [int] NOT NULL,
	[Tipo_Riesgo_Id] [int] NOT NULL,
	[Riesgo_Status] [bit] NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [int] NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [int] NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TU_RIESGO] PRIMARY KEY CLUSTERED 
(
	[Riesgo_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Transunion].[TU_RIESGO_PRODUCTO]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transunion].[TU_RIESGO_PRODUCTO](
	[Producto_Id] [int] NOT NULL,
	[Riesgo_Id] [int] NOT NULL,
	[Producto_Desc] [varchar](60) NOT NULL,
	[Producto_NameKey] [varchar](60) NOT NULL,
	[Json_Info] [varchar](max) NOT NULL,
	[Producto_Status] [bit] NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [int] NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [int] NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TU_RIESGO_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[Producto_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Transunion].[TU_TIPO_RIESGO]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transunion].[TU_TIPO_RIESGO](
	[Tipo_Riesgo_Id] [int] NOT NULL,
	[Tipo_Riesgo_Desc] [varchar](60) NOT NULL,
	[Tipo_Riesgo_Name_Key] [varchar](60) NOT NULL,
	[Tipo_Riesgo_Status] [bit] NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [int] NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [int] NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TU_TIPO_RIESGO] PRIMARY KEY CLUSTERED 
(
	[Tipo_Riesgo_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [Transunion].[VW_GET_TU_RIESGO_PRODUCTO]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-09-27
-- Description:	Get info about the score an productos available
-- =============================================
CREATE VIEW [Transunion].[VW_GET_TU_RIESGO_PRODUCTO]
AS
	select
		 tr.[Riesgo_Id]
		,tr.[Rango_Desde]
		,tr.[Rango_Hasta]
		,tr.[Tipo_Riesgo_Id]
		,ttr.[Tipo_Riesgo_Desc]
		,ttr.[Tipo_Riesgo_Name_Key]
		,trp.[Producto_Id]
		,trp.[Producto_Desc]
		,trp.[Producto_NameKey]
		,trp.[Json_Info]
	from
				   [Transunion].[TU_RIESGO] tr
		inner join [Transunion].[TU_TIPO_RIESGO] ttr
			on		ttr.[Tipo_Riesgo_Id] = tr.[Tipo_Riesgo_Id]
		left join [Transunion].[TU_RIESGO_PRODUCTO] trp
			on		trp.[Riesgo_Id] = tr.[Riesgo_Id]
				and trp.[Producto_Status] = 1
	where
		tr.[Riesgo_Status] = 1




GO
/****** Object:  UserDefinedFunction [Transunion].[FN_ULTIMO_COMPORTAMIENTO_REPORTADO]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-10-11
-- Description:	Obtener el ultimo comportamiento reportado
-- =============================================
CREATE FUNCTION [Transunion].[FN_ULTIMO_COMPORTAMIENTO_REPORTADO]
(
	@Comportamiento varchar(100)
)
RETURNS int
WITH SCHEMABINDING
AS
BEGIN
	declare @Result int
	declare @ICom varchar(100)

	set @ICom = ltrim(rtrim(isnull(@Comportamiento,'')));
	set @ICom = replace(@Comportamiento,'-','');
	set @ICom = substring(@ICom,len(@ICom), len(@ICom));

	set @Result = convert(int,@ICom);
	RETURN @Result
END




GO
/****** Object:  Table [Global].[ST_COMPANY_USER]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Global].[ST_COMPANY_USER](
	[Corp_Id] [int] NOT NULL,
	[Company_Id] [int] NOT NULL,
	[User_Id] [int] NOT NULL,
	[User_Name] [varchar](60) NOT NULL,
	[User_Password] [varbinary](8000) NOT NULL,
	[Login_Attempts] [int] NOT NULL,
	[User_Lock] [bit] NOT NULL,
	[User_Status] [bit] NOT NULL,
	[Last_LogIn_Date] [datetime] NULL,
	[Lock_Date] [datetime] NULL,
	[Create_Date] [datetime] NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Create_UsrId] [int] NOT NULL,
	[Modi_UsrId] [int] NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ST_COMPANY_USER] PRIMARY KEY CLUSTERED 
(
	[Corp_Id] ASC,
	[Company_Id] ASC,
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_User_Name_ST_COMPANY_USER] UNIQUE NONCLUSTERED 
(
	[User_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Global].[ST_GLOBAL]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Global].[ST_GLOBAL](
	[Corp_Id] [int] NOT NULL,
	[Corp_Desc] [varchar](150) NOT NULL,
	[Corp_Status] [bit] NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Create_UsrId] [int] NOT NULL,
	[Modi_UsrId] [int] NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ST_GLOBAL] PRIMARY KEY CLUSTERED 
(
	[Corp_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Transunion].[TU_CATEGORIA_TRANSACCION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transunion].[TU_CATEGORIA_TRANSACCION](
	[Categoria_Transaccion_Id] [int] NOT NULL,
	[Categoria_Transaccion_Desc] [varchar](60) NOT NULL,
	[Categoria_Transaccion_Name_Key] [varchar](60) NOT NULL,
	[Categoria_Transaccion_Status] [bit] NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [int] NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [int] NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TU_CATEGORIA_TRANSACCION] PRIMARY KEY CLUSTERED 
(
	[Categoria_Transaccion_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Transunion].[TU_INDIVIDUO_CONSULTA]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transunion].[TU_INDIVIDUO_CONSULTA](
	[Consulta_Id] [int] IDENTITY(1,1) NOT NULL,
	[Individuo_Id] [int] NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [varchar](60) NOT NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TU_INDIVIDUO_CONSULTA] PRIMARY KEY CLUSTERED 
(
	[Consulta_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Transunion].[TU_INDIVIDUO_DIRECCION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transunion].[TU_INDIVIDUO_DIRECCION](
	[Individuo_Id] [int] NOT NULL,
	[Direccion_Id] [int] NOT NULL,
	[Direccion] [varchar](4000) NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [varchar](60) NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [varchar](60) NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TU_INDIVIDUO_DIRECCION] PRIMARY KEY CLUSTERED 
(
	[Individuo_Id] ASC,
	[Direccion_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Transunion].[TU_INDIVIDUO_INDAGACION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transunion].[TU_INDIVIDUO_INDAGACION](
	[Individuo_Id] [int] NOT NULL,
	[Indagacion_Id] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Suscriptor] [varchar](100) NOT NULL,
	[Tipo] [varchar](100) NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [varchar](60) NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [varchar](60) NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TU_INDIVIDUO_INDAGACION] PRIMARY KEY CLUSTERED 
(
	[Individuo_Id] ASC,
	[Indagacion_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Transunion].[TU_INDIVIDUO_RESUMEN_TRANSACCION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transunion].[TU_INDIVIDUO_RESUMEN_TRANSACCION](
	[Individuo_Id] [int] NOT NULL,
	[Resumen_Transaccion_Id] [int] NOT NULL,
	[Categoria] [varchar](100) NULL,
	[Suscriptor] [varchar](100) NULL,
	[CantidadCuentas] [int] NOT NULL,
	[LimiteCredito] [numeric](18, 2) NOT NULL,
	[Balance] [numeric](18, 2) NOT NULL,
	[PctUtilizacion] [numeric](18, 2) NOT NULL,
	[MontoAtraso] [numeric](18, 2) NOT NULL,
	[LimiteCreditoUS] [numeric](18, 2) NOT NULL,
	[BalanceUS] [numeric](18, 2) NOT NULL,
	[PctUtilizacionUS] [numeric](18, 2) NOT NULL,
	[MontoAtrasoUS] [numeric](18, 2) NOT NULL,
	[Moneda] [varchar](60) NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [varchar](60) NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [varchar](60) NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TU_INDIVIDUO_RESUMEN_TRANSACCION] PRIMARY KEY CLUSTERED 
(
	[Individuo_Id] ASC,
	[Resumen_Transaccion_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Transunion].[TU_INDIVIDUO_SENTENCIA]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transunion].[TU_INDIVIDUO_SENTENCIA](
	[Individuo_Id] [int] NOT NULL,
	[Sentencia_Id] [int] NOT NULL,
	[Numero] [int] NULL,
	[Fecha] [date] NULL,
	[Tipo] [varchar](4000) NULL,
	[Demandantes] [varchar](8000) NULL,
	[Descripcion] [varchar](8000) NULL,
	[Monto] [numeric](18, 2) NULL,
	[AbogadoDemandante] [varchar](8000) NULL,
	[Juez] [varchar](8000) NULL,
	[Tribunal] [varchar](8000) NULL,
	[CiudadTribunal] [varchar](4000) NULL,
	[Observaciones] [varchar](max) NULL,
	[Nota] [varchar](max) NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [varchar](60) NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [varchar](60) NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TU_INDIVIDUO_SENTENCIA] PRIMARY KEY CLUSTERED 
(
	[Individuo_Id] ASC,
	[Sentencia_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Transunion].[TU_INDIVIDUO_TELEFONO]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transunion].[TU_INDIVIDUO_TELEFONO](
	[Individuo_Id] [int] NOT NULL,
	[Tipo_Telefono_Id] [int] NOT NULL,
	[Telefono_Id] [int] NOT NULL,
	[Numero] [varchar](60) NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [varchar](60) NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [varchar](60) NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TU_INDIVIDUO_TELEFONO] PRIMARY KEY CLUSTERED 
(
	[Individuo_Id] ASC,
	[Tipo_Telefono_Id] ASC,
	[Telefono_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Transunion].[TU_RAZON_DECLINACION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transunion].[TU_RAZON_DECLINACION](
	[Razon_Declinacion_Id] [int] NOT NULL,
	[Razon_Declinacion_Tipo] [varchar](500) NOT NULL,
	[Razon_Declinacion_Desc] [varchar](500) NOT NULL,
	[Razon_Declinacion_NameKey] [varchar](60) NOT NULL,
	[Razon_Declinacion_Status] [bit] NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [int] NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [int] NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TU_RAZON_DECLINACION] PRIMARY KEY CLUSTERED 
(
	[Razon_Declinacion_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Transunion].[TU_TIPO_INDAGACION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transunion].[TU_TIPO_INDAGACION](
	[Tipo_Indagacion_Id] [int] NOT NULL,
	[Tipo_Indagacion_Desc] [varchar](60) NOT NULL,
	[Tipo_Indagacion_Name_Key] [varchar](60) NOT NULL,
	[Tipo_Indagacion_Status] [bit] NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [int] NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [int] NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TU_TIPO_INDAGACION] PRIMARY KEY CLUSTERED 
(
	[Tipo_Indagacion_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Transunion].[TU_TIPO_TELEFONO]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transunion].[TU_TIPO_TELEFONO](
	[Tipo_Telefono_Id] [int] NOT NULL,
	[Tipo_Telefono_Desc] [varchar](60) NOT NULL,
	[Tipo_Telefono_Name_Key] [varchar](60) NOT NULL,
	[Tipo_Telefono_Status] [bit] NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [int] NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [int] NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TU_TIPO_TELEFONO] PRIMARY KEY CLUSTERED 
(
	[Tipo_Telefono_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Transunion].[TU_TIPO_TRANSACCION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transunion].[TU_TIPO_TRANSACCION](
	[Tipo_Transaccion_Id] [int] NOT NULL,
	[Tipo_Transaccion_Desc] [varchar](60) NOT NULL,
	[Tipo_Transaccion_Name_Key] [varchar](60) NOT NULL,
	[Tipo_Transaccion_Status] [bit] NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[Create_UsrId] [int] NOT NULL,
	[Modi_Date] [datetime] NULL,
	[Modi_UsrId] [int] NULL,
	[hostname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TU_TIPO_TRANSACCION] PRIMARY KEY CLUSTERED 
(
	[Tipo_Transaccion_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Global].[GS_LOG] ADD  CONSTRAINT [DF_GS_LOG_Identifier]  DEFAULT (newid()) FOR [Identifier]
GO
ALTER TABLE [Global].[GS_LOG] ADD  CONSTRAINT [DF_GS_LOG_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Global].[GS_LOG] ADD  CONSTRAINT [DF_GS_LOG_HostName]  DEFAULT (host_name()) FOR [HostName]
GO
ALTER TABLE [Global].[GS_LOG_TYPE] ADD  CONSTRAINT [DF_GS_LOG_TYPE_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Global].[ST_COMPANY_USER] ADD  CONSTRAINT [DF_ST_COMPANY_USER_Login_Attempts]  DEFAULT ((0)) FOR [Login_Attempts]
GO
ALTER TABLE [Transunion].[TU_CATEGORIA_TRANSACCION] ADD  CONSTRAINT [DF_TU_CATEGORIA_TRANSACCION_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Transunion].[TU_CATEGORIA_TRANSACCION] ADD  CONSTRAINT [DF_TU_CATEGORIA_TRANSACCION_hostname]  DEFAULT (host_name()) FOR [hostname]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_CONSULTA] ADD  CONSTRAINT [DF_TU_INDIVIDUO_CONSULTA_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_CONSULTA] ADD  CONSTRAINT [DF_TU_INDIVIDUO_CONSULTA_hostname]  DEFAULT (host_name()) FOR [hostname]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_DIRECCION] ADD  CONSTRAINT [DF_TU_INDIVIDUO_DIRECCION_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_INDAGACION] ADD  CONSTRAINT [DF_TU_INDIVIDUO_INDAGACION_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_RESUMEN_TRANSACCION] ADD  CONSTRAINT [DF_TU_INDIVIDUO_RESUMEN_TRANSACCION_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_SENTENCIA] ADD  CONSTRAINT [DF_TU_INDIVIDUO_SENTENCIA_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_TELEFONO] ADD  CONSTRAINT [DF_TU_INDIVIDUO_TELEFONO_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_TRANSACCION] ADD  CONSTRAINT [DF_TU_INDIVIDUO_TRANSACCION_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Transunion].[TU_RAZON_DECLINACION] ADD  CONSTRAINT [DF_TU_RAZON_DECLINACION_Razon_Declinacion_NameKey]  DEFAULT ('N/A') FOR [Razon_Declinacion_NameKey]
GO
ALTER TABLE [Transunion].[TU_RAZON_DECLINACION] ADD  CONSTRAINT [DF_TU_RAZON_DECLINACION_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Transunion].[TU_RAZON_DECLINACION] ADD  CONSTRAINT [DF_TU_RAZON_DECLINACION_hostname]  DEFAULT (host_name()) FOR [hostname]
GO
ALTER TABLE [Transunion].[TU_RIESGO] ADD  CONSTRAINT [DF_TU_RIESGO_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Transunion].[TU_RIESGO] ADD  CONSTRAINT [DF_TU_RIESGO_hostname]  DEFAULT (host_name()) FOR [hostname]
GO
ALTER TABLE [Transunion].[TU_RIESGO_PRODUCTO] ADD  CONSTRAINT [DF_TU_RIESGO_PRODUCTO_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Transunion].[TU_RIESGO_PRODUCTO] ADD  CONSTRAINT [DF_TU_RIESGO_PRODUCTO_hostname]  DEFAULT (host_name()) FOR [hostname]
GO
ALTER TABLE [Transunion].[TU_TIPO_INDAGACION] ADD  CONSTRAINT [DF_TU_TIPO_INDAGACION_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Transunion].[TU_TIPO_INDAGACION] ADD  CONSTRAINT [DF_TU_TIPO_INDAGACION_hostname]  DEFAULT (host_name()) FOR [hostname]
GO
ALTER TABLE [Transunion].[TU_TIPO_RIESGO] ADD  CONSTRAINT [DF_TU_TIPO_RIESGO_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Transunion].[TU_TIPO_RIESGO] ADD  CONSTRAINT [DF_TU_TIPO_RIESGO_hostname]  DEFAULT (host_name()) FOR [hostname]
GO
ALTER TABLE [Transunion].[TU_TIPO_TELEFONO] ADD  CONSTRAINT [DF_TU_TIPO_TELEFONO_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Transunion].[TU_TIPO_TRANSACCION] ADD  CONSTRAINT [DF_TU_TIPO_TRANSACCION_Create_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [Global].[GS_LOG]  WITH CHECK ADD  CONSTRAINT [FK_GS_LOG_ST_COMPANY] FOREIGN KEY([Corp_Id], [Company_Id])
REFERENCES [Global].[ST_COMPANY] ([Corp_Id], [Company_Id])
GO
ALTER TABLE [Global].[GS_LOG] CHECK CONSTRAINT [FK_GS_LOG_ST_COMPANY]
GO
ALTER TABLE [Global].[GS_LOG]  WITH CHECK ADD  CONSTRAINT [FK_GS_LOG_ST_PROJECT] FOREIGN KEY([Corp_Id], [Project_Id])
REFERENCES [Global].[ST_PROJECT] ([Corp_Id], [Project_Id])
GO
ALTER TABLE [Global].[GS_LOG] CHECK CONSTRAINT [FK_GS_LOG_ST_PROJECT]
GO
ALTER TABLE [Global].[GS_LOG]  WITH CHECK ADD  CONSTRAINT [FK_GS_LOG_TYPE] FOREIGN KEY([Log_Type_Id])
REFERENCES [Global].[GS_LOG_TYPE] ([Log_Type_Id])
GO
ALTER TABLE [Global].[GS_LOG] CHECK CONSTRAINT [FK_GS_LOG_TYPE]
GO
ALTER TABLE [Global].[ST_COMPANY]  WITH NOCHECK ADD  CONSTRAINT [FK_ST_COMPANY_ST_GLOBAL] FOREIGN KEY([Corp_Id])
REFERENCES [Global].[ST_GLOBAL] ([Corp_Id])
GO
ALTER TABLE [Global].[ST_COMPANY] CHECK CONSTRAINT [FK_ST_COMPANY_ST_GLOBAL]
GO
ALTER TABLE [Global].[ST_COMPANY_USER]  WITH NOCHECK ADD  CONSTRAINT [FK_ST_COMPANY_USER_ST_COMPANY] FOREIGN KEY([Corp_Id], [Company_Id])
REFERENCES [Global].[ST_COMPANY] ([Corp_Id], [Company_Id])
GO
ALTER TABLE [Global].[ST_COMPANY_USER] CHECK CONSTRAINT [FK_ST_COMPANY_USER_ST_COMPANY]
GO
ALTER TABLE [Global].[ST_PROJECT]  WITH NOCHECK ADD  CONSTRAINT [FK_ST_PROJECT_ST_GLOBAL] FOREIGN KEY([Corp_Id])
REFERENCES [Global].[ST_GLOBAL] ([Corp_Id])
GO
ALTER TABLE [Global].[ST_PROJECT] CHECK CONSTRAINT [FK_ST_PROJECT_ST_GLOBAL]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_CONSULTA]  WITH NOCHECK ADD  CONSTRAINT [FK_TU_INDIVIDUO_CONSULTA_TU_INDIVIDUO] FOREIGN KEY([Individuo_Id])
REFERENCES [Transunion].[TU_INDIVIDUO] ([Individuo_Id])
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_CONSULTA] CHECK CONSTRAINT [FK_TU_INDIVIDUO_CONSULTA_TU_INDIVIDUO]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_DIRECCION]  WITH NOCHECK ADD  CONSTRAINT [FK_TU_INDIVIDUO_DIRECCION_TU_INDIVIDUO] FOREIGN KEY([Individuo_Id])
REFERENCES [Transunion].[TU_INDIVIDUO] ([Individuo_Id])
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_DIRECCION] CHECK CONSTRAINT [FK_TU_INDIVIDUO_DIRECCION_TU_INDIVIDUO]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_INDAGACION]  WITH NOCHECK ADD  CONSTRAINT [FK_TU_INDIVIDUO_INDAGACION_TU_INDIVIDUO] FOREIGN KEY([Individuo_Id])
REFERENCES [Transunion].[TU_INDIVIDUO] ([Individuo_Id])
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_INDAGACION] CHECK CONSTRAINT [FK_TU_INDIVIDUO_INDAGACION_TU_INDIVIDUO]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_RESUMEN_TRANSACCION]  WITH NOCHECK ADD  CONSTRAINT [FK_TU_INDIVIDUO_RESUMEN_TRANSACCION_TU_INDIVIDUO] FOREIGN KEY([Individuo_Id])
REFERENCES [Transunion].[TU_INDIVIDUO] ([Individuo_Id])
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_RESUMEN_TRANSACCION] CHECK CONSTRAINT [FK_TU_INDIVIDUO_RESUMEN_TRANSACCION_TU_INDIVIDUO]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_SENTENCIA]  WITH NOCHECK ADD  CONSTRAINT [FK_TU_INDIVIDUO_SENTENCIA_TU_INDIVIDUO] FOREIGN KEY([Individuo_Id])
REFERENCES [Transunion].[TU_INDIVIDUO] ([Individuo_Id])
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_SENTENCIA] CHECK CONSTRAINT [FK_TU_INDIVIDUO_SENTENCIA_TU_INDIVIDUO]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_TELEFONO]  WITH NOCHECK ADD  CONSTRAINT [FK_TU_INDIVIDUO_TELEFONO_TU_INDIVIDUO] FOREIGN KEY([Individuo_Id])
REFERENCES [Transunion].[TU_INDIVIDUO] ([Individuo_Id])
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_TELEFONO] CHECK CONSTRAINT [FK_TU_INDIVIDUO_TELEFONO_TU_INDIVIDUO]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_TELEFONO]  WITH NOCHECK ADD  CONSTRAINT [FK_TU_INDIVIDUO_TELEFONO_TU_TIPO_TELEFONO] FOREIGN KEY([Tipo_Telefono_Id])
REFERENCES [Transunion].[TU_TIPO_TELEFONO] ([Tipo_Telefono_Id])
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_TELEFONO] CHECK CONSTRAINT [FK_TU_INDIVIDUO_TELEFONO_TU_TIPO_TELEFONO]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_TRANSACCION]  WITH NOCHECK ADD  CONSTRAINT [FK_TU_INDIVIDUO_TRANSACCION_TU_INDIVIDUO] FOREIGN KEY([Individuo_Id])
REFERENCES [Transunion].[TU_INDIVIDUO] ([Individuo_Id])
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_TRANSACCION] CHECK CONSTRAINT [FK_TU_INDIVIDUO_TRANSACCION_TU_INDIVIDUO]
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_TRANSACCION]  WITH NOCHECK ADD  CONSTRAINT [FK_TU_INDIVIDUO_TRANSACCION_TU_TIPO_TRANSACCION] FOREIGN KEY([Tipo_Transaccion_Id])
REFERENCES [Transunion].[TU_TIPO_TRANSACCION] ([Tipo_Transaccion_Id])
GO
ALTER TABLE [Transunion].[TU_INDIVIDUO_TRANSACCION] CHECK CONSTRAINT [FK_TU_INDIVIDUO_TRANSACCION_TU_TIPO_TRANSACCION]
GO
ALTER TABLE [Transunion].[TU_RIESGO]  WITH CHECK ADD  CONSTRAINT [FK_TU_RIESGO_TU_TIPO_RIESGO] FOREIGN KEY([Tipo_Riesgo_Id])
REFERENCES [Transunion].[TU_TIPO_RIESGO] ([Tipo_Riesgo_Id])
GO
ALTER TABLE [Transunion].[TU_RIESGO] CHECK CONSTRAINT [FK_TU_RIESGO_TU_TIPO_RIESGO]
GO
ALTER TABLE [Transunion].[TU_RIESGO_PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_TU_RIESGO_PRODUCTO_TU_RIESGO] FOREIGN KEY([Riesgo_Id])
REFERENCES [Transunion].[TU_RIESGO] ([Riesgo_Id])
GO
ALTER TABLE [Transunion].[TU_RIESGO_PRODUCTO] CHECK CONSTRAINT [FK_TU_RIESGO_PRODUCTO_TU_RIESGO]
GO
/****** Object:  StoredProcedure [Global].[SP_INSERT_GS_LOG]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-02-25
-- Description:	insert log globalservice
-- =============================================
CREATE PROCEDURE [Global].[SP_INSERT_GS_LOG]
	 @Log_Type_Id int
	,@Corp_Id int = null
	,@Company_Id int = null
	,@Project_Id int = null
	,@Identifier uniqueidentifier = null
	,@Log_Value varchar(max)
AS
BEGIN
	SET NOCOUNT ON;
	declare @CurrentDate datetime
	declare @HostName varchar(100)
	declare @TableResult table([Code] int not null, [Message] varchar(4000) not null)

	set @CurrentDate = getdate();
	set @HostName = host_name();


	if @Log_Type_Id is null
	begin 
		insert into @TableResult
			select 1,'@Log_Type_Id can''t be null.';
	end	

	if @Log_Value is null
	begin 
		insert into @TableResult
			select 2,'@Log_Value can''t be null.';
	end

	if not exists (select top 1 1 from @TableResult)
	begin	
		set @Identifier = isnull(@Identifier,newid());

		insert into [Global].[GS_LOG]
			([Log_Type_Id],[Corp_Id],[Company_Id],[Project_Id],[Identifier],[Log_Value],[Create_Date],[HostName])
		values
			(@Log_Type_Id,@Corp_Id,@Company_Id,@Project_Id,@Identifier,@Log_Value,@CurrentDate,@HostName);
	end

	select 
		 [Code]
		,[Message] 
	from 
		@TableResult
END


GO
/****** Object:  StoredProcedure [Transunion].[SP_GET_ST_COMPANY_USER]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-08
-- Description:	Get a individuo 
-- =============================================
CREATE PROCEDURE [Transunion].[SP_GET_ST_COMPANY_USER]
	  @User_Name varchar(60)
	 ,@KeyToDecrypt varchar(60)
AS
BEGIN
	SET NOCOUNT ON;
	
	select
		 [Corp_Id]
		,[Company_Id]
		,[User_Id]
		,[User_Name]
		,convert(varchar(60),DecryptByPassphrase(@KeyToDecrypt,[User_Password])) as [User_Password]
		,[Login_Attempts]
		,[User_Lock]
		,[User_Status]
		,[Last_LogIn_Date]
		,[Lock_Date]
	from
		[Global].[ST_COMPANY_USER]
	where 
		[User_Name] = @User_Name;
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_GET_TU_INDIVIDUO]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-07
-- Description:	Get a individuo 
-- =============================================
CREATE PROCEDURE [Transunion].[SP_GET_TU_INDIVIDUO]
	 @Cedula varchar(60)
	,@UserId varchar(60)
AS
BEGIN
	SET NOCOUNT ON;
	declare @Days int = 30;

	select 
		 ti.[Individuo_Id]
		,ti.[PrimerNombre]
		,ti.[SegundoNombre]
		,ti.[PrimerApellido]
		,ti.[SegundoApellido]
		,ti.[Cedula]
		,ti.[CedulaVieja]
		,ti.[Sexo]
		,ti.[Pasaporte]
		,ti.[LugarNacimiento]
		,ti.[FechaNacimiento]
		,ti.[EstadoCivil]
		,ti.[Edad]
		,ti.[Ocupacion]
		,ti.[Categoria]
		,ti.[Conyuge]
		,ti.[CedulaConyuge]
		,ti.[Padre]
		,ti.[Madre]
		,ti.[Photo]
		,ti.[Score]
		,ti.[Segmentacion]
		,ti.[Reason1]
		,ti.[Reason2]
		,ti.[Reason3]
		,ti.[Last]
		,ti.[Create_Date]
		,ti.[Create_UsrId]
	from
		[Transunion].[TU_INDIVIDUO] ti
	where 
			ti.[Cedula] = @Cedula
		and ti.[Last] = 1
		and datediff(dd,ti.[Create_Date],getdate()) <= @Days;
END


GO
/****** Object:  StoredProcedure [Transunion].[SP_GET_TU_INDIVIDUO_DIRECCION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-06
-- Description:	Get a individuo direccion
-- =============================================
CREATE PROCEDURE [Transunion].[SP_GET_TU_INDIVIDUO_DIRECCION]
	 @Individuo_Id int
AS
BEGIN
	SET NOCOUNT ON;

	select
		 [Individuo_Id]
		,[Direccion_Id]
		,[Direccion]
	from
		[Transunion].[TU_INDIVIDUO_DIRECCION]
	where 
		[Individuo_Id] = @Individuo_Id
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_GET_TU_INDIVIDUO_INDAGACION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-06
-- Description:	Get a individuo indagacion
-- =============================================
CREATE PROCEDURE [Transunion].[SP_GET_TU_INDIVIDUO_INDAGACION]
	 @Individuo_Id int
AS
BEGIN
	SET NOCOUNT ON;

	select
		 [Individuo_Id]
		,[Indagacion_Id]
		,[Fecha]
		,[Suscriptor]
		,[Tipo]
	from
		[Transunion].[TU_INDIVIDUO_INDAGACION]
	where
		[Individuo_Id] = @Individuo_Id
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_GET_TU_INDIVIDUO_RESUMEN_TRANSACCION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-07
-- Description:	Get a individuo resumen transaccion
-- =============================================
CREATE PROCEDURE [Transunion].[SP_GET_TU_INDIVIDUO_RESUMEN_TRANSACCION]
	 @Individuo_Id int
AS
BEGIN
	SET NOCOUNT ON;

	select
		 [Individuo_Id]
		,[Resumen_Transaccion_Id]
		,[Categoria]
		,[Suscriptor]
		,[CantidadCuentas]
		,[LimiteCredito]
		,[Balance]
		,[PctUtilizacion]
		,[MontoAtraso]
		,[LimiteCreditoUS]
		,[BalanceUS]
		,[PctUtilizacionUS]
		,[MontoAtrasoUS]
		,[Moneda]
		,[Create_Date]
		,[Create_UsrId]
	from
		[Transunion].[TU_INDIVIDUO_RESUMEN_TRANSACCION]
	where 
		[Individuo_Id] = @Individuo_Id
END


GO
/****** Object:  StoredProcedure [Transunion].[SP_GET_TU_INDIVIDUO_SENTENCIA]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-17
-- Description:	Get a individuo sentencia
-- =============================================
CREATE PROCEDURE [Transunion].[SP_GET_TU_INDIVIDUO_SENTENCIA]
	 @Individuo_Id int
AS
BEGIN
	SET NOCOUNT ON;

	select
		 [Individuo_Id]
		,[Sentencia_Id]
		,[Numero]
		,[Fecha]
		,[Tipo]
		,[Demandantes]
		,[Descripcion]
		,[Monto]
		,[AbogadoDemandante]
		,[Juez]
		,[Tribunal]
		,[CiudadTribunal]
		,[Observaciones]
		,[Nota]
	from
		[Transunion].[TU_INDIVIDUO_SENTENCIA]
	where
		[Individuo_Id] = @Individuo_Id;
END


GO
/****** Object:  StoredProcedure [Transunion].[SP_GET_TU_INDIVIDUO_TELEFONO]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-06
-- Description:	Get a individuo telefono
-- =============================================
CREATE PROCEDURE [Transunion].[SP_GET_TU_INDIVIDUO_TELEFONO]
	 @Individuo_Id int
AS
BEGIN
	SET NOCOUNT ON;

	select
		 tit.[Individuo_Id]
		,tit.[Tipo_Telefono_Id]
		,tit.[Telefono_Id]
		,tit.[Numero]
		,ttt.[Tipo_Telefono_Desc]
	from
				   [Transunion].[TU_INDIVIDUO_TELEFONO] tit
		inner join [Transunion].[TU_TIPO_TELEFONO] ttt
			on ttt.[Tipo_Telefono_Id] = tit.[Tipo_Telefono_Id]
	where
		[Individuo_Id] = @Individuo_Id
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_GET_TU_INDIVIDUO_TRANSACCION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-06
-- Description:	Get a individuo transaccion
-- =============================================
CREATE PROCEDURE [Transunion].[SP_GET_TU_INDIVIDUO_TRANSACCION]
	 @Individuo_Id int
AS
BEGIN
	SET NOCOUNT ON;

	select
		 tit.[Individuo_Id]
		,tit.[Tipo_Transaccion_Id]
		,ttt.[Tipo_Transaccion_Desc]
		,tit.[Transaccion_Id]
		,tit.[Categoria]
		,tit.[Suscriptor]
		,tit.[FechaApertura]
		,tit.[FechaUltimaAct]
		,tit.[FechaVencimiento]
		,tit.[FechaUltimaTrx]
		,tit.[LimiteCredito]
		,tit.[Balance]
		,tit.[MontoAtraso]
		,tit.[Estatus]
		,tit.[Comportamiento]
		,tit.[NoCuotas]
		,tit.[MontoCuotas]
		,tit.[U_Categoria]
		,tit.[U_Suscriptor]
		,tit.[U_FechaApertura]
		,tit.[U_FechaUltimaAct]
		,tit.[U_FechaVencimiento]
		,tit.[U_FechaUltimaTrx]
		,tit.[U_LimiteCredito]
		,tit.[U_Balance]
		,tit.[U_MontoAtraso]
		,tit.[U_Estatus]
		,tit.[U_Comportamiento]
		,tit.[U_NoCuotas]
		,tit.[U_MontoCuotas]
		,tit.[Transferido]
		,tit.[Impugnado]
		,tit.[D30]
		,tit.[D60]
		,tit.[D90]
		,tit.[D120]
		,tit.[D150]
		,tit.[U_D30]
		,tit.[U_D60]
		,tit.[U_D90]
		,tit.[U_D120]
		,tit.[U_D150]
	from
				   [Transunion].[TU_INDIVIDUO_TRANSACCION] tit
		inner join [Transunion].[TU_TIPO_TRANSACCION] ttt
			on ttt.[Tipo_Transaccion_Id] = tit.[Tipo_Transaccion_Id]
	where
		[Individuo_Id] = @Individuo_Id
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_GET_TU_RIESGO_PRODUCTO]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-07
-- Description:	Get a individuo 
-- =============================================
CREATE PROCEDURE [Transunion].[SP_GET_TU_RIESGO_PRODUCTO]
	 @Individuo_Id int
AS
BEGIN
	SET NOCOUNT ON;
	declare @Score int
	declare @MinScore int
	declare @Declinar bit
	declare @TableResult table([Id] int, [Tipo] varchar(500), [Descripcion] varchar(500),[NameKey] varchar(60))
	declare @Razones varchar(max)

	set @MinScore = 484; --Por defecto el minimo.
	set @Score = @MinScore
	set @Declinar = 0;

	select
		 @Score = [Score]
		,@Declinar = [Transunion].[FN_INDIVIDUO_DECLINAR]([Individuo_Id])
	from
		[Transunion].[TU_INDIVIDUO]
	where 
		[Individuo_Id] = @Individuo_Id;

	if @Declinar = 1
	begin
		insert into @TableResult
			select
				 [Razon_Declinacion_Id]
				,[Razon_Declinacion_Tipo]
				,[Razon_Declinacion_Desc]
				,[Razon_Declinacion_NameKey]
			from
				[Transunion].[TU_RAZON_DECLINACION]
			where
				[Razon_Declinacion_Id] = 1;
	end

	insert into @TableResult
		select
			 isnull(trd.[Razon_Declinacion_Id],-1)
			,isnull(trd.[Razon_Declinacion_Tipo],'N/A')
			,isnull(trd.[Razon_Declinacion_Desc],tis.[Tipo])
			,isnull(trd.[Razon_Declinacion_NameKey],'N/A')
		from
				  [Transunion].[TU_INDIVIDUO_SENTENCIA] tis
		left join [Transunion].[TU_RAZON_DECLINACION] trd
			on		trd.[Razon_Declinacion_Desc] = tis.[Tipo]
		where 
			tis.[Individuo_Id] = @Individuo_Id;

	--Esto significa que que si hay mas de uno es porque hay alguna sentencia
	--En caso de que halla 1 o menos dejar igual la variable.
	set @Declinar = iif((select count(*) from @TableResult) > 1,1,@Declinar);

	select 
		@Razones = stuff((
			select 
				concat(',{"Id":"',[Id],'","Tipo":"',[Tipo],'","Descripcion":"',[Descripcion],'","NameKey":"',[NameKey],'"}')
			from
				@TableResult
				for xml path ('')
		), 1, 1, '');

	set @MinScore = iif(@Score<@MinScore,@MinScore,@Score);

	select
		 [Riesgo_Id]
		,[Rango_Desde]
		,[Rango_Hasta]
		,[Tipo_Riesgo_Id]
		,[Tipo_Riesgo_Desc]
		,[Tipo_Riesgo_Name_Key]
		,[Producto_Id]
		,[Producto_Desc]
		,[Producto_NameKey]
		,[Json_Info]
		,@Declinar as [Declinar]
		,concat('[',@Razones,']') as [Razones]
	from
		[Transunion].[VW_GET_TU_RIESGO_PRODUCTO]
	where
		@MinScore between [Rango_Desde] and [Rango_Hasta];
END


GO
/****** Object:  StoredProcedure [Transunion].[SP_INSERT_ST_COMPANY_USER]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-08
-- Description:	Insert an user
-- =============================================
CREATE PROCEDURE [Transunion].[SP_INSERT_ST_COMPANY_USER]
	 @Corp_Id int
	,@Company_Id int
	,@User_Id int = null
	,@User_Name varchar(60)
	,@User_Password varchar(60)
	,@User_Lock bit
	,@User_Status bit
	,@KeyToEncrypt varchar(60)
	,@UserId int
AS
BEGIN
	SET NOCOUNT ON;

	declare @UserPassword varbinary(8000)

	if	   @Corp_Id is null 
		or @Company_Id is null 
		or @User_Name is null 
		or @User_Password is null 
		or @User_Lock is null 
		or @User_Status is null 
		or @KeyToEncrypt is null 
		or @UserId is null 
		or ltrim(rtrim(@UserId)) = ''
		or ltrim(rtrim(@KeyToEncrypt)) = ''
		or ltrim(rtrim(@User_Name)) = ''
		or ltrim(rtrim(@User_Password)) = ''
	begin
		raiserror('The value of the next properties can''t be null or empty. @Corp_Id,@Company_Id,@User_Name,@User_Password,@User_Lock,@User_Status,@KeyToEncrypt,@UserId', 15, 1)
	end
	else
	begin	
		set @UserPassword = EncryptByPassPhrase(@KeyToEncrypt,@User_Password);

		exec [Transunion].[SP_SET_ST_COMPANY_USER]
				@Corp_Id = @Corp_Id,
				@Company_Id = @Company_Id,
				@User_Id = NULL,
				@User_Name = @User_Name,
				@User_Password = @UserPassword,
				@User_Lock = @User_Lock,
				@User_Status = @User_Status,
				@UserId = @UserId;
	 end
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_INSERT_TU_INDIVIDUO_CONSULTA]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-07
-- Description:	Insert a individuo consulta
-- =============================================
CREATE PROCEDURE [Transunion].[SP_INSERT_TU_INDIVIDUO_CONSULTA]
	 @Individuo_Id int
	,@UserId varchar(60)
AS
BEGIN
	SET NOCOUNT ON;

	insert into [Transunion].[TU_INDIVIDUO_CONSULTA]
			([Individuo_Id],[Create_UsrId])
	values
			(@Individuo_Id,@UserId);

	select @Individuo_Id as [Individuo_Id]
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_SET_ST_COMPANY_USER]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-08
-- Description:	Set an user
-- =============================================
CREATE PROCEDURE [Transunion].[SP_SET_ST_COMPANY_USER]
	 @Corp_Id int
	,@Company_Id int
	,@User_Id int
	,@User_Name varchar(60)
	,@User_Password varbinary(8000)
	,@User_Lock bit
	,@User_Status bit
	,@UserId int
AS
BEGIN
	SET NOCOUNT ON;

	declare @CurrentDate datetime = getdate()
	declare @HostName varchar(100) = host_name()
	declare @TableResult table(
								 [Action] varchar(10)
								,[Corp_Id] int not null
								,[Company_Id] int not null
								,[User_Id] int not null
							  )

	if @User_Id <= 0 or @User_Id is null
	begin
		set @User_Id = isnull((
			select
				max([User_Id]) + 1
			from
				[Global].[ST_COMPANY_USER]
			where
					[Corp_Id] = @Corp_Id
				and [Company_Id] = @Company_Id
		),1) 
	end

    merge [Global].[ST_COMPANY_USER] as tt --table target
	using (select  @Corp_Id,@Company_Id,@User_Id,@User_Name,@User_Password,@User_Lock,@User_Status
				  ,@UserId,@CurrentDate,@HostName) 
		as ts --table source
			( [Corp_Id],[Company_Id],[User_Id],[User_Name],[User_Password],[User_Lock],[User_Status]
			 ,[UserId],[CurrentDate],[HostName])
	on (
				tt.[Corp_Id] = ts.[Corp_Id]
			and tt.[Company_Id] = ts.[Company_Id]
			and tt.[User_Id] = ts.[User_Id]
		)
	when matched then
		update set 
			 tt.[User_Name] = isnull(ts.[User_Name],tt.[User_Name])
			,tt.[User_Password] = isnull(ts.[User_Password],tt.[User_Password])
			,tt.[User_Lock] = isnull(ts.[User_Lock],tt.[User_Lock])
			,tt.[User_Status] = isnull(ts.[User_Status],tt.[User_Status])
			,tt.Modi_Date = ts.CurrentDate
			,tt.Modi_UsrId = ts.UserId
			,tt.hostname = ts.HostName
	when not matched then
		insert ( [Corp_Id],[Company_Id],[User_Id],[User_Name],[User_Password],[User_Lock],[User_Status]
				,Create_Date,Create_UsrId,hostname)
		values ( ts.[Corp_Id],ts.[Company_Id],ts.[User_Id],ts.[User_Name],ts.[User_Password],ts.[User_Lock],ts.[User_Status]
				,ts.CurrentDate,ts.UserId,ts.HostName)
	output $action
			,isnull(deleted.[Corp_Id],inserted.[Corp_Id])
			,isnull(deleted.[Company_Id],inserted.[Company_Id])
			,isnull(deleted.[User_Id],inserted.[User_Id])
	into @TableResult;

	select
		  [Corp_Id]
		 ,[Company_Id]
		 ,[User_Id]
	from
		@TableResult;
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_SET_TU_INDIVIDUO]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-06
-- Description:	Set a individuo 
-- =============================================
CREATE PROCEDURE [Transunion].[SP_SET_TU_INDIVIDUO]
	 @Individuo_Id int = null
	,@PrimerNombre varchar(60) = null
	,@SegundoNombre varchar(60) = null
	,@PrimerApellido varchar(60) = null
	,@SegundoApellido varchar(60) = null
	,@Cedula varchar(60)
	,@CedulaVieja varchar(60) = null
	,@Sexo varchar(30) = null
	,@Pasaporte varchar(150) = null
	,@LugarNacimiento varchar(150) = null
	,@FechaNacimiento date
	,@EstadoCivil varchar(150) = null
	,@Edad int
	,@Ocupacion varchar(150) = null
	,@Categoria varchar(150) = null
	,@Conyuge varchar(500) = null
	,@CedulaConyuge varchar(60) = null
	,@Padre varchar(500) = null
	,@Madre varchar(500) = null
	,@Photo varbinary(max) = null
	,@Score int
	,@Segmentacion varchar(4000) = null
	,@Reason1 varchar(4000) = null
	,@Reason2 varchar(4000) = null
	,@Reason3 varchar(4000) = null
	,@UserId varchar(60)
AS
BEGIN
	SET NOCOUNT ON;

	declare @CurrentDate datetime = getdate()
	declare @HostName varchar(100) = host_name()
	declare @TableResult table(
								 [Action] varchar(10)
								,[Individuo_Id] int not null
							  )

	if @Individuo_Id <= 0 or @Individuo_Id is null
	begin
		set @Individuo_Id = isnull((
			select
				max([Individuo_Id]) + 1
			from
				[Transunion].[TU_INDIVIDUO]
		),1) 
	end

    merge [Transunion].[TU_INDIVIDUO] as tt --table target
	using (select  @Individuo_Id,@PrimerNombre,@SegundoNombre,@PrimerApellido,@SegundoApellido,@Cedula,@CedulaVieja,@Sexo,@Pasaporte,@LugarNacimiento
				  ,@FechaNacimiento,@EstadoCivil,@Edad,@Ocupacion,@Categoria,@Conyuge,@CedulaConyuge,@Padre,@Madre,@Photo
				  ,@Score,@Segmentacion,@Reason1,@Reason2,@Reason3
				  ,@UserId,@CurrentDate,@HostName) 
		as ts --table source
			( [Individuo_Id],[PrimerNombre],[SegundoNombre],[PrimerApellido],[SegundoApellido],[Cedula],[CedulaVieja],[Sexo],[Pasaporte]
			 ,[LugarNacimiento],[FechaNacimiento],[EstadoCivil],[Edad],[Ocupacion],[Categoria],[Conyuge],[CedulaConyuge],[Padre],[Madre],[Photo]
			 ,[Score],[Segmentacion],[Reason1],[Reason2],[Reason3]
			 ,UserId,CurrentDate,HostName)
	on (
			tt.[Individuo_Id] = ts.[Individuo_Id]
		)
	when matched then
		update set 
			 tt.[Individuo_Id] = isnull(ts.[Individuo_Id],tt.[Individuo_Id])
			,tt.[PrimerNombre] = isnull(ts.[PrimerNombre],tt.[PrimerNombre])
			,tt.[SegundoNombre] = isnull(ts.[SegundoNombre],tt.[SegundoNombre])
			,tt.[PrimerApellido] = isnull(ts.[PrimerApellido],tt.[PrimerApellido])
			,tt.[SegundoApellido] = isnull(ts.[SegundoApellido],tt.[SegundoApellido])
			,tt.[Cedula] = isnull(ts.[Cedula],tt.[Cedula])
			,tt.[CedulaVieja] = isnull(ts.[CedulaVieja],tt.[CedulaVieja])
			,tt.[Sexo] = isnull(ts.[Sexo],tt.[Sexo])
			,tt.[Pasaporte] = isnull(ts.[Pasaporte],tt.[Pasaporte])
			,tt.[LugarNacimiento] = isnull(ts.[LugarNacimiento],tt.[LugarNacimiento])
			,tt.[FechaNacimiento] = isnull(ts.[FechaNacimiento],tt.[FechaNacimiento])
			,tt.[EstadoCivil] = isnull(ts.[EstadoCivil],tt.[EstadoCivil])
			,tt.[Edad] = isnull(ts.[Edad],tt.[Edad])
			,tt.[Ocupacion] = isnull(ts.[Ocupacion],tt.[Ocupacion])
			,tt.[Categoria] = isnull(ts.[Categoria],tt.[Categoria])
			,tt.[Conyuge] = isnull(ts.[Conyuge],tt.[Conyuge])
			,tt.[CedulaConyuge] = isnull(ts.[CedulaConyuge],tt.[CedulaConyuge])
			,tt.[Padre] = isnull(ts.[Padre],tt.[Padre])
			,tt.[Madre] = isnull(ts.[Madre],tt.[Madre])
			,tt.[Photo] = isnull(ts.[Photo],tt.[Photo])
			,tt.[Score] = isnull(ts.[Score],tt.[Score])
			,tt.[Segmentacion] = isnull(ts.[Segmentacion],tt.[Segmentacion])
			,tt.[Reason1] = isnull(ts.[Reason1],tt.[Reason1])
			,tt.[Reason2] = isnull(ts.[Reason2],tt.[Reason2])
			,tt.[Reason3] = isnull(ts.[Reason3],tt.[Reason3])
			,tt.[Last] = 1
			,tt.Modi_Date = ts.CurrentDate
			,tt.Modi_UsrId = ts.UserId
			,tt.hostname = ts.HostName
	when not matched then
		insert ( [Individuo_Id],[PrimerNombre],[SegundoNombre],[PrimerApellido],[SegundoApellido],[Cedula],[CedulaVieja],[Sexo],[Pasaporte]
				,[LugarNacimiento],[FechaNacimiento],[EstadoCivil],[Edad],[Ocupacion],[Categoria],[Conyuge],[CedulaConyuge],[Padre],[Madre],[Photo]
				,[Score],[Segmentacion],[Reason1],[Reason2],[Reason3]
				,[Last],Create_Date,Create_UsrId,hostname)
		values ( ts.[Individuo_Id],ts.[PrimerNombre],ts.[SegundoNombre],ts.[PrimerApellido],ts.[SegundoApellido],ts.[Cedula],ts.[CedulaVieja],ts.[Sexo]
				,ts.[Pasaporte],ts.[LugarNacimiento],ts.[FechaNacimiento],ts.[EstadoCivil],ts.[Edad],ts.[Ocupacion],ts.[Categoria],ts.[Conyuge],ts.[CedulaConyuge]
				,ts.[Padre],ts.[Madre],ts.[Photo],ts.[Score],ts.[Segmentacion],ts.[Reason1],ts.[Reason2],ts.[Reason3]
				,1,ts.CurrentDate,ts.UserId,ts.HostName)
	output $action
			,isnull(deleted.[Individuo_Id],inserted.[Individuo_Id])
	into @TableResult;

	select
		 [Individuo_Id]
	from
		@TableResult;
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_SET_TU_INDIVIDUO_DIRECCION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-06
-- Description:	Set a individuo direccion
-- =============================================
CREATE PROCEDURE [Transunion].[SP_SET_TU_INDIVIDUO_DIRECCION]
	 @Individuo_Id int
	,@Direccion_Id int = null
	,@Direccion varchar(4000)
	,@UserId varchar(60)
AS
BEGIN
	SET NOCOUNT ON;

	declare @CurrentDate datetime = getdate()
	declare @HostName varchar(100) = host_name()
	declare @TableResult table(
								 [Action] varchar(10)
								,[Individuo_Id] int not null
								,[Direccion_Id] int not null
							  )

	if @Direccion_Id <= 0 or @Direccion_Id is null
	begin
		set @Direccion_Id = isnull((
			select
				max([Direccion_Id]) + 1
			from
				[Transunion].[TU_INDIVIDUO_DIRECCION]
			where 
					[Individuo_Id] = @Individuo_Id
		),1) 
	end

    merge [Transunion].[TU_INDIVIDUO_DIRECCION] as tt --table target
	using (select  @Individuo_Id,@Direccion_Id,@Direccion,@UserId,@CurrentDate,@HostName) 
		as ts --table source
			( Individuo_Id,Direccion_Id,Direccion,UserId,CurrentDate,HostName)
	on (
			tt.Individuo_Id = ts.Individuo_Id
		and tt.Direccion_Id = ts.Direccion_Id
		)
	when matched then
		update set 
			 tt.Direccion = isnull(ts.Direccion,tt.Direccion)
			,tt.Modi_Date = ts.CurrentDate
			,tt.Modi_UsrId = ts.UserId
			,tt.hostname = ts.HostName
	when not matched then
		insert ( Individuo_Id,Direccion_Id,Direccion
			    ,Create_Date,Create_UsrId,hostname)
		values ( ts.Individuo_Id,ts.Direccion_Id,ts.Direccion
			     ,ts.CurrentDate,ts.UserId,ts.HostName)
	output $action
			,isnull(deleted.[Individuo_Id],inserted.[Individuo_Id])
			,isnull(deleted.[Direccion_Id],inserted.[Direccion_Id])
	into @TableResult;

	select
		 [Individuo_Id]
		,[Direccion_Id]
	from
		@TableResult;
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_SET_TU_INDIVIDUO_INDAGACION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-06
-- Description:	Set a individuo indagacion
-- =============================================
CREATE PROCEDURE [Transunion].[SP_SET_TU_INDIVIDUO_INDAGACION]
	 @Individuo_Id int
	,@Indagacion_Id int = null
	,@Fecha datetime
	,@Suscriptor varchar(100)
	,@Tipo varchar(100)
	,@UserId varchar(60)
AS
BEGIN
	SET NOCOUNT ON;

	declare @CurrentDate datetime = getdate()
	declare @HostName varchar(100) = host_name()
	declare @TableResult table(
								 [Action] varchar(10)
								,[Individuo_Id] int not null
								,[Indagacion_Id] int not null
							  )

	if @Indagacion_Id <= 0 or @Indagacion_Id is null
	begin
		set @Indagacion_Id = isnull((
			select
				max([Indagacion_Id]) + 1
			from
				[Transunion].[TU_INDIVIDUO_INDAGACION]
			where 
					[Individuo_Id] = @Individuo_Id
		),1) 
	end

    merge [Transunion].[TU_INDIVIDUO_INDAGACION] as tt --table target
	using (select  @Individuo_Id,@Indagacion_Id,@Fecha,@Suscriptor,@Tipo,@UserId,@CurrentDate,@HostName) 
		as ts --table source
			( Individuo_Id,Indagacion_Id,Fecha,Suscriptor,Tipo,UserId,CurrentDate,HostName)
	on (
			tt.Individuo_Id = ts.Individuo_Id
		and tt.Indagacion_Id = ts.Indagacion_Id
		)
	when matched then
		update set 
			 tt.Fecha = isnull(ts.Fecha,tt.Fecha)
			,tt.Suscriptor = isnull(ts.Suscriptor,tt.Suscriptor)
			,tt.Tipo = isnull(ts.Tipo,tt.Tipo)
			,tt.Modi_Date = ts.CurrentDate
			,tt.Modi_UsrId = ts.UserId
			,tt.hostname = ts.HostName
	when not matched then
		insert ( Individuo_Id,Indagacion_Id,Fecha,Suscriptor,Tipo
			    ,Create_Date,Create_UsrId,hostname)
		values ( ts.Individuo_Id,ts.Indagacion_Id,ts.Fecha,ts.Suscriptor,ts.Tipo
			    ,ts.CurrentDate,ts.UserId,ts.HostName)
	output $action
			,isnull(deleted.[Individuo_Id],inserted.[Individuo_Id])
			,isnull(deleted.[Indagacion_Id],inserted.[Indagacion_Id])
	into @TableResult;

	select
		 [Individuo_Id]
		,[Indagacion_Id]
	from
		@TableResult;
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_SET_TU_INDIVIDUO_OLD]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-06
-- Description:	Set a individuo old
-- =============================================
CREATE PROCEDURE [Transunion].[SP_SET_TU_INDIVIDUO_OLD]
	 @Cedula varchar(60)
	,@UserId varchar(60)
AS
BEGIN
	SET NOCOUNT ON;

	declare @CurrentDate datetime = getdate()
	declare @HostName varchar(100) = host_name()
	
	update
		[Transunion].[TU_INDIVIDUO]
	set
		 [Last] = 0
		,[Modi_Date] = @CurrentDate
		,[Modi_UsrId] = @UserId
		,[hostname] = @HostName
	where
			[Cedula] = @Cedula
		and [Last] = 1;

	select
		[Individuo_Id]
	from
		[Transunion].[TU_INDIVIDUO]
	where
			[Cedula] = @Cedula
		and [Last] = 1;		
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_SET_TU_INDIVIDUO_RESUMEN_TRANSACCION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-06
-- Description:	Set a individuo resumen de transaccion
-- =============================================
CREATE PROCEDURE [Transunion].[SP_SET_TU_INDIVIDUO_RESUMEN_TRANSACCION]
	 @Individuo_Id int
	,@Resumen_Transaccion_Id int = null
	,@Categoria varchar(100) = null
	,@Suscriptor varchar(100) = null
	,@CantidadCuentas int
	,@LimiteCredito numeric(18,2)
	,@Balance numeric(18,2)
	,@PctUtilizacion numeric(18,2)
	,@MontoAtraso numeric(18,2)
	,@LimiteCreditoUS numeric(18,2)
	,@BalanceUS numeric(18,2)
	,@PctUtilizacionUS numeric(18,2)
	,@MontoAtrasoUS numeric(18,2)
	,@Moneda varchar(60) = null
	,@UserId varchar(60)
AS
BEGIN
	SET NOCOUNT ON;

	declare @CurrentDate datetime = getdate()
	declare @HostName varchar(100) = host_name()
	declare @TableResult table(
								 [Action] varchar(10)
								,[Individuo_Id] int not null
								,[Resumen_Transaccion_Id] int not null
							  )

	if @Resumen_Transaccion_Id <= 0 or @Resumen_Transaccion_Id is null
	begin
		set @Resumen_Transaccion_Id = isnull((
			select
				max([Resumen_Transaccion_Id]) + 1
			from
				[Transunion].[TU_INDIVIDUO_RESUMEN_TRANSACCION]
			where 
					[Individuo_Id] = @Individuo_Id
		),1) 
	end

    merge [Transunion].[TU_INDIVIDUO_RESUMEN_TRANSACCION] as tt --table target
	using (select  @Individuo_Id,@Resumen_Transaccion_Id,@Categoria,@Suscriptor,@CantidadCuentas
				  ,@LimiteCredito,@Balance,@PctUtilizacion,@MontoAtraso,@LimiteCreditoUS,@BalanceUS
				  ,@PctUtilizacionUS,@MontoAtrasoUS,@Moneda
				  ,@UserId,@CurrentDate,@HostName) 
		as ts --table source
			( [Individuo_Id],[Resumen_Transaccion_Id],[Categoria],[Suscriptor],[CantidadCuentas],[LimiteCredito]
			 ,[Balance],[PctUtilizacion],[MontoAtraso],[LimiteCreditoUS],[BalanceUS],[PctUtilizacionUS],[MontoAtrasoUS],[Moneda]
			 ,UserId,CurrentDate,HostName)
	on (
			tt.Individuo_Id = ts.Individuo_Id
		and tt.[Resumen_Transaccion_Id] = ts.[Resumen_Transaccion_Id]
		)
	when matched then
		update set 
			 tt.Categoria = isnull(ts.Categoria,tt.Categoria)
			,tt.Suscriptor = isnull(ts.Suscriptor,tt.Suscriptor)
			,tt.CantidadCuentas = isnull(ts.CantidadCuentas,tt.CantidadCuentas)
			,tt.LimiteCredito = isnull(ts.LimiteCredito,tt.LimiteCredito)
			,tt.Balance = isnull(ts.Balance,tt.Balance)
			,tt.PctUtilizacion = isnull(ts.PctUtilizacion,tt.PctUtilizacion)
			,tt.MontoAtraso = isnull(ts.MontoAtraso,tt.MontoAtraso)
			,tt.LimiteCreditoUS = isnull(ts.LimiteCreditoUS,tt.LimiteCreditoUS)
			,tt.BalanceUS = isnull(ts.BalanceUS,tt.BalanceUS)
			,tt.PctUtilizacionUS = isnull(ts.PctUtilizacionUS,tt.PctUtilizacionUS)
			,tt.MontoAtrasoUS = isnull(ts.MontoAtrasoUS,tt.MontoAtrasoUS)
			,tt.Moneda = isnull(ts.Moneda,tt.Moneda)
			,tt.Modi_Date = ts.CurrentDate
			,tt.Modi_UsrId = ts.UserId
			,tt.hostname = ts.HostName
	when not matched then
		insert ( [Individuo_Id],[Resumen_Transaccion_Id],[Categoria],[Suscriptor],[CantidadCuentas],[LimiteCredito]
			    ,[Balance],[PctUtilizacion],[MontoAtraso],[LimiteCreditoUS],[BalanceUS],[PctUtilizacionUS],[MontoAtrasoUS],[Moneda]
			    ,Create_Date,Create_UsrId,hostname)
		values ( ts.[Individuo_Id],ts.[Resumen_Transaccion_Id],ts.[Categoria],ts.[Suscriptor],ts.[CantidadCuentas],ts.[LimiteCredito]
                ,ts.[Balance],ts.[PctUtilizacion],ts.[MontoAtraso],ts.[LimiteCreditoUS],ts.[BalanceUS],ts.[PctUtilizacionUS],ts.[MontoAtrasoUS],ts.[Moneda]
			    ,ts.CurrentDate,ts.UserId,ts.HostName)
	output $action
			,isnull(deleted.[Individuo_Id],inserted.[Individuo_Id])
			,isnull(deleted.[Resumen_Transaccion_Id],inserted.[Resumen_Transaccion_Id])
	into @TableResult;

	select
		 [Individuo_Id]
		,[Resumen_Transaccion_Id]
	from
		@TableResult;
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_SET_TU_INDIVIDUO_SENTENCIA]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-17
-- Description:	Set a individuo sentencia
-- =============================================
CREATE PROCEDURE [Transunion].[SP_SET_TU_INDIVIDUO_SENTENCIA]
	 @Individuo_Id int
	,@Sentencia_Id int = null
	,@Numero int = null
	,@Fecha date = null
	,@Tipo varchar(4000) = null
	,@Demandantes varchar(8000) = null
	,@Descripcion varchar(8000) = null
	,@Monto numeric(18,2) = null
	,@AbogadoDemandante varchar(8000) = null
	,@Juez varchar(8000) = null
	,@Tribunal varchar(8000) = null
	,@CiudadTribunal varchar(4000) = null
	,@Observaciones varchar(max) = null
	,@Nota varchar(max) = null
	,@UserId varchar(60)
AS
BEGIN
	SET NOCOUNT ON;

	declare @CurrentDate datetime = getdate()
	declare @HostName varchar(100) = host_name()
	declare @TableResult table(
								 [Action] varchar(10)
								,[Individuo_Id] int not null
								,[Sentencia_Id] int not null
							  )

	if @Sentencia_Id <= 0 or @Sentencia_Id is null
	begin
		set @Sentencia_Id = isnull((
			select
				max([Sentencia_Id]) + 1
			from
				[Transunion].[TU_INDIVIDUO_SENTENCIA]
			where 
					[Individuo_Id] = @Individuo_Id
		),1) 
	end

    merge [Transunion].[TU_INDIVIDUO_SENTENCIA] as tt --table target
	using (select  @Individuo_Id,@Sentencia_Id,@Numero,@Fecha,@Tipo,@Demandantes,@Descripcion,@Monto,@AbogadoDemandante,@Juez,@Tribunal,@CiudadTribunal
				  ,@Observaciones,@Nota
				  ,@UserId,@CurrentDate,@HostName) 
		as ts --table source
			( [Individuo_Id],[Sentencia_Id],[Numero],[Fecha],[Tipo],[Demandantes],[Descripcion],[Monto],[AbogadoDemandante],[Juez],[Tribunal],[CiudadTribunal]
			 ,[Observaciones],[Nota]
			 ,UserId,CurrentDate,HostName)
	on (
			tt.[Individuo_Id] = ts.[Individuo_Id]
		and tt.[Sentencia_Id] = ts.[Sentencia_Id]
		)
	when matched then
		update set 
			 tt.[Numero] = isnull(ts.[Numero],tt.[Numero])
			,tt.[Fecha] = isnull(ts.[Fecha],tt.[Fecha])
			,tt.[Tipo] = isnull(ts.[Tipo],tt.[Tipo])
			,tt.[Demandantes] = isnull(ts.[Demandantes],tt.[Demandantes])
			,tt.[Descripcion] = isnull(ts.[Descripcion],tt.[Descripcion])
			,tt.[Monto] = isnull(ts.[Monto],tt.[Monto])
			,tt.[AbogadoDemandante] = isnull(ts.[AbogadoDemandante],tt.[AbogadoDemandante])
			,tt.[Juez] = isnull(ts.[Juez],tt.[Juez])
			,tt.[Tribunal] = isnull(ts.[Tribunal],tt.[Tribunal])
			,tt.[CiudadTribunal] = isnull(ts.[CiudadTribunal],tt.[CiudadTribunal])
			,tt.[Observaciones] = isnull(ts.[Observaciones],tt.[Observaciones])
			,tt.[Nota] = isnull(ts.[Nota],tt.[Nota])
			,tt.Modi_Date = ts.CurrentDate
			,tt.Modi_UsrId = ts.UserId
			,tt.hostname = ts.HostName
	when not matched then
		insert ( [Individuo_Id],[Sentencia_Id],[Numero],[Fecha],[Tipo],[Demandantes],[Descripcion],[Monto],[AbogadoDemandante]
				,[Juez],[Tribunal],[CiudadTribunal],[Observaciones],[Nota]
			    ,Create_Date,Create_UsrId,hostname)
		values ( ts.[Individuo_Id],ts.[Sentencia_Id],ts.[Numero],ts.[Fecha],ts.[Tipo],ts.[Demandantes],ts.[Descripcion],ts.[Monto],ts.[AbogadoDemandante]
				,ts.[Juez],ts.[Tribunal],ts.[CiudadTribunal],ts.[Observaciones],ts.[Nota]
			    ,ts.CurrentDate,ts.UserId,ts.HostName)
	output $action
			,isnull(deleted.[Individuo_Id],inserted.[Individuo_Id])
			,isnull(deleted.[Sentencia_Id],inserted.[Sentencia_Id])
	into @TableResult;

	select
		 [Individuo_Id]
		,[Sentencia_Id]
	from
		@TableResult;
END


GO
/****** Object:  StoredProcedure [Transunion].[SP_SET_TU_INDIVIDUO_TELEFONO]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-06
-- Description:	Set a individuo telefono
-- =============================================
CREATE PROCEDURE [Transunion].[SP_SET_TU_INDIVIDUO_TELEFONO]
	 @Individuo_Id int
	,@Tipo_Telefono_Id int
	,@Telefono_Id int = null
	,@Numero varchar(60)
	,@Tipo varchar(60)
	,@UserId varchar(60)
AS
BEGIN
	SET NOCOUNT ON;

	declare @CurrentDate datetime = getdate()
	declare @HostName varchar(100) = host_name()
	declare @TableResult table(
								 [Action] varchar(10)
								,[Individuo_Id] int not null
								,[Tipo_Telefono_Id] int not null
								,[Telefono_Id] int not null
							  )

	if @Tipo_Telefono_Id <= 0 or @Tipo_Telefono_Id is null
	begin
		set @Tipo_Telefono_Id = isnull((
			select top 1
				[Tipo_Telefono_Id]
			from
				[Transunion].[TU_TIPO_TELEFONO]
			where 
					[Tipo_Telefono_Desc] = ltrim(rtrim(@Tipo))
		),1) 
	end
	
	if @Telefono_Id <= 0 or @Telefono_Id is null
	begin
		set @Telefono_Id = isnull((
			select
				max([Telefono_Id]) + 1
			from
				[Transunion].[TU_INDIVIDUO_TELEFONO]
			where 
					[Individuo_Id] = @Individuo_Id
				and [Tipo_Telefono_Id] = @Tipo_Telefono_Id
		),1) 
	end

    merge [Transunion].[TU_INDIVIDUO_TELEFONO] as tt --table target
	using (select  @Individuo_Id,@Tipo_Telefono_Id,@Telefono_Id,@Numero,@UserId,@CurrentDate,@HostName) 
		as ts --table source
			( Individuo_Id,Tipo_Telefono_Id,Telefono_Id,Numero,UserId,CurrentDate,HostName)
	on (
			tt.Individuo_Id = ts.Individuo_Id
		and tt.Tipo_Telefono_Id = ts.Tipo_Telefono_Id
		and tt.Telefono_Id = ts.Telefono_Id
		)
	when matched then
		update set 
			 tt.Numero = isnull(ts.Numero,tt.Numero)
			,tt.Modi_Date = ts.CurrentDate
			,tt.Modi_UsrId = ts.UserId
			,tt.hostname = ts.HostName
	when not matched then
		insert ( Individuo_Id,Tipo_Telefono_Id,Telefono_Id,Numero
			    ,Create_Date,Create_UsrId,hostname)
		values ( ts.Individuo_Id,ts.Tipo_Telefono_Id,ts.Telefono_Id,ts.Numero
			    ,ts.CurrentDate,ts.UserId,ts.HostName)
	output $action
			,isnull(deleted.[Individuo_Id],inserted.[Individuo_Id])
			,isnull(deleted.[Tipo_Telefono_Id],inserted.[Tipo_Telefono_Id])
			,isnull(deleted.[Telefono_Id],inserted.[Telefono_Id])
	into @TableResult;

	select
		 [Individuo_Id]
		,[Tipo_Telefono_Id]
		,[Telefono_Id]
	from
		@TableResult;
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_SET_TU_INDIVIDUO_TRANSACCION]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-06
-- Description:	Set a individuo transaccion
-- =============================================
CREATE PROCEDURE [Transunion].[SP_SET_TU_INDIVIDUO_TRANSACCION]
	 @Individuo_Id int
	,@Tipo_Transaccion_Id int
	,@Transaccion_Id int = null
	,@Categoria varchar(100)
	,@Suscriptor varchar(100)
	,@FechaApertura date = null
	,@FechaUltimaAct date = null
	,@FechaVencimiento date = null
	,@FechaUltimaTrx date = null
	,@LimiteCredito numeric(18,2)
	,@Balance numeric(18,2)
	,@MontoAtraso numeric(18,2)
	,@Estatus varchar(100) = null
	,@Comportamiento varchar(100) = null
	,@NoCuotas int
	,@MontoCuotas numeric(18,2)
	,@U_Categoria varchar(100) = null
	,@U_Suscriptor varchar(100) = null
	,@U_FechaApertura varchar(100) = null
	,@U_FechaUltimaAct varchar(100) = null
	,@U_FechaVencimiento varchar(100) = null
	,@U_FechaUltimaTrx varchar(100) = null
	,@U_LimiteCredito varchar(100) = null
	,@U_Balance varchar(100) = null
	,@U_MontoAtraso varchar(100) = null
	,@U_Estatus varchar(100) = null
	,@U_Comportamiento varchar(100) = null
	,@U_NoCuotas varchar(100) = null
	,@U_MontoCuotas varchar(100) = null
	,@Transferido varchar(100) = null
	,@Impugnado varchar(100) = null
	,@D30 varchar(100) = null
	,@D60 varchar(100) = null
	,@D90 varchar(100) = null
	,@D120 varchar(100) = null
	,@D150 varchar(100) = null
	,@U_D30 varchar(100) = null
	,@U_D60 varchar(100) = null
	,@U_D90 varchar(100) = null
	,@U_D120 varchar(100) = null
	,@U_D150 varchar(100) = null
	,@UserId varchar(60)
AS
BEGIN
	SET NOCOUNT ON;

	declare @CurrentDate datetime = getdate()
	declare @HostName varchar(100) = host_name()
	declare @TableResult table(
								 [Action] varchar(10)
								,[Individuo_Id] int not null
								,[Tipo_Transaccion_Id] int not null
								,[Transaccion_Id] int not null
							  )

	if @Transaccion_Id <= 0 or @Transaccion_Id is null
	begin
		set @Transaccion_Id = isnull((
			select
				max([Transaccion_Id]) + 1
			from
				[Transunion].[TU_INDIVIDUO_TRANSACCION]
			where 
					[Individuo_Id] = @Individuo_Id
				and [Tipo_Transaccion_Id] = @Tipo_Transaccion_Id
		),1) 
	end

    merge [Transunion].[TU_INDIVIDUO_TRANSACCION] as tt --table target
	using (select  @Individuo_Id,@Tipo_Transaccion_Id,@Transaccion_Id,@Categoria,@Suscriptor,@FechaApertura,@FechaUltimaAct
				  ,@FechaVencimiento,@FechaUltimaTrx,@LimiteCredito,@Balance,@MontoAtraso,@Estatus,@Comportamiento,@NoCuotas
				  ,@MontoCuotas,@U_Categoria,@U_Suscriptor,@U_FechaApertura,@U_FechaUltimaAct,@U_FechaVencimiento,@U_FechaUltimaTrx
				  ,@U_LimiteCredito,@U_Balance,@U_MontoAtraso,@U_Estatus,@U_Comportamiento,@U_NoCuotas,@U_MontoCuotas,@Transferido
				  ,@Impugnado,@D30,@D60,@D90,@D120,@D150,@U_D30,@U_D60,@U_D90,@U_D120,@U_D150
				  ,@UserId,@CurrentDate,@HostName) 
		as ts --table source
			( [Individuo_Id],[Tipo_Transaccion_Id],[Transaccion_Id],[Categoria],[Suscriptor],[FechaApertura],[FechaUltimaAct],[FechaVencimiento]
			 ,[FechaUltimaTrx],[LimiteCredito],[Balance],[MontoAtraso],[Estatus],[Comportamiento],[NoCuotas],[MontoCuotas],[U_Categoria],[U_Suscriptor]
			 ,[U_FechaApertura],[U_FechaUltimaAct],[U_FechaVencimiento],[U_FechaUltimaTrx],[U_LimiteCredito],[U_Balance],[U_MontoAtraso],[U_Estatus]
			 ,[U_Comportamiento],[U_NoCuotas],[U_MontoCuotas],[Transferido],[Impugnado],[D30],[D60],[D90],[D120],[D150],[U_D30],[U_D60],[U_D90],[U_D120],[U_D150]
			 ,UserId,CurrentDate,HostName)
	on (
			tt.[Individuo_Id] = ts.[Individuo_Id]
		and tt.[Tipo_Transaccion_Id] = ts.[Tipo_Transaccion_Id]
		and tt.[Transaccion_Id] = ts.[Transaccion_Id]
		)
	when matched then
		update set 
			 tt.[Categoria] = isnull(ts.[Categoria],tt.[Categoria])
			,tt.[Suscriptor] = isnull(ts.[Suscriptor],tt.[Suscriptor])
			,tt.[FechaApertura] = isnull(ts.[FechaApertura],tt.[FechaApertura])
			,tt.[FechaUltimaAct] = isnull(ts.[FechaUltimaAct],tt.[FechaUltimaAct])
			,tt.[FechaVencimiento] = isnull(ts.[FechaVencimiento],tt.[FechaVencimiento])
			,tt.[FechaUltimaTrx] = isnull(ts.[FechaUltimaTrx],tt.[FechaUltimaTrx])
			,tt.[LimiteCredito] = isnull(ts.[LimiteCredito],tt.[LimiteCredito])
			,tt.[Balance] = isnull(ts.[Balance],tt.[Balance])
			,tt.[MontoAtraso] = isnull(ts.[MontoAtraso],tt.[MontoAtraso])
			,tt.[Estatus] = isnull(ts.[Estatus],tt.[Estatus])
			,tt.[Comportamiento] = isnull(ts.[Comportamiento],tt.[Comportamiento])
			,tt.[NoCuotas] = isnull(ts.[NoCuotas],tt.[NoCuotas])
			,tt.[MontoCuotas] = isnull(ts.[MontoCuotas],tt.[MontoCuotas])
			,tt.[U_Categoria] = isnull(ts.[U_Categoria],tt.[U_Categoria])
			,tt.[U_Suscriptor] = isnull(ts.[U_Suscriptor],tt.[U_Suscriptor])
			,tt.[U_FechaApertura] = isnull(ts.[U_FechaApertura],tt.[U_FechaApertura])
			,tt.[U_FechaUltimaAct] = isnull(ts.[U_FechaUltimaAct],tt.[U_FechaUltimaAct])
			,tt.[U_FechaVencimiento] = isnull(ts.[U_FechaVencimiento],tt.[U_FechaVencimiento])
			,tt.[U_FechaUltimaTrx] = isnull(ts.[U_FechaUltimaTrx],tt.[U_FechaUltimaTrx])
			,tt.[U_LimiteCredito] = isnull(ts.[U_LimiteCredito],tt.[U_LimiteCredito])
			,tt.[U_Balance] = isnull(ts.[U_Balance],tt.[U_Balance])
			,tt.[U_MontoAtraso] = isnull(ts.[U_MontoAtraso],tt.[U_MontoAtraso])
			,tt.[U_Estatus] = isnull(ts.[U_Estatus],tt.[U_Estatus])
			,tt.[U_Comportamiento] = isnull(ts.[U_Comportamiento],tt.[U_Comportamiento])
			,tt.[U_NoCuotas] = isnull(ts.[U_NoCuotas],tt.[U_NoCuotas])
			,tt.[U_MontoCuotas] = isnull(ts.[U_MontoCuotas],tt.[U_MontoCuotas])
			,tt.[Transferido] = isnull(ts.[Transferido],tt.[Transferido])
			,tt.[Impugnado] = isnull(ts.[Impugnado],tt.[Impugnado])
			,tt.[D30] = isnull(ts.[D30],tt.[D30])
			,tt.[D60] = isnull(ts.[D60],tt.[D60])
			,tt.[D90] = isnull(ts.[D90],tt.[D90])
			,tt.[D120] = isnull(ts.[D120],tt.[D120])
			,tt.[D150] = isnull(ts.[D150],tt.[D150])
			,tt.[U_D30] = isnull(ts.[U_D30],tt.[U_D30])
			,tt.[U_D60] = isnull(ts.[U_D60],tt.[U_D60])
			,tt.[U_D90] = isnull(ts.[U_D90],tt.[U_D90])
			,tt.[U_D120] = isnull(ts.[U_D120],tt.[U_D120])
			,tt.[U_D150] = isnull(ts.[U_D150],tt.[U_D150])
			,tt.Modi_Date = ts.CurrentDate
			,tt.Modi_UsrId = ts.UserId
			,tt.hostname = ts.HostName
	when not matched then
		insert ( [Individuo_Id],[Tipo_Transaccion_Id],[Transaccion_Id],[Categoria],[Suscriptor],[FechaApertura],[FechaUltimaAct],[FechaVencimiento]
				,[FechaUltimaTrx],[LimiteCredito],[Balance],[MontoAtraso],[Estatus],[Comportamiento],[NoCuotas],[MontoCuotas],[U_Categoria],[U_Suscriptor]
				,[U_FechaApertura],[U_FechaUltimaAct],[U_FechaVencimiento],[U_FechaUltimaTrx],[U_LimiteCredito],[U_Balance],[U_MontoAtraso],[U_Estatus]
				,[U_Comportamiento],[U_NoCuotas],[U_MontoCuotas],[Transferido],[Impugnado],[D30],[D60],[D90],[D120],[D150],[U_D30],[U_D60],[U_D90],[U_D120],[U_D150]
			    ,Create_Date,Create_UsrId,hostname)
		values ( ts.[Individuo_Id],ts.[Tipo_Transaccion_Id],ts.[Transaccion_Id],ts.[Categoria],ts.[Suscriptor],ts.[FechaApertura],ts.[FechaUltimaAct]
				,ts.[FechaVencimiento],ts.[FechaUltimaTrx],ts.[LimiteCredito],ts.[Balance],ts.[MontoAtraso],ts.[Estatus],ts.[Comportamiento],ts.[NoCuotas]
				,ts.[MontoCuotas],ts.[U_Categoria],ts.[U_Suscriptor],ts.[U_FechaApertura],ts.[U_FechaUltimaAct],ts.[U_FechaVencimiento],ts.[U_FechaUltimaTrx]
				,ts.[U_LimiteCredito],ts.[U_Balance],ts.[U_MontoAtraso],ts.[U_Estatus],ts.[U_Comportamiento],ts.[U_NoCuotas],ts.[U_MontoCuotas],ts.[Transferido]
				,ts.[Impugnado],ts.[D30],ts.[D60],ts.[D90],ts.[D120],ts.[D150],ts.[U_D30],ts.[U_D60],ts.[U_D90],ts.[U_D120],ts.[U_D150]
			    ,ts.CurrentDate,ts.UserId,ts.HostName)
	output $action
			,isnull(deleted.[Individuo_Id],inserted.[Individuo_Id])
			,isnull(deleted.[Tipo_Transaccion_Id],inserted.[Tipo_Transaccion_Id])
			,isnull(deleted.[Transaccion_Id],inserted.[Transaccion_Id])
	into @TableResult;

	select
		 [Individuo_Id]
		,[Tipo_Transaccion_Id]
		,[Transaccion_Id]
	from
		@TableResult;
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_UPDATE_ST_COMPANY_USER_LAST_LOGIN_DATE]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-08
-- Description:	Update last login date
-- =============================================
CREATE PROCEDURE [Transunion].[SP_UPDATE_ST_COMPANY_USER_LAST_LOGIN_DATE]
	  @User_Name varchar(60)
AS
BEGIN
	SET NOCOUNT ON;

	update
		[Global].[ST_COMPANY_USER]
	set
		 [Last_LogIn_Date] = getdate()
		,[Login_Attempts] = 0
		,[Modi_Date] = getdate()
		,[Modi_UsrId] = 2118
	where
		[User_Name] = @User_Name;

	select @User_Name as [User_Name];
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_UPDATE_ST_COMPANY_USER_LOCK]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-08
-- Description:	Lock user
-- =============================================
CREATE PROCEDURE [Transunion].[SP_UPDATE_ST_COMPANY_USER_LOCK]
	 @User_Name varchar(60)
AS
BEGIN
	SET NOCOUNT ON;

	update
		[Global].[ST_COMPANY_USER]
	set
		 [User_Lock] = 1
		,[Lock_Date] = getdate()
		,[Modi_Date] = getdate()
		,[Modi_UsrId] = 2118
	where
		[User_Name] = @User_Name;

	select @User_Name as [User_Name];
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_UPDATE_ST_COMPANY_USER_LOGIN_ATTEMPT]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-0
-- Description:	Update fail login
-- =============================================
CREATE PROCEDURE [Transunion].[SP_UPDATE_ST_COMPANY_USER_LOGIN_ATTEMPT]
	  @User_Name varchar(60)
AS
BEGIN
	SET NOCOUNT ON;

	update
		[Global].[ST_COMPANY_USER]
	set
		 [Login_Attempts] = [Login_Attempts] + 1
		,[Modi_Date] = getdate()
		,[Modi_UsrId] = 2118
	where
		[User_Name] = @User_Name;

	select 
		[Login_Attempts]
	from
		[Global].[ST_COMPANY_USER]
	where
		[User_Name] = @User_Name;
END

GO
/****** Object:  StoredProcedure [Transunion].[SP_UPDATE_ST_COMPANY_USER_UNLOCK]    Script Date: 3/12/2021 3:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Rabel Obispo
-- Create date: 2016-08-08
-- Description:	Unlock user
-- =============================================
CREATE PROCEDURE [Transunion].[SP_UPDATE_ST_COMPANY_USER_UNLOCK]
	 @User_Name varchar(60)
AS
BEGIN
	SET NOCOUNT ON;

	update
		[Global].[ST_COMPANY_USER]
	set
		 [User_Lock] = 0
		,[Lock_Date] = null
		,[Modi_Date] = getdate()
		,[Modi_UsrId] = 2118
	where
		[User_Name] = @User_Name;

	select @User_Name as [User_Name];
END

GO
