using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.ConfirmationCall.Common;
using WEB.ConfirmationCall.Infrastructure.Providers;


namespace WEB.ConfirmationCall.UserControls.History
{
    public partial class UCSecurityQuestions : UC
    {

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
                        FillSecurityQuestions();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void FillSecurityQuestions()
        {
            DataQuestion = _services.oContactManager.GetAllSecurityQuestion(_services.Corp_Id, _services.Current_Contact_Id, UserDataProvider.LanguageId);
            GrdPreguntas.DataBind();
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
                //IEnumerable<Entity.UnderWriting.Entities.Contact.SecurityQuestion> NewDataQuestion = DataQuestion;
                //DevExpress.Web.Data.ASPxDataUpdatingEventArgs cevent = e;

                foreach (var Question in DataQuestion)
                {
                    if (Question.QuestionId == e.NewValues["QuestionId"].ToInt())
                    {
                        Question.Answer = e.NewValues["Answer"].ToString();
                    }
                }

                GrdPreguntas.CancelEdit();
                GrdPreguntas.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void dsQuestion_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
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
            GrdPreguntas.UpdateEdit();
            for (int i = 0; i < GrdPreguntas.VisibleRowCount; i++)
            {
                var prueba = GrdPreguntas.DetailRows.ToString();
                object[] row1 = (object[])GrdPreguntas.GetRowValues(i, "QuestionId", "QuestionDesc", "Answer");
                if ((row1[2] != null) && (row1[2].ToString().Length>0))
                {
                    _services.oContactManager.SetSecurityQuestion(new Entity.UnderWriting.Entities.Contact.SecurityQuestion
                    {
                        CorpId = _services.Corp_Id,
                        ContactId = _services.Current_Contact_Id,
                        QuestionId = row1[0].ToInt(),
                        QuestionDesc = row1[1].ToString(),
                        Answer = row1[2].ToString(),
                        UserId = UserDataProvider.UserId.ToInt()
                    });
                }
            }
             
            //FillSecurityQuestions(ContactId);
        }

        protected void BtnGrabar_Click(object sender, EventArgs e)
        {
            UpdateQuestion();

 

        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            Translate();
        }

        void Translate()
        {
            Utility.TranslateColumnsAspxGrid(this.GrdPreguntas);
           // BtnGrabar.Text = RESOURCE.UnderWriting.ConfirmationCall.Resources.Save;
        }
    }
}