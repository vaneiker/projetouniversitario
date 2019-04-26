USE [ShipLogs]
GO
/****** Object:  StoredProcedure [dbo].[sp_ShipmentSave_New]    Script Date: 4/25/2019 11:39:19 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

ALTER PROCEDURE [dbo].[sp_ShipmentSave_New]
(
  @ShipUniqueID        int
 ,@CarrierName         nchar(20)
 ,@AccountNumber       nchar(12)
 ,@ShipmentNumber      nchar(20)
 ,@ShipmentDate        datetime
 ,@ShipmentWeight      numeric(18,0)
 ,@ShipmentQTY         int
 ,@ShipPackageType     nchar(20)
 ,@Operator            nchar(16)
 ,@Sender              nchar(50)
 ,@Receiver            nchar(50)
 ,@ReceiverAttn        nchar(50)
 ,@ReceiverAddress     nchar(150)
 ,@ReceiverCity        nchar(40)
 ,@ReceiverState       nchar(40)
 ,@ReceiverZipCode     nchar(20)
 ,@ReceiverCountry     nchar(20)
 ,@ReceiverPhoneNumber nchar(20)
 ,@ShipmentComments    text
 ,@Transit             bit
 ,@Incoming            bit
 ,@CommissionChecks    bit
 ,@Materials           bit
 ,@OtherContents       bit
)
AS
 
BEGIN
DECLARE @ShipmentsID_New INT
IF @ShipUniqueID=0
BEGIN 
INSERT [DBO].[Shipments]
(
       [CarrierName]           
      ,[AccountNumber]         
      ,[ShipmentNumber]        
      ,[ShipmentDate]          
      ,[ShipmentWeight]        
      ,[ShipmentQTY]           
      ,[ShipPackageType]       
      ,[Operator]              
      ,[Sender]                
      ,[Receiver]              
      ,[ReceiverAttn]          
      ,[ReceiverAddress]       
      ,[ReceiverCity]          
      ,[ReceiverState]         
      ,[ReceiverZipCode]       
      ,[ReceiverCountry]       
      ,[ReceiverPhoneNumber]   
      ,[ShipmentComments]      
      ,[Transit]               
      ,[Incoming]              
      ,[CommissionChecks]      
      ,[Materials]             
      ,[OtherContents]   
)
VALUES
(
 @CarrierName         
 ,@AccountNumber       
 ,@ShipmentNumber      
 ,@ShipmentDate        
 ,@ShipmentWeight      
 ,@ShipmentQTY         
 ,@ShipPackageType     
 ,@Operator            
 ,@Sender              
 ,@Receiver            
 ,@ReceiverAttn        
 ,@ReceiverAddress     
 ,@ReceiverCity        
 ,@ReceiverState       
 ,@ReceiverZipCode     
 ,@ReceiverCountry     
 ,@ReceiverPhoneNumber 
 ,@ShipmentComments    
 ,@Transit             
 ,@Incoming            
 ,@CommissionChecks    
 ,@Materials           
 ,@OtherContents 
)

 SET @ShipmentsID_New = @@IDENTITY

SELECT @ShipmentsID_New[Id],'INSERT'[Value],'0'[IdAlf]
END 
ELSE 
BEGIN 
UPDATE [DBO].[Shipments] 
   SET [CarrierName]         =@CarrierName                  
      ,[AccountNumber]       =@AccountNumber              
      ,[ShipmentNumber]      =@ShipmentNumber            
      ,[ShipmentDate]        =@ShipmentDate                
      ,[ShipmentWeight]      =@ShipmentWeight            
      ,[ShipmentQTY]         =@ShipmentQTY                  
      ,[ShipPackageType]     =@ShipPackageType          
      ,[Operator]            =@Operator                        
      ,[Sender]              =@Sender                            
      ,[Receiver]            =@Receiver                        
      ,[ReceiverAttn]        =@ReceiverAttn                
      ,[ReceiverAddress]     =@ReceiverAddress          
      ,[ReceiverCity]        =@ReceiverCity                
      ,[ReceiverState]       =@ReceiverState              
      ,[ReceiverZipCode]     =@ReceiverZipCode          
      ,[ReceiverCountry]     =@ReceiverCountry          
      ,[ReceiverPhoneNumber] =@ReceiverPhoneNumber  
      ,[ShipmentComments]    =@ShipmentComments        
      ,[Transit]             =@Transit                          
      ,[Incoming]            =@Incoming                        
      ,[CommissionChecks]    =@CommissionChecks        
      ,[Materials]           =@Materials                      
      ,[OtherContents]       =@OtherContents
	          
WHERE ShipUniqueID=@ShipUniqueID 

SELECT @ShipUniqueID[Id],'UPDATE'[Value],'0'[IdAlf]
END  
END

 