using DI.UnderWriting;
using DI.UnderWriting.Interfaces;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Requirements;
using DevExpress.Web;

namespace WEB.NewBusiness.NewBusiness.UserControls.Requirements
{
    public partial class UCCompliance : UC, IUC
    {
        public void Initialize() { }
        public void ClearData() { }
        protected void btnUpload_Click(object sender, EventArgs e) { }
        public void save() { }
        public void readOnly(bool x) { }
        public void edit() { }
        public void FillData() { }

        public class item
        {
            public string Requirement { get; set; }
            public string LastUpdate { get; set; }
        }

        public IEnumerable<Entity.UnderWriting.Entities.Requirement> RequirementList { get; set; }

        public string Category { get; set; }
        public IEnumerable<Entity.UnderWriting.Entities.Requirement> DataSource { get; set; }

        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator("");
        }

        public void Translator(string Lang)
        {

            GridComplianceData.Columns[0].Caption = Resources.GridCompliColumNombreRol.ToUpper();
            GridComplianceData.Columns[1].Caption = Resources.GridCompliColumClientName.ToUpper();
            GridComplianceData.Columns[2].Caption = Resources.GridCompliColumDob.ToUpper();
            GridComplianceData.Columns[3].Caption = Resources.GridCompliColumIdentifi.ToUpper();
            GridComplianceData.Columns[4].Caption = Resources.GridCompliColumTypeIdentifi.ToUpper();
            GridComplianceData.Columns[5].Caption = Resources.GridCompliColumStatusCompli.ToUpper();
            GridComplianceData.Columns[6].Caption = Resources.GridCompliColumReenviarStatus.ToUpper();
        }

        public void FillData(string pStr_ContactName)
        {
            var lObjComplianceData = ObjServices.getContactForCompliance(
                ObjServices.Corp_Id,
                ObjServices.Region_Id,
                ObjServices.Country_Id,
                ObjServices.Domesticreg_Id,
                ObjServices.State_Prov_Id,
                ObjServices.City_Id,
                ObjServices.Office_Id,
                ObjServices.Case_Seq_No,
                ObjServices.Hist_Seq_No,
                ObjServices.Language.ToInt(),
                ObjServices.CompanyId);

            this.GridComplianceData.DataSource = lObjComplianceData;
            this.GridComplianceData.DataBind();
        }

        protected void GridComplianceData_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {   //Comando del grid
            var comando = e.CommandArgs.CommandName;
            var Grid = (sender as DevExpress.Web.ASPxGridView);
            var RowIndex = e.VisibleIndex;

            var lInt_ContactID = Grid.GetRowValues(RowIndex, "ContactId"); 
            var lStr_NombreContacto = Grid.GetRowValues(RowIndex, "ClientName");
            var lStr_NombreRol = Grid.GetRowValues(RowIndex, "Nombre_Rol");
            var lDt_Dob = Grid.GetRowValues(RowIndex, "Dob");
            var lStr_Identificacion = Grid.GetRowValues(RowIndex, "Identificacion");
            var lStr_TypeIdentificacion = Grid.GetRowValues(RowIndex, "TipoIdentificacion");
            var lStr_Address = GridComplianceData.GetRowValues(RowIndex, "Address");
            var lStr_CountryOfBirth = GridComplianceData.GetRowValues(RowIndex, "CountryOfBirth");

            var lStr_ActualStatusComplianc = Grid.GetRowValues(RowIndex, "statusCompliance");
            string lStr_NewStatusComplianc = string.Empty;

            switch (comando)
            {
                case "reenviar":
                    wsSearchXpert.SearchClient lObj_BlackListService = new wsSearchXpert.SearchClient();
                    wsSearchXpert.ResultsSearchResponse lObjSearchResponse = new wsSearchXpert.ResultsSearchResponse();
                    wsSearchXpert.Fields[] lArr_ObjFields = new wsSearchXpert.Fields[2];
                    List<wsSearchXpert.ContactInformation> lListContacInfo = new List<wsSearchXpert.ContactInformation>();
                    wsSearchXpert.ContactInformation lObjContacInfo;

                    int lIntCountValidStatus = 0,
                        lIntCountInValidStatus = 0,
                        lInt_CountMatch = 0;

                    //** Asignando valores al object Request 
                    wsSearchXpert.SearchRequest lObjSearchRequest = new wsSearchXpert.SearchRequest()
                    {
                        Agency = null,
                        CompanyKey = new wsSearchXpert.CompanyKey()
                        {
                            Company_Id = ObjServices.CompanyId,
                            Corp_Id = ObjServices.Corp_Id,
                            Country_Id = ObjServices.Country_Id,
                            Region_Id = ObjServices.Region_Id
                        },
                        Source = wsSearchXpert.BaseCores.GLOBAL,
                        Status = wsSearchXpert.SearchResultStatus.Deleted, 
                        ProcessAgain = true 
                    };

                    wsSearchXpert.Fields lObjUnitField = new wsSearchXpert.Fields()
                    {
                        Display = true,
                        Name = "Name",
                        Value = lStr_NombreContacto.ToString(),
                        Type = "Name",
                        SearchType = wsSearchXpert.SearchResultTypes.Name
                    };

                    wsSearchXpert.Fields lObjUnitField2 = new wsSearchXpert.Fields()
                    {
                        CoreKey = true,
                        Display = true,
                        Name = "Source_Id",
                        Value = lInt_ContactID.ToString(),
                        Type = "Name",
                        SearchType = wsSearchXpert.SearchResultTypes.Name
                    };

                    lArr_ObjFields[0] = lObjUnitField;
                    lArr_ObjFields[1] = lObjUnitField2;

                    lObjSearchRequest.RequestFields = lArr_ObjFields;
                    lObjSearchResponse = lObj_BlackListService.SearchOnline(lObjSearchRequest);

                    switch (lObjSearchResponse.Statusk__BackingField)
                    {
                        case wsSearchXpert.SearchResultStatus.NotMatch:
                            lStr_NewStatusComplianc = Resources.lblStatusNotMatch;
                            break;
                        case wsSearchXpert.SearchResultStatus.PossibleMatch:

                            lStr_NewStatusComplianc = Resources.lblStatusPossibleMatch;

                            lObjContacInfo = new wsSearchXpert.ContactInformation()
                            {
                                FullName = lStr_NombreContacto.ToString(),
                                SourceID = lInt_ContactID.ToString(),
                                Address = lStr_Address != null ? lStr_Address.ToString() : string.Empty,
                                DateOfBirth = lDt_Dob != null ? DateTime.Parse(lDt_Dob.ToString()) : (DateTime?)null,
                                ResidenceCountry = lStr_CountryOfBirth != null ? lStr_CountryOfBirth.ToString() : string.Empty,
                                Status = wsSearchXpert.SearchResultStatus.Deleted, 
                                DateProcessed = DateTime.Now,
                                Department = "Suscripcion Vida",
                                SearchID = lObjSearchResponse.SearchIDk__BackingField,
                                Source = wsSearchXpert.BaseCores.GLOBAL,
                                UserName = ObjServices.UserFullName,
                                IdentificationNumber = lStr_Identificacion.ToString()
                            };

                            lListContacInfo.Add(lObjContacInfo);//Add to the List of ContactInfo
                            lObjContacInfo = null;
                            break;
                        case wsSearchXpert.SearchResultStatus.Match:
                            lStr_NewStatusComplianc = Resources.lblStatusMatch; //"Match";
                            lInt_CountMatch += 1;
                            break;
                        case wsSearchXpert.SearchResultStatus.Deleted:
                            break;
                        case wsSearchXpert.SearchResultStatus.NotFound:
                            //lInt_CountNOTMatch += 1;
                            lStr_NewStatusComplianc = Resources.lblStatusNotFound;// "Not Found";
                            break;
                        case wsSearchXpert.SearchResultStatus.Error:
                            lStr_NewStatusComplianc = Resources.lblStatusError;// "Error";
                            break;
                        default:
                            break;
                    }

                    if (lStr_ActualStatusComplianc.ToString() != lStr_NewStatusComplianc)
                    {
                        List<Entity.UnderWriting.Entities.Requirement.Compliance> lListObjsCompliance = new List<Entity.UnderWriting.Entities.Requirement.Compliance>();
                        Entity.UnderWriting.Entities.Requirement.Compliance lObjCompliance;

                        for (int i = 0; i <= Grid.VisibleRowCount - 1; i++)
                        {
                            var lInt_ContactID2 = Grid.GetRowValues(i, "ContactId"); 
                            var lStr_NombreContacto2 = Grid.GetRowValues(i, "ClientName");
                            var lStr_NombreRol2 = Grid.GetRowValues(i, "Nombre_Rol");
                            var lDt_Dob2 = Grid.GetRowValues(i, "Dob");
                            var lStr_Identificacion2 = Grid.GetRowValues(i, "Identificacion");
                            var lStr_TypeIdentificacion2 = Grid.GetRowValues(i, "TipoIdentificacion");
                            var lStr_ActualStatusComplianc2 = Grid.GetRowValues(i, "statusCompliance");
                            var lStr_CountryOfBirth2 = GridComplianceData.GetRowValues(i, "CountryOfBirth");

                            lObjCompliance = new Entity.UnderWriting.Entities.Requirement.Compliance()
                            {
                                ContactId = lInt_ContactID2.ToInt(),
                                ClientName = lStr_NombreContacto2.ToString(),
                                Nombre_Rol = lStr_NombreRol2.ToString(),
                                Dob = lDt_Dob2 != null ? DateTime.Parse(lDt_Dob2.ToString()) : (DateTime?)null,
                                Identificacion = lStr_Identificacion2 != null ? lStr_Identificacion2.ToString() : string.Empty,
                                TipoIdentificacion = lStr_TypeIdentificacion2 != null ? lStr_TypeIdentificacion2.ToString() : string.Empty,
                                CountryOfBirth = lStr_CountryOfBirth2 != null ? lStr_CountryOfBirth2.ToString() : string.Empty,
                                IDType = lStr_TypeIdentificacion != null ? lStr_TypeIdentificacion.ToString() : string.Empty,
                                ID = lStr_Identificacion != null ? lStr_Identificacion.ToString() : string.Empty
                            };


                            if (lInt_ContactID.ToInt() == lInt_ContactID2.ToInt())
                            {
                                lObjCompliance.statusCompliance = lStr_NewStatusComplianc;
                            }
                            else
                            {
                                lObjCompliance.statusCompliance = lStr_ActualStatusComplianc2.ToString();
                            }

                            lListObjsCompliance.Add(lObjCompliance);

                            if (lObjCompliance.statusCompliance == "Not Match" || lObjCompliance.statusCompliance == "Ninguna Coincidencia")
                                lIntCountValidStatus += 1;
                            else
                                lIntCountInValidStatus += 1;
                        }

                        if (lListObjsCompliance.Count > 0)
                        {
                            GridComplianceData.DataSource = lListObjsCompliance;
                            GridComplianceData.DataBind();
                        }

                        if (lIntCountInValidStatus == 0 && lIntCountValidStatus > 0)
                        {
                            ObjServices.saveSetValidTab(Utility.Tab.Compliance, true);
                        }

                        if (lInt_CountMatch > 0)
                        {
                            ObjServices.oPolicyManager.SetPolicyStatus(new Entity.UnderWriting.Entities.Policy.Parameter()
                            {
                                CorpId = ObjServices.Corp_Id,
                                CountryId = ObjServices.Country_Id,
                                RegionId = ObjServices.Region_Id,
                                DomesticregId = ObjServices.Domesticreg_Id,
                                StateProvId = ObjServices.State_Prov_Id,
                                CityId = ObjServices.City_Id,
                                OfficeId = ObjServices.Office_Id,
                                CaseSeqNo = ObjServices.Case_Seq_No,
                                HistSeqNo = ObjServices.Hist_Seq_No,
                                StatusChangeTypeId = 3,
                                StatusId = 33,
                                UserId = ObjServices.UserID
                            });
                        }
                        else
                        {
                            ObjServices.oPolicyManager.SetPolicyStatus(new Entity.UnderWriting.Entities.Policy.Parameter()
                            {
                                CorpId = ObjServices.Corp_Id,
                                CountryId = ObjServices.Country_Id,
                                RegionId = ObjServices.Region_Id,
                                DomesticregId = ObjServices.Domesticreg_Id,
                                StateProvId = ObjServices.State_Prov_Id,
                                CityId = ObjServices.City_Id,
                                OfficeId = ObjServices.Office_Id,
                                CaseSeqNo = ObjServices.Case_Seq_No,
                                HistSeqNo = ObjServices.Hist_Seq_No,
                                StatusChangeTypeId = 3,
                                StatusId = 17, 
                                UserId = ObjServices.UserID
                            });
                        }

                        if (lListContacInfo.Count > 0)
                        {
                            lObj_BlackListService.SendNotification(lListContacInfo.ToArray());
                        }
                    }

                    break;
            }
        }

        public void ValidateComplianceContacs(bool pBol_FillInitData = true)
        {
            string lStr_Mesj = string.Empty, lStr_StatusComplianc = string.Empty;
            int lInt_CountMatch, lInt_CountPosibleMatch, lInt_CountNOTMatch, lInt_CountNotFoundOrError;
            List<Entity.UnderWriting.Entities.Requirement.Compliance> lListObjsCompliance = new List<Entity.UnderWriting.Entities.Requirement.Compliance>();
            Entity.UnderWriting.Entities.Requirement.Compliance lObjCompliance;

            lInt_CountNotFoundOrError = lInt_CountMatch = lInt_CountPosibleMatch = lInt_CountNOTMatch = 0;

            if (pBol_FillInitData)
            {
                FillData("DummyText");
            }

            if (GridComplianceData != null)
            {
                wsSearchXpert.SearchClient lObj_BlackListService = new wsSearchXpert.SearchClient();
                wsSearchXpert.ResultsSearchResponse lObjSearchResponse = new wsSearchXpert.ResultsSearchResponse();
                wsSearchXpert.Fields[] lArr_ObjFields = new wsSearchXpert.Fields[2];//new wsSearchXpert.Fields[GridComplianceData.VisibleRowCount - 1]; /Este cuando sea una lista que se envie al servicio...
                List<wsSearchXpert.ContactInformation> lListContacInfo = new List<wsSearchXpert.ContactInformation>();
                wsSearchXpert.ContactInformation lObjContacInfo;

                wsSearchXpert.SearchRequest lObjSearchRequest = new wsSearchXpert.SearchRequest()
                {
                    Agency = "Pruebas",
                    CompanyKey = new wsSearchXpert.CompanyKey()
                    {
                        Company_Id = ObjServices.CompanyId,
                        Corp_Id = ObjServices.Corp_Id,
                        Country_Id = ObjServices.Country_Id,
                        Region_Id = ObjServices.Region_Id
                    },
                    Source = wsSearchXpert.BaseCores.GLOBAL,
                    Status = wsSearchXpert.SearchResultStatus.Deleted
                };

                for (int i = 0; i <= GridComplianceData.VisibleRowCount - 1; i++)
                {
                    var lInt_ContactID = GridComplianceData.GetRowValues(i, "ContactId");
                    var lStr_NombreContacto = GridComplianceData.GetRowValues(i, "ClientName"); 
                    var lStr_NombreRol = GridComplianceData.GetRowValues(i, "Nombre_Rol");
                    var lDt_Dob = GridComplianceData.GetRowValues(i, "Dob");
                    var lStr_Identificacion = GridComplianceData.GetRowValues(i, "Identificacion");
                    var lStr_TypeIdentificacion = GridComplianceData.GetRowValues(i, "TipoIdentificacion");
                    var lStr_Address = GridComplianceData.GetRowValues(i, "Address");
                    var lStr_CountryOfBirth = GridComplianceData.GetRowValues(i, "CountryOfBirth");
                    

                    wsSearchXpert.Fields lObjUnitField = new wsSearchXpert.Fields()
                    {
                        Display = true,
                        Name = "Name",
                        Value = lStr_NombreContacto.ToString(),
                        Type = "Name",
                        SearchType = wsSearchXpert.SearchResultTypes.Name
                    };

                    wsSearchXpert.Fields lObjUnitField2 = new wsSearchXpert.Fields()
                    {
                        CoreKey = true,
                        Display = true,
                        Name = "Source_Id",
                        Value = lInt_ContactID.ToString(),
                        Type = "Name",
                        SearchType = wsSearchXpert.SearchResultTypes.Name
                    };

                    lArr_ObjFields[0] = lObjUnitField;
                    lArr_ObjFields[1] = lObjUnitField2;

                    lObjSearchRequest.RequestFields = lArr_ObjFields;
                    lObjSearchResponse = lObj_BlackListService.SearchOnline(lObjSearchRequest);

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

                            lObjContacInfo = new wsSearchXpert.ContactInformation()
                            {
                                FullName = lStr_NombreContacto.ToString(),
                                SourceID = lInt_ContactID.ToString(),
                                Address = lStr_Address != null ? lStr_Address.ToString() : "",
                                DateOfBirth = lDt_Dob != null ? DateTime.Parse(lDt_Dob.ToString()) : (DateTime?)null,
                                ResidenceCountry = lStr_CountryOfBirth != null ? lStr_CountryOfBirth.ToString() : "",
                                Status = wsSearchXpert.SearchResultStatus.Deleted,
                                DateProcessed = DateTime.Now,
                                Department = "Suscripcion Vida",
                                SearchID = lObjSearchResponse.SearchIDk__BackingField,
                                Source = wsSearchXpert.BaseCores.GLOBAL,
                                UserName = ObjServices.UserFullName,
                                IdentificationNumber = lStr_Identificacion.ToString()
                            };

                            lListContacInfo.Add(lObjContacInfo);
                            lObjContacInfo = null;
                            break;
                        case wsSearchXpert.SearchResultStatus.Match:
                            lStr_Mesj += "El contacto " + lStr_NombreContacto + " tiene un status de Match";
                            lInt_CountMatch += 1;
                            lStr_StatusComplianc = Resources.lblStatusMatch;
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

                    lObjCompliance = new Entity.UnderWriting.Entities.Requirement.Compliance()
                    {
                        ContactId = lInt_ContactID.ToInt(),
                        ClientName = lStr_NombreContacto.ToString(),
                        Nombre_Rol = (lStr_NombreRol == null) ? string.Empty : lStr_NombreRol.ToString(),
                        Dob = lDt_Dob != null ? DateTime.Parse(lDt_Dob.ToString()) : (DateTime?)null,
                        Identificacion = lStr_Identificacion != null ? lStr_Identificacion.ToString() : string.Empty,
                        TipoIdentificacion = lStr_TypeIdentificacion != null ? lStr_TypeIdentificacion.ToString() : string.Empty,
                        statusCompliance = lStr_StatusComplianc,
                        CountryOfBirth = lStr_CountryOfBirth != null ? lStr_CountryOfBirth.ToString() : string.Empty ,
                        IDType = lStr_TypeIdentificacion != null ? lStr_TypeIdentificacion.ToString() : string.Empty,
                        ID = lStr_Identificacion != null ? lStr_Identificacion.ToString() : string.Empty
                    };

                    lListObjsCompliance.Add(lObjCompliance);
                }

                if (lInt_CountPosibleMatch > 0 || lInt_CountMatch > 0 || lInt_CountNotFoundOrError > 0)
                {
                    ObjServices.saveSetValidTab(Utility.Tab.Compliance, false);

                    string lStr_MsjFinalUser = string.Empty;

                    if (lInt_CountNotFoundOrError > 0)
                    {
                        lStr_MsjFinalUser = Resources.msjCompliErroNotFound + "<br/>";
                    }

                    if (lInt_CountPosibleMatch > 0)
                    {
                        lStr_MsjFinalUser += Resources.msjCompliPossibleMatch + "<br/> ";
                    }

                    if (lInt_CountMatch > 0)
                    {
                        lStr_MsjFinalUser += Resources.msjCompliMatch + "<br/> ";
                    }

                    this.MessageBox(lStr_MsjFinalUser, Title: "Advertencia");
                }

                if (lInt_CountPosibleMatch == 0 && lInt_CountMatch == 0 && lInt_CountNotFoundOrError == 0 && (GridComplianceData.VisibleRowCount == lInt_CountNOTMatch))
                {
                    ObjServices.saveSetValidTab(Utility.Tab.Compliance, true);
                }

                if (lInt_CountMatch > 0)
                {
                    ObjServices.oPolicyManager.SetPolicyStatus(new Entity.UnderWriting.Entities.Policy.Parameter()
                    {
                        CorpId = ObjServices.Corp_Id,
                        CountryId = ObjServices.Country_Id,
                        RegionId = ObjServices.Region_Id,
                        DomesticregId = ObjServices.Domesticreg_Id,
                        StateProvId = ObjServices.State_Prov_Id,
                        CityId = ObjServices.City_Id,
                        OfficeId = ObjServices.Office_Id,
                        CaseSeqNo = ObjServices.Case_Seq_No,
                        HistSeqNo = ObjServices.Hist_Seq_No,
                        StatusChangeTypeId = 3,
                        StatusId = 33, 
                        UserId = ObjServices.UserID
                    });
                }
                else
                {
                    if (lInt_CountMatch == 0)
                    {
                        ObjServices.oPolicyManager.SetPolicyStatus(new Entity.UnderWriting.Entities.Policy.Parameter()
                        {
                            CorpId = ObjServices.Corp_Id,
                            CountryId = ObjServices.Country_Id,
                            RegionId = ObjServices.Region_Id,
                            DomesticregId = ObjServices.Domesticreg_Id,
                            StateProvId = ObjServices.State_Prov_Id,
                            CityId = ObjServices.City_Id,
                            OfficeId = ObjServices.Office_Id,
                            CaseSeqNo = ObjServices.Case_Seq_No,
                            HistSeqNo = ObjServices.Hist_Seq_No,
                            StatusChangeTypeId = 3,
                            StatusId = 17, 
                            UserId = ObjServices.UserID
                        });
                    }
                }

                if (lListObjsCompliance.Count > 0)
                {
                    GridComplianceData.DataSource = lListObjsCompliance;
                    GridComplianceData.DataBind();
                }

                if (lListContacInfo.Count > 0)
                {
                    lObj_BlackListService.SendNotification(lListContacInfo.ToArray());
                }
            }
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            throw new NotImplementedException();
        }
    }
}