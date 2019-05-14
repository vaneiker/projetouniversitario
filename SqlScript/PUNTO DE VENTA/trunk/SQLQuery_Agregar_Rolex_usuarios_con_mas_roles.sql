use[Security]
go
--

SELECT * FROM [Security].[Security].[RolesxUser] WHERE UserID=7465
 
--Buscar todo el usuario que tenga este rol
select * from Security.Users where UserID  IN(select * from Security.Users where UserID  IN(SELECT UserID FROM [Security].[Security].[RolesxUser] WHERE RolID=1458) and AgentNameId is not null and Active = 1 and IsDeleted = 0) 

--Buscar todos los usuarios que tienen AgentNameId
select * from Security.Security.Users where AgentNameId is not null and Active = 1 and IsDeleted = 0 

--buscar los que no tienen este rol
select * from Security.Security.Users where UserID=9253 
 
 select * from Security.RolesxUser where UserID in(select UserID from Security.Users where UserID  IN(SELECT UserID FROM [Security].[Security].[RolesxUser] WHERE RolID=1458) and AgentNameId is not null and Active = 1 and IsDeleted = 0) and RolID!=9253 

 --Agregar el Roll de punto de venta auto 

 ;with cteUsers as (
 select * from Security.Users where UserID  IN(SELECT UserID FROM [Security].[Security].[RolesxUser] WHERE RolID=1458) and AgentNameId is not null and Active = 1 and IsDeleted = 0
 )

INSERT INTO [Security].[RolesxUser]
           ([RolID]
           ,[UserID]
           ,[IsTemp]
           ,[TempDate]
           ,[CreatedDate]
           ,[ModifiedDate]
           ,[CreatedUserID]
           ,[ModifiedUserID]
           ,[IsDeleted]
           ,[HostName])

     select 9253 as [RolID],UserID,NULL as Istemp, NULL as [TempDate],getdate() as CreatedDate,getdate() as ModifiedDate,3348 as CreatedUserID,3348 as ModifiedUserID, 0,IsDeleted, HOST_NAME() as HostName from Security.RolesxUser where UserID in(select USERID from cteUsers) and RolID != 9253 
GO																																										 						  



