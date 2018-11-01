Alter PROCEDURE [dbo].[ATL_TraspasoCartera]
  
 @IntermediarioOrigen  int	  --= 6424
 ,@IntermediarioDestino int	 -- = 13964
 ,@PolizaCliente varchar(50)

AS  

Declare @SQLCommand varchar(900)
DECLARE @cPoliza varchar(20)

DECLARE @Contador	int = 0

declare   @Compania        int         = 30 
declare   @Poliza          varchar(50) 
declare   @IdIntermediario int         
declare   @Usuario         varchar(50) = 'Administrator'
declare   @CodigoConcepto  int         = 28
declare   @Indicador       int         = 1 -- 1 EMISION

declare @NombreAgente varchar(100) 

DECLARE @tPolizas TABLE (poliza varchar(20))


IF @PolizaCliente != ''
(
    SELECT Poliza
    FROM p_polizaheader
    WHERE dbo.p_polizaheader.Intermediario = @IntermediarioOrigen
          AND poliza = @PolizaCliente
);
    ELSE
(
    SELECT Poliza
    FROM p_polizaheader
    WHERE dbo.p_polizaheader.Intermediario = @IntermediarioOrigen   --and poliza =@PolizaCliente 
); 



DECLARE CursorTraspasoCartera CURSOR FAST_FORWARD FOR
 
SELECT tp.* FROM @tPolizas tp
ORDER BY tp.poliza


OPEN CursorTraspasoCartera;

FETCH NEXT FROM CursorTraspasoCartera INTO 	@cPoliza;                                

WHILE @@FETCH_STATUS = 0

BEGIN -- 00
	 set @IdIntermediario = @IntermediarioDestino
	 set @Poliza = @cPoliza
	 SET @Contador = @Contador + 1
	   
	 SET @NombreAgente = (Select NombreVendedor From Cxc_Vendedor Where Compania = @Compania And Codigo = @IdIntermediario  )  

	 -- print 'Entro ' + concat(@Contador,' : ') + @cPoliza  -- + '  params: '+ concat(@Compania ,'|', @Poliza ,'|', @IdIntermediario, '|', @Usuario , '|',  @CodigoConcepto ,'|',  @Indicador , '|', @NombreAgente  )


	 EXEC	 [WebServices].[SPCCambioIntermediario] @Compania , @Poliza , @IdIntermediario, @Usuario ,  @CodigoConcepto ,  @Indicador   

      Update In_DocumentoCobrar Set Vendedor = @IdIntermediario, NombreVendedor = @NombreAgente  Where Compania = @Compania  And Poliza = @Poliza -- And NumeroCotizacion = @Cotizacion    And SecuenciaPoliza >= isnull(@SecuenciaMov,0);
      UPDATE [dbo].[P_PolizaHeaderMov]  SET  Intermediario = @IdIntermediario     Where Compania = @Compania  And Poliza = @Poliza ;

	-- execute(@SQLCommand)
			          
	FETCH NEXT FROM CursorTraspasoCartera INTO @cPoliza;

END -- 00	

CLOSE CursorTraspasoCartera;

DEALLOCATE CursorTraspasoCartera;
