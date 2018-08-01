/*
1335501549 -	

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


SELECT    [Corp_Id]
           ,3
           ,'SRV-Bienvenida'
           ,[Transaction_Schedule_Id]
           , 1335501459       as [Document_Id]
           ,[Send_SMS]
           ,[Create_Userid]
           ,[Modi_Userid]
           ,[Create_Date]
           ,[Modi_Date]
           ,[Hostname]
FROM [Transaction_Control].[TC_Transaction_Types]
  WHERE Trans_Type_Id = 1


SELECT*    FROM [TRANSACTION_CONTROL].[TC_TRANSACTION_TYPES] T   WHERE TRANS_TYPE_ID = 1








INSERT INTO [Transaction_Control].[TC_Transaction_Types_Mail]
           ([Corp_Id]
           ,[Trans_Type_Mail_Id]
           ,[Trans_Type_Id]
           ,[Mail_Id]
           ,[Create_Userid]
           ,[Modi_Userid]
           ,[Create_Date]
           ,[Modi_Date]
           ,[Hostname]     
                 ,[Status]                             
                 )

SELECT    t.Corp_Id                                                                             AS [Corp_Id]
              ,ROW_NUMBER() OVER(ORDER BY Trans_Type_Id)  + (SELECT COUNT(1) FROM [Transaction_Control].[TC_Transaction_Types_Mail])                   AS [Trans_Type_Mail_Id]
              ,Trans_Type_Id                                                                          AS [Trans_Type_Id]
              ,m.Mail_Id                                                                              AS [Mail_Id]
              ,SUSER_ID()                                                                      AS [Create_Userid]
         ,NULL                                                                                         AS [Modi_Userid]
         ,GETDATE()                                                                             AS [Create_Date]
         ,NULL                                                                                         AS [Modi_Date]
         ,'GDIAZ'                                                                               AS [Hostname]                 
              ,1                                                                                             AS [Status]
  FROM [Transaction_Control].[TC_Transaction_Types] t
   CROSS JOIN [Transaction_Control].[TC_MAIL] M
    WHERE T.Trans_Type_Id IN (3)
       AND  M.MAIL_ID IN (2,3,4,5)


       SELECT *
       FROM Transaction_Control.TC_Mail

