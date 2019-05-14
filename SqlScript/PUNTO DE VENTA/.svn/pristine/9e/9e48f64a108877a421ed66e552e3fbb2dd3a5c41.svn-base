# Install.ps1
param($installPath, $toolsPath, $package, $project)
"testing" >> 'C:\ggarcia\test.txt'
$xml = New-Object xml
# find the Web.config file
$config = $project.ProjectItems | where {$_.Name -eq "Web.config"}

# find its path on the file system
$localPath = $config.Properties | where {$_.Name -eq "LocalPath"}

# load Web.config as XML
$xml.Load($localPath.Value)


if($xml.configuration.appSettings -eq $null){
[xml]$appSettingsXml = @'
<appSettings>
    <add key="STFIncludeJquery" value="false" />
    <add key="STFIncludeJqueryUI" value="false" />
    <add key="STFIncludeJqueryForm" value="false" />
    <add key="STFJqueryVersion" value="jQuery_v1_11_3" />
    <add key="STFShowAvailableApps" value="false" />
    <add key="STFSessionNotification" value="false" />
    <add key="STFSessionTimeWarning" value="1" />
    <add key="STFEditAgentProfile" value="false" />
    <add key="STFShowChangeCompany" value="false" />
    <add key="AppID" value="0" />
    <add key="SecurityMenuBar" value="false" />
    <add key="ApplySecurity" value="false" />
    <add key="appTitle" value="Test" />
    <add key="ApplicationLogin" value="true" />
    <add key="SecurityLogin" value="http://atlanticasecurity.qa.atlantica.local/index.aspx" />
    <add key="EncriptionKey" value="$t@teTru$t" />
    <add key="STFShowLogo" value="true" />
    <add key="STFEmailHost" value="statetrustlife-com.mail.protection.outlook.com" />
    <add key="STFEmailFrom" value="cambios@statetrustlife.com" />
    <add key="STFAutoRegisterRoute" value="true" />
    <add key="STFApplySecurityScript" value="true" />
</appSettings>
'@
$xml.configuration.AppendChild($xml.ImportNode($appSettingsXml.appSettings, $true))
}else {

$lstAppSettings = @(("EncriptionKey",'$t@teTru$t'),
    ("STFIncludeJquery","false"),
    ("STFIncludeJqueryUI","false"),
    ("STFIncludeJqueryForm","false"),
    ("STFJqueryVersion","jQuery_v1_11_3"),
    ("STFShowAvailableApps","false"),
    ("STFSessionNotification","false"),
    ("STFSessionTimeWarning","1"),
    ("STFEditAgentProfile","false"),
    ("STFShowChangeCompany","false"),
    ("AppID","0"),
    ("SecurityMenuBar","false"),
    ("ApplySecurity","false"),
    ("appTitle","Test"),
    ("ApplicationLogin","true"),
    ("SecurityLogin","http://atlanticasecurity.qa.atlantica.local/index.aspx"),
    ("STFShowLogo","true"),
    ("STFEmailHost","statetrustlife-com.mail.protection.outlook.com"),
    ("STFEmailFrom","cambios@statetrustlife.com"),
    ("STFAutoRegisterRoute","true"),
    ("STFApplySecurityScript","true")
    )
	
	foreach($key in $lstAppSettings){
	$appSettings = $xml.configuration.appSettings.add | where {$_.key -eq $key[0] }
	if($appSettings -eq $null)
{
$newkey = $xml.CreateElement("add")
$newkey.SetAttribute("key",$key[0])
$newkey.SetAttribute("value",$key[1])
$xml.configuration.appSettings.AppendChild($newkey)
}
}
}

if($xml.configuration.connectionStrings -eq $null){
[xml]$connectionStringsXml = @'
<connectionStrings>    
    <add name="Statetrust.Framework.SecurityConnectionString" connectionString="Data Source=172.16.38.12\SQL2008A,49281;Initial Catalog=Security;User ID=sa;Password=state" />
    <add name="STFGlobalEntities" connectionString="metadata=res://*/STFGlobalEntities.csdl|res://*/STFGlobalEntities.ssdl|res://*/STFGlobalEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=stl-dev05\SQL2012A;initial catalog=Dev_Global_LoadData;user id=Global;password=global;multipleactiveresultsets=True;application name=EntityFramework&quot;" providerName="System.Data.EntityClient" />
</connectionStrings>
'@
$xml.configuration.AppendChild($xml.ImportNode($connectionStringsXml.connectionStrings, $true))
}
else {
$lstConnections = @(
    ("Statetrust.Framework.SecurityConnectionString",'Data Source=172.16.38.12\SQL2008A,49281;Initial Catalog=Security;User ID=sa;Password=state'),
    ("STFGlobalEntities","metadata=res://*/STFGlobalEntities.csdl|res://*/STFGlobalEntities.ssdl|res://*/STFGlobalEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=stl-dev05\SQL2012A;initial catalog=Dev_Global_LoadData;user id=Global;password=global;multipleactiveresultsets=True;application name=EntityFramework&quot;"))
	
	foreach($key in $lstConnections){
	$connectionStrings = $xml.configuration.connectionStrings.add | where {$_.name -eq $key[0] }
	if($connectionStrings -eq $null)
{
$newkey = $xml.CreateElement("add")
$newkey.SetAttribute("name",$key[0])
$newkey.SetAttribute("connectionString",$key[1])
$xml.configuration.connectionStrings.AppendChild($newkey)
}
}
}

# save the Web.config file
$xml.Save($localPath.Value)


