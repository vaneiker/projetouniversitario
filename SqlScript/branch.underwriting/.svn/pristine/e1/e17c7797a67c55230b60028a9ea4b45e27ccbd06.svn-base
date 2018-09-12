using System;
using System.IO;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.PolicyPlanData
{
    public partial class UCTerminateExclusion : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        //UnderWritingDIManager diManager = new UnderWritingDIManager();

        //IPolicy PolicyManager
        //{
        //    get { return diManager.PolicyManager; }
        //}

        private string TempFilePath
        {
            get { return Server.MapPath("~/TempFiles"); }
        }

        bool IsAditionalInsured
        {
            get { return !string.IsNullOrWhiteSpace(hdnIsAditional.Value) && bool.Parse(hdnIsAditional.Value); }
            set { hdnIsAditional.Value = value.ToString(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }


        public void FillTerminanteExclusionData(String RiskId, String SequenceReference, String UnderWriterName, String Comment,Boolean IsAditional)
        {

            hdnRiskId.Value = RiskId.ToString();
            hdnSequenceReference.Value = SequenceReference;
            hdnUnderwriterName.Value = UnderWriterName;
            hdnStoreComment.Value = Comment;
            IsAditionalInsured = IsAditional;
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {

            
         Entity.UnderWriting.Entities.Policy.RiskRating exclusion = new Entity.UnderWriting.Entities.Policy.RiskRating();
         exclusion.NotificationDate = DateTime.Parse(txtNotificationDateTerminateExclusion.Text);
            exclusion.EndDate = DateTime.Parse(txtEndDateTerminateExclusion.Text);
            exclusion.UserId = Service.Underwriter_Id;
            exclusion.CorpId = Service.Corp_Id;
            exclusion.SequenceReference = hdnSequenceReference.Value;
            exclusion.RiskId =int.Parse(hdnRiskId.Value);
            exclusion.UnderwriterName = hdnUnderwriterName.Value;
            exclusion.Comment = hdnStoreComment.Value + Environment.NewLine + Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy  hh:mm tt") + Environment.NewLine + hdnUnderwriterName.Value +Environment.NewLine+ txtTerminateExclusionComment.Text;
            
      //     exclusion.DocumentBinary
            var terminateExclusionPath = hdnTerminateExclusionPdfPath.Value;
            if (!String.IsNullOrEmpty(terminateExclusionPath))
            {
                exclusion.DocumentBinary = File.ReadAllBytes(terminateExclusionPath);
            }

            txtEndDateTerminateExclusion.Text = "";
            txtNotificationDateTerminateExclusion.Text = "";
            txtTerminateExclusionComment.Text = "";

            Services.PolicyManager.TerminateExclusion(exclusion);
            ((UCPolicyPlanDataContainer)this.Parent.Parent).FillExclusionData(IsAditionalInsured);


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

        public void FillData()
        {
            throw new NotImplementedException();
        }

        protected void fuTerminateExclusionFile_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
                var file = e.UploadedFile;
            if (!file.IsValid) return;
            var fileName = Tools.GetSerialId() + "~~" + file.FileName;
            var savePath = TempFilePath + "\\" + fileName;
            file.SaveAs(savePath);
            e.CallbackData = savePath;
        }
    }
}