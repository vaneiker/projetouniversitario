using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle
{
    public partial class UCPopupVehicleTagConditioned : UC, IUC
    {
        public int DocumentCategporyID
        {
            get { return Session["_DocumentCategporyID"].ToInt(); }
            set { Session["_DocumentCategporyID"] = value; }
        }

        public int DocumentId
        {
            get { return Session["_DocumentId"].ToInt(); }
            set { Session["_DocumentId"] = value; }
        }

        public int? FunctionalitySeqNo
        {
            get { return Session["_FunctionalitySeqNo"].ToInt(); }
            set { Session["_FunctionalitySeqNo"] = value; }
        }

        public int? FunctionalityId
        {
            get { return Session["_FunctionalityId"].ToInt(); }
            set { Session["_FunctionalityId"] = value; }
        }


        public void Translator(string Lang) { }
        public void ReadOnlyControls(bool isReadOnly) { }
        public void save() { }
        public void edit() { }
        public void FillData() { }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpdatePanel3_Unload(object sender, EventArgs e)
        {
            MethodInfo methodInfo = typeof(ScriptManager).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
           .Where(i => i.Name.Equals("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel")).First();
            methodInfo.Invoke(ScriptManager.GetCurrent(Page),
                new object[] { sender as UpdatePanel });
        }

        public void SetIframeSrcTagConditioned(string src)
        {
            IframeMarbete.Src = src;
        }

        private void DownloadPdf()
        {
            var fileName = IframeMarbete.Src.Split('/')[IframeMarbete.Src.Split('/').Length - 1];

            string FormPath = Server.MapPath("~") + @"\TempFiles\" + fileName;
            FileInfo pdf = new FileInfo(FormPath);

            if (pdf.Exists)
            {
                FileStream fs = new FileStream(FormPath, FileMode.Open);
                long fileSize = fs.Length;
                byte[] Buffer = new byte[(int)fileSize];
                fs.Read(Buffer, 0, (int)fs.Length);
                fs.Close();

                Response.Clear();
                Response.ClearHeaders();
                Response.AddHeader("Content-Type", "binary/octet-stream");

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment; filename=" + pdf.Name + "");
                Response.BinaryWrite(Buffer);
                Response.Flush();
                Response.End();
            }
        }   

        protected void btnDownloadPdf_Click(object sender, EventArgs e)
        {
            DownloadPdf();
        }       

        public void Initialize()
        {
            ClearData();
        }

        public void ClearData()
        {
            DocumentCategporyID = -1;
            DocumentId = -1;
            FunctionalitySeqNo = null;
            FunctionalityId = null;
        }
    }
}