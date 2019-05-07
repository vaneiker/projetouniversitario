using Declarative.Invoicing.THServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Declarative.Invoicing.CustomCode.TH
{
    public class THSettings
    {
        private static WCFServiceClient thServicesClient;
        private static THParams tHParams;

        public THSettings()
        {
            thServicesClient = new WCFServiceClient();
            tHParams = new THParams();
            tHParams.user = ConfigurationManager.AppSettings["ThUsername"];
            tHParams.password = ConfigurationManager.AppSettings["ThPassword"];
            tHParams.projectID = ConfigurationManager.AppSettings["THProjectID"].ToInt();
            tHParams.batchConfigResID = ConfigurationManager.AppSettings["THBatchConfigResID"].ToInt();
        }
        
        //public byte[] NewSendToTHExecutePreview(byte[] transactionData, int THProjectID, int THBatchConfigResID)
        public byte[] NewSendToTHExecutePreview(byte[] transactionData)
        {
            byte[] binary = null;
            
            tHParams.batchname = "VirtualOfficeIntegration";//VirtualOfficeIntegration;
            tHParams.batchCollect = 8;

            tHParams.finOption = 0;
            tHParams.jobType = 0;

            var result = thServicesClient.executePreview(tHParams, transactionData);
            if (result.Count() > 0)
            {
                binary = result.FirstOrDefault().Xmlbinary;
            }

            return binary;
        }
    }
}