using CollectorsModule.ell;
using Statetrust.Framework.Web.WebParts.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollectorsModule.Pages
{
    public partial class ProcessPayments : STFMainPage
    {
        public string ContactId
        {
            get
            {
                return (string)Session["Contact_Id"];
            }

            set
            {
                Session["Contact_Id"] = value;
            }
        }
        public string ActiveView
        {
            get
            {
                return (string)Session["ActiveView"];
            }

            set
            {
                Session["ActiveView"] = value;
            }
        }
        public bool setStep1
        {
            set
            {
                string status = (value) ? "box_btn activo" : "box_btn";
                this.step1.Attributes.Add("class", status);
            }
        }
        public bool setStep2
        {
            set
            {
                string status = (value) ? "box_btn activo" : "box_btn";
                this.step1.Attributes.Remove("class");
                this.step2.Attributes.Remove("class");
                this.step1.Attributes.Add("class", "box_btn activo_ck");
                this.step2.Attributes.Add("class", status);
            }
        }
        public bool setStep3
        {
            set
            {
                string status = (value) ? "box_btn activo" : "box_btn";
                this.step1.Attributes.Remove("class");
                this.step2.Attributes.Remove("class");
                this.step3.Attributes.Remove("class");
                this.step1.Attributes.Add("class", "box_btn activo_ck");
                this.step2.Attributes.Add("class", "box_btn activo_ck");
                this.step3.Attributes.Add("class", status);
            }
        }
        public bool resetPayment { get {
            var r = ucPaymentMethod.resetPayment;
            return true;
        } }
        public bool setGrid
        {
            get
            {

                return ucPaymentConfirmation.setGrid;
            }
        }
        public List<Payment> dopPayments
        {
            get
            {
                return (List<Payment>)Session["dopPayments"] ?? new List<Payment>();
            }
            set
            {
                Session["dopPayments"] = value;
            }
        }
        public List<Payment> usdPayments
        {
            get
            {
                return (List<Payment>)Session["usdPayments"] ?? new List<Payment>();
            }
            set
            {
                Session["usdPayments"] = value;
            }
        }
        public string paymentForm
        {
            get
            {
                return (ucPaymentConfirmation.paymentForm).ToString();
            }
            set
            {
                ucPaymentConfirmation.paymentForm = value;
            }
        }
        public List<Payment> paymentsList
        {
            get
            {
                return (this.Page as Pages.ProcessPayments).dopPayments.Union((this.Page as Pages.ProcessPayments).usdPayments).ToList();
            }
            set
            {
                ucPaymentConfirmation.paymentsList = value;
            }
        }
        public string amountToBePaid
        {
            get
            {
                return (Session["AmountToPay"] ?? "$0.00").ToString();
            }
            set
            {
                Session["AmountToPay"] = value;
                ucPaymentMethod.amountToBePaid = value;
            }
        }

        public void clearUCClients()
        {
            ucClientSearch.clearGridClients();
            ucClientSearch.initGrid = true;
            ucClientSearch.initializeGrid();
            Response.Redirect("ProcessPayments.aspx", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsCallback && !IsPostBack)
                setActiveView(1);
            if (this.ActiveView != "3" && (this.Page as Pages.ProcessPayments).getActiveView() != "vwPaymentMethod")
            {
                this.dopPayments = null;
                this.usdPayments = null;
            }
        }

        public void setActiveView(int view)
        {
            switch (view)
            {
                case 1:
                    this.mvContentTabs.SetActiveView(vwSearchClient);
                    ucClientSearch.resetGrid();
                    this.lnkStep3.OnClientClick = this.lnkStep1.OnClientClick = "return false;";
                    if (getActiveView() == "vwSearchClient")
                    {
                        this.lnkStep2.OnClientClick = string.Empty; ;
                    }
                    this.paymentsList.Clear();
                    break;
                case 2:
                    this.mvContentTabs.SetActiveView(vwPoliciesPayments);
                    ucSetPoliciesPayments.getPolicies();
                    this.lnkStep2.OnClientClick = "return false;";
                    this.lnkStep1.OnClientClick = "if (!UserBackConfirmation()) return false;";
                    if (getActiveView() == "vwPoliciesPayments")
                        this.lnkStep3.OnClientClick = string.Empty;
                    break;
                case 3:
                    this.mvContentTabs.SetActiveView(vwPaymentMethod);
                    this.lnkStep2.OnClientClick = this.lnkStep1.OnClientClick = "if (!UserBackConfirmation()) return false;";
                    this.lnkStep3.OnClientClick = string.Empty;
                    break;
                case 4:
                    this.mvContentTabs.SetActiveView(vwPaymentConfirmation);
                    if (this.dopPayments != null && this.dopPayments.Count() > 0)
                        this.paymentsList = dopPayments;
                    else
                        this.paymentsList = usdPayments;
                    this.setStep3 = true;
                    this.lnkStep2.OnClientClick = this.lnkStep3.OnClientClick = "return false;";
                    this.lnkStep1.OnClientClick = "if (!UserBackConfirmation()) return false;";
                    break;
                default:
                    this.mvContentTabs.SetActiveView(vwSearchClient);
                    this.lnkStep3.OnClientClick = this.lnkStep1.OnClientClick = "return false;";
                    this.lnkStep2.OnClientClick = "if (!UserBackConfirmation()) return false;";
                    break;
            }
        }

        public string getActiveView()
        {
            return this.mvContentTabs.GetActiveView().ID;
        }

        protected void lnkStep1_Click(object sender, EventArgs e)
        {
            if (getActiveView() != "vwSearchClient")
            {
                bool c = this.ucPaymentConfirmation.backStep;
                bool b = this.ucPaymentMethod.backStep;
                bool a = this.ucSetPoliciesPayments.backStep;
            }
        }

        protected void lnkStep2_Click(object sender, EventArgs e)
        {
            if (getActiveView() == "vwSearchClient")
            {
                var r = this.ucClientSearch.forwardStep;
            }
            else
            {
                bool c = this.ucPaymentConfirmation.backStep;
                bool b = this.ucPaymentMethod.backStep;
            }
        }

        protected void lnkStep3_Click(object sender, EventArgs e)
        {
            if (getActiveView() == "vwPoliciesPayments")
            {
                var r = this.ucSetPoliciesPayments.forwardStep;
            }
        }
    }
}