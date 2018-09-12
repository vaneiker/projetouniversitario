using System;
using System.Text;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.CustomerCommunication
{
    public partial class UCCommCalls : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {



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
            SetPlayer();
        }

        public void FillData(String fileName, String User, String Date)
        {
            hdnAudFileName.Value = fileName;
            txtCallDate.Text = Date;
            txtCallUser.Text = User;

            FillData();
        }

        private void SetPlayer()
        {
            var fileName = hdnAudFileName.Value;

            var fileArray = fileName.Split('\\');

            var recDir = Service.RecordingsDir + fileArray[0] + "\\";
            fileName = fileArray[1];

            if (!String.IsNullOrEmpty(recDir) && !String.IsNullOrEmpty(fileName))
            {
                JMAudioTools.ConvertToMp3(recDir, Service.Mp3TempDir, fileName, true, Server.MapPath(Service.SoxFilePath));

                var sb = new StringBuilder();

                sb.Append(@"<audio id='audioCall' controls='controls' src='../../../TempFiles/Mp3/" + fileName.Replace(" ", "").Replace(".wav", ".mp3") + "' class='audioTag' type='audio/mp3'>");

                playerText.Text = sb.ToString();
            }
        }
    }
}