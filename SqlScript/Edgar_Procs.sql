USE [dbventas]
GO
/****** Object:  StoredProcedure [dbo].[FACTURA_A_IMPRIMIR]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FACTURA_A_IMPRIMIR]
@id_factura int
AS
SELECT f.[id_factura] AS [Id Factura]
      ,(c.[nombre] + ' ' + c.[apellidos]) AS [Cliente]
      ,f.[nombre_trabajador] AS Empleado
      ,f.[tipo_pago] as [Tipo de Pago]
      ,f.[fecha] as [Fecha]
      ,f.[medio_pago] as [Medio de Pago]
      ,f.[cantidad_articulos] as [No. Articulos]
      ,f.[subtotal] as [Subtotal]
      ,f.[itbis] as ITBIS
      ,f.[total] as Total
      ,f.[numero_factura] as [No. Factura]
	  ,d.[producto] as Producto
	  ,d.[cantidad] as Cantidad
	  ,d.[precio_venta] as Precio
	  ,(CONVERT(VARCHAR(10),(d.[descuento] * 100))+'%') as [Descuento]
	  ,d.[itbis] as PITBIS
	  ,d.[sub_itbis] as [PSUBITBIS]
	  ,d.[sub_total] as [PSUBTOTAL]
  FROM [dbo].[Factura] as f 
  INNER JOIN cliente c on c.idcliente = f.id_cliente
  INNER JOIN detalle_venta d on d.idventa = f.id_venta
  WHERE f.id_factura = @id_factura

GO
/****** Object:  StoredProcedure [dbo].[INGRESAR_FACTURA]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INGRESAR_FACTURA]
@nombre_trabajador varchar(100),
@tipo_pago varchar(25),
@medio_pago varchar(30),
@id_venta int,
@id_trabajador int,
@id_cliente int,
@cantidad_articulos int,
@subtotal decimal(18,2),
@itbis decimal(9,2),
@total decimal(18,2)
AS
INSERT INTO [dbo].[Factura]
           ([nombre_trabajador]
           ,[tipo_pago]
           ,[medio_pago]
           ,[id_venta]
           ,[id_trabajador]
		   ,[id_cliente]
           ,[cantidad_articulos]
           ,[subtotal]
           ,[itbis]
           ,[total]
		   ,[numero_factura])
     VALUES
           (@nombre_trabajador
           ,@tipo_pago
           ,@medio_pago
           ,@id_venta
           ,@id_trabajador
		   ,@id_cliente
           ,@cantidad_articulos
           ,@subtotal
           ,@itbis
           ,@total
		   ,('NFC'+CONVERT(VARCHAR(50),UPPER(SUBSTRING(@nombre_trabajador, (1), (2)))+'000000')+CONVERT(VARCHAR(10),@id_venta)))



GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_COTIZACION]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_COTIZACION]
@idcliente INT,
@idtrabajador INT,
@cantidad INT,
@subtotal DECIMAL(18, 2),
@itbis DECIMAL(9,2),
@total DECIMAL(18, 2),
@id_cotizacion int output
AS
BEGIN
INSERT INTO [dbo].[cotizacion]
           ([idcliente]
           ,[idtrabajador]
           ,[cantidad]
           ,[subtotal]
           ,[itbis]
           ,[total]
           ,[fecha]
           ,[estatus])
     VALUES
           (@idcliente
           ,@idtrabajador
           ,@cantidad
           ,@subtotal
           ,@itbis
           ,@total
           ,GETDATE()
           ,1)

SET @id_cotizacion = @@identity
END

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_DETALLES_COTIZADOR_PRODUCTOS]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_DETALLES_COTIZADOR_PRODUCTOS]
@idcotizacion INT,
@producto VARCHAR(50),
@cantidad INT,
@precioVenta DECIMAL(18,2),
@itbis DECIMAL(9,2),
@subtotal DECIMAL(18,2),
@total DECIMAL(18,2)
AS
INSERT INTO [dbo].[detalle_cotizacion_productos]
           ([idcotizacion]
           ,[producto]
           ,[cantidad]
           ,[precioVenta]
           ,[itbis]
           ,[subtotal]
           ,[total])
     VALUES
           (@idcotizacion
           ,@producto
           ,@cantidad
           ,@precioVenta
           ,@itbis
           ,@subtotal
           ,@total)

GO
/****** Object:  StoredProcedure [dbo].[LIST_ARTICULOS_X_CODIGO]    Script Date: 12/7/18 12:35:10 a. m. ******/
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

SET @STMT = ('SELECT * FROM DBO.articulo WHERE codigo = ' + CHAR(39) + UPPER(@CODIGO) + CHAR(39)); 

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
/****** Object:  StoredProcedure [dbo].[REDUCIR_CANTIDAD_ARTICULO]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[REDUCIR_CANTIDAD_ARTICULO]
@idarticulo int,
@cantidad int
as
begin
declare @status bit;
declare @enExistencia int;
declare @deducido int;
set @enExistencia = 0;
set @status = 1;
set @deducido = 0;

if(exists(SELECT * FROM [dbo].[articulo] WHERE [idarticulo] = @idarticulo))
BEGIN
SELECT @enExistencia = [cantidad] FROM [dbo].[articulo] WHERE [idarticulo] = @idarticulo;

if(@enExistencia <= 0)
begin
set @status = 0;
  end
    else
   begin
 set @deducido = @enExistencia - @cantidad;
end
UPDATE [dbo].[articulo]
   SET [cantidad] = @deducido
      ,[estado] = @status
 WHERE idarticulo = @idarticulo
 end
 END

GO
/****** Object:  StoredProcedure [dbo].[REGISTRAR_USUARIO]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SELECT_EMPLOYEE_BY_ID]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SELECT_EMPLOYEE_BY_ID]
@ID INT
AS
SELECT [idtrabajador]
      ,[nombre]
      ,[apellidos]
      ,[sexo]
      ,[Fecha_nac]
      ,[num_documento]
      ,[direccion]
      ,[telefono]
      ,[email]
      ,[StatusE]
      ,[FechaModifica]
      ,[UsuarioModifica]
      ,[FechaAdiciona]
      ,[UsuarioAdiciona]
  FROM [dbo].[trabajador] WHERE idtrabajador = @ID

GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_FACTURA_X_ID]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_BUSCAR_FACTURA_X_ID]
@id_factura int,
@id_venta int
AS
SELECT [id_factura]
      ,[id_cliente]
      ,[nombre_trabajador]
      ,[tipo_pago]
      ,[fecha]
      ,[medio_pago]
      ,[id_venta]
      ,[id_trabajador]
      ,[cantidad_articulos]
      ,[subtotal]
      ,[itbis]
      ,[total]
      ,[numero_factura]
  FROM [dbo].[Factura] WHERE id_venta = id_venta OR id_factura = @id_factura

GO
/****** Object:  StoredProcedure [dbo].[SP_CREAR_CUENTA_X_COBRAR]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CREAR_CUENTA_X_COBRAR]
@id_cliente int
,@valor decimal(18,2)
,@usuario varchar(50)
,@id_venta int
as
INSERT INTO [dbo].[cuentas_x_cobrar]
           ([id_cliente]
           ,[fecha]
           ,[valor]
           ,[pagado]
           ,[usuario]
		   ,[id_venta])
     VALUES
           (@id_cliente
           ,GETDATE()
           ,@valor
           ,0
           ,@usuario
		   ,@id_venta)

GO
/****** Object:  StoredProcedure [dbo].[SP_CUENTA_POR_COBRAR]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GET_ARTICULO]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GET_ARTICULO_LOAD]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GET_ARTICULOS_BUSCAR]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GET_ARTICULOS_BUSCAR_X_CODIGO]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GET_ARTICULOS_BUSCAR_X_CODIGO]
@codigo VARCHAR(50)
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
codigo=@codigo

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_CATEGORIA_BUSCAR]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GET_Categoria_LOAD]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GET_CLIENTES_BUSCAR]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[sp_get_clientes_deudores]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GET_CLIENTES_LOAD]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GET_COMBOBOX_CATEGORIA]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GET_COMBOBOX_CLIENTE]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GET_COMBOBOX_PROVEEDOR]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GET_EMPLOYEES]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GET_FACTURA]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GET_FACTURA]
@id_venta int
as
SELECT id_factura FROM FACTURA WHERE id_venta = @id_venta
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_ROLL_DROP]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GET_ROLL_DROP]
AS
BEGIN 
SELECT[id]
      ,[Nombre]
      
      
  FROM [dbventas].[dbo].[ROLES]

  END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_searche_client_pagos]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GET_USER_BY_NAME]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GET_VENTAS_DEL_DIA]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_GET_VENTAS_DEL_DIA]
@fecha date
as
begin
DECLARE @TEMP TABLE(idventa int, idcliente int, idtrabajador int, fecha date, tc varchar(25), tv varchar(20), tcli varchar(50), it decimal(9,2), sub decimal(18,2), total decimal(18,2), pagada varchar(25))
insert into @TEMP EXEC VENTAS_DEL_DIA @fecha

select t.fecha, t.idventa, (c.nombre + ' ' + c.apellidos) AS cliente, t.idtrabajador, t.tc as tipo, t.tv as venta, t.tcli as categoria, t.it as itbis, t.sub as subtotal, t.total as total, t.pagada
from @TEMP t inner join
cliente c on c.idcliente = t.idcliente;
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_VENTAS_DEL_MES]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GET_VENTAS_DEL_MES]
@FROM date,
@TO date
as
begin
DECLARE @TEMP TABLE(idventa int, idcliente int, idtrabajador int, fecha date, tc varchar(25), tv varchar(20), tcli varchar(50), it decimal(9,2), sub decimal(18,2), total decimal(18,2), pagada varchar(25))
insert into @TEMP EXEC VENTAS_DEL_DIA @FROM, @TO

select t.fecha, t.idventa, (c.nombre + ' ' + c.apellidos) AS cliente, t.idtrabajador, t.tc as tipo, t.tv as venta, t.tcli as categoria, t.it as itbis, t.sub as subtotal, t.total as total, t.pagada
from @TEMP t inner join
cliente c on c.idcliente = t.idcliente;
end
GO
/****** Object:  StoredProcedure [dbo].[SP_INGRESAR_DETALLE_VENTA]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INGRESAR_DETALLE_VENTA]
@idventa int,
@producto varchar(50),
@cantidad int,
@precio_venta decimal(18,2),
@descuento decimal(18,2),
@itbis decimal(9,2)
AS 
BEGIN
INSERT INTO [dbo].[detalle_venta]
           ([idventa]
		   ,[producto]
           ,[cantidad]
           ,[precio_venta]
           ,[descuento]
           ,[itbis])
     VALUES
           (@idventa
		   ,@producto
		   ,@cantidad
           ,@precio_venta
           ,@descuento
           ,@itbis)
END

GO
/****** Object:  StoredProcedure [dbo].[SP_INGRESAR_VENTA]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INGRESAR_VENTA]
@idtrabajador int,
@id_cliente int,
@tipo_comprobante varchar(20),
@tipo_venta varchar(20),
@tipo_cliente varchar(20),
@itbis decimal(9, 2),
@subtotal decimal(18, 2),
@total decimal(18,2),
@ventaid int output
as
BEGIN
 INSERT INTO [dbo].[venta]
           ([idtrabajador]
		   ,[idcliente]
           ,[fecha]
           ,[tipo_comprobante]
           ,[tipo_venta]
           ,[tipo_cliente]
           ,[itbis]
           ,[subtotal]
           ,[total])
     VALUES
           (@idtrabajador
		   ,@id_cliente
           ,GETDATE()
           ,@tipo_comprobante
           ,@tipo_venta
           ,@tipo_cliente
           ,@itbis
           ,@subtotal
           ,@total)

if(@@IDENTITY > 0)
BEGIN
 SET @ventaid = @@IDENTITY
END
ELSE
BEGIN
 SET @ventaid = 0
END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_LOGIN]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LOGIN]
@usuario varchar(50),
@contrasena varchar(50),
@NombreC varchar(80) output,
@rolid int output,
@id_trabajador int output
AS
BEGIN
 
 SELECT @rolid=RolID,@NombreC=NombreCompleto,@id_trabajador=id_trabajador
from dbo.wv_usuario_trabajador 
WHERE Usuario = @usuario and Clave = @contrasena
 
 
 IF  (@rolid<=0)
 BEGIN
   SET @rolid = 0
   SET @NombreC = ''
   SET @id_trabajador = 0
 END
END


GO
/****** Object:  StoredProcedure [dbo].[SP_SET_CATEGORIA]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SET_Categoria_UPDATE_INSERT]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SET_CLIENTE_DELETE]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SET_CLIENTE_INSERT_UPDATE]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SET_CLIENTE_INSERT_UPDATE_20180528]    Script Date: 12/7/18 12:35:10 a. m. ******/
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

GO
/****** Object:  StoredProcedure [dbo].[SP_SET_DELETE_ARTICULO]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SET_EMPLEADO]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
     CREATE PROC [dbo].[SP_SET_EMPLEADO]

       @idtrabajador    int
      ,@nombre          varchar(20)
      ,@apellidos       varchar(40)
      ,@sexo            char(1)
      ,@Fecha_nac       datetime
      ,@num_documento   varchar(15)
      ,@direccion       varchar(100)
      ,@telefono        varchar(10)
      ,@email           varchar(50)
      ,@StatusE         bit
      ,@UsuarioAdiciona varchar(50)
	  ,@UsuarioModifica varchar(50)

	  AS

	  BEGIN 
	  if exists(select * from dbo.trabajador where idtrabajador=@idtrabajador)
	  begin
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
	  end
	  else
	  begin
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
		end    
	  END
GO
/****** Object:  StoredProcedure [dbo].[SP_SET_INSERT_UPDATE_ARTICULO]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SET_INSERT_UPDATE_INGRESO]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SET_INSERTAR_ARTICULOS_INGRESO]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SET_UDATE_INSERT_PROVEEDOR]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
,@FechaAdiciona datetime
,@FechaModifica datetime
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
      ,[FechaAdiciona]       =@FechaAdiciona    
      ,[FechaModifica]       =@FechaModifica    
      ,[UsuarioAdiciona]     =@UsuarioAdiciona  
      ,[UsuarioModifica]     =GETDATE() 
      ,[HostName]            =HOST_NAME()         
 
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
		   ,@FechaAdiciona  
		   ,NULL
		   ,@UsuarioAdiciona
		   ,NULL
		   ,HOST_NAME()
		   
		   )

	END 	    
 INSERT INTO  [dbventas].[dbo].[ROLES] VALUES('Administrador','Administrador') 
 INSERT INTO  [dbventas].[dbo].[ROLES] VALUES('Almacenista','Inventario') 
 INSERT INTO  [dbventas].[dbo].[ROLES] VALUES('Vendedor','Operario') 
 INSERT INTO  [dbventas].[dbo].[ROLES] VALUES('Almacenista Sup','Inventario') 
 INSERT INTO  [dbventas].[dbo].[ROLES] VALUES('Vendedor Sup','Operario') 
 INSERT INTO  [dbventas].[dbo].[ROLES] VALUES('Gerente','Administrativo')
 INSERT INTO  [dbventas].[dbo].[ROLES] VALUES('HHRR','Administrativo')  

 INSERT INTO USERS VALUES('Pveneiker','TLHjuTFxUHxvymkOYn8vPA==',1,1)
 INSERT INTO USERS VALUES('Edsource','TLHjuTFxUHxvymkOYn8vPA==',1,1)
 INSERT INTO USERS VALUES('GBLANCO','TLHjuTFxUHxvymkOYn8vPA==',1,1)
		   


GO
/****** Object:  StoredProcedure [dbo].[SP_TIPO_FACTURA]    Script Date: 12/7/18 12:35:10 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[VENTAS_DEL_DIA]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[VENTAS_DEL_DIA]
@HOY date
AS
select *, [Pagada] = 'Pagada'  from venta v
where (v.[idventa]) not in (select p.id_venta from cuentas_x_cobrar p where p.fecha = @HOY)
and v.fecha = @HOY
union
select *, [Pagada] = 'Credito' from venta v
where (v.[idventa]) in (select p.id_venta from cuentas_x_cobrar p where p.fecha = @HOY)
and v.fecha = @HOY
GO
/****** Object:  StoredProcedure [dbo].[VENTAS_DEL_MES]    Script Date: 12/7/18 12:35:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[VENTAS_DEL_MES]
@FROM date,
@TO date
AS
select *, [Pagada] = 'Pagada'  from venta v
where (v.[idventa]) not in (select p.id_venta from cuentas_x_cobrar p where p.fecha between @FROM and @TO)
and v.fecha between @FROM and @TO
union
select *, [Pagada] = 'Credito' from venta v
where (v.[idventa]) in (select p.id_venta from cuentas_x_cobrar p where p.fecha between @FROM and @TO)
and v.fecha between @FROM and @TO
GO
