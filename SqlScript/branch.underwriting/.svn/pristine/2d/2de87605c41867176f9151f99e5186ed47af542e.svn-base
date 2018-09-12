using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity.UnderWriting.IllusData;
using WEB.NewBusiness.Common;
using Entity.UnderWriting.Entities;
using iTextSharp.text.pdf;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle
{
    public partial class UCHdependientes : UC, IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

        }

        public void Initialize()
        {

            throw new NotImplementedException();
        }

        public string BenefitPlanDesc
        {
            get
            {
                var value = Session["BenefitPlanDesc"];
                return value == null ? null : (string)value;
            }
        }

        public List<Policy.Contact> ListDependientes
        {
            get
            {
                var val = ViewState["ListDependientes"];
                if (val != null)
                {
                    var x = val.ToString().FromJsonToObject<Policy.Contact>();
                }
                return val == null ? new List<Policy.Contact>() : val.ToString().FromJsonToObject<List<Policy.Contact>>();

            }
            private set
            {
                ViewState["ListDependientes"] = value.ToJSON();
            }
        }

        public bool EnableTag
        {
            get
            {
                return ViewState["EnableTag"].ToBoolean();
            }
            private set
            {
                ViewState["EnableTag"] = value;
            }
        }

        public void FillData()
        {
            List<Policy.Contact> listado = ObjServices.oPolicyManager.GetContactPolicy(
                ObjServices.Corp_Id,
                ObjServices.Region_Id,
                ObjServices.Country_Id,
                ObjServices.Domesticreg_Id,
                ObjServices.State_Prov_Id,
                ObjServices.City_Id,
                ObjServices.Office_Id,
                ObjServices.Case_Seq_No,
                ObjServices.Hist_Seq_No,
                null,
                null
        ).ToList();

            EnableTag = true;
            ListDependientes = listado;
            BindGrid(listado);
        }

        protected void BindGrid(List<Policy.Contact> contactos)
        {
            try
            {
                var data = contactos.OrderBy(o => o.FirstName).Select(o => new
                {
                    Nombre = o.FirstName + "" + o.MiddleName,
                    Apellido = o.FirstLastName + "" + o.SecondLastName,
                    Id = o.Id,
                    Dob = o.Dob.Value.ToString("dd-MMM-yyyy").ToUpper(),
                    RelationshipDesc = o.RelationshiptoOwnerDesc == null ? "No especifica" : o.RelationshiptoOwnerDesc,
                    FullTimeStudent = o.HealthFullTimeStudent == true ? "si" : "no",
                    BenefitPlanDesc = this.BenefitPlanDesc
                });

                if (data != null)
                {
                    dependientesrow.DataSource = data;
                    dependientesrow.DataBind();
                }
            }
            catch (Exception e)
            {

            }
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

        public void ClearData()
        {
            throw new NotImplementedException();
        }

    }
}