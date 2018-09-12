using Entity.UnderWriting.Entities;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;


namespace WEB.NewBusiness.NewBusiness.UserControls.VehicleInspectionForm
{
    public partial class VerificacionInformacionesGenerales : UC, IUC
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            FillData();
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
            string VehicleUniqueId = Session["VehicleUniqueId"] != null ? Convert.ToString(Session["VehicleUniqueId"]) : string.Empty;

            var elements = ObjServices.GettingDropData(Utility.DropDownType.GIV,
                                                       corpId: ObjServices.Corp_Id,
                                                       NameKey: VehicleUniqueId);
            if (elements != null)
            {
                foreach (var control in this.Controls)
                {
                    if (control is RadioButton)
                    {
                        RadioButton rb = ((RadioButton)control);
                        var options = elements.Where(c => c.Namekey == rb.GroupName &&
                                                          c.BloodTypeId.GetValueOrDefault() == Convert.ToInt32(rb.Attributes["ItemId"]));
                        foreach (var option in options)
                        {
                            rb.InputAttributes.Add("data-review-item-id", option.BloodTypeId.GetValueOrDefault().ToString());
                            rb.InputAttributes.Add("data-review-class-desc", option.Namekey);
                            rb.InputAttributes.Add("data-review-option-desc", Convert.ToString(rb.Attributes["OptionDesc"]));
                        }
                    }
                }
            }
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }
    }
}