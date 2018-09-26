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


<?xml version="1.0" encoding="utf-8"?>
<!--
  For more information on how to configure your ASP.NET application, please visit
  http://go.microsoft.com/fwlink/?LinkId=301880
  -->
<configuration>
  <configSections>
    <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
    <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
  </configSections>
  <connectionStrings>
    <add name="LoansEntities" connectionString="metadata=res://*/EFModel.CobranzaModel.csdl|res://*/EFModel.CobranzaModel.ssdl|res://*/EFModel.CobranzaModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=10.14.2.14;initial catalog=Loans;persist security info=True;user id=clebron;password=Clebron@2018;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
    <add name="Statetrust.Framework.SecurityConnectionString" connectionString="Data Source=atl-dev05.dev.atlantica.local;Initial Catalog=Security;User ID=Developer05;Password=Developer05" />
    <!--<add name="STFGlobalEntities" connectionString="metadata=res://*/STFGlobalEntities.csdl|res://*/STFGlobalEntities.ssdl|res://*/STFGlobalEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=172.16.193.14;initial catalog=Global;persist security info=True;user id=Developer05;password=Developer05;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />-->
    <add connectionString="metadata=res://*/Global.GlobalEntities.csdl|res://*/Global.GlobalEntities.ssdl|res://*/Global.GlobalEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=10.14.2.14;initial catalog=global_Prod;persist security info=True;user ID=jgomez;Password=jgomez@2017;MultipleActiveResultSets=True;App=EntityFramework&quot;" name="GlobalEntities" providerName="System.Data.EntityClient" />
    
  </connectionStrings>
  <appSettings>
    <add key="webpages:Version" value="3.0.0.0" />
    <add key="webpages:Enabled" value="false" />
    <add key="ClientValidationEnabled" value="true" />
    <add key="UnobtrusiveJavaScriptEnabled" value="true" />
    <add key="EncriptionKey" value="$t@teTru$t" />
    <!--configuraciones Modulo Seguridad-->
    <add key="AppID" value="COBRA" />
    <add key="NewBusinessAppId" value="NBDEV" />
    <add key="SecurityMenuBar" value="true" />
    <add key="ApplySecurity" value="false" />
    <add key="appTitle" value="Recaudo" />
    <add key="ApplicationLogin" value="true" />
    <add key="SecurityLogin" value="http://singlesignin.ksi-dev.do/" />
    <add key="logoCompany" value="logo_atl" />
    <add key="STFIncludeKnockout" value="true" />
    <add key="STFIncludeJquery" value="false" />
    <add key="STFIncludeJqueryUI" value="false" />
    <add key="STFIncludeJqueryForm" value="true" />
    <add key="STFJqueryVersion" value="jQuery_v1_11_3" />
    <add key="STFShowAvailableApps" value="true" />
    <add key="STFSessionNotification" value="true" />
    <add key="STFSessionTimeWarning" value="1" />
    <add key="STFEditAgentProfile" value="false" />
    <add key="STFAddResetCss" value="false" />
    <add key="STFShowChangeCompany" value="true" />
    <add key="STFShowLogo" value="true" />
    <add key="STFEmailHost" value="statetrustlife-com.mail.protection.outlook.com" />
    <add key="STFEmailFrom" value="mvasquez@statetrustlife.com" />
    <add key="STFApplySecurityScript" value="true" />
    <add key="HideVaribleURL" value="false"/>
  </appSettings>
  <system.web>
    <authentication mode="None" />
    <compilation debug="true" targetFramework="4.5.2" />
    <httpRuntime targetFramework="4.5.2" />
    <httpModules>
      <!--<add name="ApplicationInsightsWebTracking" type="Microsoft.ApplicationInsights.Web.ApplicationInsightsHttpModule, Microsoft.AI.Web" />-->
    </httpModules>
  </system.web>
  <system.webServer>
    <modules>
      <remove name="FormsAuthentication" />
      <!--<remove name="ApplicationInsightsWebTracking" />
      <add name="ApplicationInsightsWebTracking" type="Microsoft.ApplicationInsights.Web.ApplicationInsightsHttpModule, Microsoft.AI.Web" preCondition="managedHandler" />-->
    </modules>
    <validation validateIntegratedModeConfiguration="false" />
  </system.webServer>
  <runtime>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="Microsoft.Owin.Security" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="0.0.0.0-3.0.1.0" newVersion="3.0.1.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="Microsoft.Owin.Security.OAuth" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="0.0.0.0-3.0.1.0" newVersion="3.0.1.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="Microsoft.Owin.Security.Cookies" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="0.0.0.0-3.0.1.0" newVersion="3.0.1.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="Microsoft.Owin" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="0.0.0.0-3.0.1.0" newVersion="3.0.1.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="Newtonsoft.Json" culture="neutral" publicKeyToken="30ad4fe6b2a6aeed" />
        <bindingRedirect oldVersion="0.0.0.0-6.0.0.0" newVersion="6.0.0.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Optimization" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="1.0.0.0-1.1.0.0" newVersion="1.1.0.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="WebGrease" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="0.0.0.0-1.5.2.14234" newVersion="1.5.2.14234" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Helpers" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="1.0.0.0-3.0.0.0" newVersion="3.0.0.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Mvc" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="1.0.0.0-5.2.3.0" newVersion="5.2.3.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.WebPages" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="1.0.0.0-3.0.0.0" newVersion="3.0.0.0" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
  <entityFramework>
    <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
    <providers>
      <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
    </providers>
  </entityFramework>
  <system.codedom>
    <compilers>
      <compiler language="c#;cs;csharp" extension=".cs" type="Microsoft.CodeDom.Providers.DotNetCompilerPlatform.CSharpCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" warningLevel="4" compilerOptions="/langversion:6 /nowarn:1659;1699;1701" />
      <compiler language="vb;vbs;visualbasic;vbscript" extension=".vb" type="Microsoft.CodeDom.Providers.DotNetCompilerPlatform.VBCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" warningLevel="4" compilerOptions="/langversion:14 /nowarn:41008 /define:_MYTYPE=\&quot;Web\&quot; /optionInfer+" />
    </compilers>
  </system.codedom>
</configuration>

