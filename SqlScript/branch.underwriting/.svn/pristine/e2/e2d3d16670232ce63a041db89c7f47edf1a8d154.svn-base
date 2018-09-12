using iTextSharp.text.pdf;
using PdfViewer4AspNet;
using Statetrust.Framework.Core.Util;
using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;
using Entity.UnderWriting.Entities;
using System.Collections.Generic;

namespace WEB.UnderWriting.Case.UserControls.FinancialInfo
{
	public partial class UCActivities : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
	{
		public class Activities
		{
			public string Form_Desc { get; set; }
			public string Create_date { get; set; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void gvQuestionnaires_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gvQuestionnaires.PageIndex = e.NewPageIndex;
			gvQuestionnaires.DataBind();
			FillData();
			setPagerIndex(gvQuestionnaires);
		}

		void setPagerIndex(GridView gv)
		{
			if (gv.BottomPagerRow != null)
			{
				var lnkPrev = (LinkButton)gv.BottomPagerRow.FindControl("prevButton");
				var lnkFirst = (LinkButton)gv.BottomPagerRow.FindControl("firstButton");
				var lnkNext = (LinkButton)gv.BottomPagerRow.FindControl("nextButton");
				var lnkLast = (LinkButton)gv.BottomPagerRow.FindControl("lastButton");
				var indexText = (Literal)gv.BottomPagerRow.FindControl("indexPage");
				var totalText = (Literal)gv.BottomPagerRow.FindControl("totalPage");


				var count = gv.PageCount;
				var index = gv.PageIndex + 1;

				indexText.Text = index.ToString();
				totalText.Text = count.ToString();

				if (index == 1)
				{
					DisableLinkButton(lnkPrev, "prev_dis");
					DisableLinkButton(lnkFirst, "rewd_dis");
				}
				else if (index == count)
				{
					DisableLinkButton(lnkNext, "next_dis");
					DisableLinkButton(lnkLast, "fwrd_dis");
				}
			}
		}

		public void DisableLinkButton(LinkButton linkButton, string disable_class)
		{
			linkButton.CssClass = disable_class;
			linkButton.Enabled = false;
		}

		public void FillData()
		{
			var data = Services.PolicyManager.GetFormPolicyContact(Service.Corp_Id,
																   Service.Region_Id,
																   Service.Country_Id,
																   Service.Domesticreg_Id,
																   Service.State_Prov_Id,
																   Service.City_Id,
																   Service.Office_Id,
																   Service.Case_Seq_No,
																   Service.Hist_Seq_No,
																   Service.Contact_Id,
																   1,
																   Service.LanguageId);
			gvQuestionnaires.DataSource = data;
			gvQuestionnaires.DataBind();

			setPagerIndex(gvQuestionnaires);

			if (gvQuestionnaires.BottomPagerRow != null)
			{
				var totalItems = (Literal)gvQuestionnaires.BottomPagerRow.FindControl("totalItems");
				totalItems.Text = data.ToList().Count + "";
			}
		}

		public void FillAvocations()
		{
			//Colocado para demostracion
			ddlTypeOfAvocation.DataSource = new string[] { "Select", "Club", "Hobbie", "Professional", "Work" };
			ddlTypeOfAvocation.DataBind();


			//Colocado para demostracion
			var data = new System.Data.DataTable("Avocations");
			data.Columns.Add("TypeOfAvocationId", typeof(Int32));
			data.Columns.Add("TypeOfAvocationDesc", typeof(String));
			data.Columns.Add("YearsOfExperience", typeof(Int32));
			data.Columns.Add("Licence", typeof(String));
			data.Columns.Add("AvocationFactor", typeof(String));
			data.Columns.Add("Detail", typeof(String));

			gvAvocations.DataSource = data;
			gvAvocations.DataBind();

			setPagerIndex(gvAvocations);

			if (gvAvocations.BottomPagerRow != null)
			{
				var totalItems = (Literal)gvAvocations.BottomPagerRow.FindControl("totalItems");
				totalItems.Text = data.Rows.Count + ""; //data.ToList().Count + "";
			}
		}

		protected void gvAvocations_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gvAvocations.PageIndex = e.NewPageIndex;
			gvAvocations.DataBind();
			FillAvocations();
			setPagerIndex(gvAvocations);
		}

		protected void btnFile_Click(object sender, EventArgs e)
		{
			var gridRow = (GridViewRow)((LinkButton)sender).NamingContainer;

			int FormId = int.Parse(gvQuestionnaires.DataKeys[gridRow.RowIndex]["FormId"].ToString());

			FillPdfViewer(FillForm(FormId));
		}

		public void FillPdfViewer(string ViewPDFFile)
		{
			if (File.Exists(ViewPDFFile))
			{
				var pdfViewerControl = (PdfViewer)Page.Master.FindControl("Right").FindControl("Right").FindControl("UCPdfViewer").FindControl("Viewer");
				pdfViewerControl.PdfSourceBytes = Utility.ReadBinaryFile(ViewPDFFile);
				pdfViewerControl.DataBind();
				((HiddenField)Page.Master.FindControl("Right").FindControl("Right").FindControl("hfMenuCasesRight")).Value = "pdfViewer";
			}
		}

		private string FillForm(int FormId)
		{
			string pdfTemplate = Server.MapPath("~/Case/UserControls/FinancialInfo/TemplatePDFS");
			string newFile = "";

			#region Anterior
			//Form.FieldValue.Parameter param = new Form.FieldValue.Parameter();
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

			////param.CorpId = Service.Corp_Id;
			////param.RegionId = Service.Region_Id;
			////param.CountryId = Service.Country_Id;
			////param.DomesticRegId = Service.Domesticreg_Id;
			////param.StateProvId = Service.State_Prov_Id;
			////param.CityId = Service.City_Id;
			////param.OfficeId = Service.Office_Id;
			////param.CaseSeqNo = Service.Case_Seq_No;
			////param.HistSeqNo = Service.Hist_Seq_No;
			////param.ContactId = Service.Contact_Id;
			//param.FormId = FormId;

			////var valores = Services.diManager.FormManager.GetFormFieldValues(param);
			#endregion

			IEnumerable<Form.FieldValue> valores = Services.diManager.FormManager.GetFormFieldValues(new Form.FieldValue.Parameter
			{
				CaseSeqNo = 1,
				CityId = 1,
				ContactId = 356834,
				CorpId = 1,
				CountryId = 14,
				DomesticRegId = 17,
				FormId = FormId,
				HistSeqNo = 1,
				OfficeId = 4,
				RegionId = 2,
				StateProvId = 1
			});

			if (valores != null)
			{
				if (!string.IsNullOrEmpty(valores.FirstOrDefault().PdfTemplatePath))
				{
					pdfTemplate = pdfTemplate + @"\" + valores.FirstOrDefault().PdfTemplatePath;  //CuestionarioHipertensos.pdf";

					newFile = Server.MapPath("~/TempFiles/") + @"\Form" + System.Guid.NewGuid().ToString().Replace("-", "").Substring(0, 15);
					PdfReader pdfReader = new PdfReader(pdfTemplate);
					PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));
					AcroFields pdfFormFields = pdfStamper.AcroFields;

					foreach (var item in valores)
					{
						switch (item.FieldTypeId)
						{
							case 1:
								#region Anterior
								////if (!string.IsNullOrEmpty(pdfFormFields.GetField(item.FieldTitle)))
								////{
								//if (!string.IsNullOrEmpty(item.TextValue))
								//{
								//	pdfFormFields.SetField(item.FieldTitle, item.TextValue);
								//}
								////}
								//else
								//{
								//	pdfFormFields.SetField(item.FieldTitle, "");
								//}
								#endregion

								pdfFormFields.SetField(item.FieldTitle, (!string.IsNullOrWhiteSpace(item.TextValue) ? item.TextValue : string.Empty));
								break;
							case 3:
								#region Anterior

								////if (!string.IsNullOrEmpty(pdfFormFields.GetField(item.FieldTitle)))
								////{
								//if (item.DateValue.HasValue)
								//{
								//	pdfFormFields.SetField(item.FieldTitle, item.DateValue.Value.ToShortDateString());
								//}
								////}
								//else
								//{
								//	pdfFormFields.SetField(item.FieldTitle, "");
								//}
								#endregion

								pdfFormFields.SetField(item.FieldTitle, (item.DateValue.HasValue ? item.DateValue.Value.ToShortDateString() : string.Empty));
								break;

							case 2:
								#region Anterior
								////if (!string.IsNullOrEmpty(pdfFormFields.GetField(item.FieldTitle)))
								////{
								//if (item.FieldValueStatus.HasValue)
								//{
								//	if (item.FieldValueStatus.Value == true)
								//	{
								//		pdfFormFields.SetField(item.FieldTitle, "Yes");
								//	}
								//	else
								//	{
								//		pdfFormFields.SetField(item.FieldTitle, "No");
								//	}
								//}
								////}
								//else
								//{
								//	pdfFormFields.SetField(item.FieldTitle, "No");
								//}
								#endregion

								pdfFormFields.SetField(item.FieldTitle, (item.FieldValueStatus.HasValue ? item.FieldValueStatus.Value == true ? "Yes" : "No" : "No"));
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

		public void Translator(string Lang)
		{
			throw new NotImplementedException();
		}

		public void save()
		{
			throw new NotImplementedException();
		}

		public void clearData()
		{
			throw new NotImplementedException();
		}

		public void readOnly(bool x)
		{
			throw new NotImplementedException();
		}

		public void edit()
		{
			throw new NotImplementedException();
		}
	}
}