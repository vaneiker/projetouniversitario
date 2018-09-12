using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Entity.UnderWriting.Entities;
using WEB.NewBusiness.Common;
using WEB.NewBusiness.Common.Illustration.IllustrationVehicle.Models;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle
{
    public partial class UCWorkflow : UC, IUC
    {
        private string IllustrationStatusCode
        {
            get
            {
                return ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).IllustrationStatusCode;
            }
        }

        private List<Policy.VehicleInsured> ListVehicles
        {
            get
            {
                return ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ListVehicles;
            }
        }

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
            var completeCssClass = "bg_grd_vd";
            var currentCssClass = "activo";
            pnlApprovedByClient.CssClass =
            pnlIncompleteIllustration.CssClass = "box_btn inactive cursorpointer";
            pnlCompleteIllustration.CssClass =
            pnlApprovedBySubscription.CssClass =
            pnlSubscription.CssClass = "box_btn inactive cursorpointer box_btn_head";
            pnlDeclinedByClient.CssClass =
            pnlDocumens.CssClass =
            pnlInspection.CssClass =
            pnlExpired.CssClass =
            pnlDeclinedBySubcription.CssClass = "box_btn inactive cursorpointer box_down";

            if (IllustrationStatusCode == Utility.IllustrationStatus.Incomplete.Code() || IllustrationStatusCode == Utility.IllustrationStatus.New.Code())
                SetCurrentStatusClass(pnlIncompleteIllustration, currentCssClass);
            else if (IllustrationStatusCode == Utility.IllustrationStatus.NewPlan.Code())
            {
                SetCurrentStatusClass(pnlIncompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlCompleteIllustration, currentCssClass);
            }
            else if (IllustrationStatusCode == Utility.IllustrationStatus.DeclinedByClient.Code())
            {
                SetCurrentStatusClass(pnlIncompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlCompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlDeclinedByClient, currentCssClass);
            }
            else if (IllustrationStatusCode == Utility.IllustrationStatus.ApprovedByClient.Code())
            {
                SetCurrentStatusClass(pnlIncompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlCompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlApprovedByClient, currentCssClass);
            }
            else if (IllustrationStatusCode == Utility.IllustrationStatus.Subscription.Code())
            {
                SetCurrentStatusClass(pnlIncompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlCompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlApprovedByClient, completeCssClass);
                SetCurrentStatusClass(pnlSubscription, currentCssClass);
            }
            else if (IllustrationStatusCode == Utility.IllustrationStatus.DeclinedBySubscription.Code())
            {
                SetCurrentStatusClass(pnlIncompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlCompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlApprovedByClient, completeCssClass);
                SetCurrentStatusClass(pnlSubscription, completeCssClass);
                SetCurrentStatusClass(pnlDeclinedBySubcription, currentCssClass);
            }
            else if (IllustrationStatusCode == Utility.IllustrationStatus.ApprovedBySubscription.Code())
            {
                SetCurrentStatusClass(pnlIncompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlCompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlApprovedByClient, completeCssClass);
                SetCurrentStatusClass(pnlSubscription, completeCssClass);
                SetCurrentStatusClass(pnlApprovedBySubscription, currentCssClass);
            }
            else if (IllustrationStatusCode == Utility.IllustrationStatus.TimeExpired.Code())
            {
                SetCurrentStatusClass(pnlExpired, completeCssClass);
            }

            else if (IllustrationStatusCode == Utility.IllustrationStatus.MissingDocuments.Code())
            {
                SetCurrentStatusClass(pnlIncompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlCompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlApprovedByClient, completeCssClass);
                SetCurrentStatusClass(pnlSubscription, completeCssClass);

                SetCurrentStatusClass(pnlDocumens, currentCssClass);
            }
            else if (IllustrationStatusCode == Utility.IllustrationStatus.MissingInspection.Code())
            {
                SetCurrentStatusClass(pnlIncompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlCompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlApprovedByClient, completeCssClass);
                SetCurrentStatusClass(pnlSubscription, completeCssClass);

                SetCurrentStatusClass(pnlInspection, currentCssClass);
            }
            else
            {
                SetCurrentStatusClass(pnlIncompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlCompleteIllustration, completeCssClass);
                SetCurrentStatusClass(pnlApprovedByClient, completeCssClass);
                SetCurrentStatusClass(pnlSubscription, completeCssClass);
                SetCurrentStatusClass(pnlApprovedBySubscription, completeCssClass);
            }

            //var lstDocuments = ListDocuments;

            //if (lstDocuments.All(o => o.Status))
            //    SetCurrentStatusClass(pnlDocumens, completeCssClass);
            //else if (lstDocuments.Any(o => o.Status))
            //    SetCurrentStatusClass(pnlDocumens, currentCssClass);

            //var lstVehicles = ListVehicles;

            //if (lstVehicles.All(o => o.Inspection.GetValueOrDefault() || o.YearVehicle.GetValueOrDefault() >= DateTime.Now.Year))
            //    SetCurrentStatusClass(pnlInspection, completeCssClass);
            //else if (lstVehicles.Any(o => o.Inspection.GetValueOrDefault() && o.YearVehicle.GetValueOrDefault() < DateTime.Now.Year))
            //    SetCurrentStatusClass(pnlInspection, currentCssClass);
        }

        private void SetCurrentStatusClass(WebControl control, string toClass)
        {
            var inactiveCssClass = "inactive";
            control.CssClass = control.CssClass.Replace(inactiveCssClass, toClass);
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