using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google;
using ATL.PdfNotification.Herramientas;  
using ATL.PdfNotification.CondParticularesData;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.IO;




namespace ATL.PdfNotification
{
    class Program
    {
        static void Main(string[] args)
        {

            Poliza pol = new Poliza();
            string url;
            string urlClient;
            string user;
            string pass;
            string batchName;
            int projectID;
            int batchConfigResID;
            Int64 SEND_TH_LOG_ID;

            url = System.Configuration.ConfigurationManager.AppSettings["WebServiceUrl"].ToString();
            urlClient = System.Configuration.ConfigurationManager.AppSettings["Urlcustomers"].ToString();
            user = System.Configuration.ConfigurationManager.AppSettings["WebServiceUser"].ToString();
            pass = System.Configuration.ConfigurationManager.AppSettings["WebServicePass"].ToString();
            batchName = System.Configuration.ConfigurationManager.AppSettings["WebServiceBatchName"].ToString();
            projectID = int.Parse(System.Configuration.ConfigurationManager.AppSettings["WebServiceProjectID"].ToString());
            batchConfigResID = int.Parse(System.Configuration.ConfigurationManager.AppSettings["WebServiceBatchConfigResID"].ToString());

            //WebServiceInternal.THProxy proxy = new WebServiceInternal.THProxy(url,user,pass,batchName,projectID,batchConfigResID); 
            String XmlTransaction = string.Empty;


            int TransactionType = 0;

            DataSet ds;
            DataSet dsNotificationsForSend = new DataSet("NotificationsForSend");

            //GET NOTIFICATIONS FOR SEND
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GlobalConnectionString"].ConnectionString))
            {
                try
                {
                    SqlCommand sqlComm = new SqlCommand("[reportes].[GetNotificationsForSend]", conn);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandTimeout = 9999999;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;
                    da.Fill(dsNotificationsForSend);
                    
                }
                catch (Exception)
                {
                    conn.Close();
                    //Logger logger = new Logger();
                    //logger.LogError("|| <b>Method:</b> ||" + System.Reflection.MethodBase.GetCurrentMethod().Name + " <br> || <b>Message:</b> ||" + ex.Message + " <br> || <b>StackTrace:</b> ||" + ex.StackTrace + " <br> || <b>ex.ToString():</b> ||" + ex.ToString(), TransactionType);
                    //return;
                }

            }

            if (dsNotificationsForSend != null)
            {
                if (dsNotificationsForSend.Tables.Count > 0)
                {
                   foreach (DataRow row in dsNotificationsForSend.Tables[0].Rows)
                    {
                        int Thunderheadresult = -1;
                        string Params = string.Empty;
                        string PolicyId = null;
                        int Trans_Type_Id = 0;
                        string FechaPago = null;
                        string PaymentKey = null;
                        int? AgentID = null;
                        int? SupervisorID = null;
                        int UserID = 0;
                        Int64? Cotizacion = null;
                        bool Isdebug;
                        ds = new DataSet("TransactionData");
                        using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GlobalConnectionString"].ConnectionString))
                        {
                            try
                            {                              

                                if (row["Policy_No"] != null && row["Policy_No"].ToString() != string.Empty)
                                {
                                    PolicyId = row["Policy_No"].ToString();
                                }
                              

                                SqlCommand sqlComm = new SqlCommand("reportes.[GetTransactionDataXML]", conn);
                                sqlComm.Parameters.AddWithValue("@PolicyId", PolicyId);
                                sqlComm.CommandType = CommandType.StoredProcedure;
                                sqlComm.CommandTimeout = 9999999;
                                SqlDataAdapter da = new SqlDataAdapter();
                                da.SelectCommand = sqlComm;

                                da.Fill(ds);

                                     //pol.NoPoliza = da.["Policy_No"].ToString();
                                     //var fec = Convert.ToDateTime(ds.["Policy_Effective_Date"]);
                                     //fec = DateTime.Now;
                                     //pol.NumeroCelular = reder["Cellphone"].ToString();
                                     //pol.DocumentId = Convert.ToString(projectID);
                                     //var documentEncr = wToken.Encrypt(pol.NoPoliza + ";" + batchConfigResID, "1");
                                     //pol.Address = ApiGoogle.shortenIt(urlClient + documentEncr.key);
                                     ////conn.Close();
                            }
                            catch (Exception)
                            {
                                conn.Close();
                                //Logger logger = new Logger();
                                //logger.LogError("|| <b>Method:</b> ||" + System.Reflection.MethodBase.GetCurrentMethod().Name + " <br> || <b>Message:</b> ||" + ex.Message + " <br> || <b>StackTrace:</b> ||" + ex.StackTrace + " <br> || <b>ex.ToString():</b> ||" + ex.ToString(), TransactionType);
                            }

                        }

                        if (ds != null)
                        {
                            if (ds.Tables.Count > 0)
                            {
                                //Transaction
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    XmlTransaction = ds.Tables[0].Rows[0][0].ToString();
                                }

                                Console.WriteLine("Data: "+ds);
                                //Thunderheadresult = proxy.Send_Plexis_Template(XmlTransaction);
                                

                            }
                            Console.Read();
                        }
                    }

                }
            }
        }
    }
}
