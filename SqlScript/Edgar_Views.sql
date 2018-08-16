USE [dbventas]
GO
/****** Object:  View [dbo].[get_client_parameter]    Script Date: 12/7/18 12:34:03 a. m. ******/
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
/****** Object:  View [dbo].[ROL_USER]    Script Date: 12/7/18 12:34:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ROL_USER] 
AS
SELECT  RolID
FROM    dbo.USERS WHERE [Statud]=1

GO
/****** Object:  View [dbo].[VW_CLIENTES_LOAD]    Script Date: 12/7/18 12:34:03 a. m. ******/
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
/****** Object:  View [dbo].[wv_get_cliente_deuda]    Script Date: 12/7/18 12:34:03 a. m. ******/
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
/****** Object:  View [dbo].[wv_get_employees]    Script Date: 12/7/18 12:34:03 a. m. ******/
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
/****** Object:  View [dbo].[wv_usuario_trabajador]    Script Date: 12/7/18 12:34:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[wv_usuario_trabajador]
as

select u.RolID,(t.nombre+' '+t.apellidos)[NombreCompleto],u.Clave,u.Usuario, ut.id_trabajador from dbo.[UsuarioTrabajador]ut  inner join 
dbo.[trabajador]t 

on t.idtrabajador=ut.id_trabajador
inner join dbo.[USERS]u

on u.id=ut.id_usuario

where       u.Statud=1
       and t.StatusE=1
and ut.fecha_deasinacion is null
and ut.status_assignacion=1


GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "ut"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "t"
            Begin Extent = 
               Top = 6
               Left = 263
               Bottom = 136
               Right = 444
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "u"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 208
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'wv_usuario_trabajador'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'wv_usuario_trabajador'
GO
