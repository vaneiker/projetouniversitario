using DI.UnderWriting;
using DI.UnderWriting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;
using Entity.UnderWriting.Entities;
using System.Text;

namespace WEB.NewBusiness.NewBusiness.UserControls.Requirements
{
    public class Temp
    {
        public string title { get; set; }
        public string CategoryName { get; set; }
        public long ContactId;
    }

    public partial class RequirementsContainer : UC, IUC
    {
        public IEnumerable<Entity.UnderWriting.Entities.Requirement> RequirementList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Bmarroquin 10-04-2017 Para que los controles de Compliance solo se muestren en DataReview!!
            if (ObjServices.IsDataReviewMode)
            {
                pnlDocumentosRequeridosNB.Visible = false;
            }
            else
            {
                pnlDocumentosRequeridosNB.Visible = true;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator("");

            if (ObjServices.IsReadyToReview)
            {
                pnSave.Visible = false;
            }

        }

        public void Translator(string Lang)
        {
            ltRequirements.Text = Resources.RequirementsLabel;
            btnSendToReview.Text = Resources.SendToReview.ToUpper();

            if (isChangingLang)
            {
                FillData();
            }
        }

        public void save()
        {

        }

        public void edit()
        {

        }

        public void Initialize()
        {
            ObjServices.SetValidTabRequirementForNewBusiness();
            var currentCase = Utility.serializeToJSON(ObjServices.GetCurrentCase());
            hdnCase.Value = currentCase;
            FillData();
        }

        public void ClearData()
        {
            ClearControls();
        }
        /// <summary>
        /// Requirement_Cat_Id	Requirement_Cat_Desc
        /// </summary>
        public void FillData()
        {
            var Corp_Id = this.ObjServices.Corp_Id;
            var Region_Id = this.ObjServices.Region_Id;
            var Country_Id = this.ObjServices.Country_Id;
            var Domesticreg_Id = this.ObjServices.Domesticreg_Id;
            var State_Prov_Id = this.ObjServices.State_Prov_Id;
            var City_Id = this.ObjServices.City_Id;
            var Office_Id = this.ObjServices.Office_Id;
            var Case_Seq_No = this.ObjServices.Case_Seq_No;
            var Hist_Seq_No = this.ObjServices.Hist_Seq_No;

            //Listado de categirias de requerimientos  
            /// 1	General
            /// 2	Medical
            /// 3	Financial
            /// 4	Activity/Sport
            /// 5	Ocupation Requierement

            //Listados de roles de la polizas 
            var datos = ObjServices.oRequirementManager.GetAllCategoryByContactRole(Corp_Id, Region_Id, Country_Id, Domesticreg_Id,
                                                                    State_Prov_Id, City_Id, Office_Id, Case_Seq_No, Hist_Seq_No);

            var generalDocments = (
                         from n in datos
                         where
                          n.RequirementCatId == 1 //General
                         select new Entity.UnderWriting.Entities.Requirement.CategoryByContactRole
                         {
                             Key = n.RequirementCatId.ToString(),
                             RequirementCatDesc = n.RequirementCatDesc,
                             CaseSeqNo = n.CaseSeqNo,
                             CityId = n.CityId,
                             CorpId = n.CorpId,
                             CountryId = n.CountryId,
                             DomesticregId = n.DomesticregId,
                             HistSeqNo = n.HistSeqNo,
                             OfficeId = n.OfficeId,
                             RegionId = n.RegionId,
                             RequirementCatId = n.RequirementCatId,
                             StateProvId = n.StateProvId
                         }
                      ).Distinct().ToList();

            this.LstViewGeneralDocuments.DataSource = generalDocments;
            LstViewGeneralDocuments.DataBind();

            var medical = (
                        from n in datos
                        where n.RequirementCatId == 2 //medical
                        select new Entity.UnderWriting.Entities.Requirement.CategoryByContactRole
                        {
                            Key = n.RequirementCatId.ToString(),
                            RequirementCatDesc = n.RequirementCatDesc,
                            CaseSeqNo = n.CaseSeqNo,
                            CityId = n.CityId,
                            CorpId = n.CorpId,
                            CountryId = n.CountryId,
                            DomesticregId = n.DomesticregId,
                            HistSeqNo = n.HistSeqNo,
                            OfficeId = n.OfficeId,
                            RegionId = n.RegionId,
                            RequirementCatId = n.RequirementCatId,
                            StateProvId = n.StateProvId
                        }
                     ).Distinct().ToList();

            this.LstViewMedicalRequiments.DataSource = medical;
            LstViewMedicalRequiments.DataBind();

            var Financial = (
                       from n in datos
                       where n.RequirementCatId == 3 //Financial

                       select new Entity.UnderWriting.Entities.Requirement.CategoryByContactRole
                       {
                           Key = n.RequirementCatId.ToString(),
                           RequirementCatDesc = n.RequirementCatDesc,
                           CaseSeqNo = n.CaseSeqNo,
                           CityId = n.CityId,
                           CorpId = n.CorpId,
                           CountryId = n.CountryId,
                           DomesticregId = n.DomesticregId,
                           HistSeqNo = n.HistSeqNo,
                           OfficeId = n.OfficeId,
                           RegionId = n.RegionId,
                           RequirementCatId = n.RequirementCatId,
                           StateProvId = n.StateProvId
                       }
                    ).Distinct().ToList();

            this.LstViewFinancialRequiments.DataSource = Financial;
            LstViewFinancialRequiments.DataBind();


            var ActivitySport = (
                       from n in datos
                       where (n.RequirementCatId == 4) //Activity/Sport and Ocupation Requierement
                       //i.ContactRoleTypeId == ContactRoleTypeId //esto es INDURED
                       select new Entity.UnderWriting.Entities.Requirement.CategoryByContactRole
                       {
                           Key = n.RequirementCatId.ToString() + @"|5",
                           RequirementCatDesc = n.RequirementCatDesc,
                           CaseSeqNo = n.CaseSeqNo,
                           CityId = n.CityId,
                           CorpId = n.CorpId,
                           CountryId = n.CountryId,
                           DomesticregId = n.DomesticregId,
                           HistSeqNo = n.HistSeqNo,
                           OfficeId = n.OfficeId,
                           RegionId = n.RegionId,
                           RequirementCatId = n.RequirementCatId,
                           StateProvId = n.StateProvId
                       }
                    ).Distinct().ToList();

            this.LstViewOccupationSport.DataSource = ActivitySport;
            LstViewOccupationSport.DataBind();
        }

        protected void ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var Requirements = (UCRequirements)e.Item.FindControl("UcRequirements");

                if (Requirements != null) //Bmarroquin 03-04-2017 se agrega validacion 
                {
                    Requirements.Page = this.Page;
                    Requirements.FillData(((DataList)sender).DataKeys[e.Item.ItemIndex].ToString(), false);
                }
            }
        }

        public void ReadOnlyControls(bool isReadOnly)
        {

        }

        protected void btnSendToReview_Click(object sender, EventArgs e)
        {
            var ListError = new List<Utility.Errors>();
            var ListMessage = new List<Utility.ListTabError>();

            var CountCasesError = 0;

            var Result = ObjServices.oCaseManager.SendToReview(new Case()
            {
                CorpId = ObjServices.Corp_Id,
                RegionId = ObjServices.Region_Id,
                CountryId = ObjServices.Country_Id,
                DomesticregId = ObjServices.Domesticreg_Id,
                StateProvId = ObjServices.State_Prov_Id,
                CityId = ObjServices.City_Id,
                OfficeId = ObjServices.Office_Id,
                CaseSeqNo = ObjServices.Case_Seq_No,
                HistSeqNo = ObjServices.Hist_Seq_No,
                UserId = ObjServices.UserID.Value
            });

            //Validar si se envio el caso a Listo para revisar,sino se muestran los errores del caso.
            if (!Result.Result)
            {
                CountCasesError++;

                var item = new Utility.Errors();
                var vErrors = Result.ResultMessage.Split(',');

                /*
                  1-Owner Info Tab no se ha completado
                  2-Plan/Policy Tab no se ha completado
                  3-Beneficiaries Tab no se ha completado
                  4-Requirements Tab no se ha completado
                  5-Health Declaration Tab no se ha completado
                */

                for (int x = 0; x < vErrors.Length; x++)
                {
                    switch (vErrors[x])
                    {
                        case "Client Info":
                            vErrors[x] = Resources.ClientInfoLabel;
                            break;
                        case "Owner Info":
                            vErrors[x] = Resources.OwnerInfoLabel;
                            break;
                        case "Plan/Policy":
                            vErrors[x] = Resources.PlanPolicyLabel;
                            break;
                        case "Beneficiaries":
                            vErrors[x] = Resources.BeneficiariesLabel;
                            break;
                        case "Requirements":
                            vErrors[x] = Resources.RequirementsLabel;
                            break;
                        case "Health Declaration":
                            vErrors[x] = Resources.HealthDeclarationLabel;
                            break;
                    }

                    if (ObjServices.Language == Utility.Language.en)
                        item.MessageErrorList.Add((x + 1).ToString() + "-" + vErrors[x] + " " + RESOURCE.UnderWriting.NewBussiness.Resources.TabNotCompleted);
                    else
                        item.MessageErrorList.Add((x + 1).ToString() + "-" + "El Tab de " + vErrors[x] + " " + RESOURCE.UnderWriting.NewBussiness.Resources.TabNotCompleted2);
                }

                ListError.Add(item);

                foreach (var item2 in ListError)
                {
                    var temp = new Utility.ListTabError();
                    //temp.Policy = RESOURCE.UnderWriting.NewBussiness.Resources.ErrorPolicyNumber + " \"" + item2.Policy + ":\"" + "<br/>";
                    temp.Errors = string.Join("<br/>", item2.MessageErrorList.ToArray());
                    ListMessage.Add(temp);
                }

                var Message = new StringBuilder();

                foreach (var item2 in ListMessage)
                {
                    Message.Append("<br/>");
                    Message.Append(item2.Errors);
                    Message.Append("<br/>");
                }

                this.MessageBox(Message.ToString(), Width: 500, Height: 350, Title: RESOURCE.UnderWriting.NewBussiness.Resources.ErrorInCase);

            }
            else
            {
                Response.Redirect("CasesInProcess.aspx");
            }  
        }
    }
}