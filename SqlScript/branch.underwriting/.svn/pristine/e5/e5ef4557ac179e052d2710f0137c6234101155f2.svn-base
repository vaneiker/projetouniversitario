using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using WEB.NewBusiness.EquifaxService;
using WEB.NewBusiness.TransunionServiceReference;

namespace WEB.NewBusiness.NewBusiness.UserControls.Common
{
    public partial class WUCEquifax : UC, IUC
    {
        public void Translator(string Lang) { }
        public void ReadOnlyControls(bool isReadOnly) { }
        public void save() { }
        public void edit() { }
        public void ClearData() { }

        public string KeyRiesgo
        {
            get { return ViewState["KeyRiesgo"].ToString(); }
            set { ViewState["KeyRiesgo"] = value; }
        }

        const string NumberFormat = "#0,0.00";
        const string defaultValue = "0";

        public string pCedulaOrDriverLicense
        {
            get
            {
                return ViewState["CedulaOrDriverLicense"].ToString();
            }

            set
            {
                ViewState["CedulaOrDriverLicense"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            pdfViewerEquifax.LicenseKey = System.Configuration.ConfigurationManager.AppSettings["PDFViewer"];
            if (
                ObjServices.IsSuscripcionQuotRole ||
                ObjServices.IsSucripcionDirectorQuotRole ||
                ObjServices.IsSuscripcionManagerQuotRole
               )
            {
                //trDirecciones.Visible = false;
                //trTelefonos.Visible = false;
            }
        }

        public void FillData()
        {
            //Objeto del tipo Salida que devuelve el servicio de Equifax al consultar el método GetReportHCIFromEquifax
            var data = new EquifaxService.salida();
            try
            {

                //Objeto de la data del Contacto
                var ContactData = ObjServices.oContactManager.GetContact(ObjServices.Corp_Id, (int)ObjServices.ContactEntityID, ObjServices.Language.ToInt());
                //Instancia del servicio de equifax
                var EquiFaxclient = ObjServices.EquifaxServiceLogIn(ObjServices.userEF, ObjServices.passEF, ObjServices.DefaulltPasswordEF);
                //Obtener la lista de documentos registrados para el cliente en la tabla EN_CONTACT_IDS de la base de datos Global
                var lstIdentification = ObjServices.oContactManager.GetAllIdDocumentInformation(ObjServices.ContactEntityID.GetValueOrDefault(),
                ObjServices.getCurrentLanguage());

                //Variables a utilizar para almacenar el número de DUI, NIT y fecha de nacimiento exigidos por el servicio de equifax
                string _dui = "";
                string _nit = "";
                string FechaNac = "";
                //Variable de tipo numeración para almacenar el tipo de persona
                EquifaxService.TipoPersona tipoPers;

                //Buscamos el número de DUI y de NIT en la lista de documentos obtenidos
                if (lstIdentification != null && lstIdentification.Any())
                {
                    foreach (var id in lstIdentification)
                    {
                        if (id.ContactIdTypeDescription.ToUpper() == "DUI")
                        {
                            _dui = id.Id;
                        }
                        if (id.ContactIdTypeDescription.ToUpper() == "NIT")
                        {
                            _nit = id.Id;
                        }
                    }
                }

                //Extraemos la fecha de  nacimiento del cliente
                if (ContactData.Dob.HasValue)
                {
                    FechaNac = ContactData.Dob.Value.ToString("ddMMyyyy").ToUpper();
                }

                //Extraemos el tipo de persona del cliente y seteamos tipoPers con el tipo numeración
                if (ContactData.TipoPersona == "Natural")
                {
                    tipoPers = EquifaxService.TipoPersona.Natural;
                }
                else
                {
                    tipoPers = EquifaxService.TipoPersona.Juridica;
                }

                //Objeto para enviar los parametros necesarios para consultar el  servicio equifax
                EquifaxService.Input Parametros = null;

                Parametros = new EquifaxService.Input
                {
                    dui = _dui,
                    nit = _nit,
                    fechaNacimiento = FechaNac,
                    primerNombre = ContactData.FirstName,
                    segundoNombre = ContactData.MiddleName,
                    primerApellido = ContactData.FirstLastName,
                    segundoApellido = ContactData.SecondLastName,
                    apellidoCasada = ContactData.SecondLastName,
                    UserId = ObjServices.user,
                    tipoPersona = tipoPers
                };

#if DEBUG
                Parametros = new EquifaxService.Input
                {
                    dui = "033485386",
                    nit = "03070311841016",
                    fechaNacimiento = "03111984",
                    primerNombre = "Joel",
                    segundoNombre = "Alfonso",
                    primerApellido = "Solís",
                    segundoApellido = "Santos",
                    UserId = "vbarrera",
                    apellidoCasada = "Santos",
                    tipoPersona = TipoPersona.Natural
                };

#endif



                //Llamada al método GetReportHCIFromEquifax que recibe como argumentos un objeto de tipo Input
                data = EquiFaxclient.GetReportHCIFromEquifax(Parametros);
                if (data == null)
                    return;

                //Si el servicio devuelve data asignamos la propiedad de tipo arrego de bytes "reportePdf",
                //Como Source del PdfViewer 
                if (data != null)
                {
                    pdfViewerEquifax.PdfSourceBytes = data.reportePdf;
                    pdfViewerEquifax.DataBind();
                }

            }
            catch (Exception ex)
            {
                var body = "";
                //WEB.NewBusiness.Common.Log_Error.RegistrarError(ex, HttpContext.Current.Request.Url.AbsoluteUri, System.Reflection.MethodBase.GetCurrentMethod().Name); //Joel Solis 09/03/2017
                if (ex.Message.IndexOf("ValidateDui") > 0 || ex.Message.IndexOf("DUI no.") > 0)
                {
                    this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.IDnoValid);
                }
                else if (ex.Message.IndexOf("ValidateNit") > 0)
                {
                    body = string.Format("El Sr(a) {1} No ha proporcionado un Número de Identificación Tributaria válido para realizar consulta de su información crediticia", ObjServices.CustomerName);
                    byte[] toBytes = Encoding.ASCII.GetBytes(body);
                    pdfViewerEquifax.PdfSourceBytes = toBytes;
                    pdfViewerEquifax.DataBind();

                }
                else
                    this.MessageBox(string.Format("ExceptionMessage {0} TraceStack {1}", ex.Message, ex.StackTrace).MyRemoveInvalidCharacters(), Title: "Error", Width: 800);
                return;
            }

        }

        public void Initialize() { }

        public void Initialize(string KeyRiesgo)
        {
            this.KeyRiesgo = KeyRiesgo;
            ClearData();
            FillData();
        }
    }
}