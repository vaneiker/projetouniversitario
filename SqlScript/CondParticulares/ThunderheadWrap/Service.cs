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
        public enum TemplateType
        {
            Marbete,
            Condicionado,
            Cotizacion,
            CondicionesParticulares,
            Endoso,
            EndosoAclaratorio,
            EndosoCesionDerecho,
            NotificacionEstatusExtranjero,
            Inspeccion,
            CotizacionPropiedad,
            Navy,
            Tranport,
            Bail,
            Airplane,
            InspeccionRiesgo,
            ContratoKSI
        }

        private string UrlServiceTH;

        public enum BusinessLine
        {
            Life = 1,
            Vehicle,
            Health,
            IncendioLineasAliadas
        }

        public enum ContactCountry { RepublicaDominicana, ElSalvador }

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

        private void SetParametersAlliedLines(TemplateType templateType, ContactCountry CountryCode = ContactCountry.RepublicaDominicana)
        {
            var batchConfigProperty = CountryCode == ContactCountry.RepublicaDominicana ? int.Parse(System.Configuration.ConfigurationManager.AppSettings["batchConfigProperty"])
                                                                       : int.Parse(System.Configuration.ConfigurationManager.AppSettings["batchConfigPropertySV"]);

            var batchNameProperty = CountryCode == ContactCountry.RepublicaDominicana ? System.Configuration.ConfigurationManager.AppSettings["batchNameProperty"]
                                                                     : System.Configuration.ConfigurationManager.AppSettings["batchNamePropertySV"];

            var projectIDProperty = CountryCode == ContactCountry.RepublicaDominicana ? int.Parse(System.Configuration.ConfigurationManager.AppSettings["projectIDProperty"])
                                                                     : int.Parse(System.Configuration.ConfigurationManager.AppSettings["projectIDPropertySV"]);

            try
            {
                //switch (templateType)
                //{
                //    case TemplateType.CotizacionPropiedad:

                //    break;
                //}

                parameters = new Parameters
                {
                    batchConfigResID = batchConfigProperty,
                    projectID = projectIDProperty,
                    batchName = batchNameProperty,
                    batchCollect = int.Parse(System.Configuration.ConfigurationManager.AppSettings["batchCollect"]),
                    finOption = int.Parse(System.Configuration.ConfigurationManager.AppSettings["finOption"]),
                    jobType = int.Parse(System.Configuration.ConfigurationManager.AppSettings["jobType"]),
                    UserName = CountryCode == ContactCountry.RepublicaDominicana ? System.Configuration.ConfigurationManager.AppSettings["UserName"]
                                                                : System.Configuration.ConfigurationManager.AppSettings["UserNameSV"],
                    Password = string.IsNullOrEmpty(Pass) ? string.Empty : Pass,
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateType"></param>
        private void SetParametersAuto(TemplateType templateType)
        {
            try
            {
                var vbatchConfigResIDQuot = int.Parse(System.Configuration.ConfigurationManager.AppSettings["batchConfigResIDQuot"]);
                var vprojectIDQuot = int.Parse(System.Configuration.ConfigurationManager.AppSettings["projectIDQuot"]);
                var vbatchConfigResIDMarbeteCondicionado = int.Parse(System.Configuration.ConfigurationManager.AppSettings["batchConfigResIDMarbeteCondicionado"]);
                var vprojectIDMarbeteCondicionado = int.Parse(System.Configuration.ConfigurationManager.AppSettings["projectIDMarbeteCondicionado"]);

                var vbatchConfigResID = 0;
                var vprojectID = 0;

                switch (templateType)
                {
                    case TemplateType.Cotizacion:
                    case TemplateType.Endoso:
                    case TemplateType.EndosoAclaratorio:
                    case TemplateType.EndosoCesionDerecho:
                    case TemplateType.NotificacionEstatusExtranjero:
                    case TemplateType.Inspeccion:
                    case TemplateType.ContratoKSI:
                        vbatchConfigResID = vbatchConfigResIDQuot;
                        vprojectID = vprojectIDQuot;
                        break;
                    case TemplateType.CondicionesParticulares:
                    case TemplateType.Marbete:
                    case TemplateType.Condicionado:
                        vbatchConfigResID = vbatchConfigResIDMarbeteCondicionado;
                        vprojectID = vprojectIDMarbeteCondicionado;
                        break;
                }

                parameters = new Parameters
                {
                    batchConfigResID = vbatchConfigResID,
                    projectID = vprojectID,
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

        public Service(TemplateType templateType, BusinessLine Bl = BusinessLine.Vehicle, ContactCountry CountryCode = ContactCountry.RepublicaDominicana)
        {
            Pass = CountryCode == ContactCountry.RepublicaDominicana ? System.Configuration.ConfigurationManager.AppSettings["Password"]
                                       : System.Configuration.ConfigurationManager.AppSettings["PasswordSV"];

            UrlServiceTH = CountryCode == ContactCountry.RepublicaDominicana ? System.Configuration.ConfigurationManager.AppSettings["UrlServiceTH"]
                                               : System.Configuration.ConfigurationManager.AppSettings["UrlServiceTHSV"];

            switch (Bl)
            {
                case BusinessLine.Life:
                    break;
                case BusinessLine.Vehicle:
                    SetParametersAuto(templateType);
                    break;
                case BusinessLine.Health:
                    break;
                case BusinessLine.IncendioLineasAliadas:
                    SetParametersAlliedLines(templateType, CountryCode);
                    break;
                default:
                    break;
            }

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
                //var r = e.submitBatch(request);

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

            return binary;

        }

    }
}
