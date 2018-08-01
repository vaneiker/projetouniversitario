----------------------------------------
------------------DONE------------------
----------------------------------------

--120028		DE LEY
--SELECT Poliza,NumeroCotizacion,* FROM IN_DocumentoCobrar WHERE NumeroCotizacion =120028		
--EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '05-373609-2015',2
--EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '05-373609-2015',3


--1201610389	VIP (FULL)
--SELECT Poliza,NumeroCotizacion,* FROM IN_DocumentoCobrar WHERE NumeroCotizacion =1201610389
--EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '1-05-401194',2
--EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '1-05-401194',3

--120161039		ECONO MAX
--SELECT Poliza,NumeroCotizacion,* FROM IN_DocumentoCobrar WHERE NumeroCotizacion =120161039
--EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '1-05-395242',2
--EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '1-05-395242',3
--SELECT * FROM P_PolCondicionMov WHERE Cotizacion =120161039


----1201527762	TOTAL PLUS (FULL)
----SELECT Poliza,NumeroCotizacion,* FROM IN_DocumentoCobrar WHERE NumeroCotizacion =1201527762
--EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '1-05-383745',2
--EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '1-05-383745',3
----SELECT * FROM P_PolCondicionMov WHERE Cotizacion =1201527762

--1201615039	ECONO VIDA
--SELECT Poliza,NumeroCotizacion,* FROM IN_DocumentoCobrar WHERE NumeroCotizacion =1201615039
EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '1-05-404446',2
EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '1-05-404446',3
--SELECT * FROM P_PolCondicionMov WHERE Cotizacion =1201615039

----1201620327	ULTRA
----SELECT Poliza,NumeroCotizacion,* FROM IN_DocumentoCobrar WHERE POliza ='1-05-407300'
--EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '1-05-407300',2
--EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '1-05-407300',3
----SELECT * FROM P_PolCondicionMov WHERE Cotizacion =1201620327



----1201611765	SERIE M	
----SELECT Poliza,NumeroCotizacion,* FROM IN_DocumentoCobrar WHERE POliza ='1-05-402488'
--EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '1-05-402488',2
--EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '1-05-402488',3
----SELECT * FROM P_PolCondicionMov WHERE Cotizacion =1201611765

/**/

















--PENDING
--------ERROR: No hay Coberturas
--------120161491	VIP (FULL)
--------SELECT Poliza,NumeroCotizacion,* FROM IN_DocumentoCobrar WHERE POliza ='1-05-395320'
----EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '1-05-395320',2
----EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '1-05-395320',3
------SELECT * FROM P_PolCondicionMov WHERE Cotizacion =120161491



----PRIMA SUPLEMENTOS 
----1201621697	TOTAL (SEMI-FULL)
----SELECT Poliza,NumeroCotizacion,* FROM IN_DocumentoCobrar WHERE POliza ='1-05-408105'
----EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '1-05-408105',2
----EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '1-05-408105',3
----SELECT * FROM P_PolCondicionMov WHERE Cotizacion =1201621697



----1200329		TOTAL (SEMI-FULL) --Totales en Cero...
----SELECT Poliza,NumeroCotizacion,* FROM IN_DocumentoCobrar WHERE NumeroCotizacion =1200329
----EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '05-006626-2003',2
----EXEC [THService].[USP_THUNDERHEAD_NOTIFY] '05-006626-2003',3
----SELECT * FROM P_PolCondicionMov WHERE Cotizacion =1200329


GO
SELECT * FROM Exceptions
GO
SELECT * FROM [Transaction_Control].[TC_Thunderhead_Webservice_Trans]
GO
TRUNCATE TABLE Exceptions
GO
TRUNCATE TABLE [Transaction_Control].[TC_Thunderhead_Webservice_Trans]
GO
SELECT * FROM Exceptions
GO
SELECT * FROM [Transaction_Control].[TC_Thunderhead_Webservice_Trans]
