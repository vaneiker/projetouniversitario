using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.ConfirmationCall.Common;
using WEB.ConfirmationCall.Infrastructure.Providers;


namespace WEB.ConfirmationCall.UserControls.ConfirmationCall
{
    public partial class UCSecurityQuestions : UC
    {
        #region fields

        List<int> lstQuestionId = new List<int>() { 9, 10, 11 };

        #endregion

        #region Metodos

        public IEnumerable<Entity.UnderWriting.Entities.Contact.SecurityQuestion> DataQuestion
        {
            get
            {
                var data = Session["UCSecurityQuestions.DataQuestion"];
                return data != null ? (IEnumerable<Entity.UnderWriting.Entities.Contact.SecurityQuestion>)Session["UCSecurityQuestions.DataQuestion"] : null;
            }
            set
            {
                Session["UCSecurityQuestions.DataQuestion"] = value;
            }
        }

        public object GetQuestion(IEnumerable<Entity.UnderWriting.Entities.Contact.SecurityQuestion> data)
        {
            return data;
        }

        public IEnumerable<Entity.UnderWriting.Entities.Contact.SecurityQuestion> SetQuestion(IEnumerable<Entity.UnderWriting.Entities.Contact.SecurityQuestion> data, int QuestionId)
        {
            return data;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (_services.Current_Contact_Id > 0)
                    {
                        //Session["ModificarAddres"] = "0";
                        FillSecurityQuestions();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Translate();
        }

        void Translate()
        {
            Utility.TranslateColumnsAspxGrid(this.GrdPreguntas);
            BtnGrabar.Text = RESOURCE.UnderWriting.ConfirmationCall.Resources.Save;
            FillSecurityQuestions();

        }

        public void FillSecurityQuestions()
        {

            DataQuestion = _services.oContactManager.GetAllSecurityQuestion(_services.Corp_Id, _services.Current_Contact_Id, UserDataProvider.LanguageId);

            GrdPreguntas.DataBind();

            try
            {

                Control chkDateBirth = FindControlRecursive(Page, "chkDateBirth");
                //
                Control chkAgent = FindControlRecursive(Page, "chkAgent");
                //
                Control chkId = FindControlRecursive(Page, "chkId");
                //


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

            }
            catch (Exception ex)
            {

            }


        }

        protected void GrdPreguntas_RowCommand1(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            try
            {
                switch (((Button)e.CommandSource).CommandName)
                {
                    case "Edit":
                        break;
                    default:
                        break;
                }
            }

            catch (Exception ex)
            {

            }

        }

        protected void GrdPreguntas_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {

                foreach (var Question in DataQuestion)
                {
                    //   Question.Answer = "";
                    if (Question.QuestionId == e.NewValues["QuestionId"].ToInt())
                    {
                        if (e.NewValues["Answer"] == null)
                        {
                            Question.Answer = null;
                            break;
                        }
                        else
                        {
                            Question.Answer = e.NewValues["Answer"].ToString();
                            break;
                        }

                    }
                    //else
                    //{
                    //    Question.Answer = null;


                    //}
                }

                GrdPreguntas.CancelEdit();
                GrdPreguntas.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void dsQuestion_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)////aqui arreglar esto omar
        {
            if (DataQuestion != null)
            {
                var query = from preguntasDatos in DataQuestion
                            where preguntasDatos.ContactId == _services.Current_Contact_Id && preguntasDatos.CorpId == _services.Corp_Id
                                  && (preguntasDatos.QuestionId != 9 && preguntasDatos.QuestionId != 10 && preguntasDatos.QuestionId != 11)
                            select preguntasDatos;

                e.InputParameters["data"] = query;
            }
            else
            {
                e.InputParameters["data"] = null;
            }
        }

        protected void dsQuestion_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            //
            GrdPreguntas.DataBind();
        }

        public void UpdateQuestion()
        {
            List<Respuestas> listRespuesta = new List<Respuestas>();

            Control chkDateBirth = FindControlRecursive(Page, "chkDateBirth");
            //
            Control chkAgent = FindControlRecursive(Page, "chkAgent");
            //
            Control chkId = FindControlRecursive(Page, "chkId");
            //
            string DateBirth = ((CheckBox)chkDateBirth).Checked.ToString();
            //
            string Agent = ((CheckBox)chkAgent).Checked.ToString();
            ///
            string Id = ((CheckBox)chkId).Checked.ToString();

            int index = 0;

            string respuesta = string.Empty;
            //

            string Respuesta_Clave = "";

            string msg = "";
            string resultado = "";
            string NameId = "";

            GrdPreguntas.UpdateEdit();

            try
            {

                GridViewDataColumn column1 = GrdPreguntas.Columns["Answer"] as GridViewDataColumn;
                for (int i = 0; i < GrdPreguntas.VisibleRowCount; i++)
                {
                    var prueba = GrdPreguntas.DetailRows.ToString();
                    object[] row1 = (object[])GrdPreguntas.GetRowValues(i, "QuestionId", "QuestionDesc", "Answer", "NameId");
                    TextBox txtRespuesta = (TextBox)GrdPreguntas.FindRowCellTemplateControl(i, column1, "txtBox");

                    respuesta = txtRespuesta.Text;

                    if (row1[3] != null)
                    {
                        NameId = row1[3].ToString();
                    }
                    else
                    {
                        NameId = "";
                    }

                    _services.oContactManager.SetSecurityQuestion(new Entity.UnderWriting.Entities.Contact.SecurityQuestion
                    {
                        CorpId = _services.Corp_Id,
                        ContactId = _services.SessionData.PolicyInfo.OwnerContactId,
                        QuestionId = row1[0].ToInt(),
                        QuestionDesc = row1[1].ToString(),
                        Answer = ((string.IsNullOrEmpty(respuesta) ? string.Empty : respuesta)),
                        UserId = UserDataProvider.UserId.ToInt()
                    });

                    var answer = "";

                    foreach (var item in DataQuestion.Where(o => lstQuestionId.Contains(o.QuestionId)))
                    {

                        switch (item.QuestionId)
                        {
                            case 9:
                                answer = DateBirth;
                                break;
                            case 10:
                                answer = Agent;
                                break;
                            case 11:
                                answer = Id;
                                break;
                        }

                        _services.oContactManager.SetSecurityQuestion(new Entity.UnderWriting.Entities.Contact.SecurityQuestion
                        {
                            CorpId = _services.Corp_Id,
                            ContactId = _services.SessionData.PolicyInfo.OwnerContactId,
                            QuestionId = item.QuestionId,
                            QuestionDesc = item.QuestionDesc,
                            Answer = answer,
                            UserId = UserDataProvider.UserId.ToInt()
                        });


                        if (i == 5 && respuesta.IndexOf("/") != -1)
                        {

                            Respuesta_Clave = respuesta.Split('/')[1];
                            listRespuesta.Add(new Respuestas() { No = (i + 1), Respuesta = respuesta.Split('/')[0] });

                        }
                        else
                        {

                            listRespuesta.Add(new Respuestas() { No = (i + 1), Respuesta = respuesta });
                        }
                    }
                }
                //update webservice
                if (listRespuesta.Count > 0)
                {
                    if (!string.IsNullOrEmpty(CRMDataInit.getAccountID(NameId, UserDataProvider.UserId.ToInt(), Request.ServerVariables["SERVER_NAME"].ToString())))
                    {
                        resultado = CRMDataInit.SaveCRMQuestions(NameId, Respuesta_Clave, listRespuesta, UserDataProvider.UserId.ToInt(), Request.ServerVariables["SERVER_NAME"].ToString());
                    }
                    else
                    {
                        msg = "Estos registros no esta disponibles en CRM para ser actualizados";
                        imgButtonAlert.ImageUrl = "~/images/red_icon.png";
                    }

                }

            }
            catch (Exception ex)
            {
                string parameter = "DateBirth:" + DateBirth + ",Agent:" + Agent + ",Id:" + Id + ",index:" + index + ",respuesta:" + respuesta + ",UserId:" + UserDataProvider.UserId.ToInt() + "";
                //
                ConfirmationCallLog.Log("Methodo UpdateQuestion", string.Format("Message {0}, Inner Exception {1}", ex.Message, ex.InnerException),
                    parameter, UserDataProvider.UserId.ToInt(), Request.ServerVariables["SERVER_NAME"].ToString());
            }


            if (resultado.Length > 0)
            {
                string d = resultado.Split('[')[1].Substring(0, 1);

                if (d == "0")
                {
                    imgButtonAlert.ImageUrl = "~/images/green_icon.png";
                }
                else
                {
                    imgButtonAlert.ImageUrl = "~/images/red_icon.png";
                    msg = string.Format("{0} <br/> {1}", msg, "Estos registros estan en proceso de ser actualizados");
                }
            }
            
            msg = string.Format(RESOURCE.UnderWriting.ConfirmationCall.Resources.SecurityQuestionSaveSucessfully, msg);
            Alertify.Alert(msg, this);

        }
        //
        protected void BtnGrabar_Click(object sender, EventArgs e)
        {
            UpdateQuestion();

            //ICONOS ESTADO

            Control iconSecurityFlag = FindControlRecursive(Page, "iconSecurityFlag");
            var lstSecurityQuestions = _services.oContactManager.GetAllSecurityQuestion(_services.Corp_Id, _services.Current_Contact_Id, UserDataProvider.LanguageId);
            iconSecurityFlag.Visible = lstSecurityQuestions.Count(o => (String.IsNullOrEmpty(o.Answer) || o.Answer.ToLower() == "false")) > 0 ? false : true;

        }

        protected void btnSelectRows_Click(object sender, EventArgs e)
        {

            // GrdPreguntas.StartEdit(Convert.ToInt32(hdnGridIndexRows.Value));
        }

        protected void GrdEmailAddresses_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {

            switch (((Button)e.CommandSource).CommandName)
            {
                case "Edit":
                    GrdPreguntas.UpdateEdit();
                    GrdPreguntas.StartEdit(e.VisibleIndex);
                    break;
                case "Delete":
                //EliminaEmail();
                //break;
                default:
                    break;


            }
        }

        private Control FindControlRecursive(Control root, string id)
        {
            if (root.ID == id) return root;
            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, id);
                if (t != null) return t;
            }
            return null;
        }



    }
}