using DevExpress.Web.ASPxScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.NewBusiness.NewBusiness.UserControls.Contact.CallAndVisits
{
    public partial class WUCCallAndVisits : System.Web.UI.UserControl
    {

        CustomEventDataSource objectInstance;

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        CustomEventList GetCustomEvents()
        {
            CustomEventList events = Session["CustomEventListData"] as CustomEventList;
            if (events == null)
            {
                events = new CustomEventList();
                Session["CustomEventListData"] = events;
            }
            return events;
        }

        protected void appointmentsDataSource_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
        {
            this.objectInstance = new CustomEventDataSource(GetCustomEvents());
            e.ObjectInstance = this.objectInstance;
        }

        protected void ASPxScheduler1_AppointmentRowInserted(object sender, ASPxSchedulerDataInsertedEventArgs e)
        {
            e.KeyFieldValue = this.objectInstance.ObtainLastInsertedId();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

    }
}