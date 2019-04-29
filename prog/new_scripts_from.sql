USE [ShipLogs]
GO


alter PROCEDURE [dbo].[SP_FROM_Shipment]
( 
@ShipmentNumberParameter      nchar(20)
)
AS
BEGIN 
SELECT   a.ShipUniqueID        
	    ,CarrierName        
	    ,AccountNumber      
	    ,ShipmentNumber     
	    ,ShipmentDate       
	    ,ShipmentWeight     
	    ,ShipmentQTY        
	    ,ShipPackageType    
	    ,Operator           
	    ,Sender             
	    ,Receiver           
	    ,ReceiverAttn       
	    ,ReceiverAddress    
	    ,ReceiverCity       
	    ,ReceiverState      
	    ,ReceiverZipCode    
	    ,ReceiverCountry    
	    ,ReceiverPhoneNumber
	    ,ShipmentComments   
	    ,Transit            
	    ,Incoming           
	    ,CommissionChecks   
	    ,Materials          
	    ,OtherContents      
	    ,AssignedTo         
	    ,ItemDetail         
	    ,a.Operator 
 FROM DBO.Shipments a left join DBO.ShipmentDetails b on a.ShipUniqueID=b.ShipUniqueID

where a.ShipmentNumber=@ShipmentNumberParameter order by ShipmentDate desc


END

 