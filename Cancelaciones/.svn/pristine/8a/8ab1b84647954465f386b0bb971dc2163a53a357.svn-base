USE [SysFlexSeguros]
GO

/****** Object:  Table [dbo].[ReassignNCF_log]    Script Date: 9/14/2017 4:13:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ReassignNCF_log](
	[id] [int] NOT NULL,
	[Poliza] [varchar](50) NOT NULL,
	[Valor_old] [decimal](18, 0) NULL,
	[ValorItbis_old] [decimal](18, 0) NULL,
	[Ncf_old] [varchar](50) NOT NULL,
	[Valor_new] [decimal](18, 0) NULL,
	[ValorItbis_new] [decimal](18, 0) NULL,
	[Ncf_new] [varchar](50) NOT NULL,
	[fecha_actualizacion] [datetime] NULL,
	[Factura_old] [varchar](50) NULL,
	[Factura_new] [varchar](50) NULL,
 CONSTRAINT [PK_ReassignNCF_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/****** Object:  Index [IX_ReassignNCF_log_01]    Script Date: 9/14/2017 4:14:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_ReassignNCF_log_01] ON [dbo].[ReassignNCF_log]
(
	[id] ASC,
	[Poliza] ASC,
	[Ncf_old] ASC,
	[Ncf_new] ASC,
	[Valor_old] ASC,
	[ValorItbis_old] ASC,
	[Valor_new] ASC,
	[ValorItbis_new] ASC,
	[fecha_actualizacion] ASC,
	[Factura_old] ASC,
	[Factura_new] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


