USE [ShipLogs]
GO
/****** Object:  StoredProcedure [dbo].[sp_ShipmentDetailSave_New]    Script Date: 4/26/2019 12:12:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 

ALTER PROC [dbo].[sp_ShipmentDetailSave_New]  
 @ShipUniqueID   int=0
,@AssignedTo     nchar(20)=NULL
,@ItemDetail     text=NULL
,@operation      varchar(15)
 
 AS

 BEGIN 
 IF @operation='INSERT'
 BEGIN 
      INSERT INTO [dbo].[ShipmentDetails] VALUES(@ShipUniqueID,@AssignedTo,@ItemDetail)
 END
 ELSE
 IF @operation='UPDATE'
  BEGIN 
 UPDATE [dbo].[ShipmentDetails] SET AssignedTo=@AssignedTo,ItemDetail=@ItemDetail
 END 
 END
  
 