using System;
using System.Collections.Generic;
using Entity.UnderWriting.Entities;
using WEB.NewBusiness.Common;
using WEB.NewBusiness.Common.Illustration.IllustrationVehicle.Models;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle
{
    public partial class UCRequiredInformation : UC, IUC
    {
        public delegate void ExportToPDFHandler(byte[] byteArray, string FileName);

        public event ExportToPDFHandler ExportFile;

        public void ReadOnlyControls(bool isReadOnly) { }
        public void save() { }
        public void edit() { }
        public void FillData() { }
        public void Initialize()
        {
            ClearData();
            ucDocuments.Initialize();
        }

        public void ClearData() { }
        public void Translator(string Lang) { }

        public void Export(byte[] byteArray, string FileName)
        {
            ExportFile(byteArray, FileName);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ucDocuments.ExportFile += Export;
        }
    }
}