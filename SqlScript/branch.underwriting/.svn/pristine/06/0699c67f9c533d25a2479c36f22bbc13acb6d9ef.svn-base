using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.MedicalInfo
{
    public partial class UCMedicalExams : WEB.UnderWriting.Common.UC
    {
      

      public   class ItemLab {
           public string ExmaDate { get; set; }
           public string ExmaTime { get; set; }
           public string MedTestDesc { get; set; }
           public string SubtestDesc { get; set; }
           public string Units { get; set; }
           public string Result { get; set; }
           public string LabFromParam { get; set; }
           public string LabToParam { get; set; }
           public string ReinsurerFromParam { get; set; }
           public string ReinsurerToParam { get; set; }
        
        }
        //IMedical MedicalManager
        //{
        //    get { return diManager.MedicalManager; }
        //}

        //UnderWritingDIManager diManager = new UnderWritingDIManager();
        DropDownManager DropDowns = new DropDownManager();


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        public void fillData(int contactId)
        {
            int Corp_Id = Service.Corp_Id;
            int Region_Id = Service.Region_Id;
            int Country_Id = Service.Country_Id;
            int Domesticreg_Id = Service.Domesticreg_Id;
            int State_Prov_Id = Service.State_Prov_Id;
            int City_Id = Service.City_Id;
            int Office_Id = Service.Office_Id;
            int Case_Seq_No = Service.Case_Seq_No;
            int Hist_Seq_No = Service.Hist_Seq_No;

            Session["Contact_Id"] = contactId;

            ddlExamType.DataSource = DropDowns.GetDropDown(DropDownType.MedicalExamReceived, Corp_Id, Region_Id, Country_Id, Domesticreg_Id, State_Prov_Id, City_Id, Office_Id, Case_Seq_No, Hist_Seq_No, contactId, projectId: Service.ProjectId, companyId: Service.CompanyId);
            ddlExamType.DataBind();
            ddlExamType.Items.Insert(0, new ListItem("Selected", "-1"));

            gvMedicalExams.DataSource = Services.MedicalManager.GetExamReceived(Corp_Id, Region_Id, Country_Id, Domesticreg_Id, State_Prov_Id, City_Id, Office_Id, Case_Seq_No, Hist_Seq_No, contactId);
            gvMedicalExams.DataBind();

            List<ItemLab> labs = new List<ItemLab>();
            //labs.Add(new ItemLab { ExmaDate = "6/20/2012", ExmaTime = "7:00 AM", MedTestDesc = "Biometria Hematica Completa", SubtestDesc = "Leucocitos", Units = "%", Result = "5,600", LabFromParam = "5,600", LabToParam = "11,200", ReinsurerFromParam = "11,200", ReinsurerToParam = "11,200" });
            //labs.Add(new ItemLab { ExmaDate = "6/20/2012", ExmaTime = "7:00 AM", MedTestDesc = "Biometria Hematica Completa", SubtestDesc = "HDL Colesterol", Units = "mg/dl", Result = "5,600", LabFromParam = "5,600", LabToParam = "11,200", ReinsurerFromParam = "11,200", ReinsurerToParam = "11,200" });

            gvMedicalInfoDetail.DataSource = labs;
            //gvMedicalInfoDetail.DataSource = MedicalManager.GetExamResult(
            //        Corp_Id,
            //        Region_Id,
            //        Country_Id,
            //        Domesticreg_Id,
            //        State_Prov_Id,
            //        City_Id,
            //        Office_Id,
            //        Case_Seq_No,
            //        Hist_Seq_No,
            //        (int)Session["Contact_Id"],
            //        1,
            //        1,
            //        1,
            //        1);
            gvMedicalInfoDetail.DataBind();

        }


        protected void lnkPdfFile_Click(object sender, EventArgs e)
        {

        }

        protected void ddlExamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Corp_Id = Service.Corp_Id;
            int Region_Id = Service.Region_Id;
            int Country_Id = Service.Country_Id;
            int Domesticreg_Id = Service.Domesticreg_Id;
            int State_Prov_Id = Service.State_Prov_Id;
            int City_Id = Service.City_Id;
            int Office_Id = Service.Office_Id;
            int Case_Seq_No = Service.Case_Seq_No;
            int Hist_Seq_No = Service.Hist_Seq_No;
            
            if (ddlExamType.SelectedValue != "-1") {
                int RequirementCatId = int.Parse(ddlExamType.SelectedValue.Split('|')[0]);
                int RequirementTypeId = int.Parse(ddlExamType.SelectedValue.Split('|')[1]);
                int RequirementId = int.Parse(ddlExamType.SelectedValue.Split('|')[2]);
                int MedicalTestId = int.Parse(ddlExamType.SelectedValue.Split('|')[3]);

                gvMedicalInfoDetail.DataSource = Services.MedicalManager.GetExamResult(
                    Corp_Id, 
                    Region_Id, 
                    Country_Id,
                    Domesticreg_Id, 
                    State_Prov_Id, 
                    City_Id, 
                    Office_Id, 
                    Case_Seq_No,
                    Hist_Seq_No, 
                    (int)Session["Contact_Id"],
                    RequirementCatId,
                    RequirementTypeId, 
                    RequirementId,
                    MedicalTestId);

                gvMedicalInfoDetail.DataBind();
            
            }

        }

        protected void gvMedicalInfoDetail_DataBound(object sender, EventArgs e)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();

            cell.Text = "Date";
            cell.ColumnSpan = 1;
            cell.CssClass = "c1";
            cell.RowSpan = 2;
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.Text = "Time";
            cell.ColumnSpan = 1;
            cell.CssClass = "c2";
            cell.RowSpan = 2;
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.Text = "Exam";
            cell.ColumnSpan = 1;
            cell.CssClass = "c3";
            cell.RowSpan = 2;
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.Text = "Tests";
            cell.ColumnSpan = 1;
            cell.CssClass = "c4";
            cell.RowSpan = 2;
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.Text = "Units";
            cell.ColumnSpan = 1;
            cell.CssClass = "c5";
            cell.RowSpan = 2;
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.Text = "Results";
            cell.ColumnSpan = 1;
            cell.CssClass = "c6";
            cell.RowSpan = 2;
            row.Controls.Add(cell);


            cell = new TableHeaderCell();
            cell.Text = "Laboratory Parameters";
            cell.CssClass = "c7-1";
            cell.ColumnSpan = 2;
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 2;
            cell.Text = "Reinsurer Parameters";
            cell.CssClass = "c7-1";
            row.Controls.Add(cell);

            if (gvMedicalInfoDetail.HeaderRow!=null)
            gvMedicalInfoDetail.HeaderRow.Parent.Controls.AddAt(0, row);
        }




    }
}