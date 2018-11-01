USE [SysFlexSeguros]
GO

/****** Object:  Table [dbo].[Log_TraspasoCartera]    Script Date: 10/5/2017 5:56:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Log_TraspasoCartera](
	[logId] [int] IDENTITY(1,1) NOT NULL,
	[fechaTraspaso] [datetime] NOT NULL,
	[poliza] [varchar](50) NOT NULL,
	[IntermediarioOrigen] [int] NOT NULL,
	[IntermediarioDestino] [int] NOT NULL,
	[usuario] [varchar](100) NOT NULL,
	[transferido] [bit] NOT NULL,
 CONSTRAINT [PK_Log_TraspasoCartera] PRIMARY KEY CLUSTERED 
(
	[logId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Log_TraspasoCartera] ADD  CONSTRAINT [DF_Log_TraspasoCartera_fechaTraspaso]  DEFAULT (getdate()) FOR [fechaTraspaso]
GO

ALTER TABLE [dbo].[Log_TraspasoCartera] ADD  CONSTRAINT [DF__Log_Trasp__trans__70210BCE]  DEFAULT ((1)) FOR [transferido]
GO


