using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration.EForm
{
    public partial class UCFormView : UC, IUC
    {

        public int Form_ID_Select
        {
            get
            {
                return (int)ViewState["Form_ID_Select"];
            }
            set
            {
                ViewState["Form_ID_Select"] = value;
            }
        }  

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pdfViewerPdfPopUp.LicenseKey = System.Configuration.ConfigurationManager.AppSettings["PDFViewer"].ToString();
                
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

        public void FillData(string ViewPDFFile)
        {
            mvSelectView.SetActiveView(VPDF);
            if (File.Exists(ViewPDFFile))
            {
                this.pdfViewerPdfPopUp.PdfSourceBytes = Utility.ReadBinaryFile(ViewPDFFile);
                this.pdfViewerPdfPopUp.DataBind();
            }
        }
        public void FillData(int formID)
        {
            mvSelectView.SetActiveView(vHTML);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("$(document).ready(function(){ ");

            Entity.UnderWriting.Entities.Form.FieldValue.Parameter param = new Entity.UnderWriting.Entities.Form.FieldValue.Parameter();

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

            param.FormId = formID;


            Form_ID_Select = formID;
            var valores = ObjServices.oFormManager.GetFormFieldValues(param);

            if (valores!= null)
            {
                var HTML = valores.FirstOrDefault().HtmlTemplate;
                lForms.Text = HTML;
                string v=string.Empty;

                foreach (var item in valores)
                {

                    //Field_Type_Id	Field_Type_Desc
                    //1	TEXTBOX
                    //2	CHECKBOX
                    //3	TEXTBOXDATE
                    //4	RADIOBUTTON
                    switch (item.FieldTypeId)
                    {
                        case 1:
                               v  = " $('#{0}').val('{1}');";
                            if(item.HasValues.HasValue && item.TextValue!= null)
                              sb.Append(  string.Format(v, item.FieldTitle, item.TextValue));
                            break;
                        case 3:
                            v  = " $('#{0}').val('{1}');";
                            if(item.HasValues.HasValue && item.DateValue.HasValue)
                                sb.Append(string.Format(v, item.FieldTitle, item.DateValue.ToString()));
                        break;

                        case 2:
                        v = " $('#{0}').prop('checked',{1}); ";
                        if (item.HasValues.HasValue && item.FieldValueStatus.HasValue)
                            if(item.FieldValueStatus.Value)
                                 sb.Append(string.Format(v, item.FieldTitle, "true"));
                            else
                               sb.Append( string.Format(v, item.FieldTitle, "false"));
                        break;

                        case 4:

                        break;

                    }
                }
            }


            //this.ExcecuteJScript("$(document).ready(function(){ " 
            //+ " $('#Datos_Asegurado_Primer_Apellido').val('example value') "

            //+ " $('#Datos_Asegurado_Primer_Apellido').prop('checked',true) "
            //+ " });");

            sb.Append(" });");

            this.ExcecuteJScript(sb.ToString());
        }
        public void FillData()
        {
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }


        public void ReadOnlyControls(bool isReadOnly)
        {
            
        }
    }
}