using DI.UnderWriting;
using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.Pages
{
    public partial class AlliedLinesRiskInspectionForm : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UCInspectionForm1.ClearData();
                UCInspectionForm1.Initialize();
                UCInspectionForm1.FillData();
            }
        }
    }
}