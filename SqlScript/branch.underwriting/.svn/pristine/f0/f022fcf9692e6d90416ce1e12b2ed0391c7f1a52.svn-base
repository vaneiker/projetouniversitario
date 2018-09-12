using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines
{
    public partial class UCAlliedLinesDetail : UC, IUC
    {
        public delegate void ExportToPDFHandler(byte[] pdfFile, string FileName);
        public event ExportToPDFHandler ExportToPdf;

        public void ExportPDF(byte[] pdfFile, string FileName)
        {
            ExportToPdf(pdfFile, FileName);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UCProperty.ExportToPdf += ExportPDF;
            UCNavy.ExportToPdf += ExportPDF;
            UCTransport.ExportToPdf += ExportPDF;
            UCAirPlane.ExportToPdf += ExportPDF;
            UCBail.ExportToPdf += ExportPDF;
        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void ReadOnlyControls(bool isReadOnly)
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
        }

        public void Initialize()
        {
            switch (ObjServices.AlliedLinesProductBehavior)
            {
                case Utility.AlliedLinesType.Property:
                    mtControl.SetActiveView(vPropertyDetail);
                    UCProperty.Initialize();
                    break;
                case Utility.AlliedLinesType.Navy:
                    mtControl.SetActiveView(vNavyDetail);
                    UCNavy.Initialize();
                    break;
                case Utility.AlliedLinesType.Transport:
                    mtControl.SetActiveView(vTransportDetail);
                    UCTransport.Initialize();
                    break;
                case Utility.AlliedLinesType.Airplane:
                    mtControl.SetActiveView(vAirPlaneDetail);
                    UCAirPlane.Initialize();
                    break;
                case Utility.AlliedLinesType.Bail:
                    mtControl.SetActiveView(vBailDetail);
                    UCBail.Initialize();
                    break;
            }

        }

        public void ClearData()
        {
        }
    }
}