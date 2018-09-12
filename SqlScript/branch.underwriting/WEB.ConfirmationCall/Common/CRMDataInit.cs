using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace WEB.ConfirmationCall.Common
{
    public class CRMDataInit
    {

        /// <summary>
        /// funcion creada por jose encarnacion para buscar en el CRM el AccountID
        /// </summary>
        /// <param name="NameID">NameID</param>
        /// <returns>ACCOUNTID</returns>
        public static string getAccountID(string NameID, int UserId, string HostName)
        {
            string result = string.Empty;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT TOP 1 ACCOUNTID FROM [sysdba].[ACCOUNT] ");
                sql.AppendFormat("WHERE NameID = '{0}'", NameID.Trim());

                using (SqlConnection oConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionSaleslogix"].ConnectionString))
                {
                    if (oConnection.State != ConnectionState.Open)
                    {
                        oConnection.Open();
                    }

                    using (SqlCommand oCommand = new SqlCommand())
                    {
                        oCommand.CommandType = CommandType.Text;
                        oCommand.Connection = oConnection;
                        oCommand.CommandText = sql.ToString();

                        using (SqlDataReader oReader = oCommand.ExecuteReader())
                        {

                            if (oReader.HasRows)
                            {
                                while (oReader.Read())
                                {
                                    if (!string.IsNullOrEmpty(oReader[0].ToString()))
                                    {
                                        result = oReader["ACCOUNTID"].ToString();
                                    }
                                }
                            }
                            else {
                                result = null;
                            
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string parameter = string.Format("NameID:{0}, UserId: {1}, HostName: {2}", NameID, UserId, HostName);
                //
                ConfirmationCallLog.Log("funcion getAccountID", string.Format("Message {0}, Inner Exception {1}", ex.Message, ex.InnerException), parameter, UserId, HostName);

            }

            return result;
        }

        /// <summary>
        /// funcion creada por jose encarnacion para buscar en el CRM el UserID
        /// </summary>
        /// <param name="UserId">UserId</param>
        /// <param name="HostName">HostName</param>
        /// <returns>CrmUserID</returns>
        public static string getCrmUserID(int UserId, string HostName)
        {
            string result = string.Empty;

            try
            {

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT [UserId],[FullName],[CRMUserId] FROM [Security].[VW_GET_CONFIRMATIONCALL_USER] ");
                sql.AppendFormat(" WHERE [UserId] = {0} ", UserId);

                using (SqlConnection oConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionLog"].ConnectionString))
                {
                    if (oConnection.State != ConnectionState.Open)
                    {
                        oConnection.Open();
                    }

                    using (SqlCommand oCommand = new SqlCommand())
                    {
                        oCommand.CommandType = CommandType.Text;
                        oCommand.Connection = oConnection;
                        oCommand.CommandText = sql.ToString();

                        using (SqlDataReader oReader = oCommand.ExecuteReader())
                        {

                            if (oReader.HasRows)
                            {
                                while (oReader.Read())
                                {
                                    if (oReader["CRMUserId"] != DBNull.Value)
                                    {
                                        result = oReader["CRMUserId"].ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string parameter = string.Format("UserId: {0}, HostName: {1}", UserId, HostName);
                //
                ConfirmationCallLog.Log("funcion getAccountID", string.Format("Message {0}, Inner Exception {1}", ex.Message, ex.InnerException), parameter, UserId, HostName);

            }

            return result;
        }
            
        /// <summary>
        /// funcion creada por jose encarnacion para buscar en el CRM el GetDatos
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="HostName"></param>
        /// <returns></returns>
        public static ClientQuestionCollection GetCrmDatos(string NameID, string Respuesta_Clave, List<Respuestas> Respuestas, int UserId, string HostName)
        {
            string AccountID = getAccountID(NameID, UserId, HostName);
            string CrmUserID = getCrmUserID(UserId, HostName);
            bool ResBlanco = false;

            List<ClientQuestion> clientQuestionList = new List<ClientQuestion>();
            ClientQuestionCollection clientQuestionCollection = new ClientQuestionCollection();
                                   
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("exec [sysdba].[GET_CLIENT_QUESTIONS] ");
            sql.AppendFormat("@ACCOUNTID ='{0}'", AccountID);
            sql.AppendFormat(",@USERID ='{0}'", CrmUserID);
            sql.AppendFormat(",@RESP_BLACO ={0};", ResBlanco);

            using (SqlConnection oConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionSaleslogix"].ConnectionString))
            {

                if (oConnection.State != ConnectionState.Open)
                {
                    oConnection.Open();
                }

                using (SqlCommand oCommand = new SqlCommand())
                {
                    oCommand.CommandType = CommandType.Text;
                    oCommand.Connection = oConnection;
                    oCommand.CommandText = sql.ToString();

                    using (SqlDataReader oReader = oCommand.ExecuteReader())
                    {

                        if (oReader.HasRows)
                        {
                            while (oReader.Read())
                            {

                                ClientQuestion oClientQuestion = new ClientQuestion();

                                if (Convert.ToInt32(oReader["NO"]) == 6)
                                {
                                    if (oReader["ACCOUNTID"] != DBNull.Value)
                                    {
                                        clientQuestionCollection.AccountID = oReader["ACCOUNTID"].ToString();
                                    }
                                    if (oReader["NAMEID"] != DBNull.Value)
                                    {
                                        clientQuestionCollection.NameID = oReader["NAMEID"].ToString();
                                    }
                                                                       
                                    clientQuestionCollection.Respuesta_Clave = Respuesta_Clave;

                                    if (oReader["RESPUESTA_CLAVE_ANTERIOR"] != DBNull.Value)
                                    {
                                        clientQuestionCollection.Respuesta_Clave_Anterior = oReader["RESPUESTA_CLAVE_ANTERIOR"].ToString();
                                    }
                                    else
                                    {
                                        clientQuestionCollection.Respuesta_Clave_Anterior = "";
                                    }

                                    clientQuestionCollection.UserID = CrmUserID;
                                    clientQuestionCollection.UpdateDesdeCIP = false;

                                    if (oReader["CREATEUSER"] != DBNull.Value)
                                    {
                                        clientQuestionCollection.CreateUser = oReader["CREATEUSER"].ToString();
                                    }
                                    if (oReader["MODIFYUSER"] != DBNull.Value)
                                    {
                                        clientQuestionCollection.ModifyUser = oReader["MODIFYUSER"].ToString();
                                    }
                                    
                                }

                                //HIJO
                                if (oReader["CLIENTQUESTIONID"] != DBNull.Value)
                                {
                                    oClientQuestion.ClientQuestionID = Convert.ToInt32(oReader["CLIENTQUESTIONID"]);
                                }

                                if (oReader["INITIALQUESTIONID"] != DBNull.Value)
                                {
                                    oClientQuestion.InitialQuestionID = Convert.ToInt32(oReader["INITIALQUESTIONID"]);
                                }

                                if (oReader["No"] != DBNull.Value)
                                {
                                    oClientQuestion.No = Convert.ToInt32(oReader["No"]);
                                }

                                if (oReader["DESCRIPTION"] != DBNull.Value)
                                {
                                    oClientQuestion.Descripcion = oReader["DESCRIPTION"].ToString();
                                }

                                if (oReader["RESPUESTA_ANTERIOR"] != DBNull.Value)
                                {
                                    oClientQuestion.RespuestaAnt = oReader["RESPUESTA_ANTERIOR"].ToString();

                                }
                                else
                                {
                                    oClientQuestion.RespuestaAnt = "";                                 
                                }

                                                               
                                                               
                                oClientQuestion.Respuesta = Respuestas.Where(x => x.No == Convert.ToInt32(oReader["No"])).FirstOrDefault().Respuesta;
                                //

                                clientQuestionList.Add(oClientQuestion);

                            }
                        }
                    }
                }
            }

            clientQuestionCollection.ClientQuestions = clientQuestionList;
            return clientQuestionCollection;

        }

        /// <summary>
        /// funcion creada por jose encarnacion para buscar en el CRM el SaveCRMQuestions
        /// </summary>
        /// <param name="Poliza">Poliza</param>
        /// <param name="Respuesta_Clave">Respuesta_Clave</param>
        /// <param name="Respuesta">Respuesta</param>
        /// <param name="UserId">UserId</param>
        /// <param name="HostName">HostName</param>
        /// <returns>string</returns>
        public static string SaveCRMQuestions(string Poliza, string Respuesta_Clave, List<Respuestas> Respuesta, int UserId, string HostName)
        {
            string returnString = string.Empty;
            try
            {
                SRSecurityQuestion.WS_SecurityQuestionClient client = new SRSecurityQuestion.WS_SecurityQuestionClient();
                ClientQuestionCollection clientQuestionCollection = new ClientQuestionCollection();
                clientQuestionCollection = GetCrmDatos(Poliza, Respuesta_Clave, Respuesta, UserId, HostName);

                string json;
                using (var ms = new MemoryStream())
                {
                    var ser = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(ClientQuestionCollection));
                    ser.WriteObject(ms, clientQuestionCollection);
                    json = System.Text.Encoding.UTF8.GetString(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
                }

                returnString = client.UpdateSecurityQuestion(json);

            }
            catch (Exception ex)
            {
                string parameter = string.Format("Poliza: {0}, Respuesta_Clave: {1}", Poliza, Respuesta_Clave);
                //
                ConfirmationCallLog.Log("funcion SaveCRMQuestions", string.Format("Message {0}, Inner Exception {1}", ex.Message, ex.InnerException), parameter, UserId, HostName);

            }

            return returnString;

        }

    }

}