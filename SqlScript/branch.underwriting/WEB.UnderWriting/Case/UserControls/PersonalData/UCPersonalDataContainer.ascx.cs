using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.PersonalData
{
    public partial class PersonalDataContainer : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }
        public void GetPdf(int DocumentCategoryId, int DocumentTypeId, int DocumentId)
        {
            var SummaryRoleDDL = (DropDownList)Page.Master.FindControl("Left").FindControl("Left").FindControl("SummaryRoleDDL");

            var Document = Services.PolicyManager.GetIdCopyRequirement(new Requirement
            {
                CorpId = Service.Corp_Id,
                RegionId = Service.Region_Id,
                CountryId = Service.Country_Id,
                DomesticregId = Service.Domesticreg_Id,
                StateProvId = Service.State_Prov_Id,
                CityId = Service.City_Id,
                OfficeId = Service.Office_Id,
                CaseSeqNo = Service.Case_Seq_No,
                HistSeqNo = Service.Hist_Seq_No,
                ContactId = int.Parse(SummaryRoleDDL.SelectedValue.Split('|')[0])
            });

            Requirement.Document ContactIdentficationDocument = Services.RequirementManager.GetDocument(
            Document.CorpId, Document.RegionId, Document.CountryId, Document.DomesticregId, Document.StateProvId, Document.CityId, Document.OfficeId, Document.CaseSeqNo, Document.HistSeqNo, Document.ContactId, Document.RequirementCatId, Document.RequirementTypeId, Document.RequirementId, Document.RequirementDocId);
            UCPersonalData1.FillPdfSummary(ContactIdentficationDocument);

        }
        public void save()
        {
            UCCompliance1.save();
            UCPersonalData1.save();
            //UCClaims1.save();
        }

        public void readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void FillData(Contact contact = null, bool fillRoles = true)
        {
            var Contact = fillRoles ? UCPersonalData1.FillRolesDdl() : contact;

            UCPersonalData1.FillData(Contact);
            UCAddresses1.FillData(Contact.Addresses);
            UCEmailPhone1.FillData(Contact);
            UCWork1.FillData(Contact);
            UCClaims1.FillData(Contact);
            UCBackgroundCheck1.FillData();
            UCCompliance1.FillData();
            UCCompliance1.FillData(Contact);
            UCTransunion.CheckScoreAvailable();

            /*
            var datos = Services.RequirementManager.GetAllCategoryByContactRole(Service.Corp_Id, Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id,
                                                                    Service.State_Prov_Id, Service.City_Id, Service.Office_Id, Service.Case_Seq_No, Service.Hist_Seq_No);
            //Bmarroquin 03-04-2017 mejora por el tema de la incorporacion de Compliance
            var Compliance = (
             from n in datos
             where (n.RequirementCatId == 7)
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
          */

            //UCCompliance1.FillData()
            //this.dtlisCompliance.DataSource = Compliance;
            //dtlisCompliance.DataBind();
        }

        protected void ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Bmarroquin 03-04-2017 mejora por el tema de la incorporacion de Compliance
                var UcCompliance = (UCCompliance)e.Item.FindControl("UCCompliance1");

                if (UcCompliance != null)
                {
                    UcCompliance.Page = this.Page;
                    //Comento xq al realizar PostBack se estaba volviendo a cargar el DataSource
                    //UcCompliance.FillData(((DataList)sender).DataKeys[e.Item.ItemIndex].ToString());
                }
                //Fin Bmarroquin 03-04-2017

            }
        }

        public void FillData()
        {

        }

        public void clearData()
        {
            UCPersonalData1.clearData();
        }

        //Bmarroquin 03-04-2017 mejora por el tema de la incorporacion de Compliance, se crea metodo
        public void ValidateComplianceContacs(bool pBol_FillInitData = true)
        {
            bool lBnl_DejarPasarTab = true;
            string lStr_Mesj = string.Empty, lStr_StatusComplianc = string.Empty;
            int lInt_CountMatch, lInt_CountPosibleMatch, lInt_CountNOTMatch, lInt_CountNotFoundOrError;
            List<Entity.UnderWriting.Entities.Requirement.Compliance> lListObjsCompliance = new List<Entity.UnderWriting.Entities.Requirement.Compliance>();
            Entity.UnderWriting.Entities.Requirement.Compliance lObjCompliance;

            lInt_CountNotFoundOrError = lInt_CountMatch = lInt_CountPosibleMatch = lInt_CountNOTMatch = 0;
            /*
            //Primero recorrer los item del DataLists
            foreach (DataListItem lObj_Item in dtlisCompliance.Items)
            {
                var UcCompliance = (UCCompliance)lObj_Item.FindControl("WUCompliance"); //Encontrar el userControl de Compliance
                if (UcCompliance != null)
                {
                    if (pBol_FillInitData)
                        //Fill Data to gridView
                        UcCompliance.FillData("DummyText");

                    //Encontrar el gridView DevExpress dentro del control
                    var GridComplianceData = (DevExpress.Web.ASPxGridView)UcCompliance.FindControl("GridComplianceData");
                    if (GridComplianceData != null)
                    {
                        wsSearchXpert.SearchClient lObj_BlackListService = new wsSearchXpert.SearchClient();
                        wsSearchXpert.SearchRequest lObjSearchRequest = new wsSearchXpert.SearchRequest();
                        wsSearchXpert.ResultsSearchResponse lObjSearchResponse = new wsSearchXpert.ResultsSearchResponse();
                        wsSearchXpert.Fields[] lArr_ObjFields = new wsSearchXpert.Fields[2];//new wsSearchXpert.Fields[GridComplianceData.VisibleRowCount - 1]; /Este cuando sea una lista que se envie al servicio...
                        List<wsSearchXpert.ContactInformation> lListContacInfo = new List<wsSearchXpert.ContactInformation>();
                        wsSearchXpert.ContactInformation lObjContacInfo;

                        //** Asignando valores al object Request 
                        lObjSearchRequest.Agency = "Pruebas"; //Cambiara 
                        lObjSearchRequest.CompanyKey = new wsSearchXpert.CompanyKey() { Company_Id = Service.CompanyId, Corp_Id = Service.Corp_Id, Country_Id = Service.Country_Id, Region_Id = Service.Region_Id };
                        lObjSearchRequest.Source = wsSearchXpert.SearchResultCores.GLOBAL;
                        lObjSearchRequest.Status = wsSearchXpert.SearchResultStatus.Deleted; //Pongo esto xq al consumir el servicio da error xq el Object Requets se trata de serializar con el Enum de Status con valor cero 

                        ///Recorrer los valores del gridView
                        for (int i = 0; i <= GridComplianceData.VisibleRowCount - 1; i++)
                        {
                            var lInt_ContactID = GridComplianceData.GetRowValues(i, "ContactId"); //Recuperar el Contact Id de los contactos
                            var lStr_NombreContacto = GridComplianceData.GetRowValues(i, "ClientName"); //Recuperar el full name de los contactos
                            var lStr_NombreRol = GridComplianceData.GetRowValues(i, "Nombre_Rol");
                            var lDt_Dob = GridComplianceData.GetRowValues(i, "Dob");
                            var lStr_Identificacion = GridComplianceData.GetRowValues(i, "Identificacion");
                            var lStr_TypeIdentificacion = GridComplianceData.GetRowValues(i, "TipoIdentificacion");
                            var lStr_Address = GridComplianceData.GetRowValues(i, "Address");
                            var lStr_CountryOfBirth = GridComplianceData.GetRowValues(i, "CountryOfBirth");
                            var lStr_DUI = GridComplianceData.GetRowValues(i, "DUI");
                            var lStr_NIT = GridComplianceData.GetRowValues(i, "NIT");

                            wsSearchXpert.Fields lObjUnitField = new wsSearchXpert.Fields();
                            lObjUnitField.Display = true;
                            lObjUnitField.Name = "Name";
                            lObjUnitField.Value = lStr_NombreContacto.ToString();
                            lObjUnitField.Type = "Name";
                            lObjUnitField.SearchType = wsSearchXpert.SearchResultTypes.Name;

                            wsSearchXpert.Fields lObjUnitField2 = new wsSearchXpert.Fields();
                            lObjUnitField2.CoreKey = true;
                            lObjUnitField2.Display = true;
                            lObjUnitField2.Name = "Source_Id";
                            lObjUnitField2.Value = lInt_ContactID.ToString();
                            lObjUnitField2.Type = "Name";
                            lObjUnitField2.SearchType = wsSearchXpert.SearchResultTypes.Name;

                            //lArr_ObjFields[i] = lObjUnitField; //Cuando sea Masivo
                            lArr_ObjFields[0] = lObjUnitField;
                            lArr_ObjFields[1] = lObjUnitField2;

                            //Este codigo hay que sacarlo del For, para que se pueda mandar una lista 
                            lObjSearchRequest.RequestFields = lArr_ObjFields;
                            lObjSearchResponse = lObj_BlackListService.SearchOnline(lObjSearchRequest);

                            //GridComplianceData.FindEditRowCellTemplateControl()

                            //Esto hay que cambiar cuando el response devuelva el result de N contactos...
                            switch (lObjSearchResponse.Statusk__BackingField)
                            {
                                case wsSearchXpert.SearchResultStatus.NotMatch:
                                    lInt_CountNOTMatch += 1;
                                    lStr_StatusComplianc = Resources.lblStatusNotMatch;// "Not Match";
                                    break;
                                case wsSearchXpert.SearchResultStatus.PossibleMatch:
                                    lStr_Mesj += "El contacto " + lStr_NombreContacto + " tiene un status de Possible Match";
                                    lInt_CountPosibleMatch += 1;
                                    lStr_StatusComplianc = Resources.lblStatusPossibleMatch;// "Possible Match";

                                    lObjContacInfo = new wsSearchXpert.ContactInformation();
                                    //Campos para el envio de la notificacion para Compliance
                                    lObjContacInfo.FullName = lStr_NombreContacto.ToString();
                                    lObjContacInfo.SourceID = lInt_ContactID.ToString();
                                    lObjContacInfo.Address = lStr_Address != null ? lStr_Address.ToString() : "";
                                    lObjContacInfo.DateOfBirth = lDt_Dob != null ? DateTime.Parse(lDt_Dob.ToString()) : (DateTime?)null;
                                    lObjContacInfo.IdentificationNumber = lStr_DUI != null ? lStr_DUI.ToString() : "";
                                    lObjContacInfo.ResidenceCountry = lStr_CountryOfBirth != null ? lStr_CountryOfBirth.ToString() : "";
                                    lObjContacInfo.Status = wsSearchXpert.SearchResultStatus.Deleted; //Valor x Defecto...No se le hace caso del lado de BlackList
                                    lObjContacInfo.TaxID = lStr_NIT != null ? lStr_NIT.ToString() : "";
                                    lObjContacInfo.DateProcessed = DateTime.Now;
                                    lObjContacInfo.Department = "Suscripcion Vida";
                                    lObjContacInfo.SearchID = null;
                                    lObjContacInfo.Source = wsSearchXpert.SearchResultCores.GLOBAL;
                                    //lObjContacInfo.UserName = ObjServices.UserFullName;
                                    //Fin Campos para Notificacion 
                                    lListContacInfo.Add(lObjContacInfo);//Add to the List of ContactInfo
                                    lObjContacInfo = null;
                                    break;
                                case wsSearchXpert.SearchResultStatus.Match:
                                    lStr_Mesj += "El contacto " + lStr_NombreContacto + " tiene un status de Match";
                                    lInt_CountMatch += 1;
                                    lStr_StatusComplianc = Resources.lblStatusMatch;// "Match";
                                    break;
                                case wsSearchXpert.SearchResultStatus.Deleted:
                                    break;
                                case wsSearchXpert.SearchResultStatus.NotFound:
                                    lInt_CountNotFoundOrError += 1;
                                    lStr_StatusComplianc = Resources.lblStatusNotFound;// "Not Found";
                                    break;
                                case wsSearchXpert.SearchResultStatus.Error:
                                    lInt_CountNotFoundOrError += 1;
                                    lStr_StatusComplianc = Resources.lblStatusError;// "Error";
                                    break;
                                default:
                                    break;
                            }

                            //*** Objetos para alimentar el DataSource del GRid...........
                            lObjCompliance = new Entity.UnderWriting.Entities.Requirement.Compliance();
                            lObjCompliance.ContactId = lInt_ContactID.ToInt();
                            lObjCompliance.ClientName = lStr_NombreContacto.ToString();
                            lObjCompliance.Nombre_Rol = lStr_NombreRol.ToString();
                            lObjCompliance.Dob = lDt_Dob != null ? DateTime.Parse(lDt_Dob.ToString()) : (DateTime?)null;
                            lObjCompliance.Identificacion = lStr_Identificacion != null ? lStr_Identificacion.ToString() : "";
                            lObjCompliance.TipoIdentificacion = lStr_TypeIdentificacion != null ? lStr_TypeIdentificacion.ToString() : "";
                            lObjCompliance.statusCompliance = lStr_StatusComplianc;
                            lListObjsCompliance.Add(lObjCompliance);
                            //*** Fin seteo objects to DataSource

                            /* ESTO FUNCIONA PERO SE PIERDE CUANDO SE HACE POSTBACK !!
                            Literal litStatusCompliance = GridComplianceData.FindRowCellTemplateControl(i, (DevExpress.Web.GridViewDataColumn)GridComplianceData.Columns[5], "litstatus") as Literal;
                            if (litStatusCompliance != null)
                            {
                                litStatusCompliance.Text = lStr_StatusComplianc;
                            }
                            ++/

                        }//Fin For 




                        //Volver a cargar el grid para que no se pierda el Status de Cumplimiento al momento que se realizen PostBacks en otros Grid...
                        if (lListObjsCompliance.Count > 0)
                        {
                            GridComplianceData.DataSource = lListObjsCompliance;
                            GridComplianceData.DataBind();
                        }

                        //Verificar si hay Possible Match que notificar a Cumplimiento
                        if (lListContacInfo.Count > 0)
                        {
                            //Rutina para mandar la notification de Cumplimiento, si procede hacerlo
                            lObj_BlackListService.SendNotification(lListContacInfo.ToArray());
                        }

                        break; // No seguir iterando primer forEach

                    }//Fin Grid != null
                }
            }
            */
        }

    }
}