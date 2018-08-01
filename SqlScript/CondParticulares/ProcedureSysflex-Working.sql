DECLARE 
--PARAMETERS
 @PolicyId varchar(60) ='1-05-402837'
,@Trans_Type_Id	AS INT  = 1

--VARIABLES
, @XmlTransaction				AS XML
, @XmlDrivers as XML
, @XmlPaquete as XML
, @BCCEmail						AS NVARCHAR(1000)
, @SMS							AS BIT
, @XmlVehicles    as XML
, @XmlPrimeResume	as XML
, @Cotizacion INT = 0
, @Fianza NUMERIC(12,2)
, @DocumentId	    AS INT = 0 ;

--COR-Bienvenido a Atlántica Seguros
	SELECT 	 @DocumentId = T.Document_Id
			,@BCCEmail	= COALESCE(T.Mail,'')
			,@SMS		= Send_SMS


	FROM  [Transaction_Control].vw_TC_Transaction_Types t
	WHERE Trans_Type_Id = @Trans_Type_Id	
	


--PARA OBTENER LA FIANZA
SELECT  @Cotizacion = cotizacion FROM P_PolizaHeader WHERE Poliza = @PolicyId --Cotizacion=5201516402
SET		@Fianza = isnull ((SELECT  CASE WHEN len(montoinformativo)=0
								THEN 0
									ELSE
								isNull(convert(NUMERIC(12,2),ltrim(rtrim(replace(replace(replace(montoinformativo,',',''),'','0'),'001','0')))),0) 
				END			AS Fianza FROM P_PolizaCoberturasMov WHERE cotizacion = @Cotizacion
		and secuencia = 9 and SecuenciaMov = 1), 0)

IF OBJECT_ID('tempdb..#tbTransaction') IS NOT NULL
DROP TABLE #tbTransaction

 
 SELECT TOP 1 @DocumentId AS DocumentId
			 ,ISNULL (Cli.NombreCliente,'-') AS Fullname
             ,ISNULL (A.Poliza, '-') AS NoPoliza
		     ,'AUTO'   AS TipoPoliza
			 ,ISNULL (b.UsuarioAdiciona,'-')  AS Username
			 ,ISNULL (CONVERT(NVARCHAR,C.FechaInicioVigencia,103),'09/09/1800')   as FechaInicio
             ,ISNULL (CONVERT(NVARCHAR,C.FechaFinVigencia,103),'09/09/1800') as FechaVencimiento
			 ,ISNULL (Vend.NombreVendedor,'-')	as	AgenteComercial
			 ,CAST (Vend.Codigo AS varchar)			as	NumeroAgenteComercial
			 ,ISNULL (Sup.NombreSupervisor, '-')			Supervisor
			 ,CONVERT(NUMERIC(10,2),@Fianza)  as Fianza			  
			 ,@BCCEmail as BCCopy
			 ,@BCCEmail as CCopy
			 --,ISNULL (LTRIM(rtrim(cli.celular)), '-') as NumeroCelular
			 ,ISNULL (LTRIM(rtrim('829-805-0892')), '-') as NumeroCelular
			 ,CAST (B.cotizacion AS varchar) 	as QuotationNumber	
			 ,ISNULL (CONVERT(NVARCHAR,Cotizacion.FechaAdiciona,103),'09/09/1800')	as QuotationDate	
			 ,ISNULL (pdm.tipovehiculo, '-')			Product
			 ,ISNULL (Tp.Descripcion, '-')		 as [Plan]
			 ,CASE Cli.tipornc 
						WHEN 1 THEN 'Cedula' 
						WHEN 2 THEN 'Pasaporte' 
						WHEN 0 THEN 'RNC'
						END AS IdType
		    ,ISNULL (Cli.rnc, '-')					IdNumber
			,ISNULL (CONVERT(NVARCHAR,Cli.FechaNacimiento,103),'09/09/1800') as BirthDate
			,LTRIM(rtrim(COALESCE (cli.TelefonoOficina,cli.telefonooficina, cli.celular))) TelephoneNumber
			--,Cli.Email Email
			,@BCCEmail Email
			,CuotasPago.CantidadCuotas	NumberOfPayments
			,CantidadVehiculos.CantidadVehiculos NumberOfVehicles
			,CONVERT(NUMERIC(10,2),dpcd.valor)	as TotalAnualPrime
			,CONVERT(NUMERIC(10,2),dpcd.ValorImpuestos) as Taxes
			,CONVERT(NUMERIC(10,2),0) as Discount
			,CONVERT(NUMERIC(10,2),Isnull (dpcd.valor,0)- isnull (dpcd.ValorImpuestos,0)) as TotalPayment
into #tbTransaction
 from    IN_DocumentoCobrar A  --Factura
				left join P_PolizaHeaderMov   B on a.Poliza=b.Poliza and a.NumeroCotizacion=b.Cotizacion and a.SecuenciaPoliza=b.SecuenciaMov --MOVIMIENTO
				left join P_PolizaDetailmov C on b.Ramo=c.Ramo and b.Cotizacion=c.Cotizacion and b.SecuenciaMov=c.SecuenciaMov --DETALLE MOVIMIENTO
				left Join CXC_Clientes Cli on b.Cliente=cli.Codigo --CLIENTE
				left join CXC_Vendedor Vend on vend.Codigo	=	a.vendedor
				left join CXC_Supervisor Sup on Sup.Codigo = vend.CodigoSupervisor
				---DATOS VEHICULO EN EL MOVIMIENTO
				left join P_PolCondicionMov TV on TV.Ramo=c.Ramo and Tv.subramo=C.subramo and tv.Cotizacion=c.Cotizacion and tv.SecuenciaCot=c.Secuencia and tv.SecuenciaCondicion=1 and TV.Descripcion='TIPO VEHICULO' and tv.SecuenciaMov=c.SecuenciaMov
				left join P_PolCondicionMov ANO on ANO.Ramo=c.Ramo and ANO.subramo=C.subramo and ANO.Cotizacion=c.Cotizacion and ANO.SecuenciaCot=c.Secuencia and ANO.SecuenciaCondicion=4 and ANO.Descripcion='AÑO' and ano.SecuenciaMov=c.SecuenciaMov
				left join P_PolCondicionMov MARCA on MARCA.Ramo=c.Ramo and MARCA.subramo=C.subramo and MARCA.Cotizacion=c.Cotizacion and MARCA.SecuenciaCot=c.Secuencia and MARCA.SecuenciaCondicion=2 and MARCA.Descripcion='MARCA' and marca.SecuenciaMov=c.SecuenciaMov
				left join P_PolCondicionMov MODELO on MODELO.Ramo=c.Ramo and MODELO.subramo=C.subramo and MODELO.Cotizacion=c.Cotizacion and MODELO.SecuenciaCot=c.Secuencia and MODELO.SecuenciaCondicion=3 and MODELO.Descripcion='MODELO' and modelo.SecuenciaMov=c.SecuenciaMov
				left join P_PolCondicionMov PLACA on PLACA.Ramo=c.Ramo and PLACA.subramo=C.subramo and PLACA.Cotizacion=c.Cotizacion and PLACA.SecuenciaCot=c.Secuencia and PLACA.SecuenciaCondicion=7 and placa.SecuenciaMov=c.SecuenciaMov --- and MARCA.Descripcion='REGISTRO NO.'
				left join P_PolCondicionMov CHASIS on CHASIS.Ramo=c.Ramo and CHASIS.subramo=C.subramo and CHASIS.Cotizacion=c.Cotizacion and CHASIS.SecuenciaCot=c.Secuencia and CHASIS.SecuenciaCondicion=6 and chasis.SecuenciaMov=c.SecuenciaMov ---and CHASIS.Descripcion='CHASIS'
				Left join P_CotizacionHeader Cotizacion on a.NumeroCotizacion=Cotizacion.Cotizacion and Cotizacion.Ramo=106 --COTIZACION
				Left join TipoPolizaSubRamo TPS on c.Ramo=tps.ramo and c.SubRamo=tps.SubRamo 
				Left join TipoPoliza TP on tps.CodigoTipoPoliza=tp.Codigo --TIPO POLIZA
				----- CUOTAS DE PAGO
				Left join 
							 (
						 select Numero, Tipo, poliza,  count (*) CantidadCuotas from IN_FormaCobrarCxc 
						 group by Numero, Tipo, poliza
						 ) CuotasPago on CuotasPago.Numero=a.Numero and CuotasPago.Tipo=a.Tipo and CuotasPago.Poliza=a.Poliza
				----- CANTIDA DE VEHICULOS EN EL MOVIMIENTO
				Left join 
							 (
							 Select ramo,Cotizacion,SecuenciaMov, count (*) CantidadVehiculos from P_PolizaDetailMov 
							 group by ramo,Cotizacion,SecuenciaMov
							 ) CantidadVehiculos on b.Cotizacion=CantidadVehiculos.Cotizacion and b.Ramo=CantidadVehiculos.Ramo and b.SecuenciaMov=CantidadVehiculos.SecuenciaMov
				----COBERTURAS
				--left  join  P_PolizaCoberturasMov DPA1 on  c.Cotizacion=dpa1.cotizacion  and  c.ramo=dpa1.ramo and  c.subramo=dpa1.SubRamo and  c.Secuencia=dpa1.SecuenciaCot and  c.SecuenciaMov=dpa1.SecuenciaMov
				----TIPO DE PRODUCTO A VENDER
				left join P_PolizaDetailMov PDM on pdm.Compania=c.Compania	and pdm.Cotizacion=c.Cotizacion	and pdm.Ramo=c.Ramo	and pdm.SubRamo=c.SubRamo	and pdm.Secuencia=c.Secuencia and  pdm.SecuenciaMov=b.SecuenciaMov
				---- PRIMAS TOTALIZADAS
				left join IN_DocumentoCobrarPrimadetalle DPCD on dpcd.Cotizacion = b.cotizacion and dpcd.Tipo = 10  and dpcd.secuenciaMov = c.SecuenciaMov

 WHERE A.Concepto='EMISION'
 AND A.Poliza = ltrim(rtrim(@PolicyId))
 AND A.Tipo=10

SET @XmlTransaction =  ( 
SELECT 
			DocumentId
			,Fullname
			,NoPoliza
			,TipoPoliza
			,Username
			,FechaInicio
			,FechaVencimiento
			,NumeroAgenteComercial
			,AgenteComercial
			,Supervisor
			,Fianza
			,BCCopy
			,CCopy
			,NumeroCelular
 FROM #tbTransaction AS [Transaction]
 FOR XML AUTO ,ELEMENTS)



 
set  @XmlDrivers  =  ( 
SELECT		Fullname AS Name
			,IdType
			,IdNumber
			,BirthDate
			,isnull(Email,'')+',gipaulino@statetrustlife.com,jalmonte@statetrustlife.com,eaquino@atlantica.do' Email
			,TelephoneNumber
 FROM #tbTransaction AS [Drivers]
 FOR XML AUTO ,ELEMENTS)


set  @XmlPaquete =  ( 
	SELECT top 1 
			 Fullname AS Solicitante
			,QuotationNumber
			,QuotationDate
			,TipoPoliza as LineOfBusiness
			,Product
			,[Plan]
			,FechaInicio as StartDate
			,FechaVencimiento as EndDate
			,QuotationDate as ProposalDate
			,IdType
			,IdNumber
			,TelephoneNumber
			,Email
			,NumberOfPayments
			,NumberOfVehicles
 FROM #tbTransaction AS [Paquete]
		FOR XML AUTO ,ELEMENTS)

SET @XmlPrimeResume				 = ( 
	SELECT top 1 
			TotalAnualPrime
			,Taxes
			,Discount
			,TotalPayment 
 FROM #tbTransaction AS [PrimeResume]
		FOR XML AUTO ,ELEMENTS);





IF OBJECT_ID('tempdb..#Vehicles') IS NOT NULL
DROP TABLE #Vehicles
BEGIN
	
SELECT distinct  
 marca.DatoAlf AS 'Brand' --MARCA
,MODELO.DatoAlf Model
,ano.datoalf [Year]
,tv.DatoAlf VehicleType
,Tp.Descripcion [Plan]
,C.MontoAsegurado AS EnsuredAmount
,isnull (Placa,'-') AS NoRegistro
,CHASIS.DatoAlf Chasis
,isnull (dpcd.ValorLey,0)				ThirdDamagesPrime
,isnull (dpcd.ValorPropios,0)			SelfDamagesPrime
,isnull (dpcd.ValorImpuestos,0)			Subtotal_Impuestos
,isnull (dpcd.ValorServicio,0)			AdditionalsPrime
,isnull(dpcd.valor,0)					TotalVehiclePrime
,b.Cotizacion as Cotizacion
,c.Secuencia as Secuencia

into #Vehicles
 FROM IN_DocumentoCobrar A --Factura
 LEFT JOIN P_PolizaHeaderMov B ON a.Poliza=b.Poliza
 AND a.NumeroCotizacion=b.Cotizacion
 AND a.SecuenciaPoliza=b.SecuenciaMov --MOVIMIENTO
 LEFT JOIN P_PolizaDetailmov C ON b.Ramo=c.Ramo
 AND b.Cotizacion=c.Cotizacion
 AND b.SecuenciaMov=c.SecuenciaMov --DETALLE MOVIMIENTO
 LEFT JOIN CXC_Clientes Cli ON b.Cliente=cli.Codigo --CLIENTE
 ---DATOS VEHICULO EN EL MOVIMIENTO
 LEFT JOIN P_PolCondicionMov TV ON TV.Ramo=c.Ramo
 AND Tv.subramo=C.subramo
 AND tv.Cotizacion=c.Cotizacion
 AND tv.SecuenciaCot=c.Secuencia
 AND tv.SecuenciaCondicion=1
 AND TV.Descripcion='TIPO VEHICULO'
 AND tv.SecuenciaMov=c.SecuenciaMov
 LEFT JOIN P_PolCondicionMov ANO ON ANO.Ramo=c.Ramo
 AND ANO.subramo=C.subramo
 AND ANO.Cotizacion=c.Cotizacion
 AND ANO.SecuenciaCot=c.Secuencia
 AND ANO.SecuenciaCondicion=4
 AND ANO.Descripcion='AÑO'
 AND ano.SecuenciaMov=c.SecuenciaMov
 LEFT JOIN P_PolCondicionMov MARCA ON MARCA.Ramo=c.Ramo
 AND MARCA.subramo=C.subramo
 AND MARCA.Cotizacion=c.Cotizacion
 AND MARCA.SecuenciaCot=c.Secuencia
 AND MARCA.SecuenciaCondicion=2
 AND MARCA.Descripcion='MARCA'
 AND marca.SecuenciaMov=c.SecuenciaMov
 LEFT JOIN P_PolCondicionMov MODELO ON MODELO.Ramo=c.Ramo
 AND MODELO.subramo=C.subramo
 AND MODELO.Cotizacion=c.Cotizacion
 AND MODELO.SecuenciaCot=c.Secuencia
 AND MODELO.SecuenciaCondicion=3
 AND MODELO.Descripcion='MODELO'
 AND modelo.SecuenciaMov=c.SecuenciaMov
 LEFT JOIN P_PolCondicionMov PLACA ON PLACA.Ramo=c.Ramo
 AND PLACA.subramo=C.subramo
 AND PLACA.Cotizacion=c.Cotizacion
 AND PLACA.SecuenciaCot=c.Secuencia
 AND PLACA.SecuenciaCondicion=7
 AND placa.SecuenciaMov=c.SecuenciaMov --- and MARCA.Descripcion='REGISTRO NO.'
 LEFT JOIN P_PolCondicionMov CHASIS ON CHASIS.Ramo=c.Ramo
 AND CHASIS.subramo=C.subramo
 AND CHASIS.Cotizacion=c.Cotizacion
 AND CHASIS.SecuenciaCot=c.Secuencia
 AND CHASIS.SecuenciaCondicion=6
 AND chasis.SecuenciaMov=c.SecuenciaMov ---and CHASIS.Descripcion='CHASIS'
 LEFT JOIN TipoPolizaSubRamo TPS ON c.Ramo=tps.ramo
 AND c.SubRamo=tps.SubRamo
 LEFT JOIN TipoPoliza TP ON tps.CodigoTipoPoliza=tp.Codigo --TIPO POLIZA
 ----- CUOTAS DE PAGO

 LEFT JOIN
   ( SELECT Numero,
            Tipo,
            poliza,
            COUNT (*) CantidadCuotas
    FROM IN_FormaCobrarCxc
    GROUP BY Numero,
             Tipo,
             poliza ) CuotasPago ON CuotasPago.Numero=a.Numero
 AND CuotasPago.Tipo=a.Tipo
 AND CuotasPago.Poliza=a.Poliza ----- CANTIDA DE VEHICULOS EN EL MOVIMIENTO

 LEFT JOIN
   ( SELECT ramo,
            Cotizacion,
            SecuenciaMov,
            COUNT (*) CantidadVehiculos
    FROM P_PolizaDetailMov
    GROUP BY ramo,
             Cotizacion,
             SecuenciaMov ) CantidadVehiculos ON b.Cotizacion=CantidadVehiculos.Cotizacion
 AND b.Ramo=CantidadVehiculos.Ramo
 AND b.SecuenciaMov=CantidadVehiculos.SecuenciaMov ----COBERTURAS
 LEFT  JOIN P_PolizaCoberturasMov DPA1 ON c.Cotizacion=dpa1.cotizacion
 AND c.ramo=dpa1.ramo
 AND c.subramo=dpa1.SubRamo
 AND c.Secuencia=dpa1.SecuenciaCot
 AND c.SecuenciaMov=dpa1.SecuenciaMov ---- 
 LEFT JOIN IN_DocumentoCobrarPrimadetalle DPCD on dpcd.Cotizacion = b.cotizacion and dpcd.Tipo = 10  and dpcd.secuenciaMov = c.SecuenciaMov

 WHERE A.Concepto='EMISION'
   AND A.Poliza = ltrim(rtrim(@PolicyId))
   AND A.Tipo=10




					   
SET @XmlVehicles =(


SELECT 

 Vehicles.Brand
,Vehicles.Model
,Vehicles.[Year]
,Vehicles.VehicleType
,Vehicles.[Plan]
,Vehicles.EnsuredAmount
,Vehicles.NoRegistro
,Vehicles.Chasis
,(select * from (SELECT [Description], Limit from  [THService].[fnGetDeducible]( 	Vehicles.Cotizacion, 'DAÑOS A TERCEROS',Vehicles.Secuencia)   )		AS ThirdDamagesCoverages		FOR XML AUTO, TYPE, ELEMENTS)   
,Vehicles.ThirdDamagesPrime
,(select * from (SELECT [Description], Limit, Deducible, DeducibleMinimo from  [THService].[fnGetDeducible]( 	Vehicles.Cotizacion, 'DAÑOS PROPIOS',Vehicles.Secuencia)   )		AS SelfDamagesCoverages		FOR XML AUTO, TYPE, ELEMENTS)   
,Vehicles.SelfDamagesPrime
,(select * from (SELECT [Description], Limit from  [THService].[fnGetDeducible]( 	Vehicles.Cotizacion, 'SERVICIOS',Vehicles.Secuencia)   )		AS Additionals		FOR XML AUTO, TYPE, ELEMENTS)   
,Vehicles.AdditionalsPrime
,Vehicles.TotalVehiclePrime

FROM #Vehicles Vehicles


FOR XML AUTo,TYPE, ELEMENTS)

end







SET @XmlPaquete.modify('insert (sql:variable("@XmlDrivers")) into(/Paquete[1])')
SET @XmlPaquete.modify('insert (sql:variable("@XmlVehicles")) into(/Paquete[1])')
SET @XmlPaquete.modify('insert (sql:variable("@XmlPrimeResume")) into(/Paquete[1])')


SELECT @XmlTransaction
SELECT @XmlPaquete





--SELECT CONVERT(NVARCHAR,GETDATE(),103)