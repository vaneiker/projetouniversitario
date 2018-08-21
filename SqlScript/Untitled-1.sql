USE [POS_SITE]
GO
/****** Object:  StoredProcedure [POS].[SP_FILL_DROP_DOWN]    Script Date: 8/14/2018 10:51:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [POS].[SP_FILL_DROP_DOWN]
       @Filtro varchar(80)
AS
BEGIN
       IF UPPER(@Filtro) = 'SOCIALREASON'
       BEGIN
             select cast(Id as varchar(100)) as [id]
                    ,Upper([Description]) as [name]
             from
                    [POS].[SOCIAL_REASON]
             where [Status] = 1
             Order by [Description]
       END
       ELSE IF UPPER(@Filtro) = 'OWNERSHIPSTRUCTURE'
       BEGIN
             select cast(Id as varchar(100)) as [id]
                    ,Upper([Description]) as [name]
             from
                    [POS].[OWNERSHIP_STRUCTURE]
             where [Status] = 1
             Order by [Description]
       END
       ELSE IF UPPER(@Filtro) = 'COUNTRY'
       BEGIN
             select cast([Global_Country_Id] as varchar(100)) as [id]
                    ,Upper([Global_Country_Desc]) as [name]
             from
                    [Global].[ST_GLOBAL_COUNTRY]
             where Global_Country_Status = 1
             Order by [Global_Country_Desc]
       END
       ELSE IF UPPER(@Filtro) = 'SURCHARGEPERCENTAGE'
       BEGIN
             Select cast([Percentage] as varchar(100)) as [id]
                    ,[Percentage_Desc] as [name]
             from
                    [Global].[ST_SURCHARGE_PERCENTAGE]
       END
       ELSE IF UPPER(@Filtro) = 'COLORS'
       BEGIN
             Select cast(Id as varchar(100)) as [id]
                    ,[name]
             from
                    [POS].[COLORS]
             Order by [Name]
       END
       ELSE IF UPPER(@Filtro) = 'JOBS'
       BEGIN
             Select cast(Id as varchar(100)) as [id]
                    ,[name]
             from
                    [POS].[JOBS]
             Order by [Name]
       END
       ELSE IF UPPER(@Filtro) = 'RELATIONSHIP'
       BEGIN
             Select cast(e.Relationship_Id as varchar(100)) as [Id]
                    ,isnull(t.Translated_Literal, t.Literal_Desc) as [name]                   
             from
                    [Global].[EN_RELATIONSHIP] e
             Left join 
                    [Global].[Global].[VW_GET_TRANSLATE] t
             on 
                    RTRIM(LTRIM(t.Literal_Desc)) = RTRIM(LTRIM(e.Relationship_Desc))
                    and t.Destiny_Language_Id=2--Espanol
             where
                    e.Relation_Status = 1
                    and e.Familiar_Relation = 1
             Order by [name]
       END
       ELSE IF UPPER(@Filtro) = 'BRANDS'
       BEGIN
             Select cast([Make_Id] as varchar(100)) as [id]
                    ,[Make_Desc] as [name]
             from
                    [Global].[ST_VEHICLE_MAKE]
             where
                    [Pos_Flag] = 1
             and    [Make_Status] = 1
             Order by [Make_Desc]
       END
       ELSE IF UPPER(@Filtro) = 'NEXTQUOTATION'
       BEGIN
             SELECT
                    cast(QuotationDailyNumber as varchar(100)) as [id],
                    QuotationNumber as [name]
             FROM
                    POS.QUOTATION 
             WHERE 
                    CAST(Created as date) = CAST(GETDATE() as date)
             ORDER BY QuotationDailyNumber DESC
       END
       ELSE IF UPPER(@Filtro) = 'CRIDITCARTYPES'
       BEGIN
             select '1' as [id], 'Master Card' as [name]
             union
             select '2' as [id], 'American Express' as [name]
             union
             select '3' as [id], 'Visa' as [name]
       END
       ELSE IF UPPER(@Filtro) = 'PaymentFreq'
       BEGIN
             SELECT [id],
                      [name]
             FROM VW_PAYMENT_FREQ
               where idSelected not in (5,6,7,8,9,10,11)
       END
       ELSE IF UPPER(@Filtro) = 'PaymentFreq2'
       BEGIN
                             select '{''Id'':''0'',''Discount'':''0.05'',''Initial'':''1.00''}' as [id], 'Pago Único (5% de Descuento)' as [name]
             union all select '{''Id'':''1'',''Discount'':''0.00'',''Initial'':''0.25''}' as [id], 'Inicial + 1 Cuota' as [name]
             union all select '{''Id'':''2'',''Discount'':''0.00'',''Initial'':''0.25''}' as [id], 'Inicial + 2 Cuotas' as [name]
             union all select '{''Id'':''3'',''Discount'':''0.00'',''Initial'':''0.25''}' as [id], 'Inicial + 3 Cuotas' as [name]
             union all select '{''Id'':''4'',''Discount'':''0.00'',''Initial'':''0.25''}' as [id], 'Inicial + 4 Cuotas' as [name]
       END
       ELSE IF UPPER(@Filtro) = 'PaymentFreqFinanced'
       BEGIN
             SELECT [id]= cast([idSelected] as varchar(100)),
                      [name]
             FROM VW_PAYMENT_FREQ
               where idSelected in (5,6,7,8,9,10,11)
       END    
       ELSE IF UPPER(@Filtro) = 'PaymentFreqFinancedJSON'
       BEGIN
             SELECT [id],
                      [name]
             FROM VW_PAYMENT_FREQ
               where idSelected in (5,6,7,8,9,10,11)
       END
       ELSE IF UPPER(@Filtro) = 'Operators'
       BEGIN
             SELECT '='as [id],
                      '='as [name]
             union
               SELECT '>'as [id],
                      '>'as [name]
             union
               SELECT '<'as [id],
                      '<'as [name]
       END
       ELSE IF UPPER(@Filtro) = 'ProductTypeFamilyBrochure'
       BEGIN
             SELECT CAST([id] as varchar) as [id],
                      [name] as [name]
             FROM [POS].[PRODUCT_TYPE_FAMILY_BROCHURE]
               where [BusinessLine_Id] = 1
       END
       ELSE IF UPPER(@Filtro) = 'FILTROHISTORICO'
       BEGIN
             SELECT CAST('1' as varchar) as [id],
                      'Nueva Cotización' as [name]
                           UNION
             SELECT CAST('2' as varchar) as [id],
                      'Histórico Cotizaciones' as [name]
                           UNION
             SELECT CAST('3' as varchar) as [id],
                      'Inclusión' as [name]
                           UNION
             SELECT CAST('4' as varchar) as [id],
                      'Exclusión' as [name]
                           UNION
               SELECT CAST('5' as varchar) as [id],
                      'Cambios' as [name]
       END
       ELSE IF UPPER(@Filtro) = 'TYPEOFPERSONS'
       BEGIN
             SELECT CAST('1' as varchar) as [id],
                      'Persona Física Nacional' as [name]
                           UNION
             SELECT CAST('2' as varchar) as [id],
                      'Persona Jurídica Nacional' as [name]
                           UNION
             SELECT CAST('3' as varchar) as [id],
                      'Persona Física Extranjera' as [name]
                           UNION
             SELECT CAST('4' as varchar) as [id],
                      'Persona Jurídica Extranjera' as [name]
                           UNION
             SELECT CAST('5' as varchar) as [id],
                      'Organismos Públicos y Gubernamentales Nacionales' as [name]
                           UNION
             SELECT CAST('6' as varchar) as [id],
                      'Organismos Públicos y Gubernamentales Internacionales' as [name]
       END
       ELSE IF UPPER(@Filtro) = 'ConfigPaymentOptionsInclusionLaw'
       BEGIN
       /*
       Mayor de 9 meses todas las opciones
       Entre 6 y 9  (3 cuotas, 2 cuotas, 1 cuota)
       Entre 3 y 6 (2 cuotas, 1 cuota)
       Menor de 3 meses pago unico       
       */

       select '>9' as id,'todas las opciones' as name
       UNION
       select '6,9' as id,'3 cuotas, 2 cuotas, 1 cuota' as name
       UNION
       select '3,6' as id,'2 cuotas, 1 cuota' as name
       UNION
       select '<3' as id,'pago unico' as name
       END

       ELSE IF UPPER(@Filtro) = 'DEFAULTCITY'
       BEGIN
             Select top 1
                    cast([Domesticreg_Id] as nvarchar) +'-' + cast([State_Prov_Id] as nvarchar) + '-' + cast(isnull([Municipio_Id],0) as nvarchar) + '-' + cast([City_Id] as nvarchar) as [id]
                    ,UPPER(City_Desc) as [name]
             FROM
                    [Global].[ST_GLOBAL_CITY] with(nolock)
             Where
                    City_Status = 0
                    and Country_Id = 129
             Order by City_Desc
       END
       ELSE IF UPPER(@Filtro) = 'GETALLUSERSACCESSPV'
       BEGIN
       DECLARE @TBLTemp TABLE (id varchar(max), name VARCHAR(MAX))
             insert into @TBLTemp
             EXEC [dbo].[SP_GET_ALL_USERS_WITH_ACCESS_PV] @UserID = NULL
             SELECT id,name FROM @TBLTemp
       END
       ELSE IF UPPER(@Filtro) = 'PHONETYPES'
       BEGIN
             SELECT CAST('1' as varchar) as [id],
                                  'Teléfono Móvil' as [name]
                                  UNION
                      SELECT CAST('2' as varchar) as [id],
                                  'Teléfono Fijo' as [name]
       END    
END

