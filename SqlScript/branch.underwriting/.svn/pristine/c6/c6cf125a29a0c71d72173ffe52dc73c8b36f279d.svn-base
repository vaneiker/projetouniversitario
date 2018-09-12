using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration.EForm
{
    public partial class UCFormsContainer : UC, IUC
    {
        private UCIllustrationContainer UCContainer
        {
            get
            {
                return (UCIllustrationContainer)Page.Controls[0].FindControl("bodyContent").FindControl("UCIllustrationContainer");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UCFormsEvailable.DisplayFormEvent += new UCFormsEvailable.DisplayFormHaddle(DisplayFormHaddle);
        }

        public void DisplayFormHaddle(int formID)
        {
            UCFormView.FillData(formID);
        }
        protected void btnSaveForms_Click(object sender, EventArgs e)
        {
            //var a = Page.Request.Form["To"];
            //var Date = Page.Request.Form["Date"];
            //var From = Page.Request.Form["From"];

            DataTable RowToInsert = ObjServices.oFormManager.GetFormDetailUddt();
            Entity.UnderWriting.Entities.Form.FieldValue.Parameter param = new Entity.UnderWriting.Entities.Form.FieldValue.Parameter();
          
            //STL
            //param.CorpId = 1;
            //param.RegionId = 2;
            //param.CountryId = 14;
            //param.DomesticRegId = 17;
            //param.StateProvId = 1;
            //param.CityId = 1;
            //param.OfficeId = 4;
            //param.CaseSeqNo = 1;
            //param.HistSeqNo = 1;
            //param.ContactId = 356834;

            //ATL
            //param.CorpId = 1;
            //param.RegionId = 2;
            //param.CountryId = 14;
            //param.DomesticRegId = 17;
            //param.StateProvId = 5;
            //param.CityId = 1;
            //param.OfficeId = 84;
            //param.CaseSeqNo = 22;
            //param.HistSeqNo = 1;
            //param.ContactId = 456994;

            param.CorpId = ObjServices.Corp_Id;
            param.RegionId = ObjServices.Region_Id;
            param.CountryId = ObjServices.Country_Id;
            param.DomesticRegId = ObjServices.Domesticreg_Id;
            param.StateProvId = ObjServices.State_Prov_Id;
            param.CityId = ObjServices.City_Id;
            param.OfficeId = ObjServices.Office_Id;
            param.CaseSeqNo = ObjServices.Case_Seq_No;
            param.HistSeqNo = ObjServices.Hist_Seq_No;
            param.ContactId = ObjServices.Contact_Id.Value;


            param.FormId = UCFormView.Form_ID_Select;
            
            var valores = ObjServices.oFormManager.GetFormFieldValues(param);

            foreach (var item in valores)
            {

                if (Page.Request.Form[item.FieldTitle] != null)
                {

                    DataRow dr = RowToInsert.NewRow();
                    dr["Corp_Id"] = param.CorpId;
                    dr["Region_Id"] = param.RegionId;
                    dr["Country_Id"] = param.CountryId;
                    dr["Domesticreg_Id"] = param.DomesticRegId;
                    dr["State_Prov_Id"] = param.StateProvId;
                    dr["City_Id"] = param.CityId;
                    dr["Office_Id"] = param.OfficeId;
                    dr["Case_Seq_No"] = param.CaseSeqNo;
                    dr["Hist_Seq_No"] = param.HistSeqNo;
                    dr["Form_Id"] = param.FormId;
                    dr["Contact_Id"] = param.ContactId;
                    dr["Field_Id"] = item.FieldId;
                    dr["UserId"] = ObjIllustrationServices.IllusUserID.Value;

                    dr["Field_Value_Status"] = false;
                  
                    switch (item.FieldTypeId)
                    {
                        case 1:
                          if (Page.Request.Form[item.FieldTitle] != null)
                                dr["Text_Value"] = Page.Request.Form[item.FieldTitle].ToString();
                            else
                                dr["Text_Value"] = string.Empty;
                            break;
                        case 3:
                            if (Page.Request.Form[item.FieldTitle] != null)
                                if (Utility.IsDate(Page.Request.Form[item.FieldTitle].ToString()))
                                    dr["Date_Value"] = Page.Request.Form[item.FieldTitle].ToString().ParseFormat();
                            break;

                        case 2:
                            if (Page.Request.Form[item.FieldTitle] != null)
                            {
                                if (Page.Request.Form[item.FieldTitle].ToString().ToLower() == "on")
                                    dr["Field_Value_Status"] = true;
                            }
                          
                            break;
                        case 4:
                        break;

                    }

                    RowToInsert.Rows.Add(dr);
                    //dr["Numeric_Value"]=
                    //dr["Integer_Value"]=
                    //dr["Date_Value"]=

                }
                
            }

            if(RowToInsert.Rows.Count >0)
            {
                ObjServices.oFormManager.SetFormDetail(RowToInsert);

            }
            UCFormView.FillData(UCFormView.Form_ID_Select);
        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {
            UCFormsEvailable.FillData();
            
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }

        #region Fill PDF
        protected void btnSaveFormPDF_Click(object sender, EventArgs e)
        {
            UCFormView.FillData(FillForm());

        }
        private string  FillForm()
        {
            string pdfTemplate = Server.MapPath("~/NewBusiness/UserControls/Illustration/EForm/TemplatePDFS");
            string newFile = "";
            Entity.UnderWriting.Entities.Form.FieldValue.Parameter param = new Entity.UnderWriting.Entities.Form.FieldValue.Parameter();

            //STL
            //param.CorpId = 1;
            //param.RegionId = 2;
            //param.CountryId = 14;
            //param.DomesticRegId = 17;
            //param.StateProvId = 1;
            //param.CityId = 1;
            //param.OfficeId = 4;
            //param.CaseSeqNo = 1;
            //param.HistSeqNo = 1;
            //param.ContactId = 356834;
            
            //ATL
            //param.CorpId = 1;
            //param.RegionId = 2;
            //param.CountryId = 14;
            //param.DomesticRegId = 17;
            //param.StateProvId = 5;
            //param.CityId = 1;
            //param.OfficeId = 84;
            //param.CaseSeqNo = 22;
            //param.HistSeqNo = 1;
            //param.ContactId = 456994;

            param.CorpId = ObjServices.Corp_Id;
            param.RegionId = ObjServices.Region_Id;
            param.CountryId = ObjServices.Country_Id;
            param.DomesticRegId = ObjServices.Domesticreg_Id;
            param.StateProvId = ObjServices.State_Prov_Id;
            param.CityId = ObjServices.City_Id;
            param.OfficeId = ObjServices.Office_Id;
            param.CaseSeqNo = ObjServices.Case_Seq_No;
            param.HistSeqNo = ObjServices.Hist_Seq_No;
            param.ContactId = ObjServices.Contact_Id.Value;

            param.FormId = UCFormView.Form_ID_Select;
            var valores = ObjServices.oFormManager.GetFormFieldValues(param);

            if (valores != null)
            {
                if (!string.IsNullOrEmpty(valores.FirstOrDefault().PdfTemplatePath))
                {
                    pdfTemplate = pdfTemplate + @"\" + valores.FirstOrDefault().PdfTemplatePath;  //CuestionarioHipertensos.pdf";

                    newFile = Server.MapPath("~/TempFiles/") + @"\Form" + System.Guid.NewGuid().ToString().Replace("-", "").Substring(0, 15);
                    PdfReader pdfReader = new PdfReader(pdfTemplate);
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(
                        newFile, FileMode.Create));
                    AcroFields pdfFormFields = pdfStamper.AcroFields;

                    foreach (var item in valores)
                    {
                        switch (item.FieldTypeId)
                        {
                            case 1:
                                //if (!string.IsNullOrEmpty(pdfFormFields.GetField(item.FieldTitle)))
                                //{
                                if (!string.IsNullOrEmpty(item.TextValue))
                                    pdfFormFields.SetField(item.FieldTitle, item.TextValue);
                                //}
                                else
                                    pdfFormFields.SetField(item.FieldTitle, "");
                                break;
                            case 3:

                                //if (!string.IsNullOrEmpty(pdfFormFields.GetField(item.FieldTitle)))
                                //{
                                if (item.DateValue.HasValue)
                                    pdfFormFields.SetField(item.FieldTitle, item.DateValue.Value.ToShortDateString());
                                //}
                                else
                                    pdfFormFields.SetField(item.FieldTitle, "");

                                break;

                            case 2:
                                //if (!string.IsNullOrEmpty(pdfFormFields.GetField(item.FieldTitle)))
                                //{
                                if (item.FieldValueStatus.HasValue)
                                {
                                    if (item.FieldValueStatus.Value == true)
                                        pdfFormFields.SetField(item.FieldTitle, "Yes");
                                    else
                                        pdfFormFields.SetField(item.FieldTitle, "No");
                                }
                                //}
                                else
                                    pdfFormFields.SetField(item.FieldTitle, "No");

                                break;
                            case 4:
                                break;

                        }
                    }
                  
                    pdfStamper.FormFlattening = false;
                    // close the pdf

                    pdfStamper.Close();
                }
            }
            return newFile;
        }
       
        #endregion



        public void ReadOnlyControls(bool isReadOnly)
        {
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            UCContainer.SetMultiView(UCIllustrationContainer.MultiViewIllustrator.PlanInformation);

        }
    }
}