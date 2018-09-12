using Entity.UnderWriting.Entities;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.VehicleInspectionForm
{
    public partial class VerificacionPartesFisicas : UC, IUC
    {
        public static bool Enabled { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
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
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            var options = ObjServices.oVehicleManager.GetVehicleReviewItemOption(new Vehicle.Review
            {
                CorpId = ObjServices.Corp_Id,
                LanguageId = ObjServices.Language.ToInt(),
                ReviewGroupId = null
            }).Select(o => new Vehicle.InspectionForm.Option
            {
                ClassDesc = o.ClassDesc,
                ClassId = o.ClassId.Value,
                GroupDesc = o.GroupDesc,
                GroupId = o.GroupId,
                ItemDesc = o.ItemDesc,
                ItemId = o.ItemId != null ? o.ItemId.Value : -1,
                OptionDesc = o.OptionDesc,
                OptionId = o.OptionId != null ? o.OptionId.Value : -1
            }).Where(c => c.GroupId.GetValueOrDefault().Equals(Utility.ReviewGroups.VerificarPartesFisicasVehiculo.ToInt())).ToList();

            if (options.Count > 0)
            {
                foreach (var option in options)
                {
                    foreach (var control in this.Controls)
                    {
                        if (control is Label)
                        {
                            Label lbl = control as Label;

                            int? ItemId = Convert.ToInt32(lbl.Attributes["ItemId"]);

                            string ClassDesc = Convert.ToString(lbl.Attributes["ClassDesc"]);

                            if (ItemId == option.ItemId && ClassDesc == option.ClassDesc)
                            {
                                lbl.Text = HttpUtility.HtmlDecode(option.ItemDesc);
                            }
                        }

                        if (control is RadioButton)
                        {
                            RadioButton rb = control as RadioButton;

                            int? ItemId = Convert.ToInt32(rb.Attributes["ItemId"]);

                            string OptionDesc = Convert.ToString(rb.Attributes["OptionDesc"]),
                                   ClassDesc = Convert.ToString(rb.Attributes["ClassDesc"]);

                            if (ItemId == option.ItemId && OptionDesc == option.OptionDesc && ClassDesc == option.ClassDesc)
                            {
                                rb.InputAttributes.Add("data-review-group-id", option.GroupId.GetValueOrDefault().ToString());
                                rb.InputAttributes.Add("data-review-class-id", option.ClassId.GetValueOrDefault().ToString());
                                rb.InputAttributes.Add("data-review-item-id", option.ItemId.GetValueOrDefault().ToString());
                                rb.InputAttributes.Add("data-review-option-id", option.OptionId.GetValueOrDefault().ToString());
                                rb.InputAttributes.Add("data-review-option-desc", option.OptionDesc);
                                rb.InputAttributes.Add("data-review-class-desc", option.ClassDesc);
                            }
                        }
                    }
                }
            }
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }
    }
}