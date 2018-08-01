USE [SysFlexSeguros]
GO


CREATE VIEW [Transaction_Control].[vw_TC_Transaction_Types]
AS 
 SELECT   Mail
		 ,tt.*
		 --,Corp_Id
		 --,Trans_Type_Id
		 --,Trans_Type_Desc
		 --,Document_Id
	  --   ,Mail
		 --,
  FROM 
		[Transaction_Control].[TC_Transaction_Types]			AS TT
	 OUTER APPLY(
				SELECT 
					stuff((
						SELECT  ','+ M.Mail
							FROM	[Transaction_Control].[TC_MAIL]	AS M
							 INNER JOIN 
										[Transaction_Control].[TC_Transaction_Types_Mail]		AS TTM
									 ON TT.Trans_Type_Id = TTM.Trans_Type_Id
							 WHERE   M.MAIL_ID = TTM.MAIL_ID 
							   AND M.STATUS = 1
							    AND  TTM.STATUS = 1
						FOR XML PATH('')
						), 1, 1, '') Mail
		) Mail




GO


