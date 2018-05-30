if exists(select * from sys.databases where name = 'dbventas')
begin
 use [master]
 drop database [dbventas]
end
if not exists(select * from sys.databases where name = 'dbventas')
begin
  create database dbventas
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
USE [dbventas]
GO
/****** Object:  Table [dbo].[articulo]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articulo](
	[idarticulo] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[idcategoria] [int] NOT NULL,
	[Imag_Url] [varchar](250) NULL,
	[descripcion] [varchar](200) NULL,
	[precioVenta] [decimal](9, 2) NULL,
	[precioCompra] [decimal](9, 2) NULL,
	[cantidad] [decimal](9, 2) NULL,
	[estado] [bit] NULL,
	[idProveedor] [int] NOT NULL,
 CONSTRAINT [PK_articulo] PRIMARY KEY CLUSTERED 
(
	[idarticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 28/05/2018 22:24:13 ******/
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
/****** Object:  Table [dbo].[cliente]    Script Date: 28/05/2018 22:24:13 ******/
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
	[num_documento] [varchar](8) NOT NULL,
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
/****** Object:  Table [dbo].[detalle_ingreso]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_ingreso](
	[iddetalle_ingreso] [int] IDENTITY(1,1) NOT NULL,
	[idingreso] [int] NOT NULL,
	[idarticulo] [int] NOT NULL,
	[precio_compra] [money] NOT NULL,
	[precio_venta] [money] NOT NULL,
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
/****** Object:  Table [dbo].[detalle_venta]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_venta](
	[iddetalle_venta] [int] IDENTITY(1,1) NOT NULL,
	[idventa] [int] NOT NULL,
	[idarticulo] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio_venta] [money] NOT NULL,
	[descuento] [money] NOT NULL,
 CONSTRAINT [PK_detalle_venta] PRIMARY KEY CLUSTERED 
(
	[iddetalle_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ingreso]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingreso](
	[idingreso] [int] IDENTITY(1,1) NOT NULL,
	[idtrabajador] [int] NOT NULL,
	[idproveedor] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo_comprobante] [varchar](20) NOT NULL,
	[serie] [varchar](4) NOT NULL,
	[correlativo] [varchar](7) NOT NULL,
	[igv] [decimal](4, 2) NOT NULL,
	[FechaAdiciona] [datetime] NULL,
	[FechaModifica] [datetime] NULL,
	[UsuarioAdiciona] [varchar](50) NULL,
	[UsuarioModifica] [varchar](50) NULL,
 CONSTRAINT [PK_ingreso] PRIMARY KEY CLUSTERED 
(
	[idingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[idproveedor] [int] IDENTITY(1,1) NOT NULL,
	[razon_social] [varchar](150) NOT NULL,
	[sector_comercial] [varchar](50) NOT NULL,
	[tipo_documento] [varchar](20) NOT NULL,
	[num_documento] [varchar](11) NOT NULL,
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
/****** Object:  Table [dbo].[ROLES]    Script Date: 28/05/2018 22:24:13 ******/
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

INSERT INTO [dbo].[ROLES](Nombre, Grupo) VALUES ('Administrador','Admin');
INSERT  INTO [dbo].[ROLES](Nombre, Grupo) VALUES ('Almacenista', 'Inventario');
INSERT INTO [dbo].[ROLES](Nombre, Grupo) VALUES ('Vendedor', 'Operario');
INSERT INTO [dbo].[ROLES](Nombre, Grupo) VALUES ('Almacenista Sup', 'Inventario');
INSERT INTO [dbo].[ROLES](Nombre, Grupo) VALUES ('Vendedor Sup', 'Operario');
INSERT INTO [dbo].[ROLES](Nombre, Grupo) VALUES ('Gerente', 'Administrativo');
INSERT INTO [dbo].[ROLES](Nombre, Grupo) VALUES ('HHRR', 'Administrativo');

/****** Object:  Table [dbo].[trabajador]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trabajador](
	[idtrabajador] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellidos] [varchar](40) NOT NULL,
	[sexo] [varchar](1) NOT NULL,
	[Fecha_nac] [date] NOT NULL,
	[num_documento] [varchar](8) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](10) NULL,
	[email] [varchar](50) NULL,
	[acceso] [varchar](20) NOT NULL,
	[usuario] [varchar](20) NOT NULL,
	[password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_trabajador] PRIMARY KEY CLUSTERED 
(
	[idtrabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 28/05/2018 22:24:13 ******/
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
/****** Object:  Table [dbo].[venta]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

INSERT INTO USERS (Usuario, Clave, RolId, Statud) VALUES('Edsource', 'Admin', 1, 1)
INSERT INTO USERS (Usuario, Clave, RolId, Statud) VALUES('Vaneiker', 'Admin', 1, 1)
INSERT INTO USERS (Usuario, Clave, RolId, Statud) VALUES('Gregory', 'Admin', 1, 1)

CREATE TABLE [dbo].[venta](
	[idventa] [int] IDENTITY(1,1) NOT NULL,
	[idcliente] [int] NOT NULL,
	[idtrabajador] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo_comprobante] [varchar](20) NOT NULL,
	[serie] [varchar](4) NOT NULL,
	[correlativo] [varchar](7) NOT NULL,
	[igv] [decimal](4, 2) NOT NULL,
 CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED 
(
	[idventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cuentas_x_pagar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_proveedor] [int] NOT NULL,
	[fecha] [datetime] NOT NULL default getdate(),
	[valor] [decimal](18,2) NOT NULL,
	[pagado] [bit] NOT NULL default 0,
	[usuario] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[cuentas_x_cobrar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NOT NULL,
	[fecha] [datetime] NOT NULL default getdate(),
	[valor] [decimal](18,2) NOT NULL,
	[pagado] [bit] NOT NULL default 0,
	[usuario] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  View [dbo].[ma;ana]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[bus_articulo]
AS
SELECT        dbo.articulo.idarticulo, dbo.articulo.codigo, dbo.articulo.nombre, dbo.articulo.descripcion, dbo.articulo.Imag_Url, dbo.articulo.idcategoria, 
                         dbo.categoria.nombre AS Expr1
FROM            dbo.articulo INNER JOIN
                         dbo.categoria ON dbo.articulo.idcategoria = dbo.categoria.idcategoria

GO
/****** Object:  View [dbo].[VW_CLIENTES_LOAD]    Script Date: 28/05/2018 22:24:13 ******/
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
ALTER TABLE [dbo].[articulo] ADD  DEFAULT ((0)) FOR [estado]
GO
ALTER TABLE [dbo].[USERS] ADD  DEFAULT ((0)) FOR [Statud]
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD  CONSTRAINT [FK_articulo_categoria] FOREIGN KEY([idcategoria])
REFERENCES [dbo].[categoria] ([idcategoria])
GO
ALTER TABLE [dbo].[articulo] CHECK CONSTRAINT [FK_articulo_categoria]
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
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_articulo] FOREIGN KEY([idarticulo])
REFERENCES [dbo].[articulo] ([idarticulo])
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_articulo]
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_venta] FOREIGN KEY([idventa])
REFERENCES [dbo].[venta] ([idventa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_venta]
GO
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD  CONSTRAINT [FK_ingreso_proveedor] FOREIGN KEY([idproveedor])
REFERENCES [dbo].[proveedor] ([idproveedor])
GO
ALTER TABLE [dbo].[ingreso] CHECK CONSTRAINT [FK_ingreso_proveedor]
GO
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD  CONSTRAINT [FK_ingreso_trabajador] FOREIGN KEY([idtrabajador])
REFERENCES [dbo].[trabajador] ([idtrabajador])
GO
ALTER TABLE [dbo].[ingreso] CHECK CONSTRAINT [FK_ingreso_trabajador]
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
/****** Object:  StoredProcedure [dbo].[SP_GET_CLIENTES_BUSCAR]    Script Date: 28/05/2018 22:24:13 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GET_CLIENTES_LOAD]    Script Date: 28/05/2018 22:24:13 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SET_CLIENTE_DELETE]    Script Date: 28/05/2018 22:24:13 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SET_CLIENTE_INSERT_UPDATE]    Script Date: 28/05/2018 22:24:13 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SET_CLIENTE_INSERT_UPDATE_20180528]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[SP_SET_CLIENTE_INSERT_UPDATE_20180528]
    
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
      --,@FechaModifica     datetime
      ,@UsuarioAdiciona   varchar(50)
      --,@UsuarioModifica	  varchar(50)
                
AS
declare @FechaModifica  datetime=getdate() 

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
							   ,getdate()
							   ,@FechaModifica
							   ,@UsuarioAdiciona
							   ,null--@UsuarioModifica
							   ,HOST_NAME()
                              )


END
/****** Object:  StoredProcedure [dbo].[SP_LOGIN]    Script Date: 29/05/2018 22:55:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC SP_LOGIN
@usuario varchar(50),
@contrasena varchar(50),
@rolid int output
AS
BEGIN
 SELECT @rolid = RolID from [dbo].[USERS] WHERE Usuario = @usuario and Clave = @contrasena;
 IF NOT (@rolid > 0)
 BEGIN
   SET @rolid = 0
 END
END
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_articulo_nombre]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_articulo_nombre]
@textobuscar varchar (50)
as
SELECT dbo.articulo.idarticulo, dbo.articulo.codigo, dbo.articulo.nombre,
dbo.articulo.descripcion, dbo.articulo.Imag_Url, dbo.articulo.idcategoria, 
dbo.categoria.nombre AS Expr1
FROM dbo.articulo INNER JOIN dbo.categoria ON dbo.articulo.idcategoria = dbo.categoria.idcategoria
where dbo.articulo.nombre like @textobuscar + '%'
order by dbo.articulo.idarticulo desc 

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_categoria]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_categoria]
@textobuscar varchar (50)
as
select * from categoria
where nombre like @textobuscar + '%' -- Alt + 39

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_proveedor_num_documento]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_proveedor_num_documento]
@textobuscar varchar (11)
as
select * from proveedor
where num_documento like @textobuscar + '%'

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_proveedor_razon_social]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_proveedor_razon_social]
@textobuscar varchar (50)
as
select * from proveedor
where razon_social like @textobuscar + '%'

GO
/****** Object:  StoredProcedure [dbo].[speditar_articulo]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_articulo]

@idarticulo int, 
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(1024),
@imagen varchar(255),
@idcategoria int
as
update articulo set codigo=@codigo,nombre=@nombre,descripcion=@descripcion,
Imag_Url=@imagen,idcategoria=@idcategoria
where idarticulo=@idarticulo

GO
/****** Object:  StoredProcedure [dbo].[speditar_categoria]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--- Procedimiento Editar 
create proc [dbo].[speditar_categoria]
@idcategoria int,
@nombre varchar (50),
@descripcion varchar (256)
as
update categoria set nombre=@nombre,
descripcion=@descripcion
where idcategoria=@idcategoria


GO
/****** Object:  StoredProcedure [dbo].[speditar_proveedor]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_proveedor]
@idproveedor int,
@razon_social varchar (150),
@sector_comercial varchar (50),
@tipo_documento varchar (20),
@num_documento varchar (11),
@direccion varchar(100),
@telefono varchar (10),
@email  varchar (50),
@url varchar (100)
as
update proveedor set razon_social=@razon_social,sector_comercial=@sector_comercial,
tipo_documento=@tipo_documento,num_documento=@num_documento,
direccion=@direccion,telefono=@telefono,email=@email,
url=@url
where idproveedor=@idproveedor

GO
/****** Object:  StoredProcedure [dbo].[speliminar_categoria]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--- Procedimiento Eliminar 
create proc [dbo].[speliminar_categoria]
@idcategoria int
as 
delete from categoria
where idcategoria=@idcategoria

GO
/****** Object:  StoredProcedure [dbo].[speliminar_proveedor]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_proveedor]
@idproveedor int
as 
delete from proveedor
where idproveedor=@idproveedor

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_articulo]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_articulo]
@idarticulo int output, 
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(1024),
@imagen varchar(255),
@idcategoria int
as


insert into articulo (codigo,nombre, descripcion,Imag_Url,idcategoria)
values (@codigo,@nombre,@descripcion,@imagen, @idcategoria)

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_categoria]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--- Procedimiento Insertar
create proc [dbo].[spinsertar_categoria] 
@idcategoria int output,
@nombre varchar (50),
@descripcion varchar (256)
as
insert into categoria (nombre,descripcion)
values (@nombre,@descripcion)


GO
/****** Object:  StoredProcedure [dbo].[spinsertar_proveedor]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_proveedor]
@idproveedor int output,
@razon_social varchar (150),
@sector_comercial varchar (50),
@tipo_documento varchar (20),
@num_documento varchar (11),
@direccion varchar(100),
@telefono varchar (10),
@email  varchar (50),
@url varchar (100)
as
insert into proveedor(razon_social,sector_comercial,tipo_documento,
num_documento,direccion,telefono,email,url)
values (@razon_social,@sector_comercial,@tipo_documento,
@num_documento,@direccion,@telefono,@email,@url)

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_articulo]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_articulo]
as
SELECT   top 100 dbo.articulo.idarticulo, dbo.articulo.codigo, dbo.articulo.nombre,
dbo.articulo.descripcion, dbo.articulo.Imag_Url, dbo.articulo.idcategoria, 
dbo.categoria.nombre AS Categoria
FROM dbo.articulo INNER JOIN dbo.categoria 
ON dbo.articulo.idcategoria = dbo.categoria.idcategoria 
order by dbo.articulo.idarticulo desc 

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_categoria]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_categoria]
as
select top 200 * from categoria
order by idcategoria desc 

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_proveedor]    Script Date: 28/05/2018 22:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_proveedor]
as
select top 100  * from proveedor
order by razon_social asc

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[44] 4[17] 2[21] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "articulo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 188
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "categoria"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 175
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'propventas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'propventas'
GO