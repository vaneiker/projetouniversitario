using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STG.DLL.TH.Serialization;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;
using System.Reflection;
using System.Collections;

namespace STG.DLL.TH.Serialization
{
    public class Implementation
    {
        public List<string> dummyList = new List<string>();
        public DateTime dummyDate = DateTime.MinValue;
        public enum Quotes
        {
            [Description("QT.Life")]
            Life = 1
        }
        public struct Configuration
        {
            public int batchConfigResID { get; set; }
            public string batchName { get; set; }
            public int projectID { get; set; }
            public int batchCollect { get; set; }
            public int finOption { get; set; }
            public int jobType { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string defaultExt { get; set; }
        }
        private Configuration configuration { get; set; }

        public byte[] GetQuote(Quotes type, Entity.Quote quote)
        {
            try
            {
                byte[] binary;
                Configuration configuration = new Configuration();
                var xmlQuote = string.Empty;

                Specified(quote);
                switch (type)
                {
                    case Quotes.Life:
                    default:
                        {
                            xmlQuote = this.GetObject(quote);
                            configuration.batchConfigResID = int.Parse(ConfigurationManager.AppSettings["DEF::BatchID:Quote:Life"]);
                            configuration.projectID = int.Parse(ConfigurationManager.AppSettings["DEF::ProjectID:Quote:Life"]);
                            configuration.batchName = (ConfigurationManager.AppSettings["DEF::BatchName:Quote:Life"]);
                            configuration.batchCollect = int.Parse(ConfigurationManager.AppSettings["DEF::BatchCollect:Quote:Life"]);
                            configuration.finOption = int.Parse(ConfigurationManager.AppSettings["DEF::FinOption:Quote:Life"]);
                            configuration.jobType = int.Parse(ConfigurationManager.AppSettings["DEF::JobType:Quote:Life"]);
                            configuration.UserName = (ConfigurationManager.AppSettings["DEF::Username:Quote:Life"]);
                            configuration.Password = (ConfigurationManager.AppSettings["DEF::Password:Quote:Life"]);
                            configuration.defaultExt = (ConfigurationManager.AppSettings["DEF::DefaultExt:Quote"]);
                        }
                        break;
                }
                binary = UTF8Encoding.UTF8.GetBytes(xmlQuote.CleanXMLToParse());
                return this.ProcessRequest(binary, configuration);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Specified(object obj)
        {
            var propSet = "Specified";
            var props = obj.GetType().GetProperties();
            foreach (var prop in props)
            {
                string typed = prop.PropertyType.Namespace;
                if (typed == dummyList.GetType().Namespace)
                {
                    object value = prop.GetValue(obj, null);
                    foreach (var child in (IEnumerable)value)
                    {
                        var childProps = child.GetType().GetProperties();
                        foreach (var item in childProps)
                        {
                            var propName = item.Name;
                            object propValue = item.GetValue(child, null);
                            if (propName.Contains(propSet))
                            {
                                SetProperty(childProps, propName, propSet, child);
                            }
                        }
                    }
                }
                else
                {
                    object value = prop.GetValue(obj, null);
                    var childProps = value.GetType().GetProperties();
                    foreach (var item in childProps)
                    {
                        var propName = item.Name;
                        object propValue = item.GetValue(value, null);
                        if (propName.Contains(propSet))
                        {
                            SetProperty(childProps, propName, propSet, value);
                        }
                    }
                }
            }
        }

        private void SetProperty(PropertyInfo[] childProps, string propName, string propSet, object value)
        {
            PropertyInfo current = childProps.Where(p => p.Name == propName).FirstOrDefault();
            PropertyInfo prop = childProps.Where(p => p.Name == propName.Replace(propSet, string.Empty)).FirstOrDefault();
            string newValue = "true";
            if (prop != null)
            {
                var propValue = prop.GetValue(value, null);
                if (propValue != null && propValue.ToString().Length > 0)
                    if (propValue.GetType().Namespace == dummyDate.GetType().Namespace && propValue.ToString() == dummyDate.ToString())
                        return;
                    else
                        current.SetValue(value, Convert.ChangeType(newValue, current.PropertyType), null);
            }           
        }

        private string GetObject(Entity.Quote quote)
        {
            ///MasterChild
            var obj = new SYSTEM_OIPA1();
            ///Child
            var objData = new List<SYSTEM_OIPA>();
            ///Simple Object for Clild
            var child = new SYSTEM_OIPA();
            ///Setting details to master
            child.PolicyInfo = quote.PolicyInfo;
            child.Members = quote.Member.ToArray();
            child.Coverages = quote.Coverages.ToArray();
            child.PolicyData = quote.PolicyData.ToArray();
            child.Quotation = quote.Quotation;
            child.PaymentDetail = quote.PaymentDetail;
            child.PrimeResume = quote.PrimeResume;
            objData.Add(child);
            obj.dataset = objData.ToArray();
            string xml = Serialization.Serialize<SYSTEM_OIPA1>(obj);
            return xml;
        }

        /// <summary>
        /// Enviar el request al servicio de Thunderhead
        /// </summary>
        /// <param name="XmlData"></param>
        /// <returns></returns>
        public byte[] ProcessRequest(byte[] XmlData, Configuration configuration)
        {
            byte[] binary = null;
            try
            {
                var request = new THAPIweb.ExternalJobRequestAPI();
                var e = new THAPIweb.JobAPIWebService();
                e.Url = STG.DLL.TH.Serialization.Properties.Settings.Default.STG_DLL_TH_Serialization_THAPIweb_JobAPIWebService;
                var sercurityLayer = new TH.Serialization.Security.Layer(configuration.UserName, configuration.Password);
                request.batchConfigResID = configuration.batchConfigResID;
                request.batchName = configuration.batchName;
                request.projectID = configuration.projectID;
                request.batchCollect = configuration.batchCollect;
                request.finOption = configuration.finOption;
                request.jobType = configuration.jobType;
                request.transactionData = XmlData;
                e.SetPolicy(new Microsoft.Web.Services3.Design.Policy(sercurityLayer));
                var result = e.executePreview(request);
                var channelDocuments = result.masterChannels;
                for (int i = 0; i < channelDocuments.Length; i++)
                {
                    var doc = channelDocuments[i];
                    binary = doc.data;
                    String ext = doc.formatString;
                    if (ext == configuration.defaultExt)
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
