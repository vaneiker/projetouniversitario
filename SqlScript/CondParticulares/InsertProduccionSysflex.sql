/*
1335501483	BNV-Bienvenido a Atlántica Seguros	Bienvenida
*/



INSERT INTO [Transaction_Control].[TC_Transaction_Types]
           ([Corp_Id]
           ,[Trans_Type_Id]
           ,[Trans_Type_Desc]
           ,[Transaction_Schedule_Id]
           ,[Document_Id]
           ,[Send_SMS]
           ,[Create_Userid]
           ,[Modi_Userid]
           ,[Create_Date]
           ,[Modi_Date]
           ,[Hostname])


SELECT      1 as [Corp_Id]
           ,1 as Trans_Type_Id
           ,'BNV-Bienvenido a Atlántica Seguros' [Trans_Type_Desc]
           ,1 as [Transaction_Schedule_Id]
           , 1335501483       as [Document_Id]
           ,1 as [Send_SMS]
           ,266 as [Create_Userid]
           ,null as [Modi_Userid]
           ,getdate() as [GETDATE]
           ,null as [Modi_Date]
           ,HOST_NAME() [Hostname] 
FROM 
GO
INSERT INTO Transaction_Control.TC_Mail
SELECT Corp_Id, 2 AS Mail_Id, 'mvasquez@statetrustlife.com',Create_Userid, Modi_Userid, Create_Date, Modi_Date, Status, HOST_NAME() 
FROM Transaction_Control.TC_Mail WHERE Mail_Id = 1




INSERT INTO [Transaction_Control].[TC_Transaction_Types_Mail]

SELECT 1,	1,	1,	2,	266,	NULL,	GETDATE(),NULL,	HOST_NAME(),	1


