using DevExpress.Data.Linq.Helpers;
using DevExpress.Web;
using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.Common
{
	public partial class UCCasesGrid : UC, IUC
	{
		string KeyPolicy
		{
			get { return hdnGridKey.Value; }
			set { hdnGridKey.Value = value; }
		}

		Boolean FilterByIndexChanged
		{
			get { return Boolean.Parse(hdnFilterByIndexChanged.Value); }
			set { hdnFilterByIndexChanged.Value = value.ToString(); }
		}

		public delegate void SelectGridRows();

		public event SelectGridRows SelectGridRow;

		protected void Page_Load(object sender, EventArgs e)
		{
            
		}

		public void Translator(string Lang)
		{
			throw new NotImplementedException();
		}

		public void save()
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

		public void FillData()
		{
			gvCases.FilterExpression = String.Empty;
			var fillData = true;
			switch (Service.TabName)
			{
				case "AllOpen":
					Dictionary<string, int> DictionaryAllOpen = new Dictionary<string, int>() 
                    {
                        {"Product Family", 0},
                        {"Illustration", 1},
                        {"Insured Name", 2},
                        {"Illustration Status", 3},
                        {"Plan Name", 4},
                        {"Series", 5},
                        {"Benefit Amount", 6},
                        {"Country", 7},
                        {"Office", 8},
                        {"Submitted Date", 9},
                        {"Assigned to", 10},
                        {"Company", 11},
                        {"Priority", 12}
                    };
					SetGridColumns(DictionaryAllOpen);

					break;
				case "Processing":
					var dictionaryProcessing = new Dictionary<string, int>()
                    {
                        {"Product Family", 0},
                        {"Illustration", 1},
                        {"Insured Name", 2},
                        {"Illustration Status", 3},
                        {"Step", 4},
                        {"Plan Name", 5},
                        {"Series", 6},
                        {"Benefit Amount", 7},
                        {"Agent Name", 8},
                        {"Office", 9},
                        {"Days",10},
                        {"Assigned to", 11},
                        {"Company", 12},
                        {"Priority", 13}
                    };
					SetGridColumns(dictionaryProcessing);
					break;
				case "AwaitingInfo":
					var dictionaryAwaitingInfo = new Dictionary<string, int>()
                    {
                        {"Product Family", 0},
                        {"Illustration", 1},
                        {"Insured Name", 2},
                        {"Illustration Status", 3},
                        {"Plan Name", 4},
                        {"Series", 5},
                        {"Benefit Amount", 6},
                        {"Agent Name", 7},
                        {"Office", 8},
                        {"Submitted Date",9},
                        {"Step in Awaiting",10},
                        {"Time in Awaiting", 11},
                        {"Assigned to", 12},
                        {"Company", 13}
                    };
					SetGridColumns(dictionaryAwaitingInfo);
					break;
				case "Reinsurance":
					var dictionaryReinsurance = new Dictionary<string, int>()
                    {
                        {"Product Family", 0},    
                        {"Illustration", 1},
                        {"Insured Name", 2},
                        {"Illustration Status", 3},
                        {"Plan Name", 4},
                        {"Series", 5},
                        {"Riders", 6},
                        {"Benefit Amount", 7},
                        {"Reinsured Amount", 8},
                        {"Reinsurer", 9},
                        {"Date Sent To Reinsurance", 10},
                        {"Time In Reinsurance", 11},
                        {"Office", 12},
                        {"Assigned to", 13},
                        {"Company", 14}
                    };
					SetGridColumns(dictionaryReinsurance);
					break;

				case "Alerts":
					var dictionaryAlerts = new Dictionary<string, int>()
                    {
                        {"Product Family", 0},    
                        {"Illustration", 1},
                        {"Insured Name", 2},
                        {"Illustration Status", 3},
                        {"Plan Name", 4},
                        {"Series", 5},
                        {"Benefit Amount", 6},
                        {"Agent Name", 7},
                        {"Office", 8},
                        {"Riders", 9},
                        {"Assigned to", 10},
                        {"User Audit Trail",11},
                        {"Company", 12}
                    };
					SetGridColumns(dictionaryAlerts);
					break;

				case "ShowExceptions":
					var dictionaryShowExceptions = new Dictionary<string, int>()
                    {
                        {"Product Family", 0}, 
                        {"Illustration", 1},
                        {"Agent Name",2},
                        {"Insured Name", 3},
                        {"Plan Name", 4},
                        {"Series", 5},
                        {"Illustration Status",6},
                        {"Benefit Amount", 7},
                        {"Office", 8},
                        {"Type of Exception",9},
                        {"Submitted Date", 10},
                        {"Effective Date",11},
                        {"Assigned to", 12}
                    };
					SetGridColumns(dictionaryShowExceptions);
					break;

				case "Recent":
					var dictionaryRecent = new Dictionary<string, int>()
                    {
                        {"Product Family", 0}, 
                    {"Illustration", 1},
                    {"Insured Name", 2},
                    {"Illustration Status",3},
                    {"Plan Name", 4},
                    {"Series", 5},
                    {"Benefit Amount", 6},
                    {"Agent Name",7},
                    {"Reinsured Amount", 8},
                    {"Submitted Date", 9},
                    {"User Audit Trail",10},
                    {"Assigned to", 11},
                    {"Company", 12}
                    };
					SetGridColumns(dictionaryRecent);
					break;


				case "Changes":
					var dictionaryChanges = new Dictionary<string, int>()
                    {
                        {"Product Family", 0}, 
                        {"Illustration", 1},
                        {"Insured Name", 2},
                        {"Illustration Status", 3},
                        {"Plan Name", 4},
                        {"Series", 5},
                        {"Benefit Amount", 6},
                        {"Effective Date", 7},
                        {"Requested Date", 8},
                        {"Requested By", 9},
                        {"Change Type", 10},
                        {"Change Step", 11},
                        {"Company", 12}
                    };
					SetGridColumns(dictionaryChanges);
					break;


				case "SearchResults":
					var dictionarySearchResults = new Dictionary<string, int>()
                    {
                        {"Product Family", 0}, 
                        {"Illustration", 1},
                        {"Insured Name", 2},
                        {"Illustration Status", 3},
                        {"Plan Name", 4},
                        {"Series", 5},
                        {"Benefit Amount", 6},
                        {"Agent Name", 7},
                        {"Office", 8},
                        {"Submitted Date", 9},
                        {"Effective Date", 10},
                        {"Assigned to", 11},
                        {"Company", 12}
                    };
					SetGridColumns(dictionarySearchResults);
					break;

                case "History":
                    var dictionaryHistoryResults = new Dictionary<string, int>()
                    {
                        {"Product Family", 0},
                        {"Illustration", 1},
                        {"Insured Name", 2},
                        {"Illustration Status", 3},
                        {"Plan Name", 4},
                        {"Series", 5},
                        {"Benefit Amount", 6},
                        {"Country", 7},
                        {"Office", 8},
                        {"Submitted Date", 9},
                        {"Assigned to", 10},
                        {"Company", 11},
                        {"Priority", 12},
                        {"Illustration No", 40}
                    };
                    SetGridColumns(dictionaryHistoryResults, Service.TabName);
                    break;
                //MAVELAR 3/10/2017
                case "Rejected":
                    var dictionaryRejectedCases = new Dictionary<string, int>()
                    {
                        {"Product Family", 0},
                        {"Illustration", 1},
                        {"Insured Name", 2},
                        {"Policy Status", 3},
                        {"Plan Name", 4},
                        {"Series", 5},
                        {"Benefit Amount", 6},
                        {"Country", 7},
                        {"Office", 8},
                        {"Submitted Date", 9},
                        {"Assigned to", 10},
                        {"Company", 11},
                        {"Priority", 12}
                    };
                    SetGridColumns(dictionaryRejectedCases);
                    break;
                //FIN MAVELAR 3/10/2017

				default:
					fillData = false;
					break;
			}

            //wcastro 02-05-2017
            hdTabName.Value = Service.TabName;
            //fin wcastro 02-05-2017

			if (!fillData) return;
			KeyPolicy = "";
			FilterByIndexChanged = false;

			gvCases.DataBind();
		}

		protected void LinqServerModeDataSource_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
		{
			var pnlGrid = (Panel)Parent.FindControl("dvGridAllOpen");

			e.KeyExpression = "PolicyNo";

			//To Show Filters
			gvCases.Settings.ShowFilterRow = !FilterByIndexChanged;
			gvCases.Settings.ShowHeaderFilterButton = !FilterByIndexChanged;

			var policyKey = new Policy.Parameter
			{
				CorpId = Service.Corp_Id,
				RegionId = Service.Region_Id,
				CountryId = Service.Country_Id,
				DomesticregId = Service.Domesticreg_Id,
				StateProvId = Service.State_Prov_Id,
				CityId = Service.City_Id,
				OfficeId = Service.Office_Id,
				CaseSeqNo = Service.Case_Seq_No,
				HistSeqNo = Service.Hist_Seq_No,
				UnderwriterId = Service.Underwriter_Id
			};

			switch (Service.TabName)
			{
				case "SearchResults":

                    //Bmarroquin 04-03-2017 mejora para que no truene cuando no hay data que cargar en el grid principal del modulo
                    var lObj_Queryable2 = Services.CaseManager.GetAllSearchResult(Service.SearchResultParameters);
                    var caseSearchResult = lObj_Queryable2.Any() == true ? lObj_Queryable2.AsQueryable() : null; // Services.CaseManager.GetAllSearchResult(Service.SearchResultParameters).AsQueryable();
                    e.QueryableSource = caseSearchResult != null ?( FilterByIndexChanged ? caseSearchResult.Where(r => r.PolicyNo == KeyPolicy) : caseSearchResult) : null;
                    //Fin cambio Bmarroquin 04-03-2017

                    var searchResultCountText = (System.Web.UI.HtmlControls.HtmlGenericControl)Parent.FindControl("SearchResultCountText");

					if (searchResultCountText != null)
						searchResultCountText.InnerText = caseSearchResult.ToList().Count().ToString();
					break;
                //ROJAS : CASE TO HANDLE CHANGES TAB
             /*   case "Changes":
                    var changes = Services.CaseManager.GetAllChange(Service.CompanyId, Service.Underwriter_Id).AsQueryable();
                    e.QueryableSource = FilterByIndexChanged ? changes.Where(r => r.PolicyNo == KeyPolicy) : changes;
                    break;  */
              /* case "History":
                    //Here there will be a Service calling all policies that are efective*/
 
				default:                  
                    //Bmarroquin 30-01-2017 cambio a raiz de la tropicalizacion en ESA
                    //Antes: e.QueryableSource = FilterByIndexChanged ? Services.CaseManager.GetAllByType(Service.TabName, policyKey).AsQueryable() : Services.CaseManager.GetAllByType(Service.TabName, Service.CompanyId, Service.Underwriter_Id).AsQueryable();
                    var lObj_Queryable = FilterByIndexChanged ? Services.CaseManager.GetAllByType(Service.TabName, policyKey) : Services.CaseManager.GetAllByType(Service.TabName, Service.CompanyId, Service.Underwriter_Id);

                    //e.QueryableSource = lObj_Queryable.Any() == true ? lObj_Queryable.AsQueryable() : null;

                    //By wcastro
                    if (lObj_Queryable != null)
                    {
                        e.QueryableSource = lObj_Queryable.AsQueryable();
                    }
                    else
                    {
                        //Creando objeto vacio de la clase para pasarsela al source del grid y que no genere error
                        IQueryable objIQueryable = Enumerable.Empty<Entity.UnderWriting.Entities.Case>().AsQueryable();

                        e.QueryableSource = objIQueryable;//Pasamos objeto vacio
                    }

                    //Fin cambio Bmarroquin 30-01-2017

                    break;
			}

			gvCases.SettingsPager.Visible = (e.QueryableSource != null && e.QueryableSource.Count() > 1);

			if (FilterByIndexChanged)
			{
				hdnVisiblePanels.Value = "true";
				pnlGrid.CssClass = "wd100 fl mB registerCase";
			}
			else
			{
				hdnVisiblePanels.Value = "false";
				pnlGrid.CssClass = "wd100 fl all_open";
				gvCases.FocusedRowIndex = -1;
			}
		}

		private void SetGridColumns(Dictionary<string, int> TabColumns)
		{
			for (var i = 0; i < gvCases.Columns.Count; i++)
			{
                if (gvCases.Columns[i].Caption.Contains("Policy"))
                    gvCases.Columns[i].Caption = gvCases.Columns[i].Caption.Replace("Policy", "Illustration");
                if (TabColumns.Keys.Contains(gvCases.Columns[i].Caption.Replace("Policy", "Illustration")))
				{
					gvCases.Columns[i].Visible = true;
					gvCases.Columns[i].VisibleIndex = Convert.ToInt32(TabColumns.Where(x => x.Key == gvCases.Columns[i].Caption).Select(f => f.Value).First());
				}
				else
					gvCases.Columns[i].Visible = false;
			}
		}

        private void SetGridColumns(Dictionary<string, int> TabColumns, string Tab)
        {
            for (var i = 0; i < gvCases.Columns.Count; i++)
            {
                if (gvCases.Columns[i].Caption.Contains("Policy"))
                    gvCases.Columns[i].Caption = gvCases.Columns[i].Caption.Replace("Policy", "Illustration");
                if (TabColumns.Keys.Contains(gvCases.Columns[i].Caption))
                {
                    gvCases.Columns[i].Visible = true;
                    gvCases.Columns[i].VisibleIndex = Convert.ToInt32(TabColumns.Where(x => x.Key == gvCases.Columns[i].Caption).Select(f => f.Value).First());
                    if (Tab == "History" && gvCases.Columns[i].Caption.Contains("Illustration") && gvCases.Columns[i].Caption != ("Illustration No"))
                        gvCases.Columns[i].Caption = gvCases.Columns[i].Caption.Replace("Illustration", "Policy");
                }
                else
                    gvCases.Columns[i].Visible = false;
            }
        }

        public void clearData()
		{
			throw new NotImplementedException();
		}

		public bool IsVisible()
		{
			return Boolean.Parse(!String.IsNullOrWhiteSpace(hdnVisiblePanels.Value) ? hdnVisiblePanels.Value : "false");
		}

		protected void gvCases_OnAutoFilterCellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			if (e.Column.FieldName != "Priority") return;
			if (!(e.Editor is ASPxComboBox)) return;
			((ASPxComboBox)e.Editor).Items.Clear();
			((ASPxComboBox)e.Editor).Items.Add("All", "");
			((ASPxComboBox)e.Editor).Items.Add("Checked", true);
			((ASPxComboBox)e.Editor).Items.Add("Unchecked", false);
		}

		protected void btnSelectedRow_OnClick(object sender, EventArgs e)
		{
			var values = hdnSelectedKey.Value.Split('|');
			if (!values.Any()) return;
			if (values.Count() < 10) return;
			Service.Corp_Id = Convert.ToInt32(values[0]);
			Service.Region_Id = Convert.ToInt32(values[1]);
			Service.Country_Id = Convert.ToInt32(values[2]);
			Service.Domesticreg_Id = Convert.ToInt32(values[3]);
			Service.State_Prov_Id = Convert.ToInt32(values[4]);
			Service.City_Id = Convert.ToInt32(values[5]);
			Service.Office_Id = Convert.ToInt32(values[6]);
			Service.Case_Seq_No = Convert.ToInt32(values[7]);
			Service.Hist_Seq_No = Convert.ToInt32(values[8]);
			Service.Policy_Id = values[9];
			Service.Contact_Id = Convert.ToInt32(values[10]);
			Service.Directory_Id = 0;
			Service.RoleTypeId = 2;
			Service.OwnerIsInsured = Convert.ToBoolean(values[11]);
			Service.AddInsuredContactId = String.IsNullOrWhiteSpace(values[12]) ? (int?)null : Convert.ToInt32(values[12]);

			//Policy Duration
            //TO DO: CONTROLLAR EXCEPCION EN ESTA LINEA ==> Service.SubmitDate = String.IsNullOrWhiteSpace(values[15]) ? (DateTime?)null : Convert.ToDateTime(values[15]);
			Service.InsuredPeriod = String.IsNullOrEmpty(values[13]) ? 0 : Convert.ToInt32(values[13]);
			hdnInsuredPeriod.Value = Service.InsuredPeriod.Value.ToString();
			//Enum Type
			Tools.ProductBehavior enumProduct;
			var parseResult = Enum.TryParse(values[14].Replace(" ", ""), true, out enumProduct);
			Service.ProductDesc = parseResult ? enumProduct : Tools.ProductBehavior.None;
			hdnProductFamily.Value = Service.GetProductFamily().ToString();

			//Para Filtrar por el numero de Poliza Seleccionada
			KeyPolicy = values[9];
			FilterByIndexChanged = true;
			///////////////////////////////////////////////////

			//Fill Summary Data
			if (Page.Master != null)
			{
				var left = Page.Master.FindControl("Left").FindControl("Left") as Left;
				if (left != null) left.FillSummaryDdl();
			}

			if (SelectGridRow != null) SelectGridRow();
			gvCases.DataBind();

            //wcastro 02-05-2017
            if (hdTabName.Value.ToLower().Equals("allopen") || hdTabName.Value.ToLower().Equals("processing") || hdTabName.Value.ToLower().Equals(""))
            {
                var objCalulate = new wsReinsurance.CalculateClient();
                wsReinsurance.ReinsuranceWarning resultWs = objCalulate.CheckForWarning(Convert.ToString(values[14]), Convert.ToDecimal(values[16]), 0, null);
                //wsReinsurance.ReinsuranceWarning resultWs = objCalulate.CheckForWarning(Convert.ToString(values[14]), Convert.ToDecimal("1000000.01"), 0, null);

                if (resultWs != null)
                {
                    if (resultWs.ExceedsContract)
                    {
                        hdFacultativeAmount.Value = Convert.ToString(resultWs.FacultativeAmount);

                        //((HiddenField)(Page.Master.FindControl("Right").FindControl("Right").FindControl("UCPopSentToReinsurance1").FindControl("hdFacultativeAmount"))).Value = Convert.ToString(resultWs.FacultativeAmount);

                        //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "CustomDialogMessageEx('" + Convert.ToString(resultWs.Warning) + "', 500, 150, true, '"+ RESOURCE.UnderWriting.Underwriting.Resources.Warning + "');", true);
                        //return;

                        //wcastro 14-05-2017
                        var stepReinsurance = (WEB.UnderWriting.Case.UserControls.Common.UCPopSentToReinsurance)Page.Master.FindControl("Right").FindControl("Right").FindControl("UCPopSentToReinsurance1");

                        if (String.IsNullOrEmpty(Service.TabName) || Service.TabName.ToLower().Equals("processing") || Service.TabName.ToLower().Equals("allopen"))//Solo si esta en proceso o en allopen
                        {
                            stepReinsurance.createNewStepReInsurance();

                            ((HiddenField)(Page.Master.FindControl("Right").FindControl("Right").FindControl("UCPopSentToReinsurance1").FindControl("hdFacultativeAmount"))).Value = Convert.ToString(resultWs.FacultativeAmount);

                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "CustomDialogMessageEx('" + Convert.ToString(resultWs.Warning) + "', 500, 150, true, '" + RESOURCE.UnderWriting.Underwriting.Resources.Warning + "');", true);

                            ((Right)Page.Master.FindControl("Right").FindControl("Right")).SendToReinsuranceAutomatically();

                            return;
                        }
                        //fin wcastro 14-05-2017

                    }
                }
            }
            //fin wcastro
        }

		protected void gvCases_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
		{
			if (e.DataColumn.FieldName == "ProductTypeDesc") { e.Cell.CssClass = "dxgv left"; }
		}
	}
}
