using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using System.Data;
using WSVirtualOffice.Models.blinsurance;
using WSVirtualOffice.Models.businesslogic;
namespace WSVirtualOffice.Models.wsdata
{
    public class WSReport
    {
        public static char ruleclasscode = ' ';
        public static string reportType = "long";
        public static String formfilename = "Report";
        public static Boolean classicmode = false;
        public static Boolean customize = false;
        public static string PlanName;
        public static string PlanCode;
        public static ReportViewer rpt;
        public static DataTable dt;
        public static DataTable dttwo;
        private static WSVirtualOffice.Settings productsProperties { get; set; }

        public WSReport()
        {
            productsProperties = (WSVirtualOffice.Settings)System.Configuration.ConfigurationManager.GetSection("QuoteSettings/ReturnOfPremium");
        }
        public static void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            rpt.LocalReport.Refresh();
            rpt.Reset();
            if (PlanCode.Equals("LEG") || PlanCode.Equals("COM") || PlanCode.Equals("CPI") || PlanCode.Equals("LGT") || PlanCode.Equals("SNT") ||
                PlanCode.Equals("ORN") || PlanCode.Equals("ORP") || PlanCode.Equals("GRD") || PlanCode.Equals("GRP") ||
                PlanCode.Equals("LUM") || PlanCode.Equals("LUV") || PlanCode.Equals("EXE") || PlanCode.Equals("EXV"))
            {
                List<rpt_Legacy_10_principle> rpt_Legacy_10_principle = (from item in newdb.rpt_Legacy_10_principles
                                                                         where item.Type == "Paisesde_Bajos"
                                                                         select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_Legacy_10_principles", rpt_Legacy_10_principle));
                List<rpt_Legacy_10_principle> rpt_Legacy_10_principle1 = (from item in newdb.rpt_Legacy_10_principles
                                                                          where item.Type == "Paisesde_Altos"
                                                                          select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_Legacy_10_principles1", rpt_Legacy_10_principle1));




                List<egr_age> egr_age = (from item in newdb.egr_ages select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_egr_age", egr_age));
                List<rpt_investments_inflacion> rpt_investment = (from item in newdb.rpt_investments_inflacions
                                                                  select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_investments_inflacion", rpt_investment));
                List<rpt_Axys_slide11> rpt_Axys_slide11 = (from item in newdb.rpt_Axys_slide11s
                                                           select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_Axys_slide11", rpt_Axys_slide11));
                ReportDataSource rds = new ReportDataSource();


                DataTable dtNew = new DataTable();
                //dtNew = Sessionclass.getSessiondata(Session).dt.Copy();
                dtNew = dt.Clone();
                int rowcounter = 1;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (rowcounter < 5)
                    {
                        rowcounter++;
                    }
                    else
                    {
                        //DataRow rw = dt.Rows[i];
                        //dtNew.ImportRow(rw);
                        dtNew.Rows.Add(dt.Rows[i].ItemArray);
                        rowcounter = 1;
                    }
                }

                dtNew.AcceptChanges();

                rds.Value = dtNew;
                e.DataSources.Add(new ReportDataSource("illustratorDataSet_illusdet", dtNew));
            }
            if (PlanCode.Equals("LEG"))
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/LegacyTwo.rdlc");
            else if (PlanCode.Equals("COM"))
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/CompassTwo.rdlc");
            else if (PlanCode.Equals("CPI"))
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/CompassIndex_Two.rdlc");
            else if (PlanCode.Equals("LGT"))
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/LightHouseTwo.rdlc");
            else if (PlanCode.Equals("SNT"))
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/SentinelTwo.rdlc");
            else if (PlanCode.Equals("ORN"))
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/OrionTwo.rdlc");
            else if (PlanCode.Equals("ORP"))
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/OrionPlusTwo.rdlc");
            else if (PlanCode.Equals("GRD"))
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/GuardianTwo.rdlc");
            else if (PlanCode.Equals("GRP"))
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/GuardianPlusTwo.rdlc");
            else if (PlanCode.Equals("LUM"))
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/LuminisBasicoTwo.rdlc");
            else if (PlanCode.Equals("LUV"))
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/LuminisVIPTwo.rdlc");
            else if (PlanCode.Equals("EXE"))
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/ExequiumBasicoTwo.rdlc");
            else if (PlanCode.Equals("EXV"))
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/ExequiumVIPTwo.rdlc");
            else if (PlanCode.Equals("EDU"))
            {
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/EduplanTwo.rdlc");

                List<egr_slide8> egr_slide8 = (from item in newdb.egr_slide8s
                                               select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_egr_slide8", egr_slide8));

                List<egr_slide9> egr_slide9 = (from item in newdb.egr_slide9s
                                               select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_egr_slide9", egr_slide9));
                List<egr_slide10> egr_slide10 = (from item in newdb.egr_slide10s
                                                 select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_egr_slide10", egr_slide10));
                List<egr_age> egr_age = (from item in newdb.egr_ages select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_egr_age", egr_age));
                List<rpt_investments_inflacion> rpt_investment = (from item in newdb.rpt_investments_inflacions
                                                                  select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_investments_inflacion", rpt_investment));
                List<rpt_Axys_slide11> rpt_Axys_slide11 = (from item in newdb.rpt_Axys_slide11s
                                                           select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_Axys_slide11", rpt_Axys_slide11));
                ReportDataSource rds = new ReportDataSource();


                DataTable dtNew = new DataTable();
                //dtNew = dt.Copy();
                dtNew = dt.Clone();
                int rowcounter = 1;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (rowcounter < 5)
                    {
                        rowcounter++;
                    }
                    else
                    {
                        //DataRow rw = dt.Rows[i];
                        //dtNew.ImportRow(rw);
                        dtNew.Rows.Add(dt.Rows[i].ItemArray);
                        rowcounter = 1;
                    }
                }

                dtNew.AcceptChanges();

                rds.Value = dtNew;
                e.DataSources.Add(new ReportDataSource("illustratorDataSet_illushorizon", dtNew));
            }
            else if (PlanCode.Equals("EGR"))
            {
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/EduplanGrowthTwo.rdlc");
                List<egr_slide8> egr_slide8 = (from item in newdb.egr_slide8s
                                               select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_egr_slide8", egr_slide8));

                List<egr_slide9> egr_slide9 = (from item in newdb.egr_slide9s
                                               select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_egr_slide9", egr_slide9));
                List<egr_slide10> egr_slide10 = (from item in newdb.egr_slide10s
                                                 select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_egr_slide10", egr_slide10));
                List<egr_age> egr_age = (from item in newdb.egr_ages select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_egr_age", egr_age));
                List<rpt_investments_inflacion> rpt_investment = (from item in newdb.rpt_investments_inflacions
                                                                  select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_investments_inflacion", rpt_investment));
                List<rpt_Axys_slide11> rpt_Axys_slide11 = (from item in newdb.rpt_Axys_slide11s
                                                           select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_Axys_slide11", rpt_Axys_slide11));
                ReportDataSource rds = new ReportDataSource();


                DataTable dtNew = new DataTable();
                //dtNew = dt.Copy();
                dtNew = dt.Clone();
                int rowcounter = 1;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (rowcounter < 5)
                    {
                        rowcounter++;
                    }
                    else
                    {
                        //DataRow rw = dt.Rows[i];
                        //dtNew.ImportRow(rw);
                        dtNew.Rows.Add(dt.Rows[i].ItemArray);
                        rowcounter = 1;
                    }
                }

                dtNew.AcceptChanges();

                rds.Value = dtNew;
                e.DataSources.Add(new ReportDataSource("illustratorDataSet_illushorizon", dtNew));
            }
            else if (PlanCode.Equals("SCH"))
            {
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/ScholarTwo.rdlc");
                List<egr_slide8> egr_slide8 = (from item in newdb.egr_slide8s
                                               select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_egr_slide8", egr_slide8));

                List<egr_slide9> egr_slide9 = (from item in newdb.egr_slide9s
                                               select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_egr_slide9", egr_slide9));
                List<egr_slide10> egr_slide10 = (from item in newdb.egr_slide10s
                                                 select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_egr_slide10", egr_slide10));
                List<egr_age> egr_age = (from item in newdb.egr_ages select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_egr_age", egr_age));
                List<rpt_investments_inflacion> rpt_investment = (from item in newdb.rpt_investments_inflacions
                                                                  select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_investments_inflacion", rpt_investment));
                List<rpt_Axys_slide11> rpt_Axys_slide11 = (from item in newdb.rpt_Axys_slide11s
                                                           select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_Axys_slide11", rpt_Axys_slide11));
                ReportDataSource rds = new ReportDataSource();


                DataTable dtNew = new DataTable();
                //dtNew = dt.Copy();
                dtNew = dt.Clone();
                int rowcounter = 1;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (rowcounter < 5)
                    {
                        rowcounter++;
                    }
                    else
                    {
                        //DataRow rw = dt.Rows[i];
                        //dtNew.ImportRow(rw);
                        dtNew.Rows.Add(dt.Rows[i].ItemArray);
                        rowcounter = 1;
                    }
                }

                dtNew.AcceptChanges();

                rds.Value = dtNew;
                e.DataSources.Add(new ReportDataSource("illustratorDataSet_illushorizon", dtNew));
            }
            else if (PlanCode.Equals("AXS"))
            {
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/AxysTwo.rdlc");

                List<egr_age> egr_age = (from item in newdb.egr_ages select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_egr_age", egr_age));

                List<rpt_investments_inflacion> rpt_investment = (from item in newdb.rpt_investments_inflacions
                                                                  select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_investments_inflacion", rpt_investment));
                List<rpt_Axys_slide11> rpt_Axys_slide11 = (from item in newdb.rpt_Axys_slide11s
                                                           select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_Axys_slide11", rpt_Axys_slide11));
                List<rpt_axys_slide5> rpt_axys_slide5 = (from item in newdb.rpt_axys_slide5s
                                                         select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_axys_slide5", rpt_axys_slide5));
                List<rpt_axys_slide6> rpt_axys_slide6 = (from item in newdb.rpt_axys_slide6s
                                                         select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_axys_slide6", rpt_axys_slide6));
                List<rpt_axys_slide8> rpt_axys_slide8 = (from item in newdb.rpt_axys_slide8s
                                                         select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_axys_slide8", rpt_axys_slide8));
                ReportDataSource rds = new ReportDataSource();
                DataTable dtNew = new DataTable();
                //dtNew = dt.Copy();
                dtNew = dt.Clone();
                int rowcounter = 1;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (rowcounter < 5)
                    {
                        rowcounter++;
                    }
                    else
                    {
                        //DataRow rw = dt.Rows[i];
                        //dtNew.ImportRow(rw);
                        dtNew.Rows.Add(dt.Rows[i].ItemArray);
                        rowcounter = 1;
                    }
                }

                dtNew.AcceptChanges();

                rds.Value = dtNew;
                e.DataSources.Add(new ReportDataSource("illustratorDataSet_illushorizon", dtNew));
            }
            else if (PlanCode.Equals("HRZ"))
            {
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/HorizonTwo.rdlc");

                List<egr_age> egr_age = (from item in newdb.egr_ages select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_egr_age", egr_age));

                List<rpt_investments_inflacion> rpt_investment = (from item in newdb.rpt_investments_inflacions
                                                                  select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_investments_inflacion", rpt_investment));
                List<rpt_Axys_slide11> rpt_Axys_slide11 = (from item in newdb.rpt_Axys_slide11s
                                                           select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_Axys_slide11", rpt_Axys_slide11));

                List<rpt_axys_slide5> rpt_axys_slide5 = (from item in newdb.rpt_axys_slide5s
                                                         select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_axys_slide5", rpt_axys_slide5));
                List<rpt_axys_slide6> rpt_axys_slide6 = (from item in newdb.rpt_axys_slide6s
                                                         select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_axys_slide6", rpt_axys_slide6));
                List<rpt_axys_slide8> rpt_axys_slide8 = (from item in newdb.rpt_axys_slide8s
                                                         select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_axys_slide8", rpt_axys_slide8));







                ReportDataSource rds = new ReportDataSource();
                DataTable dtNew = new DataTable();
                //dtNew = dt.Copy();
                dtNew = dt.Clone();
                int rowcounter = 1;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (rowcounter < 5)
                    {
                        rowcounter++;
                    }
                    else
                    {
                        //DataRow rw = dt.Rows[i];
                        //dtNew.ImportRow(rw);
                        dtNew.Rows.Add(dt.Rows[i].ItemArray);
                        rowcounter = 1;
                    }
                }

                dtNew.AcceptChanges();

                rds.Value = dtNew;
                e.DataSources.Add(new ReportDataSource("illustratorDataSet_illushorizon", dtNew));
            }
            else if (PlanCode.Equals("HGR"))
            {
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/HorizonGrowthTwo.rdlc");

                List<egr_age> egr_age = (from item in newdb.egr_ages select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_egr_age", egr_age));

                List<rpt_investments_inflacion> rpt_investment = (from item in newdb.rpt_investments_inflacions
                                                                  select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_investments_inflacion", rpt_investment));
                List<rpt_Axys_slide11> rpt_Axys_slide11 = (from item in newdb.rpt_Axys_slide11s
                                                           select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_Axys_slide11", rpt_Axys_slide11));

                List<rpt_axys_slide5> rpt_axys_slide5 = (from item in newdb.rpt_axys_slide5s
                                                         select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_axys_slide5", rpt_axys_slide5));
                List<rpt_axys_slide6> rpt_axys_slide6 = (from item in newdb.rpt_axys_slide6s
                                                         select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_axys_slide6", rpt_axys_slide6));
                List<rpt_axys_slide8> rpt_axys_slide8 = (from item in newdb.rpt_axys_slide8s
                                                         select item).ToList();
                e.DataSources.Add(new ReportDataSource("Charts_rpt_axys_slide8", rpt_axys_slide8));







                ReportDataSource rds = new ReportDataSource();
                DataTable dtNew = new DataTable();
                //dtNew = dt.Copy();
                dtNew = dt.Clone();
                int rowcounter = 1;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (rowcounter < 5)
                    {
                        rowcounter++;
                    }
                    else
                    {
                        //DataRow rw = dt.Rows[i];
                        //dtNew.ImportRow(rw);
                        dtNew.Rows.Add(dt.Rows[i].ItemArray);
                        rowcounter = 1;
                    }
                }

                dtNew.AcceptChanges();

                rds.Value = dtNew;
                e.DataSources.Add(new ReportDataSource("illustratorDataSet_illushorizon", dtNew));
            }

            List<rpt_lifeexpectancy> rpt_Life_Expectancy = (from item in newdb.rpt_lifeexpectancies
                                                            select item).ToList();
            e.DataSources.Add(new ReportDataSource("Charts_rpt_lifeexpectancy", rpt_Life_Expectancy));
            List<rpt_Compass_Slide5> rpt_Compass_Slide5 = (from item in newdb.rpt_Compass_Slide5s
                                                           select item).ToList();
            e.DataSources.Add(new ReportDataSource("Charts_rpt_Compass_Slide5", rpt_Compass_Slide5));



        }
        public static String getspanishmonth(int i)
        {
            if (i == 1)
            {
                return "Enero";
            }
            else if (i == 2)
            {
                return "Febrero";
            }
            else if (i == 3)
            {
                return "Marzo";
            }
            else if (i == 4)
            {
                return "Abril";
            }
            else if (i == 5)
            {
                return "Mayo";
            }
            else if (i == 6)
            {
                return "Junio";
            }
            else if (i == 7)
            {
                return "Julio";
            }
            else if (i == 8)
            {
                return "Agosto";
            }
            else if (i == 9)
            {
                return "Septiembre";
            }
            else if (i == 10)
            {
                return "Octubre";
            }
            else if (i == 11)
            {
                return "Noviembre";
            }
            else if (i == 12)
            {
                return "Diciembre";
            }
            else
            {
                return "";
            }
        }
        public static string GetFormatedText(string str)
        {
            char oldChar = ',';
            char newChar = '.';

            string output = String.Format("{0:n0}", Math.Round(Numericdata.getDoublevalue(str), 0, MidpointRounding.AwayFromZero)).Replace(oldChar, newChar);

            if (output.Equals("0"))
                return "-";

            return output;
        }
        public static byte[] showIllustrationRED(WSAnnuityResult annuityresult, WSCustomer customer, WSCustomerPlan customerplan, IMaineduretire eduretire)
        {
            byte[] bytes = null;
            try
            {
                rpt = new ReportViewer();
                DataVOUniversalDataContext newdb = Program.getDbConnection();
                customerplan.annuityamount = annuityresult.annuityamount;
                customerplan.premiumamount = annuityresult.periodicpremiumamount;

                rpt.LocalReport.Refresh();
                rpt.Reset();
                PlanName = Productdata.getProduct(customerplan.productcode);
                PlanCode = customerplan.productcode;
                if (PlanName.Equals("Axys"))
                {
                    rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/Axys_long.rdlc");
                }
                if (PlanName.Equals("Horizon Growth"))
                {
                    rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/Horizon_Growth_long.rdlc");
                }
                if (PlanName.Equals("Scholar"))
                {
                    rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/Scholar_long.rdlc");
                }

                if (PlanName.Equals("Eduplan Growth"))
                {
                    rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/EduPlan_Growth_long.rdlc");
                }

                Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource();
                //rds.
                rds.Name = "illustratorDataSet_illushorizon";
                dt = new DataTable();
                REDIllusdata[] illus = eduretire.getIllustration();
                for (int i = 0; i < illus[0].getDatacolumns().Length; i++)
                {
                    dt.Columns.Add(new DataColumn(illus[0].getDatacolumns()[i]));
                }
                for (int i = 0; i < illus.Length; i++)
                {
                    dt.Rows.Add(illus[i].getDataarray());
                }
                if (PlanName.Equals("Eduplan Growth") || PlanName.Equals("Scholar") || PlanName.Equals("Axys"))
                {
                    if (dt.Rows.Count >= 16 && dt.Rows.Count <= 20 || dt.Rows.Count >= 36 && dt.Rows.Count <= 40 ||
                       dt.Rows.Count >= 56 && dt.Rows.Count <= 60 || dt.Rows.Count >= 76 && dt.Rows.Count <= 80 ||
                       dt.Rows.Count >= 96 && dt.Rows.Count <= 100)
                    {
                        if (dt.Rows.Count == 16 || dt.Rows.Count == 36 || dt.Rows.Count == 56 || dt.Rows.Count == 76 || dt.Rows.Count == 96)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add(myRow);

                            rds.Value = dt;
                        }

                        else if (dt.Rows.Count == 17 || dt.Rows.Count == 37 || dt.Rows.Count == 57 || dt.Rows.Count == 77 || dt.Rows.Count == 97)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add(myRow);

                            rds.Value = dt;
                        }
                        else if (dt.Rows.Count == 18 || dt.Rows.Count == 38 || dt.Rows.Count == 58 || dt.Rows.Count == 78 || dt.Rows.Count == 98)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add(myRow);

                            rds.Value = dt;
                        }
                        else if (dt.Rows.Count == 19 || dt.Rows.Count == 39 || dt.Rows.Count == 59 || dt.Rows.Count == 79 || dt.Rows.Count == 99)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add(myRow);

                            rds.Value = dt;
                        }
                        else if (dt.Rows.Count == 20 || dt.Rows.Count == 40 || dt.Rows.Count == 60 || dt.Rows.Count == 80)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add(myRow);

                            rds.Value = dt;
                        }
                    }
                }
                else if (PlanName.Equals("Horizon Growth"))
                {
                    if (dt.Rows.Count >= 16 && dt.Rows.Count <= 20 || dt.Rows.Count >= 36 && dt.Rows.Count <= 40 ||
                      dt.Rows.Count >= 56 && dt.Rows.Count <= 60 || dt.Rows.Count >= 76 && dt.Rows.Count <= 80 ||
                      dt.Rows.Count >= 96 && dt.Rows.Count <= 100)
                    {
                        if (dt.Rows.Count == 16 || dt.Rows.Count == 36 || dt.Rows.Count == 56 || dt.Rows.Count == 76 || dt.Rows.Count == 96)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add(myRow);
                            rds.Value = dt;
                        }

                        else if (dt.Rows.Count == 17 || dt.Rows.Count == 37 || dt.Rows.Count == 57 || dt.Rows.Count == 77 || dt.Rows.Count == 97)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add(myRow);
                            rds.Value = dt;
                        }
                        else if (dt.Rows.Count == 18 || dt.Rows.Count == 38 || dt.Rows.Count == 58 || dt.Rows.Count == 78 || dt.Rows.Count == 98)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add(myRow);
                            rds.Value = dt;
                        }
                        else if (dt.Rows.Count == 19 || dt.Rows.Count == 39 || dt.Rows.Count == 59 || dt.Rows.Count == 79 || dt.Rows.Count == 99)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add(myRow);
                            rds.Value = dt;
                        }
                        else if (dt.Rows.Count == 20 || dt.Rows.Count == 40 || dt.Rows.Count == 60 || dt.Rows.Count == 80)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add(myRow);
                            rds.Value = dt;
                        }
                    }
                }
                rds.Value = dt;


                //  hdnCheckCurrentPlan.Value = customerplan.productcode.ToString();

                string defermentperiod = "-";
                string contributionperiod = "-";
                string ddlinitialcontribution = "-";
                string initialcontributionamount = "-";
                string txtsumannualpremium = "-";
                string risk = "-";
                string almillar = "-";
                string plantype = "-";
                string maritalstatus = "-";
                string investmentprofile = "-";
                string freqofpayment = "-";

                investmentprofile = (from item in newdb.investmentprofiledets
                                     where item.investmentprofilecode.Equals(customerplan.investmentprofilecode)
                                     select item.investmentprofile).SingleOrDefault();
                investmentprofile = Lookuplangdata.getLanguagevalue(Lookuptables.investmentprofiledet, investmentprofile, "es");

                if (customerplan != null)
                {
                    ruleclasscode = customerplan.classcode.ToCharArray()[0];
                    if (customerplan.frequencytypecode != null)
                    {
                        freqofpayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode.ToCharArray()[0]), "es");
                    }
                    if (customerplan.defermentperiod != null)
                    {
                        defermentperiod = customerplan.defermentperiod.ToString();
                    }
                    if (customerplan.contributionperiod != null)
                    {
                        contributionperiod = customerplan.contributionperiod.ToString();
                    }

                    if (annuityresult.annualpremiumamount != null)
                    {
                        txtsumannualpremium = annuityresult.annualpremiumamount.ToString();
                    }


                    if (customerplan.initialcontributionamount != null)
                    {
                        if (Numericdata.getDoublevalue(customerplan.initialcontributionamount.ToString()) > 0)
                        {
                            ddlinitialcontribution = "Yes";
                            initialcontributionamount = customerplan.initialcontributionamount.ToString();
                        }
                        else
                        {
                            ddlinitialcontribution = "No";
                            initialcontributionamount = "0";

                        }
                    }
                    risk = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet,
                                                            Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())), "es");


                    almillar = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet,
                                                            Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())), "es");

                    plantype = Lookuplangdata.getLanguagevalue(Lookuptables.plantypedet,
                                                            Plantypes.getPlantype(customerplan.plantypecode.ToCharArray()[0]), "es");

                    maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet, Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es");
                }
                string primaryreq = "";

                List<WSExam> exams = annuityresult.primaryexamsrequiredlist;
                String[] req = new String[12];

                int examno = 0;
                foreach (WSExam exam in exams)
                {
                    primaryreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, exam.examname.ToUpper(), "es") + "/" + primaryreq;
                    req[examno] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, exam.examname, "es");
                    examno++;
                }

                string tempPrimary = " ";
                int lno1 = 0;

                for (int j = 0; j < req.Length; j++)
                {
                    if (!string.IsNullOrEmpty(req[j]))
                        if (!req[j].Trim().Equals(""))
                        {
                            tempPrimary += req[j];
                            if (j != (req.Length - 1))
                            {
                                tempPrimary += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t";
                                //tempPrimary += ", ";

                            }
                            if (tempPrimary.Length > (lno1 + 1) * 150)
                            {
                                tempPrimary += Environment.NewLine;
                                lno1 = lno1 + 1;
                            }

                        }
                }
                List<ReportParameter> paramlist = new List<ReportParameter>();

                if (PlanName.Equals("Axys") || PlanName.Equals("Horizon Growth") || PlanName.Equals("Scholar") || PlanName.Equals("Eduplan Growth"))
                {
                    ReportParameter param100 = new ReportParameter("PolicyholderExams1", "" + tempPrimary);


                    paramlist.Add(param100);

                }


                string Prospect = (((customer.FirstName + " " + customer.MiddleName).Trim() + " " + customer.LastName).Trim() + " " + customer.LastName2).Trim();

                const int MaxLengthHeading = 30;
                const int MaxLengthName = 50;
                var custHeading = (customer.FirstName + " " + customer.LastName).Trim();
                var custName = (customer.FirstName + " " + customer.LastName).Trim();
                if (custHeading.Length > MaxLengthHeading)
                {
                    custHeading = custHeading.Substring(0, MaxLengthHeading);
                    custHeading = custHeading + "...";
                }
                if (custName.Length > MaxLengthName)
                {
                    custName = custName.Substring(0, MaxLengthName);
                    custName = custName + "...";
                }
                ReportParameter param1 = new ReportParameter("heading", custHeading);
                //ReportParameter param1_12 = new ReportParameter("heading1", (customer.LastName + " ").Trim());
                // ReportParameter param2 = new ReportParameter("date", DateTime.Today.ToShortDateString());
                ReportParameter param3 = new ReportParameter("name", custName);
                ReportParameter param4 = new ReportParameter("periodofcontribution", customerplan.contributionperiod + "");
                ReportParameter param5 = new ReportParameter("amountofcontribution", GetFormatedText(customerplan.initialcontributionamount.ToString()));
                //ReportParameter param6 = new ReportParameter("withdrawalperiod", customerplan.contributionuntilage + "");
                ReportParameter param6 = new ReportParameter("withdrawalperiod", customerplan.retirementperiod + "");
                //ReportParameter param7 = new ReportParameter("withdrawalamount", (((String.Format("{0:n0}", Numericdata.getDoublevalue(customerplan.insuredamount + ""))).Replace('.', '/')).Replace(',', '.')).Replace('/', ','));
                ReportParameter param7 = new ReportParameter("withdrawalamount", GetFormatedText(customerplan.annuityamount.ToString()));
                ReportParameter param8 = new ReportParameter("plantype", plantype + "");//Plantypes.getPlantype(customerplan.plantypecode));

                ReportParameter param9 = new ReportParameter("age", customer.Age + "");
                ReportParameter param10 = new ReportParameter("gender", customer.gendercode + "");//Genders.getgender(customer.gendercode));
                ReportParameter param11 = new ReportParameter("smoker", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, Booleandata.getBooleanstring(customer.Smoker.ToCharArray()[0]), "es"));

                ReportParameter param12 = new ReportParameter("ageatretirement", customerplan.contributionuntilage + "");
                ReportParameter param13 = new ReportParameter("risk", risk + "");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                ReportParameter param14 = new ReportParameter("almillar", almillar + "");//Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())));
                ReportParameter param15 = new ReportParameter("maritalstatus", maritalstatus + "");//Maritalstatus.getmaritalstatus(customer.MaritalStatuscode.Value));
                ReportParameter param16 = new ReportParameter("plan", Productdata.getProduct(customerplan.productcode));
                ReportParameter param17 = new ReportParameter("deferralperiod", customerplan.defermentperiod + "");
                ReportParameter param18 = new ReportParameter("country", Lookuplangdata.getLanguagevalue(Lookuptables.countrydet, Countries.getcountry(Numericdata.getIntegervalue(customerplan.countryno.ToString() + "")), "es"));
                ReportParameter param19 = new ReportParameter("investmentprofile", investmentprofile + "");//invp.investmentprofile);
                ReportParameter param20 = new ReportParameter("frequencyofcontribution", freqofpayment);//Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode), Sessionclass.getSessiondata(Session).language));
                ReportParameter param21 = new ReportParameter("initialcontribution", ddlinitialcontribution);
                //ReportParameter param22 = new ReportParameter("totalamount", (((String.Format("{0:n0}", Numericdata.getDoublevalue((customerplan.insuredamount + customerplan.ridertermamount).ToString()))).Replace('.', '/')).Replace(',', '.')).Replace('/', ','));
                ReportParameter param22 = new ReportParameter("totalamount", GetFormatedText((customerplan.annuityamount * customerplan.retirementperiod).ToString()));
                ReportParameter param23 = new ReportParameter("primatarget", GetFormatedText(annuityresult.targetpremiumamount.ToString()));
                ReportParameter param24 = new ReportParameter("minprima", GetFormatedText(annuityresult.minimumpremiumamount.ToString()));
                ReportParameter param31 = new ReportParameter("InitialContributionAmount", GetFormatedText(initialcontributionamount));
                ReportParameter param45 = new ReportParameter("Examinations", primaryreq);
                ReportParameter param46 = new ReportParameter("BottomText", "Esta presentación tiene una validez de 15 días hábiles y en ningún caso más allá del" + " 31-Diciembre-" + DateTime.Now.Year.ToString());
                ReportParameter param47 = new ReportParameter("number", "");
                ReportParameter param1_13 = new ReportParameter("lastname", (customer.LastName + " ").Trim());
                paramlist.Add(param1_13);

                paramlist.Add(param1);
                // paramlist.Add(param2);
                paramlist.Add(param3);
                paramlist.Add(param4);
                paramlist.Add(param5);

                paramlist.Add(param6);
                paramlist.Add(param7);


                paramlist.Add(param8);
                paramlist.Add(param9);
                paramlist.Add(param10);
                paramlist.Add(param11);
                paramlist.Add(param12);
                paramlist.Add(param13);
                paramlist.Add(param14);

                paramlist.Add(param15);
                paramlist.Add(param16);
                paramlist.Add(param17);
                paramlist.Add(param18);
                paramlist.Add(param19);
                paramlist.Add(param20);
                paramlist.Add(param21);
                paramlist.Add(param22);
                paramlist.Add(param23);
                paramlist.Add(param24);
                paramlist.Add(param31);
                paramlist.Add(param45);
                paramlist.Add(param46);
                paramlist.Add(param47);
                ReportParameter prmstatus1 = new ReportParameter("Color", "unchecked");
                paramlist.Add(prmstatus1);
                prmstatus1 = new ReportParameter("BN", "unchecked");
                paramlist.Add(prmstatus1);
                prmstatus1 = new ReportParameter("CompulsoryFigure", "checked");
                paramlist.Add(prmstatus1);
                string[] controllist = { "S100", "S101", "S102", "S103", "S104", "S105", "S200", "S201", "S202", "S203",
                                           "S204", "S205", "S206", "S207", "S300", "S301", "S302", "S303", "S304", "S305", "S306", "S307", "S308", "S400", "S401", "S402", "S403", "S404", "S405"
                                       , "S406", "S500", "S501", "S502", "S503", "S504", "S505"};
                for (int count1 = 0; count1 < controllist.Count(); count1++)
                {
                    ReportParameter prmstatus = new ReportParameter(controllist[count1], "unchecked");
                    paramlist.Add(prmstatus);
                }
                //foreach (Control ccontrol in this.pnlCustomize.Controls)
                //{
                //    if (ccontrol is CheckBox)
                //    {
                //        CheckBox myCheckbox = (CheckBox)ccontrol;
                //        if (myCheckbox.Checked == true)
                //        {
                //            ReportParameter prmstatus = new ReportParameter(myCheckbox.ID.Substring(3, myCheckbox.ID.Length - 3), "checked");
                //            paramlist.Add(prmstatus);
                //        }
                //        else
                //        {
                //            ReportParameter prmstatus = new ReportParameter(myCheckbox.ID.Substring(3, myCheckbox.ID.Length - 3), "unchecked");
                //            paramlist.Add(prmstatus);
                //        }
                //    }
                //}

                String[] clientsign = new string[3];
                String[] agentsign = new string[3];

                clientsign[0] = "N";
                clientsign[1] = "N";
                clientsign[2] = "N";

                agentsign[0] = "N";
                agentsign[1] = "N";
                agentsign[2] = "N";

                ReportParameter Cpath1 = Cpath1 = new ReportParameter("clientsignpath1", "");// new ReportParameter("ClientPath1", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
                ReportParameter Apath1 = new ReportParameter("agentsignpath1", "");// new ReportParameter("AgentPath1", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
                ReportParameter Cpath2 = new ReportParameter("clientsignpath2", "");// new ReportParameter("ClientPath2", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
                ReportParameter Apath2 = new ReportParameter("agentsignpath2", "");// new ReportParameter("AgentPath2", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
                ReportParameter Cpath3 = new ReportParameter("clientsignpath3", "");// new ReportParameter("ClientPath3", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
                ReportParameter Apath3 = new ReportParameter("agentsignpath3", "");// new ReportParameter("AgentPath3", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));

                paramlist.Add(Cpath1);
                paramlist.Add(Apath1);
                paramlist.Add(Cpath2);
                paramlist.Add(Apath2);
                paramlist.Add(Cpath3);
                paramlist.Add(Apath3);
                List<rpt_investments_inflacion> rpt_investment = (from item in newdb.rpt_investments_inflacions
                                                                  select item).ToList();
                var count = rpt_investment.Count();
                var inflation_Last = (from ms in rpt_investment
                                      select new { ms.Pequenas_Acciones, ms.Grandes_Acciones, ms.Papelesdel_Tesoro, ms.Bonosdel_Gobierno, ms.Inflacion }).Last();
                var inflation_first = (from ms in rpt_investment
                                       select new { ms.Pequenas_Acciones, ms.Grandes_Acciones, ms.Papelesdel_Tesoro, ms.Bonosdel_Gobierno, ms.Inflacion }).First();
                var percent_Pequenas_last = inflation_Last.Pequenas_Acciones;
                var percent_Pequenas_First = inflation_first.Pequenas_Acciones;
                var Grandes_Acciones_last = inflation_Last.Grandes_Acciones;
                var Grandes_Acciones_First = inflation_first.Grandes_Acciones;
                var Papelesdel_Tesoro_last = inflation_Last.Papelesdel_Tesoro;
                var Papelesdel_Tesoro_First = inflation_first.Papelesdel_Tesoro;
                var Bonosdel_Gobierno_last = inflation_Last.Bonosdel_Gobierno;
                var Bonosdel_Gobierno_First = inflation_first.Bonosdel_Gobierno;
                var Inflacion1_last = inflation_Last.Inflacion;
                var Inflacion1_First = inflation_first.Inflacion;


                var result_total = percent_Pequenas_last / percent_Pequenas_First;
                var numberofyears = 0.0119;
                var Pequenas_percent = (Math.Pow(Convert.ToDouble(result_total), numberofyears) - 1) * 100;

                var result1_total = Grandes_Acciones_last / Grandes_Acciones_First;
                var numberofyears1 = 0.0119;
                var Grandes_percent = (Math.Pow(Convert.ToDouble(result1_total), numberofyears1) - 1) * 100;

                var result2_total = Papelesdel_Tesoro_last / Papelesdel_Tesoro_First;
                var numberofyears2 = 0.0119;
                var Papelesdel_percent = (Math.Pow(Convert.ToDouble(result2_total), numberofyears2) - 1) * 100;

                var result3_total = Bonosdel_Gobierno_last / Bonosdel_Gobierno_First;
                var numberofyears3 = 0.0119;
                var Bonosdel_percent = (Math.Pow(Convert.ToDouble(result3_total), numberofyears3) - 1) * 100;

                var result4_total = Inflacion1_last / Inflacion1_First;
                var numberofyears4 = 0.0119;
                var Inflacion_percent = (Math.Pow(Convert.ToDouble(result4_total), numberofyears4) - 1) * 100;


                ReportParameter Pequenas_Acciones = new ReportParameter("Pequenas_Acciones", Pequenas_percent.ToString());
                ReportParameter Grandes = new ReportParameter("Grandes", Grandes_percent.ToString());
                ReportParameter Papelesdel_Tesoro = new ReportParameter("Papelesdel_Tesoro", Papelesdel_percent.ToString());
                ReportParameter Bonosdel_Gobierno = new ReportParameter("Bonosdel_Gobierno", Bonosdel_percent.ToString());
                ReportParameter Inflacion = new ReportParameter("Inflacion", Inflacion_percent.ToString());
                paramlist.Add(Pequenas_Acciones);
                paramlist.Add(Grandes);
                paramlist.Add(Papelesdel_Tesoro);
                paramlist.Add(Bonosdel_Gobierno);
                paramlist.Add(Inflacion);



                ReportParameter param308 = new ReportParameter("S308", "unchecked");
                paramlist.Add(param308);

                List<rpt_compass_investment_master> st_rpt_compass_investment_master_moderado = (from item in newdb.rpt_compass_investment_masters
                                                                                                 where item.ReturnType == "Moderado" && item.Region == "Americano/Internacional"
                                                                                                 select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_moderado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_moderado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_moderado);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_moderado = (from item in newdb.rpt_compass_investment_details
                                                                                                       where item.ReturnTypeid == 1
                                                                                                       select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_moderado = new ReportDataSource("Charts_rpt_compass_investment_details_MODERADO", st_rpt_compass_investment_distribution_moderado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_moderado);
                List<rpt_compass_investment_master> st_rpt_compass_investment_master_balanceado = (from item in newdb.rpt_compass_investment_masters
                                                                                                   where item.ReturnType == "Balanceado" && item.Region == "Americano/Internacional"
                                                                                                   select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_balanceado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_balanceado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_balanceado);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_balanceado = (from item in newdb.rpt_compass_investment_details
                                                                                                         where item.ReturnTypeid == 3
                                                                                                         select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_balanceado = new ReportDataSource("Charts_rpt_compass_investment_details_BALANCEADO", st_rpt_compass_investment_distribution_balanceado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_balanceado);
                List<rpt_compass_investment_master> st_rpt_compass_investment_master_cricimiento = (from item in newdb.rpt_compass_investment_masters
                                                                                                    where item.ReturnType == "Cricimiento" && item.Region == "Americano/Internacional"
                                                                                                    select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_cricimiento);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_cricimiento);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_cricimiento = (from item in newdb.rpt_compass_investment_details
                                                                                                          where item.ReturnTypeid == 3
                                                                                                          select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_details_CRICIMIENTO", st_rpt_compass_investment_distribution_cricimiento);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_cricimiento);
                List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_moderado = (from item in newdb.rpt_compass_investment_masters
                                                                                                      where item.ReturnType == "Moderado" && item.Region == "Europeo"
                                                                                                      select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_euro_moderado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_moderado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_moderado);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_moderado = (from item in newdb.rpt_compass_investment_details
                                                                                                            where item.ReturnTypeid == 4
                                                                                                            select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_euro_moderado = new ReportDataSource("Charts_rpt_compass_investment_details_euro_MODERADO", st_rpt_compass_investment_distribution_euro_moderado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_moderado);
                List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_balanceado = (from item in newdb.rpt_compass_investment_masters
                                                                                                        where item.ReturnType == "Balanceado" && item.Region == "Europeo"
                                                                                                        select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_euro_balanceado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_balanceado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_balanceado);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_balanceado = (from item in newdb.rpt_compass_investment_details
                                                                                                              where item.ReturnTypeid == 5
                                                                                                              select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_euro_balanceado = new ReportDataSource("Charts_rpt_compass_investment_details_euro_BALANCEADO", st_rpt_compass_investment_distribution_euro_balanceado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_balanceado);
                List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_cricimiento = (from item in newdb.rpt_compass_investment_masters
                                                                                                         where item.ReturnType == "Cricimiento" && item.Region == "Europeo"
                                                                                                         select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_euro_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_cricimiento);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_cricimiento);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_cricimiento = (from item in newdb.rpt_compass_investment_details
                                                                                                               where item.ReturnTypeid == 6
                                                                                                               select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_euro_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_details_euro_CRICIMIENTO", st_rpt_compass_investment_distribution_euro_cricimiento);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_cricimiento);

                List<rpt_compass_investment_detail> lst_rpt_compass_investment_yearreturn_americano =
                    (from item in newdb.rpt_compass_investment_details
                     join o in newdb.rpt_compass_investment_masters
                     on item.ReturnTypeid equals o.Sno
                     where (item.Years == 2010 && o.Region == "Americano/Internacional")
                     select item).ToList();

                ReportDataSource rds_rpt_compass_investment_yearreturn_americano = new ReportDataSource("Charts_rpt_compass_investment_details_yearreturn_Americano", lst_rpt_compass_investment_yearreturn_americano);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_yearreturn_americano);
                List<rpt_compass_investment_detail> lst_rpt_compass_investment_yearreturn_europeo =
                        (from item in newdb.rpt_compass_investment_details
                         join o in newdb.rpt_compass_investment_masters
                         on item.ReturnTypeid equals o.Sno
                         where (item.Years == 2010 && o.Region == "Europeo")
                         select item).ToList();

                ReportDataSource rds_rpt_compass_investment_yearreturn_europeo = new ReportDataSource("Charts_rpt_compass_investment_details_yearreturn_Europeo", lst_rpt_compass_investment_yearreturn_europeo);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_yearreturn_europeo);

                List<profile_de_inversion> lst_rpt_profile_de_inversion = (from item in newdb.profile_de_inversions
                                                                           select item).ToList();

                List<profile_de_inversion_euro> lst_rpt_profile_de_inversion_euro = (from item in newdb.profile_de_inversion_euros
                                                                                     select item).ToList();
                ReportDataSource rds_profile_de_inversion = new ReportDataSource("Charts_profile_de_inversion", lst_rpt_profile_de_inversion);
                rpt.LocalReport.DataSources.Add(rds_profile_de_inversion);
                ReportDataSource rds_profile_de_inversion_euro = new ReportDataSource("Charts_profile_de_inversion_euro", lst_rpt_profile_de_inversion_euro);
                rpt.LocalReport.DataSources.Add(rds_profile_de_inversion_euro);

                List<rpt_InvestType> lst_rpt_invest_distribution_Moderado = (from item in newdb.rpt_InvestTypes
                                                                             where item.FundCategory == "Moderado" && item.Region == "Americano/Internacional"
                                                                             select item).ToList();
                List<rpt_InvestType> lst_rpt_invest_distribution_Balanceado = (from item in newdb.rpt_InvestTypes
                                                                               where item.FundCategory == "Balanceado" && item.Region == "Americano/Internacional"
                                                                               select item).ToList();
                List<rpt_InvestType> lst_rpt_invest_distribution_Crecimiento = (from item in newdb.rpt_InvestTypes
                                                                                where item.FundCategory == "Crecimiento" && item.Region == "Americano/Internacional"
                                                                                select item).ToList();
                ReportDataSource rds_invest_distribution_Moderado = new ReportDataSource("Charts_rpt_InvestType_MODERADO", lst_rpt_invest_distribution_Moderado);
                rpt.LocalReport.DataSources.Add(rds_invest_distribution_Moderado);
                ReportDataSource rds_invest_distribution_Balanceado = new ReportDataSource("Charts_rpt_InvestType_BALANCEADO", lst_rpt_invest_distribution_Balanceado);
                rpt.LocalReport.DataSources.Add(rds_invest_distribution_Balanceado);
                ReportDataSource rds_invest_distribution_Crecimiento = new ReportDataSource("Charts_rpt_InvestType_CRECIMIENTO", lst_rpt_invest_distribution_Crecimiento);
                rpt.LocalReport.DataSources.Add(rds_invest_distribution_Crecimiento);
                List<rpt_InvestType> lst_rpt_invest_euro_distribution_Moderado = (from item in newdb.rpt_InvestTypes
                                                                                  where item.FundCategory == "Moderado" && item.Region == "Europeo"
                                                                                  select item).ToList();
                ReportDataSource rds_invest_euro_distribution_Moderado = new ReportDataSource("Charts_rpt_euro_InvestType_MODERADO", lst_rpt_invest_euro_distribution_Moderado);
                rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Moderado);
                List<rpt_InvestType> lst_rpt_invest_euro_distribution_Balanceado = (from item in newdb.rpt_InvestTypes
                                                                                    where item.FundCategory == "Balanceado" && item.Region == "Europeo"
                                                                                    select item).ToList();
                ReportDataSource rds_invest_euro_distribution_Balanceado = new ReportDataSource("Charts_rpt_euro_InvestType_BALANCEADO", lst_rpt_invest_euro_distribution_Balanceado);
                rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Balanceado);
                List<rpt_InvestType> lst_rpt_invest_euro_distribution_Crecimiento = (from item in newdb.rpt_InvestTypes
                                                                                     where item.FundCategory == "Crecimiento" && item.Region == "Europeo"
                                                                                     select item).ToList();
                ReportDataSource rds_invest_euro_distribution_Crecimiento = new ReportDataSource("Charts_rpt_euro_InvestType_CRECIMIENTO", lst_rpt_invest_euro_distribution_Crecimiento);
                rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Crecimiento);



                var totMonderadoBond = from mb in lst_rpt_invest_distribution_Moderado
                                       where mb.FundType == "Bond" && mb.FundCategory == "Moderado"
                                       group mb by mb.FundCategory into g
                                       select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var totMonderadoStock = from ms in lst_rpt_invest_distribution_Moderado
                                        where ms.FundType == "Stock" && ms.FundCategory == "Moderado"
                                        group ms by ms.FundCategory into g
                                        select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };



                ReportParameter prmMonderadoBondShare = new ReportParameter("MonderadoBondShare", totMonderadoBond.First().total.ToString());
                paramlist.Add(prmMonderadoBondShare);
                ReportParameter prmMonderadoStockShare = new ReportParameter("MonderadoStockShare", totMonderadoStock.First().total.ToString());
                paramlist.Add(prmMonderadoStockShare);
                var totBalanceadoBond = from mb in lst_rpt_invest_distribution_Balanceado
                                        where mb.FundType == "Bond" && mb.FundCategory == "Balanceado"
                                        group mb by mb.FundCategory into g
                                        select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var totBalanceadoStock = from ms in lst_rpt_invest_distribution_Balanceado
                                         where ms.FundType == "Stock" && ms.FundCategory == "Balanceado"
                                         group ms by ms.FundCategory into g
                                         select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

                ReportParameter prmBalanceadoBondShare = new ReportParameter("BalanceadoBondShare", totBalanceadoBond.First().total.ToString());
                paramlist.Add(prmBalanceadoBondShare);
                ReportParameter prmBalanceadoStockShare = new ReportParameter("BalanceadoStockShare", totBalanceadoStock.First().total.ToString());
                paramlist.Add(prmBalanceadoStockShare);




                var totCrecimientoBond = from mb in lst_rpt_invest_distribution_Crecimiento
                                         where mb.FundType == "Bond" && mb.FundCategory == "Crecimiento"
                                         group mb by mb.FundCategory into g
                                         select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var totCrecimientoStock = from ms in lst_rpt_invest_distribution_Crecimiento
                                          where ms.FundType == "Stock" && ms.FundCategory == "Crecimiento"
                                          group ms by ms.FundCategory into g
                                          select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

                string shareCrecimientoBond;
                if (totCrecimientoBond.FirstOrDefault() != null)
                {
                    shareCrecimientoBond = Convert.ToString(totCrecimientoBond.FirstOrDefault().total);
                }
                else
                {
                    shareCrecimientoBond = "0";
                }

                ReportParameter prmCrecimientoBondShare = new ReportParameter("CrecimientoBondShare", shareCrecimientoBond);
                paramlist.Add(prmCrecimientoBondShare);
                ReportParameter prmCrecimientoStockShare = new ReportParameter("CrecimientoStockShare", totCrecimientoStock.First().total.ToString());
                paramlist.Add(prmCrecimientoStockShare);

                var euro_totBalanceadoBond = from mb in lst_rpt_invest_euro_distribution_Balanceado
                                             where mb.FundType == "Bond" && mb.FundCategory == "Balanceado"
                                             group mb by mb.FundCategory into g
                                             select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var euro_totBalanceadoStock = from ms in lst_rpt_invest_euro_distribution_Balanceado
                                              where ms.FundType == "Stock" && ms.FundCategory == "Balanceado"
                                              group ms by ms.FundCategory into g
                                              select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

                ReportParameter euro_prmBalanceadoBondShare = new ReportParameter("euro_BalanceadoBondShare", euro_totBalanceadoBond.First().total.ToString());
                paramlist.Add(euro_prmBalanceadoBondShare);
                ReportParameter euro_prmBalanceadoStockShare = new ReportParameter("euro_BalanceadoStockShare", euro_totBalanceadoStock.First().total.ToString());
                paramlist.Add(euro_prmBalanceadoStockShare);

                var euro_totMonderadoBond = from mb in lst_rpt_invest_euro_distribution_Moderado
                                            where mb.FundType == "Bond" && mb.FundCategory == "Moderado"
                                            group mb by mb.FundCategory into g
                                            select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var euro_totMonderadoStock = from ms in lst_rpt_invest_euro_distribution_Moderado
                                             where ms.FundType == "Stock" && ms.FundCategory == "Moderado"
                                             group ms by ms.FundCategory into g
                                             select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

                ReportParameter euro_prmMonderadoBondShare = new ReportParameter("euro_MonderadoBondShare", euro_totMonderadoBond.First().total.ToString());
                paramlist.Add(euro_prmMonderadoBondShare);
                ReportParameter euro_prmMonderadoStockShare = new ReportParameter("euro_MonderadoStockShare", euro_totMonderadoStock.First().total.ToString());
                paramlist.Add(euro_prmMonderadoStockShare);

                var euro_totCrecimientoBond = from mb in lst_rpt_invest_distribution_Crecimiento
                                              where mb.FundType == "Bond" && mb.FundCategory == "Crecimiento"
                                              group mb by mb.FundCategory into g
                                              select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var euro_totCrecimientoStock = from ms in lst_rpt_invest_distribution_Crecimiento
                                               where ms.FundType == "Stock" && ms.FundCategory == "Crecimiento"
                                               group ms by ms.FundCategory into g
                                               select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };




                string euro_shareCrecimientoBond;
                if (totCrecimientoBond.FirstOrDefault() != null)
                {
                    euro_shareCrecimientoBond = Convert.ToString(euro_totCrecimientoBond.FirstOrDefault().total);
                }
                else
                {
                    euro_shareCrecimientoBond = "0";
                }

                ReportParameter euro_prmCrecimientoBondShare = new ReportParameter("euro_CrecimientoBondShare", euro_shareCrecimientoBond);
                paramlist.Add(euro_prmCrecimientoBondShare);
                ReportParameter euro_prmCrecimientoStockShare = new ReportParameter("euro_CrecimientoStockShare", euro_totCrecimientoStock.First().total.ToString());
                paramlist.Add(euro_prmCrecimientoStockShare);

                rpt.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

                string studentname = "-";
                if (!string.IsNullOrEmpty(customerplan.studentname))
                {
                    if (!customerplan.studentname.Trim().Equals(""))
                    {
                        studentname = customerplan.studentname;
                    }
                }

                string studentage = "-";
                if ((object)customerplan.studentage != null)
                {
                    if (customerplan.studentage != 0)
                    {
                        studentage = customerplan.studentage.ToString();
                    }
                }
                if (PlanName.Equals("Horizon Growth"))
                {
                    ReportParameter param25 = new ReportParameter("agepension", "" + (Numericdata.getLongvalue(defermentperiod) + Numericdata.getLongvalue(contributionperiod) + Numericdata.getLongvalue(customer.Age.ToString())).ToString());
                    ReportParameter param26 = new ReportParameter("lastline", Generalmethods.getHorizongrowthLastline(Prospect, new Random().Next(1, 20), customerplan.classcode.ToString().ToCharArray()[0]));
                    ReportParameter param30 = new ReportParameter("class", customerplan.classcode.ToString());
                    ReportParameter param32 = new ReportParameter("premiumamount", GetFormatedText(customerplan.premiumamount.ToString()));
                    ReportParameter param35 = new ReportParameter("AnnualPremium", GetFormatedText(txtsumannualpremium));
                    ReportParameter param1_12 = new ReportParameter("lastname", (customer.LastName + " ").Trim());
                    //ReportParameter param120 = new ReportParameter("date", getspanishmonth(DateTime.Now.ToString("MMMM")) + " " + DateTime.Now.ToString("dd, yyyy"));
                    ReportParameter param120 = new ReportParameter("date", getspanishmonth(Int32.Parse(DateTime.Now.ToString("MM"))) + " " + DateTime.Now.ToString("dd, yyyy"));
                    ReportParameter paramsage = new ReportParameter("studentage", studentage + "");
                    ReportParameter param27 = new ReportParameter("studentname", studentname + "");
                    paramlist.Add(paramsage);
                    paramlist.Add(param27);
                    paramlist.Add(param120);
                    paramlist.Add(param25);
                    paramlist.Add(param26);
                    paramlist.Add(param30);
                    paramlist.Add(param32);
                    paramlist.Add(param35);
                    paramlist.Add(param1);
                    paramlist.Add(param1_12);

                }


                if (PlanName.Equals("Axys"))
                {
                    ReportParameter param25 = new ReportParameter("agepension", "" + (Numericdata.getLongvalue(defermentperiod) + Numericdata.getLongvalue(contributionperiod) + Numericdata.getLongvalue(customer.Age.ToString())).ToString());
                    ReportParameter param26 = new ReportParameter("lastline", Generalmethods.getLastline(Prospect, new Random().Next(1, 20), customerplan.classcode.ToString().ToCharArray()[0]));
                    ReportParameter param27 = new ReportParameter("class", customerplan.classcode.ToString());
                    ReportParameter param30 = new ReportParameter("AnnualPremium", GetFormatedText(txtsumannualpremium));
                    ReportParameter param32 = new ReportParameter("premiumamount", GetFormatedText(customerplan.premiumamount.ToString()));
                    ReportParameter param1_12 = new ReportParameter("Lastname", (customer.LastName + " ").Trim());
                    //ReportParameter param120 = new ReportParameter("date", getspanishmonth(DateTime.Now.ToString("MMMM")) + " " + DateTime.Now.ToString("dd, yyyy"));
                    ReportParameter param120 = new ReportParameter("date", getspanishmonth(Int32.Parse(DateTime.Now.ToString("MM"))) + " " + DateTime.Now.ToString("dd, yyyy"));
                    paramlist.Add(param120);
                    paramlist.Add(param1_12);
                    paramlist.Add(param25);
                    paramlist.Add(param26);
                    paramlist.Add(param27);
                    paramlist.Add(param30);
                    paramlist.Add(param32);
                    rpt_Axys_fixedincome_slide12 rptincome = (from item in newdb.rpt_Axys_fixedincome_slide12s
                                                              select item).SingleOrDefault();
                    rpt_Axys_Highperform_slide12 rpthigh = (from item in newdb.rpt_Axys_Highperform_slide12s
                                                            select item).SingleOrDefault();
                    rpt_Axys_lowrisk_slide12 rptrisk = (from item in newdb.rpt_Axys_lowrisk_slide12s
                                                        select item).SingleOrDefault();
                    //ReportParameter param43 = new ReportParameter("Highperform_yeald", rpthigh.Yield.Trim());
                    //ReportParameter param44 = new ReportParameter("Highperform_Risk", rpthigh.Risk.Trim());
                    //ReportParameter param101 = new ReportParameter("lowrisk_yeald", rptrisk.Yield.Trim());
                    //ReportParameter param102 = new ReportParameter("lowrisk_Risk", rptrisk.Risk.Trim());

                    //ReportParameter param41 = new ReportParameter("fixedincome_Yeald", rptincome.Yield.Trim());
                    //ReportParameter param42 = new ReportParameter("fixedincome_Risk", rptincome.Risk.Trim());
                    //paramlist.Add(param41);
                    //paramlist.Add(param42);
                    //paramlist.Add(param43);
                    //paramlist.Add(param44);
                    //paramlist.Add(param101);
                    //paramlist.Add(param102);
                    List<rpt_axys_slide5> rpt_axys_slide5 = (from item in newdb.rpt_axys_slide5s
                                                             select item).ToList();
                    List<rpt_axys_slide6> rpt_axys_slide6 = (from item in newdb.rpt_axys_slide6s
                                                             select item).ToList();
                    List<rpt_axys_slide8> rpt_axys_slide8 = (from item in newdb.rpt_axys_slide8s
                                                             select item).ToList();
                    //List<rpt_Axys_slide10> rpt_Axys_slide10 = (from item in newdb.rpt_Axys_slide10s
                    //                                           select item).ToList();
                    //List<rpt_Axys_fixedincome_slide12> rpt_Axys_fixedincome_slide12 = (from item in newdb.rpt_Axys_fixedincome_slide12s
                    //                                                                   select item).ToList();
                    //List<rpt_Axys_lowrisk_slide12> rpt_Axys_lowrisk_slide12 = (from item in newdb.rpt_Axys_lowrisk_slide12s
                    //                                                           select item).ToList();
                    //List<rpt_Axys_Highperform_slide12> rpt_Axys_Highperform_slide12 = (from item in newdb.rpt_Axys_Highperform_slide12s
                    //                                                                   select item).ToList();
                    //List<rpt_Axys_slide11> rpt_Axys_slide11 = (from item in newdb.rpt_Axys_slide11s
                    //                                           select item).ToList();


                    //ReportDataSource axysslide10 = new ReportDataSource("Charts_rpt_Axys_slide10", rpt_Axys_slide10);
                    ReportDataSource axysslide5 = new ReportDataSource("Charts_rpt_axys_slide5", rpt_axys_slide5);
                    ReportDataSource axysslide8 = new ReportDataSource("Charts_rpt_axys_slide8", rpt_axys_slide8);
                    ReportDataSource axysslide6 = new ReportDataSource("Charts_rpt_axys_slide6", rpt_axys_slide6);
                    //ReportDataSource axysslide12_1 = new ReportDataSource("Charts_rpt_Axys_fixedincome_slide12", rpt_Axys_fixedincome_slide12);
                    //ReportDataSource axysslide12_2 = new ReportDataSource("Charts_rpt_Axys_lowrisk_slide12", rpt_Axys_lowrisk_slide12);
                    //ReportDataSource axysslide12_3 = new ReportDataSource("Charts_rpt_Axys_Highperform_slide12", rpt_Axys_Highperform_slide12);
                    //ReportDataSource axysslide11 = new ReportDataSource("Charts_rpt_Axys_slide11", rpt_Axys_slide11);



                    rpt.LocalReport.DataSources.Add(axysslide5);
                    rpt.LocalReport.DataSources.Add(axysslide6);
                    rpt.LocalReport.DataSources.Add(axysslide8);
                    //rpt.LocalReport.DataSources.Add(axysslide10);
                    //rpt.LocalReport.DataSources.Add(axysslide12_1);
                    //rpt.LocalReport.DataSources.Add(axysslide12_2);
                    //rpt.LocalReport.DataSources.Add(axysslide12_3);
                    //rpt.LocalReport.DataSources.Add(axysslide11);



                    ReportParameter param100 = new ReportParameter("PolicyholderExams1", "" + tempPrimary);

                    paramlist.Add(param100);



                }




                if (PlanName.Equals("Scholar"))
                {
                    ReportParameter param25 = new ReportParameter("periodofstudy", "-");
                    ReportParameter param26 = new ReportParameter("studentage", studentage + "");
                    ReportParameter param27 = new ReportParameter("studentname", studentname + "");
                    ReportParameter param28 = new ReportParameter("kind", customerplan.classcode.ToString());
                    ReportParameter param29 = new ReportParameter("agepension", "" + (Numericdata.getLongvalue(defermentperiod) + Numericdata.getLongvalue(contributionperiod) + Numericdata.getLongvalue(customerplan.studentage.ToString())).ToString());
                    ReportParameter param30 = new ReportParameter("lastline", Generalmethods.getScholarLastline(Prospect, new Random().Next(1, 20), customerplan.classcode.ToString().ToCharArray()[0]));
                    ReportParameter param39 = new ReportParameter("class", customerplan.classcode.ToString());
                    ReportParameter param32 = new ReportParameter("premiumamount", GetFormatedText(customerplan.premiumamount.ToString()));
                    ReportParameter param35 = new ReportParameter("AnnualPremium", GetFormatedText(txtsumannualpremium));
                    ReportParameter param40 = new ReportParameter("investmentprofile", investmentprofile);
                    //ReportParameter param120 = new ReportParameter("date", getspanishmonth(DateTime.Now.ToString("MMMM")) + " " + DateTime.Now.ToString("dd, yyyy"));
                    ReportParameter param120 = new ReportParameter("date", getspanishmonth(Int32.Parse(DateTime.Now.ToString("MM"))) + " " + DateTime.Now.ToString("dd, yyyy"));

                    paramlist.Add(param120);
                    paramlist.Add(param25);
                    paramlist.Add(param26);
                    paramlist.Add(param27);
                    paramlist.Add(param28);
                    paramlist.Add(param29);
                    paramlist.Add(param30);
                    paramlist.Add(param39);
                    paramlist.Add(param32);
                    paramlist.Add(param35);
                    paramlist.Add(param40);

                }
                else if (PlanName.Equals("Eduplan Growth"))
                {
                    ReportParameter param25 = new ReportParameter("studentage", studentage + "");
                    ReportParameter param26 = new ReportParameter("studentname", studentname + "");
                    ReportParameter param27 = new ReportParameter("agepension", "" + (Numericdata.getLongvalue(defermentperiod) + Numericdata.getLongvalue(contributionperiod) + Numericdata.getLongvalue(customerplan.studentage.ToString())).ToString());
                    ReportParameter param28 = new ReportParameter("lastline", Generalmethods.geteduplanLastline(Prospect, new Random().Next(1, 20), customerplan.classcode.ToString().ToCharArray()[0]));
                    ReportParameter param29 = new ReportParameter("class", customerplan.classcode.ToString());
                    ReportParameter param30 = new ReportParameter("AnnualPremium", GetFormatedText(txtsumannualpremium));
                    ReportParameter param32 = new ReportParameter("premiumamount", GetFormatedText(customerplan.premiumamount.ToString()));
                    //ReportParameter param120 = new ReportParameter("date", getspanishmonth(DateTime.Now.ToString("MMMM")) + " " + DateTime.Now.ToString("dd, yyyy"));
                    ReportParameter param120 = new ReportParameter("date", getspanishmonth(Int32.Parse(DateTime.Now.ToString("MM"))) + " " + DateTime.Now.ToString("dd, yyyy"));

                    paramlist.Add(param120);
                    paramlist.Add(param25);
                    paramlist.Add(param26);
                    paramlist.Add(param27);
                    paramlist.Add(param28);
                    paramlist.Add(param29);
                    paramlist.Add(param30);
                    paramlist.Add(param32);



                }

                IGrowthdata[] grdata = eduretire.getAssumedGrowthdata();
                ReportParameter param50 = new ReportParameter("prrateU", Program.getTwodecimalString(grdata[Productdata.PROFILEU].growthRate * 100) + "%");
                ReportParameter param51 = new ReportParameter("pramountU", Program.getThousandseperatedString(grdata[Productdata.PROFILEU].growthAmount));
                paramlist.Add(param50);
                paramlist.Add(param51);

                ReportParameter param52 = new ReportParameter("prrateM", Program.getTwodecimalString(grdata[Productdata.PROFILEM].growthRate * 100) + "%");
                ReportParameter param53 = new ReportParameter("pramountM", Program.getThousandseperatedString(grdata[Productdata.PROFILEM].growthAmount));
                paramlist.Add(param52);
                paramlist.Add(param53);

                ReportParameter param54 = new ReportParameter("prrateB", Program.getTwodecimalString(grdata[Productdata.PROFILEB].growthRate * 100) + "%");
                ReportParameter param55 = new ReportParameter("pramountB", Program.getThousandseperatedString(grdata[Productdata.PROFILEB].growthAmount));
                paramlist.Add(param54);
                paramlist.Add(param55);

                ReportParameter param56 = new ReportParameter("prrateG", Program.getTwodecimalString(grdata[Productdata.PROFILEG].growthRate * 100) + "%");
                ReportParameter param57 = new ReportParameter("pramountG", Program.getThousandseperatedString(grdata[Productdata.PROFILEG].growthAmount));
                paramlist.Add(param56);
                paramlist.Add(param57);


                List<egr_age> egr_age = (from item in newdb.egr_ages select item).ToList();


                List<egr_slide7> egr_slide7 = (from item in newdb.egr_slide7s
                                               select item).ToList();

                List<egr_slide8> egr_slide8 = (from item in newdb.egr_slide8s
                                               select item).ToList();


                List<egr_slide9> egr_slide9 = (from item in newdb.egr_slide9s
                                               select item).ToList();

                List<egr_slide10> egr_slide10 = (from item in newdb.egr_slide10s
                                                 select item).ToList();
                //List<rpt_axys_slide5> rpt_axys_slide5 = (from item in newdb.rpt_axys_slide5s
                //                                 select item).ToList();
                //List<rpt_axys_slide6> rpt_axys_slide6 = (from item in newdb.rpt_axys_slide6s
                //                                         select item).ToList();

                Charts.egr_slide5DataTable egr_slide5 = new Charts.egr_slide5DataTable();
                egr_slide5.Rows.Add("Princeton University", "33.000", "9.600", "5%", "42.117", "12.252", 1);
                egr_slide5.Rows.Add("California Institute of Technology", "34.337", "10.146", "5%", "43.823", "12.949", 2);
                egr_slide5.Rows.Add("Harvard University", "32.557", "11.402", "5%", "41.551", "14.092", 3);
                egr_slide5.Rows.Add("Swarthmore College", "36.154", "11.314", "5%", "46.142", "14.439", 4);
                egr_slide5.Rows.Add("Williams College", "37.400", "10.130", "5%", "47.732", "12.928", 5);
                egr_slide5.Rows.Add("USA Military College", "Publico", "Publico", "-", "Publico", "Publico", 6);
                egr_slide5.Rows.Add("Amherst College", "21.729", "8.114", "5%", "27.732", "10.355", 7);
                egr_slide5.Rows.Add("Wellesley College", "36.404", "11.336", "5%", "46.461", "14.467", 8);
                egr_slide5.Rows.Add("Yale University", "36.500", "11.000", "5%", "46.584", "14.039", 9);
                egr_slide5.Rows.Add("Columbia University", "37.470", "11.386", "5%", "47.822", "15.106", 10);


                //ReportDataSource axysslide5 = new ReportDataSource("Charts_rpt_axys_slide5", rpt_axys_slide5);
                //ReportDataSource axysslide6 = new ReportDataSource("Charts_rpt_axys_slide6", rpt_axys_slide6);
                ReportDataSource slide3 = new ReportDataSource("Charts_egr_age", egr_age);
                ReportDataSource slide7 = new ReportDataSource("Charts_egr_slide7", egr_slide7);
                ReportDataSource slide8 = new ReportDataSource("Charts_egr_slide8", egr_slide8);
                ReportDataSource slide9 = new ReportDataSource("Charts_egr_slide9", egr_slide9);
                ReportDataSource slide10 = new ReportDataSource("Charts_egr_slide10", egr_slide10);
                ReportDataSource slide5 = new ReportDataSource("Charts_egr_slide5", (DataTable)egr_slide5); ///se convirtio a datatable por cambio version reportviewer 10.0

                rpt.LocalReport.DataSources.Add(slide3);
                rpt.LocalReport.DataSources.Add(slide7);
                rpt.LocalReport.DataSources.Add(slide8);
                rpt.LocalReport.DataSources.Add(slide9);
                rpt.LocalReport.DataSources.Add(slide10);
                //rpt.LocalReport.DataSources.Add(axysslide5);
                //rpt.LocalReport.DataSources.Add(axysslide6);
                rpt.LocalReport.DataSources.Add(slide5);
                rpt.LocalReport.DataSources.Add(slide3);

                rpt.LocalReport.EnableExternalImages = true;
                rpt.LocalReport.SetParameters(paramlist);
                rpt.LocalReport.DataSources.Add(rds);
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                bytes = rpt.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                //if (classicmode == true)
                //{
                //    dvReport.Visible = true;
                //    dvpdf.Visible = false;
                //    this.ReportViewer1.LocalReport.Refresh();
                //}
                //else if (customize == false)
                //{
                //    dvpdf.Visible = true;
                //    dvReport.Visible = false;
                //    Warning[] warnings;
                //    string[] streamIds;
                //    string mimeType = string.Empty;
                //    string encoding = string.Empty;
                //    string extension = string.Empty;
                //    byte[] bytes = this.ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                //    MyGlobals.reportbytes = bytes;
                //    String strfilename = System.IO.Path.GetRandomFileName();
                //    Sessionclass.setIllustrationfilename(Session, strfilename + ".pdf");
                //    using (FileStream fs = new FileStream(Server.MapPath("~/pdfoutput/") + strfilename + ".pdf", FileMode.Create))
                //    {
                //        fs.Write(bytes, 0, bytes.Length);
                //    }
                //    /*
                //    StringBuilder sb = new StringBuilder();
                //    sb.Append("<object data='" + "pdfoutput/" + strfilename + ".pdf" + "' type='application/pdf' width='916' height='470'>");
                //    sb.Append("</object>");
                //    this.dvpdf.InnerHtml = sb.ToString();
                //    */
                //    this.dvpdf.InnerHtml = getObjectString(strfilename);


                //}

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {

                // newdb.Dispose();

            }
            return bytes;

        }
        public static byte[] showIllustrationREDfixed(WSAnnuityResult annuityresult, WSCustomer customer, WSCustomerPlan customerplan, IMaineduretirefixed eduretirefixed)
        {
            byte[] bytes = null;
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                rpt = new ReportViewer();
                rpt.LocalReport.Refresh();
                rpt.Reset();

                customerplan.annuityamount = annuityresult.annuityamount;
                customerplan.premiumamount = annuityresult.periodicpremiumamount;


                PlanName = Productdata.getProduct(customerplan.productcode);
                PlanCode = customerplan.productcode;
                if (PlanName.Equals("Horizon"))
                {
                    rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/Horizon_Long.rdlc");

                }
                else if (PlanName.Equals("Eduplan"))
                {
                    rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/Eduplan_long.rdlc");
                }



                Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource();
                //rds.
                rds.Name = "illustratorDataSet_illushorizon";
                REDIllusdata[] illus = eduretirefixed.getIllustration();
                dt = new DataTable();
                for (int i = 0; i < illus[0].getDatacolumns().Length; i++)
                {
                    dt.Columns.Add(new DataColumn(illus[0].getDatacolumns()[i]));
                }
                for (int i = 0; i < illus.Length; i++)
                {
                    dt.Rows.Add(illus[i].getDataarray());
                }
                if (PlanName.Equals("Eduplan"))
                {
                    if (dt.Rows.Count >= 16 && dt.Rows.Count <= 20 || dt.Rows.Count >= 36 && dt.Rows.Count <= 40 ||
                        dt.Rows.Count >= 56 && dt.Rows.Count <= 60 || dt.Rows.Count >= 76 && dt.Rows.Count <= 80 ||
                        dt.Rows.Count >= 96 && dt.Rows.Count <= 100)
                    {
                        if (dt.Rows.Count == 16 || dt.Rows.Count == 36 || dt.Rows.Count == 56 || dt.Rows.Count == 76 || dt.Rows.Count == 96)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add(myRow);
                            rds.Value = dt;
                        }

                        else if (dt.Rows.Count == 17 || dt.Rows.Count == 37 || dt.Rows.Count == 57 || dt.Rows.Count == 77 || dt.Rows.Count == 97)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add(myRow);
                            rds.Value = dt;
                        }
                        else if (dt.Rows.Count == 18 || dt.Rows.Count == 38 || dt.Rows.Count == 58 || dt.Rows.Count == 78 || dt.Rows.Count == 98)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add(myRow);
                            rds.Value = dt;
                        }
                        else if (dt.Rows.Count == 19 || dt.Rows.Count == 39 || dt.Rows.Count == 59 || dt.Rows.Count == 79 || dt.Rows.Count == 99)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add("", "", "", "", "", "", "", "");
                            dt.Rows.Add(myRow);
                            rds.Value = dt;
                        }
                        else if (dt.Rows.Count == 20 || dt.Rows.Count == 40 || dt.Rows.Count == 60 || dt.Rows.Count == 80)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add(myRow);
                            rds.Value = dt;
                        }
                    }
                }

                else if (PlanName.Equals("Horizon"))
                {
                    if (dt.Rows.Count >= 16 && dt.Rows.Count <= 20 || dt.Rows.Count >= 36 && dt.Rows.Count <= 40 ||
                        dt.Rows.Count >= 56 && dt.Rows.Count <= 60 || dt.Rows.Count >= 76 && dt.Rows.Count <= 80 ||
                        dt.Rows.Count >= 96 && dt.Rows.Count <= 100)
                    {
                        if (dt.Rows.Count == 16 || dt.Rows.Count == 36 || dt.Rows.Count == 56 || dt.Rows.Count == 76 || dt.Rows.Count == 96)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add(myRow);
                            rds.Value = dt;
                        }

                        else if (dt.Rows.Count == 17 || dt.Rows.Count == 37 || dt.Rows.Count == 57 || dt.Rows.Count == 77 || dt.Rows.Count == 97)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add(myRow);
                            rds.Value = dt;
                        }
                        else if (dt.Rows.Count == 18 || dt.Rows.Count == 38 || dt.Rows.Count == 58 || dt.Rows.Count == 78 || dt.Rows.Count == 98)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add(myRow);
                            rds.Value = dt;
                        }
                        else if (dt.Rows.Count == 19 || dt.Rows.Count == 39 || dt.Rows.Count == 59 || dt.Rows.Count == 79 || dt.Rows.Count == 99)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add("", "", "", "", "", "", "");
                            dt.Rows.Add(myRow);
                            rds.Value = dt;
                        }
                        else if (dt.Rows.Count == 20 || dt.Rows.Count == 40 || dt.Rows.Count == 60 || dt.Rows.Count == 80)
                        {
                            DataRow myRow;
                            myRow = dt.NewRow();
                            dt.Rows.Add(myRow);
                            rds.Value = dt;
                        }
                    }
                }
                rds.Value = dt;

                //hdnCheckCurrentPlan.Value = customerplan.productcode.ToString();
                string defermentperiod = "-";
                string contributionperiod = "-";
                string initialcontributionamount = "-";
                string intialcontribution = "-";
                string txtsumannualpremium = "-";
                string ageatretirement = "-";
                string risk = "-";
                string almillar = "-";
                string plantype = "-";
                string maritalstatus = "-";
                string freqofpayment = "-";

                string investmentprofile = (from item in newdb.investmentprofiledets
                                            where item.investmentprofilecode.Equals(customerplan.investmentprofilecode)
                                            select item.investmentprofile).SingleOrDefault();
                investmentprofile = Lookuplangdata.getLanguagevalue(Lookuptables.investmentprofiledet, investmentprofile, "es");
                if (customerplan != null)
                {
                    ruleclasscode = customerplan.classcode.ToCharArray()[0];
                    if (customerplan.frequencytypecode != null)
                    {
                        freqofpayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode.ToCharArray()[0]), "es");
                    }
                    if (customerplan.defermentperiod != null)
                    {
                        defermentperiod = customerplan.defermentperiod.ToString();
                    }
                    if (customerplan.contributionperiod != null)
                    {
                        contributionperiod = customerplan.contributionperiod.ToString();
                    }

                    if (annuityresult.annualpremiumamount != null)
                    {
                        txtsumannualpremium = annuityresult.annualpremiumamount.ToString();
                    }
                    if (customerplan.initialcontributionamount != null)
                    {
                        if (Numericdata.getDoublevalue(customerplan.initialcontributionamount.ToString()) > 0)
                        {
                            intialcontribution = "Yes";
                            initialcontributionamount = customerplan.initialcontributionamount.ToString();
                        }
                        else
                        {
                            intialcontribution = "No";
                            initialcontributionamount = "0";

                        }
                    }
                    risk = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet,
                                                            Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())), "es");


                    almillar = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet,
                                                            Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())), "es");

                    plantype = Lookuplangdata.getLanguagevalue(Lookuptables.plantypedet,
                                                            Plantypes.getPlantype(customerplan.plantypecode.ToCharArray()[0]), "es");

                    maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet,
                                                            Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es");

                    ageatretirement = (Numericdata.getIntegervalue(customerplan.defermentperiod.ToString()) + Numericdata.getIntegervalue(customerplan.contributionperiod.ToString()) + Numericdata.getIntegervalue(customer.Age.ToString())).ToString();


                }

                string primaryreq = "";

                List<WSExam> exams = annuityresult.primaryexamsrequiredlist;
                String[] req = new String[12];

                int examno = 0;
                foreach (WSExam exam in exams)
                {
                    primaryreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, exam.examname.ToUpper(), "es") + "/" + primaryreq;
                    req[examno] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, exam.examname, "es");
                    examno++;
                }

                string tempPrimary = " ";
                int lno1 = 0;

                for (int j = 0; j < req.Length; j++)
                {
                    if (!string.IsNullOrEmpty(req[j]))
                        if (!req[j].Trim().Equals(""))
                        {
                            tempPrimary += req[j];
                            if (j != (req.Length - 1))
                            {
                                //tempPrimary += ", ";
                                tempPrimary += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t";
                            }
                            if (tempPrimary.Length > (lno1 + 1) * 150)
                            {
                                tempPrimary += Environment.NewLine;
                                lno1 = lno1 + 1;
                            }

                        }
                }

                List<ReportParameter> paramlist = new List<ReportParameter>();
                if (PlanName.Equals("Horizon") || PlanName.Equals("Eduplan"))
                {
                    ReportParameter param100 = new ReportParameter("PolicyholderExams1", "" + tempPrimary);
                    paramlist.Add(param100);

                }
                string Prospect = (((customer.FirstName + " " + customer.MiddleName).Trim() + " " + customer.LastName).Trim() + " " + customer.LastName2).Trim();
                const int MaxLengthHeading = 30;
                const int MaxLengthName = 50;
                var custHeading = (customer.FirstName + " " + customer.LastName).Trim();
                var custName = (customer.FirstName + " " + customer.LastName).Trim();
                if (custHeading.Length > MaxLengthHeading)
                {
                    custHeading = custHeading.Substring(0, MaxLengthHeading);
                    custHeading = custHeading + "...";
                }
                if (custName.Length > MaxLengthName)
                {
                    custName = custName.Substring(0, MaxLengthName);
                    custName = custName + "...";
                }

                ReportParameter param1 = new ReportParameter("heading", custHeading);

                //ReportParameter param2 = new ReportParameter("date", DateTime.Today.ToShortDateString());
                ReportParameter param3 = new ReportParameter("name", custName);
                ReportParameter param4 = new ReportParameter("periodofcontribution", customerplan.contributionperiod + "");
                ReportParameter param5 = new ReportParameter("amountofcontribution", GetFormatedText(customerplan.initialcontributionamount.ToString()));
                ReportParameter param6 = new ReportParameter("withdrawalperiod", customerplan.retirementperiod + "");// customerplan.contributionuntilage + "");
                //ReportParameter param7 = new ReportParameter("withdrawalamount", ((String.Format("{0:n0}", Numericdata.getDoublevalue(customerplan.insuredamount + "")).Replace('.', '/')).Replace(',', '.')).Replace('/', ','));
                ReportParameter param7 = new ReportParameter("withdrawalamount", GetFormatedText(customerplan.annuityamount.ToString()));
                ReportParameter param8 = new ReportParameter("plantype", plantype + "");
                //string str1 = Plantypes.getPlantype(customerplan.plantypecode);
                ReportParameter param9 = new ReportParameter("age", customer.Age + "");
                ReportParameter param10 = new ReportParameter("gender", customer.gendercode.ToString());//Genders.getgender(customer.gendercode));
                ReportParameter param11 = new ReportParameter("smoker", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, Booleandata.getBooleanstring(customer.Smoker.ToCharArray()[0]), "es"));

                ReportParameter param12 = new ReportParameter("ageatretirement", ageatretirement);// customerplan.contributionuntilage + "");
                ReportParameter param13 = new ReportParameter("risk", risk + "");
                //string str2 = Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString()));
                ReportParameter param14 = new ReportParameter("almillar", almillar + "");
                //string str3 = Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString()));
                ReportParameter param15 = new ReportParameter("maritalstatus", maritalstatus);
                ReportParameter param16 = new ReportParameter("plan", Productdata.getProduct(customerplan.productcode));
                //string str4 = Productdata.getProduct(customerplan.productcode);
                ReportParameter param17 = new ReportParameter("deferralperiod", customerplan.defermentperiod + "");



                ReportParameter param22 = new ReportParameter("country", Lookuplangdata.getLanguagevalue(Lookuptables.countrydet, Countries.getcountry(Numericdata.getIntegervalue(customerplan.countryno.ToString() + "")), "es"));


                //ReportParameter param18 = new ReportParameter("frequencyofcontribution", Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode), language));
                ReportParameter param18 = new ReportParameter("frequencyofcontribution", freqofpayment);// Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode), language));


                ReportParameter param19 = new ReportParameter("initialcontribution", intialcontribution);

                ReportParameter param20 = new ReportParameter("primatarget", GetFormatedText(annuityresult.targetpremiumamount.ToString()));
                //ReportParameter param23 = new ReportParameter("totalamount", ((String.Format("{0:n0}", Numericdata.getDoublevalue((customerplan.insuredamount + customerplan.ridertermamount).ToString())).Replace('.', '/')).Replace(',', '.')).Replace('/', ','));
                ReportParameter param23 = new ReportParameter("totalamount", GetFormatedText((customerplan.annuityamount * customerplan.retirementperiod).ToString()));
                //ReportParameter param24 = new ReportParameter("minprima", ((String.Format("{0:n0}", Numericdata.getDoublevalue(customerplan.minimumpremium.ToString())).Replace('.', s'/')).Replace(',', '.')).Replace('/', ','));
                ReportParameter param44 = new ReportParameter("InitialContributionAmount", GetFormatedText(initialcontributionamount));
                ReportParameter param46 = new ReportParameter("Examinations", "-");
                ReportParameter param47 = new ReportParameter("BottomText", "Esta presentación tiene una validez de 15 días hábiles y en ningún caso más allá del" + " 31-Diciembre-" + DateTime.Now.Year.ToString());

                ReportParameter param48 = new ReportParameter("number", "");
                //ReportParameter param120_1 = new ReportParameter("date", getspanishmonth(DateTime.Now.ToString("MMMM")) + " " + DateTime.Now.ToString("dd, yyyy"));
                ReportParameter param120_1 = new ReportParameter("date", getspanishmonth(Int32.Parse(DateTime.Now.ToString("MM"))) + " " + DateTime.Now.ToString("dd, yyyy"));
                paramlist.Add(param120_1);
                ReportParameter prmcalcular = new ReportParameter("calcular", Calculatetypes.getcalculatetype(customerplan.calculatetypecode.ToCharArray()[0]));
                paramlist.Add(prmcalcular);
                ReportParameter param135 = new ReportParameter("lastname", customer.LastName.ToString());
                paramlist.Add(param135);
                //paramlist.Add(param1_12);
                paramlist.Add(param1);
                // paramlist.Add(param2);
                paramlist.Add(param3);
                paramlist.Add(param4);
                paramlist.Add(param5);

                paramlist.Add(param6);
                paramlist.Add(param7);


                paramlist.Add(param8);
                paramlist.Add(param9);
                paramlist.Add(param10);
                paramlist.Add(param11);
                paramlist.Add(param12);
                paramlist.Add(param13);
                paramlist.Add(param14);

                paramlist.Add(param15);
                paramlist.Add(param16);
                paramlist.Add(param17);
                paramlist.Add(param18);
                paramlist.Add(param19);
                paramlist.Add(param20);
                //paramlist.Add(param21);
                paramlist.Add(param22);
                paramlist.Add(param23);
                // paramlist.Add(param24);
                paramlist.Add(param44);
                paramlist.Add(param46);
                paramlist.Add(param47);
                paramlist.Add(param48);
                ReportParameter prmstatus1 = new ReportParameter("Color", "unchecked");
                paramlist.Add(prmstatus1);
                prmstatus1 = new ReportParameter("BN", "unchecked");
                paramlist.Add(prmstatus1);
                prmstatus1 = new ReportParameter("CompulsoryFigure", "checked");
                paramlist.Add(prmstatus1);
                string[] controllist = { "S100", "S101", "S102", "S103", "S104", "S105", "S200", "S201", "S202", "S203",
                                           "S204", "S205", "S206", "S207", "S300", "S301", "S302", "S303", "S304", "S305", "S306", "S307", "S308", "S400", "S401", "S402", "S403", "S404", "S405"
                                       , "S406", "S500", "S501", "S502", "S503", "S504", "S505"};
                for (int count1 = 0; count1 < controllist.Count(); count1++)
                {
                    ReportParameter prmstatus = new ReportParameter(controllist[count1], "unchecked");
                    paramlist.Add(prmstatus);
                }

                //foreach (Control ccontrol in this.pnlCustomize.Controls)
                //{
                //    if (ccontrol is CheckBox)
                //    {
                //        CheckBox myCheckbox = (CheckBox)ccontrol;
                //        if (myCheckbox.Checked == true)
                //        {
                //            ReportParameter prmstatus = new ReportParameter(myCheckbox.ID.Substring(3, myCheckbox.ID.Length - 3), "checked");
                //            paramlist.Add(prmstatus);
                //        }
                //        else
                //        {
                //            ReportParameter prmstatus = new ReportParameter(myCheckbox.ID.Substring(3, myCheckbox.ID.Length - 3), "unchecked");
                //            paramlist.Add(prmstatus);
                //        }
                //    }
                //}

                string studentname = "-";
                if (!string.IsNullOrEmpty(customerplan.studentname))
                {
                    if (!customerplan.studentname.Trim().Equals(""))
                    {
                        studentname = customerplan.studentname;
                    }
                }

                string studentage = "-";
                if ((object)customerplan.studentage != null)
                {
                    if (customerplan.studentage != 0)
                    {
                        studentage = customerplan.studentage.ToString();
                    }
                }


                String[] clientsign = new string[3];
                String[] agentsign = new string[3];

                clientsign[0] = "N";
                clientsign[1] = "N";
                clientsign[2] = "N";

                agentsign[0] = "N";
                agentsign[1] = "N";
                agentsign[2] = "N";

                ReportParameter Cpath1 = new ReportParameter("clientsignpath1", "");// new ReportParameter("ClientPath1", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
                ReportParameter Apath1 = new ReportParameter("agentsignpath1", ""); ;// new ReportParameter("AgentPath1", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
                ReportParameter Cpath2 = new ReportParameter("clientsignpath2", ""); ;// new ReportParameter("ClientPath2", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
                ReportParameter Apath2 = new ReportParameter("agentsignpath2", ""); ;// new ReportParameter("AgentPath2", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
                ReportParameter Cpath3 = new ReportParameter("clientsignpath3", ""); ;// new ReportParameter("ClientPath3", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
                ReportParameter Apath3 = new ReportParameter("agentsignpath3", ""); ;// new ReportParameter("AgentPath3", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
                paramlist.Add(Cpath1);
                paramlist.Add(Apath1);
                paramlist.Add(Cpath2);
                paramlist.Add(Apath2);
                paramlist.Add(Cpath3);
                paramlist.Add(Apath3);

                List<rpt_investments_inflacion> rpt_investment = (from item in newdb.rpt_investments_inflacions
                                                                  select item).ToList();
                var count = rpt_investment.Count();
                var inflation_Last = (from ms in rpt_investment
                                      select new { ms.Pequenas_Acciones, ms.Grandes_Acciones, ms.Papelesdel_Tesoro, ms.Bonosdel_Gobierno, ms.Inflacion }).Last();
                var inflation_first = (from ms in rpt_investment
                                       select new { ms.Pequenas_Acciones, ms.Grandes_Acciones, ms.Papelesdel_Tesoro, ms.Bonosdel_Gobierno, ms.Inflacion }).First();
                var percent_Pequenas_last = inflation_Last.Pequenas_Acciones;
                var percent_Pequenas_First = inflation_first.Pequenas_Acciones;
                var Grandes_Acciones_last = inflation_Last.Grandes_Acciones;
                var Grandes_Acciones_First = inflation_first.Grandes_Acciones;
                var Papelesdel_Tesoro_last = inflation_Last.Papelesdel_Tesoro;
                var Papelesdel_Tesoro_First = inflation_first.Papelesdel_Tesoro;
                var Bonosdel_Gobierno_last = inflation_Last.Bonosdel_Gobierno;
                var Bonosdel_Gobierno_First = inflation_first.Bonosdel_Gobierno;
                var Inflacion1_last = inflation_Last.Inflacion;
                var Inflacion1_First = inflation_first.Inflacion;


                var result_total = percent_Pequenas_last / percent_Pequenas_First;
                var numberofyears = 0.0119;
                var Pequenas_percent = (Math.Pow(Convert.ToDouble(result_total), numberofyears) - 1) * 100;

                var result1_total = Grandes_Acciones_last / Grandes_Acciones_First;
                var numberofyears1 = 0.0119;
                var Grandes_percent = (Math.Pow(Convert.ToDouble(result1_total), numberofyears1) - 1) * 100;

                var result2_total = Papelesdel_Tesoro_last / Papelesdel_Tesoro_First;
                var numberofyears2 = 0.0119;
                var Papelesdel_percent = (Math.Pow(Convert.ToDouble(result2_total), numberofyears2) - 1) * 100;

                var result3_total = Bonosdel_Gobierno_last / Bonosdel_Gobierno_First;
                var numberofyears3 = 0.0119;
                var Bonosdel_percent = (Math.Pow(Convert.ToDouble(result3_total), numberofyears3) - 1) * 100;

                var result4_total = Inflacion1_last / Inflacion1_First;
                var numberofyears4 = 0.0119;
                var Inflacion_percent = (Math.Pow(Convert.ToDouble(result4_total), numberofyears4) - 1) * 100;


                ReportParameter Pequenas_Acciones = new ReportParameter("Pequenas_Acciones", Pequenas_percent.ToString());
                ReportParameter Grandes = new ReportParameter("Grandes", Grandes_percent.ToString());
                ReportParameter Papelesdel_Tesoro = new ReportParameter("Papelesdel_Tesoro", Papelesdel_percent.ToString());
                ReportParameter Bonosdel_Gobierno = new ReportParameter("Bonosdel_Gobierno", Bonosdel_percent.ToString());
                ReportParameter Inflacion = new ReportParameter("Inflacion", Inflacion_percent.ToString());
                paramlist.Add(Pequenas_Acciones);
                paramlist.Add(Grandes);
                paramlist.Add(Papelesdel_Tesoro);
                paramlist.Add(Bonosdel_Gobierno);
                paramlist.Add(Inflacion);




                ReportParameter param308 = new ReportParameter("S308", "unchecked");
                paramlist.Add(param308);







                List<rpt_compass_investment_master> st_rpt_compass_investment_master_moderado = (from item in newdb.rpt_compass_investment_masters
                                                                                                 where item.ReturnType == "Moderado" && item.Region == "Americano/Internacional"
                                                                                                 select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_moderado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_moderado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_moderado);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_moderado = (from item in newdb.rpt_compass_investment_details
                                                                                                       where item.ReturnTypeid == 1
                                                                                                       select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_moderado = new ReportDataSource("Charts_rpt_compass_investment_details_MODERADO", st_rpt_compass_investment_distribution_moderado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_moderado);
                List<rpt_compass_investment_master> st_rpt_compass_investment_master_balanceado = (from item in newdb.rpt_compass_investment_masters
                                                                                                   where item.ReturnType == "Balanceado" && item.Region == "Americano/Internacional"
                                                                                                   select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_balanceado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_balanceado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_balanceado);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_balanceado = (from item in newdb.rpt_compass_investment_details
                                                                                                         where item.ReturnTypeid == 3
                                                                                                         select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_balanceado = new ReportDataSource("Charts_rpt_compass_investment_details_BALANCEADO", st_rpt_compass_investment_distribution_balanceado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_balanceado);
                List<rpt_compass_investment_master> st_rpt_compass_investment_master_cricimiento = (from item in newdb.rpt_compass_investment_masters
                                                                                                    where item.ReturnType == "Cricimiento" && item.Region == "Americano/Internacional"
                                                                                                    select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_cricimiento);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_cricimiento);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_cricimiento = (from item in newdb.rpt_compass_investment_details
                                                                                                          where item.ReturnTypeid == 3
                                                                                                          select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_details_CRICIMIENTO", st_rpt_compass_investment_distribution_cricimiento);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_cricimiento);
                List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_moderado = (from item in newdb.rpt_compass_investment_masters
                                                                                                      where item.ReturnType == "Moderado" && item.Region == "Europeo"
                                                                                                      select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_euro_moderado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_moderado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_moderado);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_moderado = (from item in newdb.rpt_compass_investment_details
                                                                                                            where item.ReturnTypeid == 4
                                                                                                            select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_euro_moderado = new ReportDataSource("Charts_rpt_compass_investment_details_euro_MODERADO", st_rpt_compass_investment_distribution_euro_moderado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_moderado);
                List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_balanceado = (from item in newdb.rpt_compass_investment_masters
                                                                                                        where item.ReturnType == "Balanceado" && item.Region == "Europeo"
                                                                                                        select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_euro_balanceado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_balanceado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_balanceado);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_balanceado = (from item in newdb.rpt_compass_investment_details
                                                                                                              where item.ReturnTypeid == 5
                                                                                                              select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_euro_balanceado = new ReportDataSource("Charts_rpt_compass_investment_details_euro_BALANCEADO", st_rpt_compass_investment_distribution_euro_balanceado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_balanceado);
                List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_cricimiento = (from item in newdb.rpt_compass_investment_masters
                                                                                                         where item.ReturnType == "Cricimiento" && item.Region == "Europeo"
                                                                                                         select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_euro_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_cricimiento);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_cricimiento);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_cricimiento = (from item in newdb.rpt_compass_investment_details
                                                                                                               where item.ReturnTypeid == 6
                                                                                                               select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_euro_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_details_euro_CRICIMIENTO", st_rpt_compass_investment_distribution_euro_cricimiento);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_cricimiento);

                List<rpt_compass_investment_detail> lst_rpt_compass_investment_yearreturn_americano =
                    (from item in newdb.rpt_compass_investment_details
                     join o in newdb.rpt_compass_investment_masters
                     on item.ReturnTypeid equals o.Sno
                     where (item.Years == 2010 && o.Region == "Americano/Internacional")
                     select item).ToList();

                ReportDataSource rds_rpt_compass_investment_yearreturn_americano = new ReportDataSource("Charts_rpt_compass_investment_details_yearreturn_Americano", lst_rpt_compass_investment_yearreturn_americano);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_yearreturn_americano);
                List<rpt_compass_investment_detail> lst_rpt_compass_investment_yearreturn_europeo =
                        (from item in newdb.rpt_compass_investment_details
                         join o in newdb.rpt_compass_investment_masters
                         on item.ReturnTypeid equals o.Sno
                         where (item.Years == 2010 && o.Region == "Europeo")
                         select item).ToList();

                ReportDataSource rds_rpt_compass_investment_yearreturn_europeo = new ReportDataSource("Charts_rpt_compass_investment_details_yearreturn_Europeo", lst_rpt_compass_investment_yearreturn_europeo);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_yearreturn_europeo);

                List<profile_de_inversion> lst_rpt_profile_de_inversion = (from item in newdb.profile_de_inversions
                                                                           select item).ToList();

                List<profile_de_inversion_euro> lst_rpt_profile_de_inversion_euro = (from item in newdb.profile_de_inversion_euros
                                                                                     select item).ToList();
                ReportDataSource rds_profile_de_inversion = new ReportDataSource("Charts_profile_de_inversion", lst_rpt_profile_de_inversion);
                rpt.LocalReport.DataSources.Add(rds_profile_de_inversion);
                ReportDataSource rds_profile_de_inversion_euro = new ReportDataSource("Charts_profile_de_inversion_euro", lst_rpt_profile_de_inversion_euro);
                rpt.LocalReport.DataSources.Add(rds_profile_de_inversion_euro);

                List<rpt_InvestType> lst_rpt_invest_distribution_Moderado = (from item in newdb.rpt_InvestTypes
                                                                             where item.FundCategory == "Moderado" && item.Region == "Americano/Internacional"
                                                                             select item).ToList();
                List<rpt_InvestType> lst_rpt_invest_distribution_Balanceado = (from item in newdb.rpt_InvestTypes
                                                                               where item.FundCategory == "Balanceado" && item.Region == "Americano/Internacional"
                                                                               select item).ToList();
                List<rpt_InvestType> lst_rpt_invest_distribution_Crecimiento = (from item in newdb.rpt_InvestTypes
                                                                                where item.FundCategory == "Crecimiento" && item.Region == "Americano/Internacional"
                                                                                select item).ToList();
                ReportDataSource rds_invest_distribution_Moderado = new ReportDataSource("Charts_rpt_InvestType_MODERADO", lst_rpt_invest_distribution_Moderado);
                rpt.LocalReport.DataSources.Add(rds_invest_distribution_Moderado);
                ReportDataSource rds_invest_distribution_Balanceado = new ReportDataSource("Charts_rpt_InvestType_BALANCEADO", lst_rpt_invest_distribution_Balanceado);
                rpt.LocalReport.DataSources.Add(rds_invest_distribution_Balanceado);
                ReportDataSource rds_invest_distribution_Crecimiento = new ReportDataSource("Charts_rpt_InvestType_CRECIMIENTO", lst_rpt_invest_distribution_Crecimiento);
                rpt.LocalReport.DataSources.Add(rds_invest_distribution_Crecimiento);
                List<rpt_InvestType> lst_rpt_invest_euro_distribution_Moderado = (from item in newdb.rpt_InvestTypes
                                                                                  where item.FundCategory == "Moderado" && item.Region == "Europeo"
                                                                                  select item).ToList();
                ReportDataSource rds_invest_euro_distribution_Moderado = new ReportDataSource("Charts_rpt_euro_InvestType_MODERADO", lst_rpt_invest_euro_distribution_Moderado);
                rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Moderado);
                List<rpt_InvestType> lst_rpt_invest_euro_distribution_Balanceado = (from item in newdb.rpt_InvestTypes
                                                                                    where item.FundCategory == "Balanceado" && item.Region == "Europeo"
                                                                                    select item).ToList();
                ReportDataSource rds_invest_euro_distribution_Balanceado = new ReportDataSource("Charts_rpt_euro_InvestType_BALANCEADO", lst_rpt_invest_euro_distribution_Balanceado);
                rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Balanceado);
                List<rpt_InvestType> lst_rpt_invest_euro_distribution_Crecimiento = (from item in newdb.rpt_InvestTypes
                                                                                     where item.FundCategory == "Crecimiento" && item.Region == "Europeo"
                                                                                     select item).ToList();
                ReportDataSource rds_invest_euro_distribution_Crecimiento = new ReportDataSource("Charts_rpt_euro_InvestType_CRECIMIENTO", lst_rpt_invest_euro_distribution_Crecimiento);
                rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Crecimiento);



                var totMonderadoBond = from mb in lst_rpt_invest_distribution_Moderado
                                       where mb.FundType == "Bond" && mb.FundCategory == "Moderado"
                                       group mb by mb.FundCategory into g
                                       select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var totMonderadoStock = from ms in lst_rpt_invest_distribution_Moderado
                                        where ms.FundType == "Stock" && ms.FundCategory == "Moderado"
                                        group ms by ms.FundCategory into g
                                        select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };



                ReportParameter prmMonderadoBondShare = new ReportParameter("MonderadoBondShare", totMonderadoBond.First().total.ToString());
                paramlist.Add(prmMonderadoBondShare);
                ReportParameter prmMonderadoStockShare = new ReportParameter("MonderadoStockShare", totMonderadoStock.First().total.ToString());
                paramlist.Add(prmMonderadoStockShare);
                var totBalanceadoBond = from mb in lst_rpt_invest_distribution_Balanceado
                                        where mb.FundType == "Bond" && mb.FundCategory == "Balanceado"
                                        group mb by mb.FundCategory into g
                                        select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var totBalanceadoStock = from ms in lst_rpt_invest_distribution_Balanceado
                                         where ms.FundType == "Stock" && ms.FundCategory == "Balanceado"
                                         group ms by ms.FundCategory into g
                                         select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

                ReportParameter prmBalanceadoBondShare = new ReportParameter("BalanceadoBondShare", totBalanceadoBond.First().total.ToString());
                paramlist.Add(prmBalanceadoBondShare);
                ReportParameter prmBalanceadoStockShare = new ReportParameter("BalanceadoStockShare", totBalanceadoStock.First().total.ToString());
                paramlist.Add(prmBalanceadoStockShare);




                var totCrecimientoBond = from mb in lst_rpt_invest_distribution_Crecimiento
                                         where mb.FundType == "Bond" && mb.FundCategory == "Crecimiento"
                                         group mb by mb.FundCategory into g
                                         select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var totCrecimientoStock = from ms in lst_rpt_invest_distribution_Crecimiento
                                          where ms.FundType == "Stock" && ms.FundCategory == "Crecimiento"
                                          group ms by ms.FundCategory into g
                                          select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

                string shareCrecimientoBond;
                if (totCrecimientoBond.FirstOrDefault() != null)
                {
                    shareCrecimientoBond = Convert.ToString(totCrecimientoBond.FirstOrDefault().total);
                }
                else
                {
                    shareCrecimientoBond = "0";
                }

                ReportParameter prmCrecimientoBondShare = new ReportParameter("CrecimientoBondShare", shareCrecimientoBond);
                paramlist.Add(prmCrecimientoBondShare);
                ReportParameter prmCrecimientoStockShare = new ReportParameter("CrecimientoStockShare", totCrecimientoStock.First().total.ToString());
                paramlist.Add(prmCrecimientoStockShare);

                var euro_totBalanceadoBond = from mb in lst_rpt_invest_euro_distribution_Balanceado
                                             where mb.FundType == "Bond" && mb.FundCategory == "Balanceado"
                                             group mb by mb.FundCategory into g
                                             select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var euro_totBalanceadoStock = from ms in lst_rpt_invest_euro_distribution_Balanceado
                                              where ms.FundType == "Stock" && ms.FundCategory == "Balanceado"
                                              group ms by ms.FundCategory into g
                                              select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

                ReportParameter euro_prmBalanceadoBondShare = new ReportParameter("euro_BalanceadoBondShare", euro_totBalanceadoBond.First().total.ToString());
                paramlist.Add(euro_prmBalanceadoBondShare);
                ReportParameter euro_prmBalanceadoStockShare = new ReportParameter("euro_BalanceadoStockShare", euro_totBalanceadoStock.First().total.ToString());
                paramlist.Add(euro_prmBalanceadoStockShare);

                var euro_totMonderadoBond = from mb in lst_rpt_invest_euro_distribution_Moderado
                                            where mb.FundType == "Bond" && mb.FundCategory == "Moderado"
                                            group mb by mb.FundCategory into g
                                            select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var euro_totMonderadoStock = from ms in lst_rpt_invest_euro_distribution_Moderado
                                             where ms.FundType == "Stock" && ms.FundCategory == "Moderado"
                                             group ms by ms.FundCategory into g
                                             select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

                ReportParameter euro_prmMonderadoBondShare = new ReportParameter("euro_MonderadoBondShare", euro_totMonderadoBond.First().total.ToString());
                paramlist.Add(euro_prmMonderadoBondShare);
                ReportParameter euro_prmMonderadoStockShare = new ReportParameter("euro_MonderadoStockShare", euro_totMonderadoStock.First().total.ToString());
                paramlist.Add(euro_prmMonderadoStockShare);

                var euro_totCrecimientoBond = from mb in lst_rpt_invest_distribution_Crecimiento
                                              where mb.FundType == "Bond" && mb.FundCategory == "Crecimiento"
                                              group mb by mb.FundCategory into g
                                              select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var euro_totCrecimientoStock = from ms in lst_rpt_invest_distribution_Crecimiento
                                               where ms.FundType == "Stock" && ms.FundCategory == "Crecimiento"
                                               group ms by ms.FundCategory into g
                                               select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };




                string euro_shareCrecimientoBond;
                if (totCrecimientoBond.FirstOrDefault() != null)
                {
                    euro_shareCrecimientoBond = Convert.ToString(euro_totCrecimientoBond.FirstOrDefault().total);
                }
                else
                {
                    euro_shareCrecimientoBond = "0";
                }

                ReportParameter euro_prmCrecimientoBondShare = new ReportParameter("euro_CrecimientoBondShare", euro_shareCrecimientoBond);
                paramlist.Add(euro_prmCrecimientoBondShare);
                ReportParameter euro_prmCrecimientoStockShare = new ReportParameter("euro_CrecimientoStockShare", euro_totCrecimientoStock.First().total.ToString());
                paramlist.Add(euro_prmCrecimientoStockShare);

                rpt.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                if (PlanName.Equals("Eduplan"))
                {
                    ReportParameter param25 = new ReportParameter("studentname", studentname + "");
                    ReportParameter param26 = new ReportParameter("studentage", studentage + "");
                    ReportParameter param27 = new ReportParameter("investmentprofile", "");
                    ReportParameter param28 = new ReportParameter("agepension", "" + (Numericdata.getLongvalue(defermentperiod) + Numericdata.getLongvalue(contributionperiod) + Numericdata.getLongvalue(customerplan.studentage.ToString())).ToString());
                    ReportParameter param29 = new ReportParameter("lastline", Generalmethods.geteduplanLastline(Prospect, new Random().Next(1, 20), customerplan.classcode.ToString().ToCharArray()[0]));
                    ReportParameter param31 = new ReportParameter("class", customerplan.classcode.ToString());
                    ReportParameter param30 = new ReportParameter("AnnualPremium", GetFormatedText(txtsumannualpremium));
                    ReportParameter param32 = new ReportParameter("premiumamount", GetFormatedText(customerplan.premiumamount.ToString()));


                    paramlist.Add(param25);
                    paramlist.Add(param26);
                    paramlist.Add(param27);
                    paramlist.Add(param28);
                    paramlist.Add(param29);
                    paramlist.Add(param31);
                    paramlist.Add(param30);
                    paramlist.Add(param32);
                    List<egr_age> egr_age = (from item in newdb.egr_ages select item).ToList();


                    List<egr_slide7> egr_slide7 = (from item in newdb.egr_slide7s
                                                   select item).ToList();

                    List<egr_slide8> egr_slide8 = (from item in newdb.egr_slide8s
                                                   select item).ToList();


                    List<egr_slide9> egr_slide9 = (from item in newdb.egr_slide9s
                                                   select item).ToList();

                    List<egr_slide10> egr_slide10 = (from item in newdb.egr_slide10s
                                                     select item).ToList();
                    //List<rpt_axys_slide5> rpt_axys_slide5 = (from item in newdb.rpt_axys_slide5s
                    //                                 select item).ToList();
                    //List<rpt_axys_slide6> rpt_axys_slide6 = (from item in newdb.rpt_axys_slide6s
                    //                                         select item).ToList();

                    Charts.egr_slide5DataTable egr_slide5 = new Charts.egr_slide5DataTable();
                    egr_slide5.Rows.Add("Princeton University", "33.000", "9.600", "5%", "42.117", "12.252", 1);
                    egr_slide5.Rows.Add("California Institute of Technology", "34.337", "10.146", "5%", "43.823", "12.949", 2);
                    egr_slide5.Rows.Add("Harvard University", "32.557", "11.402", "5%", "41.551", "14.092", 3);
                    egr_slide5.Rows.Add("Swarthmore College", "36.154", "11.314", "5%", "46.142", "14.439", 4);
                    egr_slide5.Rows.Add("Williams College", "37.400", "10.130", "5%", "47.732", "12.928", 5);
                    egr_slide5.Rows.Add("USA Military College", "Publico", "Publico", "-", "Publico", "Publico", 6);
                    egr_slide5.Rows.Add("Amherst College", "21.729", "8.114", "5%", "27.732", "10.355", 7);
                    egr_slide5.Rows.Add("Wellesley College", "36.404", "11.336", "5%", "46.461", "14.467", 8);
                    egr_slide5.Rows.Add("Yale University", "36.500", "11.000", "5%", "46.584", "14.039", 9);
                    egr_slide5.Rows.Add("Columbia University", "37.470", "11.386", "5%", "47.822", "15.106", 10);


                    //ReportDataSource axysslide5 = new ReportDataSource("Charts_rpt_axys_slide5", rpt_axys_slide5);
                    //ReportDataSource axysslide6 = new ReportDataSource("Charts_rpt_axys_slide6", rpt_axys_slide6);
                    ReportDataSource slide3 = new ReportDataSource("Charts_egr_age", egr_age);
                    ReportDataSource slide7 = new ReportDataSource("Charts_egr_slide7", egr_slide7);
                    ReportDataSource slide8 = new ReportDataSource("Charts_egr_slide8", egr_slide8);
                    ReportDataSource slide9 = new ReportDataSource("Charts_egr_slide9", egr_slide9);
                    ReportDataSource slide10 = new ReportDataSource("Charts_egr_slide10", egr_slide10);
                    ReportDataSource slide5 = new ReportDataSource("Charts_egr_slide5", (DataTable)egr_slide5); //se convirtio a datatable por error con reportviewer 10

                    rpt.LocalReport.DataSources.Add(slide3);
                    rpt.LocalReport.DataSources.Add(slide7);
                    rpt.LocalReport.DataSources.Add(slide8);
                    rpt.LocalReport.DataSources.Add(slide9);
                    rpt.LocalReport.DataSources.Add(slide10);
                    //rpt.LocalReport.DataSources.Add(axysslide5);
                    //rpt.LocalReport.DataSources.Add(axysslide6);
                    rpt.LocalReport.DataSources.Add(slide5);
                    rpt.LocalReport.DataSources.Add(slide3);

                }
                if (PlanName.Equals("Horizon"))
                {

                    ReportParameter param28 = new ReportParameter("agepension", "" + (Numericdata.getLongvalue(defermentperiod) + Numericdata.getLongvalue(contributionperiod) + Numericdata.getLongvalue(customer.Age.ToString())).ToString());
                    ReportParameter param29 = new ReportParameter("lastline", Generalmethods.getHorizonLastline(Prospect, new Random().Next(1, 20), customerplan.classcode.ToString().ToCharArray()[0]));
                    ReportParameter param30 = new ReportParameter("AnnualPremium", GetFormatedText(txtsumannualpremium));
                    ReportParameter param32 = new ReportParameter("premiumamount", GetFormatedText(customerplan.premiumamount.ToString()));
                    ReportParameter param27 = new ReportParameter("class", customerplan.classcode.ToString());
                    //  ReportParameter param25 = new ReportParameter("investmentprofile", invp.investmentprofile);
                    ReportParameter param1_12 = new ReportParameter("heading1", (customer.LastName + " ").Trim());
                    ReportParameter param24 = new ReportParameter("minprima", GetFormatedText(annuityresult.targetpremiumamount.ToString()));
                    paramlist.Add(param1_12);
                    paramlist.Add(param24);
                    paramlist.Add(param28);
                    paramlist.Add(param29);
                    paramlist.Add(param30);
                    paramlist.Add(param32);
                    paramlist.Add(param27);
                    // paramlist.Add(param25);


                    List<egr_age> egr_age = (from item in newdb.egr_ages select item).ToList();
                    List<rpt_axys_slide5> rpt_axys_slide5 = (from item in newdb.rpt_axys_slide5s
                                                             select item).ToList();
                    List<rpt_axys_slide6> rpt_axys_slide6 = (from item in newdb.rpt_axys_slide6s
                                                             select item).ToList();
                    List<rpt_axys_slide8> rpt_axys_slide8 = (from item in newdb.rpt_axys_slide8s
                                                             select item).ToList();
                    List<rpt_Axys_slide10> rpt_Axys_slide10 = (from item in newdb.rpt_Axys_slide10s
                                                               select item).ToList();



                    ReportDataSource horizonslide4 = new ReportDataSource("Charts_egr_age", egr_age);
                    ReportDataSource axysslide10 = new ReportDataSource("Charts_rpt_Axys_slide10", rpt_Axys_slide10);
                    ReportDataSource axysslide5 = new ReportDataSource("Charts_rpt_axys_slide5", rpt_axys_slide5);
                    ReportDataSource axysslide8 = new ReportDataSource("Charts_rpt_axys_slide8", rpt_axys_slide8);
                    ReportDataSource axysslide6 = new ReportDataSource("Charts_rpt_axys_slide6", rpt_axys_slide6);

                    rpt.LocalReport.DataSources.Add(axysslide5);
                    rpt.LocalReport.DataSources.Add(axysslide6);
                    rpt.LocalReport.DataSources.Add(axysslide8);
                    rpt.LocalReport.DataSources.Add(axysslide10);
                    rpt.LocalReport.DataSources.Add(horizonslide4);



                }
                rpt.LocalReport.EnableExternalImages = true;
                rpt.LocalReport.SetParameters(paramlist);

                rpt.LocalReport.DataSources.Add(rds);
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                bytes = rpt.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                //if (classicmode == true)
                //{
                //    dvReport.Visible = true;
                //    dvpdf.Visible = false;
                //    this.ReportViewer1.LocalReport.Refresh();
                //}
                //else if (customize == false)
                //{
                //    dvpdf.Visible = true;
                //    dvReport.Visible = false;
                //    Warning[] warnings;
                //    string[] streamIds;
                //    string mimeType = string.Empty;
                //    string encoding = string.Empty;
                //    string extension = string.Empty;

                //    StringBuilder deviceInfo = new StringBuilder();

                //    deviceInfo.Append("<DeviceInfo>");
                //    //deviceInfo.Append("<ColorDepth>32</ColorDepth>");
                //    deviceInfo.Append("<DpiX>300</DpiX>");
                //    deviceInfo.Append("<DpiY>300</DpiY>");
                //    deviceInfo.Append("<OutputFormat>BMP</OutputFormat>");
                //    //deviceInfo.Append("<MarginTop>0in</MarginTop>");
                //    //deviceInfo.Append("<MarginLeft>0in</MarginLeft>");
                //    //deviceInfo.Append("<MarginRight>0in</MarginRight>");
                //    //deviceInfo.Append("<MarginBottom>0in</MarginBottom>");
                //    //deviceInfo.Append("<PageHeight>2in</PageHeight>");
                //    //deviceInfo.Append("<PageWidth>4in</PageWidth>");
                //    deviceInfo.Append("</DeviceInfo>");



                //    byte[] bytes = this.ReportViewer1.LocalReport.Render("PDF", deviceInfo.ToString(), out mimeType, out encoding, out extension, out streamIds, out warnings);
                //    MyGlobals.reportbytes = bytes;
                //    String strfilename = System.IO.Path.GetRandomFileName();
                //    Sessionclass.setIllustrationfilename(Session, strfilename + ".pdf");
                //    using (FileStream fs = new FileStream(Server.MapPath("~/pdfoutput/") + strfilename + ".pdf", FileMode.Create))
                //    {
                //        fs.Write(bytes, 0, bytes.Length);
                //    }
                //    /*
                //    StringBuilder sb = new StringBuilder();
                //    sb.Append("<object id='pdf' data='" + "pdfoutput/" + strfilename + ".pdf" + "' type='application/pdf' width='916' height='470'>");
                //    sb.Append("<param name='src' value='" + "pdfoutput/" + strfilename + ".pdf" + "' />");
                //    sb.Append("</object>"); 
                //    this.dvpdf.InnerHtml = sb.ToString();
                //    */
                //    this.dvpdf.InnerHtml = getObjectString(strfilename);



                //}
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {

                // newdb.Dispose();

            }
            return bytes;

        }
        public static byte[] showIllustrationFUNERALfixed(WSFuneralResult funeralresult, WSCustomer customer, WSCustomerPlanFuneral customerplan, IMainfuneral funaralfixed)
        {
            byte[] bytes = null;
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            customerplan.insuredamount = funeralresult.insuredamount;
            customerplan.premiumamount = funeralresult.periodicpremiumamount;

            String productcode = "";
            rpt = new ReportViewer();
            rpt.Reset();
            ruleclasscode = customerplan.classcode.ToCharArray()[0];
            productcode = customerplan.productcode;
            ReportParameter paramOther = new ReportParameter("hideother", "Y");
            PlanName = Productdata.getProduct(customerplan.productcode);
            PlanCode = customerplan.productcode;
            // if(customerplan.rideroir.ToString().Equals("Y"))
            //{
            //    paramOther = new ReportParameter("hideother", "N");
            //}
            if (customerplan.productcode == "LUM")
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/LuminisBasico_long.rdlc");
            else if (customerplan.productcode == "LUV")
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/LuminisVIP_long.rdlc");
            else if (customerplan.productcode == "EXE")
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/ExequiumBasico_long.rdlc");
            else if (customerplan.productcode == "EXV")
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/ExequiumVIP_long.rdlc");

            ReportDataSource rds = new ReportDataSource();

            dt = new DataTable();
            dttwo = new DataTable();

            Termillusdata[] illus = funaralfixed.getIllustration();
            for (int i = 0; i < illus[0].getDatacolumns().Length; i++)
            {
                dt.Columns.Add(new DataColumn(illus[0].getDatacolumns()[i]));
            }
            for (int i = 0; i < illus.Length; i++)
            {
                dt.Rows.Add(illus[i].getDataarray());
            }



            Termillusdata[] illustwo = funaralfixed.getIllustrationtwo();
            for (int i = 0; i < illustwo[0].getDatacolumns().Length; i++)
            {
                dttwo.Columns.Add(new DataColumn(illustwo[0].getDatacolumns()[i]));
            }
            for (int i = 0; i < illustwo.Length; i++)
            {
                dttwo.Rows.Add(illustwo[i].getDataarray());
            }


            rds.Name = "illustratorDataSet_termillusdet";
            rds.Value = dt;
            ReportDataSource rdstwo = new ReportDataSource();
            rdstwo.Name = "illustratorDataSet_termtwo";
            if (dttwo.Rows.Count >= 17 && dttwo.Rows.Count <= 20 || dttwo.Rows.Count >= 37 && dttwo.Rows.Count <= 40 ||
              dttwo.Rows.Count >= 57 && dttwo.Rows.Count <= 60 || dttwo.Rows.Count >= 77 && dttwo.Rows.Count <= 80 ||
              dttwo.Rows.Count >= 97 && dttwo.Rows.Count <= 100)
            {
                if (dttwo.Rows.Count == 17 || dttwo.Rows.Count == 37 || dttwo.Rows.Count == 57 || dttwo.Rows.Count == 77 || dttwo.Rows.Count == 97)
                {
                    DataRow myRow;
                    myRow = dttwo.NewRow();
                    dttwo.Rows.Add("", "", "", "", "", "", "");
                    dttwo.Rows.Add("", "", "", "", "", "", "");
                    dttwo.Rows.Add("", "", "", "", "", "", "");
                    dttwo.Rows.Add(myRow);
                    rdstwo.Value = dttwo;
                }
                else if (dttwo.Rows.Count == 18 || dttwo.Rows.Count == 38 || dttwo.Rows.Count == 58 || dttwo.Rows.Count == 78 || dttwo.Rows.Count == 98)
                {
                    DataRow myRow;
                    myRow = dttwo.NewRow();
                    dttwo.Rows.Add("", "", "", "", "", "", "");
                    dttwo.Rows.Add("", "", "", "", "", "", "");

                    dttwo.Rows.Add(myRow);
                    rdstwo.Value = dttwo;
                }
                else if (dttwo.Rows.Count == 19 || dttwo.Rows.Count == 39 || dttwo.Rows.Count == 59 || dttwo.Rows.Count == 79 || dttwo.Rows.Count == 99)
                {
                    DataRow myRow;
                    myRow = dttwo.NewRow();
                    dttwo.Rows.Add("", "", "", "", "", "", "");

                    dttwo.Rows.Add(myRow);
                    rdstwo.Value = dttwo;
                }
                else if (dttwo.Rows.Count == 20 || dttwo.Rows.Count == 40 || dttwo.Rows.Count == 60 || dttwo.Rows.Count == 80)
                {
                    DataRow myRow;
                    myRow = dttwo.NewRow();
                    dttwo.Rows.Add(myRow);
                    rdstwo.Value = dttwo;
                }
            }
            rdstwo.Value = dttwo;
            string spouseinsuredamt = "-";


            string contributionperiod = "-";
            string termamount = "-";
            string calculate = "-";
            string freqofpayment = "-";
            string rideradbamount = "-";
            decimal annualizepremium = 0;

            decimal initialcontributionamount = 0;
            string ddlinitialcontribution = "-";
            decimal premiumamount = 0;
            string insuredamount = "-";
            string crticleillnessamount = "-";
            string maritalstatus = "-";
            string plantype = "-";
            string almillar = "-";
            string risk = "-";
            string rawreturn = "-";
            string culminationage = "-";

            if (customerplan != null)
            {
                if (customerplan.contributionperiod != null)
                {
                    contributionperiod = customerplan.contributionperiod.ToString();
                }
                rideradbamount = "";


                termamount = "";

                if (customerplan.calculatetypecode != null)
                {
                    calculate = Lookuplangdata.getLanguagevalue(Lookuptables.calculatetypedet, Calculatetypes.getcalculatetype(customerplan.calculatetypecode.ToCharArray()[0]), "es");
                }
                if (customerplan.frequencytypecode != null)
                {
                    // freqofpayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode), Sessionclass.getSessiondata(Session).language);
                    freqofpayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode.ToCharArray()[0]), "es");

                }
                if (customerplan.premiumamount != null)
                {
                    annualizepremium = Numericdata.getDecimalvalue(funeralresult.annualpremiumamount.ToString());
                }

                if (customerplan.initialcontributionamount != null)
                {
                    if (Numericdata.getDoublevalue(customerplan.initialcontributionamount.ToString()) > 0)
                    {

                        initialcontributionamount = Numericdata.getDecimalvalue(customerplan.initialcontributionamount.ToString());
                    }
                    else
                    {
                        initialcontributionamount = 0;
                    }
                }
                if (customerplan.initialcontributionamount != null)
                {
                    if (Numericdata.getDoublevalue(customerplan.initialcontributionamount.ToString()) > 0)
                    {
                        ddlinitialcontribution = Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "Yes", "es");
                    }
                    else
                    {
                        ddlinitialcontribution = Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "No", "es");

                    }
                }
                if (customerplan.premiumamount != null)
                {
                    if (Numericdata.getDoublevalue(customerplan.premiumamount.ToString()) > 0)
                    {
                        premiumamount = Numericdata.getDecimalvalue(customerplan.premiumamount.ToString());
                    }
                    else
                    {
                        premiumamount = 0;
                    }
                }
                if (customerplan.insuredamount != null)
                {
                    if (Numericdata.getDoublevalue(customerplan.insuredamount.ToString()) > 0)
                    {
                        insuredamount = customerplan.insuredamount.ToString();
                    }
                    else
                    {
                        insuredamount = "0";
                    }
                }
                crticleillnessamount = "0";
                maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet, Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es");
                plantype = Lookuplangdata.getLanguagevalue(Lookuptables.plantypedet, Plantypes.getPlantype(customerplan.plantypecode.ToCharArray()[0]), "es");


                risk = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())), "es");

                almillar = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet, Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())), "es");

                rawreturn = (Numericdata.getDecimalvalue(customerplan.initialcontributionamount.ToString()) + Frequencytypes.getfrequencytypevaluefromcode(customerplan.frequencytypecode.ToCharArray()[0]) * customerplan.contributionperiod * Numericdata.getDecimalvalue(customerplan.premiumamount.ToString())).ToString("n2");

                culminationage = (Numericdata.getIntegervalue(customerplan.contributionperiod.ToString()) + Numericdata.getIntegervalue(customer.Age.ToString()) - 1).ToString();

            }
            string rideroiramt = "0";
            string rideroirname = "-";
            string Riesgo = "-";
            string Fumador = "-";
            string Sexo = "-";
            string HastalaEdadde = "-";
            string Edad = "-";
            string AlMillar1 = "-";

            string primaryreq = "-", otherreq = "-";

            List<WSExam> exams = funeralresult.primaryexamsrequiredlist;
            String[] req = new String[20];
            //List<String> req_01 = new List<string>();


            int examno = 0;
            if (exams != null)
            {
                foreach (WSExam exam in exams)
                {
                    req[examno] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, exam.examname, "es");
                    examno++;
                }
            }
            string tempPrimary = " ";
            int lno1 = 0;

            for (int j = 0; j < req.Length; j++)
            {
                if (!string.IsNullOrEmpty(req[j]))
                    if (!req[j].Trim().Equals(""))
                    {

                        tempPrimary += req[j];
                        if (j != (req.Length - 1))
                        {
                            tempPrimary += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t";
                        }
                        if (tempPrimary.Length > (lno1 + 1) * 150)
                        {
                            tempPrimary += Environment.NewLine;
                            lno1 = lno1 + 1;
                        }

                    }
            }
            //other

            exams = funeralresult.partnerexamsrequiredlist;
            String[] oreq = new String[12];
            //List<String> req_01 = new List<string>();


            examno = 0;
            if (exams != null)
            {
                foreach (WSExam exam in exams)
                {
                    otherreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, exam.examname, "es").ToUpper() + "/" + otherreq;
                    oreq[examno] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, exam.examname, "es");
                    examno++;
                }
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            ReportParameter prmstatus1 = new ReportParameter("Color", "unchecked");
            paramlist.Add(prmstatus1);
            prmstatus1 = new ReportParameter("BN", "unchecked");
            paramlist.Add(prmstatus1);
            prmstatus1 = new ReportParameter("CompulsoryFigure", "checked");
            paramlist.Add(prmstatus1);
            string[] controllist = { "S100", "S101", "S102", "S103", "S104", "S105", "S200", "S201", "S202", "S203",
                                           "S204", "S205", "S206", "S207", "S300", "S301", "S302", "S303", "S304", "S305", "S306", "S307", "S308", "S400", "S401", "S402", "S403", "S404", "S405"
                                       , "S406", "S500", "S501", "S502", "S503", "S504", "S505"};
            for (int count1 = 0; count1 < controllist.Count(); count1++)
            {
                ReportParameter prmstatus = new ReportParameter(controllist[count1], "unchecked");
                paramlist.Add(prmstatus);
            }
            //foreach (Control ccontrol in this.pnlCustomize.Controls)
            //{
            //    if (ccontrol is CheckBox)
            //    {
            //        CheckBox myCheckbox = (CheckBox)ccontrol;
            //        if (myCheckbox.Checked == true)
            //        {
            //            ReportParameter prmstatus = new ReportParameter(myCheckbox.ID.Substring(3, myCheckbox.ID.Length - 3), "checked");
            //            paramlist.Add(prmstatus);
            //        }
            //        else
            //        {
            //            ReportParameter prmstatus = new ReportParameter(myCheckbox.ID.Substring(3, myCheckbox.ID.Length - 3), "unchecked");
            //            paramlist.Add(prmstatus);
            //        }
            //    }
            //}

            ReportParameter param100 = new ReportParameter("PolicyholderExams1", "" + tempPrimary);
            string tempOther = " ";
            //if (customerplan.rideroir.ToString().Equals("Y"))
            //{
            //    for (int j = 0; j < oreq.Length; j++)
            //    {
            //        if (!string.IsNullOrEmpty(oreq[j]))
            //            if (!oreq[j].Trim().Equals(""))
            //                tempOther += oreq[j] + ", ";
            //    }
            //}
            if (tempOther.Trim().Length > 0)
                tempOther = tempOther.Substring(0, tempOther.Length - 2);

            ReportParameter param112 = new ReportParameter("other1", "" + tempOther);


            paramlist.Add(paramOther);
            paramlist.Add(param112);
            paramlist.Add(param100);

            String[] clientsign = new string[3];
            String[] agentsign = new string[3];

            clientsign[0] = "N";
            clientsign[1] = "N";
            clientsign[2] = "N";

            agentsign[0] = "N";
            agentsign[1] = "N";
            agentsign[2] = "N";

            ReportParameter Cpath1 = new ReportParameter("clientsignpath1", "");// new ReportParameter("ClientPath1", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
            ReportParameter Apath1 = new ReportParameter("agentsignpath1", "");// new ReportParameter("AgentPath1", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
            ReportParameter Cpath2 = new ReportParameter("clientsignpath2", "");// new ReportParameter("ClientPath2", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
            ReportParameter Apath2 = new ReportParameter("agentsignpath2", "");// new ReportParameter("AgentPath2", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
            ReportParameter Cpath3 = new ReportParameter("clientsignpath3", "");// new ReportParameter("ClientPath3", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
            ReportParameter Apath3 = new ReportParameter("agentsignpath3", "");// new ReportParameter("AgentPath3", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));

            paramlist.Add(Cpath1);
            paramlist.Add(Apath1);
            paramlist.Add(Cpath2);
            paramlist.Add(Apath2);
            paramlist.Add(Cpath3);
            paramlist.Add(Apath3);

            List<rpt_compass_investment_master> st_rpt_compass_investment_master_moderado = (from item in newdb.rpt_compass_investment_masters
                                                                                             where item.ReturnType == "Moderado" && item.Region == "Americano/Internacional"
                                                                                             select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_moderado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_moderado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_moderado);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_moderado = (from item in newdb.rpt_compass_investment_details
                                                                                                   where item.ReturnTypeid == 1
                                                                                                   select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_moderado = new ReportDataSource("Charts_rpt_compass_investment_details_MODERADO", st_rpt_compass_investment_distribution_moderado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_moderado);
            List<rpt_compass_investment_master> st_rpt_compass_investment_master_balanceado = (from item in newdb.rpt_compass_investment_masters
                                                                                               where item.ReturnType == "Balanceado" && item.Region == "Americano/Internacional"
                                                                                               select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_balanceado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_balanceado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_balanceado);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_balanceado = (from item in newdb.rpt_compass_investment_details
                                                                                                     where item.ReturnTypeid == 3
                                                                                                     select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_balanceado = new ReportDataSource("Charts_rpt_compass_investment_details_BALANCEADO", st_rpt_compass_investment_distribution_balanceado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_balanceado);
            List<rpt_compass_investment_master> st_rpt_compass_investment_master_cricimiento = (from item in newdb.rpt_compass_investment_masters
                                                                                                where item.ReturnType == "Cricimiento" && item.Region == "Americano/Internacional"
                                                                                                select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_cricimiento);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_cricimiento);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_cricimiento = (from item in newdb.rpt_compass_investment_details
                                                                                                      where item.ReturnTypeid == 3
                                                                                                      select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_details_CRICIMIENTO", st_rpt_compass_investment_distribution_cricimiento);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_cricimiento);
            List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_moderado = (from item in newdb.rpt_compass_investment_masters
                                                                                                  where item.ReturnType == "Moderado" && item.Region == "Europeo"
                                                                                                  select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_euro_moderado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_moderado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_moderado);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_moderado = (from item in newdb.rpt_compass_investment_details
                                                                                                        where item.ReturnTypeid == 4
                                                                                                        select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_euro_moderado = new ReportDataSource("Charts_rpt_compass_investment_details_euro_MODERADO", st_rpt_compass_investment_distribution_euro_moderado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_moderado);
            List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_balanceado = (from item in newdb.rpt_compass_investment_masters
                                                                                                    where item.ReturnType == "Balanceado" && item.Region == "Europeo"
                                                                                                    select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_euro_balanceado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_balanceado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_balanceado);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_balanceado = (from item in newdb.rpt_compass_investment_details
                                                                                                          where item.ReturnTypeid == 5
                                                                                                          select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_euro_balanceado = new ReportDataSource("Charts_rpt_compass_investment_details_euro_BALANCEADO", st_rpt_compass_investment_distribution_euro_balanceado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_balanceado);
            List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_cricimiento = (from item in newdb.rpt_compass_investment_masters
                                                                                                     where item.ReturnType == "Cricimiento" && item.Region == "Europeo"
                                                                                                     select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_euro_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_cricimiento);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_cricimiento);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_cricimiento = (from item in newdb.rpt_compass_investment_details
                                                                                                           where item.ReturnTypeid == 6
                                                                                                           select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_euro_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_details_euro_CRICIMIENTO", st_rpt_compass_investment_distribution_euro_cricimiento);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_cricimiento);

            List<rpt_compass_investment_detail> lst_rpt_compass_investment_yearreturn_americano =
                (from item in newdb.rpt_compass_investment_details
                 join o in newdb.rpt_compass_investment_masters
                 on item.ReturnTypeid equals o.Sno
                 where (item.Years == 2010 && o.Region == "Americano/Internacional")
                 select item).ToList();

            ReportDataSource rds_rpt_compass_investment_yearreturn_americano = new ReportDataSource("Charts_rpt_compass_investment_details_yearreturn_Americano", lst_rpt_compass_investment_yearreturn_americano);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_yearreturn_americano);
            List<rpt_compass_investment_detail> lst_rpt_compass_investment_yearreturn_europeo =
                    (from item in newdb.rpt_compass_investment_details
                     join o in newdb.rpt_compass_investment_masters
                     on item.ReturnTypeid equals o.Sno
                     where (item.Years == 2010 && o.Region == "Europeo")
                     select item).ToList();

            ReportDataSource rds_rpt_compass_investment_yearreturn_europeo = new ReportDataSource("Charts_rpt_compass_investment_details_yearreturn_Europeo", lst_rpt_compass_investment_yearreturn_europeo);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_yearreturn_europeo);

            List<profile_de_inversion> lst_rpt_profile_de_inversion = (from item in newdb.profile_de_inversions
                                                                       select item).ToList();

            List<profile_de_inversion_euro> lst_rpt_profile_de_inversion_euro = (from item in newdb.profile_de_inversion_euros
                                                                                 select item).ToList();
            ReportDataSource rds_profile_de_inversion = new ReportDataSource("Charts_profile_de_inversion", lst_rpt_profile_de_inversion);
            rpt.LocalReport.DataSources.Add(rds_profile_de_inversion);
            ReportDataSource rds_profile_de_inversion_euro = new ReportDataSource("Charts_profile_de_inversion_euro", lst_rpt_profile_de_inversion_euro);
            rpt.LocalReport.DataSources.Add(rds_profile_de_inversion_euro);

            List<rpt_InvestType> lst_rpt_invest_distribution_Moderado = (from item in newdb.rpt_InvestTypes
                                                                         where item.FundCategory == "Moderado" && item.Region == "Americano/Internacional"
                                                                         select item).ToList();
            List<rpt_InvestType> lst_rpt_invest_distribution_Balanceado = (from item in newdb.rpt_InvestTypes
                                                                           where item.FundCategory == "Balanceado" && item.Region == "Americano/Internacional"
                                                                           select item).ToList();
            List<rpt_InvestType> lst_rpt_invest_distribution_Crecimiento = (from item in newdb.rpt_InvestTypes
                                                                            where item.FundCategory == "Crecimiento" && item.Region == "Americano/Internacional"
                                                                            select item).ToList();
            ReportDataSource rds_invest_distribution_Moderado = new ReportDataSource("Charts_rpt_InvestType_MODERADO", lst_rpt_invest_distribution_Moderado);
            rpt.LocalReport.DataSources.Add(rds_invest_distribution_Moderado);
            ReportDataSource rds_invest_distribution_Balanceado = new ReportDataSource("Charts_rpt_InvestType_BALANCEADO", lst_rpt_invest_distribution_Balanceado);
            rpt.LocalReport.DataSources.Add(rds_invest_distribution_Balanceado);
            ReportDataSource rds_invest_distribution_Crecimiento = new ReportDataSource("Charts_rpt_InvestType_CRECIMIENTO", lst_rpt_invest_distribution_Crecimiento);
            rpt.LocalReport.DataSources.Add(rds_invest_distribution_Crecimiento);
            List<rpt_InvestType> lst_rpt_invest_euro_distribution_Moderado = (from item in newdb.rpt_InvestTypes
                                                                              where item.FundCategory == "Moderado" && item.Region == "Europeo"
                                                                              select item).ToList();
            ReportDataSource rds_invest_euro_distribution_Moderado = new ReportDataSource("Charts_rpt_euro_InvestType_MODERADO", lst_rpt_invest_euro_distribution_Moderado);
            rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Moderado);
            List<rpt_InvestType> lst_rpt_invest_euro_distribution_Balanceado = (from item in newdb.rpt_InvestTypes
                                                                                where item.FundCategory == "Balanceado" && item.Region == "Europeo"
                                                                                select item).ToList();
            ReportDataSource rds_invest_euro_distribution_Balanceado = new ReportDataSource("Charts_rpt_euro_InvestType_BALANCEADO", lst_rpt_invest_euro_distribution_Balanceado);
            rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Balanceado);
            List<rpt_InvestType> lst_rpt_invest_euro_distribution_Crecimiento = (from item in newdb.rpt_InvestTypes
                                                                                 where item.FundCategory == "Crecimiento" && item.Region == "Europeo"
                                                                                 select item).ToList();
            ReportDataSource rds_invest_euro_distribution_Crecimiento = new ReportDataSource("Charts_rpt_euro_InvestType_CRECIMIENTO", lst_rpt_invest_euro_distribution_Crecimiento);
            rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Crecimiento);
            var totMonderadoBond = from mb in lst_rpt_invest_distribution_Moderado
                                   where mb.FundType == "Bond" && mb.FundCategory == "Moderado"
                                   group mb by mb.FundCategory into g
                                   select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var totMonderadoStock = from ms in lst_rpt_invest_distribution_Moderado
                                    where ms.FundType == "Stock" && ms.FundCategory == "Moderado"
                                    group ms by ms.FundCategory into g
                                    select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };



            ReportParameter prmMonderadoBondShare = new ReportParameter("MonderadoBondShare", totMonderadoBond.First().total.ToString());
            paramlist.Add(prmMonderadoBondShare);
            ReportParameter prmMonderadoStockShare = new ReportParameter("MonderadoStockShare", totMonderadoStock.First().total.ToString());
            paramlist.Add(prmMonderadoStockShare);
            var totBalanceadoBond = from mb in lst_rpt_invest_distribution_Balanceado
                                    where mb.FundType == "Bond" && mb.FundCategory == "Balanceado"
                                    group mb by mb.FundCategory into g
                                    select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var totBalanceadoStock = from ms in lst_rpt_invest_distribution_Balanceado
                                     where ms.FundType == "Stock" && ms.FundCategory == "Balanceado"
                                     group ms by ms.FundCategory into g
                                     select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

            ReportParameter prmBalanceadoBondShare = new ReportParameter("BalanceadoBondShare", totBalanceadoBond.First().total.ToString());
            paramlist.Add(prmBalanceadoBondShare);
            ReportParameter prmBalanceadoStockShare = new ReportParameter("BalanceadoStockShare", totBalanceadoStock.First().total.ToString());
            paramlist.Add(prmBalanceadoStockShare);




            var totCrecimientoBond = from mb in lst_rpt_invest_distribution_Crecimiento
                                     where mb.FundType == "Bond" && mb.FundCategory == "Crecimiento"
                                     group mb by mb.FundCategory into g
                                     select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var totCrecimientoStock = from ms in lst_rpt_invest_distribution_Crecimiento
                                      where ms.FundType == "Stock" && ms.FundCategory == "Crecimiento"
                                      group ms by ms.FundCategory into g
                                      select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

            string shareCrecimientoBond;
            if (totCrecimientoBond.FirstOrDefault() != null)
            {
                shareCrecimientoBond = Convert.ToString(totCrecimientoBond.FirstOrDefault().total);
            }
            else
            {
                shareCrecimientoBond = "0";
            }

            ReportParameter prmCrecimientoBondShare = new ReportParameter("CrecimientoBondShare", shareCrecimientoBond);
            paramlist.Add(prmCrecimientoBondShare);
            ReportParameter prmCrecimientoStockShare = new ReportParameter("CrecimientoStockShare", totCrecimientoStock.First().total.ToString());
            paramlist.Add(prmCrecimientoStockShare);

            var euro_totBalanceadoBond = from mb in lst_rpt_invest_euro_distribution_Balanceado
                                         where mb.FundType == "Bond" && mb.FundCategory == "Balanceado"
                                         group mb by mb.FundCategory into g
                                         select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var euro_totBalanceadoStock = from ms in lst_rpt_invest_euro_distribution_Balanceado
                                          where ms.FundType == "Stock" && ms.FundCategory == "Balanceado"
                                          group ms by ms.FundCategory into g
                                          select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

            ReportParameter euro_prmBalanceadoBondShare = new ReportParameter("euro_BalanceadoBondShare", euro_totBalanceadoBond.First().total.ToString());
            paramlist.Add(euro_prmBalanceadoBondShare);
            ReportParameter euro_prmBalanceadoStockShare = new ReportParameter("euro_BalanceadoStockShare", euro_totBalanceadoStock.First().total.ToString());
            paramlist.Add(euro_prmBalanceadoStockShare);

            var euro_totMonderadoBond = from mb in lst_rpt_invest_euro_distribution_Moderado
                                        where mb.FundType == "Bond" && mb.FundCategory == "Moderado"
                                        group mb by mb.FundCategory into g
                                        select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var euro_totMonderadoStock = from ms in lst_rpt_invest_euro_distribution_Moderado
                                         where ms.FundType == "Stock" && ms.FundCategory == "Moderado"
                                         group ms by ms.FundCategory into g
                                         select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

            ReportParameter euro_prmMonderadoBondShare = new ReportParameter("euro_MonderadoBondShare", euro_totMonderadoBond.First().total.ToString());
            paramlist.Add(euro_prmMonderadoBondShare);
            ReportParameter euro_prmMonderadoStockShare = new ReportParameter("euro_MonderadoStockShare", euro_totMonderadoStock.First().total.ToString());
            paramlist.Add(euro_prmMonderadoStockShare);

            var euro_totCrecimientoBond = from mb in lst_rpt_invest_distribution_Crecimiento
                                          where mb.FundType == "Bond" && mb.FundCategory == "Crecimiento"
                                          group mb by mb.FundCategory into g
                                          select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var euro_totCrecimientoStock = from ms in lst_rpt_invest_distribution_Crecimiento
                                           where ms.FundType == "Stock" && ms.FundCategory == "Crecimiento"
                                           group ms by ms.FundCategory into g
                                           select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };




            string euro_shareCrecimientoBond;
            if (totCrecimientoBond.FirstOrDefault() != null)
            {
                euro_shareCrecimientoBond = Convert.ToString(euro_totCrecimientoBond.FirstOrDefault().total);
            }
            else
            {
                euro_shareCrecimientoBond = "0";
            }

            ReportParameter euro_prmCrecimientoBondShare = new ReportParameter("euro_CrecimientoBondShare", euro_shareCrecimientoBond);
            paramlist.Add(euro_prmCrecimientoBondShare);
            ReportParameter euro_prmCrecimientoStockShare = new ReportParameter("euro_CrecimientoStockShare", euro_totCrecimientoStock.First().total.ToString());
            paramlist.Add(euro_prmCrecimientoStockShare);



            List<rpt_lifeexpectancy> rpt_Life_Expectancy = (from item in newdb.rpt_lifeexpectancies
                                                            select item).ToList();


            decimal MaxAge = 0;
            if (customer.gendercode.ToString() == "M")
            {
                MaxAge = Convert.ToDecimal((from item in rpt_Life_Expectancy where item.Current_Age == 0 select item.Men).First());
            }
            else if (customer.gendercode.ToString() == "F")
            {
                MaxAge = Convert.ToDecimal((from item in rpt_Life_Expectancy where item.Current_Age == 0 select item.Woman).First());
            }

            //decimal LifeExpectancy = MaxAge - Convert.ToDecimal(customer.Age);

            ReportParameter param110 = new ReportParameter("LifeExpectancy", (MaxAge - Convert.ToDecimal(customer.Age)).ToString());
            paramlist.Add(param110);
            ReportDataSource lifeexpetancy = new ReportDataSource("Charts_rpt_lifeexpectancy", rpt_Life_Expectancy);
            rpt.LocalReport.DataSources.Add(lifeexpetancy);

            string Prospect = (((customer.FirstName + " " + customer.MiddleName).Trim() + " " + customer.LastName).Trim() + " " + customer.LastName2).Trim();
            if (PlanName == "")
            {
                const int MaxLengthHeading = 30;
                const int MaxLengthName = 50;
                var custHeading = (customer.FirstName + " " + customer.LastName).Trim();
                var custName = (customer.FirstName + " " + customer.LastName).Trim();
                if (custHeading.Length > MaxLengthHeading)
                {
                    custHeading = custHeading.Substring(0, MaxLengthHeading);
                    custHeading = custHeading + "...";
                }
                if (custName.Length > MaxLengthName)
                {
                    custName = custName.Substring(0, MaxLengthName);
                    custName = custName + "...";
                }
                ReportParameter param1 = new ReportParameter("heading", custHeading);
                ReportParameter param3 = new ReportParameter("name", custName);
                paramlist.Add(param1);
                paramlist.Add(param3);
            }
            else
            {
                const int MaxLengthHeading = 25;
                const int MaxLengthName = 50;
                var custHeading = (customer.FirstName + " " + customer.LastName).Trim();
                var custName = (customer.FirstName + " " + customer.LastName).Trim();
                if (custHeading.Length > MaxLengthHeading)
                {
                    custHeading = custHeading.Substring(0, MaxLengthHeading);
                    custHeading = custHeading + "...";
                }
                if (custName.Length > MaxLengthName)
                {
                    custName = custName.Substring(0, MaxLengthName);
                    custName = custName + "...";
                }
                ReportParameter param1 = new ReportParameter("heading", custHeading);
                ReportParameter param3 = new ReportParameter("name", custName);
                paramlist.Add(param1);
                paramlist.Add(param3);
            }


            ReportParameter param135 = new ReportParameter("lastname", customer.LastName.ToString());
            paramlist.Add(param135);
            //ReportParameter param2 = new ReportParameter("date", DateTime.Now.ToShortDateString());

            ReportParameter param4 = new ReportParameter("periodofcontribution", customerplan.contributionperiod + "");
            //ReportParameter param5 = new ReportParameter("amountofcontribution", GetFormatedText(customerplan.initialcontribution + ""));
            ReportParameter param5 = new ReportParameter("amountofcontribution", GetFormatedText(initialcontributionamount.ToString()));
            ReportParameter param6 = new ReportParameter("premiumamount", premiumamount.ToString("n2"));
            ReportParameter param7 = new ReportParameter("withdrawalamount", GetFormatedText(insuredamount));

            //ReportParameter param8 = new ReportParameter("plantype", plantype + "");//Plantypes.getPlantype(customerplan.plantypecode));
            ReportParameter param8 = new ReportParameter("plantype", "Temporal" + "");//Plantypes.getPlantype(customerplan.plantypecode));

            ReportParameter param9 = new ReportParameter("age", customer.Age + "");
            ReportParameter param10 = new ReportParameter("gender", customer.gendercode + "");//Genders.getgender(customer.gendercode));
            ReportParameter param11 = new ReportParameter("smoker", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, Booleandata.getBooleanstring(customer.Smoker.ToCharArray()[0]), "es"));

            ReportParameter param12 = new ReportParameter("ageatretirement", customerplan.contributionuntilage + "");
            ReportParameter param13 = new ReportParameter("risk", risk);//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
            ReportParameter param14 = new ReportParameter("almillar", almillar);//Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())));
            ReportParameter param15 = new ReportParameter("maritalstatus", maritalstatus);//Maritalstatus.getmaritalstatus(customer.MaritalStatuscode.Value));
            //ReportParameter param16 = new ReportParameter("suminsured", ((String.Format("{0:n0}", Numericdata.getDoublevalue((customerplan.insuredamount + customerplan.ridertermamount).ToString())).Replace('.', '/')).Replace(',', '.')).Replace('/', ','));
            ReportParameter param16 = new ReportParameter("suminsured", customerplan.insuredamount.ToString("n2"));
            ReportParameter param17 = new ReportParameter("annualpremium", annualizepremium.ToString("n2"));
            ReportParameter param18 = new ReportParameter("period", freqofpayment);
            ReportParameter param19 = new ReportParameter("calcular", calculate);
            //ReportParameter param20 = new ReportParameter("additionaltemporary", Booleandata.getBooleanstring(customerplan.riderterm));
            ReportParameter param20 = new ReportParameter("additionaltemporary", "");
            ReportParameter param21;
            if (customerplan.classcode.ToString().Equals("R"))
            {
                param21 = new ReportParameter("kind", "RD$");
            }
            else
            {
                param21 = new ReportParameter("kind", customerplan.classcode.ToString());
            }
            ReportParameter param22 = new ReportParameter("country", Lookuplangdata.getLanguagevalue(Lookuptables.countrydet, Countries.getcountry(Numericdata.getIntegervalue(customerplan.countryno.ToString() + "")), Langdata.LANGUAGE_SPANISH));//Sessionclass.getSessiondata(Session).language));
            ReportParameter param23 = new ReportParameter("initialcontribution", ddlinitialcontribution);

            //ReportParameter param24 = new ReportParameter("accidentaldeath", Booleandata.getBooleanstring(customerplan.rideradb));

            ReportParameter param24 = new ReportParameter("accidentaldeath", "");

            ReportParameter param25 = new ReportParameter("spouceinsurance", rideroirname);
            ReportParameter param26 = new ReportParameter("primatarget", funeralresult.targetpremiumamount.ToString("n2"));
            ReportParameter param27 = new ReportParameter("timeinsurance", contributionperiod);
            ReportParameter param28 = new ReportParameter("financialgoals", customerplan.financialgoal + "");
            ReportParameter param29 = new ReportParameter("plan", Productdata.getProduct(customerplan.productcode));
            //ReportParameter param120_1 = new ReportParameter("date", getspanishmonth(DateTime.Now.ToString("MMMM")) + " " + DateTime.Now.ToString("dd, yyyy"));
            ReportParameter param120_1 = new ReportParameter("date", getspanishmonth(Int32.Parse(DateTime.Now.ToString("MM"))) + " " + DateTime.Now.ToString("dd, yyyy"));
            paramlist.Add(param120_1);
            //ReportParameter param30 = new ReportParameter("descriptionline", Generalmethods.getDescriptionline(Productdata.getProduct(customerplan.productcode), initialcontributionamount));
            ReportParameter param81 = new ReportParameter("class", customerplan.classcode.ToString());
            paramlist.Add(param81);
            ReportParameter paramsib = new ReportParameter("suminsuredbase", (customerplan.insuredamount.ToString("n2")));
            paramlist.Add(paramsib);

            string investmentprofile = "-";
            ReportParameter param26_12 = new ReportParameter("investmentprofile", investmentprofile + "");
            paramlist.Add(param26_12);
            ReportParameter param76_12 = new ReportParameter("PaymentFrequency", freqofpayment);
            paramlist.Add(param76_12);
            string desc = "";
            string desc1 = "";

            //// if (customerplan.productcode.Equals("LGT"))
            //desc = Generalmethods.getLightHouseDescriptionline(contributionperiod, Productdata.getProduct(customerplan.productcode));
            desc = Generalmethods.getFuneralDescriptionline(customerplan.insuredamount.ToString(), Productdata.getProduct(customerplan.productcode), customerplan.productcode.ToString());
            //  else if (customerplan.productcode.Equals("SNT"))
            // desc = Generalmethods.getSentinalDescriptionline(contributionperiod);


            ReportParameter param30 = new ReportParameter("descriptionline", desc);


            ReportParameter param31 = new ReportParameter("lastline", Generalmethods.getLastlineFuneral(Prospect, new Random().Next(1, 20), customerplan.classcode.ToString().ToCharArray()[0]));

            ReportParameter param33 = new ReportParameter("InitialContributionAmount", initialcontributionamount.ToString("n2"));
            ReportParameter param34 = new ReportParameter("Temporal", "-");
            ReportParameter param35 = new ReportParameter("PeriodoContribucion1", "-");
            ReportParameter param63 = new ReportParameter("PolicyholderSubscriptionRequirements", primaryreq);
            ReportParameter param64 = new ReportParameter("UnderwritingRequirementsAdditionalInsured", otherreq);
            ReportParameter param65 = new ReportParameter("Riesgo", Riesgo);
            ReportParameter param66 = new ReportParameter("AlMillar1", AlMillar1);
            ReportParameter param67 = new ReportParameter("Edad", Edad);
            ReportParameter param68 = new ReportParameter("Fumador", Fumador);
            ReportParameter param69 = new ReportParameter("Sexo", Sexo);
            ReportParameter param70 = new ReportParameter("ForYears", HastalaEdadde);
            ReportParameter param71 = new ReportParameter("HastalaEdadde", HastalaEdadde);
            ReportParameter param72 = new ReportParameter("AccidentalAmount", GetFormatedText(rideradbamount));
            ReportParameter param73 = new ReportParameter("TemporalAdicionalForYears", "");
            ReportParameter param74 = new ReportParameter("TemporalAdicionalAmount", "");
            ReportParameter param75 = new ReportParameter("criticleillness", Booleandata.getBooleanstring(' '));
            ReportParameter param76 = new ReportParameter("BottomText", "Esta propuesta es válida por 15 días y en  ningún caso más allá del " + DateTime.DaysInMonth(DateTime.Now.Year, 12) + "/" + 12 + "/" + DateTime.Now.Year + " (v2)");
            ReportParameter param77 = new ReportParameter("rideroiramount", (rideroiramt));
            ReportParameter param78 = new ReportParameter("ValueAccount", "-");
            ReportParameter param82 = new ReportParameter("foryear", "Por Años");
            ReportParameter param83 = new ReportParameter("withdrawalperiod", "-");
            ReportParameter param84 = new ReportParameter("rideroirname", rideroirname);
            ReportParameter param85 = new ReportParameter("crticleillnessamount", GetFormatedText(crticleillnessamount));


            ReportParameter param308 = new ReportParameter("S308", "unchecked");
            paramlist.Add(param308);
            ReportParameter param124 = new ReportParameter("number", "");//txtnumber.Text);
            ReportParameter param125 = new ReportParameter("culminationage", culminationage + "");
            ReportParameter param126 = null;
            //if (customerplan.rideroir.ToString() == "N")
            //{
            param126 = new ReportParameter("rideroir", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "No", "es"));
            //}
            //else
            //{
            //    param126 = new ReportParameter("rideroir", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "Yes", "es"));
            //}

            ReportParameter param127 = new ReportParameter("Impuesto", funeralresult.Tax.ToString("n2"));
            ReportParameter param128 = new ReportParameter("primatotal", funeralresult.TotalPeriodicPremium.ToString("n2"));
            ReportParameter param129 = new ReportParameter("Totalsuminsured", Numericdata.getDoublevalue((customerplan.insuredamount.ToString() + "").ToString()).ToString("n2"));


            ReportParameter paramcnp = new ReportParameter("contributionperiod", "PERÍODO INICIAL:" + " " + customerplan.contributionperiod + "Años - Prima Nivelada Garantizada");
            paramlist.Add(paramcnp);


            if (customerplan.productcode.Equals("GRD") || customerplan.productcode.Equals("GRP") || customerplan.productcode.Equals("EXV") || customerplan.productcode.Equals("EXE"))
            {
                ReportParameter paramrop = new ReportParameter("returnamount", rawreturn);
                paramlist.Add(paramrop);

            }

            // paramlist.Add(param2);

            paramlist.Add(param4);
            paramlist.Add(param5);
            paramlist.Add(param6);
            paramlist.Add(param7);
            paramlist.Add(param8);
            paramlist.Add(param9);
            paramlist.Add(param10);
            paramlist.Add(param11);
            paramlist.Add(param12);
            paramlist.Add(param13);
            paramlist.Add(param14);
            paramlist.Add(param15);
            paramlist.Add(param16);
            paramlist.Add(param17);
            paramlist.Add(param18);
            paramlist.Add(param19);
            paramlist.Add(param20);
            paramlist.Add(param21);
            paramlist.Add(param22);
            paramlist.Add(param23);
            paramlist.Add(param24);
            paramlist.Add(param25);
            paramlist.Add(param26);
            paramlist.Add(param27);
            paramlist.Add(param28);
            paramlist.Add(param29);
            paramlist.Add(param30);

            paramlist.Add(param31);
            paramlist.Add(param33);
            paramlist.Add(param34);
            paramlist.Add(param35);
            paramlist.Add(param63);
            paramlist.Add(param64);
            paramlist.Add(param65);
            paramlist.Add(param66);
            paramlist.Add(param67);
            paramlist.Add(param68);
            paramlist.Add(param69);
            paramlist.Add(param70);
            paramlist.Add(param71);
            paramlist.Add(param72);
            paramlist.Add(param73);
            paramlist.Add(param74);
            paramlist.Add(param75);
            paramlist.Add(param76);
            paramlist.Add(param77);
            paramlist.Add(param78);
            paramlist.Add(param83);
            paramlist.Add(param84);
            paramlist.Add(param82);
            paramlist.Add(param85);
            paramlist.Add(param124);
            paramlist.Add(param125);
            paramlist.Add(param126);
            paramlist.Add(param127);
            paramlist.Add(param128);
            paramlist.Add(param129);

            //ReportParameter param504 = new ReportParameter("S504", "unchecked");
            //paramlist.Add(param504);


            List<rpt_investments_inflacion> rpt_investment = (from item in newdb.rpt_investments_inflacions
                                                              select item).ToList();
            var count = rpt_investment.Count();
            var inflation_Last = (from ms in rpt_investment
                                  select new { ms.Pequenas_Acciones, ms.Grandes_Acciones, ms.Papelesdel_Tesoro, ms.Bonosdel_Gobierno, ms.Inflacion }).Last();
            var inflation_first = (from ms in rpt_investment
                                   select new { ms.Pequenas_Acciones, ms.Grandes_Acciones, ms.Papelesdel_Tesoro, ms.Bonosdel_Gobierno, ms.Inflacion }).First();
            var percent_Pequenas_last = inflation_Last.Pequenas_Acciones;
            var percent_Pequenas_First = inflation_first.Pequenas_Acciones;
            var Grandes_Acciones_last = inflation_Last.Grandes_Acciones;
            var Grandes_Acciones_First = inflation_first.Grandes_Acciones;
            var Papelesdel_Tesoro_last = inflation_Last.Papelesdel_Tesoro;
            var Papelesdel_Tesoro_First = inflation_first.Papelesdel_Tesoro;
            var Bonosdel_Gobierno_last = inflation_Last.Bonosdel_Gobierno;
            var Bonosdel_Gobierno_First = inflation_first.Bonosdel_Gobierno;
            var Inflacion1_last = inflation_Last.Inflacion;
            var Inflacion1_First = inflation_first.Inflacion;


            var result_total = percent_Pequenas_last / percent_Pequenas_First;
            var numberofyears = 0.0119;
            var Pequenas_percent = (Math.Pow(Convert.ToDouble(result_total), numberofyears) - 1) * 100;

            var result1_total = Grandes_Acciones_last / Grandes_Acciones_First;
            var numberofyears1 = 0.0119;
            var Grandes_percent = (Math.Pow(Convert.ToDouble(result1_total), numberofyears1) - 1) * 100;

            var result2_total = Papelesdel_Tesoro_last / Papelesdel_Tesoro_First;
            var numberofyears2 = 0.0119;
            var Papelesdel_percent = (Math.Pow(Convert.ToDouble(result2_total), numberofyears2) - 1) * 100;

            var result3_total = Bonosdel_Gobierno_last / Bonosdel_Gobierno_First;
            var numberofyears3 = 0.0119;
            var Bonosdel_percent = (Math.Pow(Convert.ToDouble(result3_total), numberofyears3) - 1) * 100;

            var result4_total = Inflacion1_last / Inflacion1_First;
            var numberofyears4 = 0.0119;
            var Inflacion_percent = (Math.Pow(Convert.ToDouble(result4_total), numberofyears4) - 1) * 100;


            ReportParameter Pequenas_Acciones = new ReportParameter("Pequenas_Acciones", Pequenas_percent.ToString());
            ReportParameter Grandes = new ReportParameter("Grandes", Grandes_percent.ToString());
            ReportParameter Papelesdel_Tesoro = new ReportParameter("Papelesdel_Tesoro", Papelesdel_percent.ToString());
            ReportParameter Bonosdel_Gobierno = new ReportParameter("Bonosdel_Gobierno", Bonosdel_percent.ToString());
            ReportParameter Inflacion = new ReportParameter("Inflacion", Inflacion_percent.ToString());
            paramlist.Add(Pequenas_Acciones);
            paramlist.Add(Grandes);
            paramlist.Add(Papelesdel_Tesoro);
            paramlist.Add(Bonosdel_Gobierno);
            paramlist.Add(Inflacion);

            if (PlanName.Equals("Sentinel"))
            {
                ReportParameter param30_12 = new ReportParameter("descriptionline1", desc1);
                paramlist.Add(param30_12);

            }

            string untilAge = "-";


            ReportParameter paramAdditionalTermUntilAge = new ReportParameter("AdditionalTermUntilAge", untilAge);

            paramlist.Add(paramAdditionalTermUntilAge);


            maritalstatus = "-";

            ReportParameter paramSpouseMaritalStatus = new ReportParameter("SpouseMaritalStatus", maritalstatus);
            paramlist.Add(paramSpouseMaritalStatus);

            string temp = "-";


            // ReportParameter paramRiderAmount1 = new ReportParameter("RiderAmount1", temp);
            temp = "-";


            //ReportParameter paramRiderAmount2 = new ReportParameter("RiderAmount2", temp);

            string partinsRiderOirAmount = "-";


            //ReportParameter paramRiderAmount3 = new ReportParameter("RiderAmount3", partinsRiderOirAmount);

            untilAge = "-";


            if (untilAge.Equals("0"))
                untilAge = "-";

            string untilAge2 = "-";


            if (untilAge2.Equals("0"))
                untilAge2 = "-";
            List<rpt_Compass_Slide5> rpt_Compass_Slide5 = (from item in newdb.rpt_Compass_Slide5s
                                                           select item).ToList();
            List<rpt_Compass_slide7> Compass_slide7 = (from item in newdb.rpt_Compass_slide7s
                                                       select item).ToList();

            foreach (rpt_Compass_slide7 item in Compass_slide7)
            {
                if (item.Continent == "Europa")
                {
                    ReportParameter param60 = new ReportParameter("Europe_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param61 = new ReportParameter("Europe_Area", item.Area.ToString() + " Km2");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param60);
                    paramlist.Add(param61);
                }
                else if (item.Continent == "Mediterráneo Oriental")
                {
                    ReportParameter param62 = new ReportParameter("Eastern_Mediterranean_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param130 = new ReportParameter("Eastern_Mediterranean_Area", item.Area.ToString() + " Km2");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param62);
                    paramlist.Add(param130);
                }
                else if (item.Continent == "Pacífico Occidental")
                {
                    ReportParameter param131 = new ReportParameter("Pacífico_Occidental_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param132 = new ReportParameter("Pacífico_Occidental_Area", item.Area.ToString() + " Km2");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param131);
                    paramlist.Add(param132);
                }
                else if (item.Continent == "Asia Sur Oriental")
                {
                    ReportParameter param133 = new ReportParameter("Asia_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param105 = new ReportParameter("Asia_Area", item.Area.ToString());//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param133);
                    paramlist.Add(param105);
                }
                else if (item.Continent == "Centro y Suramérica")
                {
                    ReportParameter param106 = new ReportParameter("america_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param107 = new ReportParameter("america_Area", item.Area.ToString() + " Km2");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param106);
                    paramlist.Add(param107);
                }
                else if (item.Continent == "Africa")
                {
                    ReportParameter param108 = new ReportParameter("Africa_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param109 = new ReportParameter("Africa_Area", item.Area.ToString() + " Km2");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param108);
                    paramlist.Add(param109);
                }
            }

            string sup = "";
            if (customerplan.Familiar.ToString() != "N" || customerplan.Repatriacion.ToString() != "N" || customerplan.SepulturaLote.ToString() != "N")
            {
                //sup = Generalmethods.getsuplementosline(customerplan.rideradb.ToString(), customerplan.riderterm.ToString(), customerplan.rideroir.ToString(), customerplan.rideradbamount != null ? Program.getCurrencyString(ruleclasscode,double.Parse( customerplan.rideradbamount.ToString())) : "", customerplan.ridertermamount != null ? Program.getCurrencyString(ruleclasscode, double.Parse(customerplan.ridertermamount.ToString())) : "",partins!=null? partins.rideroiramount!=null? Program.getCurrencyString(ruleclasscode,double.Parse( partins.rideroiramount.ToString())):"":"", untilAge, HastalaEdadde);
                sup = Generalmethods.getsuplementoslineFuneral(customerplan.Familiar.ToString(), customerplan.Repatriacion.ToString(), customerplan.SepulturaLote.ToString());
            }
            else
            {
                sup = "Este Plan no tiene coberturas adicionales.";
            }
            ReportParameter param134 = new ReportParameter("suplementos", sup);
            paramlist.Add(param134);
            ReportParameter param138 = null;
            if (customerplan.Familiar.ToString() == "N")
            {
                param138 = new ReportParameter("Familiar", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "No", "es"));
            }
            else
            {
                param138 = new ReportParameter("Familiar", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "Yes", "es"));
            }
            paramlist.Add(param138);
            ReportParameter param136 = null;
            if (customerplan.Repatriacion.ToString() == "N")
            {
                param136 = new ReportParameter("Repatriacion", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "No", "es"));
            }
            else
            {
                param136 = new ReportParameter("Repatriacion", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "Yes", "es"));
            }
            paramlist.Add(param136);
            ReportParameter param137 = null;
            if (customerplan.SepulturaLote.ToString() == "N")
            {
                param137 = new ReportParameter("SepulturaLote", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "No", "es"));
            }
            else if (customerplan.SepulturaLote.ToString() == "P")
            {
                param137 = new ReportParameter("SepulturaLote", Lookuplangdata.getLanguagevalue(Lookuptables.SepulturaLotedet, "Public", "es"));
            }
            else if (customerplan.SepulturaLote.ToString() == "R")
            {
                param137 = new ReportParameter("SepulturaLote", Lookuplangdata.getLanguagevalue(Lookuptables.SepulturaLotedet, "Private", "es"));
            }
            paramlist.Add(param137);

            ReportDataSource Compassslide7 = new ReportDataSource("Charts_rpt_Compass_slide7", Compass_slide7);

            ReportDataSource Compassslide5 = new ReportDataSource("Charts_rpt_Compass_Slide5", rpt_Compass_Slide5);
            //ReportDataSource axysslide5 = new ReportDataSource("Charts_rpt_axys_slide5", rpt_axys_slide5);
            //ReportDataSource axysslide8 = new ReportDataSource("Charts_rpt_axys_slide8", rpt_axys_slide8);
            //ReportDataSource axysslide6 = new ReportDataSource("Charts_rpt_axys_slide6", rpt_axys_slide6);
            //ReportDataSource axysslide12_1 = new ReportDataSource("Charts_rpt_Axys_fixedincome_slide12", rpt_Axys_fixedincome_slide12);
            //ReportDataSource axysslide12_2 = new ReportDataSource("Charts_rpt_Axys_lowrisk_slide12", rpt_Axys_lowrisk_slide12);
            //ReportDataSource axysslide12_3 = new ReportDataSource("Charts_rpt_Axys_Highperform_slide12", rpt_Axys_Highperform_slide12);
            //ReportDataSource axysslide11 = new ReportDataSource("Charts_rpt_Axys_slide11", rpt_Axys_slide11);



            rpt.LocalReport.DataSources.Add(Compassslide5);
            rpt.LocalReport.DataSources.Add(Compassslide7);



            rpt.LocalReport.EnableExternalImages = true;
            rpt.LocalReport.SetParameters(paramlist);

            rpt.LocalReport.DataSources.Add(rds);
            rpt.LocalReport.DataSources.Add(rdstwo);
            rpt.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            bytes = rpt.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            //if (classicmode == true)
            //{
            //    dvReport.Visible = true;
            //    dvpdf.Visible = false;
            //    this.ReportViewer1.LocalReport.Refresh();
            //}
            //else if (customize == false)
            //{
            //    dvpdf.Visible = true;
            //    dvReport.Visible = false;
            //    Warning[] warnings;
            //    string[] streamIds;
            //    string mimeType = string.Empty;
            //    string encoding = string.Empty;
            //    string extension = string.Empty;
            //    byte[] bytes = this.ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            //    MyGlobals.reportbytes = bytes;
            //    String strfilename = System.IO.Path.GetRandomFileName();
            //    Sessionclass.setIllustrationfilename(Session, strfilename + ".pdf");
            //    using (FileStream fs = new FileStream(Server.MapPath("~/pdfoutput/") + strfilename + ".pdf", FileMode.Create))
            //    {
            //        fs.Write(bytes, 0, bytes.Length);
            //    }
            //    /*
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append("<object data='" + "pdfoutput/" + strfilename + ".pdf" + "' type='application/pdf' width='916' height='470'>");
            //    sb.Append("</object>");
            //    this.dvpdf.InnerHtml = sb.ToString();
            //     */
            //    this.dvpdf.InnerHtml = getObjectString(strfilename);

            //}
            return bytes;

        }

        public static byte[] showIllustrationTERMfixed(WSTermResult termresult, WSCustomer customer, WSCustomerPlan customerplan, IMaintermfixed termfixed, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            byte[] bytes = null;
            DataVOUniversalDataContext newdb = Program.getDbConnection();

            customerplan.insuredamount = termresult.insuredamount;
            customerplan.premiumamount = termresult.periodicpremiumamount;


            String productcode = "";
            rpt = new ReportViewer();
            rpt.LocalReport.Refresh();
            rpt.Reset();
            ruleclasscode = customerplan.classcode.ToCharArray()[0];
            productcode = customerplan.productcode;
            ReportParameter paramOther = new ReportParameter("hideother", "Y");
            if (partins != null)
            {
                paramOther = new ReportParameter("hideother", "N");
            }
            PlanName = Productdata.getProduct(customerplan.productcode);
            PlanCode = customerplan.productcode;
            if (PlanName.Equals("Lighthouse"))
            {
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/LightHouse_long.rdlc");

            }
            else if (PlanName.Equals("Sentinel"))
            {
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/Sentinel_long.rdlc");
            }
            else if (PlanName.Equals("Orion"))
            {

                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/Orion_long.rdlc");

            }
            else if (PlanName.Equals("Orion Plus"))
            {

                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/OrionPlus_long.rdlc");

            }
            else if (PlanName.Equals("Guardian"))
            {

                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/Guardian_long.rdlc");

            }
            else if (PlanName.Equals("Guardian Plus"))
            {

                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/GuardianPlus_long.rdlc");

            }

            ReportDataSource rds = new ReportDataSource();
            dt = new DataTable();
            dttwo = new DataTable();
            Termillusdata[] illus = termfixed.getIllustration();
            for (int i = 0; i < illus[0].getDatacolumns().Length; i++)
            {
                dt.Columns.Add(new DataColumn(illus[0].getDatacolumns()[i]));
            }
            for (int i = 0; i < illus.Length; i++)
            {
                dt.Rows.Add(illus[i].getDataarray());
            }



            Termillusdata[] illustwo = termfixed.getIllustrationtwo();
            for (int i = 0; i < illustwo[0].getDatacolumns().Length; i++)
            {
                dttwo.Columns.Add(new DataColumn(illustwo[0].getDatacolumns()[i]));
            }
            for (int i = 0; i < illustwo.Length; i++)
            {
                dttwo.Rows.Add(illustwo[i].getDataarray());
            }

            //rds.
            rds.Name = "illustratorDataSet_termillusdet";

            rds.Value = dt;

            ReportDataSource rdstwo = new ReportDataSource();
            rdstwo.Name = "illustratorDataSet_termtwo";
            if (dttwo.Rows.Count >= 17 && dttwo.Rows.Count <= 20 || dttwo.Rows.Count >= 37 && dttwo.Rows.Count <= 40 ||
              dttwo.Rows.Count >= 57 && dttwo.Rows.Count <= 60 || dttwo.Rows.Count >= 77 && dttwo.Rows.Count <= 80 ||
              dttwo.Rows.Count >= 97 && dttwo.Rows.Count <= 100)
            {
                if (dttwo.Rows.Count == 17 || dttwo.Rows.Count == 37 || dttwo.Rows.Count == 57 || dttwo.Rows.Count == 77 || dttwo.Rows.Count == 97)
                {
                    DataRow myRow;
                    myRow = dttwo.NewRow();
                    dttwo.Rows.Add("", "", "", "", "", "", "");
                    dttwo.Rows.Add("", "", "", "", "", "", "");
                    dttwo.Rows.Add("", "", "", "", "", "", "");
                    dttwo.Rows.Add(myRow);
                    rdstwo.Value = dttwo;
                }
                else if (dttwo.Rows.Count == 18 || dttwo.Rows.Count == 38 || dttwo.Rows.Count == 58 || dttwo.Rows.Count == 78 || dttwo.Rows.Count == 98)
                {
                    DataRow myRow;
                    myRow = dttwo.NewRow();
                    dttwo.Rows.Add("", "", "", "", "", "", "");
                    dttwo.Rows.Add("", "", "", "", "", "", "");

                    dttwo.Rows.Add(myRow);
                    rdstwo.Value = dttwo;
                }
                else if (dttwo.Rows.Count == 19 || dttwo.Rows.Count == 39 || dttwo.Rows.Count == 59 || dttwo.Rows.Count == 79 || dttwo.Rows.Count == 99)
                {
                    DataRow myRow;
                    myRow = dttwo.NewRow();
                    dttwo.Rows.Add("", "", "", "", "", "", "");

                    dttwo.Rows.Add(myRow);
                    rdstwo.Value = dttwo;
                }
                else if (dttwo.Rows.Count == 20 || dttwo.Rows.Count == 40 || dttwo.Rows.Count == 60 || dttwo.Rows.Count == 80)
                {
                    DataRow myRow;
                    myRow = dttwo.NewRow();
                    dttwo.Rows.Add(myRow);
                    rdstwo.Value = dttwo;
                }
            }
            rdstwo.Value = dttwo;
            string spouseinsuredamt = "-";
            if (partins != null)
            {
                if (partins.amount != null)
                {
                    spouseinsuredamt = partins.amount.ToString();
                }

            }

            string contributionperiod = "-";
            string termamount = "-";
            string calculate = "-";
            string freqofpayment = "-";
            string rideradbamount = "-";
            decimal annualizepremium = 0;

            string initialcontributionamount = "-";
            string ddlinitialcontribution = "-";
            decimal premiumamount = 0;
            string insuredamount = "-";
            string crticleillnessamount = "-";
            string maritalstatus = "-";
            string plantype = "-";
            string almillar = "-";
            string risk = "-";
            string rawreturn = "-";
            string culminationage = "-";

            WSRider rideradb = null;
            WSRider riderterm = null;
            decimal Porcentaje = 0.00M;
            if (riderslist != null)
            {
                foreach (WSRider rider in riderslist)
                {
                    if (rider.ridertypecode.Equals(WSRider.RIDERADB))
                    {
                        rideradb = rider;
                    }
                    else if (rider.ridertypecode.Equals(WSRider.RIDERTERM))
                    {
                        riderterm = rider;
                    }
                }


            }


            if (customerplan != null)
            {
                if (customerplan.contributionperiod != null)
                {
                    contributionperiod = customerplan.contributionperiod.ToString();
                }
                if (rideradb != null && rideradb.amount != null)
                {
                    rideradbamount = rideradb.amount.ToString();

                }
                if (riderterm != null && riderterm.amount != null)
                {
                    termamount = riderterm.amount.ToString();
                }
                if (customerplan.calculatetypecode != null)
                {
                    calculate = Lookuplangdata.getLanguagevalue(Lookuptables.calculatetypedet, Calculatetypes.getcalculatetype(customerplan.calculatetypecode.ToCharArray()[0]), "es");
                }
                if (customerplan.frequencytypecode != null)
                {
                    // freqofpayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode), Sessionclass.getSessiondata(Session).language);
                    freqofpayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode.ToCharArray()[0]), "es");

                }
                if (customerplan.premiumamount != null)
                {
                    annualizepremium = Numericdata.getDecimalvalue(termresult.annualpremiumamount.ToString());
                }

                if (customerplan.initialcontributionamount != null)
                {
                    if (Numericdata.getDoublevalue(customerplan.initialcontributionamount.ToString()) > 0)
                    {

                        initialcontributionamount = customerplan.initialcontributionamount.ToString();
                    }
                    else
                    {
                        initialcontributionamount = "0";
                    }
                }
                if (customerplan.initialcontributionamount != null)
                {
                    if (Numericdata.getDoublevalue(customerplan.initialcontributionamount.ToString()) > 0)
                    {
                        ddlinitialcontribution = Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "Yes", "es");
                    }
                    else
                    {
                        ddlinitialcontribution = Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "No", "es");

                    }
                }
                if (customerplan.premiumamount != null)
                {
                    if (Numericdata.getDoublevalue(customerplan.premiumamount.ToString()) > 0)
                    {
                        premiumamount = Numericdata.getDecimalvalue(customerplan.premiumamount.ToString());
                    }
                    else
                    {
                        premiumamount = 0;
                    }
                }
                if (customerplan.insuredamount != null)
                {
                    if (Numericdata.getDoublevalue(customerplan.insuredamount.ToString()) > 0)
                    {
                        insuredamount = customerplan.insuredamount.ToString();
                    }
                    else
                    {
                        insuredamount = "0";
                    }
                }
                //if (customerplan.riderciamount != null)
                //{
                //    if (Numericdata.getDoublevalue(customerplan.riderciamount.ToString()) > 0)
                //    {
                //        crticleillnessamount = customerplan.riderciamount.ToString();
                //    }
                //    else
                //    {
                //        crticleillnessamount = "0";
                //    }
                //}
                //CODIGO ORIGINAL 
                //MAVELAR 3/24/17
                //maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet, Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es") + "(a)";
                string estadocivil = " ";
                estadocivil = Maritalstatus.getmaritalstatus(customer.MaritalStatuscode);
                //Unión Libre(a)
                if (estadocivil == "Free union")
                {
                    maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet, Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es");
                }
                else
                {
                    maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet, Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es") + "(a)";
                }
                //MAVELAR 3/24/17
                plantype = Lookuplangdata.getLanguagevalue(Lookuptables.plantypedet, Plantypes.getPlantype(customerplan.plantypecode.ToCharArray()[0]), "es");


                risk = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())), "es");



                almillar = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet, Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())), "es");


                rawreturn = GetROP((Numericdata.getDecimalvalue(customerplan.initialcontributionamount.ToString())),
                                        Frequencytypes.getfrequencytypevaluefromcode(customerplan.frequencytypecode.ToCharArray()[0]),
                                        customerplan.contributionperiod,
                                        Numericdata.getDecimalvalue(customerplan.premiumamount.ToString()))
                                .ToString("n2");

                culminationage = (Numericdata.getIntegervalue(customerplan.contributionperiod.ToString()) + customer.Age - 1).ToString();



            }
            //

            string rideroiramt = "0";
            string rideroirname = "-";
            string Riesgo = "-";
            string Fumador = "-";
            string Sexo = "-";
            string HastalaEdadde = "-";
            string Edad = "-";
            string AlMillar1 = "-";
            //Lisandro
            string riderciamt = "0";
            foreach (WSRider rider in riderslist)
            {
                if (rider.ridertypecode == WSRider.RIDERCI)
                {
                    riderciamt = rider.amount.ToString("n2");
                }
            }
            if (partins != null)
            {

                rideroiramt = partins.amount.ToString("n2");
                rideroirname = partins.firstname + " " + partins.middlename + " " + partins.lastname + " " + partins.LastName2;

                Fumador = Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, Booleandata.getBooleanstring(partins.smoker.ToCharArray()[0]), "es");
                Sexo = partins.gendercode.ToString();

                if (partins.contributiontype.Equals(Contributiontypes.CONTINUOUS.ToString()))
                    HastalaEdadde = "99";
                else if (partins.contributiontype.Equals(Contributiontypes.NUMBEROFYEARS.ToString()))
                    HastalaEdadde = (Convert.ToInt32(partins.age) + partins.term - 1).ToString();
                else if (partins.contributiontype.Equals(Contributiontypes.UNTILAGE.ToString()))
                    HastalaEdadde = partins.term.ToString();

                Edad = partins.age.ToString();

                Riesgo = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, Activityrisktypes.getActivityrisktype(partins.activityrisktypeno), "es");

                AlMillar1 = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet, Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(partins.healthrisktypeno.ToString())), "es");


            }

            string primaryreq = "-", otherreq = "-";

            List<WSExam> exams = termresult.primaryexamsrequiredlist;

            String[] req = new String[20];

            int examno = 0;
            foreach (WSExam exam in exams)
            {
                primaryreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es").ToUpper() + "/" + primaryreq;
                req[examno] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es");
                examno++;
            }

            string tempPrimary = " ";
            int lno1 = 0;

            for (int j = 0; j < req.Length; j++)
            {
                if (!string.IsNullOrEmpty(req[j]))
                    if (!req[j].Trim().Equals(""))
                    {
                        //tempPrimary += req[j] + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t";                            

                        //if(tempPrimary.Length % 80

                        tempPrimary += req[j];
                        if (j != (req.Length - 1))
                        {
                            tempPrimary += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t";
                        }
                        if (tempPrimary.Length > (lno1 + 1) * 150)
                        {
                            tempPrimary += Environment.NewLine;
                            lno1 = lno1 + 1;
                        }

                    }
            }
            //other

            exams = termresult.partnerexamsrequiredlist;

            String[] oreq = new String[12];

            int k = 0;
            foreach (WSExam exam in exams)
            {
                otherreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es").ToUpper() + "/" + otherreq;
                oreq[k] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es");
                k++;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();

            ReportParameter prmstatus1 = new ReportParameter("Color", "unchecked");
            paramlist.Add(prmstatus1);
            prmstatus1 = new ReportParameter("BN", "unchecked");
            paramlist.Add(prmstatus1);
            prmstatus1 = new ReportParameter("CompulsoryFigure", "checked");
            paramlist.Add(prmstatus1);
            string[] controllist = { "S100", "S101", "S102", "S103", "S104", "S105", "S200", "S201", "S202", "S203",
                                          "S204", "S205", "S206", "S207", "S300", "S301", "S302", "S303", "S304", "S305", "S306", "S307", "S308", "S400", "S401", "S402", "S403", "S404", "S405"
                                      , "S406", "S500", "S501", "S502", "S503", "S504", "S505"};
            for (int count1 = 0; count1 < controllist.Count(); count1++)
            {
                ReportParameter prmstatus = new ReportParameter(controllist[count1], "unchecked");
                paramlist.Add(prmstatus);
            }

            //foreach (Control ccontrol in this.pnlCustomize.Controls)
            //{
            //    if (ccontrol is CheckBox)
            //    {
            //        CheckBox myCheckbox = (CheckBox)ccontrol;
            //        if (myCheckbox.Checked == true)
            //        {
            //            ReportParameter prmstatus = new ReportParameter(myCheckbox.ID.Substring(3, myCheckbox.ID.Length - 3), "checked");
            //            paramlist.Add(prmstatus);
            //        }
            //        else
            //        {
            //            ReportParameter prmstatus = new ReportParameter(myCheckbox.ID.Substring(3, myCheckbox.ID.Length - 3), "unchecked");
            //            paramlist.Add(prmstatus);
            //        }
            //    }
            //}

            ReportParameter param100 = new ReportParameter("PolicyholderExams1", "" + tempPrimary);

            string tempOther = " ";
            if (partins != null)
            // if (customerplan.rideroir.ToString().Equals("Y"))
            {
                for (int j = 0; j < oreq.Length; j++)
                {
                    if (!string.IsNullOrEmpty(oreq[j]))
                        if (!oreq[j].Trim().Equals(""))
                            tempOther += oreq[j] + ", ";
                }
            }
            if (tempOther.Trim().Length > 0)
                tempOther = tempOther.Substring(0, tempOther.Length - 2);

            ReportParameter param112 = new ReportParameter("other1", "" + tempOther);


            paramlist.Add(paramOther);
            paramlist.Add(param112);
            paramlist.Add(param100);

            String[] clientsign = new string[3];
            String[] agentsign = new string[3];

            clientsign[0] = "N";
            clientsign[1] = "N";
            clientsign[2] = "N";

            agentsign[0] = "N";
            agentsign[1] = "N";
            agentsign[2] = "N";

            ReportParameter Cpath1 = new ReportParameter("clientsignpath1", "");// new ReportParameter("ClientPath1", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
            ReportParameter Apath1 = new ReportParameter("agentsignpath1", "");// new ReportParameter("AgentPath1", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
            ReportParameter Cpath2 = new ReportParameter("clientsignpath2", "");// new ReportParameter("ClientPath2", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
            ReportParameter Apath2 = new ReportParameter("agentsignpath2", "");// new ReportParameter("AgentPath2", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
            ReportParameter Cpath3 = new ReportParameter("clientsignpath3", "");// new ReportParameter("ClientPath3", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
            ReportParameter Apath3 = new ReportParameter("agentsignpath3", "");// new ReportParameter("AgentPath3", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));

            paramlist.Add(Cpath1);
            paramlist.Add(Apath1);
            paramlist.Add(Cpath2);
            paramlist.Add(Apath2);
            paramlist.Add(Cpath3);
            paramlist.Add(Apath3);


            List<rpt_compass_investment_master> st_rpt_compass_investment_master_moderado = (from item in newdb.rpt_compass_investment_masters
                                                                                             where item.ReturnType == "Moderado" && item.Region == "Americano/Internacional"
                                                                                             select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_moderado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_moderado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_moderado);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_moderado = (from item in newdb.rpt_compass_investment_details
                                                                                                   where item.ReturnTypeid == 1
                                                                                                   select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_moderado = new ReportDataSource("Charts_rpt_compass_investment_details_MODERADO", st_rpt_compass_investment_distribution_moderado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_moderado);
            List<rpt_compass_investment_master> st_rpt_compass_investment_master_balanceado = (from item in newdb.rpt_compass_investment_masters
                                                                                               where item.ReturnType == "Balanceado" && item.Region == "Americano/Internacional"
                                                                                               select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_balanceado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_balanceado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_balanceado);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_balanceado = (from item in newdb.rpt_compass_investment_details
                                                                                                     where item.ReturnTypeid == 3
                                                                                                     select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_balanceado = new ReportDataSource("Charts_rpt_compass_investment_details_BALANCEADO", st_rpt_compass_investment_distribution_balanceado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_balanceado);
            List<rpt_compass_investment_master> st_rpt_compass_investment_master_cricimiento = (from item in newdb.rpt_compass_investment_masters
                                                                                                where item.ReturnType == "Cricimiento" && item.Region == "Americano/Internacional"
                                                                                                select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_cricimiento);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_cricimiento);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_cricimiento = (from item in newdb.rpt_compass_investment_details
                                                                                                      where item.ReturnTypeid == 3
                                                                                                      select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_details_CRICIMIENTO", st_rpt_compass_investment_distribution_cricimiento);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_cricimiento);
            List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_moderado = (from item in newdb.rpt_compass_investment_masters
                                                                                                  where item.ReturnType == "Moderado" && item.Region == "Europeo"
                                                                                                  select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_euro_moderado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_moderado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_moderado);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_moderado = (from item in newdb.rpt_compass_investment_details
                                                                                                        where item.ReturnTypeid == 4
                                                                                                        select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_euro_moderado = new ReportDataSource("Charts_rpt_compass_investment_details_euro_MODERADO", st_rpt_compass_investment_distribution_euro_moderado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_moderado);
            List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_balanceado = (from item in newdb.rpt_compass_investment_masters
                                                                                                    where item.ReturnType == "Balanceado" && item.Region == "Europeo"
                                                                                                    select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_euro_balanceado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_balanceado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_balanceado);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_balanceado = (from item in newdb.rpt_compass_investment_details
                                                                                                          where item.ReturnTypeid == 5
                                                                                                          select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_euro_balanceado = new ReportDataSource("Charts_rpt_compass_investment_details_euro_BALANCEADO", st_rpt_compass_investment_distribution_euro_balanceado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_balanceado);
            List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_cricimiento = (from item in newdb.rpt_compass_investment_masters
                                                                                                     where item.ReturnType == "Cricimiento" && item.Region == "Europeo"
                                                                                                     select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_euro_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_cricimiento);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_cricimiento);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_cricimiento = (from item in newdb.rpt_compass_investment_details
                                                                                                           where item.ReturnTypeid == 6
                                                                                                           select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_euro_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_details_euro_CRICIMIENTO", st_rpt_compass_investment_distribution_euro_cricimiento);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_cricimiento);

            List<rpt_compass_investment_detail> lst_rpt_compass_investment_yearreturn_americano =
                (from item in newdb.rpt_compass_investment_details
                 join o in newdb.rpt_compass_investment_masters
                 on item.ReturnTypeid equals o.Sno
                 where (item.Years == 2010 && o.Region == "Americano/Internacional")
                 select item).ToList();

            ReportDataSource rds_rpt_compass_investment_yearreturn_americano = new ReportDataSource("Charts_rpt_compass_investment_details_yearreturn_Americano", lst_rpt_compass_investment_yearreturn_americano);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_yearreturn_americano);
            List<rpt_compass_investment_detail> lst_rpt_compass_investment_yearreturn_europeo =
                    (from item in newdb.rpt_compass_investment_details
                     join o in newdb.rpt_compass_investment_masters
                     on item.ReturnTypeid equals o.Sno
                     where (item.Years == 2010 && o.Region == "Europeo")
                     select item).ToList();

            ReportDataSource rds_rpt_compass_investment_yearreturn_europeo = new ReportDataSource("Charts_rpt_compass_investment_details_yearreturn_Europeo", lst_rpt_compass_investment_yearreturn_europeo);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_yearreturn_europeo);

            List<profile_de_inversion> lst_rpt_profile_de_inversion = (from item in newdb.profile_de_inversions
                                                                       select item).ToList();

            List<profile_de_inversion_euro> lst_rpt_profile_de_inversion_euro = (from item in newdb.profile_de_inversion_euros
                                                                                 select item).ToList();
            ReportDataSource rds_profile_de_inversion = new ReportDataSource("Charts_profile_de_inversion", lst_rpt_profile_de_inversion);
            rpt.LocalReport.DataSources.Add(rds_profile_de_inversion);
            ReportDataSource rds_profile_de_inversion_euro = new ReportDataSource("Charts_profile_de_inversion_euro", lst_rpt_profile_de_inversion_euro);
            rpt.LocalReport.DataSources.Add(rds_profile_de_inversion_euro);

            List<rpt_InvestType> lst_rpt_invest_distribution_Moderado = (from item in newdb.rpt_InvestTypes
                                                                         where item.FundCategory == "Moderado" && item.Region == "Americano/Internacional"
                                                                         select item).ToList();
            List<rpt_InvestType> lst_rpt_invest_distribution_Balanceado = (from item in newdb.rpt_InvestTypes
                                                                           where item.FundCategory == "Balanceado" && item.Region == "Americano/Internacional"
                                                                           select item).ToList();
            List<rpt_InvestType> lst_rpt_invest_distribution_Crecimiento = (from item in newdb.rpt_InvestTypes
                                                                            where item.FundCategory == "Crecimiento" && item.Region == "Americano/Internacional"
                                                                            select item).ToList();
            ReportDataSource rds_invest_distribution_Moderado = new ReportDataSource("Charts_rpt_InvestType_MODERADO", lst_rpt_invest_distribution_Moderado);
            rpt.LocalReport.DataSources.Add(rds_invest_distribution_Moderado);
            ReportDataSource rds_invest_distribution_Balanceado = new ReportDataSource("Charts_rpt_InvestType_BALANCEADO", lst_rpt_invest_distribution_Balanceado);
            rpt.LocalReport.DataSources.Add(rds_invest_distribution_Balanceado);
            ReportDataSource rds_invest_distribution_Crecimiento = new ReportDataSource("Charts_rpt_InvestType_CRECIMIENTO", lst_rpt_invest_distribution_Crecimiento);
            rpt.LocalReport.DataSources.Add(rds_invest_distribution_Crecimiento);
            List<rpt_InvestType> lst_rpt_invest_euro_distribution_Moderado = (from item in newdb.rpt_InvestTypes
                                                                              where item.FundCategory == "Moderado" && item.Region == "Europeo"
                                                                              select item).ToList();
            ReportDataSource rds_invest_euro_distribution_Moderado = new ReportDataSource("Charts_rpt_euro_InvestType_MODERADO", lst_rpt_invest_euro_distribution_Moderado);
            rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Moderado);
            List<rpt_InvestType> lst_rpt_invest_euro_distribution_Balanceado = (from item in newdb.rpt_InvestTypes
                                                                                where item.FundCategory == "Balanceado" && item.Region == "Europeo"
                                                                                select item).ToList();
            ReportDataSource rds_invest_euro_distribution_Balanceado = new ReportDataSource("Charts_rpt_euro_InvestType_BALANCEADO", lst_rpt_invest_euro_distribution_Balanceado);
            rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Balanceado);
            List<rpt_InvestType> lst_rpt_invest_euro_distribution_Crecimiento = (from item in newdb.rpt_InvestTypes
                                                                                 where item.FundCategory == "Crecimiento" && item.Region == "Europeo"
                                                                                 select item).ToList();
            ReportDataSource rds_invest_euro_distribution_Crecimiento = new ReportDataSource("Charts_rpt_euro_InvestType_CRECIMIENTO", lst_rpt_invest_euro_distribution_Crecimiento);
            rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Crecimiento);
            var totMonderadoBond = from mb in lst_rpt_invest_distribution_Moderado
                                   where mb.FundType == "Bond" && mb.FundCategory == "Moderado"
                                   group mb by mb.FundCategory into g
                                   select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var totMonderadoStock = from ms in lst_rpt_invest_distribution_Moderado
                                    where ms.FundType == "Stock" && ms.FundCategory == "Moderado"
                                    group ms by ms.FundCategory into g
                                    select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

            ReportParameter prmMonderadoBondShare = new ReportParameter("MonderadoBondShare", totMonderadoBond.First().total.ToString());
            paramlist.Add(prmMonderadoBondShare);
            ReportParameter prmMonderadoStockShare = new ReportParameter("MonderadoStockShare", totMonderadoStock.First().total.ToString());
            paramlist.Add(prmMonderadoStockShare);
            var totBalanceadoBond = from mb in lst_rpt_invest_distribution_Balanceado
                                    where mb.FundType == "Bond" && mb.FundCategory == "Balanceado"
                                    group mb by mb.FundCategory into g
                                    select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var totBalanceadoStock = from ms in lst_rpt_invest_distribution_Balanceado
                                     where ms.FundType == "Stock" && ms.FundCategory == "Balanceado"
                                     group ms by ms.FundCategory into g
                                     select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

            ReportParameter prmBalanceadoBondShare = new ReportParameter("BalanceadoBondShare", totBalanceadoBond.First().total.ToString());
            paramlist.Add(prmBalanceadoBondShare);
            ReportParameter prmBalanceadoStockShare = new ReportParameter("BalanceadoStockShare", totBalanceadoStock.First().total.ToString());
            paramlist.Add(prmBalanceadoStockShare);




            var totCrecimientoBond = from mb in lst_rpt_invest_distribution_Crecimiento
                                     where mb.FundType == "Bond" && mb.FundCategory == "Crecimiento"
                                     group mb by mb.FundCategory into g
                                     select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var totCrecimientoStock = from ms in lst_rpt_invest_distribution_Crecimiento
                                      where ms.FundType == "Stock" && ms.FundCategory == "Crecimiento"
                                      group ms by ms.FundCategory into g
                                      select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

            string shareCrecimientoBond;
            if (totCrecimientoBond.FirstOrDefault() != null)
            {
                shareCrecimientoBond = Convert.ToString(totCrecimientoBond.FirstOrDefault().total);
            }
            else
            {
                shareCrecimientoBond = "0";
            }

            ReportParameter prmCrecimientoBondShare = new ReportParameter("CrecimientoBondShare", shareCrecimientoBond);
            paramlist.Add(prmCrecimientoBondShare);
            ReportParameter prmCrecimientoStockShare = new ReportParameter("CrecimientoStockShare", totCrecimientoStock.First().total.ToString());
            paramlist.Add(prmCrecimientoStockShare);

            var euro_totBalanceadoBond = from mb in lst_rpt_invest_euro_distribution_Balanceado
                                         where mb.FundType == "Bond" && mb.FundCategory == "Balanceado"
                                         group mb by mb.FundCategory into g
                                         select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var euro_totBalanceadoStock = from ms in lst_rpt_invest_euro_distribution_Balanceado
                                          where ms.FundType == "Stock" && ms.FundCategory == "Balanceado"
                                          group ms by ms.FundCategory into g
                                          select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

            ReportParameter euro_prmBalanceadoBondShare = new ReportParameter("euro_BalanceadoBondShare", euro_totBalanceadoBond.First().total.ToString());
            paramlist.Add(euro_prmBalanceadoBondShare);
            ReportParameter euro_prmBalanceadoStockShare = new ReportParameter("euro_BalanceadoStockShare", euro_totBalanceadoStock.First().total.ToString());
            paramlist.Add(euro_prmBalanceadoStockShare);

            var euro_totMonderadoBond = from mb in lst_rpt_invest_euro_distribution_Moderado
                                        where mb.FundType == "Bond" && mb.FundCategory == "Moderado"
                                        group mb by mb.FundCategory into g
                                        select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var euro_totMonderadoStock = from ms in lst_rpt_invest_euro_distribution_Moderado
                                         where ms.FundType == "Stock" && ms.FundCategory == "Moderado"
                                         group ms by ms.FundCategory into g
                                         select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

            ReportParameter euro_prmMonderadoBondShare = new ReportParameter("euro_MonderadoBondShare", euro_totMonderadoBond.First().total.ToString());
            paramlist.Add(euro_prmMonderadoBondShare);
            ReportParameter euro_prmMonderadoStockShare = new ReportParameter("euro_MonderadoStockShare", euro_totMonderadoStock.First().total.ToString());
            paramlist.Add(euro_prmMonderadoStockShare);

            var euro_totCrecimientoBond = from mb in lst_rpt_invest_distribution_Crecimiento
                                          where mb.FundType == "Bond" && mb.FundCategory == "Crecimiento"
                                          group mb by mb.FundCategory into g
                                          select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var euro_totCrecimientoStock = from ms in lst_rpt_invest_distribution_Crecimiento
                                           where ms.FundType == "Stock" && ms.FundCategory == "Crecimiento"
                                           group ms by ms.FundCategory into g
                                           select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };




            string euro_shareCrecimientoBond;
            if (totCrecimientoBond.FirstOrDefault() != null)
            {
                euro_shareCrecimientoBond = Convert.ToString(euro_totCrecimientoBond.FirstOrDefault().total);
            }
            else
            {
                euro_shareCrecimientoBond = "0";
            }

            ReportParameter euro_prmCrecimientoBondShare = new ReportParameter("euro_CrecimientoBondShare", euro_shareCrecimientoBond);
            paramlist.Add(euro_prmCrecimientoBondShare);
            ReportParameter euro_prmCrecimientoStockShare = new ReportParameter("euro_CrecimientoStockShare", euro_totCrecimientoStock.First().total.ToString());
            paramlist.Add(euro_prmCrecimientoStockShare);



            List<rpt_lifeexpectancy> rpt_Life_Expectancy = (from item in newdb.rpt_lifeexpectancies
                                                            select item).ToList();


            decimal MaxAge = 0;
            if (customer.gendercode.ToString() == "M")
            {
                MaxAge = Convert.ToDecimal((from item in rpt_Life_Expectancy where item.Current_Age == 0 select item.Men).First());
            }
            else if (customer.gendercode.ToString() == "F")
            {
                MaxAge = Convert.ToDecimal((from item in rpt_Life_Expectancy where item.Current_Age == 0 select item.Woman).First());
            }

            //decimal LifeExpectancy = MaxAge - Convert.ToDecimal(customer.Age);

            ReportParameter param110 = new ReportParameter("LifeExpectancy", (MaxAge - Convert.ToDecimal(customer.Age)).ToString());
            paramlist.Add(param110);
            ReportDataSource lifeexpetancy = new ReportDataSource("Charts_rpt_lifeexpectancy", rpt_Life_Expectancy);
            rpt.LocalReport.DataSources.Add(lifeexpetancy);

            string Prospect = (((customer.FirstName + " " + customer.MiddleName).Trim() + " " + customer.LastName).Trim() + " " + customer.LastName2).Trim();
            if (PlanName == "")
            {
                const int MaxLengthHeading = 30;
                const int MaxLengthName = 50;
                string ini3 = (customer.gendercode == "M" ? "Sr." : "Sr(a).");
                var custHeading = (ini3 + " " + customer.FirstName + " " + customer.LastName).Trim();
                var custName = (customer.FirstName + " " + customer.LastName).Trim();
                if (custHeading.Length > MaxLengthHeading)
                {
                    custHeading = custHeading.Substring(0, MaxLengthHeading);
                    custHeading = custHeading + "...";
                }
                if (custName.Length > MaxLengthName)
                {
                    custName = custName.Substring(0, MaxLengthName);
                    custName = custName + "...";
                }
                ReportParameter param1 = new ReportParameter("heading", custHeading);
                ReportParameter param3 = new ReportParameter("name", custName);
                paramlist.Add(param1);
                paramlist.Add(param3);
            }
            else
            {
                const int MaxLengthHeading = 25;
                const int MaxLengthName = 50;
                string ini2 = string.Empty;
                if (customer.gendercode == "F")
                {
                    if (customer.MaritalStatuscode == "S")
                        ini2 = "Srta.";
                    else
                        ini2 = "Sra.";
                }
                else
                {
                    if (customer.MaritalStatuscode == "S")
                        ini2 = string.Empty;
                    else
                        ini2 = "Sr.";
                }
                var custHeading = (ini2 + " " + customer.FirstName + " " + customer.LastName).Trim();
                var custName = (customer.FirstName + " " + customer.LastName).Trim();
                if (custHeading.Length > MaxLengthHeading)
                {
                    custHeading = custHeading.Substring(0, MaxLengthHeading);
                    custHeading = custHeading + "...";
                }
                if (custName.Length > MaxLengthName)
                {
                    custName = custName.Substring(0, MaxLengthName);
                    custName = custName + "...";
                }
                ReportParameter param1 = new ReportParameter("heading", custHeading);
                ReportParameter param3 = new ReportParameter("name", custName);
                paramlist.Add(param1);
                paramlist.Add(param3);
            }

            ReportParameter param135 = new ReportParameter("lastname", customer.LastName.ToString());
            paramlist.Add(param135);
            //ReportParameter param2 = new ReportParameter("date", DateTime.Now.ToShortDateString());

            ReportParameter param4 = new ReportParameter("periodofcontribution", customerplan.contributionperiod + "");
            //ReportParameter param5 = new ReportParameter("amountofcontribution", GetFormatedText(customerplan.initialcontribution + ""));
            ReportParameter param5 = new ReportParameter("amountofcontribution", GetFormatedText(initialcontributionamount.ToString()));
            ReportParameter param6 = new ReportParameter("premiumamount", premiumamount.ToString("n2"));
            ReportParameter param7 = new ReportParameter("withdrawalamount", GetFormatedText(insuredamount));

            //ReportParameter param8 = new ReportParameter("plantype", plantype + "");//Plantypes.getPlantype(customerplan.plantypecode));
            ReportParameter param8 = new ReportParameter("plantype", "Temporal" + "");//Plantypes.getPlantype(customerplan.plantypecode));

            ReportParameter param9 = new ReportParameter("age", customer.Age + "");
            ReportParameter param10 = new ReportParameter("gender", customer.gendercode + "");//Genders.getgender(customer.gendercode));
            ReportParameter param11 = new ReportParameter("smoker", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, Booleandata.getBooleanstring(customer.Smoker.ToCharArray()[0]), "es"));

            ReportParameter param12 = new ReportParameter("ageatretirement", customerplan.contributionuntilage + "");
            ReportParameter param13 = new ReportParameter("risk", risk);//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
            ReportParameter param14 = new ReportParameter("almillar", almillar);//Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())));
            ReportParameter param15 = new ReportParameter("maritalstatus", maritalstatus);//Maritalstatus.getmaritalstatus(customer.MaritalStatuscode.Value));
            //ReportParameter param16 = new ReportParameter("suminsured", ((String.Format("{0:n0}", Numericdata.getDoublevalue((customerplan.insuredamount + customerplan.ridertermamount).ToString())).Replace('.', '/')).Replace(',', '.')).Replace('/', ','));
            ReportParameter param16 = new ReportParameter("suminsured", (customerplan.insuredamount + (riderterm != null ? riderterm.amount : 0)).ToString("n2"));
            ReportParameter param17 = new ReportParameter("annualpremium", annualizepremium.ToString("n2"));
            ReportParameter param18 = new ReportParameter("period", freqofpayment);
            ReportParameter param19 = new ReportParameter("calcular", calculate);
            //ReportParameter param20 = new ReportParameter("additionaltemporary", Booleandata.getBooleanstring(customerplan.riderterm));
            ReportParameter param20 = new ReportParameter("additionaltemporary", riderterm != null ? riderterm.amount.ToString("n2") : "0");
            ReportParameter param21;
            if (customerplan.classcode.ToString().Equals("R"))
            {
                param21 = new ReportParameter("kind", "RD$");
            }
            else
            {
                param21 = new ReportParameter("kind", customerplan.classcode.ToString());
            }
            ReportParameter param22 = new ReportParameter("country", Lookuplangdata.getLanguagevalue(Lookuptables.countrydet, Countries.getcountry(Numericdata.getIntegervalue(customerplan.countryno + "")), Langdata.LANGUAGE_SPANISH));//Sessionclass.getSessiondata(Session).language));
            ReportParameter param23 = new ReportParameter("initialcontribution", ddlinitialcontribution);

            //ReportParameter param24 = new ReportParameter("accidentaldeath", Booleandata.getBooleanstring(customerplan.rideradb));

            ReportParameter param24 = new ReportParameter("accidentaldeath", rideradb != null ? rideradb.amount.ToString("n2") : "0");

            ReportParameter param25 = new ReportParameter("spouceinsurance", rideroirname);
            ReportParameter param26 = new ReportParameter("primatarget", termresult.targetpremiumamount.ToString("n2"));
            ReportParameter param27 = new ReportParameter("timeinsurance", contributionperiod);
            ReportParameter param28 = new ReportParameter("financialgoals", customerplan.financialgoal + "");
            ReportParameter param29 = new ReportParameter("plan", Productdata.getProduct(customerplan.productcode));
            //ReportParameter param120_1 = new ReportParameter("date", getspanishmonth(DateTime.Now.ToString("MMMM")) + " " + DateTime.Now.ToString("dd, yyyy"));
            ReportParameter param120_1 = new ReportParameter("date", getspanishmonth(Int32.Parse(DateTime.Now.ToString("MM"))) + " " + DateTime.Now.ToString("dd, yyyy"));
            paramlist.Add(param120_1);
            //ReportParameter param30 = new ReportParameter("descriptionline", Generalmethods.getDescriptionline(Productdata.getProduct(customerplan.productcode), initialcontributionamount));
            ReportParameter param81 = new ReportParameter("class", customerplan.classcode.ToString());
            paramlist.Add(param81);
            ReportParameter paramsib = new ReportParameter("suminsuredbase", (customerplan.insuredamount.ToString("n2")));
            paramlist.Add(paramsib);

            string investmentprofile = "-";
            ReportParameter param26_12 = new ReportParameter("investmentprofile", investmentprofile + "");
            paramlist.Add(param26_12);
            ReportParameter param76_12 = new ReportParameter("PaymentFrequency", freqofpayment);
            paramlist.Add(param76_12);
            string desc = "";
            string desc1 = "";

            //// if (customerplan.productcode.Equals("LGT"))
            //desc = Generalmethods.getLightHouseDescriptionline(contributionperiod, Productdata.getProduct(customerplan.productcode));
            desc = Generalmethods.getDescriptionline(productcode, int.Parse(contributionperiod));
            //  else if (customerplan.productcode.Equals("SNT"))
            // desc = Generalmethods.getSentinalDescriptionline(contributionperiod);


            ReportParameter param30 = new ReportParameter("descriptionline", desc);


            ReportParameter param31 = new ReportParameter("lastline", Generalmethods.getLastlineTerm(productcode, Prospect, new Random().Next(1, 20), customerplan.classcode.ToString().ToCharArray()[0]));
            ReportParameter param33 = new ReportParameter("InitialContributionAmount", GetFormatedText(initialcontributionamount));
            ReportParameter param34 = new ReportParameter("Temporal", "-");
            ReportParameter param35 = new ReportParameter("PeriodoContribucion1", "-");
            ReportParameter param63 = new ReportParameter("PolicyholderSubscriptionRequirements", primaryreq);
            ReportParameter param64 = new ReportParameter("UnderwritingRequirementsAdditionalInsured", otherreq);
            ReportParameter param65 = new ReportParameter("Riesgo", Riesgo);
            ReportParameter param66 = new ReportParameter("AlMillar1", AlMillar1);
            ReportParameter param67 = new ReportParameter("Edad", Edad);
            ReportParameter param68 = new ReportParameter("Fumador", Fumador);
            ReportParameter param69 = new ReportParameter("Sexo", Sexo);
            ReportParameter param70 = new ReportParameter("ForYears", HastalaEdadde);
            ReportParameter param71 = new ReportParameter("HastalaEdadde", HastalaEdadde);
            ReportParameter param72 = new ReportParameter("AccidentalAmount", GetFormatedText(rideradbamount));
            ReportParameter param73 = new ReportParameter("TemporalAdicionalForYears", riderterm != null ? riderterm.term + "" : "");
            ReportParameter param74 = new ReportParameter("TemporalAdicionalAmount", GetFormatedText(riderterm != null ? riderterm.amount.ToString() : ""));
            ReportParameter param75 = new ReportParameter("criticleillness", Booleandata.getBooleanstring('N'));
            ReportParameter param76 = new ReportParameter("BottomText", "Esta propuesta es válida por 15 días y en  ningún caso más allá del " + DateTime.DaysInMonth(DateTime.Now.Year, 12) + "/" + 12 + "/" + DateTime.Now.Year + " (v2)");
            ReportParameter param77 = new ReportParameter("rideroiramount", (rideroiramt));
            ReportParameter param78 = new ReportParameter("ValueAccount", "-");
            ReportParameter param82 = new ReportParameter("foryear", "Por Años");
            ReportParameter param83 = new ReportParameter("withdrawalperiod", "-");
            ReportParameter param84 = new ReportParameter("rideroirname", rideroirname);
            ReportParameter param85 = new ReportParameter("crticleillnessamount", GetFormatedText(crticleillnessamount));

            //if ((hdnCheckedSettings.Value != "") || (hdnUnCheckedSettings.Value != ""))
            //{
            //    string[] checkedSettings = hdnCheckedSettings.Value.ToString().TrimStart(',').Split(',');
            //    string[] unCheckedSettings = hdnUnCheckedSettings.Value.ToString().TrimStart(',').Split(',');

            //    for (int counter1 = 0; counter1 < checkedSettings.Count(); counter1++)
            //    {
            //        ReportParameter visibilityParam = new ReportParameter(checkedSettings[counter1].ToString(), "checked");
            //        paramlist.Add(visibilityParam);
            //    }

            //    for (int counter2 = 0; counter2 < unCheckedSettings.Count(); counter2++)
            //    {
            //        if (unCheckedSettings[counter2].ToString() == null || unCheckedSettings[counter2].ToString() == "")
            //        {
            //        }
            //        else
            //        {
            //            ReportParameter visibilityParam = new ReportParameter(unCheckedSettings[counter2].ToString(), "unchecked");
            //            paramlist.Add(visibilityParam);
            //        }
            //    }


            //} 

            ReportParameter param308 = new ReportParameter("S308", "unchecked");
            paramlist.Add(param308);
            ReportParameter param124 = new ReportParameter("number", "");//txtnumber.Text);
            ReportParameter param125 = new ReportParameter("culminationage", culminationage + "");
            ReportParameter param126 = null;
            if (partins == null)
            {
                param126 = new ReportParameter("rideroir", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "No", "es"));
            }
            else
            {
                param126 = new ReportParameter("rideroir", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "Yes", "es"));
            }

            ReportParameter param127 = new ReportParameter("Impuesto", termresult.Tax.ToString("n2"));
            ReportParameter param128 = new ReportParameter("primatotal", termresult.TotalPeriodicPremium.ToString("n2"));
            ReportParameter param129 = new ReportParameter("Totalsuminsured", Numericdata.getDoublevalue((customerplan.insuredamount + (riderterm != null ? riderterm.amount : 0)).ToString()).ToString("n2"));


            ReportParameter paramcnp = new ReportParameter("contributionperiod", "PERÍODO INICIAL:" + " " + customerplan.contributionperiod + "Años - Prima Nivelada Garantizada");
            paramlist.Add(paramcnp);


            if (customerplan.productcode.Equals("GRD") || customerplan.productcode.Equals("GRP"))
            {
                ReportParameter paramrop = new ReportParameter("returnamount", rawreturn);
                paramlist.Add(paramrop);

            }

            // paramlist.Add(param2);

            paramlist.Add(param4);
            paramlist.Add(param5);
            paramlist.Add(param6);
            paramlist.Add(param7);
            paramlist.Add(param8);
            paramlist.Add(param9);
            paramlist.Add(param10);
            paramlist.Add(param11);
            paramlist.Add(param12);
            paramlist.Add(param13);
            paramlist.Add(param14);
            paramlist.Add(param15);
            paramlist.Add(param16);
            paramlist.Add(param17);
            paramlist.Add(param18);
            paramlist.Add(param19);
            paramlist.Add(param20);
            paramlist.Add(param21);
            paramlist.Add(param22);
            paramlist.Add(param23);
            paramlist.Add(param24);
            paramlist.Add(param25);
            paramlist.Add(param26);
            paramlist.Add(param27);
            paramlist.Add(param28);
            paramlist.Add(param29);
            paramlist.Add(param30);

            paramlist.Add(param31);
            paramlist.Add(param33);
            paramlist.Add(param34);
            paramlist.Add(param35);
            paramlist.Add(param63);
            paramlist.Add(param64);
            paramlist.Add(param65);
            paramlist.Add(param66);
            paramlist.Add(param67);
            paramlist.Add(param68);
            paramlist.Add(param69);
            paramlist.Add(param70);
            paramlist.Add(param71);
            paramlist.Add(param72);
            paramlist.Add(param73);
            paramlist.Add(param74);
            paramlist.Add(param75);
            paramlist.Add(param76);
            paramlist.Add(param77);
            paramlist.Add(param78);
            paramlist.Add(param83);
            paramlist.Add(param84);
            paramlist.Add(param82);
            paramlist.Add(param85);
            paramlist.Add(param124);
            paramlist.Add(param125);
            paramlist.Add(param126);
            paramlist.Add(param127);
            paramlist.Add(param128);
            paramlist.Add(param129);

            //ReportParameter param504 = new ReportParameter("S504", "unchecked");
            //paramlist.Add(param504);


            List<rpt_investments_inflacion> rpt_investment = (from item in newdb.rpt_investments_inflacions
                                                              select item).ToList();
            var count = rpt_investment.Count();
            var inflation_Last = (from ms in rpt_investment
                                  select new { ms.Pequenas_Acciones, ms.Grandes_Acciones, ms.Papelesdel_Tesoro, ms.Bonosdel_Gobierno, ms.Inflacion }).Last();
            var inflation_first = (from ms in rpt_investment
                                   select new { ms.Pequenas_Acciones, ms.Grandes_Acciones, ms.Papelesdel_Tesoro, ms.Bonosdel_Gobierno, ms.Inflacion }).First();
            var percent_Pequenas_last = inflation_Last.Pequenas_Acciones;
            var percent_Pequenas_First = inflation_first.Pequenas_Acciones;
            var Grandes_Acciones_last = inflation_Last.Grandes_Acciones;
            var Grandes_Acciones_First = inflation_first.Grandes_Acciones;
            var Papelesdel_Tesoro_last = inflation_Last.Papelesdel_Tesoro;
            var Papelesdel_Tesoro_First = inflation_first.Papelesdel_Tesoro;
            var Bonosdel_Gobierno_last = inflation_Last.Bonosdel_Gobierno;
            var Bonosdel_Gobierno_First = inflation_first.Bonosdel_Gobierno;
            var Inflacion1_last = inflation_Last.Inflacion;
            var Inflacion1_First = inflation_first.Inflacion;


            var result_total = percent_Pequenas_last / percent_Pequenas_First;
            var numberofyears = 0.0119;
            var Pequenas_percent = (Math.Pow(Convert.ToDouble(result_total), numberofyears) - 1) * 100;

            var result1_total = Grandes_Acciones_last / Grandes_Acciones_First;
            var numberofyears1 = 0.0119;
            var Grandes_percent = (Math.Pow(Convert.ToDouble(result1_total), numberofyears1) - 1) * 100;

            var result2_total = Papelesdel_Tesoro_last / Papelesdel_Tesoro_First;
            var numberofyears2 = 0.0119;
            var Papelesdel_percent = (Math.Pow(Convert.ToDouble(result2_total), numberofyears2) - 1) * 100;

            var result3_total = Bonosdel_Gobierno_last / Bonosdel_Gobierno_First;
            var numberofyears3 = 0.0119;
            var Bonosdel_percent = (Math.Pow(Convert.ToDouble(result3_total), numberofyears3) - 1) * 100;

            var result4_total = Inflacion1_last / Inflacion1_First;
            var numberofyears4 = 0.0119;
            var Inflacion_percent = (Math.Pow(Convert.ToDouble(result4_total), numberofyears4) - 1) * 100;


            ReportParameter Pequenas_Acciones = new ReportParameter("Pequenas_Acciones", Pequenas_percent.ToString());
            ReportParameter Grandes = new ReportParameter("Grandes", Grandes_percent.ToString());
            ReportParameter Papelesdel_Tesoro = new ReportParameter("Papelesdel_Tesoro", Papelesdel_percent.ToString());
            ReportParameter Bonosdel_Gobierno = new ReportParameter("Bonosdel_Gobierno", Bonosdel_percent.ToString());
            ReportParameter Inflacion = new ReportParameter("Inflacion", Inflacion_percent.ToString());
            paramlist.Add(Pequenas_Acciones);
            paramlist.Add(Grandes);
            paramlist.Add(Papelesdel_Tesoro);
            paramlist.Add(Bonosdel_Gobierno);
            paramlist.Add(Inflacion);


            if (PlanName.Equals("Sentinel"))
            {
                ReportParameter param30_12 = new ReportParameter("descriptionline1", desc1);
                paramlist.Add(param30_12);

            }

            string untilAge = "-";

            if (riderterm != null)
            {
                if (riderterm.type.Equals(Contributiontypes.CONTINUOUS.ToString()))
                    untilAge = "99";
                else if (riderterm.type.Equals(Contributiontypes.NUMBEROFYEARS.ToString()))
                    untilAge = (Convert.ToInt32(customer.Age) + riderterm.term - 1).ToString();
                else if (riderterm.type.Equals(Contributiontypes.UNTILAGE.ToString()))
                    untilAge = riderterm.term.ToString();
            }

            ReportParameter paramAdditionalTermUntilAge = new ReportParameter("AdditionalTermUntilAge", untilAge);

            paramlist.Add(paramAdditionalTermUntilAge);


            maritalstatus = "-";

            if (partins != null)
            {
                maritalstatus = Maritalstatus.getmaritalstatus(partins.maritalstatuscode);

                lookupdatadet mstatus = (from item in newdb.lookupdatadets
                                         where item.tablename.Equals("maritalstatusdet") && item.lookupcaption.Equals(maritalstatus)
                                         select item).SingleOrDefault();
                if (mstatus != null)
                    maritalstatus = mstatus.spanish;
            }

            ReportParameter paramSpouseMaritalStatus = new ReportParameter("SpouseMaritalStatus", maritalstatus);
            paramlist.Add(paramSpouseMaritalStatus);

            string temp = "-";
            if (riderterm != null)
                temp = GetFormatedText(riderterm.amount.ToString());

            // ReportParameter paramRiderAmount1 = new ReportParameter("RiderAmount1", temp);
            temp = "-";
            if (rideradb != null)
                temp = GetFormatedText(rideradb.amount.ToString());

            //ReportParameter paramRiderAmount2 = new ReportParameter("RiderAmount2", temp);

            string partinsRiderOirAmount = "-";
            // if (customerplan.rideroir.ToString().Equals("Y"))
            if (partins != null)
                partinsRiderOirAmount = GetFormatedText(partins.amount.ToString());

            //ReportParameter paramRiderAmount3 = new ReportParameter("RiderAmount3", partinsRiderOirAmount);

            untilAge = "-";

            if (riderterm != null)
            {
                if (riderterm.type.Equals(Contributiontypes.CONTINUOUS.ToString()))
                    untilAge = "99";
                else if (riderterm.type.Equals(Contributiontypes.NUMBEROFYEARS.ToString()))
                    untilAge = (Convert.ToInt32(customer.Age) + riderterm.term - 1).ToString();
                else if (riderterm.type.Equals(Contributiontypes.UNTILAGE.ToString()))
                    untilAge = riderterm.term.ToString();
            }

            if (untilAge.Equals("0"))
                untilAge = "-";

            string untilAge2 = "-";


            if (partins != null)
            {
                if (partins.contributiontype.Equals(Contributiontypes.CONTINUOUS.ToString()))
                    untilAge2 = "99";
                else if (partins.contributiontype.Equals(Contributiontypes.NUMBEROFYEARS.ToString()))
                    untilAge2 = (Convert.ToInt32(partins.age) + partins.term - 1).ToString();
                else if (partins.contributiontype.Equals(Contributiontypes.UNTILAGE.ToString()))
                    untilAge2 = partins.term.ToString();
            }

            if (untilAge2.Equals("0"))
                untilAge2 = "-";

            List<rpt_Compass_Slide5> rpt_Compass_Slide5 = (from item in newdb.rpt_Compass_Slide5s
                                                           select item).ToList();
            List<rpt_Compass_slide7> Compass_slide7 = (from item in newdb.rpt_Compass_slide7s
                                                       select item).ToList();

            foreach (rpt_Compass_slide7 item in Compass_slide7)
            {
                if (item.Continent == "Europa")
                {
                    ReportParameter param60 = new ReportParameter("Europe_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param61 = new ReportParameter("Europe_Area", item.Area.ToString() + " Km2");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param60);
                    paramlist.Add(param61);
                }
                else if (item.Continent == "Mediterráneo Oriental")
                {
                    ReportParameter param62 = new ReportParameter("Eastern_Mediterranean_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param130 = new ReportParameter("Eastern_Mediterranean_Area", item.Area.ToString() + " Km2");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param62);
                    paramlist.Add(param130);
                }
                else if (item.Continent == "Pacífico Occidental")
                {
                    ReportParameter param131 = new ReportParameter("Pacífico_Occidental_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param132 = new ReportParameter("Pacífico_Occidental_Area", item.Area.ToString() + " Km2");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param131);
                    paramlist.Add(param132);
                }
                else if (item.Continent == "Asia Sur Oriental")
                {
                    ReportParameter param133 = new ReportParameter("Asia_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param105 = new ReportParameter("Asia_Area", item.Area.ToString());//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param133);
                    paramlist.Add(param105);
                }
                else if (item.Continent == "Centro y Suramérica")
                {
                    ReportParameter param106 = new ReportParameter("america_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param107 = new ReportParameter("america_Area", item.Area.ToString() + " Km2");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param106);
                    paramlist.Add(param107);
                }
                else if (item.Continent == "Africa")
                {
                    ReportParameter param108 = new ReportParameter("Africa_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param109 = new ReportParameter("Africa_Area", item.Area.ToString() + " Km2");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param108);
                    paramlist.Add(param109);
                }
            }

            string sup = "";
            if (rideradb != null || riderterm != null || partins != null)
            {
                //sup = Generalmethods.getsuplementosline(customerplan.rideradb.ToString(), customerplan.riderterm.ToString(), customerplan.rideroir.ToString(), customerplan.rideradbamount != null ? Program.getCurrencyString(ruleclasscode,double.Parse( customerplan.rideradbamount.ToString())) : "", customerplan.ridertermamount != null ? Program.getCurrencyString(ruleclasscode, double.Parse(customerplan.ridertermamount.ToString())) : "",partins!=null? partins.rideroiramount!=null? Program.getCurrencyString(ruleclasscode,double.Parse( partins.rideroiramount.ToString())):"":"", untilAge, HastalaEdadde);
                sup = Generalmethods.getsuplementoslineNew(rideradb != null ? "Y" : "N", riderterm != null ? "Y" : "N", partins != null ? "Y" : "N", rideradb != null ? rideradb.amount.ToString() : "", riderterm != null ? riderterm.amount.ToString() : "", partins != null ? partins.amount != null ? partins.amount.ToString() : "" : "", untilAge, HastalaEdadde, ruleclasscode);

            }
            else
            {
                sup = "Este Plan no tiene coberturas adicionales.";
            }
            ReportParameter param134 = new ReportParameter("suplementos", sup);
            paramlist.Add(param134);

            ReportDataSource Compassslide7 = new ReportDataSource("Charts_rpt_Compass_slide7", Compass_slide7);

            ReportDataSource Compassslide5 = new ReportDataSource("Charts_rpt_Compass_Slide5", rpt_Compass_Slide5);

            /* Lgonzalez 29-04-2017 */
            /***** Agregando nuevo parametro - Inicio *****/

            //ReportParameter param159 = new ReportParameter("RecargoFraccion", termresult.fractionsurcharge.ToString() ); // Math.Round(Numericdata.getDecimalvalue(termresult.fractionsurcharge.ToString()),2) );
            //paramlist.Add(param159);

            /***** Agregando nuevo parametro - Fin *****/

            rpt.LocalReport.DataSources.Add(Compassslide5);
            rpt.LocalReport.DataSources.Add(Compassslide7);
            rpt.LocalReport.EnableExternalImages = true;
            rpt.LocalReport.SetParameters(paramlist);

            rpt.LocalReport.DataSources.Add(rds);
            rpt.LocalReport.DataSources.Add(rdstwo);
            rpt.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            bytes = rpt.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            //if (classicmode == true)
            //{
            //    dvReport.Visible = true;
            //    dvpdf.Visible = false;
            //    this.ReportViewer1.LocalReport.Refresh();
            //}
            //else if (customize == false)
            //{
            //    dvpdf.Visible = true;
            //    dvReport.Visible = false;
            //    Warning[] warnings;
            //    string[] streamIds;
            //    string mimeType = string.Empty;
            //    string encoding = string.Empty;
            //    string extension = string.Empty;
            //    byte[] bytes = this.ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            //    MyGlobals.reportbytes = bytes;
            //    String strfilename = System.IO.Path.GetRandomFileName();
            //    Sessionclass.setIllustrationfilename(Session, strfilename + ".pdf");
            //    using (FileStream fs = new FileStream(Server.MapPath("~/pdfoutput/") + strfilename + ".pdf", FileMode.Create))
            //    {
            //        fs.Write(bytes, 0, bytes.Length);
            //    }
            //    /*
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append("<object data='" + "pdfoutput/" + strfilename + ".pdf" + "' type='application/pdf' width='916' height='470'>");
            //    sb.Append("</object>");
            //    this.dvpdf.InnerHtml = sb.ToString();
            //     */
            //    this.dvpdf.InnerHtml = getObjectString(strfilename);



            //}


            return bytes;

        }


        public static byte[] showIllustrationTERMfixedLS(WSTermResult termresult, WSCustomer customer, WSCustomerPlan customerplan, IMaintermfixedLS termfixed, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            byte[] bytes = null;
            DataVOUniversalDataContext newdb = Program.getDbConnection();

            customerplan.insuredamount = termresult.insuredamount;
            customerplan.premiumamount = termresult.periodicpremiumamount;


            String productcode = "";
            rpt = new ReportViewer();
            rpt.LocalReport.Refresh();
            rpt.Reset();
            ruleclasscode = customerplan.classcode.ToCharArray()[0];
            productcode = customerplan.productcode;
            ReportParameter paramOther = new ReportParameter("hideother", "Y");
            if (partins != null)
            {
                paramOther = new ReportParameter("hideother", "N");
            }
            PlanName = Productdata.getProduct(customerplan.productcode);
            PlanCode = customerplan.productcode;
            if (PlanName.Equals("Lighthouse"))
            {
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/LightHouse_long.rdlc");

            }
            else if (PlanName.Equals("Sentinel"))
            {
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/Sentinel_long.rdlc");
            }
            else if (PlanName.Equals("Orion"))
            {

                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/Orion_long.rdlc");

            }
            else if (PlanName.Equals("Orion Plus"))
            {

                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/OrionPlus_long.rdlc");

            }
            else if (PlanName.Equals("Guardian"))
            {

                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/Guardian_long.rdlc");

            }
            else if (PlanName.Equals("Guardian Plus"))
            {

                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/GuardianPlus_long.rdlc");

            }

            ReportDataSource rds = new ReportDataSource();
            dt = new DataTable();
            dttwo = new DataTable();
            Termillusdata[] illus = termfixed.getIllustration();
            if (illus.Count() > 0)
            {
                for (int i = 0; i < illus[0].getDatacolumns().Length; i++)
                {
                    dt.Columns.Add(new DataColumn(illus[0].getDatacolumns()[i]));
                }
                for (int i = 0; i < illus.Length; i++)
                {
                    dt.Rows.Add(illus[i].getDataarray());
                }
            }



            Termillusdata[] illustwo = termfixed.getIllustrationtwo();
            if (illustwo.Count() > 0)
            {
                for (int i = 0; i < illustwo[0].getDatacolumns().Length; i++)
                {
                    dttwo.Columns.Add(new DataColumn(illustwo[0].getDatacolumns()[i]));
                }
                for (int i = 0; i < illustwo.Length; i++)
                {
                    dttwo.Rows.Add(illustwo[i].getDataarray());
                }
            }

            //rds.
            rds.Name = "illustratorDataSet_termillusdet";

            rds.Value = dt;

            ReportDataSource rdstwo = new ReportDataSource();
            rdstwo.Name = "illustratorDataSet_termtwo";
            if (dttwo.Rows.Count >= 17 && dttwo.Rows.Count <= 20 || dttwo.Rows.Count >= 37 && dttwo.Rows.Count <= 40 ||
              dttwo.Rows.Count >= 57 && dttwo.Rows.Count <= 60 || dttwo.Rows.Count >= 77 && dttwo.Rows.Count <= 80 ||
              dttwo.Rows.Count >= 97 && dttwo.Rows.Count <= 100)
            {
                if (dttwo.Rows.Count == 17 || dttwo.Rows.Count == 37 || dttwo.Rows.Count == 57 || dttwo.Rows.Count == 77 || dttwo.Rows.Count == 97)
                {
                    DataRow myRow;
                    myRow = dttwo.NewRow();
                    dttwo.Rows.Add("", "", "", "", "", "", "");
                    dttwo.Rows.Add("", "", "", "", "", "", "");
                    dttwo.Rows.Add("", "", "", "", "", "", "");
                    dttwo.Rows.Add(myRow);
                    rdstwo.Value = dttwo;
                }
                else if (dttwo.Rows.Count == 18 || dttwo.Rows.Count == 38 || dttwo.Rows.Count == 58 || dttwo.Rows.Count == 78 || dttwo.Rows.Count == 98)
                {
                    DataRow myRow;
                    myRow = dttwo.NewRow();
                    dttwo.Rows.Add("", "", "", "", "", "", "");
                    dttwo.Rows.Add("", "", "", "", "", "", "");

                    dttwo.Rows.Add(myRow);
                    rdstwo.Value = dttwo;
                }
                else if (dttwo.Rows.Count == 19 || dttwo.Rows.Count == 39 || dttwo.Rows.Count == 59 || dttwo.Rows.Count == 79 || dttwo.Rows.Count == 99)
                {
                    DataRow myRow;
                    myRow = dttwo.NewRow();
                    dttwo.Rows.Add("", "", "", "", "", "", "");

                    dttwo.Rows.Add(myRow);
                    rdstwo.Value = dttwo;
                }
                else if (dttwo.Rows.Count == 20 || dttwo.Rows.Count == 40 || dttwo.Rows.Count == 60 || dttwo.Rows.Count == 80)
                {
                    DataRow myRow;
                    myRow = dttwo.NewRow();
                    dttwo.Rows.Add(myRow);
                    rdstwo.Value = dttwo;
                }
            }
            rdstwo.Value = dttwo;
            string spouseinsuredamt = "-";
            if (partins != null)
            {
                if (partins.amount != null)
                {
                    spouseinsuredamt = partins.amount.ToString();
                }

            }

            string adb1 = "";
            string tempr1 = "";
            string rideroir1 = "";

            string contributionperiod = "-";
            string termamount = "-";
            string calculate = "-";
            string freqofpayment = "-";
            string rideradbamount = "-";
            decimal annualizepremium = 0;

            string initialcontributionamount = "-";
            string ddlinitialcontribution = "-";
            decimal premiumamount = 0;
            string insuredamount = "-";
            string crticleillnessamount = "-";
            string maritalstatus = "-";
            string plantype = "-";
            string almillar = "-";
            string risk = "-";
            string rawreturn = "-";
            string culminationage = "-";

            WSRider rideradb = null;
            WSRider riderterm = null;

            if (riderslist != null)
            {
                foreach (WSRider rider in riderslist)
                {
                    if (rider.ridertypecode.Equals(WSRider.RIDERADB))
                    {
                        rideradb = rider;
                    }
                    else if (rider.ridertypecode.Equals(WSRider.RIDERTERM))
                    {
                        riderterm = rider;
                    }
                }


            }


            if (customerplan != null)
            {
                if (customerplan.contributionperiod != null)
                {
                    contributionperiod = customerplan.contributionperiod.ToString();
                }
                if (rideradb != null && rideradb.amount != null)
                {
                    rideradbamount = rideradb.amount.ToString();

                }
                if (riderterm != null && riderterm.amount != null)
                {
                    termamount = riderterm.amount.ToString();
                }
                if (customerplan.calculatetypecode != null)
                {
                    calculate = Lookuplangdata.getLanguagevalue(Lookuptables.calculatetypedet, Calculatetypes.getcalculatetype(customerplan.calculatetypecode.ToCharArray()[0]), "es");
                }
                if (customerplan.frequencytypecode != null)
                {
                    // freqofpayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode), Sessionclass.getSessiondata(Session).language);
                    freqofpayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode.ToCharArray()[0]), "es");

                }
                if (customerplan.premiumamount != null)
                {
                    annualizepremium = Numericdata.getDecimalvalue(termresult.annualpremiumamount.ToString());
                }

                if (customerplan.initialcontributionamount != null)
                {
                    if (Numericdata.getDoublevalue(customerplan.initialcontributionamount.ToString()) > 0)
                    {

                        initialcontributionamount = customerplan.initialcontributionamount.ToString();
                    }
                    else
                    {
                        initialcontributionamount = "0";
                    }
                }
                if (customerplan.initialcontributionamount != null)
                {
                    if (Numericdata.getDoublevalue(customerplan.initialcontributionamount.ToString()) > 0)
                    {
                        ddlinitialcontribution = Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "Yes", "es");
                    }
                    else
                    {
                        ddlinitialcontribution = Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "No", "es");

                    }
                }
                if (customerplan.premiumamount != null)
                {
                    if (Numericdata.getDoublevalue(customerplan.premiumamount.ToString()) > 0)
                    {
                        premiumamount = Numericdata.getDecimalvalue(customerplan.premiumamount.ToString());
                    }
                    else
                    {
                        premiumamount = 0;
                    }
                }
                if (customerplan.insuredamount != null)
                {
                    if (Numericdata.getDoublevalue(customerplan.insuredamount.ToString()) > 0)
                    {
                        insuredamount = customerplan.insuredamount.ToString();
                    }
                    else
                    {
                        insuredamount = "0";
                    }
                }
                //if (customerplan.riderciamount != null)
                //{
                //    if (Numericdata.getDoublevalue(customerplan.riderciamount.ToString()) > 0)
                //    {
                //        crticleillnessamount = customerplan.riderciamount.ToString();
                //    }
                //    else
                //    {
                crticleillnessamount = "0";
                //    }
                //}
                maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet, Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es");
                plantype = Lookuplangdata.getLanguagevalue(Lookuptables.plantypedet, Plantypes.getPlantype(customerplan.plantypecode.ToCharArray()[0]), "es");


                risk = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())), "es");



                almillar = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet, Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())), "es");


                rawreturn = (Numericdata.getDecimalvalue(customerplan.initialcontributionamount.ToString()) + Frequencytypes.getfrequencytypevaluefromcode(customerplan.frequencytypecode.ToCharArray()[0]) * customerplan.contributionperiod * Numericdata.getDecimalvalue(customerplan.premiumamount.ToString())).ToString("n2");

                culminationage = (Numericdata.getIntegervalue(customerplan.contributionperiod.ToString()) + customer.Age - 1).ToString();



            }
            //

            string rideroiramt = "-";
            string rideroirname = "-";
            string Riesgo = "-";
            string Fumador = "-";
            string Sexo = "-";
            string HastalaEdadde = "-";
            string Edad = "-";
            string AlMillar1 = "-";

            if (partins != null)
            {

                rideroiramt = partins.amount.ToString("n2");
                rideroirname = partins.firstname + " " + partins.middlename + " " + partins.lastname + " " + partins.LastName2;

                Fumador = Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, Booleandata.getBooleanstring(partins.smoker.ToCharArray()[0]), "es");
                Sexo = partins.gendercode.ToString();

                if (partins.contributiontype.Equals(Contributiontypes.CONTINUOUS.ToString()))
                    HastalaEdadde = "99";
                else if (partins.contributiontype.Equals(Contributiontypes.NUMBEROFYEARS.ToString()))
                    HastalaEdadde = (Convert.ToInt32(partins.age) + partins.term - 1).ToString();
                else if (partins.contributiontype.Equals(Contributiontypes.UNTILAGE.ToString()))
                    HastalaEdadde = partins.term.ToString();

                Edad = partins.age.ToString();

                Riesgo = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, Activityrisktypes.getActivityrisktype(partins.activityrisktypeno), "es");

                AlMillar1 = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet, Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(partins.healthrisktypeno.ToString())), "es");


            }

            string primaryreq = "-", otherreq = "-";

            List<WSExam> exams = termresult.primaryexamsrequiredlist;

            String[] req = new String[20];

            int examno = 0;
            foreach (WSExam exam in exams)
            {
                primaryreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es").ToUpper() + "/" + primaryreq;
                req[examno] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es");
                examno++;
            }

            string tempPrimary = " ";
            int lno1 = 0;

            for (int j = 0; j < req.Length; j++)
            {
                if (!string.IsNullOrEmpty(req[j]))
                    if (!req[j].Trim().Equals(""))
                    {
                        //tempPrimary += req[j] + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t";                            

                        //if(tempPrimary.Length % 80

                        tempPrimary += req[j];
                        if (j != (req.Length - 1))
                        {
                            tempPrimary += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t";
                        }
                        if (tempPrimary.Length > (lno1 + 1) * 150)
                        {
                            tempPrimary += Environment.NewLine;
                            lno1 = lno1 + 1;
                        }

                    }
            }
            //other

            exams = termresult.partnerexamsrequiredlist;

            String[] oreq = new String[12];

            int k = 0;
            foreach (WSExam exam in exams)
            {
                otherreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es").ToUpper() + "/" + otherreq;
                oreq[k] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es");
                k++;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();

            ReportParameter prmstatus1 = new ReportParameter("Color", "unchecked");
            paramlist.Add(prmstatus1);
            prmstatus1 = new ReportParameter("BN", "unchecked");
            paramlist.Add(prmstatus1);
            prmstatus1 = new ReportParameter("CompulsoryFigure", "checked");
            paramlist.Add(prmstatus1);
            string[] controllist = { "S100", "S101", "S102", "S103", "S104", "S105", "S200", "S201", "S202", "S203",
                                          "S204", "S205", "S206", "S207", "S300", "S301", "S302", "S303", "S304", "S305", "S306", "S307", "S308", "S400", "S401", "S402", "S403", "S404", "S405"
                                      , "S406", "S500", "S501", "S502", "S503", "S504", "S505"};
            for (int count1 = 0; count1 < controllist.Count(); count1++)
            {
                ReportParameter prmstatus = new ReportParameter(controllist[count1], "unchecked");
                paramlist.Add(prmstatus);
            }

            //foreach (Control ccontrol in this.pnlCustomize.Controls)
            //{
            //    if (ccontrol is CheckBox)
            //    {
            //        CheckBox myCheckbox = (CheckBox)ccontrol;
            //        if (myCheckbox.Checked == true)
            //        {
            //            ReportParameter prmstatus = new ReportParameter(myCheckbox.ID.Substring(3, myCheckbox.ID.Length - 3), "checked");
            //            paramlist.Add(prmstatus);
            //        }
            //        else
            //        {
            //            ReportParameter prmstatus = new ReportParameter(myCheckbox.ID.Substring(3, myCheckbox.ID.Length - 3), "unchecked");
            //            paramlist.Add(prmstatus);
            //        }
            //    }
            //}

            ReportParameter param100 = new ReportParameter("PolicyholderExams1", "" + tempPrimary);

            string tempOther = " ";
            if (partins != null)
            // if (customerplan.rideroir.ToString().Equals("Y"))
            {
                for (int j = 0; j < oreq.Length; j++)
                {
                    if (!string.IsNullOrEmpty(oreq[j]))
                        if (!oreq[j].Trim().Equals(""))
                            tempOther += oreq[j] + ", ";
                }
            }
            if (tempOther.Trim().Length > 0)
                tempOther = tempOther.Substring(0, tempOther.Length - 2);

            ReportParameter param112 = new ReportParameter("other1", "" + tempOther);


            paramlist.Add(paramOther);
            paramlist.Add(param112);
            paramlist.Add(param100);

            String[] clientsign = new string[3];
            String[] agentsign = new string[3];

            clientsign[0] = "N";
            clientsign[1] = "N";
            clientsign[2] = "N";

            agentsign[0] = "N";
            agentsign[1] = "N";
            agentsign[2] = "N";

            ReportParameter Cpath1 = new ReportParameter("clientsignpath1", "");// new ReportParameter("ClientPath1", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
            ReportParameter Apath1 = new ReportParameter("agentsignpath1", "");// new ReportParameter("AgentPath1", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
            ReportParameter Cpath2 = new ReportParameter("clientsignpath2", "");// new ReportParameter("ClientPath2", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
            ReportParameter Apath2 = new ReportParameter("agentsignpath2", "");// new ReportParameter("AgentPath2", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
            ReportParameter Cpath3 = new ReportParameter("clientsignpath3", "");// new ReportParameter("ClientPath3", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
            ReportParameter Apath3 = new ReportParameter("agentsignpath3", "");// new ReportParameter("AgentPath3", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));

            paramlist.Add(Cpath1);
            paramlist.Add(Apath1);
            paramlist.Add(Cpath2);
            paramlist.Add(Apath2);
            paramlist.Add(Cpath3);
            paramlist.Add(Apath3);


            List<rpt_compass_investment_master> st_rpt_compass_investment_master_moderado = (from item in newdb.rpt_compass_investment_masters
                                                                                             where item.ReturnType == "Moderado" && item.Region == "Americano/Internacional"
                                                                                             select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_moderado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_moderado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_moderado);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_moderado = (from item in newdb.rpt_compass_investment_details
                                                                                                   where item.ReturnTypeid == 1
                                                                                                   select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_moderado = new ReportDataSource("Charts_rpt_compass_investment_details_MODERADO", st_rpt_compass_investment_distribution_moderado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_moderado);
            List<rpt_compass_investment_master> st_rpt_compass_investment_master_balanceado = (from item in newdb.rpt_compass_investment_masters
                                                                                               where item.ReturnType == "Balanceado" && item.Region == "Americano/Internacional"
                                                                                               select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_balanceado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_balanceado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_balanceado);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_balanceado = (from item in newdb.rpt_compass_investment_details
                                                                                                     where item.ReturnTypeid == 3
                                                                                                     select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_balanceado = new ReportDataSource("Charts_rpt_compass_investment_details_BALANCEADO", st_rpt_compass_investment_distribution_balanceado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_balanceado);
            List<rpt_compass_investment_master> st_rpt_compass_investment_master_cricimiento = (from item in newdb.rpt_compass_investment_masters
                                                                                                where item.ReturnType == "Cricimiento" && item.Region == "Americano/Internacional"
                                                                                                select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_cricimiento);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_cricimiento);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_cricimiento = (from item in newdb.rpt_compass_investment_details
                                                                                                      where item.ReturnTypeid == 3
                                                                                                      select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_details_CRICIMIENTO", st_rpt_compass_investment_distribution_cricimiento);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_cricimiento);
            List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_moderado = (from item in newdb.rpt_compass_investment_masters
                                                                                                  where item.ReturnType == "Moderado" && item.Region == "Europeo"
                                                                                                  select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_euro_moderado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_moderado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_moderado);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_moderado = (from item in newdb.rpt_compass_investment_details
                                                                                                        where item.ReturnTypeid == 4
                                                                                                        select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_euro_moderado = new ReportDataSource("Charts_rpt_compass_investment_details_euro_MODERADO", st_rpt_compass_investment_distribution_euro_moderado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_moderado);
            List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_balanceado = (from item in newdb.rpt_compass_investment_masters
                                                                                                    where item.ReturnType == "Balanceado" && item.Region == "Europeo"
                                                                                                    select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_euro_balanceado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_balanceado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_balanceado);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_balanceado = (from item in newdb.rpt_compass_investment_details
                                                                                                          where item.ReturnTypeid == 5
                                                                                                          select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_euro_balanceado = new ReportDataSource("Charts_rpt_compass_investment_details_euro_BALANCEADO", st_rpt_compass_investment_distribution_euro_balanceado);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_balanceado);
            List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_cricimiento = (from item in newdb.rpt_compass_investment_masters
                                                                                                     where item.ReturnType == "Cricimiento" && item.Region == "Europeo"
                                                                                                     select item).ToList();
            ReportDataSource rds_rpt_compss_investment_master_euro_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_cricimiento);
            rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_cricimiento);
            List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_cricimiento = (from item in newdb.rpt_compass_investment_details
                                                                                                           where item.ReturnTypeid == 6
                                                                                                           select item).ToList();
            ReportDataSource rds_rpt_compass_investment_distribution_euro_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_details_euro_CRICIMIENTO", st_rpt_compass_investment_distribution_euro_cricimiento);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_cricimiento);

            List<rpt_compass_investment_detail> lst_rpt_compass_investment_yearreturn_americano =
                (from item in newdb.rpt_compass_investment_details
                 join o in newdb.rpt_compass_investment_masters
                 on item.ReturnTypeid equals o.Sno
                 where (item.Years == 2010 && o.Region == "Americano/Internacional")
                 select item).ToList();

            ReportDataSource rds_rpt_compass_investment_yearreturn_americano = new ReportDataSource("Charts_rpt_compass_investment_details_yearreturn_Americano", lst_rpt_compass_investment_yearreturn_americano);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_yearreturn_americano);
            List<rpt_compass_investment_detail> lst_rpt_compass_investment_yearreturn_europeo =
                    (from item in newdb.rpt_compass_investment_details
                     join o in newdb.rpt_compass_investment_masters
                     on item.ReturnTypeid equals o.Sno
                     where (item.Years == 2010 && o.Region == "Europeo")
                     select item).ToList();

            ReportDataSource rds_rpt_compass_investment_yearreturn_europeo = new ReportDataSource("Charts_rpt_compass_investment_details_yearreturn_Europeo", lst_rpt_compass_investment_yearreturn_europeo);
            rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_yearreturn_europeo);

            List<profile_de_inversion> lst_rpt_profile_de_inversion = (from item in newdb.profile_de_inversions
                                                                       select item).ToList();

            List<profile_de_inversion_euro> lst_rpt_profile_de_inversion_euro = (from item in newdb.profile_de_inversion_euros
                                                                                 select item).ToList();
            ReportDataSource rds_profile_de_inversion = new ReportDataSource("Charts_profile_de_inversion", lst_rpt_profile_de_inversion);
            rpt.LocalReport.DataSources.Add(rds_profile_de_inversion);
            ReportDataSource rds_profile_de_inversion_euro = new ReportDataSource("Charts_profile_de_inversion_euro", lst_rpt_profile_de_inversion_euro);
            rpt.LocalReport.DataSources.Add(rds_profile_de_inversion_euro);

            List<rpt_InvestType> lst_rpt_invest_distribution_Moderado = (from item in newdb.rpt_InvestTypes
                                                                         where item.FundCategory == "Moderado" && item.Region == "Americano/Internacional"
                                                                         select item).ToList();
            List<rpt_InvestType> lst_rpt_invest_distribution_Balanceado = (from item in newdb.rpt_InvestTypes
                                                                           where item.FundCategory == "Balanceado" && item.Region == "Americano/Internacional"
                                                                           select item).ToList();
            List<rpt_InvestType> lst_rpt_invest_distribution_Crecimiento = (from item in newdb.rpt_InvestTypes
                                                                            where item.FundCategory == "Crecimiento" && item.Region == "Americano/Internacional"
                                                                            select item).ToList();
            ReportDataSource rds_invest_distribution_Moderado = new ReportDataSource("Charts_rpt_InvestType_MODERADO", lst_rpt_invest_distribution_Moderado);
            rpt.LocalReport.DataSources.Add(rds_invest_distribution_Moderado);
            ReportDataSource rds_invest_distribution_Balanceado = new ReportDataSource("Charts_rpt_InvestType_BALANCEADO", lst_rpt_invest_distribution_Balanceado);
            rpt.LocalReport.DataSources.Add(rds_invest_distribution_Balanceado);
            ReportDataSource rds_invest_distribution_Crecimiento = new ReportDataSource("Charts_rpt_InvestType_CRECIMIENTO", lst_rpt_invest_distribution_Crecimiento);
            rpt.LocalReport.DataSources.Add(rds_invest_distribution_Crecimiento);
            List<rpt_InvestType> lst_rpt_invest_euro_distribution_Moderado = (from item in newdb.rpt_InvestTypes
                                                                              where item.FundCategory == "Moderado" && item.Region == "Europeo"
                                                                              select item).ToList();
            ReportDataSource rds_invest_euro_distribution_Moderado = new ReportDataSource("Charts_rpt_euro_InvestType_MODERADO", lst_rpt_invest_euro_distribution_Moderado);
            rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Moderado);
            List<rpt_InvestType> lst_rpt_invest_euro_distribution_Balanceado = (from item in newdb.rpt_InvestTypes
                                                                                where item.FundCategory == "Balanceado" && item.Region == "Europeo"
                                                                                select item).ToList();
            ReportDataSource rds_invest_euro_distribution_Balanceado = new ReportDataSource("Charts_rpt_euro_InvestType_BALANCEADO", lst_rpt_invest_euro_distribution_Balanceado);
            rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Balanceado);
            List<rpt_InvestType> lst_rpt_invest_euro_distribution_Crecimiento = (from item in newdb.rpt_InvestTypes
                                                                                 where item.FundCategory == "Crecimiento" && item.Region == "Europeo"
                                                                                 select item).ToList();
            ReportDataSource rds_invest_euro_distribution_Crecimiento = new ReportDataSource("Charts_rpt_euro_InvestType_CRECIMIENTO", lst_rpt_invest_euro_distribution_Crecimiento);
            rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Crecimiento);
            var totMonderadoBond = from mb in lst_rpt_invest_distribution_Moderado
                                   where mb.FundType == "Bond" && mb.FundCategory == "Moderado"
                                   group mb by mb.FundCategory into g
                                   select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var totMonderadoStock = from ms in lst_rpt_invest_distribution_Moderado
                                    where ms.FundType == "Stock" && ms.FundCategory == "Moderado"
                                    group ms by ms.FundCategory into g
                                    select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

            ReportParameter prmMonderadoBondShare = new ReportParameter("MonderadoBondShare", totMonderadoBond.First().total.ToString());
            paramlist.Add(prmMonderadoBondShare);
            ReportParameter prmMonderadoStockShare = new ReportParameter("MonderadoStockShare", totMonderadoStock.First().total.ToString());
            paramlist.Add(prmMonderadoStockShare);
            var totBalanceadoBond = from mb in lst_rpt_invest_distribution_Balanceado
                                    where mb.FundType == "Bond" && mb.FundCategory == "Balanceado"
                                    group mb by mb.FundCategory into g
                                    select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var totBalanceadoStock = from ms in lst_rpt_invest_distribution_Balanceado
                                     where ms.FundType == "Stock" && ms.FundCategory == "Balanceado"
                                     group ms by ms.FundCategory into g
                                     select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

            ReportParameter prmBalanceadoBondShare = new ReportParameter("BalanceadoBondShare", totBalanceadoBond.First().total.ToString());
            paramlist.Add(prmBalanceadoBondShare);
            ReportParameter prmBalanceadoStockShare = new ReportParameter("BalanceadoStockShare", totBalanceadoStock.First().total.ToString());
            paramlist.Add(prmBalanceadoStockShare);




            var totCrecimientoBond = from mb in lst_rpt_invest_distribution_Crecimiento
                                     where mb.FundType == "Bond" && mb.FundCategory == "Crecimiento"
                                     group mb by mb.FundCategory into g
                                     select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var totCrecimientoStock = from ms in lst_rpt_invest_distribution_Crecimiento
                                      where ms.FundType == "Stock" && ms.FundCategory == "Crecimiento"
                                      group ms by ms.FundCategory into g
                                      select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

            string shareCrecimientoBond;
            if (totCrecimientoBond.FirstOrDefault() != null)
            {
                shareCrecimientoBond = Convert.ToString(totCrecimientoBond.FirstOrDefault().total);
            }
            else
            {
                shareCrecimientoBond = "0";
            }

            ReportParameter prmCrecimientoBondShare = new ReportParameter("CrecimientoBondShare", shareCrecimientoBond);
            paramlist.Add(prmCrecimientoBondShare);
            ReportParameter prmCrecimientoStockShare = new ReportParameter("CrecimientoStockShare", totCrecimientoStock.First().total.ToString());
            paramlist.Add(prmCrecimientoStockShare);

            var euro_totBalanceadoBond = from mb in lst_rpt_invest_euro_distribution_Balanceado
                                         where mb.FundType == "Bond" && mb.FundCategory == "Balanceado"
                                         group mb by mb.FundCategory into g
                                         select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var euro_totBalanceadoStock = from ms in lst_rpt_invest_euro_distribution_Balanceado
                                          where ms.FundType == "Stock" && ms.FundCategory == "Balanceado"
                                          group ms by ms.FundCategory into g
                                          select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

            ReportParameter euro_prmBalanceadoBondShare = new ReportParameter("euro_BalanceadoBondShare", euro_totBalanceadoBond.First().total.ToString());
            paramlist.Add(euro_prmBalanceadoBondShare);
            ReportParameter euro_prmBalanceadoStockShare = new ReportParameter("euro_BalanceadoStockShare", euro_totBalanceadoStock.First().total.ToString());
            paramlist.Add(euro_prmBalanceadoStockShare);

            var euro_totMonderadoBond = from mb in lst_rpt_invest_euro_distribution_Moderado
                                        where mb.FundType == "Bond" && mb.FundCategory == "Moderado"
                                        group mb by mb.FundCategory into g
                                        select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var euro_totMonderadoStock = from ms in lst_rpt_invest_euro_distribution_Moderado
                                         where ms.FundType == "Stock" && ms.FundCategory == "Moderado"
                                         group ms by ms.FundCategory into g
                                         select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

            ReportParameter euro_prmMonderadoBondShare = new ReportParameter("euro_MonderadoBondShare", euro_totMonderadoBond.First().total.ToString());
            paramlist.Add(euro_prmMonderadoBondShare);
            ReportParameter euro_prmMonderadoStockShare = new ReportParameter("euro_MonderadoStockShare", euro_totMonderadoStock.First().total.ToString());
            paramlist.Add(euro_prmMonderadoStockShare);

            var euro_totCrecimientoBond = from mb in lst_rpt_invest_distribution_Crecimiento
                                          where mb.FundType == "Bond" && mb.FundCategory == "Crecimiento"
                                          group mb by mb.FundCategory into g
                                          select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

            var euro_totCrecimientoStock = from ms in lst_rpt_invest_distribution_Crecimiento
                                           where ms.FundType == "Stock" && ms.FundCategory == "Crecimiento"
                                           group ms by ms.FundCategory into g
                                           select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };




            string euro_shareCrecimientoBond;
            if (totCrecimientoBond.FirstOrDefault() != null)
            {
                euro_shareCrecimientoBond = Convert.ToString(euro_totCrecimientoBond.FirstOrDefault().total);
            }
            else
            {
                euro_shareCrecimientoBond = "0";
            }

            ReportParameter euro_prmCrecimientoBondShare = new ReportParameter("euro_CrecimientoBondShare", euro_shareCrecimientoBond);
            paramlist.Add(euro_prmCrecimientoBondShare);
            ReportParameter euro_prmCrecimientoStockShare = new ReportParameter("euro_CrecimientoStockShare", euro_totCrecimientoStock.First().total.ToString());
            paramlist.Add(euro_prmCrecimientoStockShare);



            List<rpt_lifeexpectancy> rpt_Life_Expectancy = (from item in newdb.rpt_lifeexpectancies
                                                            select item).ToList();


            decimal MaxAge = 0;
            if (customer.gendercode.ToString() == "M")
            {
                MaxAge = Convert.ToDecimal((from item in rpt_Life_Expectancy where item.Current_Age == 0 select item.Men).First());
            }
            else if (customer.gendercode.ToString() == "F")
            {
                MaxAge = Convert.ToDecimal((from item in rpt_Life_Expectancy where item.Current_Age == 0 select item.Woman).First());
            }

            //decimal LifeExpectancy = MaxAge - Convert.ToDecimal(customer.Age);

            ReportParameter param110 = new ReportParameter("LifeExpectancy", (MaxAge - Convert.ToDecimal(customer.Age)).ToString());
            paramlist.Add(param110);
            ReportDataSource lifeexpetancy = new ReportDataSource("Charts_rpt_lifeexpectancy", rpt_Life_Expectancy);
            rpt.LocalReport.DataSources.Add(lifeexpetancy);

            string Prospect = (((customer.FirstName + " " + customer.MiddleName).Trim() + " " + customer.LastName).Trim() + " " + customer.LastName2).Trim();
            if (PlanName == "")
            {
                const int MaxLengthHeading = 30;
                const int MaxLengthName = 50;
                var custHeading = (customer.FirstName + " " + customer.LastName).Trim();
                var custName = (customer.FirstName + " " + customer.LastName).Trim();
                if (custHeading.Length > MaxLengthHeading)
                {
                    custHeading = custHeading.Substring(0, MaxLengthHeading);
                    custHeading = custHeading + "...";
                }
                if (custName.Length > MaxLengthName)
                {
                    custName = custName.Substring(0, MaxLengthName);
                    custName = custName + "...";
                }
                ReportParameter param1 = new ReportParameter("heading", custHeading);
                ReportParameter param3 = new ReportParameter("name", custName);
                paramlist.Add(param1);
                paramlist.Add(param3);
            }
            else
            {
                const int MaxLengthHeading = 25;
                const int MaxLengthName = 50;
                var custHeading = (customer.FirstName + " " + customer.LastName).Trim();
                var custName = (customer.FirstName + " " + customer.LastName).Trim();
                if (custHeading.Length > MaxLengthHeading)
                {
                    custHeading = custHeading.Substring(0, MaxLengthHeading);
                    custHeading = custHeading + "...";
                }
                if (custName.Length > MaxLengthName)
                {
                    custName = custName.Substring(0, MaxLengthName);
                    custName = custName + "...";
                }
                ReportParameter param1 = new ReportParameter("heading", custHeading);
                ReportParameter param3 = new ReportParameter("name", custName);
                paramlist.Add(param1);
                paramlist.Add(param3);
            }
            ReportParameter param135 = new ReportParameter("lastname", customer.LastName.ToString());
            paramlist.Add(param135);
            ReportParameter param4 = new ReportParameter("periodofcontribution", customerplan.contributionperiod + "");

            //ReportParameter param135 = new ReportParameter("lastname", customer.LastName.ToString());
            //paramlist.Add(param135);
            //ReportParameter param2 = new ReportParameter("date", DateTime.Now.ToShortDateString());


            //ReportParameter param5 = new ReportParameter("amountofcontribution", GetFormatedText(customerplan.initialcontribution + ""));
            ReportParameter param5 = new ReportParameter("amountofcontribution", GetFormatedText(initialcontributionamount.ToString()));
            ReportParameter param6 = new ReportParameter("premiumamount", premiumamount.ToString("n2"));
            ReportParameter param7 = new ReportParameter("withdrawalamount", GetFormatedText(insuredamount));

            //ReportParameter param8 = new ReportParameter("plantype", plantype + "");//Plantypes.getPlantype(customerplan.plantypecode));
            ReportParameter param8 = new ReportParameter("plantype", "Temporal" + "");//Plantypes.getPlantype(customerplan.plantypecode));

            ReportParameter param9 = new ReportParameter("age", customer.Age + "");
            ReportParameter param10 = new ReportParameter("gender", customer.gendercode + "");//Genders.getgender(customer.gendercode));
            ReportParameter param11 = new ReportParameter("smoker", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, Booleandata.getBooleanstring(customer.Smoker.ToCharArray()[0]), "es"));

            ReportParameter param12 = new ReportParameter("ageatretirement", customerplan.contributionuntilage + "");
            ReportParameter param13 = new ReportParameter("risk", risk);//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
            ReportParameter param14 = new ReportParameter("almillar", almillar);//Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())));
            ReportParameter param15 = new ReportParameter("maritalstatus", maritalstatus);//Maritalstatus.getmaritalstatus(customer.MaritalStatuscode.Value));
            //ReportParameter param16 = new ReportParameter("suminsured", ((String.Format("{0:n0}", Numericdata.getDoublevalue((customerplan.insuredamount + customerplan.ridertermamount).ToString())).Replace('.', '/')).Replace(',', '.')).Replace('/', ','));
            ReportParameter param16 = new ReportParameter("suminsured", (customerplan.insuredamount + (riderterm != null ? riderterm.amount : 0)).ToString("n2"));
            ReportParameter param17 = new ReportParameter("annualpremium", annualizepremium.ToString("n2"));
            ReportParameter param18 = new ReportParameter("period", freqofpayment);
            ReportParameter param19 = new ReportParameter("calcular", calculate);
            //ReportParameter param20 = new ReportParameter("additionaltemporary", Booleandata.getBooleanstring(customerplan.riderterm));
            ReportParameter param20 = new ReportParameter("additionaltemporary", riderterm != null ? riderterm.amount.ToString("n2") : "");
            ReportParameter param21;
            if (customerplan.classcode.ToString().Equals("R"))
            {
                param21 = new ReportParameter("kind", "RD$");
            }
            else
            {
                param21 = new ReportParameter("kind", customerplan.classcode.ToString());
            }
            ReportParameter param22 = new ReportParameter("country", Lookuplangdata.getLanguagevalue(Lookuptables.countrydet, Countries.getcountry(Numericdata.getIntegervalue(customerplan.countryno + "")), Langdata.LANGUAGE_SPANISH));//Sessionclass.getSessiondata(Session).language));
            ReportParameter param23 = new ReportParameter("initialcontribution", ddlinitialcontribution);

            //ReportParameter param24 = new ReportParameter("accidentaldeath", Booleandata.getBooleanstring(customerplan.rideradb));

            ReportParameter param24 = new ReportParameter("accidentaldeath", rideradb != null ? rideradb.amount.ToString("n2") : "");

            ReportParameter param25 = new ReportParameter("spouceinsurance", rideroirname);
            ReportParameter param26 = new ReportParameter("primatarget", termresult.targetpremiumamount.ToString("n2"));
            ReportParameter param27 = new ReportParameter("timeinsurance", contributionperiod);
            ReportParameter param28 = new ReportParameter("financialgoals", customerplan.financialgoal + "");
            ReportParameter param29 = new ReportParameter("plan", Productdata.getProduct(customerplan.productcode));
            //ReportParameter param120_1 = new ReportParameter("date", getspanishmonth(DateTime.Now.ToString("MMMM")) + " " + DateTime.Now.ToString("dd, yyyy"));
            ReportParameter param120_1 = new ReportParameter("date", getspanishmonth(Int32.Parse(DateTime.Now.ToString("MM"))) + " " + DateTime.Now.ToString("dd, yyyy"));
            paramlist.Add(param120_1);
            ////ReportParameter param30 = new ReportParameter("descriptionline", Generalmethods.getDescriptionline(Productdata.getProduct(customerplan.productcode), initialcontributionamount));
            ReportParameter param81 = new ReportParameter("class", customerplan.classcode.ToString());
            paramlist.Add(param81);
            ReportParameter paramsib = new ReportParameter("suminsuredbase", (customerplan.insuredamount.ToString("n2")));
            paramlist.Add(paramsib);

            string investmentprofile = "-";
            ReportParameter param26_12 = new ReportParameter("investmentprofile", investmentprofile + "");
            paramlist.Add(param26_12);
            ReportParameter param76_12 = new ReportParameter("PaymentFrequency", freqofpayment);
            paramlist.Add(param76_12);
            string desc = "";
            string desc1 = "";
            if (customerplan.productcode.Equals("LGT"))
                desc = Generalmethods.getLightHouseDescriptionline(contributionperiod);
            else if (customerplan.productcode.Equals("SNT"))
                desc = Generalmethods.getSentinalDescriptionline(contributionperiod);
            desc1 = Generalmethods.getSentinalDescriptionline(contributionperiod);

            ReportParameter param30 = new ReportParameter("descriptionline", desc);


            ReportParameter param31 = new ReportParameter("lastline", Generalmethods.getLastlineTerm(productcode, Prospect, new Random().Next(1, 20), customerplan.classcode.ToString().ToCharArray()[0]));
            ReportParameter param33 = new ReportParameter("InitialContributionAmount", GetFormatedText(initialcontributionamount));
            ReportParameter param34 = new ReportParameter("Temporal", "-");
            ReportParameter param35 = new ReportParameter("PeriodoContribucion1", "-");
            ReportParameter param63 = new ReportParameter("PolicyholderSubscriptionRequirements", primaryreq);
            ReportParameter param64 = new ReportParameter("UnderwritingRequirementsAdditionalInsured", otherreq);
            ReportParameter param65 = new ReportParameter("Riesgo", Riesgo);
            ReportParameter param66 = new ReportParameter("AlMillar1", AlMillar1);
            ReportParameter param67 = new ReportParameter("Edad", Edad);
            ReportParameter param68 = new ReportParameter("Fumador", Fumador);
            ReportParameter param69 = new ReportParameter("Sexo", Sexo);
            ReportParameter param70 = new ReportParameter("ForYears", HastalaEdadde);
            ReportParameter param71 = new ReportParameter("HastalaEdadde", HastalaEdadde);
            ReportParameter param72 = new ReportParameter("AccidentalAmount", GetFormatedText(rideradbamount));
            ReportParameter param73 = new ReportParameter("TemporalAdicionalForYears", riderterm != null ? riderterm.term + "" : "");
            ReportParameter param74 = new ReportParameter("TemporalAdicionalAmount", GetFormatedText(riderterm != null ? riderterm.amount.ToString() : ""));
            ReportParameter param75 = new ReportParameter("criticleillness", Booleandata.getBooleanstring('N'));
            ReportParameter param76 = new ReportParameter("BottomText", "Esta propuesta es válida por 15 días y en  ningún caso más allá del " + DateTime.DaysInMonth(DateTime.Now.Year, 12) + "/" + 12 + "/" + DateTime.Now.Year + " (v2)");
            ReportParameter param77 = new ReportParameter("rideroiramount", (rideroiramt));
            ReportParameter param78 = new ReportParameter("ValueAccount", "-");
            ReportParameter param82 = new ReportParameter("foryear", "Por Años");
            ReportParameter param83 = new ReportParameter("withdrawalperiod", "-");
            ReportParameter param84 = new ReportParameter("rideroirname", rideroirname);
            ReportParameter param85 = new ReportParameter("crticleillnessamount", GetFormatedText(crticleillnessamount));

            //if ((hdnCheckedSettings.Value != "") || (hdnUnCheckedSettings.Value != ""))
            //{
            //    string[] checkedSettings = hdnCheckedSettings.Value.ToString().TrimStart(',').Split(',');
            //    string[] unCheckedSettings = hdnUnCheckedSettings.Value.ToString().TrimStart(',').Split(',');

            //    for (int counter1 = 0; counter1 < checkedSettings.Count(); counter1++)
            //    {
            //        ReportParameter visibilityParam = new ReportParameter(checkedSettings[counter1].ToString(), "checked");
            //        paramlist.Add(visibilityParam);
            //    }

            //    for (int counter2 = 0; counter2 < unCheckedSettings.Count(); counter2++)
            //    {
            //        if (unCheckedSettings[counter2].ToString() == null || unCheckedSettings[counter2].ToString() == "")
            //        {
            //        }
            //        else
            //        {
            //            ReportParameter visibilityParam = new ReportParameter(unCheckedSettings[counter2].ToString(), "unchecked");
            //            paramlist.Add(visibilityParam);
            //        }
            //    }


            //} 

            ReportParameter param308 = new ReportParameter("S308", "unchecked");
            paramlist.Add(param308);
            ReportParameter param124 = new ReportParameter("number", "");//txtnumber.Text);
            ReportParameter param125 = new ReportParameter("culminationage", culminationage + "");
            //ReportParameter param126 = null;
            //if (partins ==null)
            //{
            //    param126 = new ReportParameter("rideroir", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "No", "es"));
            //}
            //else
            //{
            //    param126 = new ReportParameter("rideroir", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "Yes", "es"));
            //}

            //ReportParameter param127 = new ReportParameter("Impuesto", (Convert.ToDouble(premiumamount) * 0.16).ToString("n2"));
            //ReportParameter param128 = new ReportParameter("primatotal", (Convert.ToDouble(premiumamount) + (Convert.ToDouble(premiumamount) * 0.16)).ToString("n2"));
            //ReportParameter param129 = new ReportParameter("Totalsuminsured", Numericdata.getDoublevalue((customerplan.insuredamount + (riderterm != null ? riderterm.amount : 0)).ToString()).ToString("n2"));


            ReportParameter paramcnp = new ReportParameter("contributionperiod", "PERÍODO INICIAL:" + " " + customerplan.contributionperiod + "Años - Prima Nivelada Garantizada");
            paramlist.Add(paramcnp);


            if (customerplan.productcode.Equals("SNT"))
            {
                ReportParameter paramrop = new ReportParameter("returnamount", rawreturn);
                paramlist.Add(paramrop);

            }

            // paramlist.Add(param2);
            //paramlist.Add(param1);
            //paramlist.Add(param2);
            //paramlist.Add(param3);
            paramlist.Add(param4);
            paramlist.Add(param5);
            paramlist.Add(param6);
            paramlist.Add(param7);
            paramlist.Add(param8);
            paramlist.Add(param9);
            paramlist.Add(param10);
            paramlist.Add(param11);
            paramlist.Add(param12);
            paramlist.Add(param13);
            paramlist.Add(param14);
            paramlist.Add(param15);
            paramlist.Add(param16);
            paramlist.Add(param17);
            paramlist.Add(param18);
            paramlist.Add(param19);
            paramlist.Add(param20);
            paramlist.Add(param21);
            paramlist.Add(param22);
            paramlist.Add(param23);
            paramlist.Add(param24);
            paramlist.Add(param25);
            paramlist.Add(param26);
            paramlist.Add(param27);
            paramlist.Add(param28);
            paramlist.Add(param29);
            paramlist.Add(param30);

            paramlist.Add(param31);
            paramlist.Add(param33);
            paramlist.Add(param34);
            paramlist.Add(param35);
            paramlist.Add(param63);
            paramlist.Add(param64);
            paramlist.Add(param65);
            paramlist.Add(param66);
            paramlist.Add(param67);
            paramlist.Add(param68);
            paramlist.Add(param69);
            paramlist.Add(param70);
            paramlist.Add(param71);
            paramlist.Add(param72);
            paramlist.Add(param73);
            paramlist.Add(param74);
            paramlist.Add(param75);
            paramlist.Add(param76);
            paramlist.Add(param77);
            paramlist.Add(param78);
            paramlist.Add(param83);
            paramlist.Add(param84);
            paramlist.Add(param82);
            paramlist.Add(param85);
            paramlist.Add(param124);
            paramlist.Add(param125);
            // paramlist.Add(param126);
            //paramlist.Add(param127);
            //paramlist.Add(param128);
            //paramlist.Add(param129);

            //ReportParameter param504 = new ReportParameter("S504", "unchecked");
            //paramlist.Add(param504);


            List<rpt_investments_inflacion> rpt_investment = (from item in newdb.rpt_investments_inflacions
                                                              select item).ToList();
            var count = rpt_investment.Count();
            var inflation_Last = (from ms in rpt_investment
                                  select new { ms.Pequenas_Acciones, ms.Grandes_Acciones, ms.Papelesdel_Tesoro, ms.Bonosdel_Gobierno, ms.Inflacion }).Last();
            var inflation_first = (from ms in rpt_investment
                                   select new { ms.Pequenas_Acciones, ms.Grandes_Acciones, ms.Papelesdel_Tesoro, ms.Bonosdel_Gobierno, ms.Inflacion }).First();
            var percent_Pequenas_last = inflation_Last.Pequenas_Acciones;
            var percent_Pequenas_First = inflation_first.Pequenas_Acciones;
            var Grandes_Acciones_last = inflation_Last.Grandes_Acciones;
            var Grandes_Acciones_First = inflation_first.Grandes_Acciones;
            var Papelesdel_Tesoro_last = inflation_Last.Papelesdel_Tesoro;
            var Papelesdel_Tesoro_First = inflation_first.Papelesdel_Tesoro;
            var Bonosdel_Gobierno_last = inflation_Last.Bonosdel_Gobierno;
            var Bonosdel_Gobierno_First = inflation_first.Bonosdel_Gobierno;
            var Inflacion1_last = inflation_Last.Inflacion;
            var Inflacion1_First = inflation_first.Inflacion;


            var result_total = percent_Pequenas_last / percent_Pequenas_First;
            var numberofyears = 0.0119;
            var Pequenas_percent = (Math.Pow(Convert.ToDouble(result_total), numberofyears) - 1) * 100;

            var result1_total = Grandes_Acciones_last / Grandes_Acciones_First;
            var numberofyears1 = 0.0119;
            var Grandes_percent = (Math.Pow(Convert.ToDouble(result1_total), numberofyears1) - 1) * 100;

            var result2_total = Papelesdel_Tesoro_last / Papelesdel_Tesoro_First;
            var numberofyears2 = 0.0119;
            var Papelesdel_percent = (Math.Pow(Convert.ToDouble(result2_total), numberofyears2) - 1) * 100;

            var result3_total = Bonosdel_Gobierno_last / Bonosdel_Gobierno_First;
            var numberofyears3 = 0.0119;
            var Bonosdel_percent = (Math.Pow(Convert.ToDouble(result3_total), numberofyears3) - 1) * 100;

            var result4_total = Inflacion1_last / Inflacion1_First;
            var numberofyears4 = 0.0119;
            var Inflacion_percent = (Math.Pow(Convert.ToDouble(result4_total), numberofyears4) - 1) * 100;


            ReportParameter Pequenas_Acciones = new ReportParameter("Pequenas_Acciones", Pequenas_percent.ToString());
            ReportParameter Grandes = new ReportParameter("Grandes", Grandes_percent.ToString());
            ReportParameter Papelesdel_Tesoro = new ReportParameter("Papelesdel_Tesoro", Papelesdel_percent.ToString());
            ReportParameter Bonosdel_Gobierno = new ReportParameter("Bonosdel_Gobierno", Bonosdel_percent.ToString());
            ReportParameter Inflacion = new ReportParameter("Inflacion", Inflacion_percent.ToString());
            paramlist.Add(Pequenas_Acciones);
            paramlist.Add(Grandes);
            paramlist.Add(Papelesdel_Tesoro);
            paramlist.Add(Bonosdel_Gobierno);
            paramlist.Add(Inflacion);


            if (PlanName.Equals("Sentinel"))
            {
                ReportParameter param30_12 = new ReportParameter("descriptionline1", desc1);
                paramlist.Add(param30_12);

            }


            string untilAge = "-";

            if (riderterm != null)
            {
                if (riderterm.type.Equals(Contributiontypes.CONTINUOUS.ToString()))
                    untilAge = "99";
                else if (riderterm.type.Equals(Contributiontypes.NUMBEROFYEARS.ToString()))
                    untilAge = (Convert.ToInt32(customer.Age) + riderterm.term - 1).ToString();
                else if (riderterm.type.Equals(Contributiontypes.UNTILAGE.ToString()))
                    untilAge = riderterm.term.ToString();
            }

            ReportParameter paramAdditionalTermUntilAge = new ReportParameter("AdditionalTermUntilAge", untilAge);

            paramlist.Add(paramAdditionalTermUntilAge);


            maritalstatus = "-";

            if (partins != null)
            {
                maritalstatus = Maritalstatus.getmaritalstatus(Convert.ToString(partins.maritalstatuscode));
                lookupdatadet mstatus = (from item in newdb.lookupdatadets
                                         where item.tablename.Equals("maritalstatusdet") && item.lookupcaption.Equals(maritalstatus)
                                         select item).SingleOrDefault();
                if (mstatus != null)
                    maritalstatus = mstatus.spanish;
            }

            ReportParameter paramSpouseMaritalStatus = new ReportParameter("SpouseMaritalStatus", maritalstatus);
            paramlist.Add(paramSpouseMaritalStatus);

            string temp = "-";
            if (riderterm != null)
                temp = GetFormatedText(riderterm.amount.ToString());

            // ReportParameter paramRiderAmount1 = new ReportParameter("RiderAmount1", temp);
            temp = "-";
            if (rideradb != null)
                temp = GetFormatedText(rideradb.amount.ToString());

            // ReportParameter paramRiderAmount2 = new ReportParameter("RiderAmount2", temp);

            string partinsRiderOirAmount = "-";
            //if (customerplan.rideroir.ToString().Equals("Y"))
            if (partins != null)
                partinsRiderOirAmount = GetFormatedText(partins.amount.ToString());

            //  ReportParameter paramRiderAmount3 = new ReportParameter("RiderAmount3", partinsRiderOirAmount);

            untilAge = "-";

            if (riderterm != null)
            {
                if (riderterm.type.Equals(Contributiontypes.CONTINUOUS.ToString()))
                    untilAge = "99";
                else if (riderterm.type.Equals(Contributiontypes.NUMBEROFYEARS.ToString()))
                    untilAge = (Convert.ToInt32(customer.Age) + riderterm.term - 1).ToString();
                else if (riderterm.type.Equals(Contributiontypes.UNTILAGE.ToString()))
                    untilAge = riderterm.term.ToString();
            }

            if (untilAge.Equals("0"))
                untilAge = "-";

            string untilAge2 = "-";


            if (partins != null)
            {
                if (partins.contributiontype.Equals(Contributiontypes.CONTINUOUS.ToString()))
                    untilAge2 = "99";
                else if (partins.contributiontype.Equals(Contributiontypes.NUMBEROFYEARS.ToString()))
                    untilAge2 = (Convert.ToInt32(partins.age) + partins.term - 1).ToString();
                else if (partins.contributiontype.Equals(Contributiontypes.UNTILAGE.ToString()))
                    untilAge2 = partins.term.ToString();
            }

            if (untilAge2.Equals("0"))
                untilAge2 = "-";

            //  ReportParameter paramRiderUntilAge1 = new ReportParameter("RiderUntilAge1", untilAge);
            //ReportParameter paramRiderUntilAge2 = new ReportParameter("RiderUntilAge2", "65");
            // ReportParameter paramRiderUntilAge2 = new ReportParameter("RiderUntilAge2", untilAge2);


            //paramlist.Add(paramRiderAmount1);
            //paramlist.Add(paramRiderAmount2);
            //paramlist.Add(paramRiderAmount3);
            //paramlist.Add(paramRiderUntilAge1);
            //paramlist.Add(paramRiderUntilAge2);


            List<rpt_Compass_Slide5> rpt_Compass_Slide5 = (from item in newdb.rpt_Compass_Slide5s
                                                           select item).ToList();
            List<rpt_Compass_slide7> Compass_slide7 = (from item in newdb.rpt_Compass_slide7s
                                                       select item).ToList();

            foreach (rpt_Compass_slide7 item in Compass_slide7)
            {
                if (item.Continent == "Europa")
                {
                    ReportParameter param60 = new ReportParameter("Europe_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param61 = new ReportParameter("Europe_Area", item.Area.ToString() + " Km2");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param60);
                    paramlist.Add(param61);
                }
                else if (item.Continent == "Mediterráneo Oriental")
                {
                    ReportParameter param62 = new ReportParameter("Eastern_Mediterranean_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param130 = new ReportParameter("Eastern_Mediterranean_Area", item.Area.ToString() + " Km2");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param62);
                    paramlist.Add(param130);
                }
                else if (item.Continent == "Pacífico Occidental")
                {
                    ReportParameter param131 = new ReportParameter("Pacífico_Occidental_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param132 = new ReportParameter("Pacífico_Occidental_Area", item.Area.ToString() + " Km2");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param131);
                    paramlist.Add(param132);
                }
                else if (item.Continent == "Asia Sur Oriental")
                {
                    ReportParameter param133 = new ReportParameter("Asia_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param105 = new ReportParameter("Asia_Area", item.Area.ToString());//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param133);
                    paramlist.Add(param105);
                }
                else if (item.Continent == "Centro y Suramérica")
                {
                    ReportParameter param106 = new ReportParameter("america_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param107 = new ReportParameter("america_Area", item.Area.ToString() + " Km2");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param106);
                    paramlist.Add(param107);
                }
                else if (item.Continent == "Africa")
                {
                    ReportParameter param108 = new ReportParameter("Africa_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param109 = new ReportParameter("Africa_Area", item.Area.ToString() + " Km2");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    paramlist.Add(param108);
                    paramlist.Add(param109);
                }
            }

            string sup = "";
            if (rideradb != null || riderterm != null || partins != null)
            {
                //sup = Generalmethods.getsuplementosline(customerplan.rideradb.ToString(), customerplan.riderterm.ToString(), customerplan.rideroir.ToString(), customerplan.rideradbamount != null ? Program.getCurrencyString(ruleclasscode,double.Parse( customerplan.rideradbamount.ToString())) : "", customerplan.ridertermamount != null ? Program.getCurrencyString(ruleclasscode, double.Parse(customerplan.ridertermamount.ToString())) : "",partins!=null? partins.rideroiramount!=null? Program.getCurrencyString(ruleclasscode,double.Parse( partins.rideroiramount.ToString())):"":"", untilAge, HastalaEdadde);
                sup = Generalmethods.getsuplementoslineNew(rideradb != null ? "Y" : "N", riderterm != null ? "Y" : "N", partins != null ? "Y" : "N", rideradb != null ? rideradb.amount.ToString() : "", riderterm != null ? riderterm.amount.ToString() : "", partins != null ? partins.amount != null ? partins.amount.ToString() : "" : "", untilAge, HastalaEdadde, ruleclasscode);

            }
            else
            {
                sup = "Este Plan no tiene coberturas adicionales.";
            }
            //ReportParameter param134 = new ReportParameter("suplementos", sup);
            //paramlist.Add(param134);

            ReportDataSource Compassslide7 = new ReportDataSource("Charts_rpt_Compass_slide7", Compass_slide7);

            ReportDataSource Compassslide5 = new ReportDataSource("Charts_rpt_Compass_Slide5", rpt_Compass_Slide5);

            rpt.LocalReport.DataSources.Add(Compassslide5);
            rpt.LocalReport.DataSources.Add(Compassslide7);



            rpt.LocalReport.EnableExternalImages = true;
            rpt.LocalReport.SetParameters(paramlist);

            rpt.LocalReport.DataSources.Add(rds);
            rpt.LocalReport.DataSources.Add(rdstwo);
            rpt.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            bytes = rpt.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            //if (classicmode == true)
            //{
            //    dvReport.Visible = true;
            //    dvpdf.Visible = false;
            //    this.ReportViewer1.LocalReport.Refresh();
            //}
            //else if (customize == false)
            //{
            //    dvpdf.Visible = true;
            //    dvReport.Visible = false;
            //    Warning[] warnings;
            //    string[] streamIds;
            //    string mimeType = string.Empty;
            //    string encoding = string.Empty;
            //    string extension = string.Empty;
            //    byte[] bytes = this.ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            //    MyGlobals.reportbytes = bytes;
            //    String strfilename = System.IO.Path.GetRandomFileName();
            //    Sessionclass.setIllustrationfilename(Session, strfilename + ".pdf");
            //    using (FileStream fs = new FileStream(Server.MapPath("~/pdfoutput/") + strfilename + ".pdf", FileMode.Create))
            //    {
            //        fs.Write(bytes, 0, bytes.Length);
            //    }
            //    /*
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append("<object data='" + "pdfoutput/" + strfilename + ".pdf" + "' type='application/pdf' width='916' height='470'>");
            //    sb.Append("</object>");
            //    this.dvpdf.InnerHtml = sb.ToString();
            //     */
            //    this.dvpdf.InnerHtml = getObjectString(strfilename);



            //}


            return bytes;

        }

        public static byte[] showIllustrationLife(WSLifeResult liferesult, WSCustomer customer, WSCustomerPlan customerplan, IMainInsuranceData insmaindata, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            byte[] bytes = null;
            try
            {

                DataVOUniversalDataContext newdb = Program.getDbConnection();

                customerplan.insuredamount = liferesult.insuredamount;
                customerplan.premiumamount = liferesult.periodicpremiumamount;

                rpt = new ReportViewer();
                rpt.LocalReport.Refresh();
                rpt.Reset();
                ruleclasscode = customerplan.classcode.ToCharArray()[0];


                ReportParameter paramPlanOption1 = new ReportParameter("PlanOption1", "");
                ReportParameter paramPlanOption2 = new ReportParameter("PlanOption2", "");
                ReportParameter paramPlanOption3 = new ReportParameter("PlanOption3", "");
                ReportParameter paramPlanOption4 = new ReportParameter("PlanOption4", "");
                ReportParameter paramPlanOption5 = new ReportParameter("PlanOption5", "");
                ReportParameter paramPlanOption6 = new ReportParameter("PlanOption6", "");




                ReportParameter paramOther = new ReportParameter("hideother", "Y");

                if (partins != null)
                {
                    paramOther = new ReportParameter("hideother", "N");
                }
                PlanName = Productdata.getProduct(customerplan.productcode);
                PlanCode = customerplan.productcode;
                if (PlanName.Equals("Legacy"))
                {
                    rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/Legacy_long.rdlc");

                }
                else if (PlanName.Equals("Compass Index"))
                {
                    rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/Compass_Index_long.rdlc");
                }
                else if (PlanName.Equals("Compass"))
                {
                    rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Landscape/Compass_long.rdlc");
                }

                Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource();
                //rds.
                rds.Name = "illustratorDataSet_illusdet";
                dt = new DataTable();
                Illusdata[] illus = insmaindata.getIllustration();
                for (int i1 = 0; i1 < illus[0].getDatacolumns().Length; i1++)
                {
                    dt.Columns.Add(new DataColumn(illus[0].getDatacolumns()[i1]));
                }
                for (int i1 = 0; i1 < illus.Length; i1++)
                {
                    dt.Rows.Add(illus[i1].getDataarray());
                }
                // for csv
                //for (int i = 0; i < illus[0].getDatacolumns_test().Length; i++)
                //{
                //    dtcsv.Columns.Add(new DataColumn(illus[0].getDatacolumns_test()[i]));
                //}
                //for (int i = 0; i < illus.Length; i++)
                //{
                //    dtcsv.Rows.Add(illus[i].getDataarray_test());
                //}


                if (dt.Rows.Count >= 17 && dt.Rows.Count <= 20 || dt.Rows.Count >= 37 && dt.Rows.Count <= 40 ||
                    dt.Rows.Count >= 57 && dt.Rows.Count <= 60 || dt.Rows.Count >= 77 && dt.Rows.Count <= 80 ||
                    dt.Rows.Count >= 97 && dt.Rows.Count <= 100)
                {
                    if (dt.Rows.Count == 17 || dt.Rows.Count == 37 || dt.Rows.Count == 57 || dt.Rows.Count == 77 || dt.Rows.Count == 97)
                    {
                        DataRow myRow;
                        myRow = dt.NewRow();
                        dt.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "");
                        dt.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "");
                        dt.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "");
                        dt.Rows.Add(myRow);
                        rds.Value = dt;
                    }
                    else if (dt.Rows.Count == 18 || dt.Rows.Count == 38 || dt.Rows.Count == 58 || dt.Rows.Count == 78 || dt.Rows.Count == 98)
                    {
                        DataRow myRow;
                        myRow = dt.NewRow();
                        dt.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "");
                        dt.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "");
                        dt.Rows.Add(myRow);
                        rds.Value = dt;
                    }
                    else if (dt.Rows.Count == 19 || dt.Rows.Count == 39 || dt.Rows.Count == 59 || dt.Rows.Count == 79 || dt.Rows.Count == 99)
                    {
                        DataRow myRow;
                        myRow = dt.NewRow();
                        dt.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "");
                        dt.Rows.Add(myRow);
                        rds.Value = dt;
                    }
                    else if (dt.Rows.Count == 20 || dt.Rows.Count == 40 || dt.Rows.Count == 60 || dt.Rows.Count == 80)
                    {
                        DataRow myRow;
                        myRow = dt.NewRow();
                        dt.Rows.Add(myRow);
                        rds.Value = dt;
                    }
                }
                rds.Value = dt;
                const int MaxLengthHeading = 30;
                const int MaxLengthName = 50;
                var custHeading = (customer.FirstName + " " + customer.LastName).Trim();
                var custName = (customer.FirstName + " " + customer.LastName).Trim();
                if (custHeading.Length > MaxLengthHeading)
                {
                    custHeading = custHeading.Substring(0, MaxLengthHeading);
                    custHeading = custHeading + "...";
                }
                if (custName.Length > MaxLengthName)
                {
                    custName = custName.Substring(0, MaxLengthName);
                    custName = custName + "...";
                }

                ReportParameter param1 = new ReportParameter("heading", custHeading);
                ReportParameter param2 = new ReportParameter("per1", insmaindata.comprate1);
                ReportParameter param3 = new ReportParameter("per2", insmaindata.comprate2);
                ReportParameter param4 = new ReportParameter("per3", insmaindata.comprate3);
                ReportParameter param6 = new ReportParameter("header3", "Asumiendo un Rendimiento de Inversión de");
                ReportParameter param7 = new ReportParameter("dynrate", insmaindata.dynratecaption);
                ReportParameter param124 = new ReportParameter("number", "");//txtnumber.Text);
                ReportParameter param1_13 = new ReportParameter("lastname", (customer.LastName + " ").Trim());

                WSRider rideradb = null;
                WSRider riderterm = null;

                if (riderslist != null)
                {
                    foreach (WSRider rider in riderslist)
                    {
                        if (rider.ridertypecode.Equals(WSRider.RIDERADB))
                        {
                            rideradb = rider;
                        }
                        else if (rider.ridertypecode.Equals(WSRider.RIDERTERM))
                        {
                            riderterm = rider;
                        }
                    }


                }

                //var invp = (from inv in newdb.investmentprofiledets
                //            from cust in newdb.customerPlandets
                //            where (cust.investmentprofilecode == inv.investmentprofilecode) && (cust.customerPlanno == Sessionclass.getSessiondata(Session).customerplanno)
                //            select inv).SingleOrDefault();

                string ddlfingoal = "-";
                string ddlinitialcontribution = "-";
                string initialcontributionamount = "-";
                string ddlinvestprofile = "-";
                string txtsumannualpremium = "-";
                string initialcomission = "-";
                string crticleillnessamount = "-";
                string freqofpayment = "-";
                string plantype = "-";
                string almillar = "-";
                string risk = "-";
                string investmentprofile = "-";
                string maritalstatus = "-";
                string fingoalamount = "-";

                if (customerplan != null)
                {
                    investmentprofile = Lookuplangdata.getLanguagevalue(Lookuptables.investmentprofiledet, Invprofiledata.getInvestmentprofile(customerplan.investmentprofilecode.ToCharArray()[0]), "es");

                }
                if (customerplan != null)
                {
                    if (customerplan.frequencytypecode != null)
                    {
                        // freqofpayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode), Sessionclass.getSessiondata(Session).language);
                        freqofpayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode.ToCharArray()[0]), "es");


                    }
                    if (customerplan.financialgoal != null)
                    {
                        if (customerplan.financialgoal == "Y")
                        {
                            ddlfingoal = "Yes";
                        }
                        if (customerplan.financialgoal == "N")
                        {
                            ddlfingoal = "No";
                        }
                    }

                    if (customerplan.initialcontributionamount != null)
                    {
                        if (Numericdata.getDoublevalue(customerplan.initialcontributionamount.ToString()) > 0)
                        {
                            ddlinitialcontribution = "Yes";
                            initialcontributionamount = customerplan.initialcontributionamount.ToString();
                        }
                        else
                        {
                            ddlinitialcontribution = "No";

                        }
                    }

                    if (customerplan.investmentprofilecode != null)
                    {
                        ddlinvestprofile = Invprofiledata.getInvestmentprofile(customerplan.investmentprofilecode.ToCharArray()[0]);
                    }

                    if (liferesult.annualpremiumamount != null)
                    {
                        txtsumannualpremium = liferesult.annualpremiumamount.ToString();
                    }

                    crticleillnessamount = "";




                    plantype = Lookuplangdata.getLanguagevalue(Lookuptables.plantypedet, Plantypes.getPlantype(customerplan.plantypecode.ToCharArray()[0]), "es");

                    risk = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())), "es");



                    almillar = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet, Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())), "es");
                    maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet, Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es");
                    if (customerplan.financialgoalamount != null)
                    {
                        fingoalamount = customerplan.financialgoalamount.ToString();
                    }


                }

                // initialcomission = customerplan.initialcommission.ToString();

                string rideroiramt = "-";
                string rideroirname = "-";
                string Riesgo = "-";
                string Fumador = "-";
                string Sexo = "-";
                string HastalaEdadde = "-";
                string Edad = "-";
                string AlMillar1 = "-";

                if (partins != null)
                {

                    rideroiramt = partins.amount.ToString();
                    rideroirname = partins.firstname + " " + partins.middlename + " " + partins.lastname + " " + partins.LastName2;

                    Riesgo = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, Activityrisktypes.getActivityrisktype(partins.activityrisktypeno), "es");



                    Fumador = Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, Booleandata.getBooleanstring(partins.smoker.ToCharArray()[0]), "es");
                    Sexo = partins.gendercode.ToString();//Genders.getgender(partins.gendercode.ToString().ToCharArray()[0]);

                    if (partins.contributiontype.Equals(Contributiontypes.CONTINUOUS.ToString()))
                        HastalaEdadde = "99";
                    else if (partins.contributiontype.Equals(Contributiontypes.NUMBEROFYEARS.ToString()))
                        HastalaEdadde = (Convert.ToInt32(partins.age) + partins.term - 1).ToString();
                    else if (partins.contributiontype.Equals(Contributiontypes.UNTILAGE.ToString()))
                        HastalaEdadde = partins.term.ToString();

                    Edad = partins.age.ToString();



                    AlMillar1 = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet, Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(partins.healthrisktypeno.ToString())), "es");



                }
                string primaryreq = "-", otherreq = "-";

                List<WSExam> exams = liferesult.primaryexamsrequiredlist;
                String[] req = new String[exams.Count()];

                int i = 0;
                foreach (WSExam exam in exams)
                {
                    primaryreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es").ToUpper() + "/" + primaryreq;
                    req[i] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es");
                    i++;
                }

                string tempPrimary = " ";
                int lno1 = 0;

                for (int j = 0; j < req.Length; j++)
                {
                    if (!string.IsNullOrEmpty(req[j]))
                        if (!req[j].Trim().Equals(""))
                        {
                            //tempPrimary += req[j] + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t";                            

                            //if(tempPrimary.Length % 80
                            tempPrimary += req[j];
                            if (j != (req.Length - 1))
                            {
                                tempPrimary += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t";
                            }
                            if (tempPrimary.Length > (lno1 + 1) * 150)
                            {
                                tempPrimary += Environment.NewLine;
                                lno1 = lno1 + 1;
                            }

                        }
                }
                //other

                exams = liferesult.partnerexamsrequiredlist;
                String[] oreq = new String[exams.Count()];

                int k = 0;
                foreach (WSExam exam in exams)
                {

                    otherreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es").ToUpper() + "/" + otherreq;

                    oreq[k] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es");
                    k++;
                }

                List<ReportParameter> paramlist = new List<ReportParameter>();
                ReportParameter param8 = new ReportParameter("name", custName);
                ReportParameter param9 = new ReportParameter("age", customer.Age.ToString());
                ReportParameter param10 = new ReportParameter("gender", customer.gendercode + "");//Genders.getgender(customer.gendercode));
                ReportParameter param14 = new ReportParameter("smoker", Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, Booleandata.getBooleanstring(customer.Smoker.ToCharArray()[0]), "es"));

                ReportParameter param13 = new ReportParameter("maritalstatus", maritalstatus + "");//Maritalstatus.getmaritalstatus(customer.MaritalStatuscode.Value));
                ReportParameter param27 = new ReportParameter("country", Lookuplangdata.getLanguagevalue(Lookuptables.countrydet, Countries.getcountry(Numericdata.getIntegervalue(customerplan.countryno + "")), "es"));
                ReportParameter param43 = new ReportParameter("InitialContributionAmount", GetFormatedText(initialcontributionamount) + "");
                ReportParameter param47 = new ReportParameter("financialgoals", ddlfingoal);
                ReportParameter param48 = new ReportParameter("ValueAccount", GetFormatedText(fingoalamount));
                ReportParameter param49 = new ReportParameter("AlaAge", GetFormatedText(customerplan.financialgoalage.ToString()));

                ReportParameter param50 = new ReportParameter("PolicyholderExams", primaryreq);
                ReportParameter param51 = new ReportParameter("TestsSecondInsured", otherreq);

                ReportParameter param100 = new ReportParameter("PolicyholderExams1", "" + tempPrimary);
                //ReportParameter param120_1 = new ReportParameter("date", getspanishmonth(DateTime.Now.ToString("MMMM")) + " " + DateTime.Now.ToString("dd, yyyy"));
                ReportParameter param120_1 = new ReportParameter("date", getspanishmonth(Int32.Parse(DateTime.Now.ToString("MM"))) + " " + DateTime.Now.ToString("dd, yyyy"));
                paramlist.Add(param120_1);

                ReportParameter prmstatus1 = new ReportParameter("Color", "unchecked");
                paramlist.Add(prmstatus1);
                prmstatus1 = new ReportParameter("BN", "unchecked");
                paramlist.Add(prmstatus1);
                prmstatus1 = new ReportParameter("CompulsoryFigure", "checked");
                paramlist.Add(prmstatus1);
                string[] controllist = { "S100", "S101", "S102", "S103", "S104", "S105", "S200", "S201", "S202", "S203",
                                          "S204", "S205", "S206", "S207", "S300", "S301", "S302", "S303", "S304", "S305", "S306", "S307", "S308", "S400", "S401", "S402", "S403", "S404", "S405"
                                      , "S406", "S500", "S501", "S502", "S503", "S504", "S505"};
                for (int count1 = 0; count1 < controllist.Count(); count1++)
                {
                    ReportParameter prmstatus = new ReportParameter(controllist[count1], "unchecked");
                    paramlist.Add(prmstatus);
                }

                //foreach (Control ccontrol in this.pnlCustomize.Controls)
                //{
                //    if (ccontrol is CheckBox)
                //    {
                //        CheckBox myCheckbox = (CheckBox)ccontrol;
                //        if (myCheckbox.Checked == true)
                //        {
                //            ReportParameter prmstatus = new ReportParameter(myCheckbox.ID.Substring(3, myCheckbox.ID.Length - 3), "checked");
                //            paramlist.Add(prmstatus);
                //        }
                //        else
                //        {
                //            ReportParameter prmstatus = new ReportParameter(myCheckbox.ID.Substring(3, myCheckbox.ID.Length - 3), "unchecked");
                //            paramlist.Add(prmstatus);
                //        }
                //    }
                //}

                string tempOther = " ";
                if (partins != null)
                {

                    for (int j = 0; j < oreq.Length; j++)
                    {
                        if (!string.IsNullOrEmpty(oreq[j]))
                            if (!oreq[j].Trim().Equals(""))
                                tempOther += oreq[j] + ", ";
                    }
                }
                if (tempOther.Trim().Length > 0)
                    tempOther = tempOther.Substring(0, tempOther.Length - 2);

                ReportParameter param112 = new ReportParameter("other1", "" + tempOther);


                paramlist.Add(param112);





                paramlist.Add(paramOther);

                paramlist.Add(param100);

                paramlist.Add(param1_13);





                paramlist.Add(param1);
                paramlist.Add(param2);
                paramlist.Add(param3);
                paramlist.Add(param4);
                //paramlist.Add(param5);
                paramlist.Add(param6);
                paramlist.Add(param7);


                paramlist.Add(param8);
                paramlist.Add(param9);
                paramlist.Add(param10);
                paramlist.Add(param13);
                paramlist.Add(param14);


                paramlist.Add(param27);
                paramlist.Add(param43);
                paramlist.Add(param47);
                paramlist.Add(param48);
                paramlist.Add(param49);
                paramlist.Add(param50);
                paramlist.Add(param51);
                paramlist.Add(param124);

                paramlist.Add(paramPlanOption1);
                paramlist.Add(paramPlanOption2);
                paramlist.Add(paramPlanOption3);
                paramlist.Add(paramPlanOption4);
                paramlist.Add(paramPlanOption5);
                paramlist.Add(paramPlanOption6);

                string contributionPeriod = "-";

                if (customerplan.contributiontypecode.Equals(Contributiontypes.CONTINUOUS.ToString()))
                {
                    contributionPeriod = (99 - Convert.ToInt32(customer.Age) + 1).ToString();
                }
                else if (customerplan.contributiontypecode.Equals(Contributiontypes.UNTILAGE.ToString()))
                {
                    contributionPeriod = (customerplan.contributionuntilage - Convert.ToInt32(customer.Age) + 1).ToString();
                }
                else if (customerplan.contributiontypecode.Equals(Contributiontypes.NUMBEROFYEARS.ToString()))
                {
                    contributionPeriod = customerplan.contributionperiod.ToString();
                }

                if (contributionPeriod.Equals("0"))
                    contributionPeriod = "-";
                string Prospect = (((customer.FirstName + " " + customer.MiddleName).Trim() + " " + customer.LastName).Trim() + " " + customer.LastName2).Trim();

                if (PlanName.Equals("Legacy"))
                {
                    ReportParameter param15 = new ReportParameter("heading", custHeading);
                    ReportParameter param11 = new ReportParameter("risk", risk + "");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param20 = new ReportParameter("almillar", almillar + "");//Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())));
                    ReportParameter param12 = new ReportParameter("plan", Productdata.getProduct(customerplan.productcode));
                    ReportParameter param19 = new ReportParameter("calcular", Calculatetypes.getcalculatetype(customerplan.calculatetypecode.ToCharArray()[0]));
                    ReportParameter param18 = new ReportParameter("periodofcontribution", contributionPeriod);
                    ReportParameter param16 = new ReportParameter("suminsured", GetFormatedText((customerplan.insuredamount + (riderterm != null ? riderterm.amount : 0)).ToString()));
                    ReportParameter paramsib = new ReportParameter("suminsuredbase", GetFormatedText(customerplan.insuredamount.ToString()));

                    ReportParameter param24 = new ReportParameter("initialcontribution", ddlinitialcontribution);
                    ReportParameter param25 = new ReportParameter("annualpremium", GetFormatedText(txtsumannualpremium));

                    ReportParameter param26 = new ReportParameter("investmentprofile", investmentprofile + "");//ddlinvestprofile);
                    ReportParameter param29 = new ReportParameter("accidentaldeath", GetFormatedText(rideradb != null ? rideradb.amount.ToString() : ""));
                    ReportParameter param29_1 = new ReportParameter("Accidental", Booleandata.getBooleanstring('N'));//customerplan.rideracdb));

                    ReportParameter param21 = new ReportParameter("additionaltemporary", GetFormatedText(riderterm != null ? riderterm.amount.ToString() : ""));
                    ReportParameter param22_1 = new ReportParameter("riderterm", Booleandata.getBooleanstring(riderterm != null ? 'Y' : 'N'));
                    ReportParameter param22_3 = new ReportParameter("TemporalAdicionaluntilage", Contributiontypes.getcontributiontype(riderterm != null ? riderterm.type.ToCharArray()[0] : ' '));


                    ReportParameter param23 = new ReportParameter("primatarget", GetFormatedText(liferesult.targetpremiumamount.ToString()));
                    ReportParameter param28 = new ReportParameter("minprima", GetFormatedText(liferesult.minimumpremiumamount.ToString()));

                    ReportParameter param30 = new ReportParameter("lastline", Generalmethods.getLastline(Prospect, new Random().Next(1, 20), customerplan.classcode.ToString().ToCharArray()[0]));
                    ReportParameter param31 = new ReportParameter("planincrement", " ");
                    ReportParameter param32 = new ReportParameter("PerodoContribucinSemester", " ");

                    ReportParameter param33 = new ReportParameter("rideroiramount", GetFormatedText(rideroiramt));
                    ReportParameter param64 = new ReportParameter("rideroirname", rideroirname);
                    ReportParameter param65 = new ReportParameter("Riesgo", Riesgo);
                    ReportParameter param66 = new ReportParameter("Edad", Edad);
                    ReportParameter param67 = new ReportParameter("Fumador", Fumador);
                    ReportParameter param68 = new ReportParameter("Sexo", Sexo);
                    ReportParameter param69 = new ReportParameter("HastalaEdadde", HastalaEdadde);
                    ReportParameter param53 = new ReportParameter("AlMillar1", AlMillar1 + "");
                    ReportParameter param70 = new ReportParameter("BottomText", "Esta presentación tiene una validez de 15 días hábiles y en ningún caso más allá del " + " 31-Diciembre-" + DateTime.Now.Year.ToString());
                    ReportParameter param75 = new ReportParameter("criticleillness", GetFormatedText(crticleillnessamount));
                    ReportParameter param76 = new ReportParameter("PaymentFrequency", freqofpayment);
                    ReportParameter param77 = new ReportParameter("PlanType", plantype + "");//Plantypes.getPlantype(customerplan.plantypecode));
                    ReportParameter param78 = new ReportParameter("premiumamount", GetFormatedText(customerplan.premiumamount.ToString()));
                    ReportParameter param79 = new ReportParameter("Actualparticipation", "-");
                    ReportParameter param80 = new ReportParameter("Biannualrateguarante", "Tasa Bi-Anual Garantizada");
                    ReportParameter param81 = new ReportParameter("Class", customerplan.classcode.ToString());
                    ReportParameter param82 = new ReportParameter("Foryears", "Por Años");
                    ReportParameter param83 = new ReportParameter("BottomText", "Esta presentación tiene una validez de 15 días hábiles y en ningún caso más allá del " + " 31-Diciembre-" + DateTime.Now.Year.ToString());
                    ReportParameter param57 = new ReportParameter("Monto", "-");

                    paramlist.Add(param57);
                    paramlist.Add(paramsib);
                    paramlist.Add(param33);
                    paramlist.Add(param53);
                    paramlist.Add(param64);
                    paramlist.Add(param65);
                    paramlist.Add(param66);
                    paramlist.Add(param67);
                    paramlist.Add(param68);
                    paramlist.Add(param69);
                    paramlist.Add(param70);
                    paramlist.Add(param75);
                    paramlist.Add(param76);
                    paramlist.Add(param77);
                    paramlist.Add(param78);
                    paramlist.Add(param79);
                    paramlist.Add(param80);
                    paramlist.Add(param81);
                    paramlist.Add(param82);
                    paramlist.Add(param83);




                    paramlist.Add(param7);
                    paramlist.Add(param12);
                    paramlist.Add(param15);
                    paramlist.Add(param16);
                    paramlist.Add(param18);
                    paramlist.Add(param19);
                    paramlist.Add(param20);
                    paramlist.Add(param21);

                    paramlist.Add(param23);
                    paramlist.Add(param24);
                    paramlist.Add(param25);
                    paramlist.Add(param26);
                    paramlist.Add(param28);
                    paramlist.Add(param29);
                    paramlist.Add(param11);
                    paramlist.Add(param30);
                    paramlist.Add(param31);
                    paramlist.Add(param32);
                    paramlist.Add(param22_1);
                    paramlist.Add(param22_3);
                    paramlist.Add(param29_1);

                    ReportParameter paramActRisk = new ReportParameter("activityrisk", Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter paramHealthRisk = new ReportParameter("healthrisk", Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())));

                    paramlist.Add(paramActRisk);
                    paramlist.Add(paramHealthRisk);

                    ReportParameter prmplanname = new ReportParameter("planname", Productdata.getProduct(customerplan.productcode));
                    ReportParameter prmplantype = new ReportParameter("plantype", plantype + "");//Plantypes.getPlantype(customerplan.plantypecode));

                    paramlist.Add(prmplanname);
                    paramlist.Add(prmplantype);

                    if (partins != null)
                    {
                        ReportParameter param22 = new ReportParameter("spouceinsurance", GetFormatedText(partins != null ? partins.amount.ToString() : ""));
                        paramlist.Add(param22);
                    }
                    else
                    {
                        ReportParameter param22 = new ReportParameter("spouceinsurance", "-");
                        paramlist.Add(param22);
                    }




                    List<rpt_lifeexpectancy> rpt_Life_Expectancy = (from item in newdb.rpt_lifeexpectancies
                                                                    select item).ToList();


                    decimal MaxAge = 0;
                    if (customer.gendercode.ToString() == "M")
                    {
                        MaxAge = Convert.ToDecimal((from item in rpt_Life_Expectancy where item.Current_Age == 0 select item.Men).First());
                    }
                    else if (customer.gendercode.ToString() == "F")
                    {
                        MaxAge = Convert.ToDecimal((from item in rpt_Life_Expectancy where item.Current_Age == 0 select item.Woman).First());
                    }

                    //decimal LifeExpectancy = MaxAge - Convert.ToDecimal(customer.Age);

                    ReportParameter param110 = new ReportParameter("LifeExpectancy", (MaxAge - Convert.ToDecimal(customer.Age)).ToString());
                    paramlist.Add(param110);
                    ReportDataSource lifeexpetancy = new ReportDataSource("Charts_rpt_lifeexpectancy", rpt_Life_Expectancy);
                    rpt.LocalReport.DataSources.Add(lifeexpetancy);

                }
                else if (PlanName.Equals("Compass Index") || PlanName.Equals("Compass"))
                {


                    List<rpt_lifeexpectancy> rpt_Life_Expectancy = (from item in newdb.rpt_lifeexpectancies
                                                                    select item).ToList();


                    decimal MaxAge = 0;
                    if (customer.gendercode.ToString() == "M")
                    {
                        MaxAge = Convert.ToDecimal((from item in rpt_Life_Expectancy where item.Current_Age == 0 select item.Men).First());
                    }
                    else if (customer.gendercode.ToString() == "F")
                    {
                        MaxAge = Convert.ToDecimal((from item in rpt_Life_Expectancy where item.Current_Age == 0 select item.Woman).First());
                    }

                    //decimal LifeExpectancy = MaxAge - Convert.ToDecimal(customer.Age);

                    ReportParameter param110 = new ReportParameter("LifeExpectancy", (MaxAge - Convert.ToDecimal(customer.Age)).ToString());
                    paramlist.Add(param110);
                    ReportDataSource lifeexpetancy = new ReportDataSource("Charts_rpt_lifeexpectancy", rpt_Life_Expectancy);
                    rpt.LocalReport.DataSources.Add(lifeexpetancy);

                    ReportParameter param15 = new ReportParameter("heading", custHeading);
                    ReportParameter param11 = new ReportParameter("risk", risk + "");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                    ReportParameter param20 = new ReportParameter("almillar", almillar + "");//Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())));
                    ReportParameter param12 = new ReportParameter("plan", Productdata.getProduct(customerplan.productcode));
                    ReportParameter param19 = new ReportParameter("calcular", Calculatetypes.getcalculatetype(customerplan.calculatetypecode.ToCharArray()[0]));
                    ReportParameter param18 = new ReportParameter("periodofcontribution", contributionPeriod);
                    ReportParameter param16 = new ReportParameter("suminsured", GetFormatedText((customerplan.insuredamount + (riderterm != null ? riderterm.amount : 0)).ToString()));
                    ReportParameter paramsib = new ReportParameter("suminsuredbase", GetFormatedText(customerplan.insuredamount.ToString()));


                    ReportParameter param24 = new ReportParameter("initialcontribution", ddlinitialcontribution);
                    ReportParameter param25 = new ReportParameter("annualpremium", GetFormatedText(txtsumannualpremium));

                    ReportParameter param26 = new ReportParameter("investmentprofile", "Indexado");//ddlinvestprofile);
                    ReportParameter param29 = new ReportParameter("accidentaldeath", GetFormatedText(rideradb != null ? rideradb.amount.ToString() : ""));
                    ReportParameter param29_1 = new ReportParameter("Accidental", Booleandata.getBooleanstring('N'));//customerplan.rideracdb));

                    ReportParameter param21 = new ReportParameter("additionaltemporary", GetFormatedText(riderterm != null ? riderterm.amount.ToString() : ""));
                    ReportParameter param22_1 = new ReportParameter("riderterm", Booleandata.getBooleanstring(riderterm != null ? 'Y' : 'N'));
                    ReportParameter param22_3 = new ReportParameter("TemporalAdicionaluntilage", Contributiontypes.getcontributiontype(riderterm != null ? riderterm.type.ToCharArray()[0] : ' '));


                    ReportParameter param23 = new ReportParameter("primatarget", GetFormatedText(liferesult.targetpremiumamount.ToString()));
                    ReportParameter param28 = new ReportParameter("minprima", GetFormatedText(liferesult.minimumpremiumamount.ToString()));

                    //ReportParameter param30 = new ReportParameter("lastline", Generalmethods.getLastline(Sessionclass.getSessiondata(Session).Prospect, new Random().Next(1, 20), customerplan.@class.ToString().ToCharArray()[0]));
                    ReportParameter param31 = new ReportParameter("planincrement", " ");
                    ReportParameter param32 = new ReportParameter("PerodoContribucinSemester", " ");

                    ReportParameter param33 = new ReportParameter("rideroiramount", GetFormatedText(rideroiramt));
                    ReportParameter param64 = new ReportParameter("rideroirname", rideroirname);
                    ReportParameter param65 = new ReportParameter("Riesgo", Riesgo);
                    ReportParameter param66 = new ReportParameter("Edad", Edad);
                    ReportParameter param67 = new ReportParameter("Fumador", Fumador);
                    ReportParameter param68 = new ReportParameter("Sexo", Sexo);
                    ReportParameter param69 = new ReportParameter("HastalaEdadde", HastalaEdadde);
                    ReportParameter param53 = new ReportParameter("AlMillar1", AlMillar1 + "");
                    ReportParameter param70 = new ReportParameter("BottomText", "Esta presentación tiene una validez de 15 días hábiles y en ningún caso más allá del " + " 31-Diciembre-" + DateTime.Now.Year.ToString());
                    ReportParameter param75 = new ReportParameter("criticleillness", GetFormatedText(crticleillnessamount));
                    ReportParameter param76 = new ReportParameter("PaymentFrequency", freqofpayment);
                    ReportParameter param77 = new ReportParameter("PlanType", plantype + "");//Plantypes.getPlantype(customerplan.plantypecode));
                    ReportParameter param78 = new ReportParameter("premiumamount", GetFormatedText(customerplan.premiumamount.ToString()));
                    ReportParameter param79 = new ReportParameter("Actualparticipation", "-");
                    ReportParameter param80 = new ReportParameter("Biannualrateguarante", "Tasa Bi-Anual Garantizada");
                    ReportParameter param81 = new ReportParameter("Class", customerplan.classcode.ToString());
                    ReportParameter param82 = new ReportParameter("Foryears", "Por Años");
                    ReportParameter param83 = new ReportParameter("BottomText", "Esta presentación tiene una validez de 15 días hábiles y en ningún caso más allá del " + " 31-Diciembre-" + DateTime.Now.Year.ToString());

                    //Accidental
                    //ReportParameter param57 = new ReportParameter("Monto", "");

                    //paramlist.Add(param57);

                    ReportParameter param30 = null;

                    if (PlanName.Equals("Compass Index"))
                    {
                        param30 = new ReportParameter("lastline", Generalmethods.getLastline(Prospect, new Random().Next(1, 20), customerplan.classcode.ToString().ToCharArray()[0]));
                    }

                    if (PlanName.Equals("Compass"))
                    {

                        //Sessionclass.getSessiondata(Session).Prospect = customer.FirstName + " " + customer.LastName;
                        param30 = new ReportParameter("lastline", Generalmethods.getcompassLastline(Prospect, new Random().Next(1, 20), customerplan.classcode.ToString().ToCharArray()[0]));
                    }

                    paramlist.Add(paramsib);
                    paramlist.Add(param33);
                    paramlist.Add(param53);
                    paramlist.Add(param64);
                    paramlist.Add(param65);
                    paramlist.Add(param66);
                    paramlist.Add(param67);
                    paramlist.Add(param68);
                    paramlist.Add(param69);
                    paramlist.Add(param70);
                    paramlist.Add(param75);
                    paramlist.Add(param76);
                    paramlist.Add(param77);
                    paramlist.Add(param78);
                    paramlist.Add(param79);
                    paramlist.Add(param80);
                    paramlist.Add(param81);
                    paramlist.Add(param82);
                    paramlist.Add(param83);




                    paramlist.Add(param7);
                    paramlist.Add(param12);
                    //paramlist.Add(param15);
                    paramlist.Add(param16);
                    paramlist.Add(param18);
                    paramlist.Add(param19);
                    paramlist.Add(param20);
                    paramlist.Add(param21);

                    paramlist.Add(param23);
                    paramlist.Add(param24);
                    paramlist.Add(param25);
                    paramlist.Add(param26);
                    paramlist.Add(param28);
                    paramlist.Add(param29);
                    paramlist.Add(param11);
                    paramlist.Add(param30);
                    paramlist.Add(param31);
                    paramlist.Add(param32);
                    paramlist.Add(param22_1);
                    paramlist.Add(param22_3);
                    paramlist.Add(param29_1);



                    if (partins != null)
                    {
                        ReportParameter param22 = new ReportParameter("spouceinsurance", GetFormatedText(partins != null ? partins.amount.ToString() : ""));
                        paramlist.Add(param22);
                    }
                    else
                    {
                        ReportParameter param22 = new ReportParameter("spouceinsurance", "-");
                        paramlist.Add(param22);
                    }



                }

                String[] clientsign = new string[3];
                String[] agentsign = new string[3];

                clientsign[0] = "N";
                clientsign[1] = "N";
                clientsign[2] = "N";

                agentsign[0] = "N";
                agentsign[1] = "N";
                agentsign[2] = "N";

                ReportParameter Cpath1 = new ReportParameter("clientsignpath1", "");// new ReportParameter("ClientPath1", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
                ReportParameter Apath1 = new ReportParameter("agentsignpath1", "");// new ReportParameter("AgentPath1", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
                ReportParameter Cpath2 = new ReportParameter("clientsignpath2", ""); ;// new ReportParameter("ClientPath2", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
                ReportParameter Apath2 = new ReportParameter("agentsignpath2", "");// new ReportParameter("AgentPath2", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
                ReportParameter Cpath3 = new ReportParameter("clientsignpath3", ""); ;// new ReportParameter("ClientPath3", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));
                ReportParameter Apath3 = new ReportParameter("agentsignpath3", "");// new ReportParameter("AgentPath3", Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Signatures/d341dlyp.k1o.jpg"));



                paramlist.Add(Cpath1);
                paramlist.Add(Apath1);
                paramlist.Add(Cpath2);
                paramlist.Add(Apath2);
                paramlist.Add(Cpath3);
                paramlist.Add(Apath3);

                List<rpt_investments_inflacion> rpt_investment = (from item in newdb.rpt_investments_inflacions
                                                                  select item).ToList();
                var count = rpt_investment.Count();
                var inflation_Last = (from ms in rpt_investment
                                      select new { ms.Pequenas_Acciones, ms.Grandes_Acciones, ms.Papelesdel_Tesoro, ms.Bonosdel_Gobierno, ms.Inflacion }).Last();
                var inflation_first = (from ms in rpt_investment
                                       select new { ms.Pequenas_Acciones, ms.Grandes_Acciones, ms.Papelesdel_Tesoro, ms.Bonosdel_Gobierno, ms.Inflacion }).First();
                var percent_Pequenas_last = inflation_Last.Pequenas_Acciones;
                var percent_Pequenas_First = inflation_first.Pequenas_Acciones;
                var Grandes_Acciones_last = inflation_Last.Grandes_Acciones;
                var Grandes_Acciones_First = inflation_first.Grandes_Acciones;
                var Papelesdel_Tesoro_last = inflation_Last.Papelesdel_Tesoro;
                var Papelesdel_Tesoro_First = inflation_first.Papelesdel_Tesoro;
                var Bonosdel_Gobierno_last = inflation_Last.Bonosdel_Gobierno;
                var Bonosdel_Gobierno_First = inflation_first.Bonosdel_Gobierno;
                var Inflacion1_last = inflation_Last.Inflacion;
                var Inflacion1_First = inflation_first.Inflacion;


                var result_total = percent_Pequenas_last / percent_Pequenas_First;
                var numberofyears = 0.0119;
                var Pequenas_percent = (Math.Pow(Convert.ToDouble(result_total), numberofyears) - 1) * 100;

                var result1_total = Grandes_Acciones_last / Grandes_Acciones_First;
                var numberofyears1 = 0.0119;
                var Grandes_percent = (Math.Pow(Convert.ToDouble(result1_total), numberofyears1) - 1) * 100;

                var result2_total = Papelesdel_Tesoro_last / Papelesdel_Tesoro_First;
                var numberofyears2 = 0.0119;
                var Papelesdel_percent = (Math.Pow(Convert.ToDouble(result2_total), numberofyears2) - 1) * 100;

                var result3_total = Bonosdel_Gobierno_last / Bonosdel_Gobierno_First;
                var numberofyears3 = 0.0119;
                var Bonosdel_percent = (Math.Pow(Convert.ToDouble(result3_total), numberofyears3) - 1) * 100;

                var result4_total = Inflacion1_last / Inflacion1_First;
                var numberofyears4 = 0.0119;
                var Inflacion_percent = (Math.Pow(Convert.ToDouble(result4_total), numberofyears4) - 1) * 100;


                ReportParameter Pequenas_Acciones = new ReportParameter("Pequenas_Acciones", Pequenas_percent.ToString());
                ReportParameter Grandes = new ReportParameter("Grandes", Grandes_percent.ToString());
                ReportParameter Papelesdel_Tesoro = new ReportParameter("Papelesdel_Tesoro", Papelesdel_percent.ToString());
                ReportParameter Bonosdel_Gobierno = new ReportParameter("Bonosdel_Gobierno", Bonosdel_percent.ToString());
                ReportParameter Inflacion = new ReportParameter("Inflacion", Inflacion_percent.ToString());
                paramlist.Add(Pequenas_Acciones);
                paramlist.Add(Grandes);
                paramlist.Add(Papelesdel_Tesoro);
                paramlist.Add(Bonosdel_Gobierno);
                paramlist.Add(Inflacion);

                //if ((hdnCheckedSettings.Value != "") || (hdnUnCheckedSettings.Value != ""))
                //{
                //    string[] checkedSettings = hdnCheckedSettings.Value.ToString().TrimStart(',').Split(',');
                //    string[] unCheckedSettings = hdnUnCheckedSettings.Value.ToString().TrimStart(',').Split(',');

                //    for (int counter1 = 0; counter1 < checkedSettings.Count(); counter1++)
                //    {
                //        ReportParameter visibilityParam = new ReportParameter(checkedSettings[counter1].ToString(), "checked");
                //        paramlist.Add(visibilityParam);
                //    }

                //    for (int counter2 = 0; counter2 < unCheckedSettings.Count(); counter2++)
                //    {
                //        if (unCheckedSettings[counter2].ToString() == null || unCheckedSettings[counter2].ToString()=="")
                //        {
                //        }
                //        else
                //        {
                //            ReportParameter visibilityParam = new ReportParameter(unCheckedSettings[counter2].ToString(), "unchecked");
                //            paramlist.Add(visibilityParam);
                //        }
                //    }


                //}

                ReportParameter param308 = new ReportParameter("S308", "unchecked");
                paramlist.Add(param308);
                List<rpt_Compass_Slide5> rpt_Compass_Slide5 = (from item in newdb.rpt_Compass_Slide5s
                                                               select item).ToList();
                List<rpt_Compass_slide7> Compass_slide7 = (from item in newdb.rpt_Compass_slide7s
                                                           select item).ToList();

                foreach (rpt_Compass_slide7 item in Compass_slide7)
                {
                    if (item.Continent == "Europa")
                    {
                        ReportParameter param60 = new ReportParameter("Europe_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                        ReportParameter param61 = new ReportParameter("Europe_Area", item.Area.ToString());//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                        paramlist.Add(param60);
                        paramlist.Add(param61);
                    }
                    else if (item.Continent == "Mediterráneo Oriental")
                    {
                        ReportParameter param62 = new ReportParameter("Eastern_Mediterranean_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                        ReportParameter param63 = new ReportParameter("Eastern_Mediterranean_Area", item.Area.ToString());//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                        paramlist.Add(param62);
                        paramlist.Add(param63);
                    }
                    else if (item.Continent == "Pacífico Occidental")
                    {
                        ReportParameter param72 = new ReportParameter("Pacífico_Occidental_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                        ReportParameter param73 = new ReportParameter("Pacífico_Occidental_Area", item.Area.ToString());//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                        paramlist.Add(param72);
                        paramlist.Add(param73);
                    }
                    else if (item.Continent == "Asia Sur Oriental")
                    {
                        ReportParameter param74 = new ReportParameter("Asia_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                        ReportParameter param105 = new ReportParameter("Asia_Area", item.Area.ToString());//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                        paramlist.Add(param74);
                        paramlist.Add(param105);
                    }
                    else if (item.Continent == "Centro y Suramérica")
                    {
                        ReportParameter param106 = new ReportParameter("america_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                        ReportParameter param107 = new ReportParameter("america_Area", item.Area.ToString());//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                        paramlist.Add(param106);
                        paramlist.Add(param107);
                    }
                    else if (item.Continent == "Africa")
                    {
                        ReportParameter param108 = new ReportParameter("Africa_Deaths", item.Deaths.ToString() + " muertes");//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                        ReportParameter param109 = new ReportParameter("Africa_Area", item.Area.ToString());//Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())));
                        paramlist.Add(param108);
                        paramlist.Add(param109);
                    }
                }
                ReportDataSource Compassslide7 = new ReportDataSource("Charts_rpt_Compass_slide7", Compass_slide7);

                ReportDataSource Compassslide5 = new ReportDataSource("Charts_rpt_Compass_Slide5", rpt_Compass_Slide5);

                rpt.LocalReport.DataSources.Add(Compassslide5);
                rpt.LocalReport.DataSources.Add(Compassslide7);
                string untilAge = "-";

                if (riderterm != null)
                {
                    if (riderterm.type.Equals(Contributiontypes.CONTINUOUS.ToString()))
                        untilAge = "99";
                    else if (riderterm.type.Equals(Contributiontypes.NUMBEROFYEARS.ToString()))
                        untilAge = (Convert.ToInt32(customer.Age) + riderterm.term - 1).ToString();
                    else if (riderterm.type.Equals(Contributiontypes.UNTILAGE.ToString()))
                        untilAge = riderterm.term.ToString();
                }

                ReportParameter paramAdditionalTermUntilAge = new ReportParameter("AdditionalTermUntilAge", untilAge);
                paramlist.Add(paramAdditionalTermUntilAge);

                maritalstatus = "-";

                if (partins != null)
                {
                    maritalstatus = Maritalstatus.getmaritalstatus(Convert.ToString(partins.maritalstatuscode));
                    lookupdatadet mstatus = (from item in newdb.lookupdatadets
                                             where item.tablename.Equals("maritalstatusdet") && item.lookupcaption.Equals(maritalstatus)
                                             select item).SingleOrDefault();
                    if (mstatus != null)
                        maritalstatus = mstatus.spanish;
                }


                ReportParameter paramSpouseMaritalStatus = new ReportParameter("SpouseMaritalStatus", maritalstatus);
                //*****************Adding Parameters of Sub Report*********************//
                //if (PlanName.Equals("Legacy"))
                //{

                rpt.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);


                List<rpt_InvestType> lst_rpt_invest_distribution_Moderado = (from item in newdb.rpt_InvestTypes
                                                                             where item.FundCategory == "Moderado" && item.Region == "Americano/Internacional"
                                                                             select item).ToList();
                var totMonderadoBond = from mb in lst_rpt_invest_distribution_Moderado
                                       where mb.FundType == "Bond" && mb.FundCategory == "Moderado"
                                       group mb by mb.FundCategory into g
                                       select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var totMonderadoStock = from ms in lst_rpt_invest_distribution_Moderado
                                        where ms.FundType == "Stock" && ms.FundCategory == "Moderado"
                                        group ms by ms.FundCategory into g
                                        select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

                ReportParameter prmMonderadoBondShare = new ReportParameter("MonderadoBondShare", totMonderadoBond.First().total.ToString());
                paramlist.Add(prmMonderadoBondShare);
                ReportParameter prmMonderadoStockShare = new ReportParameter("MonderadoStockShare", totMonderadoStock.First().total.ToString());
                paramlist.Add(prmMonderadoStockShare);
                List<rpt_InvestType> lst_rpt_invest_distribution_Balanceado = (from item in newdb.rpt_InvestTypes
                                                                               where item.FundCategory == "Balanceado" && item.Region == "Americano/Internacional"
                                                                               select item).ToList();
                var totBalanceadoBond = from mb in lst_rpt_invest_distribution_Balanceado
                                        where mb.FundType == "Bond" && mb.FundCategory == "Balanceado"
                                        group mb by mb.FundCategory into g
                                        select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var totBalanceadoStock = from ms in lst_rpt_invest_distribution_Balanceado
                                         where ms.FundType == "Stock" && ms.FundCategory == "Balanceado"
                                         group ms by ms.FundCategory into g
                                         select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

                ReportParameter prmBalanceadoBondShare = new ReportParameter("BalanceadoBondShare", totBalanceadoBond.First().total.ToString());
                paramlist.Add(prmBalanceadoBondShare);
                ReportParameter prmBalanceadoStockShare = new ReportParameter("BalanceadoStockShare", totBalanceadoStock.First().total.ToString());
                paramlist.Add(prmBalanceadoStockShare);
                List<rpt_InvestType> lst_rpt_invest_distribution_Crecimiento = (from item in newdb.rpt_InvestTypes
                                                                                where item.FundCategory == "Crecimiento" && item.Region == "Americano/Internacional"
                                                                                select item).ToList();
                var totCrecimientoBond = from mb in lst_rpt_invest_distribution_Crecimiento
                                         where mb.FundType == "Bond" && mb.FundCategory == "Crecimiento"
                                         group mb by mb.FundCategory into g
                                         select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var totCrecimientoStock = from ms in lst_rpt_invest_distribution_Crecimiento
                                          where ms.FundType == "Stock" && ms.FundCategory == "Crecimiento"
                                          group ms by ms.FundCategory into g
                                          select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

                string shareCrecimientoBond;
                if (totCrecimientoBond.FirstOrDefault() != null)
                {
                    shareCrecimientoBond = Convert.ToString(totCrecimientoBond.FirstOrDefault().total);
                }
                else
                {
                    shareCrecimientoBond = "0";
                }

                ReportParameter prmCrecimientoBondShare = new ReportParameter("CrecimientoBondShare", shareCrecimientoBond);
                paramlist.Add(prmCrecimientoBondShare);
                ReportParameter prmCrecimientoStockShare = new ReportParameter("CrecimientoStockShare", totCrecimientoStock.First().total.ToString());
                paramlist.Add(prmCrecimientoStockShare);
                List<rpt_InvestType> lst_rpt_invest_euro_distribution_Moderado = (from item in newdb.rpt_InvestTypes
                                                                                  where item.FundCategory == "Moderado" && item.Region == "Europeo"
                                                                                  select item).ToList();
                //e.DataSources.Add(new ReportDataSource("Charts_rpt_euro_InvestType_MODERADO", lst_rpt_invest_euro_distribution_Moderado));
                //ReportDataSource rds_invest_euro_distribution_Moderado = new ReportDataSource("Charts_rpt_euro_InvestType_MODERADO", lst_rpt_invest_euro_distribution_Moderado);
                //rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Moderado);



                var euro_totMonderadoBond = from mb in lst_rpt_invest_euro_distribution_Moderado
                                            where mb.FundType == "Bond" && mb.FundCategory == "Moderado"
                                            group mb by mb.FundCategory into g
                                            select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var euro_totMonderadoStock = from ms in lst_rpt_invest_euro_distribution_Moderado
                                             where ms.FundType == "Stock" && ms.FundCategory == "Moderado"
                                             group ms by ms.FundCategory into g
                                             select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

                ReportParameter euro_prmMonderadoBondShare = new ReportParameter("euro_MonderadoBondShare", euro_totMonderadoBond.First().total.ToString());
                paramlist.Add(euro_prmMonderadoBondShare);
                ReportParameter euro_prmMonderadoStockShare = new ReportParameter("euro_MonderadoStockShare", euro_totMonderadoStock.First().total.ToString());
                paramlist.Add(euro_prmMonderadoStockShare);
                List<rpt_InvestType> lst_rpt_invest_euro_distribution_Balanceado = (from item in newdb.rpt_InvestTypes
                                                                                    where item.FundCategory == "Balanceado" && item.Region == "Europeo"
                                                                                    select item).ToList();
                //e.DataSources.Add(new ReportDataSource("Charts_rpt_euro_InvestType_BALANCEADO", lst_rpt_invest_euro_distribution_Balanceado));
                //ReportDataSource rds_invest_euro_distribution_Balanceado = new ReportDataSource("Charts_rpt_euro_InvestType_BALANCEADO", lst_rpt_invest_euro_distribution_Balanceado);
                //rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Balanceado);


                var euro_totBalanceadoBond = from mb in lst_rpt_invest_euro_distribution_Balanceado
                                             where mb.FundType == "Bond" && mb.FundCategory == "Balanceado"
                                             group mb by mb.FundCategory into g
                                             select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var euro_totBalanceadoStock = from ms in lst_rpt_invest_euro_distribution_Balanceado
                                              where ms.FundType == "Stock" && ms.FundCategory == "Balanceado"
                                              group ms by ms.FundCategory into g
                                              select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };

                ReportParameter euro_prmBalanceadoBondShare = new ReportParameter("euro_BalanceadoBondShare", euro_totBalanceadoBond.First().total.ToString());
                paramlist.Add(euro_prmBalanceadoBondShare);
                ReportParameter euro_prmBalanceadoStockShare = new ReportParameter("euro_BalanceadoStockShare", euro_totBalanceadoStock.First().total.ToString());
                paramlist.Add(euro_prmBalanceadoStockShare);


                //************************Adding Subreport to Master Report*******************//
                List<rpt_InvestType> lst_rpt_invest_euro_distribution_Crecimiento = (from item in newdb.rpt_InvestTypes
                                                                                     where item.FundCategory == "Crecimiento" && item.Region == "Europeo"
                                                                                     select item).ToList();
                //e.DataSources.Add(new ReportDataSource("Charts_rpt_euro_InvestType_CRECIMIENTO", lst_rpt_invest_euro_distribution_Crecimiento));
                //ReportDataSource rds_invest_euro_distribution_Crecimiento = new ReportDataSource("Charts_rpt_euro_InvestType_CRECIMIENTO", lst_rpt_invest_euro_distribution_Crecimiento);
                //rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Crecimiento);

                var euro_totCrecimientoBond = from mb in lst_rpt_invest_distribution_Crecimiento
                                              where mb.FundType == "Bond" && mb.FundCategory == "Crecimiento"
                                              group mb by mb.FundCategory into g
                                              select new { category = g.Key, total = g.Sum(mb => mb.FundValue) };

                var euro_totCrecimientoStock = from ms in lst_rpt_invest_distribution_Crecimiento
                                               where ms.FundType == "Stock" && ms.FundCategory == "Crecimiento"
                                               group ms by ms.FundCategory into g
                                               select new { category = g.Key, total = g.Sum(ms => ms.FundValue) };
                List<rpt_compass_investment_master> st_rpt_compass_investment_master_moderado = (from item in newdb.rpt_compass_investment_masters
                                                                                                 where item.ReturnType == "Moderado" && item.Region == "Americano/Internacional"
                                                                                                 select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_moderado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_moderado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_moderado);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_moderado = (from item in newdb.rpt_compass_investment_details
                                                                                                       where item.ReturnTypeid == 1
                                                                                                       select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_moderado = new ReportDataSource("Charts_rpt_compass_investment_details_MODERADO", st_rpt_compass_investment_distribution_moderado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_moderado);
                List<rpt_compass_investment_master> st_rpt_compass_investment_master_balanceado = (from item in newdb.rpt_compass_investment_masters
                                                                                                   where item.ReturnType == "Balanceado" && item.Region == "Americano/Internacional"
                                                                                                   select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_balanceado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_balanceado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_balanceado);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_balanceado = (from item in newdb.rpt_compass_investment_details
                                                                                                         where item.ReturnTypeid == 3
                                                                                                         select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_balanceado = new ReportDataSource("Charts_rpt_compass_investment_details_BALANCEADO", st_rpt_compass_investment_distribution_balanceado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_balanceado);
                List<rpt_compass_investment_master> st_rpt_compass_investment_master_cricimiento = (from item in newdb.rpt_compass_investment_masters
                                                                                                    where item.ReturnType == "Cricimiento" && item.Region == "Americano/Internacional"
                                                                                                    select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_cricimiento);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_cricimiento);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_cricimiento = (from item in newdb.rpt_compass_investment_details
                                                                                                          where item.ReturnTypeid == 3
                                                                                                          select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_details_CRICIMIENTO", st_rpt_compass_investment_distribution_cricimiento);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_cricimiento);
                List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_moderado = (from item in newdb.rpt_compass_investment_masters
                                                                                                      where item.ReturnType == "Moderado" && item.Region == "Europeo"
                                                                                                      select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_euro_moderado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_moderado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_moderado);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_moderado = (from item in newdb.rpt_compass_investment_details
                                                                                                            where item.ReturnTypeid == 4
                                                                                                            select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_euro_moderado = new ReportDataSource("Charts_rpt_compass_investment_details_euro_MODERADO", st_rpt_compass_investment_distribution_euro_moderado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_moderado);
                List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_balanceado = (from item in newdb.rpt_compass_investment_masters
                                                                                                        where item.ReturnType == "Balanceado" && item.Region == "Europeo"
                                                                                                        select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_euro_balanceado = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_balanceado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_balanceado);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_balanceado = (from item in newdb.rpt_compass_investment_details
                                                                                                              where item.ReturnTypeid == 5
                                                                                                              select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_euro_balanceado = new ReportDataSource("Charts_rpt_compass_investment_details_euro_BALANCEADO", st_rpt_compass_investment_distribution_euro_balanceado);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_balanceado);
                List<rpt_compass_investment_master> st_rpt_compass_investment_master_euro_cricimiento = (from item in newdb.rpt_compass_investment_masters
                                                                                                         where item.ReturnType == "Cricimiento" && item.Region == "Europeo"
                                                                                                         select item).ToList();
                ReportDataSource rds_rpt_compss_investment_master_euro_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_master", st_rpt_compass_investment_master_euro_cricimiento);
                rpt.LocalReport.DataSources.Add(rds_rpt_compss_investment_master_euro_cricimiento);
                List<rpt_compass_investment_detail> st_rpt_compass_investment_distribution_euro_cricimiento = (from item in newdb.rpt_compass_investment_details
                                                                                                               where item.ReturnTypeid == 6
                                                                                                               select item).ToList();
                ReportDataSource rds_rpt_compass_investment_distribution_euro_cricimiento = new ReportDataSource("Charts_rpt_compass_investment_details_euro_CRICIMIENTO", st_rpt_compass_investment_distribution_euro_cricimiento);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_distribution_euro_cricimiento);

                List<rpt_compass_investment_detail> lst_rpt_compass_investment_yearreturn_americano =
                    (from item in newdb.rpt_compass_investment_details
                     join o in newdb.rpt_compass_investment_masters
                     on item.ReturnTypeid equals o.Sno
                     where (item.Years == 2010 && o.Region == "Americano/Internacional")
                     select item).ToList();

                ReportDataSource rds_rpt_compass_investment_yearreturn_americano = new ReportDataSource("Charts_rpt_compass_investment_details_yearreturn_Americano", lst_rpt_compass_investment_yearreturn_americano);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_yearreturn_americano);
                List<rpt_compass_investment_detail> lst_rpt_compass_investment_yearreturn_europeo =
                        (from item in newdb.rpt_compass_investment_details
                         join o in newdb.rpt_compass_investment_masters
                         on item.ReturnTypeid equals o.Sno
                         where (item.Years == 2010 && o.Region == "Europeo")
                         select item).ToList();

                ReportDataSource rds_rpt_compass_investment_yearreturn_europeo = new ReportDataSource("Charts_rpt_compass_investment_details_yearreturn_Europeo", lst_rpt_compass_investment_yearreturn_europeo);
                rpt.LocalReport.DataSources.Add(rds_rpt_compass_investment_yearreturn_europeo);

                List<profile_de_inversion> lst_rpt_profile_de_inversion = (from item in newdb.profile_de_inversions
                                                                           select item).ToList();

                List<profile_de_inversion_euro> lst_rpt_profile_de_inversion_euro = (from item in newdb.profile_de_inversion_euros
                                                                                     select item).ToList();
                //List<rpt_InvestType> lst_rpt_invest_distribution_Moderado = (from item in newdb.rpt_InvestTypes
                //                                                             where item.FundCategory == "Moderado" && item.Region == "Americano/Internacional"
                //                                                             select item).ToList();
                //List<rpt_InvestType> lst_rpt_invest_distribution_Balanceado = (from item in newdb.rpt_InvestTypes
                //                                                               where item.FundCategory == "Balanceado" && item.Region == "Americano/Internacional"
                //                                                               select item).ToList();
                //List<rpt_InvestType> lst_rpt_invest_distribution_Crecimiento = (from item in newdb.rpt_InvestTypes
                //                                                                where item.FundCategory == "Crecimiento" && item.Region == "Americano/Internacional"
                //                                                                select item).ToList();
                ReportDataSource rds_invest_distribution_Moderado = new ReportDataSource("Charts_rpt_InvestType_MODERADO", lst_rpt_invest_distribution_Moderado);
                rpt.LocalReport.DataSources.Add(rds_invest_distribution_Moderado);
                ReportDataSource rds_profile_de_inversion = new ReportDataSource("Charts_profile_de_inversion", lst_rpt_profile_de_inversion);
                rpt.LocalReport.DataSources.Add(rds_profile_de_inversion);

                ReportDataSource rds_profile_de_inversion_euro = new ReportDataSource("Charts_profile_de_inversion_euro", lst_rpt_profile_de_inversion_euro);
                rpt.LocalReport.DataSources.Add(rds_profile_de_inversion_euro);
                ReportDataSource rds_invest_distribution_Balanceado = new ReportDataSource("Charts_rpt_InvestType_BALANCEADO", lst_rpt_invest_distribution_Balanceado);
                rpt.LocalReport.DataSources.Add(rds_invest_distribution_Balanceado);
                ReportDataSource rds_invest_distribution_Crecimiento = new ReportDataSource("Charts_rpt_InvestType_CRECIMIENTO", lst_rpt_invest_distribution_Crecimiento);
                rpt.LocalReport.DataSources.Add(rds_invest_distribution_Crecimiento);
                //List<rpt_InvestType> lst_rpt_invest_euro_distribution_Moderado = (from item in newdb.rpt_InvestTypes
                //                                                                  where item.FundCategory == "Moderado" && item.Region == "Europeo"
                //                                                                  select item).ToList();
                ReportDataSource rds_invest_euro_distribution_Moderado = new ReportDataSource("Charts_rpt_euro_InvestType_MODERADO", lst_rpt_invest_euro_distribution_Moderado);
                rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Moderado);
                //List<rpt_InvestType> lst_rpt_invest_euro_distribution_Balanceado = (from item in newdb.rpt_InvestTypes
                //                                                                    where item.FundCategory == "Balanceado" && item.Region == "Europeo"
                //                                                                    select item).ToList();
                ReportDataSource rds_invest_euro_distribution_Balanceado = new ReportDataSource("Charts_rpt_euro_InvestType_BALANCEADO", lst_rpt_invest_euro_distribution_Balanceado);
                rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Balanceado);
                //List<rpt_InvestType> lst_rpt_invest_euro_distribution_Crecimiento = (from item in newdb.rpt_InvestTypes
                //                                                                     where item.FundCategory == "Crecimiento" && item.Region == "Europeo"
                //                                                                     select item).ToList();
                ReportDataSource rds_invest_euro_distribution_Crecimiento = new ReportDataSource("Charts_rpt_euro_InvestType_CRECIMIENTO", lst_rpt_invest_euro_distribution_Crecimiento);
                rpt.LocalReport.DataSources.Add(rds_invest_euro_distribution_Crecimiento);


                string euro_shareCrecimientoBond;
                if (totCrecimientoBond.FirstOrDefault() != null)
                {
                    euro_shareCrecimientoBond = Convert.ToString(euro_totCrecimientoBond.FirstOrDefault().total);
                }
                else
                {
                    euro_shareCrecimientoBond = "0";
                }

                ReportParameter euro_prmCrecimientoBondShare = new ReportParameter("euro_CrecimientoBondShare", euro_shareCrecimientoBond);
                paramlist.Add(euro_prmCrecimientoBondShare);
                ReportParameter euro_prmCrecimientoStockShare = new ReportParameter("euro_CrecimientoStockShare", euro_totCrecimientoStock.First().total.ToString());
                paramlist.Add(euro_prmCrecimientoStockShare);
                rpt.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                //}

                paramlist.Add(paramSpouseMaritalStatus);

                rpt.LocalReport.EnableExternalImages = true;
                rpt.LocalReport.SetParameters(paramlist);
                rpt.LocalReport.DataSources.Add(rds);
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                bytes = rpt.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                //if (classicmode == true)
                //{
                //    dvReport.Visible = true;
                //    dvpdf.Visible = false;
                //    this.rpt.LocalReport.Refresh();
                //}
                //else if (customize == false)
                //{
                //    dvpdf.Visible = true;
                //    dvReport.Visible = false;
                //    Warning[] warnings;
                //    string[] streamIds;
                //    string mimeType = string.Empty;
                //    string encoding = string.Empty;
                //    string extension = string.Empty;


                //    StringBuilder deviceInfo = new StringBuilder();

                //    deviceInfo.Append("<DeviceInfo>");
                //    deviceInfo.Append("<OutputFormat>PDF</OutputFormat>");
                //    deviceInfo.Append("<ColorDepth>1</ColorDepth>");
                //    //deviceInfo.Append("<DpiX>150</DpiX>");
                //    //deviceInfo.Append("<DpiY>150</DpiY>");
                //    //deviceInfo.Append("<OutputFormat>BMP</OutputFormat>");
                //    //deviceInfo.Append("<MarginTop>0in</MarginTop>");
                //    //deviceInfo.Append("<MarginLeft>0in</MarginLeft>");
                //    //deviceInfo.Append("<MarginRight>0in</MarginRight>");
                //    //deviceInfo.Append("<MarginBottom>0in</MarginBottom>");
                //    //deviceInfo.Append("<PageHeight>2in</PageHeight>");
                //    //deviceInfo.Append("<PageWidth>4in</PageWidth>");
                //    deviceInfo.Append("</DeviceInfo>");

                //    //this.rpt.LocalReport.Render(

                //    byte[] bytes = this.rpt.LocalReport.Render("PDF", deviceInfo.ToString(), out mimeType, out encoding, out extension, out streamIds, out warnings);


                //    //byte[] bytes = this.rpt.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                //    MyGlobals.reportbytes = bytes;
                //    String strfilename = System.IO.Path.GetRandomFileName();
                //    Sessionclass.setIllustrationfilename(Session, strfilename + ".pdf");
                //    using (FileStream fs = new FileStream(Server.MapPath("~/pdfoutput/") + strfilename + ".pdf", FileMode.Create))
                //    {
                //        fs.Write(bytes, 0, bytes.Length);
                //    }
                //    /*
                //    StringBuilder sb = new StringBuilder();
                //    sb.Append("<object data='" + "pdfoutput/" + strfilename + ".pdf" + "' type='application/pdf' width='916' height='470'>");
                //    sb.Append("</object>");
                //    this.dvpdf.InnerHtml = sb.ToString();
                //    */
                //    this.dvpdf.InnerHtml = getObjectString(strfilename);
                //}
                //else
                //{
                //    dvpdf.Visible = false;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //  newdb.Dispose();
            }
            return bytes;
        }

        private static decimal GetROP(decimal initial_contribution, int frequency_type, int contribution_period, decimal premium_amount)
        {
            decimal ropPercent = 0.00m;
            switch (contribution_period)
            {
                case int n when (n == 10):
                    ropPercent = 0.50m;
                    break;
                case int n when (n == 11):
                    ropPercent = 0.55m;
                    break;
                case int n when (n == 12):
                    ropPercent = 0.60m;
                    break;
                case int n when (n == 13):
                    ropPercent = 0.65m;
                    break;
                case int n when (n == 14):
                    ropPercent = 0.70m;
                    break;
                case int n when (n == 15):
                    ropPercent = 0.75m;
                    break;
                case int n when (n == 16):
                    ropPercent = 0.80m;
                    break;
                case int n when (n == 17):
                    ropPercent = 0.85m;
                    break;
                case int n when (n == 18):
                    ropPercent = 0.90m;
                    break;
                case int n when (n == 19):
                    ropPercent = 0.95m;
                    break;
                case int n when (n > 19 && n <= 30):
                    ropPercent = 1.00m;
                    break;
                case int n when (n < 10):
                default:
                    ropPercent = 0.00m;
                    break;
            }

            return (initial_contribution + (contribution_period * (premium_amount * frequency_type))) * ropPercent;
        }

        #region Illustration from Thunderhead
        public static byte[] showIllustrationTERMfixed(WSTermResult termresult, WSCustomer customer, WSCustomerPlan customerplan, IMaintermfixed termfixed, List<WSRider> riderslist, WSCustomerPlanPartner partins, bool PDF = true)
        {
            var ropSettings = productsProperties.Elements.ToList();
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            Services svc = new Services();
            var quote = new STG.DLL.TH.Serialization.Entity.Quote();
            var Coverages = new List<Coverage>();
            #region Values from illustration
            WSRider riderterm = null, rideradb = null;
            string maritalstatus = string.Empty,
                   maritalstatusAI = string.Empty,
                   untilAge = string.Empty;

            if (riderslist != null && riderslist.Any())
            {
                foreach (WSRider rider in riderslist)
                {
                    if (rider.type != null)
                    {
                        if (rider.type.Equals(Contributiontypes.CONTINUOUS.ToString()))
                            untilAge = "99";
                        else if (rider.type.Equals(Contributiontypes.NUMBEROFYEARS.ToString()))
                            untilAge = (Convert.ToInt32(customer.Age) + riderterm.term - 1).ToString();
                        else if (rider.type.Equals(Contributiontypes.UNTILAGE.ToString()))
                            untilAge = riderterm.term.ToString();
                    }
                    Coverages.Add(new Coverage
                    {
                        AmountInsured = Numericdata.getDecimalvalue(rider.amount.ToString()),
                        Description = Enums.GetDescription((Services.Rider)Enum.Parse(typeof(Services.Rider), rider.ridertypecode)),
                        CoverageAge = untilAge
                    });

                    if (rider.ridertypecode.Equals(WSRider.RIDERADB))
                    {
                        rideradb = rider;
                    }
                    else if (rider.ridertypecode.Equals(WSRider.RIDERTERM))
                    {
                        riderterm = rider;
                    }
                }
            }
            if (partins != null)
            {
                if (partins.contributiontype.Equals(Contributiontypes.CONTINUOUS.ToString()))
                    untilAge = "99";
                else if (partins.contributiontype.Equals(Contributiontypes.NUMBEROFYEARS.ToString()))
                    untilAge = (Convert.ToInt32(partins.age) + partins.term - 1).ToString();
                else if (partins.contributiontype.Equals(Contributiontypes.UNTILAGE.ToString()))
                    untilAge = partins.term.ToString();
                Coverages.Add(new Coverage
                {
                    AmountInsured = Numericdata.getDecimalvalue(partins.amount.ToString()),
                    Description = partins.contributiontype.Equals(Contributiontypes.CONTINUOUS.ToString()) ? Enums.GetDescription(Services.Rider.AI) : Enums.GetDescription(Services.Rider.AIT),
                    CoverageAge = untilAge
                });
            }
            quote.Coverages = Coverages;
            string estadocivil = string.Empty;
            estadocivil = Maritalstatus.getmaritalstatus(customer.MaritalStatuscode);
            if (estadocivil == "Free union")
            {
                maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet, Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es");
            }
            else
            {
                maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet, Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es") + "(a)";
            }
            if (partins != null)
            {
                maritalstatusAI = Maritalstatus.getmaritalstatus(partins.maritalstatuscode);

                lookupdatadet mstatus = (from item in newdb.lookupdatadets
                                         where item.tablename.Equals("maritalstatusdet") && item.lookupcaption.Equals(maritalstatusAI)
                                         select item).SingleOrDefault();
                if (mstatus != null)
                    maritalstatusAI = mstatus.spanish;
            }
            ReportDataSource rds = new ReportDataSource();
            dt = new DataTable();
            dttwo = new DataTable();
            Termillusdata[] illus = termfixed.getIllustration();
            for (int i = 0; i < illus[0].getDatacolumns().Length; i++)
            {
                dt.Columns.Add(new DataColumn(illus[0].getDatacolumns()[i]));
            }
            for (int i = 0; i < illus.Length; i++)
            {
                dt.Rows.Add(illus[i].getDataarray());
            }
            Termillusdata[] illustwo = termfixed.getIllustrationtwo();
            for (int i = 0; i < illustwo[0].getDatacolumns().Length; i++)
            {
                dttwo.Columns.Add(new DataColumn(illustwo[0].getDatacolumns()[i]));
            }
            for (int i = 0; i < illustwo.Length; i++)
            {
                dttwo.Rows.Add(illustwo[i].getDataarray());
            }
            var policyType = Services.InsuranceType.IndividualTermLife;
            var planMode = Services.InsurancePlanMode.Individual;
            char plangroupcode = Productdata.getPlangroupcode(customerplan.productcode);
            switch (plangroupcode)
            {
                case 'F':
                    policyType = Services.InsuranceType.IndividualFunerary;
                    break;
                case 'T':
                default:
                    policyType = Services.InsuranceType.IndividualTermLife;
                    planMode = Services.InsurancePlanMode.Individual;
                    break;
            }

            string examsRequiredIns = string.Empty;
            List<WSExam> exams = termresult.primaryexamsrequiredlist;
            int examno = 0;
            if (exams != null)
            {
                String[] required = new String[exams.Count];
                foreach (WSExam exam in exams)
                {
                    //primaryreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es").ToUpper() + "/" + primaryreq;
                    required[examno] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es");
                    examno++;
                }
                examsRequiredIns = string.Join(", ", required);
            }
            exams = termresult.partnerexamsrequiredlist;
            string examsRequiredAdd = string.Empty;
            int k = 0;
            if (exams != null)
            {
                String[] orequired = new String[exams.Count];
                foreach (WSExam exam in exams)
                {
                    orequired[k] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es");
                    k++;
                }
                examsRequiredAdd = string.Join(", ", orequired);
            }
            #endregion
            quote.PolicyInfo = new PolicyInfo
            {
                DocumentId = long.Parse(System.Configuration.ConfigurationManager.AppSettings["DEF::DocumentID:Quote:Life"]),
                PolicyNumber = customerplan.IllustrationNo,
                PolicyType = Enums.GetDescription(policyType),
                Plan = Productdata.getProduct(customerplan.productcode),
                InsuranceDuration = customerplan.insuranceperiod.ToString(),
                PrincipalInsuredReq = string.IsNullOrEmpty(examsRequiredIns) ? "-" : examsRequiredIns + ".",
                AdditionalInsuredReq = string.IsNullOrEmpty(examsRequiredAdd) ? "-" : examsRequiredAdd + ".",
                PlanMode = Enums.GetDescription(planMode)
            };
            var Member = new List<Member>();
            Member.Add(new Member
            {
                Age = customer.Age.ToString(),
                FirstName = customer.FirstName,
                MiddleName = customer.MiddleName,
                LastName = customer.LastName,
                SecondLastName = customer.LastName2,
                Sex = Enums.GetDescription((Services.Genders)Enum.Parse(typeof(Services.Genders), customer.gendercode)),
                Smoker = customer.Smoker == "N" ? "0" : "1",
                dateOfBirth = new DateTime(),
                Risk = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())), "es"),
                Millar = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet, Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())), "es"),
                CivilStatus = maritalstatus,
                Country = Lookuplangdata.getLanguagevalue(Lookuptables.countrydet, Countries.getcountry(Numericdata.getIntegervalue(customerplan.countryno + "")), Langdata.LANGUAGE_SPANISH),
                Role = Enums.GetDescription(Services.Role.Owner)
            });
            if (partins != null)
                Member.Add(new Member
                {
                    Age = partins.age.ToString(),
                    FirstName = partins.firstname,
                    MiddleName = partins.middlename,
                    LastName = partins.lastname,
                    SecondLastName = partins.LastName2,
                    Sex = Enums.GetDescription((Services.Genders)Enum.Parse(typeof(Services.Genders), partins.gendercode)),
                    Smoker = partins.smoker == "N" ? "0" : "1",
                    dateOfBirth = new DateTime(),
                    Risk = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(partins.activityrisktypeno.ToString())), "es"),
                    Millar = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet, Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(partins.healthrisktypeno.ToString())), "es"),
                    CivilStatus = maritalstatusAI,
                    Country = Lookuplangdata.getLanguagevalue(Lookuptables.countrydet, Countries.getcountry(Numericdata.getIntegervalue(customerplan.countryno + "")), Langdata.LANGUAGE_SPANISH),
                    Role = Enums.GetDescription(Services.Role.AdditionalInsured)
                });
            quote.Member = Member;
            var isRefund = Productdata.isRefund(customerplan.productcode);
            var policyData = new List<PolicyData>();
            var policyDataSecured = dt.ConvertToList<PolicyData>();
            foreach (var item in policyDataSecured)
            {
                item.TipoPrima = Enums.GetDescription(Services.PremiumType.SecuredPremium);
                if (!isRefund)
                {
                    item.AccumulatedPremiums = 0;
                    continue;
                }
                else
                {
                    if (ropSettings != null && ropSettings.Any())
                    {
                        var zeroROP = ropSettings.Where(v => v.Percent == 0).FirstOrDefault();
                        var currentReturn = ropSettings.Where(v => v.Start >= customerplan.insuranceperiod && v.End <= customerplan.insuranceperiod).FirstOrDefault();
                        if (zeroROP != null && Convert.ToInt32(item.YearsOfThePlan) <= zeroROP.End)
                        {
                            item.AccumulatedPremiums = 0;
                            continue;
                        }
                        if (currentReturn != null && currentReturn.Percent > 0)
                            item.AccumulatedPremiums = item.AccumulatedPremiums * currentReturn.Percent;


                    }
                }
            }
            policyDataSecured.RemoveAll(w => w.AccumulatedPremiums > decimal.Parse(w.DeathBenefit) || w.TotalPrime > decimal.Parse(w.DeathBenefit));
            policyData.AddRange(policyDataSecured);

            var policyDataUnsecured = dttwo.ConvertToList<PolicyData>();
            foreach (var item in policyDataUnsecured)
            {
                item.TipoPrima = Enums.GetDescription(Services.PremiumType.UnsecuredPremium);
                if (!isRefund)
                {
                    item.AccumulatedPremiums = 0;
                    continue;
                }
                else
                {
                    if (ropSettings != null && ropSettings.Any())
                    {
                        var zeroROP = ropSettings.Where(v => v.Percent == 0).FirstOrDefault();
                        var currentReturn = ropSettings.Where(v => v.Start >= customerplan.insuranceperiod && v.End <= customerplan.insuranceperiod).FirstOrDefault();
                        if (zeroROP != null && Convert.ToInt32(item.YearsOfThePlan) <= zeroROP.End)
                        {
                            item.AccumulatedPremiums = 0;
                            continue;
                        }
                        if (currentReturn != null && currentReturn.Percent > 0)
                            item.AccumulatedPremiums = item.AccumulatedPremiums * currentReturn.Percent;


                    }
                }
            }
            policyDataUnsecured.RemoveAll(w => w.AccumulatedPremiums > decimal.Parse(w.DeathBenefit) || w.TotalPrime > decimal.Parse(w.DeathBenefit));
            policyData.AddRange(policyDataUnsecured);

            quote.PolicyData = policyData;
            quote.Quotation = new Quotation
            {
                ProposalDate = DateTime.Now,
                QuotationNumber = customerplan.IllustrationNo,
                EndOfProposalDate = new DateTime(DateTime.Now.Year, 12, 31)
            };
            quote.PaymentDetail = new PaymentDetail
            {
                InitialContribution = Numericdata.getDecimalvalue(customerplan.initialcontributionamount.ToString()) > 0 ? "1" : "0",
                AdditionalAmount = Numericdata.getDecimalvalue(customerplan.initialcontributionamount.ToString()),
                FrequencyOfPayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode.ToCharArray()[0]), "es"),
                Currency = Enums.GetDescription((Services.Currency)Enum.Parse(typeof(Services.Currency), customerplan.classcode))
            };
            quote.PrimeResume = new PrimeResume
            {
                TotalInsuredAmount = Numericdata.getDecimalvalue((customerplan.insuredamount + (riderterm != null ? riderterm.amount : 0)).ToString()),
                BaseInsuredAmount = Numericdata.getDecimalvalue(customerplan.insuredamount.ToString()),
                ContributionPeriod = customerplan.contributionperiod.ToString(),
                AnnualPremium = Numericdata.getDecimalvalue(termresult.annualpremiumamount.ToString()),
                PeriodicalPrime = Numericdata.getDecimalvalue(customerplan.premiumamount.ToString()),
                TargetPrime = Numericdata.getDecimalvalue(termresult.targetpremiumamount.ToString()),
                PremiumReturnAmount = GetROP((Numericdata.getDecimalvalue(customerplan.initialcontributionamount.ToString())),
                                        Frequencytypes.getfrequencytypevaluefromcode(customerplan.frequencytypecode.ToCharArray()[0]),
                                        customerplan.contributionperiod,
                                        Numericdata.getDecimalvalue(customerplan.premiumamount.ToString())),
                Taxes = Numericdata.getDecimalvalue(termresult.Tax.ToString()),
                TotalPeriodicalPrime = Numericdata.getDecimalvalue(customerplan.premiumamount.ToString()) + Numericdata.getDecimalvalue(termresult.Tax.ToString()),
            };

            return svc.GenerateQuote(STG.DLL.TH.Serialization.Implementation.Quotes.Life, quote);
        }
        public static byte[] showIllustrationFUNERALfixed(WSFuneralResult funeralresult, WSCustomer customer, WSCustomerPlanFuneral customerplan, IMainfuneral funaralfixed, bool PDF = true)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            Services svc = new Services();
            var quote = new STG.DLL.TH.Serialization.Entity.Quote();
            var Coverages = new List<Coverage>();
            #region Values from illustration
            WSRider riderterm = null, rideradb = null;
            string maritalstatus = string.Empty,
                   maritalstatusAI = string.Empty,
                   untilAge = string.Empty;
            if (customerplan.Familiar == "Y")
                Coverages.Add(new Coverage
                {
                    AmountInsured = 0.00m,
                    Description = Enums.GetDescription(Services.Rider.FAMILIAR),
                    CoverageAge = string.Empty
                });
            if (customerplan.Repatriacion == "Y")
                Coverages.Add(new Coverage
                {
                    AmountInsured = 0.00m,
                    Description = Enums.GetDescription(Services.Rider.REPATRIACION),
                    CoverageAge = string.Empty
                });

            quote.Coverages = Coverages;
            string estadocivil = " ";
            estadocivil = Maritalstatus.getmaritalstatus(customer.MaritalStatuscode);
            if (estadocivil == "Free union")
            {
                maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet, Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es");
            }
            else
            {
                maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet, Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es") + "(a)";
            }

            ReportDataSource rds = new ReportDataSource();
            dt = new DataTable();
            dttwo = new DataTable();
            Termillusdata[] illus = funaralfixed.getIllustration();
            for (int i = 0; i < illus[0].getDatacolumns().Length; i++)
            {
                dt.Columns.Add(new DataColumn(illus[0].getDatacolumns()[i]));
            }
            for (int i = 0; i < illus.Length; i++)
            {
                dt.Rows.Add(illus[i].getDataarray());
            }
            Termillusdata[] illustwo = funaralfixed.getIllustrationtwo();
            for (int i = 0; i < illustwo[0].getDatacolumns().Length; i++)
            {
                dttwo.Columns.Add(new DataColumn(illustwo[0].getDatacolumns()[i]));
            }
            for (int i = 0; i < illustwo.Length; i++)
            {
                dttwo.Rows.Add(illustwo[i].getDataarray());
            }
            var policyType = Services.InsuranceType.IndividualTermLife;
            var planMode = Services.InsurancePlanMode.Individual;
            var basicpremium = 0d;
            char plangroupcode = Productdata.getPlangroupcode(customerplan.productcode);
            switch (plangroupcode)
            {
                case 'F':
                    policyType = Services.InsuranceType.IndividualFunerary;
                    planMode = (customerplan.Familiar == "Y") ? Services.InsurancePlanMode.Familiar : Services.InsurancePlanMode.Individual;
                    basicpremium = funaralfixed.goalseekfunerary(customerplan.insuredamount);
                    break;
                case 'T':
                default:
                    policyType = Services.InsuranceType.IndividualTermLife;
                    planMode = Services.InsurancePlanMode.Individual;
                    break;
            }

            List<WSExam> exams = funeralresult.primaryexamsrequiredlist;
            string examsRequired = "-";
            int examno = 0;
            if (exams != null)
            {
                String[] required = new String[exams.Count];
                foreach (WSExam exam in exams)
                {
                    required[examno] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, exam.examname, "es");
                    examno++;
                }
                examsRequired = (exams != null) ? string.Join(";", required) : string.Empty;
            }
            #endregion
            quote.PolicyInfo = new PolicyInfo
            {
                DocumentId = long.Parse(System.Configuration.ConfigurationManager.AppSettings["DEF::DocumentID:Quote:Life"]),
                PolicyNumber = customerplan.IllustrationNo,
                PolicyType = Enums.GetDescription(policyType),
                Plan = Productdata.getProduct(customerplan.productcode),
                InsuranceDuration = customerplan.insuranceperiod.ToString(),
                PrincipalInsuredReq = examsRequired,
                AdditionalInsuredReq = string.Empty,
                PlanMode = Enums.GetDescription(planMode)
            };
            var Member = new List<Member>();
            Member.Add(new Member
            {
                Age = customer.Age.ToString(),
                FirstName = customer.FirstName,
                MiddleName = customer.MiddleName,
                LastName = customer.LastName,
                SecondLastName = customer.LastName2,
                Sex = Enums.GetDescription((Services.Genders)Enum.Parse(typeof(Services.Genders), customer.gendercode)),
                Smoker = customer.Smoker == "N" ? "0" : "1",
                dateOfBirth = new DateTime(),
                Risk = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())), "es"),
                Millar = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet, Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())), "es"),
                CivilStatus = maritalstatus,
                Country = Lookuplangdata.getLanguagevalue(Lookuptables.countrydet, Countries.getcountry(Numericdata.getIntegervalue(customerplan.countryno + "")), Langdata.LANGUAGE_SPANISH),
                Role = Enums.GetDescription(Services.Role.Owner)
            });
            quote.Member = Member;

            var policyData = new List<PolicyData>();
            var policyDataSecured = dt.ConvertToList<PolicyData>();
            policyDataSecured.ForEach(t => t.TipoPrima = Enums.GetDescription(Services.PremiumType.SecuredPremium));
            policyData.AddRange(policyDataSecured);

            var policyDataUnsecured = dttwo.ConvertToList<PolicyData>();
            policyDataUnsecured.ForEach(t => t.TipoPrima = Enums.GetDescription(Services.PremiumType.UnsecuredPremium));
            policyData.AddRange(policyDataUnsecured);

            if (plangroupcode == 'F')
                policyData.ForEach(a => { a.AccumulatedPremiums = 0; a.DeathBenefit = customerplan.insuredamount.ToString(); a.BasicPrimeCoverage = Convert.ToDecimal(basicpremium); a.SupplementsPrime = Convert.ToDecimal(funeralresult.annualpremiumamount - basicpremium); });
            quote.PolicyData = policyData;
            quote.Quotation = new Quotation
            {
                ProposalDate = DateTime.Now,
                QuotationNumber = customerplan.IllustrationNo,
                EndOfProposalDate = new DateTime(DateTime.Now.Year, 12, 31)
            };
            quote.PaymentDetail = new PaymentDetail
            {
                InitialContribution = Numericdata.getDecimalvalue(customerplan.initialcontributionamount.ToString()) > 0 ? "1" : "0",
                AdditionalAmount = Numericdata.getDecimalvalue(customerplan.initialcontributionamount.ToString()),
                FrequencyOfPayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode.ToCharArray()[0]), "es"),
                Currency = Enums.GetDescription((Services.Currency)Enum.Parse(typeof(Services.Currency), customerplan.classcode))
            };
            quote.PrimeResume = new PrimeResume
            {
                TotalInsuredAmount = Numericdata.getDecimalvalue((customerplan.insuredamount + (riderterm != null ? riderterm.amount : 0)).ToString()),
                BaseInsuredAmount = Numericdata.getDecimalvalue(customerplan.insuredamount.ToString()),
                ContributionPeriod = customerplan.contributionperiod.ToString(),
                AnnualPremium = Numericdata.getDecimalvalue(funeralresult.annualpremiumamount.ToString()),
                PeriodicalPrime = Numericdata.getDecimalvalue(customerplan.premiumamount.ToString()),
                TargetPrime = Numericdata.getDecimalvalue(funeralresult.targetpremiumamount.ToString()),
                PremiumReturnAmount = GetROP((Numericdata.getDecimalvalue(customerplan.initialcontributionamount.ToString())),
                                        Frequencytypes.getfrequencytypevaluefromcode(customerplan.frequencytypecode.ToCharArray()[0]),
                                        customerplan.contributionperiod,
                                        Numericdata.getDecimalvalue(customerplan.premiumamount.ToString())),
                Taxes = Numericdata.getDecimalvalue(funeralresult.Tax.ToString()),
                TotalPeriodicalPrime = Numericdata.getDecimalvalue(funeralresult.TotalPeriodicPremium.ToString())
            };

            return svc.GenerateQuote(STG.DLL.TH.Serialization.Implementation.Quotes.Life, quote);
        }
        #endregion
    }
}