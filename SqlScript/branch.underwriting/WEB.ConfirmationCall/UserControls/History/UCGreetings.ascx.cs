using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using WEB.ConfirmationCall.Common;
using WEB.ConfirmationCall.Infrastructure.Providers;


namespace WEB.ConfirmationCall.UserControls.History
{
    public partial class UCGreetings : UC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        List<int> lstQuestionId = new List<int>() { 9, 10, 11 };


        private string GetPlanOrPoliza(string Plan)
        {
            string result = "";

            switch (Plan)
            {
                case "Luminis":
                    {
                        result = "PLAN LUMINIS";
                        break;
                    }

                case "Luminis Básico":
                    {
                        result = "PLAN LUMINIS BÁSICO";
                        break;
                    }
                case "Luminis VIP":
                    {
                        result = "PLAN LUMINIS VIP";
                        break;
                    }
                case "Exequium Básico":
                    {
                        result = "PLAN EXEQUIUM BÁSICO";
                        break;
                    }
                case "Exequium VIP":
                    {
                        result = "PLAN EXEQUIUM VIP";
                        break;
                    }
                case "Orion":
                    {

                        if (UserDataProvider.LanguageId == 1)
                        {
                            result = "POLICY ORION";
                        }
                        else
                        {
                            result = "POLIZA ORION";
                        }

                        break;
                    }
                case "Guardian":
                    {
                        if (UserDataProvider.LanguageId == 1)
                        {
                            result = "POLICY GUARDIAN";
                        }
                        else
                        {
                            result = "POLIZA GUARDIAN";
                        }

                        break;
                    }
                case "Guardian Plus":
                    {
                        if (UserDataProvider.LanguageId == 1)
                        {
                            result = "POLICY GUARDIAN PLUS";
                        }
                        else
                        {
                            result = "POLIZA GUARDIAN PLUS";
                        }

                        break;
                    }
            }

            return result;

        }


        private string GetFullNameOperador()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("SELECT isnull(FullName,'') as FullName FROM [Security].[VWSecurityUsers] WHERE UserId = {0}", UserDataProvider.UserId);
            string rs = string.Empty;
            try
            {

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

                        using (SqlDataReader dr = oCommand.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                if (dr["FullName"] != DBNull.Value)
                                {
                                    rs = string.Format("{0}", dr["FullName"].ToString());
                                }

                            }

                        }

                    }
                }
            }
            catch (Exception)
            {
            }
            return rs;

        }



        //LLENA GREETINGS.
        public void LlenaGreetings()
        {
            try
            {


                //ICONOS ESTADO
                var lstSecurityQuestions = _services.oContactManager.GetAllSecurityQuestion(_services.Corp_Id, _services.Current_Contact_Id, UserDataProvider.LanguageId);
                iconSecurityFlag.Visible = lstSecurityQuestions.Count(o => (String.IsNullOrEmpty(o.Answer) || o.Answer.ToLower() == "false")) > 0 ? false : true;
                iconMedicalFlag.Visible = false;

                //DATOS CONTACT.
                var lstContact = _services.oContactManager.GetContact(_services.Corp_Id, _services.Current_Contact_Id, UserDataProvider.LanguageId);
                tbDateBirth.Text = lstContact != null ? lstContact.Dob.Value.ToLongDateString() : null;
                lbNombreCliente.Text = lstContact != null ? lstContact.FullName.ToUpper() : null;

                //DATOS DOCUMENTOS.
                var lsDocumentos = _services.oContactManager.GetAllIdDocumentInformation(_services.Current_Contact_Id, UserDataProvider.LanguageId);
                var document = lsDocumentos.FirstOrDefault();
                tbId.Text = document != null ? document.Id : "N/A";



                var DataQuestion = _services.oContactManager.GetAllSecurityQuestion(_services.Corp_Id, _services.Current_Contact_Id, UserDataProvider.LanguageId);



                foreach (var item in DataQuestion.Where(o => lstQuestionId.Contains(o.QuestionId)))
                {

                    switch (item.QuestionId)
                    {
                        case 9:
                            ((CheckBox)chkDateBirth).Checked = (item.Answer == "True" ? true : false);
                            break;
                        case 10:
                            ((CheckBox)chkAgent).Checked = (item.Answer == "True" ? true : false);
                            break;
                        case 11:
                            ((CheckBox)chkId).Checked = (item.Answer == "True" ? true : false);
                            break;
                    }
                }



                //DATOS POLICIES.
                var lsPolicies = _services.oPolicyManager.GetPlanData(_services.Corp_Id, _services.Region_Id, _services.Country_Id, _services.Domesticreg_Id, _services.State_Prov_Id, _services.City_Id, _services.Office_Id, _services.Case_Seq_No, _services.Hist_Seq_No);
                tbAgent.Text = lsPolicies.AgentFullName.ToUpper();

                //Quitar Valor por defecto                
                string nombre = GetFullNameOperador();
                lbNombreOperador.Text = (string.IsNullOrEmpty(nombre) ? "MARJORY ORTEGA" : nombre);
                lbNombreOperador.Text = lbNombreOperador.Text.ToUpper();
                lbAcesorFinanciero.Text = lsPolicies.AgentFullName.ToUpper();


                //lbPlan
                if (lsPolicies != null)
                {
                    lbPlan.Text = GetPlanOrPoliza(lsPolicies.PlanName);
                }
                else
                {
                    lbPlan.Text = "N/A";
                }

            }
            catch (Exception ex)
            {
                string param = "";
                ConfirmationCallLog.Log("HISTORICO.UCGreetings : LlenaGreetings", string.Format("Message {0} TrackTrace {1}", ex.Message, ex.StackTrace),
                    param, UserDataProvider.UserId.ToInt(), Request.ServerVariables["SERVER_NAME"].ToString());
            }
        }
    }
}