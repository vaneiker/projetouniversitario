using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderheadWrap
{
    /// <summary>
    /// Author.: Lic. Carlos ML. Lebron Batista
    /// Wrapper para Consumir el servicio de Thunderhead    
    /// </summary>
    public class Service
    {        
        private string UrlServiceTH;

        public class Parameters
        {
            public int batchConfigResID { get; set; }
            public string batchName { get; set; }
            public int projectID { get; set; }
            public int batchCollect { get; set; }
            public int finOption { get; set; }
            public int jobType { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        private Parameters parameters { get; set; }
        private string Pass { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        private void SetParameters()
        {
            try
            {
                parameters = new Parameters
                {
                    batchConfigResID =int.Parse(System.Configuration.ConfigurationManager.AppSettings["batchConfigResID"]),
                    projectID = int.Parse(System.Configuration.ConfigurationManager.AppSettings["projectID"]),
                    batchName = System.Configuration.ConfigurationManager.AppSettings["batchName"],
                    batchCollect = int.Parse(System.Configuration.ConfigurationManager.AppSettings["batchCollect"]),
                    finOption = int.Parse(System.Configuration.ConfigurationManager.AppSettings["finOption"]),
                    jobType = int.Parse(System.Configuration.ConfigurationManager.AppSettings["jobType"]),
                    UserName = System.Configuration.ConfigurationManager.AppSettings["UserName"],
                    Password = string.IsNullOrEmpty(Pass) ? string.Empty : Pass,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Service()
        {
            Pass = System.Configuration.ConfigurationManager.AppSettings["Password"];
            UrlServiceTH = System.Configuration.ConfigurationManager.AppSettings["UrlServiceTH"];
            SetParameters();
        }

        /// <summary>
        /// Enviar el request al servicio de Thunderhead
        /// </summary>
        /// <param name="XmlData"></param>
        /// <returns></returns>
        public byte[] sendRequest(byte[] XmlData)
        {
            byte[] binary = null;

            try
            {
                var request = new THAPIWeb.ExternalJobRequestAPI();
                var e = new THAPIWeb.JobAPIWebService();
                e.Url = UrlServiceTH;
                var sercurityAssertion = new THSecurityAssertion(parameters.UserName, parameters.Password);

                request.batchConfigResID = parameters.batchConfigResID;//Ej: 1335501590;
                request.batchName = parameters.batchName;//Ej: "VirtualOfficeIntegration";
                request.projectID = parameters.projectID;//Ej: 1335500031;
                request.batchCollect = parameters.batchCollect;//Ej: 8;
                request.finOption = parameters.finOption;//Ej: 0;
                request.jobType = parameters.jobType;//Ej: 0;

                request.transactionData = XmlData;

                e.SetPolicy(new Microsoft.Web.Services3.Design.Policy(sercurityAssertion));

                //**** version binario del documento ****//
                //generar documento
                var result = e.executePreview(request);

                //obtener canal(es) documento(s) generado(s)
                var channelDocuments = result.masterChannels;

                for (int i = 0; i < channelDocuments.Length; i++)
                {
                    var doc = channelDocuments[i];
                    binary = doc.data;
                    String ext = doc.formatString;
                    if (ext == "pdf")
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return 
                binary;  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="XmlData"></param>
        /// <returns></returns>
        public int sendRequestSubmitBatch(byte[] XmlData)
        {
            int? result = null;

            try
            {
                var request = new THAPIWeb.ExternalJobRequestAPI();
                var e = new THAPIWeb.JobAPIWebService();
                e.Url = UrlServiceTH;
                var sercurityAssertion = new THSecurityAssertion(parameters.UserName, parameters.Password);

                request.batchConfigResID = parameters.batchConfigResID;//Ej: 1335501590;
                request.batchName = parameters.batchName;//Ej: "VirtualOfficeIntegration";
                request.projectID = parameters.projectID;//Ej: 1335500031;
                request.batchCollect = parameters.batchCollect;//Ej: 8;
                request.finOption = parameters.finOption;//Ej: 0;
                request.jobType = parameters.jobType;//Ej: 0;

                request.transactionData = XmlData;

                e.SetPolicy(new Microsoft.Web.Services3.Design.Policy(sercurityAssertion));

                //**** version binario del documento ****//
                //generar documento
                 result = e.submitBatch(request);

                
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return
                result.GetValueOrDefault();
        }

    }
}
