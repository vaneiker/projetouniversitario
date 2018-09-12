/// <summary>
/// Author: Lic. Carlos Ml. Lebron
/// Date  : 31/10/2014
/// Componente paginador de GridView  v1.0.0.0
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Common
{
    public partial class WUCGridPaginator : System.Web.UI.UserControl
    {
        #region Variables
        private int TotalRecord
        {
            get
            {
                return int.Parse(hdnTotalRecord.Value);
            }
            set
            {
                hdnTotalRecord.Value = value.ToString();
            }
        }

        private int RecordPerPage
        {
            get
            {
                return int.Parse(hdnRecordPerPage.Value);
            }
            set
            {
                hdnRecordPerPage.Value = value.ToString();
            }
        }

        private int TotalPage
        {
            get
            {
                return int.Parse(hdnTotalPage.Value);
            }
            set
            {
                hdnTotalPage.Value = value.ToString();
            }
        }

        private int CurrentPage
        {
            get
            {
                return int.Parse(hfCurrentPage.Value);
            }
            set
            {
                hfCurrentPage.Value = value.ToString();
            }
        }

        private GridView Grid;  

        private IEnumerable<dynamic> Data
        {
            set
            {
                Session[hdnSessionGridName.Value] = value;
            }
            get
            {
                return Session[hdnSessionGridName.Value] as IEnumerable<dynamic>;
            }
        }

        private IEnumerable<dynamic> DataPage
        {
            set
            {
                Session[string.Concat("Data_" + hdnSessionGridName.Value)] = value;
            }
            get
            {
                return Session[string.Concat("Data_" + hdnSessionGridName.Value)] as IEnumerable<dynamic>;
            }
        }

        #endregion

        #region Public Properties


        #endregion

        #region Classes

        public class ItemPaging
        {
            public GridView Grid { get; set; }
            public int RecordPerPage { get; set; }
        }

        #endregion

        #region Methods

        private bool ExistGrid(string GridName)
        {
            List<string> GridNameList = null;

            bool result = false;

            var hdnMasterGridNameList = this.Page.Master.FindControl("hdnMasterGridNameList");

            if (hdnMasterGridNameList != null)
            {
                GridNameList = ((HiddenField)hdnMasterGridNameList).Value.Split('|').ToList();
            }

            result = GridNameList.Where(x => x == GridName).Any();

            return result;
        }

        /// <summary>
        /// Configuracion inicial
        /// </summary>
        /// <param name="options"></param>
        public void SetConfiguration(ItemPaging options)
        {
            try
            {
                Grid = options.Grid;

                if (!ExistGrid(options.Grid.ClientID))
                {
                    hdnSessionGridName.Value = options.Grid.ClientID;

                    var hdnMasterGridNameList = this.Page.Master.FindControl("hdnMasterGridNameList");

                    if (hdnMasterGridNameList != null)
                        ((HiddenField)hdnMasterGridNameList).Value += hdnSessionGridName.Value + "|";

                    //Guardar la data total
                    Data = (IEnumerable<dynamic>)Grid.DataSource;
                }
                else
                    Data = Session[options.Grid.ClientID] as IEnumerable<dynamic>;


                if (!Data.Any())
                {
                    Grid.DataBind();
                    ltPageInformation.Text = string.Format("Page {0} of {1} ({2} items)", 0, 0, 0);
                    btnNext.CssClass = "next_dis";
                    btnNext.Enabled = false;
                    btnPrior.CssClass = "prev_dis";
                    btnPrior.Enabled = false;
                    btnFirstPage.CssClass = "rewd_dis";
                    btnFirstPage.Enabled = false;
                    btnLastPage.CssClass = "fwrd_dis";
                    btnLastPage.Enabled = false;
                    return;
                }

                RecordPerPage = options.RecordPerPage;

                TotalRecord = Data.Count();
                //Obtengo la cantidad de paginas
                TotalPage = (Data.Count() / options.RecordPerPage) + (Data.Count() % options.RecordPerPage == 0 ? 0 : 1);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "CustomDialogMessage('" + ex.Message + "');", true);
            }

        }

        /// <summary>
        /// Llenar el grid 
        /// </summary>
        /// <param name="Data"></param>
        private void FillData(IEnumerable<dynamic> Data)
        {
            try
            {
                Grid.DataSource = Data;
                Grid.DataBind();
                Grid.RenderTableHeaderOrTableFooterOnGridView();
                ltPageInformation.Text = string.Format("Page {0} of {1} ({2} items)", CurrentPage, TotalPage, TotalRecord);// Page 1 of 2 (4 items) 
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "CustomDialogMessage('" + ex.Message + "');", true);
            }
        }


        public void OrderByData(String OrderByField, String OrderBy = "ASC")
        {
            try
            {
                if (Data != null)
                {
                    if (Data.Any())
                    {
                        var pageIndex = 0;

                        if (CurrentPage > 1)
                            pageIndex = (CurrentPage) * RecordPerPage;                                               

                        if (OrderByField != null)
                        {                               
                            DataPage = (OrderBy == "ASC") ?
                                       EnumerableExtender.OrderBy(Data.Skip(pageIndex).Take(RecordPerPage), OrderByField).ToList() :
                                       EnumerableExtender.OrderByDescending(Data.Skip(pageIndex).Take(RecordPerPage), OrderByField).ToList();
                        }
                        else
                            DataPage = Data.Skip(CurrentPage).Take(RecordPerPage).ToList();

                        FillData(DataPage);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "CustomDialogMessage('" + ex.Message + "');", true);
            }

        }

        private void CalculateDataFromPage(int PageIndex)
        {
            try
            {
                if (Data != null)
                {
                    if (Data.Any())
                    {
                        DataPage = Data.Skip(PageIndex).Take(RecordPerPage).ToList();
                        FillData(DataPage);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "CustomDialogMessage('" + ex.Message + "');", true);
            }
        }

        /// <summary>
        /// Avanza en la lista la cantidad de registros por paginas
        /// </summary>
        public void CalculateDataNextPage()
        {
            try
            {
                if (Data != null)
                {
                    if (Data.Any())
                    {

                        //Validar que si es la ultima pagina no pueda seguir avanzando
                        if (CurrentPage == (TotalPage))
                        {
                            CalculateDataLastPage();
                            return;
                        }

                        int pageIndex = 0;

                        if (CurrentPage >= 1)
                            pageIndex = (CurrentPage) * RecordPerPage;

                        //Obtengo la pagina siguiente
                        CurrentPage++;

                        if (CurrentPage == (TotalPage))
                        {
                            btnNext.CssClass = "next_dis";
                            btnNext.Enabled = false;
                            btnLastPage.CssClass = "fwrd_dis";
                            btnLastPage.Enabled = false;
                            btnPrior.CssClass = "prev";
                            btnPrior.Enabled = true;
                        }
                        else
                        {
                            btnNext.CssClass = "next";
                            btnNext.Enabled = true;
                            btnPrior.CssClass = "prev";
                            btnPrior.Enabled = true;
                            btnFirstPage.CssClass = "rewd";
                            btnFirstPage.Enabled = true;
                            btnLastPage.CssClass = "fwrd";
                            btnLastPage.Enabled = true;
                        }

                        hlkCurrent.CssClass = "numbers";
                        hlkNumber.CssClass = "current";

                        if (CurrentPage > 2)
                        {
                            //Rotar los numeros
                            hlkCurrent.Text = (CurrentPage - 1).ToString();
                            hlkNumber.Text = CurrentPage.ToString();
                        }

                        CalculateDataFromPage(pageIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "CustomDialogMessage('" + ex.Message + "');", true);
            }

        }

        /// <summary>
        /// Retrocede en la lista la cantidad de regisros por pagina
        /// </summary>
        public void CalculateDataPriorPage()
        {
            try
            {
                if (Data != null)
                {
                    if (Data.Any())
                    {
                        //Obtengo la pagina siguiente
                        CurrentPage--;

                        //Validar que si es la ultima pagina no pueda seguir avanzando
                        if (CurrentPage <= 1)
                        {
                            CalculateDataFirstPage();
                            return;
                        }

                        int pageIndex = 0;


                        if (CurrentPage <= TotalPage)
                            pageIndex = (CurrentPage - 1) * RecordPerPage;

                        if (CurrentPage <= 1)
                        {
                            btnNext.CssClass = "next";
                            btnNext.Enabled = true;
                            btnPrior.CssClass = "prev_dis";
                            btnPrior.Enabled = false;
                            btnFirstPage.CssClass = "fwrd_dis";
                            btnFirstPage.Enabled = false;
                        }
                        else
                        {
                            btnNext.CssClass = "next";
                            btnNext.Enabled = true;
                            btnPrior.CssClass = "prev";
                            btnPrior.Enabled = true;
                            btnLastPage.CssClass = "fwrd";
                            btnLastPage.Enabled = true;
                        }

                        hlkCurrent.CssClass = "numbers";
                        hlkNumber.CssClass = "current";

                        //Rotar los numeros
                        hlkCurrent.Text = (CurrentPage - 1).ToString();
                        hlkNumber.Text = CurrentPage.ToString();

                        CalculateDataFromPage(pageIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "CustomDialogMessage('" + ex.Message + "');", true);
            }
        }

        /// <summary>
        ///  Ir la primera pagina
        /// </summary>
        public void CalculateDataFirstPage()
        {
            try
            {
                if (Data != null)
                {
                    if (Data.Any())
                    {
                        if (TotalPage == 1)
                        {
                            btnNext.CssClass = "next_dis";
                            btnNext.Enabled = false;
                            btnPrior.CssClass = "prev_dis";
                            btnPrior.Enabled = false;
                            ltPageInformation.Text = string.Format("Page {0} of {1} ({2} items)", CurrentPage, TotalPage, TotalRecord);// Page 1 of 2 (4 items) 
                            return;
                        }

                        CurrentPage = 1;
                        int pageIndex = (CurrentPage - 1) * RecordPerPage;                        
                        DataPage = Data.Skip(pageIndex).Take(RecordPerPage).ToList();
                        btnPrior.CssClass = "prev_dis";
                        btnPrior.Enabled = false;
                        btnFirstPage.CssClass = "rewd_dis";
                        btnFirstPage.Enabled = false;
                        btnNext.CssClass = "next";
                        btnNext.Enabled = true;
                        btnLastPage.CssClass = "fwrd";
                        btnLastPage.Enabled = true;

                        hlkCurrent.CssClass = "current";
                        hlkNumber.CssClass = "numbers";

                        //Rotar los numeros
                        hlkCurrent.Text = CurrentPage.ToString();
                        hlkNumber.Text = "2";
                        FillData(DataPage);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "CustomDialogMessage('" + ex.Message + "');", true);
            }
        }

        /// <summary>
        ///  Ir al la ultima pagina
        /// </summary>
        public void CalculateDataLastPage()
        {
            try
            {
                if (Data != null)
                {
                    if (Data.Any())
                    {
                        CurrentPage = TotalPage;
                        int pageIndex = (CurrentPage - 1) * RecordPerPage;
                        DataPage = Data.Skip(pageIndex).Take(RecordPerPage).ToList();
                        btnPrior.CssClass = "prev";
                        btnPrior.Enabled = true;
                        btnNext.CssClass = "next_dis";
                        btnNext.Enabled = false;
                        btnFirstPage.CssClass = "rewd";
                        btnFirstPage.Enabled = true;
                        btnLastPage.CssClass = "fwrd_dis";
                        btnLastPage.Enabled = false;

                        hlkCurrent.CssClass = "numbers";
                        hlkNumber.CssClass = "current";

                        //Rotar los numeros
                        hlkCurrent.Text = (CurrentPage - 1).ToString();
                        hlkNumber.Text = CurrentPage.ToString();

                        FillData(DataPage);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "CustomDialogMessage('" + ex.Message + "');", true);
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            CalculateDataNextPage();
        }

        protected void btnPrior_Click(object sender, EventArgs e)
        {
            CalculateDataPriorPage();
        }

        protected void btnFirstPage_Click(object sender, EventArgs e)
        {
            CalculateDataFirstPage();
        }

        protected void btnLastPage_Click(object sender, EventArgs e)
        {
            CalculateDataLastPage();
        }

        protected void hlkNumber_Click(object sender, EventArgs e)
        {
            try
            {
                //Ir a la pagina en especifico
                CurrentPage = int.Parse(((LinkButton)sender).Text);
                CalculateDataFromPage(CurrentPage);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "CustomDialogMessage('" + ex.Message + "');", true);
            }

        }
    }
}