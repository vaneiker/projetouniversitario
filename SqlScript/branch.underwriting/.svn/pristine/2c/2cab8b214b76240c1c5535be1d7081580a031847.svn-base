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
using DI.UnderWriting.Implementations;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle
{
    public partial class UCHsuplementos : UC, IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {

        
            var listadosuplementos = ObjServices.oHealthManager.GetPolicyMemberCoveragePremium(new Health.Policy.Member.CoveragePremium(){
               CorpId = ObjServices.Corp_Id,
               RegionId = ObjServices.Region_Id,
               CountryId = ObjServices.Country_Id,
               DomesticRegId = ObjServices.Domesticreg_Id,
               StateProvId = ObjServices.State_Prov_Id,
               CityId = ObjServices.City_Id,
               OfficeId = ObjServices.Office_Id,
               CaseSeqNo = ObjServices.Case_Seq_No,
               HistSeqNo = ObjServices.Hist_Seq_No

            }).ToList();



            Console.Write(listadosuplementos);

            BindGrid(listadosuplementos);
        }

        public void BindGrid(List<Health.Policy.Member.CoveragePremium> listadosuplementos) { 
            try{
          suplementosrow.DataSource = listadosuplementos.Select(o => new
                {
                 tiposuplemento = o.CoverageDesc,
                   Asegurado = o.ContactFirstName + " " + o.ContactLastName,
                   Producto = o.BenefitPlanDesc,
                  Cobertura = o.InsuredAmount.ToFormatCurrency(),
                  Prima = o.PremiumAmount.ToFormatCurrency()
                 // selectedPlan = o.Be
                });
            }catch(Exception e){
                 Console.Write(e);
            }

            Total.Text = listadosuplementos.Sum(o => o.PremiumAmount).ToDecimal().ToFormatCurrency();

            suplementosrow.DataBind();
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