



IF OBJECT_ID('tempdb..#Vehicles') IS NOT NULL
DROP TABLE #Vehicles

	
SELECT distinct  
 marca.DatoAlf AS 'Brand' --MARCA
,MODELO.DatoAlf Model
,ano.datoalf [Year]
,tv.DatoAlf VehicleType
,Tp.Descripcion [Plan]
,C.MontoAsegurado AS EnsuredAmount
,'11' AS NoRegistro
,CHASIS.DatoAlf Chasis
,isnull (dpcd.ValorLey,0)				ThirdDamagesPrime
,isnull (dpcd.ValorPropios,0)			SelfDamagesPrime
,isnull (dpcd.ValorImpuestos,0)			Subtotal_Impuestos
,isnull (dpcd.ValorServicio,0)			Subtotal_Servicios
,0.00 AS					AdditionalsPrime
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
   AND A.Poliza = ltrim(rtrim('1-05-402837'))
   AND A.Tipo=10





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


FOR XML AUTo,TYPE, ELEMENTS
