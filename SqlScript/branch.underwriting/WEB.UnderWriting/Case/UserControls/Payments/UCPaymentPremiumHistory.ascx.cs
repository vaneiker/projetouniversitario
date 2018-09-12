using System;
using System.Web.UI.WebControls;

namespace WEB.UnderWriting.Case.UserControls.Payments
{
	public partial class UCPaymentPremiumHistory : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public void DisableLinkButton(LinkButton linkButton, string disable_class)
		{
			linkButton.CssClass = disable_class;
			linkButton.Enabled = false;
		}

		void setPagerIndex(GridView gv)
		{
			if (gv.BottomPagerRow != null)
			{
				var lnkPrev = (LinkButton)gv.BottomPagerRow.FindControl("prevButton");
				var lnkFirst = (LinkButton)gv.BottomPagerRow.FindControl("firstButton");
				var lnkNext = (LinkButton)gv.BottomPagerRow.FindControl("nextButton");
				var lnkLast = (LinkButton)gv.BottomPagerRow.FindControl("lastButton");
				var indexText = (Literal)gv.BottomPagerRow.FindControl("indexPage");
				var totalText = (Literal)gv.BottomPagerRow.FindControl("totalPage");


				var count = gv.PageCount;
				var index = gv.PageIndex + 1;

				indexText.Text = index.ToString();
				totalText.Text = count.ToString();

				if (index == 1)
				{
					DisableLinkButton(lnkPrev, "prev_dis");
					DisableLinkButton(lnkFirst, "rewd_dis");
				}
				else if (index == count)
				{
					DisableLinkButton(lnkNext, "next_dis");
					DisableLinkButton(lnkLast, "fwrd_dis");
				}
			}
		}

		public void FillData()
		{
			var data = new System.Data.DataTable("Avocations");
			//data.Columns.Add("TypeOfAvocationId", typeof(Int32));
			//data.Columns.Add("TypeOfAvocationDesc", typeof(String));
			//data.Columns.Add("YearsOfExperience", typeof(Int32));
			//data.Columns.Add("Licence", typeof(String));
			//data.Columns.Add("AvocationFactor", typeof(String));
			//data.Columns.Add("Detail", typeof(String));

			gvPaymentsHistory.DataSource = data;
			gvPaymentsHistory.DataBind();

			setPagerIndex(gvPaymentsHistory);

			if (gvPaymentsHistory.BottomPagerRow != null)
			{
				var totalItems = (Literal)gvPaymentsHistory.BottomPagerRow.FindControl("totalItems");
				totalItems.Text = data.Rows.Count + ""; //data.ToList().Count + "";
			}
		}

		protected void gvPaymentsHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gvPaymentsHistory.PageIndex = e.NewPageIndex;
			gvPaymentsHistory.DataBind();
			FillData();
			setPagerIndex(gvPaymentsHistory);
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
	}
}