USE [dbventas]
GO
/****** Object:  Table [dbo].[trabajador]    Script Date: 28/06/2018 21:38:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trabajador](
	[idtrabajador] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellidos] [varchar](40) NOT NULL,
	[sexo] [char](10) NOT NULL,
	[Fecha_nac] [datetime] NOT NULL,
	[num_documento] [varchar](15) NOT NULL,
	[direccion] [varchar](100) NOT NULL,
	[telefono] [varchar](15) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[StatusE] [bit] NOT NULL,
	[FechaAdiciona] [datetime] NULL,
	[FechaModifica] [datetime] NULL,
	[UsuarioAdiciona] [varchar](50) NULL,
	[UsuarioModifica] [varchar](50) NULL,
 CONSTRAINT [PK_trabajador] PRIMARY KEY CLUSTERED 
(
	[idtrabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[wv_get_employees]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE VIEW [dbo].[wv_get_employees]
	as
	
	 SELECT
	   [idtrabajador]  
      ,upper(apellidos+' '+nombre)[NombreCompleto]      
      ,[sexo]
      ,[Fecha_nac]
      ,[num_documento]
      ,[direccion]
      ,[telefono]
      ,[email]
      ,iif([StatusE]=1,'Activo','Inactivo')[Estado]
      ,[FechaAdiciona]
      ,[FechaModifica]
      ,[UsuarioAdiciona]
      ,[UsuarioModifica]
  FROM [dbventas].[dbo].[trabajador]
  where StatusE=1
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[idcliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellidos] [varchar](40) NULL,
	[sexo] [char](10) NULL,
	[fecha_nacimiento] [date] NULL,
	[tipo_documento] [varchar](20) NOT NULL,
	[num_documento] [varchar](15) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](15) NULL,
	[email] [varchar](50) NULL,
	[statu] [bit] NULL,
	[CodigoCliente]  AS ((CONVERT([varchar],datepart(day,[fecha_nacimiento]))+'-0')+CONVERT([varchar],[idcliente])),
	[FechaAdiciona] [datetime] NULL,
	[FechaModifica] [datetime] NULL,
	[UsuarioAdiciona] [varchar](50) NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[HostName] [varchar](200) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuentas_x_cobrar]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuentas_x_cobrar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[valor] [decimal](18, 2) NOT NULL,
	[pagado] [bit] NOT NULL,
	[usuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_cuentas_x_cobrar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[get_client_parameter]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create view [dbo].[get_client_parameter]
  as  
  
  select 
  c.id
  ,c.[id_cliente]
  ,cl.CodigoCliente
  ,cl.num_documento 
  ,(cl.nombre +''+ cl.apellidos) NombreCompleto   
  ,[fecha]
  ,[valor]
  ,[pagado] 
    
  from [dbventas].[dbo].[cuentas_x_cobrar]c
  left join dbo.cliente cl

  on c.id_cliente=cl.idcliente

  where --cl.CodigoCliente='6-015'
         cl.statu=1
		and c.pagado=0
GO
/****** Object:  View [dbo].[VW_CLIENTES_LOAD]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[VW_CLIENTES_LOAD]

AS
SELECT [idcliente]
      ,CodigoCliente
      ,upper(apellidos+' '+nombre)[Nombre_Completo_Empleado]
      ,[Sexo]
      ,[fecha_nacimiento][Fecha Nacimiento]
      ,[tipo_documento][Tipo_de_Documento]
      ,[num_documento][Numero_Identificación]
      ,[direccion][Direccion]
      ,[telefono][Telefono]
      ,[email][Correo_electronico]
      --iif([statu]=0,'Inactivo','Activo')[Status]
	  --,statu
  FROM [dbventas].[dbo].[cliente] where statu=1
GO
/****** Object:  View [dbo].[wv_get_cliente_deuda]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE view [dbo].[wv_get_cliente_deuda]

as

SELECT cc.id
      ,cc.id_cliente
	  ,c.num_documento
	  ,c.CodigoCliente
	  ,(c.nombre+' '+c.apellidos) as NombreCompleto
	  ,cc.fecha
	  ,cc.valor
	  ,cc.pagado
	  FROM dbo.[cuentas_x_cobrar]cc 
left join dbo.[cliente]c

on 

cc.id_cliente=c.idcliente

where c.statu=1   and cc.pagado=0
and valor>0

 
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Clave] [varchar](50) NOT NULL,
	[RolID] [int] NOT NULL,
	[Statud] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioTrabajador]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioTrabajador](
	[id] [int] NOT NULL,
	[id_trabajador] [int] NULL,
	[id_usuario] [int] NULL,
	[fecha_asignacion] [datetime] NULL,
	[fecha_deasinacion] [datetime] NULL,
	[status_assignacion] [bit] NULL,
	[usuarioAdiciona] [varchar](50) NULL,
	[usuarioModifica] [varchar](50) NULL,
	[fechaAdiciona] [datetime] NULL,
	[fechaModifica] [datetime] NULL,
 CONSTRAINT [PK_UsuarioTrabajador] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[wv_usuario_trabajador]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[wv_usuario_trabajador]
as

SELECT u.RolID,(t.apellidos+' '+t.nombre)[NombreCompleto],u.Clave,u.Usuario

FROM [dbventas].[dbo].[UsuarioTrabajador]ut inner join 
dbo.trabajador t 

on 
ut.id_trabajador=t.idtrabajador

inner join USERS u

on ut.id_trabajador=u.id
where u.Statud=1 and t.StatusE=1
                 and ut.fecha_deasinacion is null
				 and ut.status_assignacion=1
GO
/****** Object:  View [dbo].[ROL_USER]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ROL_USER] 
AS
SELECT  RolID
FROM    dbo.USERS WHERE [Statud]=1
GO
/****** Object:  Table [dbo].[articulo]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articulo](
	[idarticulo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[idcategoria] [int] NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Imag_Url] [varchar](250) NULL,
	[descripcion] [varchar](200) NULL,
	[precioVenta] [decimal](9, 2) NULL,
	[precioCompra] [decimal](9, 2) NULL,
	[cantidad] [decimal](9, 2) NULL,
	[estado] [bit] NULL,
	[idProveedor] [int] NOT NULL,
	[CodigoBarra]  AS (CONVERT([varchar],(upper(substring([nombre],(1),(4)))+'00000')+CONVERT([varchar],[idarticulo]))),
 CONSTRAINT [PK_articulo] PRIMARY KEY CLUSTERED 
(
	[idarticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[idcategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [nchar](256) NULL,
 CONSTRAINT [PK_categoria] PRIMARY KEY CLUSTERED 
(
	[idcategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuentas_x_pagar]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuentas_x_pagar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_proveedor] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[valor] [decimal](18, 2) NOT NULL,
	[pagado] [bit] NOT NULL,
	[usuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_cuentas_x_pagar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_ingreso]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_ingreso](
	[iddetalle_ingreso] [int] IDENTITY(1,1) NOT NULL,
	[idingreso] [int] NOT NULL,
	[idarticulo] [int] NOT NULL,
	[precio_compra] [decimal](9, 2) NOT NULL,
	[precio_venta] [decimal](9, 2) NOT NULL,
	[stock_inicial] [int] NOT NULL,
	[stock_actual] [int] NOT NULL,
	[fecha_produccion] [date] NOT NULL,
	[fecha_vencimiento] [date] NOT NULL,
 CONSTRAINT [PK_detalle_ingreso] PRIMARY KEY CLUSTERED 
(
	[iddetalle_ingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_venta]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_venta](
	[iddetalle_venta] [int] IDENTITY(1,1) NOT NULL,
	[idventa] [int] NOT NULL,
	[iddetalle_ingreso] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio_venta] [money] NOT NULL,
	[descuento] [money] NOT NULL,
 CONSTRAINT [PK_detalle_venta] PRIMARY KEY CLUSTERED 
(
	[iddetalle_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ingreso]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingreso](
	[idingreso] [int] IDENTITY(1,1) NOT NULL,
	[CodigBarra] [int] NULL,
	[idproveedor] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo_comprobante] [varchar](20) NOT NULL,
	[igv] [decimal](9, 2) NOT NULL,
	[FechaAdiciona] [datetime] NOT NULL,
	[FechaModifica] [datetime] NULL,
	[UsuarioAdiciona] [varchar](50) NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
 CONSTRAINT [PK_ingreso] PRIMARY KEY CLUSTERED 
(
	[idingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimientosPagosYcobranzas]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimientosPagosYcobranzas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DetalleMov] [varchar](50) NULL,
	[fechaPago] [datetime] NULL,
	[idFactura] [varchar](60) NULL,
	[cantidadPagada] [decimal](9, 2) NULL,
	[statud] [bit] NULL,
	[usuarioPago] [varchar](50) NULL,
	[id_cxc] [int] NULL,
	[id_cxp] [int] NULL,
 CONSTRAINT [PK__Movimien__3213E83F5BDAEDBE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ncf_Comprovante]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ncf_Comprovante](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Comprovante_Fiscal] [varchar](50) NULL,
	[Number] [varchar](50) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Ncf_Comprovante] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[idproveedor] [int] IDENTITY(1,1) NOT NULL,
	[razon_social] [varchar](150) NOT NULL,
	[NombreProveedor] [varchar](50) NOT NULL,
	[tipo_documento] [varchar](20) NOT NULL,
	[num_documento] [varchar](15) NOT NULL,
	[direccion] [nchar](100) NULL,
	[telefono] [varchar](10) NULL,
	[email] [varchar](50) NULL,
	[url] [varchar](100) NULL,
	[statu] [bit] NULL,
	[FechaAdiciona] [datetime] NULL,
	[FechaModifica] [datetime] NULL,
	[UsuarioAdiciona] [varchar](50) NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[HostName] [varchar](200) NULL,
 CONSTRAINT [PK_proveedor] PRIMARY KEY CLUSTERED 
(
	[idproveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROLES]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROLES](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Grupo] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[venta]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venta](
	[idventa] [int] IDENTITY(1,1) NOT NULL,
	[idcliente] [int] NOT NULL,
	[idtrabajador] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo_comprobante] [varchar](20) NOT NULL,
	[serie] [varchar](4) NOT NULL,
	[correlativo] [varchar](7) NOT NULL,
	[itbis] [decimal](9, 2) NOT NULL,
 CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED 
(
	[idventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[articulo] ADD  CONSTRAINT [DF__articulo__estado__3F466844]  DEFAULT ((0)) FOR [estado]
GO
ALTER TABLE [dbo].[cuentas_x_cobrar] ADD  DEFAULT (getdate()) FOR [fecha]
GO
ALTER TABLE [dbo].[cuentas_x_cobrar] ADD  DEFAULT ((0)) FOR [pagado]
GO
ALTER TABLE [dbo].[cuentas_x_pagar] ADD  DEFAULT (getdate()) FOR [fecha]
GO
ALTER TABLE [dbo].[cuentas_x_pagar] ADD  DEFAULT ((0)) FOR [pagado]
GO
ALTER TABLE [dbo].[USERS] ADD  DEFAULT ((0)) FOR [Statud]
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD  CONSTRAINT [FK_articulo_categoria] FOREIGN KEY([idcategoria])
REFERENCES [dbo].[categoria] ([idcategoria])
GO
ALTER TABLE [dbo].[articulo] CHECK CONSTRAINT [FK_articulo_categoria]
GO
ALTER TABLE [dbo].[cuentas_x_cobrar]  WITH CHECK ADD  CONSTRAINT [FK_cuentas_x_cobrar_cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[cliente] ([idcliente])
GO
ALTER TABLE [dbo].[cuentas_x_cobrar] CHECK CONSTRAINT [FK_cuentas_x_cobrar_cliente]
GO
ALTER TABLE [dbo].[cuentas_x_pagar]  WITH CHECK ADD  CONSTRAINT [FK_cuentas_x_pagar_proveedor] FOREIGN KEY([id_proveedor])
REFERENCES [dbo].[proveedor] ([idproveedor])
GO
ALTER TABLE [dbo].[cuentas_x_pagar] CHECK CONSTRAINT [FK_cuentas_x_pagar_proveedor]
GO
ALTER TABLE [dbo].[detalle_ingreso]  WITH CHECK ADD  CONSTRAINT [FK_detalle_ingreso_articulo] FOREIGN KEY([idarticulo])
REFERENCES [dbo].[articulo] ([idarticulo])
GO
ALTER TABLE [dbo].[detalle_ingreso] CHECK CONSTRAINT [FK_detalle_ingreso_articulo]
GO
ALTER TABLE [dbo].[detalle_ingreso]  WITH CHECK ADD  CONSTRAINT [FK_detalle_ingreso_ingreso] FOREIGN KEY([idingreso])
REFERENCES [dbo].[ingreso] ([idingreso])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_ingreso] CHECK CONSTRAINT [FK_detalle_ingreso_ingreso]
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_detalle_ingreso] FOREIGN KEY([iddetalle_ingreso])
REFERENCES [dbo].[detalle_ingreso] ([iddetalle_ingreso])
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_detalle_ingreso]
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_venta] FOREIGN KEY([idventa])
REFERENCES [dbo].[venta] ([idventa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_venta]
GO
ALTER TABLE [dbo].[MovimientosPagosYcobranzas]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosPagosYcobranzas_cuentas_x_cobrar] FOREIGN KEY([id_cxc])
REFERENCES [dbo].[cuentas_x_cobrar] ([id])
GO
ALTER TABLE [dbo].[MovimientosPagosYcobranzas] CHECK CONSTRAINT [FK_MovimientosPagosYcobranzas_cuentas_x_cobrar]
GO
ALTER TABLE [dbo].[MovimientosPagosYcobranzas]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosPagosYcobranzas_cuentas_x_pagar] FOREIGN KEY([id_cxp])
REFERENCES [dbo].[cuentas_x_pagar] ([id])
GO
ALTER TABLE [dbo].[MovimientosPagosYcobranzas] CHECK CONSTRAINT [FK_MovimientosPagosYcobranzas_cuentas_x_pagar]
GO
ALTER TABLE [dbo].[USERS]  WITH CHECK ADD  CONSTRAINT [FK_USERS_ROLES] FOREIGN KEY([RolID])
REFERENCES [dbo].[ROLES] ([id])
GO
ALTER TABLE [dbo].[USERS] CHECK CONSTRAINT [FK_USERS_ROLES]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_cliente] FOREIGN KEY([idcliente])
REFERENCES [dbo].[cliente] ([idcliente])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_cliente]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_trabajador] FOREIGN KEY([idtrabajador])
REFERENCES [dbo].[trabajador] ([idtrabajador])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_trabajador]
GO
/****** Object:  StoredProcedure [dbo].[LIST_ARTICULOS_X_CODIGO]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LIST_ARTICULOS_X_CODIGO]
@CODIGO VARCHAR(50),
@COPIAS INT
AS
BEGIN
DECLARE @STMT VARCHAR(MAX);
DECLARE @QUERY VARCHAR(1000);
DECLARE @COUNTER INT;

SET @COUNTER = 1;
SET @QUERY = '';

SET @STMT = ('SELECT * FROM DBO.articulo WHERE CodigoBarra =' + CHAR(39) + UPPER(@CODIGO) + CHAR(39)); 

WHILE(@COUNTER <= @COPIAS)
BEGIN
  IF(@COUNTER = @COPIAS)
    BEGIN
	  SET @QUERY = @QUERY + @STMT;
	END
  ELSE
    BEGIN
	  SET @QUERY = @QUERY + @STMT + CHAR(13) + 'UNION ALL' + CHAR(13)
	END
  SET @COUNTER = @COUNTER + 1;
END

EXEC(@QUERY)
END
GO
/****** Object:  StoredProcedure [dbo].[ListaProveedores]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListaProveedores]
@id int

as
begin
SELECT [idproveedor]
      ,[razon_social]
      ,[NombreProveedor]
      ,[tipo_documento]
      ,[num_documento]
      ,[direccion]
      ,[telefono]
      ,[email]
      ,[url]
      ,[statu]
      ,[FechaAdiciona]    
      ,[UsuarioAdiciona]      
  FROM [dbventas].[dbo].[proveedor] where idproveedor=@id

  end
GO
/****** Object:  StoredProcedure [dbo].[REGISTRAR_USUARIO]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[REGISTRAR_USUARIO]
@id INT,
@Usuario VARCHAR(50),
@Clave VARCHAR(50),
@RolID int,
@Statud bit
AS
BEGIN
  IF(@id <= 0)
    BEGIN
      INSERT INTO [dbo].[USERS]
             ([Usuario]
             ,[Clave]
             ,[RolID]
             ,[Statud])
       VALUES
           (@Usuario
           ,@Clave
           ,@RolID
           ,@Statud)
    END
  ELSE
    BEGIN
	  UPDATE [dbo].[USERS]
	  SET Usuario = @Usuario,
	      Clave = @Clave,
		  RolID = @RolID,
		  Statud = @Statud
	  WHERE id = @id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CUENTA_POR_COBRAR]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CUENTA_POR_COBRAR]
 @id INT
,@id_cliente INT
,@valor DECIMAL(9,2)
,@pagado DECIMAL(9,2)
,@usuario VARCHAR(50)
,@idFactura varchar(50)

AS

BEGIN 
IF EXISTS(SELECT * FROM dbo.cuentas_x_cobrar where id=@id)

UPDATE dbo.cuentas_x_cobrar set valor=@valor,usuario=@usuario
where id=id

--else

--insert into dbo.cuentas_x_cobrar values(
--@id_cliente
--,GETDATE()
--,@valor
--,@pagado
--,@usuario
--)
 

INSERT INTO MovimientosPagosYcobranzas 
SELECT 
      'Cuenta por Cobrar'[DetalleMov]
      ,getdate()[fechaPago]
      ,@idFactura[idFactura]
      ,@valor[cantidadPagada]
      ,1[statud]
      ,@usuario[usuarioPago]
      ,@id [id_cxc]
      ,null[id_cxp]


END
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_ARTICULO]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_GET_ARTICULO]


@codigo varchar(30)
,@nom varchar(50)

AS

BEGIN

SELECT        idarticulo, nombre, idcategoria, Codigo, Imag_Url, descripcion, precioVenta, precioCompra, cantidad, estado, idProveedor, CodigoBarra
FROM            dbo.articulo
WHERE CodigoBarra LIKE '%'+@codigo+'%' or nombre like '%'+@nom+'%'

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_ARTICULO_LOAD]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_GET_ARTICULO_LOAD]
as 
BEGIN
SELECT [idarticulo]
      ,[codigo]
      ,[nombre]
      ,[idcategoria]
      ,[Imag_Url]
      ,[descripcion]
      ,[precioVenta]
      ,[precioCompra]
      ,[cantidad]
      ,[estado]
      ,[idProveedor]
  FROM [dbventas].[dbo].[articulo]

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_ARTICULOS_BUSCAR]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_GET_ARTICULOS_BUSCAR]
@codigo VARCHAR(50)
,@nombre VARCHAR(50)

as 
BEGIN

select            idarticulo
                 ,codigo
	             ,nombre
	             ,idcategoria
	             ,Imag_Url
	             ,descripcion
	             ,precioVenta
	             ,precioCompra 
from dbo.articulo
where 
codigo=@codigo or nombre like +'%'+ @nombre+'%'

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_BUSCAR_PROVEEDOR]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_GET_BUSCAR_PROVEEDOR]
@documento varchar(15),
@telefono varchar(15),
@nombre varchar(60)
as
SELECT [idproveedor]
      ,[razon_social]
      ,[NombreProveedor]
      ,[tipo_documento]
      ,[num_documento]
      ,[direccion]
      ,[telefono]
      ,[email]
      ,[url]
      ,iif([statu]=1,'Activo','Inactivo')[Estado]
      
  FROM [dbventas].[dbo].[proveedor]

  where NombreProveedor like '%'+@nombre+'%' or telefono=@telefono or num_documento=@documento
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_CATEGORIA_BUSCAR]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_GET_CATEGORIA_BUSCAR]

@nombre VARCHAR(50)

as 
BEGIN

select          idcategoria
               ,nombre
			   ,descripcion
from dbo.categoria
where 
nombre like '%'+@nombre+'%'

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_Categoria_LOAD]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_GET_Categoria_LOAD]


as
begin 
select * from dbo.categoria
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_CLIENTES_BUSCAR]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_GET_CLIENTES_BUSCAR]

@CodigoCliente varchar(60),
@Identificacion varchar(15),
@Nombre_Completo varchar(50),
@Telefono  varchar(15)
as 
BEGIN
select * from VW_CLIENTES_LOAD
where 
     [CodigoCliente]=@CodigoCliente 
or [Numero_Identificación]=@Identificacion
or [Nombre_Completo_Empleado] LIKE @Nombre_Completo+'%'
OR [Telefono]=@Telefono
END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_clientes_deudores]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_get_clientes_deudores]

as

begin 

select * from [dbo].[wv_get_cliente_deuda]
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_CLIENTES_LOAD]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_GET_CLIENTES_LOAD]
as 
BEGIN
SELECT [idcliente]
      ,[nombre]
      ,[apellidos]
      ,[sexo]
      ,[fecha_nacimiento]
      ,[tipo_documento]
      ,[num_documento]
      ,[direccion]
      ,[telefono]
      ,[email]
      ,[CodigoCliente]
      FROM [dbventas].[dbo].[cliente]
	  where statu=1

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_COMBOBOX_CATEGORIA]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


      --codigo]
      --nombre]
      --idcategoria]
      --Imag_Url]
      --descripcion]
      --precioVenta]
      --precioCompra]
      --cantidad]
      --estado]
      --idProveedor]

	  create PROC [dbo].[SP_GET_COMBOBOX_CATEGORIA]
	  AS
	  BEGIN
	  SELECT idcategoria,nombre FROM categoria ORDER BY nombre ASC
	  END
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_COMBOBOX_CLIENTE]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[SP_GET_COMBOBOX_CLIENTE]

AS

BEGIN 
SELECT idcliente,upper(nombre +' '+apellidos)as NombreCompleto FROM dbo.cliente  
order by NombreCompleto
END
  
  --select 
  --c.id
  --,c.[id_cliente]
  --,cl.CodigoCliente
  --,cl.num_documento 
  --,(cl.nombre +''+ cl.apellidos) NombreCompleto   
  --,[fecha]
  --,[valor]
  --,[pagado] 
    
  --from [dbventas].[dbo].[cuentas_x_cobrar]c
  --left join dbo.cliente cl

  --on c.id_cliente=cl.idcliente

  --where cl.CodigoCliente='6-015'
  --      and cl.statu=1
		--and c.pagado=0

GO
/****** Object:  StoredProcedure [dbo].[SP_GET_COMBOBOX_PROVEEDOR]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


      --codigo]
      --nombre]
      --idcategoria]
      --Imag_Url]
      --descripcion]
      --precioVenta]
      --precioCompra]
      --cantidad]
      --estado]
      --idProveedor]

	  CREATE PROC [dbo].[SP_GET_COMBOBOX_PROVEEDOR]
	  AS
	  BEGIN
	  SELECT idproveedor,NombreProveedor FROM proveedor ORDER BY NombreProveedor ASC
	  END
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_EMPLOYEES]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_GET_EMPLOYEES]
 @NombreC varchar(80)
,@num_cedula varchar(15)
,@telefono varchar(15)

as

begin


SELECT [idtrabajador]
      ,[NombreCompleto]
      ,[sexo]
      ,[num_documento]
      ,[direccion]
      ,[telefono]
      ,[email]
      ,[Estado]
   
  FROM [dbventas].[dbo].[wv_get_employees]
where 
     NombreCompleto like '%'+@NombreC+'%'
  or telefono=@telefono
  or num_documento=@num_cedula
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_PROVEEDOR_BUSCAR]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_GET_PROVEEDOR_BUSCAR]
@documento varchar(15),
@telefono varchar(15),
@nombre varchar(60)
as
SELECT [idproveedor]
      ,[razon_social]
      ,[NombreProveedor]
      ,[tipo_documento]
      ,[num_documento]
      ,[direccion]
      ,[telefono]
      ,[email]
      ,[url]
      ,[statu]
      ,[FechaAdiciona]
      ,[UsuarioAdiciona]      
  FROM [dbventas].[dbo].[proveedor]

  where NombreProveedor like '%'+@nombre+'%' or telefono=@telefono or num_documento=@documento
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_PROVEEDOR_LOAD]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_GET_PROVEEDOR_LOAD]
as
SELECT [idproveedor]
      ,[razon_social]
      ,[NombreProveedor]
      ,[tipo_documento]
      ,[num_documento]
      ,[direccion]
      ,[telefono]
      ,[email]
      ,[url]
        
      
  FROM [dbventas].[dbo].[proveedor]
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_ROLL_DROP]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[SP_GET_ROLL_DROP]

AS

BEGIN 
SELECT id,Nombre FROM dbo.ROLES
END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_searche_client_pagos]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE proc [dbo].[sp_get_searche_client_pagos]
@num_documento varchar(15)
,@codigoCliente varchar(62)
,@NombComp varchar(80)

as

begin 

select * from get_client_parameter
where codigocliente =@codigoCliente or num_documento=@num_documento or 
NombreCompleto like '%'+@NombComp+'%%'
end 
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_USER_BY_NAME]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GET_USER_BY_NAME]
@USERNAME VARCHAR(50)
AS 
SELECT [id]
      ,[Usuario]
      ,[Clave]
      ,[RolID]
      ,[Statud]
  FROM [dbo].[USERS]
  WHERE Usuario = @USERNAME
GO
/****** Object:  StoredProcedure [dbo].[SP_LOGIN]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LOGIN]
@usuario varchar(50),
@contrasena varchar(50),
@NombreC varchar(80) output,
@rolid int output
AS
BEGIN
 
 SELECT @rolid=RolID,@NombreC=NombreCompleto
from dbo.wv_usuario_trabajador 
WHERE Usuario = @usuario and Clave = @contrasena
 
 
 IF  (@rolid<=0)
 BEGIN
   SET @rolid = 0
   SET @NombreC = ''
 END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_SET_CATEGORIA]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[SP_SET_CATEGORIA]
@idCat int
,@nom varchar(50)
,@Desc varchar(256)

as

begin 
if exists(select * from categoria where idcategoria=@idCat)
update categoria set nombre=@nom,descripcion=@Desc where idcategoria=@idCat
else

insert into categoria (nombre,descripcion)values(@nom,@Desc)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_SET_Categoria_UPDATE_INSERT]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_SET_Categoria_UPDATE_INSERT]

@IdCategoria int,
@NomCategiria VARCHAR(50),
@Descripcion varchar(256)

as

begin 
if exists(select * from dbo.categoria where idcategoria=@IdCategoria)
update dbo.categoria set nombre=@NomCategiria,descripcion=@Descripcion
where idcategoria=@IdCategoria
else

insert into dbo.categoria  values(@NomCategiria,@Descripcion)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_SET_CLIENTE_DELETE]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[SP_SET_CLIENTE_DELETE]
 
     
 @idcliente INT 
--,@status    BIT
,@UsuarioModifica VARCHAR(50)

AS

BEGIN
UPDATE dbo.cliente set  statu=0
                       ,UsuarioAdiciona=@UsuarioModifica
					    where idcliente=@idcliente

END
GO
/****** Object:  StoredProcedure [dbo].[SP_SET_CLIENTE_INSERT_UPDATE]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SET_CLIENTE_INSERT_UPDATE]
    
	   @idcliente         int
      ,@nombre			  varchar(50)
      ,@apellidos		  varchar(40)
      ,@sexo			  char(10)
      ,@fecha_nacimiento  date
      ,@tipo_documento	  varchar(20)
      ,@num_documento	  varchar(8)
      ,@direccion		  varchar(100)
      ,@telefono		  varchar(15)
      ,@email			  varchar(50)
	  ,@status            bit
	  ,@FechaAdiciona     datetime
      ,@FechaModifica     datetime
      ,@UsuarioAdiciona   varchar(50)
      --,@UsuarioModifica	  varchar(50)
                
AS

BEGIN
IF EXISTS(select * from dbo.cliente where idcliente=@idcliente)

UPDATE dbo.cliente SET      
	 				   nombre		     =	@nombre			
					   ,apellidos	     =	@apellidos		
					   ,sexo			 =	@sexo			
					   ,fecha_nacimiento =	@fecha_nacimiento
					   ,tipo_documento	 =	@tipo_documento	
					   ,num_documento	 =	@num_documento	
					   ,direccion		 =	@direccion		
					   ,telefono		 =	@telefono		
					   ,email            =	@email
					   ,statu            =  @status
			           ,FechaAdiciona    =  @FechaAdiciona
                       ,FechaModifica    =  @FechaModifica
                       ,UsuarioAdiciona  =  @UsuarioAdiciona
                       --,UsuarioModifica  =  @UsuarioModifica
                       ,HostName         = HOST_NAME()
					   

where idcliente=@idcliente
					   
ELSE

INSERT INTO dbo.cliente values(

                                @nombre			
							   ,@apellidos		
							   ,@sexo			
							   ,@fecha_nacimiento
							   ,@tipo_documento	
							   ,@num_documento	
							   ,@direccion		
							   ,@telefono		
							   ,@email
							   ,@status
							   ,@FechaAdiciona
							   ,@FechaModifica
							   ,@UsuarioAdiciona
							   ,null--@UsuarioModifica
							   ,HOST_NAME()
                              )


END
GO
/****** Object:  StoredProcedure [dbo].[SP_SET_DELETE_ARTICULO]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SET_DELETE_ARTICULO]
@codigo int 
,@estado bit
AS

BEGIN 
UPDATE dbo.articulo SET estado=@estado where codigo=@codigo

END
GO
/****** Object:  StoredProcedure [dbo].[SP_SET_EMPLEADO]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
       CREATE PROC [dbo].[SP_SET_EMPLEADO]

       @idtrabajador    int
      ,@nombre          varchar(20)
      ,@apellidos       varchar(40)
      ,@sexo            char(10)
      ,@Fecha_nac       datetime
      ,@num_documento   varchar(15)
      ,@direccion       varchar(100)
      ,@telefono        varchar(15)
      ,@email           varchar(50)
      ,@StatusE         bit
      ,@UsuarioAdiciona varchar(50)
	  ,@UsuarioModifica varchar(50)

	  AS

	  BEGIN 
	  if exists(select * from dbo.trabajador where idtrabajador=@idtrabajador)
	  UPDATE dbo.trabajador
	  set

	   nombre         =@nombre         
	  ,apellidos      =@apellidos      
	  ,sexo           =@sexo           
	  ,Fecha_nac      =@Fecha_nac      
	  ,num_documento  =@num_documento  
	  ,direccion      =@direccion      
	  ,telefono       =@telefono       
	  ,email          =@email          
	  ,StatusE        =@StatusE    
	  ,FechaModifica  =GETDATE()
	  ,UsuarioModifica=@UsuarioModifica

	  WHERE idtrabajador=@idtrabajador;
	  else

	  INSERT INTO [dbo].[trabajador]
           ([nombre]
           ,[apellidos]
           ,[sexo]
           ,[Fecha_nac]
           ,[num_documento]
           ,[direccion]
           ,[telefono]
           ,[email]
           ,[StatusE]
           ,[FechaAdiciona]
           ,[FechaModifica]
           ,[UsuarioAdiciona]
           ,[UsuarioModifica])
     VALUES
           (
		   @nombre          
		   ,@apellidos       
		   ,@sexo            
		   ,@Fecha_nac       
		   ,@num_documento   
		   ,@direccion       
		   ,@telefono        
		   ,@email           
		   ,@StatusE        
		   ,GETDATE()   
		   ,NULL   
		   ,@UsuarioAdiciona 
		   ,NULL	
		   )
		    
	  END
GO
/****** Object:  StoredProcedure [dbo].[SP_SET_INSERT_UPDATE_ARTICULO]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_SET_INSERT_UPDATE_ARTICULO]
    @idarticulo int ,
	@codigo varchar(50)  ,
	@nombre varchar(50)  ,
	@idcategoria int  ,
	@Imag_Url varchar(250) ,
	@descripcion varchar(200) ,
	@precioVenta decimal(9, 2) ,
	@precioCompra decimal(9, 2) ,
	@cantidad decimal(9, 2) ,
	@estado bit ,
	@idProveedor int 

AS
BEGIN 
IF EXISTS(SELECT * FROM dbo.articulo where idarticulo=@idarticulo)
UPDATE [dbo].[articulo]
   SET 
       [codigo]       = @codigo
	  ,[nombre]       = @nombre
      ,[idcategoria]  = @idcategoria
      ,[Imag_Url]     = @Imag_Url
      ,[descripcion]  = @descripcion
      ,[precioVenta]  = @precioVenta
      ,[precioCompra] = @precioCompra
      ,[cantidad]     = @cantidad
      ,[estado]       = @estado
      ,[idProveedor]  = @idProveedor

 WHERE idarticulo=@idarticulo
else

INSERT INTO [dbo].[articulo]
           ([codigo]
           ,[nombre]
           ,[idcategoria]
           ,[Imag_Url]
           ,[descripcion]
           ,[precioVenta]
           ,[precioCompra]
           ,[cantidad]
           ,[estado]
           ,[idProveedor])
     VALUES
           (
		    @codigo
		   ,@nombre
		   ,@idcategoria
		   ,@Imag_Url
		   ,@descripcion
		   ,@precioVenta
		   ,@precioCompra
		   ,@cantidad
		   ,@estado
		   ,@idProveedor
		   )

END
GO
/****** Object:  StoredProcedure [dbo].[SP_SET_INSERT_UPDATE_INGRESO]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_SET_INSERT_UPDATE_INGRESO]

       @idingreso            int            
      ,@idproveedor          int
      ,@fecha                date 
      ,@tipo_comprobante     varchar(20) 
      ,@serie                varchar(20) 
      ,@correlativo          varchar(7)
      ,@Itbis                decimal(9,2)  
      ,@FechaAdiciona        datetime
      ,@FechaModifica        datetime 
      ,@UsuarioAdiciona      varchar(50)
      ,@UsuarioModifica      varchar(50)
	  ,@idarticulo           int 
	  ,@precio_compra        money
	  ,@precio_venta         money
	  ,@stock_inicial        int
	  ,@stock_actual         int
	  ,@fecha_produccion     date
	  ,@fecha_vencimiento    date
	 
	  AS

	  BEGIN
	   declare @id_ingre int
	  IF EXISTS(SELECT * FROM [dbo].[ingreso] WHERE idingreso=@idingreso) 
	
	  UPDATE [dbo].[ingreso]
	       
      SET    
          [idproveedor]       =@idproveedor     
         ,[fecha]             =@fecha           
         ,[tipo_comprobante]  =@tipo_comprobante
         ,[serie]             =@serie           
         ,[correlativo]       =@correlativo     
         ,[igv]               =@Itbis           
         ,[FechaAdiciona]     =@FechaAdiciona   
         ,[FechaModifica]     =@FechaModifica   
         ,[UsuarioAdiciona]   =@UsuarioAdiciona 
         ,[UsuarioModifica]   =@UsuarioModifica 
     
	  WHERE [idingreso]=@idingreso

	  ELSE
	  
INSERT INTO [dbo].[ingreso]
           (
            [idproveedor]
           ,[fecha]
           ,[tipo_comprobante]
           ,[serie]
           ,[correlativo]
           ,[igv]
           ,[FechaAdiciona]
           ,[FechaModifica]
           ,[UsuarioAdiciona]
           ,[UsuarioModifica])
     VALUES
           
		   ( 
		  
		    @idproveedor     
		   ,@fecha           
		   ,@tipo_comprobante
           ,@serie           
           ,@correlativo     
           ,@Itbis           
           ,@FechaAdiciona   
           ,@FechaModifica   
           ,@UsuarioAdiciona 
           ,@UsuarioModifica) 
		set  @id_ingre=(select max(idingreso) from [dbo].[ingreso] )

INSERT INTO [dbo].detalle_ingreso
SELECT  
      
       @id_ingre[idingreso]
      ,@idarticulo[idarticulo]
      ,@precio_compra [precio_compra]
      ,@precio_venta [precio_venta]
      ,@stock_inicial [stock_inicial]
      ,@stock_inicial [stock_actual]
      ,@fecha_produccion [fecha_produccion]
      ,@fecha_vencimiento [fecha_vencimiento]
  


	  END
GO
/****** Object:  StoredProcedure [dbo].[SP_SET_INSERTAR_ARTICULOS_INGRESO]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_SET_INSERTAR_ARTICULOS_INGRESO]

 
  @nombre              varchar(50)
 ,@idcategoria         int
 ,@Codigo              varchar(50)
 ,@Imag_Url            varchar(250)
 ,@descripcion         varchar(200)
 ,@precioVenta         decimal(9,2)
 ,@precioCompra        decimal(9,2)
 ,@cantidad            decimal(9,2)
 ,@estado              bit
 ,@idProveedor         int
 ,@idingreso           int
 ,@fecha               date
 ,@tipo_comprobante    varchar(20)
 ,@igv                 decimal(9,2)
 ,@UsuarioAdiciona     varchar(50)
 ,@stock_inicial       int
 ,@fecha_produccion    date
 ,@fecha_vencimiento   date

 AS


 BEGIN 
INSERT INTO [dbo].[articulo]
           ([nombre]
           ,[idcategoria]
           ,[Codigo]
           ,[Imag_Url]
           ,[descripcion]
           ,[precioVenta]
           ,[precioCompra]
           ,[cantidad]
           ,[estado]
           ,[idProveedor])
     VALUES
           (
		    @nombre       
		   ,@idcategoria  
		   ,@Codigo       
		   ,@Imag_Url     
		   ,@descripcion  
		   ,@precioVenta  
		   ,@precioCompra 
		   ,@cantidad     
		   ,@estado       
		   ,@idProveedor  
		   );
		   
		   --DECLARE @cd varchar(30)=(select max(idarticulo) from [dbventas].[dbo].[articulo]);
	DECLARE @cd INT;
	SET @cd=@@IDENTITY
	PRINT @cd;
INSERT INTO [dbo].[ingreso]
           ([CodigBarra]
           ,[idproveedor]
           ,[fecha]
           ,[tipo_comprobante]
           ,[igv]
           ,[FechaAdiciona]
           ,[FechaModifica]
           ,[UsuarioAdiciona]
           ,[UsuarioModifica])
     VALUES

           (
		    @cd
		   ,@idProveedor		   
		   ,@fecha
		   ,@tipo_comprobante
		   ,@igv
		   ,GETDATE()
		   ,NULL
		   ,@UsuarioAdiciona
		   ,NULL
		   );
		  
		     DECLARE @codigoIng int=(select max(idingreso) from dbo.ingreso); 
			 DECLARE @art int=(select max(idarticulo) from dbo.articulo); 

		   INSERT INTO [dbo].[detalle_ingreso]
           ([idingreso]
           ,[idarticulo]
           ,[precio_compra]
           ,[precio_venta]
           ,[stock_inicial]
           ,[stock_actual]
           ,[fecha_produccion]
           ,[fecha_vencimiento])
     VALUES
           (
		    @codigoIng
		   ,@art
		   ,@precioCompra
		   ,@precioVenta
		   ,@stock_inicial
		   ,@cantidad
		   ,@fecha_produccion
		   ,@fecha_vencimiento
		   )
		
 END








GO
/****** Object:  StoredProcedure [dbo].[SP_SET_UDATE_INSERT_PROVEEDOR]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SET_UDATE_INSERT_PROVEEDOR]

 @idproveedor        int  
,@razon_social varchar(150)
,@NombreProveedor varchar(50)
,@tipo_documento varchar(20)
,@num_documento varchar(15)
,@direccion nchar(100)
,@telefono varchar(10)
,@email varchar(50)
,@url varchar(100)
,@statu bit
,@UsuarioAdiciona varchar(50)
,@UsuarioModifica varchar(50)


as

begin 
if exists(select * from dbo.proveedor where idproveedor=@idproveedor)
UPDATE [dbo].[proveedor]
  
   SET [razon_social]        =@razon_social     
      ,[NombreProveedor]     =@NombreProveedor  
      ,[tipo_documento]      =@tipo_documento   
      ,[num_documento]       =@num_documento    
      ,[direccion]           =@direccion        
      ,[telefono]            =@telefono         
      ,[email]               =@email            
      ,[url]                 =@url              
      ,[statu]               =@statu    
      ,[FechaModifica]       =getdate()    
      ,[UsuarioModifica]     =@UsuarioModifica
           
 
  WHERE  idproveedor=@idproveedor
  ELSE
 INSERT INTO [dbo].[proveedor]
           ([razon_social]
           ,[NombreProveedor]
           ,[tipo_documento]
           ,[num_documento]
           ,[direccion]
           ,[telefono]
           ,[email]
           ,[url]
           ,[statu]
           ,[FechaAdiciona]
           ,[FechaModifica]
           ,[UsuarioAdiciona]
           ,[UsuarioModifica]
           ,[HostName])
     VALUES
           (
		    @razon_social     
		   ,@NombreProveedor  
		   ,@tipo_documento   
		   ,@num_documento    
		   ,@direccion  
		   ,@telefono   
		   ,@email      
		   ,@url        
		   ,@statu 
		   ,getdate()
		   ,NULL
		   ,@UsuarioAdiciona
		   ,NULL
		   ,HOST_NAME()
		   
		   )
		   
END 
GO
/****** Object:  StoredProcedure [dbo].[SP_TIPO_FACTURA]    Script Date: 28/06/2018 21:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TIPO_FACTURA]
AS
BEGIN 
SELECT[id]
      ,[Tipo_Comprovante_Fiscal]
      
      
  FROM [dbventas].[dbo].[Ncf_Comprovante]

  END
GO
