using System;
using System.Web.UI;
using Statetrust.Framework.Core.Util;

namespace WEB.NewBusiness
{
    public partial class STFConvertImageBase64 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         if (Request.Files.Count <= 0) return;
            var file = Request.Files[0];
            Response.Clear();
            Response.Write("data:image/png;base64," + Convert.ToBase64String(Utility.ConvertStreamToByteBuffer(file.InputStream)));
            Response.Flush();
            Response.End();
        }
    }
}