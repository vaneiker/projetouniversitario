using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing;
using iTextSharp.text;
using System.Threading;
using System.Activities.Statements;
using Statetrust.Framework.Web.WebParts.Pages;
using System.Web.Configuration;
using Keys = System.Configuration.ConfigurationManager;
using System.Globalization;
using System.Drawing.Printing;
using Statetrust.Framework.Security.Core;
using Statetrust.Framework.Security.Bll.Item;
using System.Diagnostics;
using System.ComponentModel;
using System.Web.Services;
//

public partial class MarbeteWeb : STFMainPage// System.Web.UI.Page
{
    #region Enums
    public enum Sections
    {
        First = 1,
        Second,
        Third,
        Fourth,
        Fifth,
        Sixth,
        Combined,
        All = 0
    }
    public enum Printer
    {
        Sharp = 1,
        HP,
        Other
    }
    #endregion

    #region Properties
    private string MarbeteTemplatePath
    {

        get
        {

            string path = Server.MapPath("~/MarbeteTemplate/Marbete.pdf");
            if (IsFull)
                path = Server.MapPath("~/MarbeteTemplate/Marbete_full.pdf");
            return path;
        }
    }
    private bool IsSharpPrinter
    {
        get
        {
            bool isSharpPrinter = false;
            if (Session["IsSharpPrinter"] != null && Session["IsSharpPrinter"].ToBool())
                isSharpPrinter = Session["IsSharpPrinter"].ToBool();
            return isSharpPrinter;
        }
    }
    private string TempDirectory
    {
        get
        {
            string directory = string.Empty;
            if (Session["TempDirectory"] != null)
                directory = Session["TempDirectory"].ToString();
            return directory;
        }
    }
    public bool IsFromService
    {
        get
        {
            bool result = false;
            if (Session["Chasis"] != null || !string.IsNullOrEmpty(Session["Chasis"].ToString()))
                result = true;
            return result;
        }
    }
    public bool IsFull
    {

        get
        {
            bool result = false;
            if (Session["IsFull"] != null)
            {
                if (Session["IsFull"].ToBool())
                    result = true;
            }
            return result;
        }

    }
    public string TemplateName
    {
        get
        {
             string name = "Marbete.pdf";
            
            if (IsFull)
                name = "Marbete_full.pdf";
            return name;
        }
    }
    private int UserID
    {
        get
        {
            int userid = 0;
            if (Session["UserID"] != null || !string.IsNullOrEmpty(Session["UserID"].ToString()))
                userid = int.Parse(Session["UserID"].ToString());
            return userid;
        }
    }
    public bool IsCombinedFill
    {
        get
        {
            bool result = false;
            if (Session["IsCombinedFill"] != null || !string.IsNullOrEmpty(Session["IsCombinedFill"].ToString()))
                result = Session["IsCombinedFill"].ToBool();
            return result;
        }

    }
    public bool ApplyBoldText
    {
        get
        {
            bool result = false;
            if (Session["ApplyBoldText"] != null || !string.IsNullOrEmpty(Session["ApplyBoldText"].ToString()))
                result = Session["ApplyBoldText"].ToBool();
            return result;
        }
    }
    public bool IsTo90Days
    {
        get
        {
            bool result = false;
            if (Session["IsTo90Days"] != null)
                result = Session["IsTo90Days"].ToBool();
            return result;
        }
    }
    /// <summary>
    /// Created by: Keny Martin
    /// </summary>
    public List<int> CombinedSections
    {
        get
        {
            var result = new List<int>();
            if (Session["CombinedSections"] != null)
                result = (List<int>)Session["CombinedSections"];
            return result;
        }
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)    {

        if (!IsPostBack)
            SetValues(cbFull.Checked);
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Session.Abandon();        //DeleteAllFiles();
        DeleteTempDirectory(recursive: true);
        Response.Redirect(WebConfigurationManager.AppSettings["SecurityLogin"]);
    }
    protected void cbFull_OnCheckedChanged(object sender, EventArgs e)
    {
        var checkBox = (CheckBox)sender;
        SetValues(checkBox.Checked);
        //SetValues(true);
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        ReturnToService();
    }
    protected void btnFillPDF_Click(object sender, EventArgs e)
    {
        Session["IsTo90Days"] = cb90Days.Checked;
        Session["ApplyBoldText"] = false;
        DeleteTemplate(IsFull);
        if (string.IsNullOrEmpty(txtPolicies.Text))
        {
            Utils.MessageBox(this, "Debe agregar al menos una poliza!!");
            return;
        }
        var policies = txtPolicies.Text.Replace("\r\n", ",").Replace("\n", ",").Split(',').ToArray();
        policies = policies.Where(o => !string.IsNullOrEmpty(o)).ToArray();
        if (IsFull)
        {
            SetFullnsurance(policies);
            return;
        }
        var section = (Sections)ddlPolicies.SelectedValue.ToInt();
        Session["IsCombinedFill"] = section == Sections.Combined ? true : false;
        if (IsCombinedFill)
            Fill(policies);
        else
            Fill(policies, section);
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {

        ClearPdf();
        cb90Days.Checked = IsTo90Days;
        cbFull.Checked = IsFull;
    }

    #endregion

    #region Public Methods
    /// <summary>
    /// 
    /// </summary>
    /// <param name="policies"></param>
    /// <param name="section"></param>
    public void Fill(string[] policies, Sections section = Sections.All)
    {
        var policyList = new DataAccess().GetDataMarbete(policies);
        //policyList = policyList.Where(o => !o.IsFull()).ToList();//Solo marbetes de Ley--Comentado para permitir impresion de marbetes full  en la seccion de Ley
        if (!policyList.Any()) return;
        int PageNumber = Convert.ToInt16(Math.Ceiling((float)policyList.Count / 6));
        int Marbetes = policyList.Count();
        int i = 0;
        while (i < PageNumber)
        {
            btnFillPDF.Text = "Generando...";
            var pdfPath = CopyFile(string.Concat(TemplateName, (i + 1).ToString()));
            var formFieldMap = PDFHelper.GetFormFieldNames(pdfPath);
            switch (section)
            {
                case Sections.First:
                    var _section1 = policyList.Take(1).FirstOrDefault();
                    if (_section1 == null) return;
                    formFieldMap["ano_1"] = _section1.Ano.DefaultValue();
                    formFieldMap["asegurado_1"] = _section1.nombrecliente.DefaultValue();
                    formFieldMap["chasis_1"] = _section1.Chassis.DefaultValue();
                    formFieldMap["fecha_inicio_1"] = _section1.fechainiciovigencia.Value.ToShortDateString();
                    formFieldMap["fecha_vencimiento_1"] = IsTo90Days ? _section1.fechainiciovigencia.Value.AddMonths(3).ToShortDateString() : _section1.fechafinvigencia.Value.ToShortDateString();
                    formFieldMap["fianza_1"] = _section1.Fianza.DefaultValue();
                    formFieldMap["marca_1"] = _section1.Marca.DefaultValue();
                    formFieldMap["modelo_1"] = _section1.Modelo.DefaultValue();
                    formFieldMap["poliza_1"] = _section1.poliza.DefaultValue();
                    formFieldMap["registro_1"] = _section1.Registro.DefaultValue();
                    formFieldMap["tipo_1"] = _section1.TipoVehiculo.DefaultValue();
                    formFieldMap["chk_casa_conductor_1"] = !string.IsNullOrEmpty(_section1.CasaConductor) ? "Yes" : string.Empty;
                    formFieldMap["chk_asistencia_vial_1"] = !string.IsNullOrEmpty(_section1.Asistencia) ? "Yes" : string.Empty;
                    formFieldMap["chk_grua_basica_1"] = !string.IsNullOrEmpty(_section1.Grua) ? "Yes" : string.Empty;
                    SetLog(_section1);
                    break;
                case Sections.Second:
                    if (Marbetes > 1)
                        policyList.RemoveAt(0);
                    var _section2 = policyList.Take(1).FirstOrDefault();
                    if (_section2 == null) return;
                    formFieldMap["ano_2"] = _section2.Ano.DefaultValue();
                    formFieldMap["asegurado_2"] = _section2.nombrecliente.DefaultValue();
                    formFieldMap["chasis_2"] = _section2.Chassis.DefaultValue();
                    formFieldMap["fecha_inicio_2"] = _section2.fechainiciovigencia.Value.ToShortDateString();
                    formFieldMap["fecha_vencimiento_2"] = IsTo90Days ? _section2.fechainiciovigencia.Value.AddMonths(3).ToShortDateString() : _section2.fechafinvigencia.Value.ToShortDateString();
                    formFieldMap["fianza_2"] = _section2.Fianza.DefaultValue();
                    formFieldMap["marca_2"] = _section2.Marca.DefaultValue();
                    formFieldMap["modelo_2"] = _section2.Modelo.DefaultValue();
                    formFieldMap["poliza_2"] = _section2.poliza.DefaultValue();
                    formFieldMap["registro_2"] = _section2.Registro.DefaultValue();
                    formFieldMap["tipo_2"] = _section2.TipoVehiculo.DefaultValue();
                    formFieldMap["chk_casa_conductor_2"] = !string.IsNullOrEmpty(_section2.CasaConductor) ? "Yes" : string.Empty;
                    formFieldMap["chk_asistencia_vial_2"] = !string.IsNullOrEmpty(_section2.Asistencia) ? "Yes" : string.Empty;
                    formFieldMap["chk_grua_basica_2"] = !string.IsNullOrEmpty(_section2.Grua) ? "Yes" : string.Empty;
                    SetLog(_section2);
                    break;
                case Sections.Third:
                    if (Marbetes >= 2)
                        policyList.RemoveAt(1);
                    //policyList.RemoveRange(0, 1);
                    var _section3 = Marbetes == 1 ? policyList.Take(1).FirstOrDefault() : policyList.Skip(1).Take(1).FirstOrDefault();
                    if (_section3 == null) return;
                    formFieldMap["ano_3"] = _section3.Ano.DefaultValue();
                    formFieldMap["asegurado_3"] = _section3.nombrecliente.DefaultValue();
                    formFieldMap["chasis_3"] = _section3.Chassis.DefaultValue();
                    formFieldMap["fecha_inicio_3"] = _section3.fechainiciovigencia.Value.ToShortDateString();
                    formFieldMap["fecha_vencimiento_3"] = IsTo90Days ? _section3.fechainiciovigencia.Value.AddMonths(3).ToShortDateString() : _section3.fechafinvigencia.Value.ToShortDateString();
                    formFieldMap["fianza_3"] = _section3.Fianza.DefaultValue();
                    formFieldMap["marca_3"] = _section3.Marca.DefaultValue();
                    formFieldMap["modelo_3"] = _section3.Modelo.DefaultValue();
                    formFieldMap["poliza_3"] = _section3.poliza.DefaultValue();
                    formFieldMap["registro_3"] = _section3.Registro.DefaultValue();
                    formFieldMap["tipo_3"] = _section3.TipoVehiculo.DefaultValue();
                    formFieldMap["chk_casa_conductor_3"] = !string.IsNullOrEmpty(_section3.CasaConductor) ? "Yes" : string.Empty;
                    formFieldMap["chk_asistencia_vial_3"] = !string.IsNullOrEmpty(_section3.Asistencia) ? "Yes" : string.Empty;
                    formFieldMap["chk_grua_basica_3"] = !string.IsNullOrEmpty(_section3.Grua) ? "Yes" : string.Empty;
                    SetLog(_section3);
                    break;
                case Sections.Fourth:
                    if (Marbetes >= 3)
                        policyList.RemoveAt(2);
                    var _section4 = Marbetes == 1 ? policyList.Take(1).FirstOrDefault() : policyList.Skip(1).Take(1).FirstOrDefault();
                    if (_section4 == null) return;
                    formFieldMap["ano_4"] = _section4.Ano.DefaultValue();
                    formFieldMap["asegurado_4"] = _section4.nombrecliente.DefaultValue();
                    formFieldMap["chasis_4"] = _section4.Chassis.DefaultValue();
                    formFieldMap["fecha_inicio_4"] = _section4.fechainiciovigencia.Value.ToShortDateString();
                    formFieldMap["fecha_vencimiento_4"] = IsTo90Days ? _section4.fechainiciovigencia.Value.AddMonths(3).ToShortDateString() : _section4.fechafinvigencia.Value.ToShortDateString();
                    formFieldMap["fianza_4"] = _section4.Fianza.DefaultValue();
                    formFieldMap["marca_4"] = _section4.Marca.DefaultValue();
                    formFieldMap["modelo_4"] = _section4.Modelo.DefaultValue();
                    formFieldMap["poliza_4"] = _section4.poliza.DefaultValue();
                    formFieldMap["registro_4"] = _section4.Registro.DefaultValue();
                    formFieldMap["tipo_4"] = _section4.TipoVehiculo.DefaultValue();
                    formFieldMap["chk_casa_conductor_4"] = !string.IsNullOrEmpty(_section4.CasaConductor) ? "Yes" : string.Empty;
                    formFieldMap["chk_asistencia_vial_4"] = !string.IsNullOrEmpty(_section4.Asistencia) ? "Yes" : string.Empty;
                    formFieldMap["chk_grua_basica_4"] = !string.IsNullOrEmpty(_section4.Grua) ? "Yes" : string.Empty;
                    SetLog(_section4);
                    break;
                case Sections.Fifth:
                    if (Marbetes >= 4)
                        policyList.RemoveAt(3);
                    //policyList.RemoveRange(0, 4);
                    var _section5 = Marbetes == 1 ? policyList.Take(1).FirstOrDefault() : policyList.Skip(1).Take(1).FirstOrDefault();
                    if (_section5 == null) return;
                    formFieldMap["ano_5"] = _section5.Ano.DefaultValue();
                    formFieldMap["asegurado_5"] = _section5.nombrecliente.DefaultValue();
                    formFieldMap["chasis_5"] = _section5.Chassis.DefaultValue();
                    formFieldMap["fecha_inicio_5"] = _section5.fechainiciovigencia.Value.ToShortDateString();
                    formFieldMap["fecha_vencimiento_5"] = IsTo90Days ? _section5.fechainiciovigencia.Value.AddMonths(3).ToShortDateString() : _section5.fechafinvigencia.Value.ToShortDateString();
                    formFieldMap["fianza_5"] = _section5.Fianza.DefaultValue();
                    formFieldMap["marca_5"] = _section5.Marca.DefaultValue();
                    formFieldMap["modelo_5"] = _section5.Modelo.DefaultValue();
                    formFieldMap["poliza_5"] = _section5.poliza.DefaultValue();
                    formFieldMap["registro_5"] = _section5.Registro.DefaultValue();
                    formFieldMap["tipo_5"] = _section5.TipoVehiculo.DefaultValue();
                    formFieldMap["chk_casa_conductor_5"] = !string.IsNullOrEmpty(_section5.CasaConductor) ? "Yes" : string.Empty;
                    formFieldMap["chk_asistencia_vial_5"] = !string.IsNullOrEmpty(_section5.Asistencia) ? "Yes" : string.Empty;
                    formFieldMap["chk_grua_basica_5"] = !string.IsNullOrEmpty(_section5.Grua) ? "Yes" : string.Empty;
                    SetLog(_section5);
                    break;
                case Sections.Sixth:
                    if (Marbetes >= 5)
                        policyList.RemoveAt(4);
                    //policyList.RemoveRange(0, 4);
                    var _section6 = Marbetes == 1 ? policyList.Take(1).FirstOrDefault() : policyList.Skip(1).Take(1).FirstOrDefault();
                    if (_section6 == null) return;
                    formFieldMap["ano_6"] = _section6.Ano.DefaultValue();
                    formFieldMap["asegurado_6"] = _section6.nombrecliente.DefaultValue();
                    formFieldMap["chasis_6"] = _section6.Chassis.DefaultValue();
                    formFieldMap["fecha_inicio_6"] = _section6.fechainiciovigencia.Value.ToShortDateString(); ;
                    formFieldMap["fecha_vencimiento_6"] = IsTo90Days ? _section6.fechainiciovigencia.Value.AddMonths(3).ToShortDateString() : _section6.fechafinvigencia.Value.ToShortDateString();
                    formFieldMap["fianza_6"] = _section6.Fianza.DefaultValue();
                    formFieldMap["marca_6"] = _section6.Marca.DefaultValue();
                    formFieldMap["modelo_6"] = _section6.Modelo.DefaultValue();
                    formFieldMap["poliza_6"] = _section6.poliza.DefaultValue();
                    formFieldMap["registro_6"] = _section6.Registro.DefaultValue();
                    formFieldMap["tipo_6"] = _section6.TipoVehiculo.DefaultValue();
                    formFieldMap["chk_casa_conductor_6"] = !string.IsNullOrEmpty(_section6.CasaConductor) ? "Yes" : string.Empty;
                    formFieldMap["chk_asistencia_vial_6"] = !string.IsNullOrEmpty(_section6.Asistencia) ? "Yes" : string.Empty;
                    formFieldMap["chk_grua_basica_6"] = !string.IsNullOrEmpty(_section6.Grua) ? "Yes" : string.Empty;
                    SetLog(_section6);
                    break;
                case Sections.All:
                    int sectionNo = 0;
                    int records = Marbetes <= 6 ? Marbetes : 6;
                    var AllSection = policyList.Take(records).ToList();
                    foreach (var _section in AllSection)
                    {
                        sectionNo++;
                        formFieldMap[string.Concat("ano_", sectionNo.ToString())] = _section.Ano.DefaultValue();
                        formFieldMap[string.Concat("asegurado_", sectionNo.ToString())] = _section.nombrecliente.DefaultValue();
                        formFieldMap[string.Concat("chasis_", sectionNo.ToString())] = _section.Chassis.DefaultValue();
                        formFieldMap[string.Concat("fecha_inicio_", sectionNo.ToString())] = _section.fechainiciovigencia.Value.ToShortDateString();
                        formFieldMap[string.Concat("fecha_vencimiento_", sectionNo.ToString())] = IsTo90Days ? _section.fechainiciovigencia.Value.AddMonths(3).ToShortDateString() : _section.fechafinvigencia.Value.ToShortDateString();
                        formFieldMap[string.Concat("fianza_", sectionNo.ToString())] = _section.Fianza.DefaultValue();
                        formFieldMap[string.Concat("marca_", sectionNo.ToString())] = _section.Marca.DefaultValue();
                        formFieldMap[string.Concat("modelo_", sectionNo.ToString())] = _section.Modelo.DefaultValue();
                        formFieldMap[string.Concat("poliza_", sectionNo.ToString())] = _section.poliza.DefaultValue();
                        formFieldMap[string.Concat("registro_", sectionNo.ToString())] = _section.Registro.DefaultValue();
                        formFieldMap[string.Concat("tipo_", sectionNo.ToString())] = _section.TipoVehiculo.DefaultValue();
                        formFieldMap[string.Concat("chk_casa_conductor_", sectionNo.ToString())] = !string.IsNullOrEmpty(_section.CasaConductor) ? "Yes" : string.Empty;
                        formFieldMap[string.Concat("chk_asistencia_vial_", sectionNo.ToString())] = !string.IsNullOrEmpty(_section.Asistencia) ? "Yes" : string.Empty;
                        formFieldMap[string.Concat("chk_grua_basica_", sectionNo.ToString())] = !string.IsNullOrEmpty(_section.Grua) ? "Yes" : string.Empty;
                        Marbetes--;
                        policyList.Remove(_section);
                        SetLog(_section);
                        if (Marbetes == 0) break;
                    }
                    break;
            }
            i++;
            var byteFile = GeneratePDF(pdfPath, formFieldMap, ApplyBoldText);
            File.WriteAllBytes(pdfPath, byteFile.Item1);
        }

        Merge(TempDirectory);
        RefreshIframe(string.Concat("MergePdf", "/", TemplateName));
        //btnFillPDF.Text = "Llenar PDF";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="policies"></param>
    public void Fill(string[] policies)
    {
        Session["CombinedSections"] = (new List<int>(0) { });
        if (marbete1.Checked)
            CombinedSections.Add(1);
        if (marbete2.Checked)
            CombinedSections.Add(2);
        if (marbete3.Checked)
            CombinedSections.Add(3);
        if (marbete4.Checked)
            CombinedSections.Add(4);
        if (marbete5.Checked)
            CombinedSections.Add(5);
        if (marbete6.Checked)
            CombinedSections.Add(6);
        var quantityOfCheckBoxes = 0;
        if (CombinedSections.Count() == 0)
        {
            Utils.MessageBox(this, "Debe cotejar al menos una sección!!");
            return;
        }
        quantityOfCheckBoxes = CombinedSections.Count();
        var section = Sections.Combined;
        var marbeteList = new DataAccess().GetDataMarbete(policies);
        //marbeteList = marbeteList.Where(o => !o.IsFull()).ToList();//Solo marbetes de Ley--Comentado para permitir impresion de marbetes full  es la seccion de Ley
        if (!marbeteList.Any()) return;
        int PageNumber = Convert.ToInt16(Math.Ceiling((float)marbeteList.Count / 6));
        int Marbetes = marbeteList.Count();
        int i = 0;
        while (i < PageNumber)
        {
            btnFillPDF.Text = "Generando...";
            var pdfPath = CopyFile(string.Concat(TemplateName, (i + 1).ToString()));
            var formFieldMap = PDFHelper.GetFormFieldNames(pdfPath);
            switch (section)
            {
                case Sections.Combined:
                default:
                    var sectionsByPage = 6;
                    int sectionNo = 0;
                    var combinedsectionNo = 0;
                    int records = Marbetes <= sectionsByPage ? Marbetes : sectionsByPage;
                    var AllSection = marbeteList.Take(records).ToList();
                    foreach (var _section in AllSection)
                    {
                        sectionNo++;
                        if (!CombinedSections.Contains(sectionNo))
                        {
                            if (records < sectionsByPage)
                            {
                                if (quantityOfCheckBoxes == 1)
                                {
                                    var record = (Sections)CombinedSections.First();
                                    MoveToSection(_section, record, formFieldMap);
                                }
                                else
                                {
                                    foreach (var checkBoxValue in CombinedSections)
                                    {
                                        if (combinedsectionNo == CombinedSections.Count()) break;
                                        var sectionToMove = (Sections)checkBoxValue;
                                        var record = AllSection.ElementAtOrDefault(combinedsectionNo);
                                        combinedsectionNo++;
                                        if (record != null)
                                            MoveToSection(record, sectionToMove, formFieldMap);
                                    }
                                }
                            }
                            else
                                continue;
                        }
                        else
                        {
                            formFieldMap[string.Concat("ano_", sectionNo.ToString())] = _section.Ano.DefaultValue();
                            formFieldMap[string.Concat("asegurado_", sectionNo.ToString())] = _section.nombrecliente.DefaultValue();
                            formFieldMap[string.Concat("chasis_", sectionNo.ToString())] = _section.Chassis.DefaultValue();
                            formFieldMap[string.Concat("fecha_inicio_", sectionNo.ToString())] = _section.fechainiciovigencia.Value.ToShortDateString();
                            formFieldMap[string.Concat("fecha_vencimiento_", sectionNo.ToString())] = IsTo90Days ? _section.fechainiciovigencia.Value.AddMonths(3).ToShortDateString() : _section.fechafinvigencia.Value.ToShortDateString();
                            formFieldMap[string.Concat("fianza_", sectionNo.ToString())] = _section.Fianza.DefaultValue();
                            formFieldMap[string.Concat("marca_", sectionNo.ToString())] = _section.Marca.DefaultValue();
                            formFieldMap[string.Concat("modelo_", sectionNo.ToString())] = _section.Modelo.DefaultValue();
                            formFieldMap[string.Concat("poliza_", sectionNo.ToString())] = _section.poliza.DefaultValue();
                            formFieldMap[string.Concat("registro_", sectionNo.ToString())] = _section.Registro.DefaultValue();
                            formFieldMap[string.Concat("tipo_", sectionNo.ToString())] = _section.TipoVehiculo.DefaultValue();
                            formFieldMap[string.Concat("chk_casa_conductor_", sectionNo.ToString())] = !string.IsNullOrEmpty(_section.CasaConductor) ? "Yes" : string.Empty;
                            formFieldMap[string.Concat("chk_asistencia_vial_", sectionNo.ToString())] = !string.IsNullOrEmpty(_section.Asistencia) ? "Yes" : string.Empty;
                            formFieldMap[string.Concat("chk_grua_basica_", sectionNo.ToString())] = !string.IsNullOrEmpty(_section.Grua) ? "Yes" : string.Empty;
                        }
                        Marbetes--;
                        marbeteList.Remove(_section);
                        SetLog(_section);
                        if (Marbetes == 0) break;
                    }
                    break;
            }
            i++;
            var byteFile = GeneratePDF(pdfPath, formFieldMap, ApplyBoldText);
            File.WriteAllBytes(pdfPath, byteFile.Item1);
        }
        Merge(TempDirectory);
        RefreshIframe(string.Concat("MergePdf", "/", TemplateName));
        btnFillPDF.Text = "Llenar PDF";
    }

    public void SetFullnsurance(string[] policies)
    {
        //ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script> confirm('Hello');</script>", false);
        var policyList = new DataAccess().GetDataMarbete(policies);
        policyList = policyList.Where(o => o.IsFull()).ToList();
        if (!policyList.Any()) return;
        int PageNumber = policyList.Count;
        int i = 0;
        int pages = new int();
        pages = PageNumber;
        while (i < PageNumber)
        {
            btnFillPDF.Text = "Generando...";
            var pdfPath = CopyFile(string.Concat(TemplateName, (i + 1).ToString()));
            var formFieldMap = PDFHelper.GetFormFieldNames(pdfPath);
            var currentPage = policyList.ElementAtOrDefault(i);
            if (currentPage == null) continue;
            var AllSection = new List<VW_DATA_MARBETE> { currentPage };
            foreach (var item in AllSection)
            {
                if (item == null) break;
                
                var asist = item.Asistencia.DefaultValue();
                var casa = item.CasaConductor.DefaultValue();
                var grua = item.Grua.DefaultValue();


                if (asist == "Asistencia Vial Atlantica")
                {
                    formFieldMap["rdbtCobertura_marbete_asistencia_vial"] = "Yes";
                }
                if (casa == "Casa Del Conductor")
                {
                    formFieldMap["rdbtCobertura_marbete_casa_conductor"] = "Yes";
                }
                if (grua == "Servicio de Grua")
                {
                    formFieldMap["txtMarbete_grua"] = item.Grua.DefaultValue();
                }       

                formFieldMap["txtMarbete_ano"] = item.Ano.DefaultValue();
                formFieldMap["txtMarbete_chasis"] = item.Chassis.DefaultValue();
                formFieldMap["txtMarbete_fecha_inicio"] = item.fechainiciovigencia.Value.ToShortDateString();
                formFieldMap["txtMarbete_fecha_vencimiento"] = IsTo90Days ? item.fechainiciovigencia.Value.AddMonths(3).ToShortDateString() : item.fechafinvigencia.Value.ToShortDateString();
                formFieldMap["txtMarbete_fianza_judicial"] = item.Fianza.DefaultValue();
                formFieldMap["txtMarbete_marca"] = item.Marca.DefaultValue();
                formFieldMap["txtMarbete_modelo"] = item.Modelo.DefaultValue();
                formFieldMap["txtMarbete_numero_poliza"] = item.poliza.DefaultValue();
                formFieldMap["txtMarbete_registro"] = item.Registro.DefaultValue();
                formFieldMap["txtMarbete_tipo"] = item.TipoVehiculo.DefaultValue();
                formFieldMap["txtMarbete_segurado"] = item.nombrecliente.DefaultValue();
                

                pages--;
                SetLog(item);
                if (pages == 0) break;
            }
            i++;
            var byteFile = GeneratePDF(pdfPath, formFieldMap, ApplyBoldText);
            File.WriteAllBytes(pdfPath, byteFile.Item1);
        }
        Merge(TempDirectory);
        RefreshIframe(string.Concat("MergePdf", "/", TemplateName));
    }

    #endregion

    #region Private Methods
    void DeleteTemplate(bool isFull = false)
    {

        if (!IsFull)
        {
            var files = Directory.GetFiles(TempDirectory).Where(o => o.Contains("Marbete_full")).ToList();
            if (files.Any())
                files.ForEach(o => File.Delete(o));
        }
        else
        {
            var files = Directory.GetFiles(TempDirectory).Where(o => o.Contains("Marbete")).ToList();
            if (files.Any())
                files.ForEach(o => File.Delete(o));
        }

    }
    static Tuple<byte[], int> GeneratePDF(string pdfPath, Dictionary<string, string> formFieldMap, bool applyBoldText = false)
    {
        var tupleResult = new Tuple<byte[], int>(null, 0);
        var output = new MemoryStream();
        var reader = new PdfReader(pdfPath);
        var stamper = new PdfStamper(reader, output);
        var formFields = stamper.AcroFields;
        foreach (var fieldName in formFieldMap.Keys)
        {
            if (applyBoldText)
                formFields.SetFieldProperty(fieldName, "textfont", iTextSharp.text.Font.BOLD, null);
            formFields.SetField(fieldName, formFieldMap[fieldName]);
        }
        stamper.FormFlattening = true;
        stamper.Close();
        reader.Close();
        tupleResult = Tuple.Create(output.ToArray(), reader.NumberOfPages);
        return tupleResult;
    }
    /// <summary>
    /// Moves a record to a specific section. 
    /// Create by: Keny Martin.
    /// </summary>
    /// <param name="record">record</param>
    /// <param name="section">section</param>
    /// <param name="formFieldMap">Dictionary string, string> </param>
    void MoveToSection(VW_DATA_MARBETE record, Sections section, Dictionary<string, string> formFieldMap)
    {
        switch (section)
        {
            case Sections.First:
                formFieldMap["ano_1"] = record.Ano.DefaultValue();
                formFieldMap["asegurado_1"] = record.nombrecliente.DefaultValue();
                formFieldMap["chasis_1"] = record.Chassis.DefaultValue();
                formFieldMap["fecha_inicio_1"] = record.fechainiciovigencia.Value.ToShortDateString();
                formFieldMap["fecha_vencimiento_1"] = IsTo90Days ? record.fechainiciovigencia.Value.AddMonths(3).ToShortDateString() : record.fechafinvigencia.Value.ToShortDateString();
                formFieldMap["fianza_1"] = record.Fianza.DefaultValue();
                formFieldMap["marca_1"] = record.Marca.DefaultValue();
                formFieldMap["modelo_1"] = record.Modelo.DefaultValue();
                formFieldMap["poliza_1"] = record.poliza.DefaultValue();
                formFieldMap["registro_1"] = record.Registro.DefaultValue();
                formFieldMap["tipo_1"] = record.TipoVehiculo.DefaultValue();
                formFieldMap["chk_casa_conductor_1"] = !string.IsNullOrEmpty(record.CasaConductor) ? "Yes" : string.Empty;
                formFieldMap["chk_asistencia_vial_1"] = !string.IsNullOrEmpty(record.Asistencia) ? "Yes" : string.Empty;
                formFieldMap["chk_grua_basica_1"] = !string.IsNullOrEmpty(record.Grua) ? "Yes" : string.Empty;
                break;
            case Sections.Second:
                formFieldMap["ano_2"] = record.Ano.DefaultValue();
                formFieldMap["asegurado_2"] = record.nombrecliente.DefaultValue();
                formFieldMap["chasis_2"] = record.Chassis.DefaultValue();
                formFieldMap["fecha_inicio_2"] = record.fechainiciovigencia.Value.ToShortDateString();
                formFieldMap["fecha_vencimiento_2"] = IsTo90Days ? record.fechainiciovigencia.Value.AddMonths(3).ToShortDateString() : record.fechafinvigencia.Value.ToShortDateString();
                formFieldMap["fianza_2"] = record.Fianza.DefaultValue();
                formFieldMap["marca_2"] = record.Marca.DefaultValue();
                formFieldMap["modelo_2"] = record.Modelo.DefaultValue();
                formFieldMap["poliza_2"] = record.poliza.DefaultValue();
                formFieldMap["registro_2"] = record.Registro.DefaultValue();
                formFieldMap["tipo_2"] = record.TipoVehiculo.DefaultValue();
                formFieldMap["chk_casa_conductor_2"] = !string.IsNullOrEmpty(record.CasaConductor) ? "Yes" : string.Empty;
                formFieldMap["chk_asistencia_vial_2"] = !string.IsNullOrEmpty(record.Asistencia) ? "Yes" : string.Empty;
                formFieldMap["chk_grua_basica_2"] = !string.IsNullOrEmpty(record.Grua) ? "Yes" : string.Empty;
                break;
            case Sections.Third:
                formFieldMap["ano_3"] = record.Ano.DefaultValue();
                formFieldMap["asegurado_3"] = record.nombrecliente.DefaultValue();
                formFieldMap["chasis_3"] = record.Chassis.DefaultValue();
                formFieldMap["fecha_inicio_3"] = record.fechainiciovigencia.Value.ToShortDateString();
                formFieldMap["fecha_vencimiento_3"] = IsTo90Days ? record.fechainiciovigencia.Value.AddMonths(3).ToShortDateString() : record.fechafinvigencia.Value.ToShortDateString();
                formFieldMap["fianza_3"] = record.Fianza.DefaultValue();
                formFieldMap["marca_3"] = record.Marca.DefaultValue();
                formFieldMap["modelo_3"] = record.Modelo.DefaultValue();
                formFieldMap["poliza_3"] = record.poliza.DefaultValue();
                formFieldMap["registro_3"] = record.Registro.DefaultValue();
                formFieldMap["tipo_3"] = record.TipoVehiculo.DefaultValue();
                formFieldMap["chk_casa_conductor_3"] = !string.IsNullOrEmpty(record.CasaConductor) ? "Yes" : string.Empty;
                formFieldMap["chk_asistencia_vial_3"] = !string.IsNullOrEmpty(record.Asistencia) ? "Yes" : string.Empty;
                formFieldMap["chk_grua_basica_3"] = !string.IsNullOrEmpty(record.Grua) ? "Yes" : string.Empty;
                break;
            case Sections.Fourth:
                formFieldMap["ano_4"] = record.Ano.DefaultValue();
                formFieldMap["asegurado_4"] = record.nombrecliente.DefaultValue();
                formFieldMap["chasis_4"] = record.Chassis.DefaultValue();
                formFieldMap["fecha_inicio_4"] = record.fechainiciovigencia.Value.ToShortDateString();
                formFieldMap["fecha_vencimiento_4"] = IsTo90Days ? record.fechainiciovigencia.Value.AddMonths(3).ToShortDateString() : record.fechafinvigencia.Value.ToShortDateString();
                formFieldMap["fianza_4"] = record.Fianza.DefaultValue();
                formFieldMap["marca_4"] = record.Marca.DefaultValue();
                formFieldMap["modelo_4"] = record.Modelo.DefaultValue();
                formFieldMap["poliza_4"] = record.poliza.DefaultValue();
                formFieldMap["registro_4"] = record.Registro.DefaultValue();
                formFieldMap["tipo_4"] = record.TipoVehiculo.DefaultValue();
                formFieldMap["chk_casa_conductor_4"] = !string.IsNullOrEmpty(record.CasaConductor) ? "Yes" : string.Empty;
                formFieldMap["chk_asistencia_vial_4"] = !string.IsNullOrEmpty(record.Asistencia) ? "Yes" : string.Empty;
                formFieldMap["chk_grua_basica_4"] = !string.IsNullOrEmpty(record.Grua) ? "Yes" : string.Empty;
                break;
            case Sections.Fifth:
                formFieldMap["ano_5"] = record.Ano.DefaultValue();
                formFieldMap["asegurado_5"] = record.nombrecliente.DefaultValue();
                formFieldMap["chasis_5"] = record.Chassis.DefaultValue();
                formFieldMap["fecha_inicio_5"] = record.fechainiciovigencia.Value.ToShortDateString();
                formFieldMap["fecha_vencimiento_5"] = IsTo90Days ? record.fechainiciovigencia.Value.AddMonths(3).ToShortDateString() : record.fechafinvigencia.Value.ToShortDateString();
                formFieldMap["fianza_5"] = record.Fianza.DefaultValue();
                formFieldMap["marca_5"] = record.Marca.DefaultValue();
                formFieldMap["modelo_5"] = record.Modelo.DefaultValue();
                formFieldMap["poliza_5"] = record.poliza.DefaultValue();
                formFieldMap["registro_5"] = record.Registro.DefaultValue();
                formFieldMap["tipo_5"] = record.TipoVehiculo.DefaultValue();
                formFieldMap["chk_casa_conductor_5"] = !string.IsNullOrEmpty(record.CasaConductor) ? "Yes" : string.Empty;
                formFieldMap["chk_asistencia_vial_5"] = !string.IsNullOrEmpty(record.Asistencia) ? "Yes" : string.Empty;
                formFieldMap["chk_grua_basica_5"] = !string.IsNullOrEmpty(record.Grua) ? "Yes" : string.Empty;
                break;
            case Sections.Sixth:
                formFieldMap["ano_6"] = record.Ano.DefaultValue();
                formFieldMap["asegurado_6"] = record.nombrecliente.DefaultValue();
                formFieldMap["chasis_6"] = record.Chassis.DefaultValue();
                formFieldMap["fecha_inicio_6"] = record.fechainiciovigencia.Value.ToShortDateString(); ;
                formFieldMap["fecha_vencimiento_6"] = IsTo90Days ? record.fechainiciovigencia.Value.AddMonths(3).ToShortDateString() : record.fechafinvigencia.Value.ToShortDateString();
                formFieldMap["fianza_6"] = record.Fianza.DefaultValue();
                formFieldMap["marca_6"] = record.Marca.DefaultValue();
                formFieldMap["modelo_6"] = record.Modelo.DefaultValue();
                formFieldMap["poliza_6"] = record.poliza.DefaultValue();
                formFieldMap["registro_6"] = record.Registro.DefaultValue();
                formFieldMap["tipo_6"] = record.TipoVehiculo.DefaultValue();
                formFieldMap["chk_casa_conductor_6"] = !string.IsNullOrEmpty(record.CasaConductor) ? "Yes" : string.Empty;
                formFieldMap["chk_asistencia_vial_6"] = !string.IsNullOrEmpty(record.Asistencia) ? "Yes" : string.Empty;
                formFieldMap["chk_grua_basica_6"] = !string.IsNullOrEmpty(record.Grua) ? "Yes" : string.Empty;
                break;
            default:
                break;
        }
    }
    void ReturnToService()
    {
        try
        {
            if (!string.IsNullOrEmpty(Session["Chasis"].ToString()))
            {
                string Chasis = Session["Chasis"].ToString();
                LinkButton bntDrop = new LinkButton();
                bntDrop.Attributes["path"] = "ContactList.aspx";
                bntDrop.Attributes["appname"] = "VOVehiculos";
                /*Enviar Chasis Como parametro*/
                bntDrop.Attributes.Add("Action", Chasis);
                var addInfo = new AdditionalInfo
                {
                    CompanyId = 2,
                    Language = "es"
                };
                var data = SecurityPage.GenerateToken(UserID, bntDrop, addInfo);
                if (data.Status)
                    Response.Redirect(data.UrlPath, true);
                else
                    this.MessageBox(data.errormessage);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void SetValues(bool isFull = false)
    {
        Session["IsFull"] = isFull;
        ddlPolicies.SelectedValue = isFull ? "0" : ddlPolicies.SelectedValue;
        ddlPolicies.Enabled = !isFull;
        ltlUserName.Text = Session["UserName"] != null ? Session["UserName"].ToString() : string.Empty;
        DeleteAllFiles();
        iframePDF.Attributes["src"] = "about:blank";
        iframePDF.Attributes.Remove("src");
        iframePDF.Attributes.Add("src", string.Concat("MarbeteTemplate", "/", TemplateName));
        if (Session["Chasis"] != null)
        {
            if (!string.IsNullOrEmpty(Session["Chasis"].ToString()))
            {
                txtPolicies.Text = Session["Chasis"].ToString();
                dvAtras.Visible = true;
                btnFillPDF_Click(new object[] { txtPolicies.Text }, EventArgs.Empty);
            }
        }
    }
    void RefreshIframe(string path = null)
    {
        path = path ?? MarbeteTemplatePath;
        iframePDF.Attributes["src"] = path;
    }
    void SetLog(VW_DATA_MARBETE section)
    {
        try
        {
            if (Keys.AppSettings["ApplyAudit"].ToString(CultureInfo.InvariantCulture) == "true")
            {
                var UserID = Session["UserID"].ToInt();
                if (UserID == 202) return;
                var User = new UserInfo();
                User.UserFullName = Session["UserName"].ToString();
                User.Policy = section.poliza;
                User.Quotation = section.cotizacion;
                User.Sequence = section.SECUENCIA;
                new DataAccess().AddLog(User);
            }
        }
        catch (Exception)
        {
            return;
        }
    }
    void ClearPdf()
    {
        var originalFile = File.ReadAllBytes(Server.MapPath(string.Concat("~/MarbetBackUpTempate", "/", TemplateName)));
        var targetPath = MarbeteTemplatePath;
        File.WriteAllBytes(targetPath, originalFile);
        txtPolicies.Text = string.Empty;
        ddlPolicies.SelectedValue = "0";
        DeleteAllFiles();
        iframePDF.Attributes["src"] = "about:blank";
        iframePDF.Attributes.Remove("src");
        iframePDF.Attributes.Add("src", string.Concat("MarbeteTemplate", "/", TemplateName));
    }
    void SendToPrinter()
    {
        var info = new ProcessStartInfo();
        var pdfArray = Directory.GetFiles(TempDirectory);
        for (int i = 0; i < pdfArray.Length; i++)
        {
            info.Verb = "print";
            info.FileName = pdfArray[i];// @"c:\output.pdf";
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = new Process();
            p.StartInfo = info;
            p.Start();
            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(3000);

            if (false == p.CloseMainWindow())
                p.Kill();
        }
    }
    string CopyFile(string filename = null)
    {
        filename = filename.Replace(".pdf", "") ?? "Marbete";
        string targetPath = string.Concat(TempDirectory, "/", filename, ".pdf");
        File.Copy(MarbeteTemplatePath, targetPath, true);
        return targetPath;
    }
    void DeleteAllFiles()
    {
        var directory = TempDirectory;
        if (string.IsNullOrEmpty(directory)) return;
        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        var files = Directory.GetFiles(directory).ToList();
        if (files.Any())
        {
            try
            {
                files.ForEach(o => File.Delete(o));
            }
            catch (IOException)
            {
                return;
            }
        }
    }
    /// <summary>
    /// Deletes the TempDirectory by user and, if indicated, any subdirectories and
    ///    files in the directory.
    /// </summary>
    /// <param name="recursive"></param>
    void DeleteTempDirectory(bool recursive = false)
    {
        if (Directory.Exists(TempDirectory))
            Directory.Delete(TempDirectory, recursive);
    }
    void Merge(string path)
    {
        // step 1: creation of a document-object
        Document document = new Document();
        string[] fileNames = Directory.GetFiles(path).ToArray();
        string outFile = Server.MapPath(string.Concat("~/MergePDF", "/", TemplateName));//TODO: CONSIDER USAR VARIABLE DE SESSION PARA ESTO.
        // step 2: we create a writer that listens to the document
        PdfCopy writer = new PdfCopy(document, new FileStream(outFile, FileMode.Create));
        if (writer == null)
        {
            return;
        }
        // step 3: we open the document
        document.Open();
        foreach (string fileName in fileNames)
        {
            // we create a reader for a certain document
            PdfReader reader = new PdfReader(fileName);
            reader.ConsolidateNamedDestinations();
            // step 4: we add content
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                PdfImportedPage page = writer.GetImportedPage(reader, i);
                writer.AddPage(page);
            }
            PRAcroForm form = reader.AcroForm;
            if (form != null)
            {
                writer.CopyAcroForm(reader);
            }
            reader.Close();
        }
        // step 5: we close the document and writer
        writer.Close();
        document.Close();
    }


    #endregion
}